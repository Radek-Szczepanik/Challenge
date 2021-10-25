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
            
            var numbers = new List<double>() {12.4, 5, 0.333};
            employee.AddGrade(12.5);

            var result = 0.0;
            foreach(var n in numbers)
            {
                result += n;
            }

            result /= numbers.Count;

            Console.WriteLine($"The average is {result:N2}");
            
            
        }
    }
}
