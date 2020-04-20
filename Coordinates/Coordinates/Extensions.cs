using System;
using System.Collections.Generic;
using System.Text;

namespace Coordinates
{
    static class Extensions
    {
        public static double ToRad(double degrees)
        {
            return degrees * Math.PI / 180;
        }

        public static double ToDeg(double radians)
        {
            return radians * 180 / Math.PI;
        }
        
    }
}
