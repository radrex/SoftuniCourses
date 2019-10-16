USE master
GO

/*--- TASK 1 --------- EMPLOYEE SUMMARY ---------------------------*/
USE SoftUni

SELECT  FirstName + ' ' + LastName AS [Full Name]
       ,JobTitle
       ,Salary
FROM Employees

/*--- TASK 2 --------- HIGHEST PEAK -------------------------------*/
USE Geography

CREATE VIEW v_HighestPeak AS
SELECT TOP (1) *
FROM Peaks
ORDER BY Elevation DESC

/*--- TASK 3 --------- UPDATE PROJECT -----------------------------*/
USE SoftUni

UPDATE Projects
	SET EndDate = '2017-01-23'
	WHERE EndDate IS NULL