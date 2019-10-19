/*--- TASK 1 --------- ADDRESSES WITH TOWNS -----------------------*/
USE SoftUni

SELECT TOP (50) e.FirstName
               ,e.LastName
               ,t.[Name] AS Town
               ,a.AddressText
FROM Employees AS e
JOIN Addresses a ON e.AddressID = a.AddressID
JOIN Towns t ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName

/*--- TASK 2 --------- SALES EMPLOYEES ----------------------------*/
SELECT e.EmployeeID
      ,e.FirstName
      ,e.LastName 
      ,d.[Name] AS DepartmentName
FROM Employees AS e 
INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID

/*--- TASK 3 --------- EMPLOYEES HIRED AFTER ----------------------*/
SELECT e.FirstName
      ,e.LastName
      ,e.HireDate
      ,d.[Name] as DeptName
FROM Employees AS e
INNER JOIN Departments d ON (e.DepartmentId = d.DepartmentId AND e.HireDate > '1/1/1999' 
                                                             AND d.[Name] IN ('Sales', 'Finance'))
ORDER BY e.HireDate ASC

/*--- TASK 4 --------- EMPLOYEES SUMMARY --------------------------*/
SELECT TOP (50) e.EmployeeID
               ,e.FirstName + ' ' + e.LastName AS EmployeeName
               ,m.FirstName + ' ' + m. LastName AS ManagerName
               ,d.[Name] AS DepartmentName
FROM Employees AS e
LEFT JOIN Employees AS m ON m.EmployeeID = e.ManagerID
LEFT JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
ORDER BY e.EmployeeID ASC

/*--- TASK 5 --------- MIN AVERAGE SALARY -------------------------*/
SELECT MIN(a.AverageSalary) AS MinAverageSalary
FROM 
    (
        SELECT e.DepartmentID 
              ,AVG(e.Salary) AS AverageSalary
        FROM Employees AS e
        GROUP BY e.DepartmentID
    ) AS a



