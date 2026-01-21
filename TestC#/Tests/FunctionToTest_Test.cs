using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestC_.Tests
{
    public static class FunctionToTest_Test
    {
        //Naming Convention - ClassName_MethodName_ExpectedResult
        public static void FunctionToTest_ReturnsPikachuIfZero_ReturnsString()
        {
            try
            {
                //Arrange
                Classes.FunctionToTest functionToTest = new Classes.FunctionToTest();
                //Act
                string result = functionToTest.ReturnsPikachuIfZero(0);
                //Assert
                if (result != "Pikachu")
                {
                    Console.WriteLine("FAILED: FunctionToTest_ReturnsPikachuIfZero_ReturnsString");
                }
                else
                {
                    Console.WriteLine("PASSED: FunctionToTest_ReturnsPikachuIfZero_ReturnsString");

                }
            }
            catch (Exception ex)
            {

                throw;
            }   
        }
    }
}
