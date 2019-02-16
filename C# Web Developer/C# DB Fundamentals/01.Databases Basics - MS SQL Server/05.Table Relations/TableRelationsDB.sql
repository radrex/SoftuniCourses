/*---------------------- EXERCISE -----------------------*/
CREATE DATABASE TableRelationsDB
USE TableRelationsDB

/*--- TASK 1 --- ONE-TO-ONE RELATIONSHIP ----------------*/
CREATE TABLE Persons (
	 PersonID INT IDENTITY NOT NULL
	,FirstName VARCHAR(100) NOT NULL
	,Salary DECIMAL(15, 2)
	,PassportID INT NOT NULL
)

CREATE TABLE Passports (
	 PassportID INT IDENTITY(101, 1) NOT NULL
	,PassportNumber VARCHAR(50) NOT NULL
)

INSERT INTO Persons VALUES
	 ('Roberto', 43300, 102)
	,('Tom', 56100, 103)
	,('Yana', 60200, 101)

INSERT INTO Passports VALUES
	 ('N34FG21B')
	,('K65LO4R7')
	,('ZE657QP2')

ALTER TABLE Persons
ADD PRIMARY KEY (PersonID)

ALTER TABLE Passports
ADD PRIMARY KEY (PassportID)

ALTER TABLE Persons
ADD FOREIGN KEY (PassportID) REFERENCES Passports(PassportID)

/*--- TASK 2 --- ONE-TO-MANY RELATIONSHIP ---------------*/
CREATE TABLE Manufacturers (
	 ManufacturerID INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
	,EstablishedOn DATE
)

CREATE TABLE Models (
	 ModelID INT PRIMARY KEY IDENTITY(101, 1)
	,[Name] VARCHAR(50) NOT NULL
	,ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers VALUES
	 ('BMW', '1916-03-07')
	,('Tesla', '2003-01-01')
	,('Lada', '1966-05-01')

INSERT INTO Models VALUES
	 ('X1', 1)
	,('i6', 1)
	,('Model S', 2)
	,('Model X', 2)
	,('Model 3', 2)
	,('Nova', 3)

/*--- TASK 3 --- MANY-TO-MANY RELATIONSHIP --------------*/
CREATE TABLE Students (
	 StudentID INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Exams (
	 ExamID INT PRIMARY KEY IDENTITY(101, 1)
	,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams (
	 StudentID INT FOREIGN KEY REFERENCES Students(StudentID) NOT NULL
	,ExamID INT FOREIGN KEY REFERENCES Exams(ExamID) NOT NULL
	,CONSTRAINT PK_Students_Exams PRIMARY KEY(StudentID, ExamID)
)

INSERT INTO Students VALUES
	 ('Mila')
	,('Toni')
	,('Ron')

INSERT INTO Exams VALUES
	 ('SpringMVC')
	,('Neo4j')
	,('Oracle 11g')

INSERT INTO StudentsExams VALUES
	 (1, 101)
	,(1, 102)
	,(2, 101)
	,(3, 103)
	,(2, 102)
	,(2, 103)

/*--- TASK 4 --- SELF-REFERENCING -----------------------*/
CREATE TABLE Teachers (
	TeacherID INT PRIMARY KEY IDENTITY(101, 1)
	,[Name] VARCHAR(50) NOT NULL
	,ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers VALUES
	 ('John', NULL)
	,('Maya', NULL)
	,('Silvia', NULL)
	,('Ted', NULL)
	,('Mark', 101)
	,('Greta', 101)

UPDATE Teachers
SET ManagerID = 106
WHERE TeacherID IN (102, 103)

UPDATE Teachers
SET ManagerID = 105
WHERE TeacherID = 104


