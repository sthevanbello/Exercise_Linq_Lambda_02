using ExerciseLinqLambda02.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExerciseLinqLambda02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

            List<Employee> employees = new List<Employee>();
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] fields = sr.ReadLine().Split(',');
                        string name = fields[0];
                        string email = fields[1];
                        double salary = double.Parse(fields[2]);

                        employees.Add(new Employee(name, email, salary));
                    }

                }

                Console.Write("Enter salary: ");
                double salaryQuery = double.Parse(Console.ReadLine());

                var resultSalary = employees.Where(e => e.Salary > salaryQuery).OrderBy(e => e.Email).Select(e => e.Email);

                foreach (var item in resultSalary)
                {
                    Console.WriteLine(item);
                }

                var sumSalaryM = employees.Where(e => e.Name[0] == 'M').Sum(e => e.Salary);
                Console.WriteLine($"Sum of salary of people whose name starts with 'M': {sumSalaryM:C}");

            }
            catch (IOException ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
