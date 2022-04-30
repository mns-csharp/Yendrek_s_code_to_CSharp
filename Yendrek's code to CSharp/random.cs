using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yendrek_s_code_to_CSharp
{
    public static class random
    {
        public static double GetNormalized(double val, double min, double max)
        {
            if (!(val >= 0 && val <= 1))
                throw new Exception("val must betwet ween 0 and 1");

            double valmin = 0;
            double valmax = 1;
            return (((val - valmin) / (valmax - valmin)) * (max - min)) + min;
        }

        public static double uniform(Random random, double min, double max)
        {
            double randDouble = random.NextDouble();

            return GetNormalized(randDouble, min, max);
        }

        public static double randdouble(Random random)
        {
            return uniform(random, 0.0, 1.0);
        }

        public static int randint(Random random, int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
