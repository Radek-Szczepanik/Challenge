using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    public partial class Employee
    {
        private string name;
        private List<double> grades = new List<double>();
        public Employee(string name)
        {
            this.name = name;
        }

        public void AddGrade(double grade)
        {
            this.grades.Add(grade);
        }
        
        public void ShowStatistics()
        {
            
        }

    }
}