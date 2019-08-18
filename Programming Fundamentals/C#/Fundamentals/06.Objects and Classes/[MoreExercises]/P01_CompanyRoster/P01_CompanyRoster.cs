namespace P01_CompanyRoster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P01_CompanyRoster
    {
        static void Main(string[] args)
        {
            List<Department> departments = new List<Department>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] employeeData = Console.ReadLine().Split();
                string name = employeeData[0];
                decimal salary = decimal.Parse(employeeData[1]);
                string departmentName = employeeData[2];

                if (!departments.Any(d => d.Name == departmentName))
                {
                    Department department = new Department()
                    {
                        Name = departmentName,
                    };
                    departments.Add(department);
                }

                Employee employee = new Employee()
                {
                    Name = name,
                    Salary = salary,
                    Department = departments.First(d => d.Name == departmentName)
                };

                departments.First(d => d.Name == departmentName).Employees.Add(employee);
            }

            Department bestDepartment = departments.OrderByDescending(d => d.Employees.Sum(e => e.Salary) / d.Employees.Count).First();

            Console.WriteLine($"Highest Average Salary: {bestDepartment.Name}");
            foreach (Employee employee in bestDepartment.Employees.OrderByDescending(e => e.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2}");
            }
        }
    }

    class Employee
    {
        public string Name { get; set; }

        public decimal Salary { get; set; }

        public Department Department { get; set; }
    }

    class Department
    {
        public Department()
        {
            this.Employees = new List<Employee>();
        }

        public string Name { get; set; }

        public List<Employee> Employees { get; set; }
    }
}