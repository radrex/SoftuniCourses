/*--- TASK 16 ---- CREATE SOFTUNI DATABASE  -------------------*/
CREATE DATABASE SoftUni
USE SoftUni

CREATE TABLE Towns (
	 Id INT PRIMARY KEY IDENTITY(1, 1) NOT NULL
	,[Name] NVARCHAR(100) NOT NULL
)

CREATE TABLE Addresses (
	 Id INT PRIMARY KEY IDENTITY(1, 1) NOT NULL
	,AddressText NVARCHAR(100) NOT NULL
	,TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE Departments (
	 Id INT PRIMARY KEY IDENTITY(1, 1) NOT NULL
	,[Name] NVARCHAR(100) NOT NULL
)

CREATE TABLE Employees (
	 Id INT PRIMARY KEY IDENTITY(1, 1) NOT NULL
	,FirstName NVARCHAR(50) NOT NULL
	,MiddleName NVARCHAR(50) NOT NULL
	,LastName NVARCHAR(50) NOT NULL
	,JobTitle NVARCHAR(150) NOT NULL
	,DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
	,HireDate DATE
	,Salary MONEY
	,AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

/*--- TASK 18 ---- BASIC INSERT  ------------------------------*/
INSERT INTO Towns VALUES
	 ('Sofia')
	,('Plovdiv')
	,('Varna')
	,('Burgas')

INSERT INTO Departments VALUES
	 ('Engineering')
	,('Sales')
	,('Marketing')
	,('Software Development')
	,('Quality Assurance')

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary ) VALUES
	 ('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00)
	,('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00)
	,('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25)
	,('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00)
	,('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88)

/*--- TASK 19 ---- BASIC SELECT ALL FIELDS  -------------------*/
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

/*--- TASK 20 ---- BASIC SELECT ALL FIELDS AND ORDER THEM  ----*/
SELECT * FROM Towns ORDER BY [Name]
SELECT * FROM Departments ORDER BY [Name]
SELECT * FROM Employees ORDER BY Salary DESC

/*--- TASK 21 ---- BASIC SELECT ALL SOME FIELDS ---------------*/
SELECT [Name] FROM Towns ORDER BY [Name]
SELECT [Name] FROM Departments ORDER BY [Name]
SELECT FirstName, LastName, JobTitle, Salary FROM Employees ORDER BY Salary DESC

/*--- TASK 22 ---- INCREASE EMPLOYEES SALARY ------------------*/
UPDATE Employees
SET Salary = Salary * 1.1

SELECT Salary FROM Employees




