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
            
            var grades = new List<double>();
            employee.AddGrade(12.56);
            employee.AddGrade(20.18);
            employee.AddGrade(5.47);

            var stat = employee.GetStatistics();
            
            
        }
    }
}
