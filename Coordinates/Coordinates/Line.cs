using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Coordinates
{
    public class Line: Polyline
    {
        public Line(List<Coords> points) : base()
        {
            StrokeWidth = 8;
            StrokeColor = Color.Black;
            positions = new List<Position>();
            foreach (var p in points)
            {
                positions.Add(new Position(p.DegLatitude, p.DegLongitude));
            }
            foreach (var p in positions)
            {
                Geopath.Add(p);
            };
        }
        public void AddPoint(Coords coordinate)
        {
            positions.Add(new Position(coordinate.DegLatitude, coordinate.DegLongitude));
            Geopath.Clear();
            foreach (var p in positions)
            {
                Geopath.Add(p);
            };
        }
        private List<Position> positions;
    }
}
