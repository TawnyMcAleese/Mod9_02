using System;
using System.Collections.Generic;
using System.Linq;
using Mod9_02;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Calculator with Event Logging Demo ===\n");
        Console.WriteLine("Initializing Calculator...\n");
        Console.WriteLine("Calculator Ready. Available Operations: +, -, *, /\n");

        Calculator calc = new Calculator();
        CalculationLogger logger = new CalculationLogger();

        calc.CalculationPerformed += logger.LogCalculation;

        Console.WriteLine("Performing Calculations:");
        calc.Calculate(10, 5, calc.Add, "Addition");
        calc.Calculate(20, 8, calc.Subtract, "Subtraction");
        calc.Calculate(20, 8, calc.Subtract, "Subtraction");
        calc.Calculate(20, 8, calc.Subtract, "Subtraction");
        calc.Calculate(6, 4, calc.Multiply, "Multiplication");
        calc.Calculate(15, 3, calc.Divide, "Division");
        calc.Calculate(10, 0, calc.Divide, "Division");
        calc.Calculate(11, 52, calc.Add, "Addition");

        logger.DisplayHistory();

        Console.WriteLine("\n=== End of Calculator Demo ===");
    }
}
