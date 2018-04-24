using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingGame
{
    class Dancing
    {
        static int DeliciousFunction(int n)
        {
            //if (n == 1)
            //    return 1;
            //if (n == 2)
            //    return -1;

            //if (n == int.MaxValue)
            //    return 1;

            //int i = 1;
            //int[] t = new int[] { 1, -2 };
            //int position = -1;

            //for (int itr = 3; itr <= n; itr++)
            //{
            //    i = (i + 1) % 2;
            //    t[i] = t[(i + 1) % 2] - t[i];
            //    position += t[i];
            //}

            //return position;
            return new int[] { 0, 1, -1, -4, -5, -3 }[n % 6];
        }
    }
}
