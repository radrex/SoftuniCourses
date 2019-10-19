/*--- TASK 1 --------- EMPLOYEE ADDRESS ---------------------------*/
USE SoftUni
GO

SELECT TOP(5) e.EmployeeID
             ,e.JobTitle
	         ,e.AddressID
	         ,a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON a.AddressID = e.AddressID
ORDER BY a.AddressID

/*--- TASK 2 --------- ADDRESSES WITH TOWNS -----------------------*/
SELECT TOP(50) e.FirstName
              ,e.LastName
			  ,t.[Name]
			  ,a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON a.AddressID = e.AddressID
JOIN Towns AS t ON t.TownID = a.TownID
ORDER BY e.FirstName ASC, e.LastName ASC

/*--- TASK 3 --------- SALES EMPLOYEE -----------------------------*/
SELECT e.EmployeeID
      ,e.FirstName
	  ,e.LastName
	  ,d.[Name] AS [DepartmentName]
FROM Employees AS e
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID ASC

/*--- TASK 4 --------- EMPLOYEE DEPARTMENTS -----------------------*/
SELECT TOP(5) e.EmployeeID
             ,e.FirstName
			 ,e.Salary
			 ,d.[Name] AS [DepartmentName]
FROM Employees AS e
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
WHERE e.Salary > 15000
ORDER BY d.DepartmentID ASC

/*--- TASK 5 --------- EMPLOYEES WITHOUT PROJECT ------------------*/
SELECT TOP(3) e.EmployeeID
             ,e.FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID ASC

/*--- TASK 6 --------- EMPLOYEES HIRED AFTER ----------------------*/
SELECT e.FirstName
      ,e.LastName
	  ,e.HireDate
	  ,d.[Name] AS [DeptName]
FROM Employees AS e
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
WHERE e.HireDate > '1.1.1999' AND d.[Name] IN ('Sales', 'Finance')
ORDER BY e.HireDate ASC

/*--- TASK 7 --------- EMPLOYEES WITH PROJECT ---------------------*/
SELECT TOP(5) e.EmployeeID
             ,e.FirstName
			 ,p.[Name] AS [ProjectName]
FROM Employees AS e
JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE p.StartDate > '2002.06.01' AND p.EndDate IS NULL
ORDER BY e.EmployeeID ASC

/*--- TASK 8 --------- EMPLOYEE 24 --------------------------------*/
SELECT e.EmployeeID
      ,e.FirstName
	  ,CASE
           WHEN DATEPART(YEAR, p.StartDate) >= 2005 THEN NULL
		   ELSE p.[Name]
       END AS [ProjectName]
FROM Employees AS e
JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24

/*--- TASK 9 --------- EMPLOYEE MANAGER ---------------------------*/
SELECT e.EmployeeID
      ,e.FirstName
	  ,e.ManagerID
	  ,m.FirstName AS [ManagerName]
FROM Employees AS e
JOIN Employees AS m ON m.EmployeeID = e.ManagerID
WHERE e.ManagerID IN(3, 7)
ORDER BY e.EmployeeID ASC

/*--- TASK 10 -------- EMPLOYEE SUMMARY ---------------------------*/
SELECT TOP(50) e.EmployeeID
              ,CONCAT(e.FirstName, ' ', e.LastName) AS [EmployeeName]
			  ,CONCAT(m.FirstName, ' ', m.LastName) AS [ManagerName]
			  ,d.[Name] AS [DepartmentName]
FROM Employees AS e
JOIN Employees AS m ON m.EmployeeID = e.ManagerID
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
ORDER BY e.EmployeeID ASC

/*--- TASK 11 -------- MIN AVERAGE SALARY -------------------------*/
SELECT MIN(a.AverageSalary) AS [MinAverageSalary]
FROM
(
    SELECT DepartmentID
          ,AVG(Salary) AS AverageSalary
    FROM Employees
    GROUP BY DepartmentID
) AS a

/*--- TASK 12 -------- HIGHEST PEAKS IN BULGARIA ------------------*/
USE [Geography]
GO

SELECT c.CountryCode
      ,m.MountainRange
	  ,p.PeakName
	  ,p.Elevation
FROM Countries AS c
JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
JOIN Mountains AS m ON m.Id = mc.MountainId
JOIN Peaks AS p ON p.MountainId = m.Id
WHERE c.CountryName = 'Bulgaria' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

/*--- TASK 13 -------- COUNT MOUNTAIN RANGES ----------------------*/
SELECT c.CountryCode
      ,COUNT(m.MountainRange) AS [MountainRanges]
FROM Countries AS c
JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
JOIN Mountains AS m ON m.Id = mc.MountainId
WHERE c.CountryName IN('United States', 'Russia', 'Bulgaria')
GROUP BY c.CountryCode

/*--- TASK 14 -------- COUNTRIES WITH RIVERS ----------------------*/
SELECT TOP(5) c.CountryName
             ,r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName ASC

/*--- TASK 15 -------- CONTINENTS AND CURRENCIES ------------------*/
SELECT MostUsedCurrency.ContinentCode
      ,MostUsedCurrency.CurrencyCode
      ,MostUsedCurrency.CurrencyUsage
FROM
    (
        SELECT c.ContinentCode
              ,c.CurrencyCode
              ,COUNT(c.CurrencyCode) AS CurrencyUsage
              ,DENSE_RANK() OVER (PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS CurrencyRank
        FROM Countries AS c
        GROUP BY c.ContinentCode, c.CurrencyCode
        HAVING COUNT(c.CurrencyCode) > 1

    ) AS MostUsedCurrency

WHERE MostUsedCurrency.CurrencyRank = 1
ORDER BY MostUsedCurrency.ContinentCode, MostUsedCurrency.CurrencyUsage

/*--- TASK 16 --- COUNTRIES WITHOUT ANY MOUNTAINS -------*/
SELECT COUNT(*) AS CountryCode
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
WHERE mc.CountryCode IS NULL

/*--- TASK 16 -------- COUNTRIES WITHOUT ANY MOUNTAINS ------------*/
SELECT COUNT(*)
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
WHERE mc.MountainId IS NULL

/*--- TASK 17 -------- HIGHEST PEAK AND LONGEST RIVER BY COUNTRY --*/
SELECT TOP(5) c.CountryName
             ,MAX(p.Elevation) AS MaxElevation
             ,MAX(r.[Length]) AS MaxRiverLength
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
LEFT JOIN Peaks AS p ON p.MountainId = mc.MountainId
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
GROUP BY c.CountryName
ORDER BY MaxElevation DESC, MaxRiverLength DESC, c.CountryName

/*--- TASK 18 -------- HIGHEST PEAK NAME AND ELEVATION BY COUNTRY -*/
SELECT TOP(5) k.CountryName
             ,ISNULL(k.PeakName, '(no highest peak)') AS [Highest Peak Name]
             ,ISNULL(k.MaxElevation, 0) AS [Highest Peak Elevation]
             ,ISNULL(k.MountainRange, '(no mountain)') AS [Mountain]
FROM
    (
        SELECT c.CountryName
              ,MAX(p.Elevation) AS [MaxElevation]
        	  ,p.PeakName
        	  ,m.MountainRange
        	  ,DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY MAX(p.Elevation) DESC) AS ElevationRank
        FROM Countries AS c
        LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
        LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
        LEFT JOIN Peaks AS p ON p.MountainId = m.Id
        GROUP BY c.CountryName, p.PeakName, m.MountainRange
    ) AS k
WHERE k.ElevationRank = 1
ORDER BY k.CountryName, k.PeakName