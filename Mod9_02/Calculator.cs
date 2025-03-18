using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod9_02
{
    using System;

    public class Calculator
    {
        public event Action<string> CalculationPerformed;

        public double Add(double a, double b) => a + b;
        public double Subtract(double a, double b) => a - b;
        public double Multiply(double a, double b) => a * b;

        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                return double.NaN;
            }
            return a / b;
        }


        public void Calculate(double num1, double num2, Func<double, double, double> operation, string operationName)
        {
            double result = operation(num1, num2);
            string output = double.IsNaN(result)
                ? $"Division: Error - Cannot divide {num1} by {num2}"
                : $"{operationName}: {num1} {GetOperationSymbol(operationName)} {num2} = {result}";

            CalculationPerformed?.Invoke(output);
            Console.WriteLine(output);
        }

        private string GetOperationSymbol(string operationName)
        {
            return operationName switch
            {
                "Addition" => "+",
                "Subtraction" => "-",
                "Multiplication" => "*",
                "Division" => "/",
                _ => "?"
            };
        }
    }

}
