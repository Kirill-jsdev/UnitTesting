using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestC_.Classes
{
    internal class Toolbox
    {
        public static void PrintTools(int[] numbers)
        {
            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    Console.WriteLine("Even number found: " + number);
                }
                else
                {
                    Console.WriteLine("Odd number found: " + number);
                }
            }
        }
    }
}
