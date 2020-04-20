using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coordinates
{
    public static class Calculator
    {
        public enum Measures
        {
            NM,
            KM,
            M,
            FT
        }

        const double RADIUS_NM = 3440.065;
        const double RADIUS_KM = 6371;
        const double RADIUS_M = 6371e3;
        const double RADIUS_FT = 2.0902e+7;

        public static Coords FindPoint(Coords startPoint, double bearing, double distance, Measures distType) //bearing TRUE!!! and in radians
        {
            double sigma = 0;   //distance in radians
            switch(distType)
            {
                case Measures.NM:
                    sigma = distance / RADIUS_NM;
                    break;
                case Measures.KM:
                    sigma = distance / RADIUS_KM;
                    break;
                case Measures.M:
                    sigma = distance / RADIUS_M;
                    break;
                case Measures.FT:
                    sigma = distance / RADIUS_FT;
                    break;
            }

            var phi1 = startPoint.Latitude;
            var lambda1 = startPoint.Longitude;

            var sinPhi1 = Math.Sin(phi1);
            var cosPhi1 = Math.Cos(phi1);
            var sinSigma = Math.Sin(sigma);
            var cosSigma = Math.Cos(sigma);
            var sinTheta = Math.Sin(bearing);
            var cosTheta = Math.Cos(bearing);

            var sinPhi2 = sinPhi1 * cosSigma + cosPhi1 * sinSigma * cosTheta;
            var phi2 = Math.Asin(sinPhi2);
            var y = sinTheta * sinSigma * cosPhi1;
            var x = cosSigma - sinPhi1 * sinPhi2;
            var lambda2 = lambda1 + Math.Atan2(y, x);

            return new Coords(phi2, lambda2);
        }

        public static void FindPointsLine(Coords startPoint, double bearing, double distance, Measures distType, int numPoints, ref List<Coords> resultList)   //bearing TRUE!!! and in radians
        {
            Coords tempPoint = new Coords();
            tempPoint = startPoint;

            for (int i = 0; i < numPoints; i++)
            {
                var newPoint = FindPoint(tempPoint, bearing, distance, distType);

                resultList.Add(newPoint);

                tempPoint = newPoint;
            }

        }

        public static void FindFinalMarks(in List<Coords> finalPoints, double bearing, ref List<Coords> markLines)  //bearing TRUE!!! and in radians
        {
            for (int i = 0; i < finalPoints.Count(); i++)
            {
                double distance;

                if (((i + 1) % 5) != 0)
                {
                    distance = 0.3;
                }
                else
                {
                    distance = 0.7;
                }

                double b1 = bearing + Extensions.ToRad(90);
                double b2 = bearing - Extensions.ToRad(90);

                markLines.Add(FindPoint(finalPoints[i], b1, distance, Measures.NM));
                markLines.Add(FindPoint(finalPoints[i], b2, distance, Measures.NM));

            }
        }

        public static void FindGate(in List<Coords> finalPoints, int gateMile, double bearing, ref List<Coords> gateLine)
        {
            List<Coords> gateR = new List<Coords>();
            List<Coords> gateL = new List<Coords>();

            var aimPoint = finalPoints[gateMile - 1];

            double b1 = bearing + Extensions.ToRad(90); //right abeam
            double b2 = bearing - Extensions.ToRad(90); //left abeam
            double br = bearing + Extensions.ToRad(30);
            double bl = bearing - Extensions.ToRad(30);

            gateR.Add(FindPoint(aimPoint, br, 10, Measures.NM));
            gateR.Add(FindPoint(gateR[0], b1, 2, Measures.NM));

            gateL.Add(FindPoint(aimPoint, bl, 10, Measures.NM));
            gateL.Add(FindPoint(gateL[0], b2, 2, Measures.NM));

            gateLine.Add(gateR[1]);
            gateLine.Add(gateR[0]);
            gateLine.Add(aimPoint);
            gateLine.Add(gateL[0]);
            gateLine.Add(gateL[1]);

        }
    }
}
