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

        internal static bool DesktopMode = false;

        /// <summary> False, wenn die Software ohne Datenbank betrieben werden soll. </summary>
        internal const bool Databasemode = true;

        /// <summary> Static Field that represents the connection to the Arduinos. </summary>
        internal static Arduino ArduinoLeonardo { get; private set; }
        internal static Arduino ArduinoUno { get; private set; }

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
                if (!DesktopMode)
                    ArduinoLeonardo = new Arduino("COM5");//COM5
                ArduinoUno = new Arduino(DesktopMode ? "COM3" : "COM7");//COM7
            }
            catch (Exception)
            {
                ArduinoMode = false;
                MessageBox.Show("Es kann über W,S und Up,Down gespielt werden.\nMit Leertaste startet die Runde.", "Kein Arduino gefunden!");
            }

            MainMenuform = new MainMenuForm(); //Instantiating MainMenu

            Pong = new Pong.Pong(); //Instantiating the Game Pong
            Bounce = new Bounce.Bounce();

            if (ArduinoMode)
            {
                ArduinoHelper.Setup();
                ArduinoUno.AnalogPinUpdated += AnalogPinUpdated;
                if (!DesktopMode)
                    ArduinoLeonardo.DigitalPinUpdated += DigitalPinUpdated;
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
            ArduinoDataTest.AddDigitalData(pin, state);
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

        private int[] SliderLastValue = new int[4];
        public static List<int>[] SliderSample = new List<int>[] {
            new List<int>(),
            new List<int>(),
            new List<int>(),
            new List<int>(),
        };
        public static int[] SliderDistorted = new int[4];

        private readonly int SamplesForAverage = 1;

        private void CleanValue(Slider slider, int value, int dampening, int minimumValue)
        {
            SliderLastValue[(int)slider] = value;

            if (value < minimumValue) return;

            double average = SliderSample[(int)slider].Count == 0 ? 0 : SliderSample[(int)slider].Average();

            //if (value > average + 500)
            //{
            //    SliderDistorted[(int)slider]++;

            //    if (SliderDistorted[(int)slider] < 5)
            //        return;
            //}
            //else
            //{
            //    SliderDistorted[(int)slider] = 0;
            //}

            if (value > average + dampening)
            {
                System.Diagnostics.Debug.WriteLine("Hohe Schwankung " + (value - average));
                value = value - dampening;
            }
            else if (value < average - dampening)
            {
                System.Diagnostics.Debug.WriteLine("Niedrige Schwankung " + (average - value));
                value = value + dampening;
            }

            if (value != -1)
                SliderSample[(int)slider].Add(value);

            if (SliderSample[(int)slider].Count > SamplesForAverage)
                SliderSample[(int)slider].RemoveAt(0);
        }

        /// <summary> Event that triggers, when the value of an analog pin from a Player was changed. </summary>
        /// <param name="pin"> The updated Pin </param>
        /// <param name="value"> The changed Value </param>
        private void AnalogPinUpdated(PinMapping pin, int value)
        {
#if DEBUG
            if (pin == PinMapping.Player1SliderSensLeft || pin == PinMapping.Player1SliderSensRight || pin == PinMapping.Player2SliderSensLeft || pin == PinMapping.Player2SliderSensRight)
                ArduinoDataTest.AddAnalogData(pin, value);
#endif

            if (pin == PinMapping.Player1SliderSensLeft)
            {
                CleanValue(Slider.Player1Left, value, 300, 400);
                UpdatePlayer1Position();
            }
            else if (pin == PinMapping.Player1SliderSensRight)
            {
                CleanValue(Slider.Player1Right, value, 300, 400);
                UpdatePlayer1Position();
            }

            else if (pin == PinMapping.Player2SliderSensLeft)
            {
                CleanValue(Slider.Player2Left, value, 350, 400);
                UpdatePlayer2Position();
            }
            else if (pin == PinMapping.Player2SliderSensRight)
            {
                CleanValue(Slider.Player2Right, value, 350, 400);
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

        private const int lowest1Value = -2200;
        private const int highest1Value = 2400;
        private List<int> TotalSample1 = new List<int>();
        private void UpdatePlayer1Position()
        {
            //int leftAverage = SliderSample[(int)Slider.Player1Left].Count == 0 ? 0 : (int)SliderSample[(int)Slider.Player1Left].Average();
            //int rightAverage = SliderSample[(int)Slider.Player1Right].Count == 0 ? 0 : (int)SliderSample[(int)Slider.Player1Right].Average();

            int leftAverage = SliderSample[(int)Slider.Player1Left].Count == 0 ? 0 : (int)SliderSample[(int)Slider.Player1Left][0];
            int rightAverage = SliderSample[(int)Slider.Player1Right].Count == 0 ? 0 : (int)SliderSample[(int)Slider.Player1Right][0];

            if (SliderLastValue[(int)Slider.Player1Left] > 500 || SliderLastValue[(int)Slider.Player1Right] > 500)
            {
                int total = rightAverage - leftAverage;
                total = Math.Max(0, Math.Min(100, total.Map(lowest1Value, highest1Value, 0, 100)));

                TotalSample1.Add(total);

                if (TotalSample1.Count > 5)
                    TotalSample1.RemoveAt(0);

                onValueChanged.Invoke(PinMapping.Player1SliderTotal, (int)TotalSample1.Average());
                //pnlSlider.Location = new Point(Math.Max(0, Math.Min(800, total)), pnlSlider.Location.Y);
            }
        }

        private const int lowest2Value = -2400;
        private const int highest2Value = 2400;
        private void UpdatePlayer2Position()
        {
            int leftAverage = SliderSample[(int)Slider.Player2Left].Count == 0 ? 0 : (int)SliderSample[(int)Slider.Player2Left].Average();
            int rightAverage = SliderSample[(int)Slider.Player2Right].Count == 0 ? 0 : (int)SliderSample[(int)Slider.Player2Right].Average();

            if (SliderLastValue[(int)Slider.Player2Left] > 500 || SliderLastValue[(int)Slider.Player2Right] > 500)
            {
                int total = rightAverage - leftAverage;
                total = Math.Max(0, Math.Min(100, total.Map(lowest2Value, highest2Value, 0, 100)));

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
