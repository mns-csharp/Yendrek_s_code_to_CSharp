using System;
using System.Collections.Generic;
using System.Text;
using Yendrek_s_code_to_CSharp;

namespace ListPointModificationTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Point2d> list = new List<Point2d>();

            list.Add(new Point2d(0, 0));
            list.Add(new Point2d(0, 1));

            foreach (Point2d item in list)
            {
                item.Print();
            }

            list[0] = new Point2d(-1,-1);

            foreach (Point2d item in list)
            {
                item.Print();
            }

            Console.ReadKey();
        }
    }
}
