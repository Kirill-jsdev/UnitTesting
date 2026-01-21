using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestC_.Classes
{
    public class FunctionToTest
    {
        public string ReturnsPikachuIfZero(int number)
        {
            if (number == 0)
            {
                return "Pikachu";
            }
            return "Not Pikachu";
        }
    }
}
