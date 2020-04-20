using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace Coordinates
{
    public class CustomPin: Pin
    {
        public CustomPin(Coords inputPoint) : base()
        {
            point = inputPoint;
            Position = new Position(point.DegLatitude, point.DegLongitude);
            Label = point.Name;
        }

        public Coords point;
    }
}
