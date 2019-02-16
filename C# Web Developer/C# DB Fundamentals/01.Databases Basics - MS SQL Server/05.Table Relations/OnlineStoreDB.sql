/*---------------------- EXERCISE -----------------------*/
CREATE DATABASE OnlineStoreDB
USE OnlineStoreDB

/*--- TASK 5 --- ONLINE STORE DATABASE ------------------*/
CREATE TABLE Cities (
	 CityID INT PRIMARY KEY NOT NULL
	,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Customers (
	 CustomerID INT PRIMARY KEY NOT NULL
	,[Name] VARCHAR(50) NOT NULL
	,Birthday DATE
	,CityID INT FOREIGN KEY REFERENCES Cities(CityID) NOT NULL
)

CREATE TABLE Orders (
	 OrderID INT PRIMARY KEY NOT NULL
	,CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID) NOT NULL
)

CREATE TABLE ItemTypes (
	 ItemTypeID INT PRIMARY KEY NOT NULL
	,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Items (
	 ItemID INT PRIMARY KEY NOT NULL
	,[Name] VARCHAR(50) NOT NULL
	,ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID) NOT NULL
)

CREATE TABLE OrderItems (
	 OrderID INT FOREIGN KEY REFERENCES Orders(OrderID) NOT NULL
	,ItemID INT FOREIGN KEY REFERENCES Items(ItemID) NOT NULL
	,CONSTRAINT PK_Order_Items PRIMARY KEY (OrderID, ItemID)
)