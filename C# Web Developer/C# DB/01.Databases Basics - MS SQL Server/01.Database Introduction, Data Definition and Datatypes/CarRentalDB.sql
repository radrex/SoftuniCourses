USE master
GO

/*--- TASK 14 --------- CAR RENTAL DATABASE ------------------------*/
CREATE DATABASE CarRental
GO

USE CarRental
GO

CREATE TABLE Categories (
	 Id INT CONSTRAINT PK_Categories PRIMARY KEY IDENTITY
	,CategoryName NVARCHAR(50) CONSTRAINT UC_Category UNIQUE NOT NULL
	,DailyRate INT
	,WeeklyRate INT
	,MonthlyRate INT
	,WeekendRate INT
)

CREATE TABLE Cars (
	 Id INT CONSTRAINT PK_Cars PRIMARY KEY IDENTITY
	,PlateNumber NVARCHAR(10) CONSTRAINT UC_PlateNumber UNIQUE NOT NULL
	,Manufacturer NVARCHAR(50) NOT NULL
	,Model NVARCHAR(50) NOT NULL
	,CarYear INT NOT NULL
	,CategoryId INT CONSTRAINT FK_Cars_Categories FOREIGN KEY REFERENCES Categories(Id) NOT NULL
	,Doors INT NOT NULL
	,Picture VARBINARY(MAX)
	,Condition NVARCHAR(50)
	,Available BIT NOT NULL
)

CREATE TABLE Employees (
	 Id INT CONSTRAINT PK_Employees PRIMARY KEY IDENTITY
	,FirstName NVARCHAR(30) NOT NULL
	,LastName NVARCHAR(30) NOT NULL
	,Title NVARCHAR(30)
	,Notes NVARCHAR(200)
)

CREATE TABLE Customers (
	 Id INT CONSTRAINT PK_Customers PRIMARY KEY IDENTITY
	,DriverLicenceNumber NVARCHAR(20) CONSTRAINT UC_DriverLicenceNumber UNIQUE NOT NULL
	,FullName NVARCHAR(100) NOT NULL
	,[Address] NVARCHAR(250) NOT NULL
	,City NVARCHAR(50) NOT NULL
	,ZIPCode NVARCHAR(30) NOT NULL
	,Notes NVARCHAR(200)
)

CREATE TABLE RentalOrders (
	 Id INT CONSTRAINT PK_RentalOrders PRIMARY KEY IDENTITY
	,EmployeeId INT CONSTRAINT FK_RentalOrders_Employees FOREIGN KEY REFERENCES Employees(Id) NOT NULL
	,CustomerId INT CONSTRAINT FK_RentalOrders_Customers FOREIGN KEY REFERENCES Customers(Id) NOT NULL
	,CarId INT CONSTRAINT FK_RentalOrders_Cars FOREIGN KEY REFERENCES Cars(Id) NOT NULL
	,TankLevel INT NOT NULL
	,KilometrageStart INT NOT NULL
	,KilometrageEnd INT NOT NULL
	,TotalKilometrage AS KilometrageEnd - KilometrageStart
	,StartDate DATE NOT NULL
	,EndDate DATE NOT NULL
	,TotalDays AS DATEDIFF(DAY, StartDate, EndDate)
	,RateApplied INT NOT NULL
	,TaxRate AS RateApplied * 0.2
	,OrderStatus BIT NOT NULL
	,Notes NVARCHAR(200)
)

INSERT INTO Categories (CategoryName) VALUES
	 ('Grand tourer')
	,('Roadster')
	,('SUV')

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Available) VALUES
	 ('CA1234KP', 'Aston Martin Lagonda Limited', 'Aston Martin DB9', 2004, 1, 2, 1)
	,('CA567KP', 'BMW', 'BMW Z', 2018, 2, 2, 0)
	,('CA8910KP', 'Honda', 'Honda CR-V', 2015, 2, 5, 1)

INSERT INTO Employees (FirstName, LastName) VALUES
	 ('Ivan', 'Ivanov')
	,('Georgi', 'Stoyanov')
	,('Iliyan', 'Angelov')

INSERT INTO Customers (DriverLicenceNumber, FullName, [Address], City, ZIPCode) VALUES
	 ('1351363612', 'Martin Georgiev', 'Pirotska 4', 'Sofia', '1000')
	,('2155125125', 'Dimcho Ivanov', 'Vasil Levski 37', 'Shumen', '9700')
	,('2353515151', 'Lazar Lazarov', 'Yane Sandanski 5', 'Sandanski', '2800')

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, StartDate, EndDate, RateApplied, OrderStatus) VALUES
	 (1, 1, 3, 70, 12400, 40153, '2018-02-10', '2018-08-10', 250, 1)
	,(2, 2, 2, 60, 120000, 150245, '2018-09-18', '2018-10-24', 1500, 0)
	,(3, 3, 1, 50, 28268, 30001, '2018-05-08', '2018-06-01', 850, 0)