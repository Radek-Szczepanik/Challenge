using System;
using System.Collections.Generic;
using System.Linq;

namespace ChallengeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var employee = new Employee("Radek");
            
            var grades = new List<double>() {12.4, 5, 0.333};
            employee.AddGrade(12.5);

            var result = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;

            foreach(var n in grades)
            {
                lowGrade = Math.Min(lowGrade, n);
                highGrade = Math.Max(highGrade, n);
                result += n;
            }

            result /= grades.Count;

            Console.WriteLine($"The average is {result:N2}");
            
            
        }
    }
}
