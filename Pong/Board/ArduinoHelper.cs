using RetroTable.Main;
using System.Timers;

namespace RetroTable.Board
{
    /// <summary> Helperclass to access the Hardware connected through the Arduino Leonardo on the Lattepanda. </summary>
    public static class ArduinoHelper
    {
        /// <summary> Configures the pins from the arduino for the project. </summary>
        public static void Setup()
        {
            Retrotable.Arduino.PinMode(PinMapping.ButtonStart, Arduino.INPUT);
            Retrotable.Arduino.PinMode(PinMapping.Player1ButtonLed, Arduino.OUTPUT);
            Retrotable.Arduino.PinMode(PinMapping.Player2ButtonLed, Arduino.OUTPUT);

            Retrotable.Arduino.PinMode(PinMapping.Player1LedGreen, Arduino.OUTPUT);
            Retrotable.Arduino.PinMode(PinMapping.Player1LedRed, Arduino.OUTPUT);
            Retrotable.Arduino.PinMode(PinMapping.Player2LedGreen, Arduino.OUTPUT);
            Retrotable.Arduino.PinMode(PinMapping.Player2LedRed, Arduino.OUTPUT);

            Retrotable.Arduino.PinMode(PinMapping.Player1Bar, Arduino.ANALOG);
            Retrotable.Arduino.PinMode(PinMapping.Player2Bar, Arduino.ANALOG);

            SetStartLeds(true, true);

            _blinkTimer = new Timer(500)
            {
                AutoReset = true
            };

            _blinkTimer.Elapsed += delegate
            {
                var pin = _blinkPlayer ? PinMapping.Player1ButtonLed : PinMapping.Player2ButtonLed;
                _blinkState = !_blinkState;
                Retrotable.Arduino.DigitalWrite(pin, _blinkState ? Arduino.HIGH : Arduino.LOW);
            };
        }

        /// <summary>
        /// Sets the player LEDs to green or red, depending on the bools given.
        /// </summary>
        /// <param name="player1">If true, the player1 LED is green, otherwise red</param>
        /// <param name="player2">If true, the player2 LED is green, otherwise red</param>
        [System.Obsolete("DUO-LEDs are not implemented!", true)]
        public static void SetLeds(bool player1, bool player2)
        {
            if (!Retrotable.ArduinoMode) return;

            if (player1)
            {
                Retrotable.Arduino.DigitalWrite(PinMapping.Player1LedRed, Arduino.LOW);
                Retrotable.Arduino.DigitalWrite(PinMapping.Player1LedGreen, Arduino.HIGH);
            }
            else
            {
                Retrotable.Arduino.DigitalWrite(PinMapping.Player1LedGreen, Arduino.LOW);
                Retrotable.Arduino.DigitalWrite(PinMapping.Player1LedRed, Arduino.HIGH);
            }
            if (player2)
            {
                Retrotable.Arduino.DigitalWrite(PinMapping.Player2LedRed, Arduino.LOW);
                Retrotable.Arduino.DigitalWrite(PinMapping.Player2LedGreen, Arduino.HIGH);
            }
            else
            {
                Retrotable.Arduino.DigitalWrite(PinMapping.Player2LedGreen, Arduino.LOW);
                Retrotable.Arduino.DigitalWrite(PinMapping.Player2LedRed, Arduino.HIGH);
            }
        }

        /// <summary>
        /// Sets the LEDs from the player startbuttons to on or off, depending on the given bool.
        /// </summary>
        /// <param name="player1">If true, the LED from the player 1 startbutton is on</param>
        /// <param name="player2">If true, the LED from the player 2 startbutton is on</param>
        public static void SetStartLeds(bool player1, bool player2)
        {
            if (!Retrotable.ArduinoMode) return;

            Retrotable.Arduino.DigitalWrite(PinMapping.Player1ButtonLed, player1 ? Arduino.HIGH : Arduino.LOW);
            Retrotable.Arduino.DigitalWrite(PinMapping.Player2ButtonLed, player2 ? Arduino.HIGH : Arduino.LOW);
        }

        private static Timer _blinkTimer;
        private static bool _blinkPlayer = false;
        private static bool _blinkState = false;

        /// <summary>
        /// Starts the blinking for a players startbutton.
        /// </summary>
        /// <param name="player1">If true, the player 1 startbutton will blink, otherwise the player 2 startbutton</param>
        public static void StartBlinking(bool player1)
        {
            if (!Retrotable.ArduinoMode) return;
            _blinkPlayer = player1;
            _blinkTimer.Enabled = true;
        }

        /// <summary> Stops the blinking for the startbuttons. </summary>
        public static void StopBlinking()
        {
            _blinkTimer.Enabled = false;
        }

    }
}
