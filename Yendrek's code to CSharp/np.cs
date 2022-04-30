using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yendrek_s_code_to_CSharp
{
    public static class np
    {
        public static Matrix<Point2d> meshgrid(List<double> rows, List<double> columns)
        {
            Matrix<Point2d> grid = new Matrix<Point2d>(rows.Count, columns.Count);
            for (int i = 0; i < rows.Count; i++)
            {
                for (int j = 0; j < columns.Count; j++)
                {
                    grid[i, j] = new Point2d(j, i);
                }
            }
            return grid;
        }

        public static List<double> linspace(double min, double max, int points)
        {
            double[] d = new double[points];
            double incr = (max-min)/(points-1);//points = 1

            if (double.IsInfinity(incr))
            {
                d[0] = min;
                return new List<double>(d);
            }
            else
            {
                int i = 0;
                for (double val = min; val <= max; val += incr)
                {
                    if (i >= points)
                    {
                        break;
                    }

                    d[i] = val;
                    i++;
                }
                return new List<double>(d);
            }
        }
    }
}
