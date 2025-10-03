using System;
using System.Diagnostics.CodeAnalysis;

namespace DN3
{
    public struct Vector
    {
        double x, y, z;

        //Konstruktor
        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString()
        {
            return "[" + x + "," + y + "," + z + "]";
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Vector operator *(Vector a, Vector b)
        {
            return new Vector(
                a.y * b.z - a.z * b.y,
                a.z * b.x - a.x * b.z,
                a.x * b.y - a.y * b.x
            );
        }

        public static Vector operator *(double scalar, Vector v)
        {
            return new Vector(scalar * v.x, scalar * v.y, scalar * v.z);
        }

        public static Vector operator *(Vector v, double scalar)
        {
            return new Vector(scalar * v.x, scalar * v.y, scalar * v.z);
        }

        public static Vector operator /(Vector v, double scalar)
        {
            return new Vector(v.x / scalar, v.y / scalar, v.z / scalar);
        }

        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return x;
                    case 1: return y;
                    case 2: return z;
                    default: throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        x = value;
                        return;
                    case 1:
                        y = value;
                        return;
                    case 2:
                        z = value;
                        return;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }

        public static explicit operator double(Vector vector)
        {
            return Math.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
        }

        public static implicit operator Vector(double d)
        {
            return new Vector(d, 0, 0);
        }

        public static bool operator ==(Vector a, Vector b)
        {
            return nearlyEqual(a.x, b.x) && nearlyEqual(a.y, b.y) && nearlyEqual(a.z, b.z);
        }

        public static bool operator !=(Vector a, Vector b)
        {
            return !(a == b);
        }

        public override bool Equals(Object o)
        {
            return (this == (Vector)o);
        }
        
        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode() ^ z.GetHashCode();
        }


        // TODO Implement

        private static bool nearlyEqual(double a, double b)
        {
            const double epsilon = 1E-10; // depends, usually parameter
            const double MinNormal = 2.2250738585072014E-308d;
            double absA = Math.Abs(a);
            double absB = Math.Abs(b);
            double diff = Math.Abs(a - b);
            if (a.Equals(b))
            {
                // shortcut, also handles infinities
                return true;
            }
            else if (a == 0 || b == 0 || absA + absB < MinNormal)
            {
// a or b is zero or both are extremely close to it
// relative error is less meaningful here
                return diff < (epsilon * MinNormal);
            }
            else
            {
                // use relative error
                return diff / (absA + absB) < epsilon;
            }
        }
    }

    internal class MainClass
    {
        public static void Test()
        {
            Vector a = new Vector(1, 2, 3);
            Vector b = new Vector(4, 5, 6);
            Vector c = a * b;
            Console.WriteLine(c);
        }

        // public static void Main(string[] args)
        // {
        //     Test();
        // }
    }
}