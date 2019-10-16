USE master
GO

/*--- TASK 15 --------- MOVIES DATABASE ----------------------------*/
CREATE DATABASE Hotel
GO

USE Hotel
GO

CREATE TABLE Employees (
	 Id INT CONSTRAINT PK_Employees PRIMARY KEY IDENTITY
	,FirstName NVARCHAR(50) NOT NULL
	,LastName NVARCHAR(50) NOT NULL
	,Title NVARCHAR(50) CONSTRAINT UC_Title UNIQUE NOT NULL
	,Notes NVARCHAR(200)
)

CREATE TABLE Customers (
	 AccountNumber INT CONSTRAINT PK_Customers PRIMARY KEY IDENTITY
	,FirstName NVARCHAR(50) NOT NULL
	,LastName NVARCHAR(50) NOT NULL
	,PhoneNumber NVARCHAR(30)
	,EmergencyName NVARCHAR(50)
	,EmergencyNumber NVARCHAR(50)
	,Notes NVARCHAR(200) 
)

CREATE TABLE RoomStatus (
	 RoomStatus NVARCHAR(50) CONSTRAINT PK_RoomStatus PRIMARY KEY NOT NULL
	,Notes NVARCHAR(200)
)

CREATE TABLE RoomTypes (
	 RoomType NVARCHAR(50) CONSTRAINT PK_RoomTypes PRIMARY KEY NOT NULL
	,Notes NVARCHAR(200)
)

CREATE TABLE BedTypes (
	 BedType NVARCHAR(50) CONSTRAINT PK_BedType PRIMARY KEY NOT NULL
	,Notes NVARCHAR(200)
)

CREATE TABLE Rooms (
	 RoomNumber INT CONSTRAINT PK_Rooms PRIMARY KEY NOT NULL
	,RoomType NVARCHAR(50) CONSTRAINT FK_Rooms_RoomTypes FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL
	,BedType NVARCHAR(50) CONSTRAINT FK_Rooms_BedTypes FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL
	,Rate DECIMAL(6,2) NOT NULL
	,RoomStatus BIT NOT NULL
	,Notes NVARCHAR(200)
)

CREATE TABLE Payments (
	 Id INT CONSTRAINT PK_Payments PRIMARY KEY IDENTITY
	,EmployeeId INT CONSTRAINT FK_Payments_Employees FOREIGN KEY REFERENCES Employees(Id) NOT NULL
	,PaymentDate DATETIME NOT NULL
	,AccountNumber INT CONSTRAINT FK_Payments_Customers FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL
	,FirstDateOccupied DATE NOT NULL
	,LastDateOccupied DATE NOT NULL
	,TotalDays AS DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied)
	,AmountCharged DECIMAL(7, 2) NOT NULL
	,TaxRate DECIMAL(6,2) NOT NULL
	,TaxAmount AS AmountCharged * TaxRate
	,PaymentTotal AS AmountCharged + AmountCharged * TaxRate
	,Notes NVARCHAR(200)
)

CREATE TABLE Occupancies (
	 Id INT CONSTRAINT PK_Occupancies PRIMARY KEY IDENTITY
	,EmployeeId INT CONSTRAINT FK_Occupancies_Employees FOREIGN KEY REFERENCES Employees(Id) NOT NULL
	,DateOccupied DATE NOT NULL
	,AccountNumber INT CONSTRAINT FK_Occupancies_Customers FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL
	,RoomNumber INT CONSTRAINT FK_Occupancies_Rooms FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL
	,RateApplied DECIMAL(7, 2) NOT NULL
	,PhoneCharge DECIMAL(8, 2) NOT NULL
	,Notes NVARCHAR(200)
)

INSERT INTO Employees(FirstName, LastName, Title) VALUES
	('Ivan', 'Ivanov', 'Physicist'),
	('Stoyan', 'Georgiev', 'Biologist'),
	('Petar', 'Stoychev', 'Programmer')

INSERT INTO Customers(FirstName, LastName) VALUES
	('Stoycho', 'Stoychev'),
	('Krasimir', 'Botev'),
	('Gencho', 'Dimitrov')

INSERT INTO RoomStatus(RoomStatus) VALUES
	('Occupied'),
	('Free'),
	('In Repair')

INSERT INTO RoomTypes(RoomType) VALUES
	('Single'),
	('Double'),
	('Appartment')

INSERT INTO BedTypes(BedType) VALUES
	('Single'),
	('Double'),
	('Couch')

INSERT INTO Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus) VALUES
	(2245, 'Single', 'Single', 30.0, 1),
	(2552, 'Double', 'Double', 45.0, 0),
	(5522, 'Appartment', 'Double', 90.0, 1)

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, AmountCharged, TaxRate) VALUES
	(1, '2011-11-25', 1, '2017-11-30', '2017-12-04', 200.0, 0.1),
	(2, '2014-06-03', 2, '2014-06-06', '2014-06-09', 440.0, 0.2),
	(3, '2016-02-25', 3, '2016-02-27', '2016-03-04', 870.0, 0.5)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge) VALUES
	(1, '2011-02-04', 1, 2245, 40.0, 12.54),
	(2, '2015-04-09', 2, 2552, 70.0, 11.22),
	(3, '2012-06-08', 3, 5522, 110.0, 10.05)

/*--- TASK 23 --------- DECREASE TAX RATE --------------------------*/
UPDATE Payments
SET TaxRate -= TaxRate * 0.03

SELECT TaxRate FROM Payments

/*--- TASK 24 --------- DELETE ALL RECORDS -------------------------*/
TRUNCATE TABLE Occupancies

