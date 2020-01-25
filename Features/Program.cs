using System;
using System.Collections.Generic;
using System.Linq;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            Func<int, int> square = x => x * x;
            Func<int, int, int> add = (int x, int y) =>
            {
                int temp = x + y;
                return temp;
            };
            Action<int> write = x => Console.WriteLine(x);               

            write(square(add(3, 5)));

            //IEnumerable<Employee> developers = new Employee[]
            var developers = new Employee[]
            {
                new Employee { Id = 1, Name = "Miro"},
                new Employee { Id = 2, Name = "Ceco" }
            };

            //IEnumerable<Employee> sales = new List<Employee>()
            var sales = new List<Employee>()
            {
                new Employee { Id = 3, Name = "Ilian"}
            };

            //Console.WriteLine(developers.Count());
            //IEnumerator<Employee> enumerator = developers.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    Console.WriteLine(enumerator.Current.Name);
            //}

            var query = developers.Where(e => e.Name.Length == 5)
                                    .OrderBy(e => e.Name);



            foreach (var employee in developers.Where(
                e => e.Name.Length == 4)
                .OrderBy(e => e.Name ))
 
                
                //Where(e => e.Name.StartsWith("C")))
            {
                Console.WriteLine(employee.Name);
            }
        }


        private static bool NameStartWithM(Employee employee)
        {
            return employee.Name.StartsWith("M");
        }
    }
}
