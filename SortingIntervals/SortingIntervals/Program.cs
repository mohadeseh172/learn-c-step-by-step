using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Step 1: Get the number of intervals
        Console.Write("Enter the number of intervals (n): ");
        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Please enter a valid positive integer for n: ");
        }

        // Step 2: Get the intervals
        List<(int start, int end)> intervals = new List<(int, int)>();
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter interval {i + 1} (format: start end): ");
            string[] input = Console.ReadLine()?.Split();
            if (input != null && input.Length == 2 &&
                int.TryParse(input[0], out int start) &&
                int.TryParse(input[1], out int end))
            {
                if (start <= end)
                {
                    intervals.Add((start, end));
                }
                else
                {
                    Console.WriteLine("Invalid interval. Start must be <= end. Try again.");
                    i--; // Retry current interval
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter two integers separated by a space.");
                i--; // Retry current interval
            }
        }

        // Step 3: Sort the intervals
        var sortedIntervals = intervals.OrderBy(interval => interval.start)
                                       .ThenBy(interval => interval.end)
                                       .ToList();

        // Step 4: Output the sorted intervals
        Console.WriteLine("\nSorted intervals:");
        foreach (var interval in sortedIntervals)
        {
            Console.WriteLine($"({interval.start}, {interval.end})");
        }
    }
}
