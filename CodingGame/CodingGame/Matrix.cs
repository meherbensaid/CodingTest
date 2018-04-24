using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CodingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //string n;
            //while ((n = Console.ReadLine()) != "")
            //    Console.WriteLine(DeliciousFunction(int.Parse(n)));
            var hello=Program.getByRowCol(8,4);
            Console.WriteLine();
        }

        public static string getByRowCol(int l, int c) // Le problème de la matrice
        {
            BigInteger[][] matrix = new BigInteger[l + 1][];
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new BigInteger[i + 1];
                matrix[i][0] = 1;
                matrix[i][i] = 1;
                if (i >= 2)
                {
                    for (int j = 1; j < matrix[i].Length - 1; j++)
                    {
                        matrix[i][j] = matrix[i - 1][j - 1] + matrix[i - 1][j];
                    }
                }
            }
            return matrix[l][c] + "";
        }


     

      }


}
