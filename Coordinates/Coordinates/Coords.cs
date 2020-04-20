using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coordinates
{
    [Table("Coords")]
    public class Coords
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        //coords in radian
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double DegLatitude { get; set; }
        public double DegLongitude { get; set; }
        public string Name { get; set; }
        public bool Show { get; set; } = false;
        public Coords() { }
        //all in radians!
        public Coords(double radLat, double radLon)   //all in radians!
        {
            Latitude = radLat;
            Longitude = radLon;
            DegLatitude = Extensions.ToDeg(radLat);
            DegLongitude = Extensions.ToDeg(radLon);
        }
        public Coords(string coords)
        {
            Parse(coords);
        }
        public bool Parse(string coords)
        {
            List<char> inputLat = new List<char>();
            List<char> inputLon = new List<char>();

            coords = coords.ToLower();

            if ((coords[2] == '.') || (coords[2] ==','))
            {
                int i = 0;
                while(coords[i] != 'n')
                {
                    inputLat.Add(coords[i]);
                    i++;
                }
                i++;
                while (coords[i] != 'e')
                {
                    inputLon.Add(coords[i]);
                    i++;
                }

                char[] tempLat = inputLat.ToArray();
                char[] tempLon = inputLon.ToArray();

                Latitude = Extensions.ToRad(Convert.ToDouble(new string(tempLat)));
                Longitude = Extensions.ToRad(Convert.ToDouble(new string(tempLon)));
                DegLatitude = Convert.ToDouble(new string(tempLat));
                DegLongitude = Convert.ToDouble(new string(tempLon));
            }
            else
            {
                
                int last = coords.Length - 1;
                string temp = coords.Remove(last);
                
                string[] input;

                input = temp.Split('n');

                string D = "";
                string M = "";
                string S = "";

                D += input[0][0];
                D += input[0][1];

                M += input[0][2];
                M += input[0][3];

                S += input[0][4];
                S += input[0][5];
                S += input[0][6];
                S += input[0][7];
                S += input[0][8];

                double latD = Convert.ToDouble(D);
                double latM = Convert.ToDouble(M);
                double latS = Convert.ToDouble(S);

                D = "";
                M = "";
                S = "";

                D += input[1][0];
                D += input[1][1];
                D += input[1][2];

                M += input[1][3];
                M += input[1][4];

                S += input[1][5];
                S += input[1][6];
                S += input[1][7];
                S += input[1][8];
                S += input[1][9];

                double lonD = Convert.ToDouble(D);
                double lonM = Convert.ToDouble(M);
                double lonS = Convert.ToDouble(S);

                Latitude = Extensions.ToRad(latD + (latM + latS / 60) / 60);
                Longitude = Extensions.ToRad(lonD + (lonM + lonS / 60) / 60);
                DegLatitude = latD + (latM + latS / 60) / 60;
                DegLongitude = lonD + (lonM + lonS / 60) / 60;
            }

            return true;
        }
        public override string ToString()
        {
            var latD = Math.Truncate(this.DegLatitude);
            var templatM = (this.DegLatitude - latD) * 60;
            var latM = Math.Truncate(templatM);
            var latS = (templatM - latM) * 60;

            var lonD = Math.Truncate(this.DegLongitude);
            var templonM = (this.DegLongitude - lonD) * 60;
            var lonM = Math.Truncate(templonM);
            var lonS = (templonM - lonM) * 60;

            var tempLat = latD.ToString() + ' ' + latM.ToString() + ' ' + Math.Round(latS, 2, MidpointRounding.ToEven).ToString() + 'N';
            var tempLon = lonD.ToString() + ' ' + lonM.ToString() + ' ' + Math.Round(lonS, 2, MidpointRounding.ToEven).ToString() + 'E';

            return (tempLat + '\t' + tempLon);
        }
        
    }
}
