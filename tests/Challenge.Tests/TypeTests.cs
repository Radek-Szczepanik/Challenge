using System;
using Xunit;
using ChallengeApp;

namespace Challenge.Tests
{
    public class TypeTests
    {
        [Fact]
        public void GetEmployeeReturnsDifferentObjects()
        {
            var emp1 = GetEmployee("Zuzia");
            var emp2 = GetEmployee("Rafał");

            Assert.Equal("Zuzia", emp1.Name);
            Assert.Equal("Rafał", emp2.Name);
            
        }

        private Employee GetEmployee(string name)
        {
            return new Employee(name);
        }
    }
}
