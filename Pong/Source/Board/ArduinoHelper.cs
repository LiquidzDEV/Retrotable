using LattePanda.Firmata;
using System.Timers;

namespace Pong.Source
{
    public static class ArduinoHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Setup()
        {
            Pong.Arduino.PinMode(PinMapping.ButtonStart, Arduino.INPUT);
            Pong.Arduino.PinMode(PinMapping.Player1ButtonLed, Arduino.OUTPUT);
            Pong.Arduino.PinMode(PinMapping.Player2ButtonLed, Arduino.OUTPUT);

            Pong.Arduino.PinMode(PinMapping.Player1LedGreen, Arduino.OUTPUT);
            Pong.Arduino.PinMode(PinMapping.Player1LedRed, Arduino.OUTPUT);
            Pong.Arduino.PinMode(PinMapping.Player2LedGreen, Arduino.OUTPUT);
            Pong.Arduino.PinMode(PinMapping.Player2LedRed, Arduino.OUTPUT);

            Pong.Arduino.PinMode(PinMapping.Player1Bar, Arduino.ANALOG);
            Pong.Arduino.PinMode(PinMapping.Player2Bar, Arduino.ANALOG);

            SetStartLeds(true, true);

            Blinktimer = new Timer(500);
            Blinktimer.AutoReset = true;
        }

        [System.Obsolete("DUO-LEDs sind zurzeit nicht verbaut!")]
        public static void SetLeds(bool player1, bool player2)
        {
            if (!Pong.ArduinoMode) return;

            if (player1)
            {
                Pong.Arduino.DigitalWrite(PinMapping.Player1LedRed, Arduino.LOW);
                Pong.Arduino.DigitalWrite(PinMapping.Player1LedGreen, Arduino.HIGH);
            }
            else
            {
                Pong.Arduino.DigitalWrite(PinMapping.Player1LedGreen, Arduino.LOW);
                Pong.Arduino.DigitalWrite(PinMapping.Player1LedRed, Arduino.HIGH);
            }
            if (player2)
            {
                Pong.Arduino.DigitalWrite(PinMapping.Player2LedRed, Arduino.LOW);
                Pong.Arduino.DigitalWrite(PinMapping.Player2LedGreen, Arduino.HIGH);
            }
            else
            {
                Pong.Arduino.DigitalWrite(PinMapping.Player2LedGreen, Arduino.LOW);
                Pong.Arduino.DigitalWrite(PinMapping.Player2LedRed, Arduino.HIGH);
            }
        }

        public static void SetStartLeds(bool player1, bool player2)
        {
            Pong.Arduino.DigitalWrite(PinMapping.Player1ButtonLed, player1 ? Arduino.HIGH : Arduino.LOW);
            Pong.Arduino.DigitalWrite(PinMapping.Player2ButtonLed, player2 ? Arduino.HIGH : Arduino.LOW);
        }

        private static Timer Blinktimer;

        public static void StartBlinking(bool player1)
        {
            Blinktimer.Elapsed += delegate
            {
                var pin = player1 ? PinMapping.Player1ButtonLed : PinMapping.Player2ButtonLed;
                Pong.Arduino.DigitalWrite(pin, Pong.Arduino.digitalRead(pin) > 0 ? Arduino.LOW : Arduino.HIGH);
            };
            Blinktimer.Enabled = true;
        }

        public static void StopBlinking()
        {
            Blinktimer.Enabled = false;
        }

    }
}
