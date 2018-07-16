/*
 * Pascal "Liquidz" H.
 * Jannik Herrmann, Jannic Walder, Marc Weißelstein
 */

using RetroTable.Board;
using RetroTable.MySql;
using RetroTable.Pong;
using RetroTable.Pong.Components;
using RetroTable.UserSystem;
using System;
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

        public static event ButtonPressed onButtonPressed;
        public delegate void ButtonPressed(PinMapping button);
        public static event ButtonReleased onButtonReleased;
        public delegate void ButtonReleased(PinMapping button);
        public static event ValueChanged onValueChanged;
        public delegate void ValueChanged(PinMapping button, int newValue);

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

        /// <summary> False, if no Arduino is found. </summary>
        internal static bool ArduinoMode = true;

        /// <summary> Static Field that represents the connection to the Arduino. </summary>
        internal static Arduino Arduino { get; private set; }

        internal MainMenuForm MainMenuform { get; private set; }
        /// <summary> Field that is holding the instance of the <see cref="Pongform"/>. </summary>
        internal PongForm Pongform { get; private set; }

        /// <summary> Holding the instance of a Player. </summary>
        internal Player Player1, Player2;

        /// <summary> Holding the instance of the <see cref="Ball"/>. </summary>
        internal Ball Ball;

        /// <summary> True, if a match is running. </summary>
        internal bool Started;

        /// <summary> True, if the Singleton Class is initialized. </summary>
        private bool _initialized;

        /// <summary> Initialization of the Singleton Class </summary>
        internal void Initialize()
        {
            if (_initialized)
                return;

            Database.Init();

            try
            {
                Arduino = new Arduino("COM3");
                ArduinoHelper.Setup();
            }
            catch (Exception)
            {
                //try
                //{
                //    Arduino = new Arduino("COM5");
                //    ArduinoHelper.Setup();
                //}
                //catch (Exception)
                {
                    ArduinoMode = false;
                    MessageBox.Show("Es kann über W,S und Up,Down gespielt werden.\nMit Leertaste startet die Runde.", "Kein Arduino gefunden!");
                }
            }

            MainMenuform = new MainMenuForm();
            Pongform = new PongForm();

            if (ArduinoMode)
            {
                Arduino.AnalogPinUpdated += AnalogPinUpdated;
                Arduino.DigitalPinUpdated += DigitalPinUpdated;
            }

            Application.Run(MainMenuform);

            _initialized = true;
        }

        /// <summary> This Event is triggered when a digital pin is updated. </summary>
        /// <param name="pin"> The updated Pin </param>
        /// <param name="state"> the changed Value (HIGH or LOW) </param>
        private static void DigitalPinUpdated(PinMapping pin, byte state)
        {
            if (state == Arduino.HIGH)
            {
                switch (pin)
                {
                    case PinMapping.ButtonStart:
                        onButtonPressed?.Invoke(pin);
                        break;
                }
            }
            else if (state == Arduino.LOW)
            {
                switch (pin)
                {
                    case PinMapping.ButtonStart:
                        onButtonReleased?.Invoke(pin);
                        break;
                }
            }
        }

        /// <summary> Event that triggers, when the value of an analog pin from a Player was changed. </summary>
        /// <param name="pin"> The updated Pin </param>
        /// <param name="value"> The changed Value </param>
        private void AnalogPinUpdated(PinMapping pin, int value)
        {
            if (pin == PinMapping.Player1Bar || pin == PinMapping.Player2Bar)
                onValueChanged?.Invoke(pin, value.Map(0, 1023, 0, 100));
        }

        /// <summary> This method writes the message into the debug console. Only works if the application is compiled in debugmode.  </summary>    
        internal static void DebugMessage(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }
    }
}
