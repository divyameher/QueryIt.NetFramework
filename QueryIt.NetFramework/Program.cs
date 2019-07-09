//using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data.Entity;
using System.Linq;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace QueryIt
{
    class Program
    {
        static void Main(string[] args)
        {
            //var repository = new Repository<Employee>(); // talks to real database!
            //AddEmployee(repository);
            //AddManager(repository);
            //CountEmployees(repository);
            //PrintAllPeople(repository);
            Database.SetInitializer(new DropCreateDatabaseAlways<EmployeeDb>());
            using (IRepository<Employee> employeeRepository = new SqlRepository<Employee>(new EmployeeDb()))
            {

                AddEmployees(employeeRepository);
                CountEmployees(employeeRepository);
            }

        }

        private static void CountEmployees(IRepository<Employee> employeeRepository)
        {
            Console.WriteLine($"Employee Count is : {employeeRepository.FindAll().Count()}");
        }

        private static void AddEmployees(IRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { Name = "Scott" });
            employeeRepository.Add(new Employee { Name = "Danny" });
            employeeRepository.Add(new Employee { Name = "Robert" });
            employeeRepository.Commit();
        }
    }
}
