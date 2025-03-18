using System;
using System.Collections.Generic;
using System.Linq;

public class CalculationLogger
{
    private List<string> history = new List<string>();
    private Dictionary<string, int> operationCount = new Dictionary<string, int>();
    private int errorCount = 0;

    public void LogCalculation(string log)
    {
        string timestamp = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]");
        string entry = $"{timestamp} {log}";
        history.Add(entry);

        if (log.Contains("Error"))
        {
            errorCount++;
        }
        else
        {
            string operation = log.Split(':')[0];
            if (!operationCount.ContainsKey(operation))
                operationCount[operation] = 0;
            operationCount[operation]++;
        }
    }

    public void DisplayHistory()
    {
        Console.WriteLine("\nCalculation History:");
        foreach (var entry in history)
        {
            Console.WriteLine(entry);
        }

        Console.WriteLine("\nStatistics:");
        Console.WriteLine($"Total Calculations: {history.Count}");
        Console.WriteLine($"Successful: {history.Count - errorCount}");
        Console.WriteLine($"Errors: {errorCount}");

        if (operationCount.Count > 0)
        {
            var mostUsed = operationCount.OrderByDescending(kvp => kvp.Value).First();
            Console.WriteLine($"Most Used Operation: {mostUsed.Key} ({mostUsed.Value} times)");
        }
    }
}
