using System;

namespace Pong.Source
{
    public static class Extensions
    {
        /// <summary>
        /// Äquivalent zur map()-Methode vom Arduino.
        /// </summary>
        /// <param name="value">Der Wert der umgewandelt werden soll</param>
        /// <param name="fromSource">Der Minimale Wert den value haben kann</param>
        /// <param name="toSource">Der Maximale Wert den value haben kann</param>
        /// <param name="fromTarget">Der Minimale Wert der gemappten value</param>
        /// <param name="toTarget">Der maximale Wert der gemappten value</param>
        /// <returns></returns>
        public static int Map(this int value, decimal fromSource, decimal toSource, decimal fromTarget, decimal toTarget)
        {
            return (int)Math.Round((value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget);
        }
    }
}
