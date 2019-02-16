/*---------------------- EXERCISE -----------------------*/
CREATE DATABASE UniversityDB
USE UniversityDB

/*--- TASK 6 --- UNIVERSITY DATABASE --------------------*/
CREATE TABLE Majors (
	 MajorID INT PRIMARY KEY NOT NULL
	,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Students (
	 StudentID INT PRIMARY KEY NOT NULL
	,StudentNumber VARCHAR(15) NOT NULL
	,StudentName VARCHAR(50) NOT NULL
	,MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Payments (
	 PaymentID INT PRIMARY KEY NOT NULL
	,PaymentDate DATETIME NOT NULL
	,PaymentAmount DECIMAL(6, 2) NOT NULL
	,StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)

CREATE TABLE Subjects (
	 SubjectID INT PRIMARY KEY NOT NULL
	,SubjectName VARCHAR(35) NOT NULL
)

CREATE TABLE Agenda (
	 StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
	,SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID)
	,CONSTRAINT PK_Agenda PRIMARY KEY (StudentID, SubjectID)
)


