namespace Pong.Source
{
    /// <summary>
    /// <para> Enum to name the connected pins. </para>
	/// <para> Improves the readability of the code and prevents from triggering the wrong pins on the Board. </para>
    /// </summary>
    public enum PinMapping
    {
        ButtonStart = 4,
        Player1LedGreen = 6,
        Player1LedRed = 5,
        Player2LedGreen = 11,
        Player2LedRed = 12,
        Player1Bar = 0,
        Player2Bar = 1
    }
}
