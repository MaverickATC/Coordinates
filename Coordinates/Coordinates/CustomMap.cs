using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace Coordinates
{
    public class CustomMap: Map
    {
        public CustomMap() : base()
        {
            CustomPins = new List<CustomPin>();
        }
        public List<CustomPin> CustomPins { get; set; }
    }
}
