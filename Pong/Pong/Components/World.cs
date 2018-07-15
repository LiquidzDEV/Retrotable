namespace RetroTable.Pong.Components
{
    /// <summary> Holds the bounds for the gameworld. </summary>
    public static class World
    {
        public static int Upper = 0, Bottom, Left = 0, Right;

        public static void SetBounds(int height, int width)
        {
            Bottom = height;
            Right = width;
        }
    }
}
