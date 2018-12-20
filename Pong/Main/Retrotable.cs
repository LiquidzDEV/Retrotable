/*
 * Pascal "Liquidz" H.
 * Jannik Herrmann, Jannic Walder, Marc Weißelstein
 */

using RetroTable.Board;
using RetroTable.MySql;
using RetroTable.Test;
using RetroTable.UserSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace RetroTable.Main
{
    /// <summary>
    /// Main-Class of the Application.
    /// This Class is a Singleton-Class, that means it can only be one instance at a time.
    /// Singleton-Classes are initialized and stored in a static field.
    /// The Entrypoint of the Application is in <see cref="Program"/>.
    /// </summary>
    internal class Retrotable
    {
        /// <summary> The private field where the instance is stored. </summary>
        private static Retrotable _instance;

        /// <summary> Makes the instance of Pong internal seeable, creates an instances if no instance is initialized. </summary>
        internal static Retrotable Instance => _instance ?? (_instance = new Retrotable());

        //Shortened Property, same as:
        //internal static Pong Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //            _instance = new Pong();
        //        return _instance;
        //    }
        //}

        public static event ButtonPressed onButtonPressed;
        public delegate void ButtonPressed(PinMapping button);
        public static event ButtonReleased onButtonReleased;
        public delegate void ButtonReleased(PinMapping button);
        public static event ValueChanged onValueChanged;
        public delegate void ValueChanged(PinMapping button, int newValue);
        public static event EncoderRotated onEncoderRotated;
        public delegate void EncoderRotated(bool clockwise);

        /// <summary> False, if no Arduino is found. </summary>
        internal static bool ArduinoMode = true;

        /// <summary> False, wenn die Software ohne Datenbank betrieben werden soll. </summary>
        internal const bool Databasemode = false;

        /// <summary> Static Field that represents the connection to the Arduino. </summary>
        internal static Arduino Arduino { get; private set; }

        /// <summary> Holds the Instance for the MainMenu </summary>
        internal MainMenuForm MainMenuform { get; private set; }

        /// <summary> Field that is holding the instance of the Game <see cref="Pong"/>. </summary>
        internal Pong.Pong Pong { get; private set; }

        internal Bounce.Bounce Bounce { get; private set; }

        internal static Random Random { get; } = new Random();

        internal static LiveGameData LiveGameData = new LiveGameData();

        /// <summary> True, if the Singleton Class is initialized. </summary>
        private bool _initialized;

        /// <summary> Initialization of the Singleton Class </summary>
        internal void Initialize()
        {
            if (_initialized)
                return;

            if (Databasemode)
            {
                Database.Init();
                Retrotable.UpdateLiveGameData();
            }
            else
            {
                UserManager.CreateUser("Pascal");
                UserManager.CreateUser("Test");
            }

            try
            {
                Arduino = new Arduino("COM7");//COM5
            }
            catch (Exception)
            {
                try
                {
                    Arduino = new Arduino("COM1");
                }
                catch (Exception)
                {
                    ArduinoMode = false;
                    MessageBox.Show("Es kann über W,S und Up,Down gespielt werden.\nMit Leertaste startet die Runde.", "Kein Arduino gefunden!");
                }
            }

            MainMenuform = new MainMenuForm(); //Instantiating MainMenu

            Pong = new Pong.Pong(); //Instantiating the Game Pong
            Bounce = new Bounce.Bounce();

            if (ArduinoMode)
            {
                ArduinoHelper.Setup();
                Arduino.AnalogPinUpdated += AnalogPinUpdated;
                Arduino.DigitalPinUpdated += DigitalPinUpdated;
            }

            Application.Run(MainMenuform);

            _initialized = true;
        }

        /// <summary> This Event is triggered when a digital pin is updated. </summary>
        /// <param name="pin"> The updated Pin </param>
        /// <param name="state"> the changed Value (HIGH or LOW) </param>
        private void DigitalPinUpdated(PinMapping pin, byte state)
        {

#if DEBUG           
            ArduinoDataTest.AddData(pin, state);
#endif

            if (pin == PinMapping.EncoderDT)
            {
                DT = state == Arduino.HIGH ? true : false;
                UpdateEncoder();
            }
            else if (pin == PinMapping.EncoderCLK)
            {
                CLK = state == Arduino.HIGH ? true : false;
                UpdateEncoder();
            }

            if (state == Arduino.HIGH)
            {
                switch (pin)
                {
                    case PinMapping.EncoderSW:
                        onButtonReleased?.Invoke(pin);
                        break;
                    case PinMapping.Player1Buttons:
                    case PinMapping.Player2Buttons:
                        onButtonPressed?.Invoke(pin);
                        break;
                }
            }
            else if (state == Arduino.LOW)
            {
                switch (pin)
                {
                    case PinMapping.EncoderSW:
                        onButtonPressed?.Invoke(pin);
                        break;
                    case PinMapping.Player1Buttons:
                    case PinMapping.Player2Buttons:
                        onButtonReleased?.Invoke(pin);
                        break;
                }
            }
        }

        private int Player1LastLeftValue, Player1LastRightValue;
        private int Player2LastLeftValue, Player2LastRightValue;

        private List<int> Player1LeftSample = new List<int>();
        private List<int> Player1RightSample = new List<int>();
        private List<int> Player2LeftSample = new List<int>();
        private List<int> Player2RightSample = new List<int>();

        private readonly int AverageValue = 5;

        /// <summary> Event that triggers, when the value of an analog pin from a Player was changed. </summary>
        /// <param name="pin"> The updated Pin </param>
        /// <param name="value"> The changed Value </param>
        private void AnalogPinUpdated(PinMapping pin, int value)
        {
#if DEBUG
            if (pin == PinMapping.Player1SliderSensLeft || pin == PinMapping.Player1SliderSensRight || pin == PinMapping.Player2SliderSensLeft || pin == PinMapping.Player2SliderSensRight)
                ArduinoDataTest.AddData(pin, value);
#endif

            if (pin == PinMapping.Player1SliderSensLeft)
            {
                Player1LastLeftValue = value;
                if (value > 500)
                    Player1LeftSample.Add(value);
                if (Player1LeftSample.Count >= AverageValue)
                    Player1LeftSample.RemoveAt(0);
                UpdatePlayer1Position();
            }
            else if (pin == PinMapping.Player1SliderSensRight)
            {
                Player1LastRightValue = value;
                if (value > 500)
                    Player1RightSample.Add(value);
                if (Player1RightSample.Count >= AverageValue)
                    Player1RightSample.RemoveAt(0);
                UpdatePlayer1Position();
            }

            else if (pin == PinMapping.Player2SliderSensLeft)
            {
                Player2LastLeftValue = value;
                if (value > 500)
                    Player2LeftSample.Add(value);
                if (Player2LeftSample.Count >= AverageValue)
                    Player2LeftSample.RemoveAt(0);
                UpdatePlayer2Position();
            }
            else if (pin == PinMapping.Player2SliderSensRight)
            {
                Player2LastRightValue = value;
                if (value > 500)
                    Player2RightSample.Add(value);
                if (Player2RightSample.Count >= AverageValue)
                    Player2RightSample.RemoveAt(0);
                UpdatePlayer2Position();
            }
        }

        private bool? first;
        private bool DT, CLK, counted;
        private void UpdateEncoder()
        {
            // Wurde gerade ein drehvorgang beendet und sind beide signale wieder 0, kann ein neuer drehvorgang beginnen

            if (!DT && !CLK && counted)
            {
                first = null;
                counted = false;
            }

            // Im Uhrzeigersinn zuerst CLK dann DT (Links = 1)

            if (first == null && CLK)
            {
                first = false;
            }
            else if (!counted && first == false && DT)
            {
                //LINKS
                onEncoderRotated?.Invoke(false);
                counted = true;
            }

            // Gegen den Uhrzeigersinn zuerst DT dann CLK (Rechts = 2)

            else if (first == null && DT)
            {
                first = true;
            }
            else if (!counted && first == true && CLK)
            {
                //RECHTS
                onEncoderRotated?.Invoke(true);
                counted = true;
            }
        }

        private void UpdatePlayer1Position()
        {
            int leftAverage = Player1LeftSample.Count == 0 ? 0 : (int)Player1LeftSample.Average();
            int rightAverage = Player1RightSample.Count == 0 ? 0 : (int)Player1RightSample.Average();

            if (Player1LastLeftValue > 500 || Player1LastRightValue > 500)
            {
                int total = rightAverage - leftAverage;
                total = Math.Max(0, Math.Min(100, total.Map(-1300, 1200, 0, 100)));

                onValueChanged.Invoke(PinMapping.Player1SliderTotal, total);
                //pnlSlider.Location = new Point(Math.Max(0, Math.Min(800, total)), pnlSlider.Location.Y);
            }
        }

        private void UpdatePlayer2Position()
        {
            int leftAverage = Player2LeftSample.Count == 0 ? 0 : (int)Player2LeftSample.Average();
            int rightAverage = Player2RightSample.Count == 0 ? 0 : (int)Player2RightSample.Average();

            if (Player2LastLeftValue > 500 || Player2LastRightValue > 500)
            {
                int total = rightAverage - leftAverage;
                total = Math.Max(0, Math.Min(100, total.Map(-1300, 1200, 0, 100)));

                onValueChanged.Invoke(PinMapping.Player2SliderTotal, total);
                //pnlSlider.Location = new Point(Math.Max(0, Math.Min(800, total)), pnlSlider.Location.Y);
            }
        }

        internal static void UpdateLiveGameData()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                if (Databasemode)
                    Database.Game.UpdateGameData(LiveGameData);
            }).Start();
        }
    }
}
