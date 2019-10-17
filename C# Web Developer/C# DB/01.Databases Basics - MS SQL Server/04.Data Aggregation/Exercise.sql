/*--- TASK 1 --------- RECORD'S COUNT -----------------------------*/
USE Gringotts
GO

SELECT COUNT(*) AS [Count]
FROM WizzardDeposits

/*--- TASK 2 --------- LONGEST MAGIC WAND -------------------------*/
SELECT MAX(MagicWandSize) AS [Longest Magic Wand]
FROM WizzardDeposits

/*--- TASK 3 --------- LONGEST MAGIC WAND PER DEPOSIT GROUPS ------*/
SELECT DepositGroup
      ,MAX(MagicWandSize) AS [Longest Magic Wand]
FROM WizzardDeposits
GROUP BY DepositGroup

/*--- TASK 4 --------- SMALLEST DEPOSIT GROUP PER MAGIC WAND SIZE -*/
SELECT TOP 2 DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

/*--- TASK 5 --------- DEPOSITS SUM -------------------------------*/
SELECT DepositGroup
      ,SUM(DepositAmount) AS [Total Sum]
FROM WizzardDeposits
GROUP BY DepositGroup

/*--- TASK 6 --------- DEPOSITS SUM FOR OLLIVANDER FAMILLY --------*/
SELECT DepositGroup
      ,SUM(DepositAmount) AS [Total Sum]
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander Family'
GROUP BY DepositGroup

/*--- TASK 7 --------- DEPOSITS FILTER ----------------------------*/
SELECT DepositGroup
      ,SUM(DepositAmount) AS [Total Sum]
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander Family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY [Total Sum] DESC

/*--- TASK 8 --------- DEPOSIT CHARGE -----------------------------*/
SELECT DepositGroup
      ,MagicWandCreator
	  ,MIN(DepositCharge) AS [Min Deposit Charge]
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator

/*--- TASK 9 --------- AGE GROUPS ---------------------------------*/
SELECT AgeGroupTable.AgeGroup
      ,COUNT(AgeGroupTable.AgeGroup) AS WizardCount 
FROM 
      (
        SELECT 
            CASE
               WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
               WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
               WHEN Age BETWEEN 21 and 30 THEN '[21-30]'
               WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
               WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
               WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
               ELSE '[61+]'
			END AS AgeGroup 
        FROM WizzardDeposits
    ) AS AgeGroupTable
GROUP BY AgeGroup
ORDER BY AgeGroup

/*--- TASK 10 -------- FIRST LETTER -------------------------------*/
SELECT LEFT(FirstName, 1) AS FirstLetter 
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)

/*--- TASK 11 -------- AVERAGE INTEREST ---------------------------*/
SELECT DepositGroup
      ,IsDepositExpired
      ,AVG(DepositInterest) AS [AverageInterest]
FROM WizzardDeposits
WHERE DATEPART(YEAR, DepositStartDate) >= 1985
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired

/*--- TASK 12 -------- RICH WIZARD, POOR WIZARD -------------------*/
SELECT SUM([Difference]) AS SumDifference 
FROM 
(
    SELECT w.FirstName AS [Host Wizzard]
          ,w.DepositAmount AS [Host Wizzard Deposit]
          ,wd.FirstName AS [Guest Wizzard]
          ,wd.DepositAmount AS [Guest Wizzard Deposit]
          ,w.DepositAmount - wd.DepositAmount AS [Difference]
    FROM WizzardDeposits AS w
    JOIN WizzardDeposits AS wd ON w.Id = wd.Id - 1
) AS WizardTable

/*--- TASK 13 -------- DEPARTMENTS TOTAL SALARIES -----------------*/
USE SoftUni

SELECT DepartmentID
      ,SUM(Salary) AS TotalSalary 
FROM Employees
GROUP BY DepartmentID

/*--- TASK 14 -------- EMPLOYEES MINIMUM SALARIES -----------------*/
SELECT DepartmentID
      ,MIN(Salary) AS MinimumSalary 
FROM Employees
WHERE DATEPART(YEAR, HireDate) >= 2000
GROUP BY DepartmentID
HAVING DepartmentID IN (2, 5, 7)

/*--- TASK 15 -------- EMPLOYEES AVERAGE SALARIES -----------------*/
SELECT * 
INTO EmployeesWithHighSalary
FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeesWithHighSalary
WHERE ManagerID = 42

UPDATE EmployeesWithHighSalary
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID
      ,AVG(Salary) AS AverageSalary 
FROM EmployeesWithHighSalary
GROUP BY DepartmentID

/*--- TASK 16 -------- EMPLOYEES MAXIMUM SALARIES -----------------*/
SELECT DepartmentID
      ,MAX(Salary) AS MaxSalary 
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

/*--- TASK 17 -------- EMPLOYEES COUNT SALARIES -------------------*/
SELECT COUNT(Salary) AS [Count] 
FROM Employees
WHERE ManagerID IS NULL

/*--- TASK 18 -------- 3rd HIGHEST SALARY -------------------------*/
SELECT DISTINCT RankedSalaries.DepartmentID
               ,RankedSalaries.Salary
FROM 
    (
        SELECT DepartmentID
              ,Salary
              ,DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRank
        FROM Employees
    ) AS RankedSalaries
WHERE RankedSalaries.SalaryRank = 3

/*--- TASK 19 -------- SALARY CHALLENGE ---------------------------*/
SELECT TOP (10) FirstName
               ,LastName
               ,DepartmentID
FROM Employees AS e
WHERE Salary > (	
                    SELECT AVG(Salary) 
                    FROM Employees AS em 
                    WHERE em.DepartmentID = e.DepartmentID
			   )

