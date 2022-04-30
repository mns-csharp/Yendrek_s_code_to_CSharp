using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yendrek_s_code_to_CSharp
{
    public static partial class Python<T>
    {
        public static List<T> Range(int n)
        {
            List<T> newList = new List<T>(new T[n]);

            for (int i = 0; i < n; i++)
            {
                newList[i] = (T)(object)i;
            }

            return newList;
        }        
    }
}
