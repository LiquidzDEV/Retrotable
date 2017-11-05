using LattePanda.Firmata;

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

            Pong.Arduino.PinMode(PinMapping.Player1LedGreen, Arduino.OUTPUT);
            Pong.Arduino.PinMode(PinMapping.Player1LedRed, Arduino.OUTPUT);
            Pong.Arduino.PinMode(PinMapping.Player2LedGreen, Arduino.OUTPUT);
            Pong.Arduino.PinMode(PinMapping.Player2LedRed, Arduino.OUTPUT);

            Pong.Arduino.PinMode(PinMapping.Player1Bar, Arduino.ANALOG);
            Pong.Arduino.PinMode(PinMapping.Player2Bar, Arduino.ANALOG);

            SetLeds(true, true);
        }

        public static void SetLeds(bool player1, bool player2)
        {
            if (!Pong.ARDUINOMODE) return;

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

    }
}
