using System;
using System.Linq;

namespace spnavwrapper
{
    public enum SpaceNavAxis
    {
        NONE, X, Y, Z, RX, RY, RZ
    }

    public enum SpaceNavDirection
    {
        POSITIVE, NEGATIVE
    }

    public abstract class SpaceNavEvent
    {
    }

    public class SpaceNavButtonEvent : SpaceNavEvent
    {
        public bool Pressed { get; private set; }
        public int Button { get; private set; }

        public SpaceNavButtonEvent(bool pressed, int button)
        {
            Pressed = pressed;
            Button = button;
        }

        public override string ToString()
        {
            return "pressed=" + Pressed + " button=" + Button;
        }
    }

    public class SpaceNavMotionEvent : SpaceNavEvent
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }
        public int Rx { get; private set; }
        public int Ry { get; private set; }
        public int Rz { get; private set; }
        public SpaceNavDirection Direction { get; private set; }

        public SpaceNavMotionEvent(int x, int y, int z, int rx, int ry, int rz)
        {
            X = x;
            Y = y;
            Z = z;
            Rx = rx;
            Ry = ry;
            Rz = rz;
        }

        public SpaceNavAxis Axis
        {
            get
            {
                int max = Max(Math.Abs(X), Math.Abs(Y), Math.Abs(Z), Math.Abs(Rx), Math.Abs(Ry), Math.Abs(Rz));
                if (max == 0)
                {
                    return SpaceNavAxis.NONE;
                }
                if (max == Math.Abs(X))
                {
                    Direction = X > 0 ? SpaceNavDirection.POSITIVE : SpaceNavDirection.NEGATIVE;
                    return SpaceNavAxis.X;
                }
                else if (max == Math.Abs(Y))
                {
                    Direction = Y > 0 ? SpaceNavDirection.POSITIVE : SpaceNavDirection.NEGATIVE;
                    return SpaceNavAxis.Y;
                }
                else if (max == Math.Abs(Z))
                {
                    Direction = Z > 0 ? SpaceNavDirection.POSITIVE : SpaceNavDirection.NEGATIVE;
                    return SpaceNavAxis.Z;
                }
                else if (max == Math.Abs(Rx))
                {
                    Direction = Rx > 0 ? SpaceNavDirection.POSITIVE : SpaceNavDirection.NEGATIVE;
                    return SpaceNavAxis.RX;
                }
                else if (max == Math.Abs(Ry))
                {
                    Direction = Ry > 0 ? SpaceNavDirection.POSITIVE : SpaceNavDirection.NEGATIVE;
                    return SpaceNavAxis.RY;
                }
                else if (max == Math.Abs(Rz))
                {
                    Direction = Rz > 0 ? SpaceNavDirection.POSITIVE : SpaceNavDirection.NEGATIVE;
                    return SpaceNavAxis.RZ;
                }
                return SpaceNavAxis.NONE;
            }
        }

        public override string ToString()
        {
            return "x=" + X + " y=" + Y + " z=" + Z +
                " rx=" + Rz + " ry=" + Ry + " rz=" + Rz;
        }

        public static int Max(params int[] values)
        {
            return Enumerable.Max(values);
        }
    }
}
