using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine(isPrime(5));
        //    Console.ReadKey();
        //}

        public static bool isPrime(int n)
        {
            if (n == 1) return false;

            bool IsPrime = true;
            int i = 2;

            while (IsPrime && i <= (n / 2))
            {
                if (n % i == 0)
                    IsPrime = false;

                i++;
            }
            return IsPrime;
        }
    }
}
