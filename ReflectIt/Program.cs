using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectIt
{
    class Program
    {
        static void Main(string[] args)
        {
            //var employeeList = new List<Employee>();
            //                                  Unbound Types
            var employeeList = CreateCollection(typeof(List<>), typeof(Employee));
            Console.WriteLine($"Type Name of Employee List : {employeeList.GetType().Name}");
            Console.WriteLine($"Type Full Name of Employee List : {employeeList.GetType().FullName}");
            var genericTypeArgs = employeeList.GetType().GenericTypeArguments;
            foreach (var arg in genericTypeArgs)
            {
                Console.WriteLine($"Generic Type Argument is : {arg.Name}");
            }
            var employee = new Employee();
            var employeeType = typeof(Employee);
            var methodInfo = employeeType.GetMethod("Speak");
            methodInfo = methodInfo.MakeGenericMethod(typeof(DateTime));
            methodInfo.Invoke(employee, null);
        }

        private static object CreateCollection(Type collectionType, Type itemType)
        {
            var closedType = collectionType.MakeGenericType(itemType);
            return Activator.CreateInstance(closedType);
        }

        public class Employee
        {
            public string Name { get; set; }
            public void Speak<T>()
            {
                Console.WriteLine($"Speak Type of T from Employee class : {typeof(T).Name}");
            }
        }
    }
}
