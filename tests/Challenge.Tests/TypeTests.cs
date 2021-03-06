using System;
using Xunit;
using ChallengeApp;

namespace Challenge.Tests
{
    public class TypeTests
    {
        public delegate string WriteMessage(string message);

        int counter = 0;

        [Fact]
        public void WriteMessageDelegateCanPointToMethod()
        {
            WriteMessage del = ReturnMessage;

            del += ReturnMessage;
            del += ReturnMessage2;

            var result = del("Hello!");

            Assert.Equal(3, counter);
        }

        string ReturnMessage(string message)
        {
            counter++;
            return message;
        }

        string ReturnMessage2(string message)
        {
            counter++;
            return message.ToUpper();
        }

        [Fact]
        public void GetEmployeeReturnsDifferentObjects()
        {
            var emp1 = GetEmployee("Zuzia");
            var emp2 = GetEmployee("Rafał");

            Assert.NotSame(emp1, emp2);
            Assert.False(Object.ReferenceEquals(emp1, emp2));
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var emp1 = GetEmployee("Zuzia");
            var emp2 = emp1;

            Assert.Same(emp1, emp2);
            Assert.True(Object.ReferenceEquals(emp1, emp2));
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            Employee emp1 = null;
            GetEmployeeSetName(out emp1, "New Name");

            Assert.Equal("New Name", emp1.Name);
            
        }

        public void CanSetNameFromReference()
        {
            var emp1 = GetEmployee("Zuzia");
            this.SetName(emp1, "NewName");
            Assert.Equal("NewName", emp1.Name);
        }

        private Employee GetEmployee(string name)
        {
            return new Employee(name);
        }

        private void SetName(Employee employee, string name)
        {
            employee.Name = name;
        }

        private void GetEmployeeSetName(out Employee emp, string name)
        {
            emp = new Employee(name);
        }
    }
}
