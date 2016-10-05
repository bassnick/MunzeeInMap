using System;

namespace gpsCircle
{
    struct Gps
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
            double lat = Latitude / 180 * Math.PI;
            double lng = Longtitude / 180 * Math.PI;

            // Z is North
            // X points at the Greenwich meridian
            return new Vector(Math.Cos(lng) * Math.Cos(lat), Math.Sin(lng) * Math.Cos(lat), Math.Sin(lat));
        }
    }

    struct Vector
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
            return X * X + Y * Y + Z * Z;
        }

        public double Magnitude()
        {
            return Math.Sqrt(MagnitudeSquared());
        }

        public Vector ToUnit()
        {
            double m = Magnitude();

            return new Vector(X / m, Y / m, Z / m);
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

            return new Gps(lat * 180 / Math.PI, lng * 180 / Math.PI);
        }

        public static Vector operator *(double m, Vector v)
        {
            return new Vector(m * v.X, m * v.Y, m * v.Z);
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
            return X * that.X + Y * that.Y + Z * that.Z;
        }

        public Vector Cross(Vector that)
        {
            return new Vector(Y * that.Z - Z * that.Y, Z * that.X - X * that.Z, X * that.Y - Y * that.X);
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

            return (B - minNormal * this).ToUnit();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Phnom Penh
            Gps centre = new Gps(11.55, 104.916667);

            // In metres
            double worldRadius = 6371000;
            // In metres
            double circleRadius = 1000;

            // Points representing circle of radius circleRadius round centre.
            Gps[] points = new Gps[20];

            CirclePoints(points, centre, worldRadius, circleRadius);
        }

        static void CirclePoints(Gps[] points, Gps centre, double R, double r)
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
        }
    }
}