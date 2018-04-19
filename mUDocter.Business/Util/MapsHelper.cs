using System;

namespace mUDocter.Business.Util
{
    public class MapsHelper
    {
        public static float distance(double x1, double y1, double x2, double y2)
        {
            float distance = (float) Math.Sqrt((x1 - x2)*(x1 - x2) + (y1 - y2)*(y1 - y2));

            return distance;
        }

        public static double getDistanceFromLatLonInKm(double lat1, double lon1, double lat2, double lon2)
        {
            var R = 6371; // Radius of the earth in km
            var dLat = deg2rad(lat2 - lat1);
            var dLon = deg2rad(lon2 - lon1);

            var a =
                Math.Sin(dLat/2)*Math.Sin(dLat/2) +
                Math.Cos(deg2rad(lat1))*Math.Cos(deg2rad(lat2))*
                Math.Sin(dLon/2)*Math.Sin(dLon/2)
                ;
            var c = 2*Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = R*c; // Distance in km
            return d;
        }

        public static double deg2rad(double deg)
        {
            return deg*(Math.PI/180);
        }
    }
}
