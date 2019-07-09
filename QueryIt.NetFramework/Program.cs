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
            Database.SetInitializer(new DropCreateDatabaseAlways<EmployeeDb>());
            using (IRepository<Employee> employeeRepository = new SqlRepository<Employee>(new EmployeeDb()))
            {

                AddEmployees(employeeRepository);
                AddManagers(employeeRepository);
                CountEmployees(employeeRepository);
                QueryEmployees(employeeRepository);
                DumpPeople(employeeRepository);
            }
        }

        private static void AddManagers(IWriteOnlyRepository<Manager> employeeRepository)
        {
            employeeRepository.Add(new Manager { Name = "Mgr. Scott" });
            employeeRepository.Commit();
        }

        private static void DumpPeople(IReadonlyRepository<Person> employeeRepository)
        {
            var persons = employeeRepository.FindAll();
            foreach (var person in persons)
            {
                Console.WriteLine($"People are : {person.Name}");
            }
        }

        private static void QueryEmployees(IRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.FindById(1);
            Console.WriteLine($"Queried Employee is : {employee.Name}");

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
