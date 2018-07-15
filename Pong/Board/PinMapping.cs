namespace RetroTable.Board
{
    /// <summary>
    /// <para> Enum to name the connected pins. </para>
	/// <para> Improves the readability of the code and prevents from triggering the wrong pins on the Board. </para>
    /// </summary>
    public enum PinMapping
    {
        ButtonStart = 4, // Closingcontact of the startbuttons
        Player1ButtonLed = 2, // Led Startbutton Player 1
        Player2ButtonLed = 3, // Led Startbutton Player 2
        Player1LedGreen = 6, //
        Player1LedRed = 5, //
        Player2LedGreen = 11, //
        Player2LedRed = 12, // 
        Player1Bar = 0, // Analog value from the Player 1 potentiometer
        Player2Bar = 1 // Analog value from the Player 2 potentiometer
    }
}
