using System;

namespace Pong.Source.Board
{
    /// <summary> Static Helperclass to extend the int-Class </summary>
    public static class Extensions
    {
        /// <summary>
        /// Equivalent to the map()-Method of Arduino.
        /// </summary>
        /// <param name="value">The value that should be converted</param>
        /// <param name="fromSource">The minimal value of value</param>
        /// <param name="toSource">The maximum value of value</param>
        /// <param name="fromTarget">The minimal value of the converted value</param>
        /// <param name="toTarget">The maximum value of the converted value</param>
        /// <returns></returns>
        public static int Map(this int value, decimal fromSource, decimal toSource, decimal fromTarget, decimal toTarget)
        {
            return (int)Math.Round((value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget);
        }
    }
}
