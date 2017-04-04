/*
 * Pascal "Liquidz" H.
 * 10.02.2017 / 07:03
 * 
 * Description:
 */

namespace Pong.Source.Components
{
    /// <summary> Hält die Bounds des Spielfeldes. </summary>
    public static class World
    {
        public static int upper, bottom, left, right;
        
        public static void setBounds(int height, int width){
        	World.bottom = height;
            World.right = width;
        }
    }
}
