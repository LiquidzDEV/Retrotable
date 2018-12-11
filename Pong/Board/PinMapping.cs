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
        EncoderSW = 1,
        EncoderDT = 2,
        EncoderCLK = 3,
        Player1SliderSensLeft = 4,
        Player1SliderSensRight = 5,
        Player1SliderTotal = 100,
        Player2SliderSensLeft = 14,
        Player2SliderSensRight = 15,
        Player2SliderTotal = 101,
        Player1ButtonLeftLed = 9,
        Player1ButtonRightLed = 10,
        Player2ButtonLeftLed = 11,
        Player2ButtonRightLed = 12,
    }
}
