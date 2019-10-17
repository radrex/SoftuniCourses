/*--- TASK 1 --------- DEPARTMENTS TOTAL SALARIES -----------------*/
USE SoftUni

SELECT e.DepartmentID 
      ,SUM(e.Salary) AS TotalSalary
FROM Employees AS e
GROUP BY e.DepartmentID
ORDER BY e.DepartmentID

