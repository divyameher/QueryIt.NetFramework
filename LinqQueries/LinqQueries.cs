using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqQueries
{
    public class LinqQueries
    {
        public void RunQuery()
        {
            var employees = new List<Employee>();
            employees.Add(new Employee() { Name = "Henry" });
            employees.Add(new Employee() { Name = "Williams" });
            employees.Add(new Employee() { Name = "Jon" });
            employees.Add(new Employee() { Name = "Harry" });
            employees.Add(new Employee() { Name = "Harvard" });
            var query = employees.Where(e => e.Name.StartsWith("H"))
                .OrderBy(e => e.Name);
            foreach (var employee in query)
            {
                Console.WriteLine(employee.Name);
            }
        }
    }
}
