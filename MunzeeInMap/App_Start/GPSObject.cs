using System;

namespace MunzeeInMap
{
    public class Circle
    {
        private struct Gps
        {
            // In degrees
            public readonly double Latitude;
            public readonly double Longtitude;

            public Gps(double latitude, double longtitude)
            {
                Latitude = latitude;
                Longtitude = longtitude;
            }

            public override string ToString()
            {
                return string.Format("({0},{1})", Latitude, Longtitude);
            }

            public Vector ToUnitVector()
            {
                double lat = Latitude/180*Math.PI;
                double lng = Longtitude/180*Math.PI;

                // Z is North
                // X points at the Greenwich meridian
                return new Vector(Math.Cos(lng)*Math.Cos(lat), Math.Sin(lng)*Math.Cos(lat), Math.Sin(lat));
            }
        }

        private struct Vector
        {
            public readonly double X;
            public readonly double Y;
            public readonly double Z;

            public Vector(double x, double y, double z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public double MagnitudeSquared()
            {
                return X*X + Y*Y + Z*Z;
            }

            public double Magnitude()
            {
                return Math.Sqrt(MagnitudeSquared());
            }

            public Vector ToUnit()
            {
                double m = Magnitude();

                return new Vector(X/m, Y/m, Z/m);
            }

            public Gps ToGps()
            {
                Vector unit = ToUnit();
                // Rounding errors
                double z = unit.Z;
                if (z > 1)
                    z = 1;

                double lat = Math.Asin(z);

                double lng = Math.Atan2(unit.Y, unit.X);

                return new Gps(lat*180/Math.PI, lng*180/Math.PI);
            }

            public static Vector operator *(double m, Vector v)
            {
                return new Vector(m*v.X, m*v.Y, m*v.Z);
            }

            public static Vector operator -(Vector a, Vector b)
            {
                return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
            }

            public static Vector operator +(Vector a, Vector b)
            {
                return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
            }

            public override string ToString()
            {
                return string.Format("({0},{1},{2})", X, Y, Z);
            }

            public double Dot(Vector that)
            {
                return X*that.X + Y*that.Y + Z*that.Z;
            }

            public Vector Cross(Vector that)
            {
                return new Vector(Y*that.Z - Z*that.Y, Z*that.X - X*that.Z, X*that.Y - Y*that.X);
            }

            // Pick a random orthogonal vector
            public Vector Orthogonal()
            {
                double minNormal = Math.Abs(X);
                int minIndex = 0;
                if (Math.Abs(Y) < minNormal)
                {
                    minNormal = Math.Abs(Y);
                    minIndex = 1;
                }
                if (Math.Abs(Z) < minNormal)
                {
                    minNormal = Math.Abs(Z);
                    minIndex = 2;
                }

                Vector B;
                switch (minIndex)
                {
                    case 0:
                        B = new Vector(1, 0, 0);
                        break;
                    case 1:
                        B = new Vector(0, 1, 0);
                        break;
                    default:
                        B = new Vector(0, 0, 1);
                        break;
                }

                return (B - minNormal*this).ToUnit();
            }
        }

        // Phnom Penh
        //private Gps centre = new Gps(11.55, 104.916667);

        // In metres
        //private double worldRadius = 6371000;
        // In metres
        //private double circleRadius = 1000;

        // Points representing circle of radius circleRadius round centre.
        //private Gps[] points = new Gps[60];

        //private CirclePoints(points , centre , worldRadius , circleRadius );

        private static Gps[] CirclePoints(Gps[] points, Gps centre, double R, double r)
        {
            int count = points.Length;

            Vector C = centre.ToUnitVector();
            double t = r / R;
            Vector K = Math.Cos(t) * C;
            double s = Math.Sin(t);

            Vector U = K.Orthogonal();
            Vector V = K.Cross(U);
            // Improve orthogonality
            U = K.Cross(V);

            for (int point = 0; point != count; ++point)
            {
                double a = 2 * Math.PI * point / count;
                Vector P = K + s * (Math.Sin(a) * U + Math.Cos(a) * V);
                points[point] = P.ToGps();
            }
            return points;
        }
    }




    public class GpsObject
    {
        private double _longitude;
        private double _latitude;

        public GpsObject()
        {
            _longitude = 0.0;
            _latitude = 0.0;
        }

        // latitude in radians
        public GpsObject(double longitude, double latitude)
        {
            _longitude = longitude;
            _latitude = latitude;
        }

        public double Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }

        public double Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        public double GetDistanceFrom(GpsObject other)
        {
            return GetDistanceFrom(other.Longitude, other.Latitude);
        }

        public double GetDistanceFrom(double otherLongitude, double otherLatitude)
        {

            double R = 6371000.0; //m
            double diffLat = (((otherLatitude * 180.0) / Math.PI) - ((Latitude * 180.0) / Math.PI))*(Math.PI/180.0);
            double diffLong = (((otherLongitude* 180.0) /Math.PI) - ((Longitude*180.0)/Math.PI))*(Math.PI/180.0);
            double a = Math.Sin(diffLat/2.0)*Math.Sin(diffLat/2.0) +
                       (Math.Cos(Latitude)*Math.Cos(otherLatitude)*Math.Sin(diffLong/2.0)*Math.Sin(diffLong/2.0));
            double d = R*  2*Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            //var d = R*c;

            return d;

            /*
            var R = 6371; // km
            var φ1 = lat1.toRadians();
            var φ2 = lat2.toRadians();
            var Δφ = (lat2 - lat1).toRadians();
            var Δλ = (lon2 - lon1).toRadians();

            var a = Math.sin(Δφ / 2) * Math.sin(Δφ / 2) +
                    Math.cos(φ1) * Math.cos(φ2) *
                    Math.sin(Δλ / 2) * Math.sin(Δλ / 2);
            var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));

            var d = R * c;
             */
        }

        public GpsObject[] GetBoundary(double radiusKm)
        {
            double obvod = 2*Math.PI*6371; // km
            double oneDegreeLatitude = 180/obvod;
            double oneDegreeLongitude =360 /obvod;

            double diffDegreeLatitude = oneDegreeLatitude * radiusKm;
            double diffDegreeLongitude = oneDegreeLongitude * radiusKm;

            GpsObject LeftUp = new GpsObject(this.Longitude - diffDegreeLongitude, this.Latitude + diffDegreeLatitude);
            GpsObject RightDown = new GpsObject(this.Longitude + diffDegreeLongitude, this.Latitude - diffDegreeLatitude);
            GpsObject[] result = new GpsObject[2];
            result[0] = LeftUp;
            result[1] = RightDown;
            
            return result;
        }

        public double GetDistanceFrom2(GpsObject other)
        {
            return GetDistanceFrom2(other.Longitude, other.Latitude);
        }

        private double GetDistanceFrom2(double otherLongitude, double otherLatitude)
        {

            double different = toRad((toDeg(Longitude) - toDeg(otherLongitude)));
            double _90a2 = toRad((90 - toDeg(Latitude)));
            double _90a3 = toRad((90 - toDeg(otherLatitude)));

            Double result =
            Math.Acos(Math.Cos(_90a2) * Math.Cos(_90a3) +
                      Math.Sin(_90a2) * Math.Sin(_90a3) * Math.Cos(different)) * 6371000;
            return result;
        }

        
        private double toRad(double x)
        {
            return (x*Math.PI/180.0);
        }

        private double toDeg(double x)
        {
            return (x*180.0/Math.PI);
        }
    }

}
