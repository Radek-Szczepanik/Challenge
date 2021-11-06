using System;
using System.Collections.Generic;
using System.IO;

namespace ChallengeApp
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    public class NamedObject
    {
        public NamedObject(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }

    public interface IEmployee
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class EmployeeBase : NamedObject, IEmployee
    {
        public EmployeeBase(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();
    }

    public class InMemoryEmployee : EmployeeBase
    {
        private List<double> grades;
        public InMemoryEmployee(string name) : base(name)
        {
            grades = new List<double>();
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
    }
    public class SavedEmployee : EmployeeBase
    {
        public SavedEmployee(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;
        public override void AddGrade(double grade)
        {
            using(var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using(var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();

                while(line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }
            return result;
        }
    }
}