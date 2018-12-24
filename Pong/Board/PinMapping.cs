namespace RetroTable.Board
{
    /// <summary>
    /// <para> Enum to name the connected pins. </para>
	/// <para> Improves the readability of the code and prevents from triggering the wrong pins on the Board. </para>
    /// </summary>
    public enum PinMapping
    {
        Player1Buttons = 7,
        Player2Buttons = 8,
        EncoderSW = 0,
        EncoderDT = 15,
        EncoderCLK = 14,
        Player1SliderSensLeft = 9,
        Player1SliderSensRight = 10,
        Player1SliderTotal = 100,
        Player2SliderSensLeft = 13,
        Player2SliderSensRight = 2,
        Player2SliderTotal = 101,
        Player1ButtonLeftLed = 4,
        Player1ButtonRightLed = 5,
        Player2ButtonLeftLed = 6,
        Player2ButtonRightLed = 12,
    }
}
