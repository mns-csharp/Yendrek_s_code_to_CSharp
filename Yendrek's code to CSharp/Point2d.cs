﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Yendrek_s_code_to_CSharp
{
    public class Point2d : IEquatable<Point2d>
    {
        public double X { get; set; }
        public double Y { get; set; }

        #region constructor
        public Point2d(double x, double y)
        {
            X = x;
            Y = y;
        }
        #endregion
        public void Print()
        {
            Console.Write("(");
            Console.Write(X);
            Console.Write(",");
            Console.Write(Y);
            Console.Write(")  ");
        }
        
        public double GetDistance(Point2d otherPoint)
        {
            return Math.Sqrt(GetSquaredDistance(otherPoint));
        }

        public double GetSquaredDistance(Point2d otherPoint)
        {
            return ((otherPoint.X - X) * (otherPoint.X - X))
                + ((otherPoint.Y - Y) * (otherPoint.Y - Y));
        }

        public Point2d GetTranslated(Point2d center)
        {
            return new Point2d(X + center.X, Y + center.Y);
        }

        #region override string ToString()
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("(" + X + " , " + Y + ")");

            return sb.ToString();
        }
        #endregion

        #region equality comparison implementations
        public override bool Equals(object other)
        {
            if (!(other is Point2d)) return false;
            return Equals((Point2d)other);
        }
        public bool Equals(Point2d other)
        {
            return X == other.X && Y == other.Y;
        }
        public override int GetHashCode()
        {
            return (int)Math.Round(Y * 31.0 + X, 0); // 31 = some prime number
        }
        public static bool operator ==(Point2d a1, Point2d a2)
        {
            return a1.Equals(a2);
        }
        public static bool operator !=(Point2d a1, Point2d a2)
        {
            return !a1.Equals(a2);
        }
        #endregion
    }
}
