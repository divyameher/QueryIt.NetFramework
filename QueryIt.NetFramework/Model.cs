using System;
using System.Collections.Generic;
using System.Text;

namespace QueryIt
{
    public interface IEntity
    {
        bool IsValid();
    }
    public class Person
    {
        public string Name { get; set; }
    }

    public class Employee : Person, IEntity
    {
        public int Id { get; set; }
        public virtual void DoWork()
        {
            Console.WriteLine("Doing Real Work!");
        }

        public bool IsValid()
        {
            return true;
        }
    }
    public class Manager : Employee
    {
        public int MyProperty { get; set; }
        public override void DoWork()
        {
            Console.WriteLine("Create a Meeting");
        }
    }
}
