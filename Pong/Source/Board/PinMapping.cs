namespace Pong.Source
{
    /// <summary>
    /// <para> Enum to name the connected pins. </para>
	/// <para> Improves the readability of the code and prevents from triggering the wrong pins on the Board. </para>
    /// </summary>
    public enum PinMapping
    {
        ButtonStart = 4, //Schliesserkontakt der parallel geschalteten Starttaster
        Player1ButtonLed = 2, //Led Startbutton Spieler 1
        Player2ButtonLed = 3, //Led Startbutton Spieler 2
        Player1LedGreen = 6, 
        Player1LedRed = 5,
        Player2LedGreen = 11,
        Player2LedRed = 12,
        Player1Bar = 0,
        Player2Bar = 1
    }
}
