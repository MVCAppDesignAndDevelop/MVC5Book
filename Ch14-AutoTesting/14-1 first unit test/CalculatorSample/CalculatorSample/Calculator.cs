using System;
namespace CalculatorSample
{
    public class Calculator
    {
        public int Add(int firstNumber, int secondNumber)
        {
            if (firstNumber == 0)
            {
                throw new ArgumentOutOfRangeException("firstNumber");
            }

            return firstNumber + secondNumber;
        }
    }
}