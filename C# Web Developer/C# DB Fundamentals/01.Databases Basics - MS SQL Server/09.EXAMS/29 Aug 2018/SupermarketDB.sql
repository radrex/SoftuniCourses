/*-------------------------------------------------------------------------------*/
/*--------------------------- SECTION 1 --- DDL ---------------------------------*/
/*-------------------------------------------------------------------------------*/
CREATE DATABASE Supermarket
USE Supermarket

/*--- TASK 1 ---- DATABASE DESIGN -----------*/
/*-------- CATEGORIES --------*/
CREATE TABLE Categories (
	 Id INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(30) NOT NULL
)
/*---------- ITEMS -----------*/
CREATE TABLE Items (
	 Id INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(30) NOT NULL
	,Price DECIMAL(15, 2) NOT NULL
	,CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
)
/*-------- EMPLOYEES ---------*/
CREATE TABLE Employees (
	 Id INT PRIMARY KEY IDENTITY
	,FirstName NVARCHAR(50) NOT NULL
	,LastName NVARCHAR(50) NOT NULL
	,Phone CHAR(12) NOT NULL
	,CONSTRAINT CHK_Phone CHECK(LEN(Phone) = 12)
	,Salary DECIMAL(15, 2) NOT NULL
)
/*---------- ORDERS ----------*/
CREATE TABLE Orders (
	 Id INT PRIMARY KEY IDENTITY
	,[DateTime] DATETIME NOT NULL
	,EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

/*---------- ORDER ITEMS -----*/
CREATE TABLE OrderItems (
	 OrderId INT FOREIGN KEY REFERENCES Orders(Id) NOT NULL
	,ItemId INT FOREIGN KEY REFERENCES Items(Id) NOT NULL
	,CONSTRAINT CK_Orders_Items PRIMARY KEY(OrderId, ItemId)
	,Quantity INT NOT NULL
	,CONSTRAINT CHK_Quantity CHECK(Quantity >= 1)
)
/*---------- SHIFTS ----------*/
CREATE TABLE Shifts (
	 Id INT IDENTITY
	,EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
	,CONSTRAINT CK_Employees PRIMARY KEY(Id, EmployeeId)
	,CheckIn DATETIME NOT NULL
	,CheckOut DATETIME NOT NULL
	,CONSTRAINT CHK_CheckOut CHECK(CheckOut > CheckIn)
)

/*-------------------------------------------------------------------------------*/
/*--------------------------- SECTION 2 --- DML ---------------------------------*/
/*-------------------------------------------------------------------------------*/

-- IMPORT DATA SET

/*--- TASK 2 --------- INSERT ---------------*/
INSERT INTO Employees VALUES
	 ('Stoyan', 'Petrov', '888-785-8573', 500.25)
	,('Stamat', 'Nikolov', '789-613-1122', 999995.25)
	,('Evgeni', 'Petkov', '645-369-9517', 1234.51)
	,('Krasimir', 'Vidolov', '321-471-9982', 50.25)

INSERT INTO Items VALUES
	 ('Tesla battery', 154.25, 8)
	,('Chess', 30.25, 8)
	,('Juice', 5.32, 1)
	,('Glasses', 10, 8)
	,('Bottle of water', 1, 1)

/*--- TASK 3 --------- UPDATE ---------------*/
UPDATE Items
SET Price *= 1.27
WHERE CategoryId IN(1, 2, 3)

/*--- TASK 4 --------- DELETE ---------------*/
DELETE
FROM OrderItems
WHERE OrderId = 48

DELETE
FROM Orders
WHERE Id = 48

/*-------------------------------------------------------------------------------*/
/*--------------------------- SECTION 3 --- QUERYING ----------------------------*/
/*-------------------------------------------------------------------------------*/

-- RECREATE DB AND IMPORT DATA SET AGAIN

/*--- TASK 5 --------- RICHEST PEOPLE ---------------*/
SELECT Id
	  ,FirstName
FROM Employees
WHERE Salary > 6500
ORDER BY FirstName, Id

/*--- TASK 6 ------- COOL PHONE NUMBERS -------------*/
SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name]
	  ,Phone
FROM Employees
WHERE Phone LIKE '3%'
ORDER BY FirstName ASC, Phone ASC

/*--- TASK 7 ------- EMPLOYEE STATISTICS ------------*/
SELECT e.FirstName	
      ,e.LastName
	  ,COUNT(o.Id) AS [Count]
FROM Employees AS e
JOIN Orders AS o ON o.EmployeeId = e.Id
GROUP BY e.FirstName, e.LastName
ORDER BY COUNT(o.Id) DESC, e.FirstName

/*--- TASK 8 ------- HARD WORKERS CLUB --------------*/
SELECT HardWorkers.FirstName
	  ,HardWorkers.LastName
	  ,HardWorkers.[Work Hours]
FROM
	(
		SELECT e.Id
		      ,e.FirstName
			  ,e.LastName
			  ,AVG(DATEDIFF(HOUR, s.CheckIn, s.CheckOut)) AS [Work Hours]
		FROM Employees AS e
		JOIN Shifts AS s ON s.EmployeeId = e.Id
		GROUP BY e.Id, e.FirstName, e.LastName
	) AS HardWorkers

WHERE [Work Hours] > 7
ORDER BY HardWorkers.[Work Hours] DESC, HardWorkers.Id

/*--- SECOND OPTION ---*/
SELECT e.FirstName
	  ,e.LastName
	  ,AVG(DATEDIFF(HOUR, s.CheckIn, s.CheckOut)) AS [Work Hours]
FROM Employees AS e
JOIN Shifts AS s ON s.EmployeeId = e.Id
GROUP BY e.Id, e.FirstName, e.LastName
HAVING AVG(DATEDIFF(HOUR, s.CheckIn, s.CheckOut)) > 7
ORDER BY [Work Hours] DESC, e.Id

/*--- TASK 9 ------- THE MOST EXPENSIVE ORDER -------*/
SELECT TOP(1) oi.OrderId
			 ,SUM(oi.Quantity * i.Price) AS [Total Price]
FROM OrderItems AS oi
JOIN Items i ON i.Id = oi.ItemId
GROUP BY oi.OrderId
ORDER BY [Total Price] DESC

/*--- TASK 10 ------- RICH ITEM, POOR ITEM ----------*/
SELECT TOP(10) oi.OrderId
			  ,MAX(i.Price) AS ExpensivePrice
			  ,MIN(i.Price) AS CheapPrice
FROM OrderItems AS oi
JOIN Items i ON i.Id = oi.ItemId
GROUP BY oi.OrderId
ORDER BY ExpensivePrice DESC, oi.OrderId ASC

/*--- TASK 11 ------- CASHIERS ----------------------*/
SELECT DISTINCT e.Id
			   ,e.FirstName AS [First Name]
			   ,e.LastName AS [Last Name]
FROM Employees AS e
LEFT JOIN Orders AS o ON o.EmployeeId = e.Id
WHERE o.Id IS NOT NULL
ORDER BY e.Id

/*--- TASK 12 ------- LAZY EMPLOYEES ----------------*/
SELECT DISTINCT e.Id
			   ,CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name]
FROM Employees AS e
JOIN Shifts AS s ON s.EmployeeId = e.Id
WHERE DATEDIFF(HOUR, s.CheckIn, s.CheckOut) < 4
ORDER BY e.Id

/*--- TASK 13 ------- SELLERS -----------------------*/
SELECT TOP(10) CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name]
			  ,SUM(oi.Quantity * i.Price) AS [Total Price]
			  ,SUM(oi.Quantity) AS [Items]
FROM Employees AS e
JOIN Orders AS o ON o.EmployeeId = e.Id
JOIN OrderItems AS oi ON oi.OrderId = o.Id
JOIN Items AS i ON i.Id = oi.ItemId
WHERE o.[DateTime] < '20180615'
GROUP BY e.FirstName, e.LastName
ORDER BY [Total Price] DESC, [Items] DESC

/*--- TASK 14 ------- TOUGH DAYS --------------------*/
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name]
	  ,DATENAME(WEEKDAY, s.CheckIn) AS [Day of week]
FROM Employees AS e
LEFT JOIN Orders AS o ON o.EmployeeId = e.Id
LEFT JOIN Shifts AS s ON s.EmployeeId = e.Id
WHERE o.Id IS NULL AND DATEDIFF(HOUR, s.CheckIn, s.CheckOut) > 12
ORDER BY e.Id

/*--- TASK 15 ------- TOP ORDER PER EMPLOYEE --------*/
SELECT k.[Full Name]
	  ,DATEDIFF(HOUR, s.CheckIn, s.CheckOut) AS WorkHours
	  ,k.TotalSum
FROM
	(
		SELECT o.Id AS OrderId
			  ,e.Id AS EmployeeId
			  ,o.[DateTime]
			  ,CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name]
			  ,SUM(oi.Quantity * i.Price) AS TotalSum
			  ,ROW_NUMBER() OVER (PARTITION BY e.Id ORDER BY SUM(oi.Quantity * i.Price) DESC) AS  RowNumber
		FROM Employees AS e
		JOIN Orders AS o ON o.EmployeeId = e.Id
		JOIN OrderItems AS oi ON oi.OrderId = o.Id
		JOIN Items AS i ON i.Id = oi.ItemId
		GROUP BY o.Id, e.FirstName, e.LastName, e.Id, o.[DateTime]

	) AS k
JOIN Shifts AS s ON s.EmployeeId = k.EmployeeId
WHERE k.RowNumber = 1 AND k.[DateTime] BETWEEN s.CheckIn AND s.CheckOut
ORDER BY k.[Full Name],WorkHours DESC, k.TotalSum DESC

/*--- TASK 16 ------- AVERAGE PROFIT PER DAY --------*/
SELECT DATEPART(DAY, o.[DateTime]) AS [DayOfMonth]
	  ,FORMAT(AVG(oi.Quantity * i.Price), 'N2') AS AveragePrice
FROM Orders AS o
JOIN OrderItems AS oi ON oi.OrderId = o.Id
JOIN Items AS i ON i.Id = oi.ItemId
GROUP BY DATEPART(DAY, o.[DateTime])
ORDER BY [DayOfMonth]

/*--- TASK 17 ------- TOP PRODUCTS ------------------*/
SELECT i.[Name] AS Item
	  ,c.[Name] AS Category
	  ,SUM(oi.Quantity) AS [Count]
	  ,SUM(oi.Quantity * i.Price) AS TotalPrice
FROM Items AS i
JOIN Categories AS c ON c.Id = i.CategoryId
LEFT JOIN OrderItems AS oi ON oi.ItemId = i.Id
GROUP BY i.[Name], c.[Name]
ORDER BY TotalPrice DESC, [Count] DESC


/*-------------------------------------------------------------------------------*/
/*--------------------------- SECTION 4 --- PROGRAMMABILITY ---------------------*/
/*-------------------------------------------------------------------------------*/

/*--- TASK 18 ------- PROMOTION DAYS ----------------*/
CREATE FUNCTION udf_GetPromotedProducts (@CurrentDate DATETIME, @StartDate DATETIME, @EndDate DATETIME, @Discount DECIMAL(15, 2), @FirstItemId INT, @SecondItemId INT, @ThirdItemId INT)
RETURNS NVARCHAR(MAX)
AS
	BEGIN
	/*-------------------- VARIABLES -------------------------------------------------------*/
		DECLARE @firstItemName NVARCHAR(MAX) = (SELECT [Name] FROM Items WHERE Id = @FirstItemId)
		DECLARE @firstItemPrice DECIMAL(15, 2) = (SELECT Price FROM Items WHERE Id = @FirstItemId)

		DECLARE @secondItemName NVARCHAR(MAX) = (SELECT [Name] FROM Items WHERE Id = @SecondItemId)
		DECLARE @secondItemPrice DECIMAL(15, 2) = (SELECT Price FROM Items WHERE Id = @SecondItemId)

		DECLARE @thirdItemName NVARCHAR(MAX) = (SELECT [Name] FROM Items WHERE Id = @ThirdItemId)
		DECLARE @thirdItemPrice DECIMAL(15, 2) = (SELECT Price FROM Items WHERE Id = @ThirdItemId)
	/*-------------------- IF CHECKS -------------------------------------------------------*/
		IF(@firstItemName IS NULL OR @secondItemName IS NULL OR @thirdItemName IS NULL)
		BEGIN
			RETURN 'One of the items does not exists!'
		END
		
		IF(@CurrentDate NOT BETWEEN @StartDate AND @EndDate)
		BEGIN
			RETURN 'The current date is not within the promotion dates!'
		END
	/*-------------------- IF BOTH CONDITIONS ARE TRUE MAKE DISCOUNT -----------------------*/
		SET @firstItemPrice = @firstItemPrice - (@firstItemPrice * (@Discount / 100))
		SET @secondItemPrice = @secondItemPrice - (@secondItemPrice * (@Discount / 100))
		SET @thirdItemPrice = @thirdItemPrice - (@thirdItemPrice * (@Discount / 100))

		RETURN @firstItemName  + ' price: ' + CAST(@firstItemPrice AS NVARCHAR(MAX)) +  ' <-> ' +
			   @secondItemName + ' price: ' + CAST(@secondItemPrice AS NVARCHAR(MAX)) +  ' <-> ' +
			   @thirdItemName  + ' price: ' + CAST(@thirdItemPrice AS NVARCHAR(MAX))
	
			
	END
	
SELECT dbo.udf_GetPromotedProducts('2018-08-02', '2018-08-01', '2018-08-03',13, 3,4,5)
SELECT dbo.udf_GetPromotedProducts('2018-08-01', '2018-08-02', '2018-08-03',13,3 ,4,5)

/*--- TASK 19 ------- CANCEL ORDER ------------------*/
CREATE PROC usp_CancelOrder(@OrderId INT, @CancelDate DATETIME)
AS
	DECLARE @targetOrder INT = (SELECT Id FROM Orders WHERE Id = @OrderId)
	DECLARE @orderDateTime DATETIME = (SELECT [DateTime] FROM Orders WHERE Id = @OrderId)

	IF(@targetOrder IS NULL)
	BEGIN
		RAISERROR('The order does not exist!', 16, 1)
		RETURN
	END

	IF(DATEDIFF(DAY, @orderDateTime, @CancelDate) > 3)
	BEGIN
		RAISERROR('You cannot cancel the order!', 16, 2)
		RETURN
	END

DELETE FROM OrderItems
WHERE OrderId = @OrderId

DELETE FROM Orders
WHERE Id = @OrderId

EXEC usp_CancelOrder 1, '2018-06-02'
SELECT COUNT(*) FROM Orders
SELECT COUNT(*) FROM OrderItems

EXEC usp_CancelOrder 1, '2018-06-15'

EXEC usp_CancelOrder 124231, '2018-06-15'

/*--- TASK 20 ------- DELETED ORDERS ----------------*/
CREATE TRIGGER tr_DeletedOrders ON OrderItems AFTER DELETE
AS
	INSERT INTO DeletedOrders(ItemId, OrderId, ItemQuantity)
	SELECT ItemId, OrderId, Quantity FROM deleted

	DELETE FROM OrderItems
	WHERE OrderId = 5

	DELETE FROM Orders
	WHERE Id = 5