/*--- TASK 1 --------- EXAMINE THE DATABASES ----------------------*/
/*-- EXECUTE THE SCRIPTS FOR THE DATABASES --> Diablo-Database ----*/
/*--									   --> SoftUni-Database ---*/
/*--									   --> Geography-Database -*/

/*--- TASK 2 --------- FIND ALL INFORMATION ABOUT DEPARTMENTS -----*/
USE SoftUni
GO

SELECT * FROM Departments

/*--- TASK 3 --------- FIND ALL DEPARTMENT NAMES ------------------*/
SELECT [Name] 
FROM Departments

/*--- TASK 4 --------- FIND SALARY OF EACH EMPLOYEE ---------------*/
SELECT FirstName
	  ,LastName
	  ,Salary 
FROM Employees

/*--- TASK 5 --------- FIND FULL NAME OF EACH EMPLOYEE ------------*/
SELECT FirstName
	  ,MiddleName
	  ,LastName 
FROM Employees

/*--- TASK 6 --------- FIND EMAIL ADDRESS OF EACH EMPLOYEE --------*/
SELECT (FirstName + '.' + LastName + '@softuni.bg') AS [Full Email Address]
FROM Employees

/*--- TASK 7 --------- FIND ALL DIFFERENT EMPLOYEE'S SALARIES -----*/
SELECT DISTINCT Salary 
FROM Employees

/*--- TASK 8 --------- FIND ALL INFORMATION ABOUT EMPLOYEES -------*/
SELECT *
FROM Employees
WHERE JobTitle = 'Sales Representative'

/*--- TASK 9 ---- FIND NAMES OF ALL EMPLOYEES BY SALARY IN RANGE --*/
SELECT FirstName
	  ,LastName
	  ,JobTitle
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

/*--- TASK 10 --------- FIND NAMES OF ALL EMPLOYEES ---------------*/
SELECT (FirstName + ' ' + MiddleName + ' ' + LastName) AS [Full Name]
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)

/*--- TASK 11 --------- FIND ALL EMPLOYEES WITHOUT MANAGER --------*/
SELECT FirstName
	  ,LastName
FROM Employees
WHERE ManagerID IS NULL

/*--- TASK 12 --------- FIND ALL EMPLOYEES WITH SALARY MORE THAN --*/
SELECT FirstName
	  ,LastName
	  ,Salary
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

/*--- TASK 13 --------- FIND 5 BEST PAID EMPLOYEES ----------------*/
SELECT TOP(5) FirstName
			 ,LastName
FROM Employees
ORDER BY Salary DESC

/*--- TASK 14 --------- FIND ALL EMPLOYEES EXCEPT MARKETING -------*/
SELECT FirstName
	  ,LastName
FROM Employees
WHERE NOT (DepartmentID = 4)

/*--- TASK 15 --------- SORT EMPLOYEES TABLE ----------------------*/
SELECT * 
FROM Employees
ORDER BY Salary DESC
		,FirstName ASC
		,LastName DESC
		,MiddleName ASC

/*--- TASK 16 --------- CREATE VIEW EMPLOYEES WITH SALARIES -------*/
CREATE VIEW V_EmployeesSalaries AS
SELECT FirstName
	  ,LastName
	  ,Salary
FROM Employees

/*--- TASK 17 --------- CREATE VIEW EMPLOYEES WITH JOB TITLES -----*/
CREATE VIEW V_EmployeeNameJobTitle AS
SELECT (FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName) AS [Full Name]
	  ,JobTitle AS [Job Title]
FROM Employees

/*--- TASK 18 --------- DISTINCT JOB TITLES -----------------------*/
SELECT DISTINCT JobTitle
FROM Employees

/*--- TASK 19 --------- FIND FIRST 10 STARTED PROJECTS ------------*/
SELECT TOP(10) *
FROM Projects
ORDER BY StartDate ASC
		,[Name] ASC

/*--- TASK 20 --------- LAST 7 HIRED EMPLOYEES --------------------*/
SELECT TOP(7) FirstName
			 ,LastName
			 ,HireDate
FROM Employees
ORDER BY HireDate DESC

/*--- TASK 21 --------- INCREASE SALARIES -------------------------*/
UPDATE Employees
SET Salary *= 1.12
WHERE DepartmentID IN(1, 2, 4, 11)

SELECT Salary FROM Employees

/*--- TASK 22 --------- ALL MOUNTAIN PEAKS ------------------------*/
USE Geography
GO

SELECT PeakName
FROM Peaks
ORDER BY PeakName ASC

/*--- TASK 23 --------- BIGGEST COUNTRIES BY POPULATION -----------*/
SELECT TOP(30) CountryName
			  ,[Population]
FROM Countries
WHERE ContinentCode = 'EU'
ORDER BY [Population] DESC
		,CountryName ASC

/*--- TASK 24 --------- COUNTRIES AND CURRENCY (EURO / NOT EURO) --*/
SELECT CountryName
	  ,CountryCode
	  ,Currency = CASE CurrencyCode
						WHEN 'EUR' THEN 'Euro'
						ELSE 'Not Euro'
				  END
FROM Countries
ORDER BY CountryName ASC

/*--- TASK 25 --------- ALL DIABLO CHARACTERS ---------------------*/
USE Diablo
GO

SELECT [Name] 
FROM Characters
ORDER BY [Name] ASC

