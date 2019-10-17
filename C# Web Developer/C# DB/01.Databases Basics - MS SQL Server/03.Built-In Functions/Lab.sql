/*--- TASK 1 --------- OBFUSCATE CC NUMBERS -----------------------*/
USE SoftUni

SELECT FirstName + ' ' + LastName AS [Full Name]
      ,JobTitle
      ,Salary
FROM Employees

/*--- TASK 2 --------- PALLETS ------------------------------------*/
USE Geography

CREATE VIEW v_HighestPeak AS
SELECT TOP (1) *
FROM Peaks
ORDER BY Elevation DESC

/*--- TASK 3 --------- QUARTERLY REPORT ---------------------------*/
USE SoftUni

UPDATE Projects
SET EndDate = '2017-01-23'
WHERE EndDate IS NULL