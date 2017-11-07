namespace Pong.Source
{
    /// <summary>
    /// <para>Enum um den anzusteuernden Pins einen Namen zu geben.</para>
    /// <para>Somit vermindert man das Problem das ein falscher Pin angesteuert wird.</para>
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
