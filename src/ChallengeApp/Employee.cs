using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    public class Employee
    {
        public delegate void GradeAddedDelegate(object sender, EventArgs args);

        public event GradeAddedDelegate GradeAdded;

        private List<double> grades = new List<double>();
        public Employee(string name)
        {
            this.Name = name;
        }

        public void AddGrade(double grade)
        {
            if(grade >= 0 && grade <= 100)
            {
                this.grades.Add(grade);
                
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
                
            }
            else
            {
                throw new ArgumentException($"Invalid argument: {nameof(grade)}");
            }
        }
        public void AddGrade(char grade)
        {
            switch(grade)
            {
                case 'A':
                    this.AddGrade(100);
                    break;
                case 'B':
                    this.AddGrade(80);
                    break;
                case 'C':
                    this.AddGrade(60);
                    break;
                default:
                    this.AddGrade(0);
                    break;

            }
        }
        
        public string Name { get; set; }
        
        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach (var grade in grades)
            {
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);
                result.Average += grade;
            }
            result.Average /= grades.Count;

            switch(result.Average)
            {
                case var d when d >= 90:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80:
                    result.Letter = 'B';
                    break;
                default:
                    result.Letter = 'Z';
                    break;

            }

            return result;
        }

    }
}