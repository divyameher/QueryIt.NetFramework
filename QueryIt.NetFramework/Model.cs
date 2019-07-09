using System;
using System.Collections.Generic;
using System.Text;

namespace QueryIt
{
    public class Person
    {
        public string Name { get; set; }
    }

    public class Employee : Person
    {
        public int Id { get; set; }
        public virtual void DoWork()
        {
            Console.WriteLine("Doing Real Work!");
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
