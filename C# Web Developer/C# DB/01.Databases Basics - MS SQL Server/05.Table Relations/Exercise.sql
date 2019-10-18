/*--- TASK 1 --------- ONE-TO-ONE RELATIONSHIP --------------------*/
CREATE DATABASE TableRelationsDB
GO

USE TableRelationsDB
GO

CREATE TABLE Persons (
    PersonID INT IDENTITY NOT NULL
   ,FirstName NVARCHAR(50)
   ,Salary DECIMAL(15, 2)
   ,PassportID INT NOT NULL
)

CREATE TABLE Passports (
     PassportID INT IDENTITY(101, 1) NOT NULL
    ,PassportNumber NVARCHAR(8) CONSTRAINT CC_PassportLength CHECK (LEN(PassportNumber) = 8) NOT NULL
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
ADD CONSTRAINT PK_Persons PRIMARY KEY (PersonID)

ALTER TABLE Passports
ADD CONSTRAINT PK_Passports PRIMARY KEY (PassportID)

ALTER TABLE Persons
ADD CONSTRAINT FK_Persons_Passports FOREIGN KEY (PassportID) REFERENCES Passports(PassportID)

/*--- TASK 2 --------- ONE-TO-MANY RELATIONSHIP -------------------*/
CREATE TABLE Manufacturers (
     ManufacturerID INT CONSTRAINT PK_Manufacturers PRIMARY KEY IDENTITY NOT NULL
	,[Name] NVARCHAR(20) NOT NULL
	,EstablishedOn DATE NOT NULL
)

CREATE TABLE Models (
     ModelID INT CONSTRAINT PK_Models PRIMARY KEY IDENTITY(101, 1) NOT NULL
	,[Name] NVARCHAR(20) NOT NULL
	,ManufacturerID INT CONSTRAINT FK_Models_Manufacturers FOREIGN KEY REFERENCES Manufacturers(ManufacturerID) NOT NULL
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

/*--- TASK 3 --------- MANY-TO-MANY RELATIONSHIP ------------------*/
CREATE TABLE Students (
     StudentID INT CONSTRAINT PK_Students PRIMARY KEY IDENTITY NOT NULL
    ,[Name] NVARCHAR(20) NOT NULL
)

CREATE TABLE Exams (
     ExamID INT CONSTRAINT PK_Exams PRIMARY KEY IDENTITY(101, 1) NOT NULL
	,[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams (
     StudentID INT CONSTRAINT FK_StudentsExams_Students FOREIGN KEY REFERENCES Students(StudentID) NOT NULL
	,ExamID INT CONSTRAINT FK_StudentsExams_Exams FOREIGN KEY REFERENCES Exams(ExamID) NOT NULL
	,CONSTRAINT PK_StudentsExams PRIMARY KEY(StudentID, ExamID)
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

/*--- TASK 4 --------- SELF-REFERENCING ---------------------------*/
CREATE TABLE Teachers (
     TeacherID INT CONSTRAINT PK_Teachers PRIMARY KEY IDENTITY(101, 1)
	,[Name] NVARCHAR(20) NOT NULL
	,ManagerID INT CONSTRAINT FK_Teachers FOREIGN KEY REFERENCES Teachers(TeacherID)
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

/*--- TASK 5 --------- ONLINE STORE DATABASE ----------------------*/
CREATE DATABASE OnlineStoreDB
GO

USE OnlineStoreDB
GO

CREATE TABLE Cities (
     CityID INT CONSTRAINT PK_Cities PRIMARY KEY IDENTITY NOT NULL
	,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Customers (
     CustomerID INT CONSTRAINT PK_Customers PRIMARY KEY IDENTITY NOT NULL
    ,[Name] VARCHAR(50) NOT NULL
	,Birthday DATE NOT NULL
	,CityID INT CONSTRAINT FK_Customers_Cities FOREIGN KEY REFERENCES Cities(CityID) NOT NULL
)

CREATE TABLE Orders (
     OrderID INT CONSTRAINT PK_Orders PRIMARY KEY IDENTITY NOT NULL
	,CustomerID INT CONSTRAINT FK_Orders_Customers FOREIGN KEY REFERENCES Customers(CustomerID) NOT NULL
)

CREATE TABLE ItemTypes (
     ItemTypeID INT CONSTRAINT PK_ItemTypes PRIMARY KEY IDENTITY NOT NULL
	,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Items (
     ItemID INT CONSTRAINT PK_Items PRIMARY KEY IDENTITY NOT NULL
	,[Name] VARCHAR(50) NOT NULL
	,ItemTypeID INT CONSTRAINT FK_Items_ItemTypes FOREIGN KEY REFERENCES ItemTypes(ItemTypeID) NOT NULL
)

CREATE TABLE OrderItems (
     OrderID INT CONSTRAINT FK_OrderItems_Orders FOREIGN KEY REFERENCES Orders(OrderID) NOT NULL
	,ItemID INT CONSTRAINT FK_OrderItems_Items FOREIGN KEY REFERENCES Items(ItemID) NOT NULL
	,CONSTRAINT PK_OrderItems PRIMARY KEY(OrderID, ItemID)
)

/*--- TASK 6 --------- UNIVERSITY DATABASE ------------------------*/
CREATE DATABASE UniversityDB
GO

USE UniversityDB
GO

CREATE TABLE Majors (
     MajorID INT CONSTRAINT PK_Majors PRIMARY KEY IDENTITY NOT NULL
	,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Students (
     StudentID INT CONSTRAINT PK_Students PRIMARY KEY IDENTITY NOT NULL
	,StudentNumber VARCHAR(15) NOT NULL
	,StudentName VARCHAR(50) NOT NULL
	,MajorID INT CONSTRAINT FK_Students_Majors FOREIGN KEY REFERENCES Majors(MajorID) NOT NULL
)

CREATE TABLE Payments (
     PaymentID INT CONSTRAINT PK_Payments PRIMARY KEY IDENTITY NOT NULL
	,PaymentDate DATE NOT NULL
	,PaymentAmount DECIMAL(15,2) NOT NULL
	,StudentID INT CONSTRAINT FK_Payments_Students FOREIGN KEY REFERENCES Students(StudentID) NOT NULL
)

CREATE TABLE Subjects (
     SubjectID INT CONSTRAINT PK_Subjects PRIMARY KEY IDENTITY NOT NULL
	,SubjectName VARCHAR(50) NOT NULL
)

CREATE TABLE Agenda (
     StudentID INT CONSTRAINT FK_Agenda_Students FOREIGN KEY REFERENCES Students(StudentID) NOT NULL
	,SubjectID INT CONSTRAINT FK_Agenda_Subjects FOREIGN KEY REFERENCES Subjects(SubjectID) NOT NULL
	,CONSTRAINT PK_Agenda PRIMARY KEY(StudentID, SubjectID)
)

/*--- TASK 7 --------- SOFTUNI DESIGN -----------------------------*/
/*--- TASK 8 --------- GEOGRAPHY DESIGN ---------------------------*/

/*--- TASK 9 --------- PEAKS IN RILA ------------------------------*/
USE [Geography]

SELECT m.MountainRange
      ,p.PeakName
      ,p.Elevation 
FROM Mountains AS m
JOIN Peaks AS p ON p.MountainId = m.Id
WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC
