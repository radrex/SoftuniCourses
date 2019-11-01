namespace SoftUni
{
    using SoftUni.Data;
    using SoftUni.Models;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                //------------------ TASK 03 -- EMPLOYEES FULL INFORMATION ------------------------
                //string result = GetEmployeesFullInformation(context);

                //------------------ TASK 04 -- EMPLOYEES WITH SALARY OVER 50 000 -----------------
                //string result = GetEmployeesWithSalaryOver50000(context);

                //------------------ TASK 05 -- EMPLOYEES FROM RESEARCH AND DEVELOPMENT -----------
                //string result = GetEmployeesFromResearchAndDevelopment(context);

                //------------------ TASK 06 -- ADDING A NEW ADDRESS AND UPDATING EMPLOYEE --------
                //string result = AddNewAddressToEmployee(context);

                //------------------ TASK 07 -- EMPLOYEES AND PROJECTS ----------------------------
                //string result = GetEmployeesInPeriod(context);

                //------------------ TASK 08 -- ADDRESSES BY TOWN ---------------------------------
                //string result = GetAddressesByTown(context);

                //------------------ TASK 09 -- EMPLOYEE 147 --------------------------------------
                //string result = GetEmployee147(context);

                //------------------ TASK 10 -- DEPARTMENTS WITH MORE THAN 5 EMPLOYEES ------------
                //string result = GetDepartmentsWithMoreThan5Employees(context);

                //------------------ TASK 11 -- FIND LATEST 10 PROJECTS ---------------------------
                //string result = GetLatestProjects(context);

                //------------------ TASK 12 -- INCREASE SALARIES ---------------------------------
                //string result = IncreaseSalaries(context);

                //------------------ TASK 13 -- FIND EMPLOYEES BY FIRST NAME STARTING WITH 'Sa' ---
                //string result = GetEmployeesByFirstNameStartingWithSa(context);

                //------------------ TASK 14 -- DELETE PROJECT BY ID ------------------------------
                //string result = DeleteProjectById(context);

                //------------------ TASK 15 -- REMOVE TOWN ---------------------------------------
                string result = RemoveTown(context);

                Console.WriteLine(result);
            }
        }

        //------------------ TASK 03 -- EMPLOYEES FULL INFORMATION ------------------------
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees
                                   .Select(e => new
                                   {
                                       e.FirstName,
                                       e.LastName,
                                       e.MiddleName,
                                       e.JobTitle,
                                       e.Salary,
                                       e.EmployeeId
                                   })
                                   .OrderBy(e => e.EmployeeId)
                                   .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }
            return sb.ToString().TrimEnd();
        }

        //------------------ TASK 04 -- EMPLOYEES WITH SALARY OVER 50 000 -----------------
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees
                                   .Where(e => e.Salary > 50000)
                                   .Select(e => new
                                   {
                                       e.FirstName,
                                       e.Salary
                                   })
                                   .OrderBy(e => e.FirstName)
                                   .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //------------------ TASK 05 -- EMPLOYEES FROM RESEARCH AND DEVELOPMENT -----------
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees
                                   .Where(e => e.Department.Name == "Research and Development")
                                   .Select(e => new
                                   {
                                       e.FirstName,
                                       e.LastName,
                                       DepartmentName = e.Department.Name,
                                       e.Salary
                                   })
                                   .OrderBy(e => e.Salary)
                                   .ThenByDescending(e => e.FirstName)
                                   .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //------------------ TASK 06 -- ADDING A NEW ADDRESS AND UPDATING EMPLOYEE --------
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            Address address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            //context.Add(address);
            Employee nakov = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            nakov.Address = address;
            context.SaveChanges();

            var employeeAddresses = context.Employees
                                           .OrderByDescending(e => e.AddressId)
                                           .Select(e => e.Address.AddressText)
                                           .Take(10)
                                           .ToList();

            foreach (var employeeAddress in employeeAddresses)
            {
                sb.AppendLine($"{employeeAddress}");
            }

            return sb.ToString().TrimEnd();
        }

        //------------------ TASK 07 -- EMPLOYEES AND PROJECTS ----------------------------
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees
                                   .Where(e => e.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                                   .Select(e => new
                                   {
                                       EmployeeFullName = e.FirstName + " " + e.LastName,
                                       ManagerFullName = e.Manager.FirstName + " " + e.Manager.LastName,
                                       Projects = e.EmployeesProjects
                                                   .Select(p => new
                                                   {
                                                       ProjectName = p.Project.Name,
                                                       StartDate = p.Project.StartDate,
                                                       EndDate = p.Project.EndDate
                                                   })
                                                       .ToList()
                                   })
                                   .Take(10)
                                   .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.EmployeeFullName} - Manager: {employee.ManagerFullName}");
                foreach (var project in employee.Projects)
                {
                    string startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    string endDate = project.EndDate.HasValue ? project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished";
                    sb.AppendLine($"--{project.ProjectName} - {startDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //------------------ TASK 08 -- ADDRESSES BY TOWN ---------------------------------
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var addresses = context.Addresses
                                   .Select(a => new
                                   {
                                       Town = a.Town.Name,
                                       AddressText = a.AddressText,
                                       Employees = a.Employees.Count
                                   })
                                   .ToList()
                                   .OrderByDescending(a => a.Employees)
                                   .ThenBy(a => a.Town)
                                   .ThenBy(a => a.AddressText)
                                   .Take(10)
                                   .ToList();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.Town} - {address.Employees} employees");
            }

            return sb.ToString().TrimEnd();
        }
        //------------------ TASK 09 -- EMPLOYEE 147 --------------------------------------
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employee = context.Employees
                                  .Where(e => e.EmployeeId == 147)
                                  .Select(e => new
                                  {
                                      e.FirstName,
                                      e.LastName,
                                      e.JobTitle,
                                      Projects = e.EmployeesProjects
                                                  .Select(p => p.Project.Name)
                                                  .OrderBy(p => p)
                                                  .ToList()
                                  })
                                  .First();

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            sb.AppendLine(String.Join(Environment.NewLine, employee.Projects));
            return sb.ToString().TrimEnd();
        }

        //------------------ TASK 10 -- DEPARTMENTS WITH MORE THAN 5 EMPLOYEES ------------
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var departments = context.Departments
                                     .Where(d => d.Employees.Count > 5)
                                     .OrderBy(d => d.Employees.Count)
                                     .ThenBy(d => d.Name)
                                     .Select(d => new
                                     {
                                         DepartmentName = d.Name,
                                         ManagerFullName = d.Manager.FirstName + " " + d.Manager.LastName,
                                         Employees = d.Employees
                                                      .Select(e => new
                                                      {
                                                          EmployeeFullName = e.FirstName + " " + e.LastName,
                                                          e.JobTitle
                                                      })
                                                      .OrderBy(e => e.EmployeeFullName)
                                                      .ToList()
                                     })
                                     .ToList();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.DepartmentName} - {department.ManagerFullName}");
                foreach (var employee in department.Employees)
                {
                    sb.AppendLine($"{employee.EmployeeFullName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //------------------ TASK 11 -- FIND LATEST 10 PROJECTS ---------------------------
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var projects = context.Projects
                                  .OrderByDescending(p => p.StartDate)
                                  .Take(10)
                                  .Select(p => new
                                  {
                                      p.Name,
                                      p.Description,
                                      StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                                  })
                                  .OrderBy(p => p.Name)
                                  .ToList();

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.StartDate);
            }

            return sb.ToString().TrimEnd();
        }

        //------------------ TASK 12 -- INCREASE SALARIES ---------------------------------
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            context.Employees
                   .Where(e => new[] { "Engineering", "Tool Design", "Marketing", "Information Services" }.Contains(e.Department.Name))
                   .ToList()
                   .ForEach(e => e.Salary *= 1.12M);

            context.SaveChanges();

            var employees = context.Employees
                                   .Where(e => new[] { "Engineering", "Tool Design", "Marketing", "Information Services" }.Contains(e.Department.Name))
                                   .Select(e => new
                                   {
                                       EmployeeFullName = e.FirstName + " " + e.LastName,
                                       e.Salary
                                   })
                                   .OrderBy(e => e.EmployeeFullName)
                                   .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.EmployeeFullName} (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        //------------------ TASK 13 -- FIND EMPLOYEES BY FIRST NAME STARTING WITH 'Sa' ---
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees
                                   .Where(e => e.FirstName.StartsWith("Sa"))
                                   .Select(e => new
                                   {
                                       EmployeeFullName = e.FirstName + " " + e.LastName,
                                       e.JobTitle,
                                       e.Salary
                                   })
                                   .OrderBy(e => e.EmployeeFullName)
                                   .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.EmployeeFullName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        //------------------ TASK 14 -- DELETE PROJECT BY ID ------------------------------
        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Project project = context.Projects.First(p => p.ProjectId == 2);
            context.EmployeesProjects.ToList().ForEach(p => context.EmployeesProjects.Remove(p));
            context.Projects.Remove(project);
            context.SaveChanges();

            List<string> projects = context.Projects
                                           .Take(10)
                                           .Select(p => p.Name)
                                           .ToList();

            foreach (string p in projects)
            {
                sb.AppendLine(p);
            }

            return sb.ToString().TrimEnd();
        }
        //------------------ TASK 15 -- REMOVE TOWN ---------------------------------------
        public static string RemoveTown(SoftUniContext context)
        {
            var employees = context.Employees.Where(e => e.Address.Town.Name == "Seattle").ToList();

            foreach (var employee in employees)
            {
                employee.AddressId = null;
            }

            var towns = context.Towns.Where(t => t.Name == "Seattle").ToList();

            var addresses = context.Addresses.Where(a => a.Town.Name == "Seattle").ToList();

            int count = addresses.Count();

            foreach (var address in addresses)
            {
                context.Addresses.Remove(address);
            }

            foreach (var town in towns)
            {
                context.Towns.Remove(town);
            }

            context.SaveChanges();       
            return $"{count} addresses in Seattle were deleted";
        }
    }
}
