using System;
using System.Collections.Generic;
using System.Linq;

namespace ChallengeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var employee = new SavedEmployee("Radek");
            
            
            while(true)
            {
                Console.WriteLine($"Hello! Enter grade for {employee.Name}");

                var input = Console.ReadLine();

                if(input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    employee.AddGrade(grade);
                }
                catch(FormatException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                catch(ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                
            }

            var stats = employee.GetStatistics();
            Console.WriteLine($"High: {stats.High}");
            Console.WriteLine($"Low: {stats.Low}");
            Console.WriteLine($"Average: {stats.Average:N2}");
            Console.WriteLine($"Letter: {stats.Letter}");
        }

        static void OnGradeAdded(object sender, EventArgs args)
        {
            System.Console.WriteLine($"New grade is added");
        }
    }
}
