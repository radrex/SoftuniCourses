USE master
GO

/*--- TASK 1 --------- CREATE DATABASE ----------------------------*/
CREATE DATABASE Minions
GO

USE Minions
GO

/*--- TASK 2 --------- CREATE TABLES ------------------------------*/
CREATE TABLE Minions (
	 Id INT NOT NULL
	,[Name] NVARCHAR(50) NOT NULL
	,Age INT
)

ALTER TABLE Minions
ADD CONSTRAINT PK_Minions PRIMARY KEY(Id)

CREATE TABLE Towns (
	 Id INT CONSTRAINT PK_Town PRIMARY KEY
	,[Name] NVARCHAR(50) NOT NULL
)

/*--- TASK 3 --------- ALTER MINIONS TABLE ------------------------*/
ALTER TABLE Minions
ADD TownId INT CONSTRAINT FK_Minions_Towns FOREIGN KEY REFERENCES Towns(Id) NOT NULL

/*--- TASK 4 --------- INSERT RECORDS IN BOTH TABLES  -------------*/
INSERT INTO Towns (Id, [Name]) VALUES
	 (1, 'Sofia')
	,(2, 'Plovdiv')
	,(3, 'Varna')


INSERT INTO Minions (Id, [Name], Age, TownId) VALUES
	 (1, 'Kevin', 22, 1)
	,(2, 'Bob', 15, 3)
	,(3, 'Steward', NULL, 2)

/*--- TASK 5 --------- TRUNCATE TABLE MINIONS  --------------------*/
TRUNCATE TABLE Minions

/*--- TASK 6 --------- DROP ALL TABLES  ---------------------------*/
DROP TABLE Minions
DROP TABLE Towns

/*--- TASK 7 --------- CREATE TABLE PEOPLE  -----------------------*/
CREATE TABLE People (
	 Id INT CONSTRAINT PK_People PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(200) NOT NULL
	,Picture VARBINARY(MAX) CHECK (DATALENGTH(Picture) > 1024 * 1024 * 2)
	,Height DECIMAL(3,2)
	,[Weight] DECIMAL(5,2)
	,Gender CHAR(1) CHECK (Gender = 'm' OR Gender = 'f') NOT NULL
	,Birthdate DATE NOT NULL
	,Biography NVARCHAR(MAX)
)

INSERT INTO People ([Name], Height, [Weight], Gender, Birthdate) VALUES
	 ('Ivan Ivanov', 1.80, 72.23, 'm', '1995/04/02')
	,('Georgi Ivanov', 1.70, 62.83, 'm', '1993/06/07')
	,('Stoyan Stoychev', 1.75, 72.23, 'm', '1991/09/21')
	,('Dobromira Stoyanova', 1.65, 52.32, 'f', '1995/11/23')
	,('Kristiyan Dimitrov', 1.88, 80.98, 'm', '1991/10/18')

/*--- TASK 8 --------- CREATE TABLE USERS  ------------------------*/
CREATE TABLE Users (
	 Id INT CONSTRAINT PK_Users PRIMARY KEY IDENTITY
	,Username VARCHAR(30) CONSTRAINT UC_Username UNIQUE NOT NULL
	,[Password] VARCHAR(26) NOT NULL
	,ProfilePicture VARBINARY(MAX) CHECK (DATALENGTH(ProfilePicture) <= 900 * 1024)
	,LastLoginTime DATETIME
	,IsDeleted BIT NOT NULL
)

INSERT INTO Users (Username, [Password], IsDeleted) VALUES
	 ('ivan20', 'wlafjalsf2', 0)
	,('georgiev', 'kojfasi2', 1)
	,('stoych4', 'asfasf2441', 0)
	,('unknown', 'fhasfo1', 0)
	,('thecollector', 'asfasfo145', 1)

/*--- TASK 9 --------- CHANGE PRIMARY KEY  ------------------------*/
ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT PK_User PRIMARY KEY(Id, Username)

/*--- TASK 10 -------- ADD CHECK CONSTRAINT  ----------------------*/
ALTER TABLE Users
ADD CONSTRAINT PasswordLength CHECK (LEN([Password]) >= 5)

/*--- TASK 11 -------- SET DEFAULT VALUE OF FIELD  ----------------*/
ALTER TABLE Users
ADD DEFAULT GETDATE() FOR LastLoginTime

/*--- TASK 12 -------- SET UNIQUE FIELD  --------------------------*/
ALTER TABLE Users
DROP CONSTRAINT PK_User

ALTER TABLE Users
DROP CONSTRAINT UC_Username

ALTER TABLE Users
ADD CONSTRAINT PK_User PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT UC_Username UNIQUE(Username)

ALTER TABLE Users
ADD CONSTRAINT UsernameLength CHECK (LEN(Username) >= 3)