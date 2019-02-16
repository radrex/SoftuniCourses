CREATE DATABASE Orders;
GO

USE Orders;
GO
CREATE TABLE Orders
(
Id INT NOT NULL,
ProductName VARCHAR(50) NOT NULL,
OrderDate DATETIME NOT NULL
CONSTRAINT PK_Orders PRIMARY KEY (Id)
)

INSERT INTO Orders (Id, ProductName, OrderDate) VALUES 
	 (1, 'Butter', '20160919')
	,(2, 'Milk', '20160930')
	,(3, 'Cheese', '20160904')
	,(4, 'Bread', '20151220')
	,(5, 'Tomatoes', '20150101')
	,(6, 'Tomatoe2', '20150201')
	,(7, 'Tomatoess', '20150401')
	,(8, 'Tomatoe3', '20150128')
	,(9, 'Tomatoe4', '20150628')
	,(10, 'Tomatoe44s', '20150630')
	,(11, 'Tomatoefggs', '20150228')
	,(12, 'Tomatoesytu', '20160228')
	,(13, 'Toyymatddoehys', '20151231')
	,(14, 'Tom443atoes', '20151215')
	,(15, 'Tomat65434foe23gfhgsPep', '20151004')


/*--- PROBLEM --- QUATERLY REPORT ---------*/
SELECT Id
      ,DATEPART(QUARTER, OrderDate) AS [Quarter]
      ,DATEPART(MONTH, OrderDate) AS [Month]
      ,DATEPART(YEAR, OrderDate) AS [Year]
      ,DATEPART(DAY, OrderDate) AS [Day]
FROM Orders

/*------------------------ EXERCISE -----------------------*/
USE Orders

/*--- TASK 18 --- ORDERS TABLE ----------------------------*/
SELECT ProductName
	  ,OrderDate
	  ,DATEADD(DAY, 3, OrderDate) AS [Pay Due]
	  ,DATEADD(MONTH, 1, OrderDate) AS [Deliver Due] 
FROM Orders

/*--- TASK 19 --- PEOPLE TABLE ----------------------------*/
CREATE TABLE People (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	Birthdate DATETIME NOT NULL
)

INSERT INTO People VALUES
	 ('Ivan', '1995-02-17')
	,('Gosho', '1991-10-10')
	,('Ayk', '1996-06-20')
	,('Yanka', '2001-01-16')

SELECT [Name],
	DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years],
	DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months],
	DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age in Days],
	DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age in Minutes]
FROM People