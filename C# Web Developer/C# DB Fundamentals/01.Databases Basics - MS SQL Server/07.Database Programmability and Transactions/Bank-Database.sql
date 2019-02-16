CREATE DATABASE Bank
GO
USE Bank
GO
CREATE TABLE AccountHolders
(
Id INT NOT NULL,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
SSN CHAR(10) NOT NULL
CONSTRAINT PK_AccountHolders PRIMARY KEY (Id)
)

CREATE TABLE Accounts
(
Id INT NOT NULL,
AccountHolderId INT NOT NULL,
Balance MONEY DEFAULT 0
CONSTRAINT PK_Accounts PRIMARY KEY (Id)
CONSTRAINT FK_Accounts_AccountHolders FOREIGN KEY (AccountHolderId) REFERENCES AccountHolders(Id)
)

INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES 
	 (1, 'Susan', 'Cane', '1234567890')
	,(2, 'Kim', 'Novac', '1234567890')
	,(3, 'Jimmy', 'Henderson', '1234567890')
	,(4, 'Steve', 'Stevenson', '1234567890')
	,(5, 'Bjorn', 'Sweden', '1234567890')
	,(6, 'Kiril', 'Petrov', '1234567890')
	,(7, 'Petar', 'Kirilov', '1234567890')
	,(8, 'Michka', 'Tsekova', '1234567890')
	,(9, 'Zlatina', 'Pateva', '1234567890')
	,(10, 'Monika', 'Miteva', '1234567890')
	,(11, 'Zlatko', 'Zlatyov', '1234567890')
	,(12, 'Petko', 'Petkov Junior', '1234567890')

INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES 
	 (1, 1, 123.12)
	,(2, 3, 4354.23)
	,(3, 12, 6546543.23)
	,(4, 9, 15345.64)
	,(5, 11, 36521.20)
	,(6, 8, 5436.34)
	,(7, 10, 565649.20)
	,(8, 11, 999453.50)
	,(9, 1, 5349758.23)
	,(10, 2, 543.30)
	,(11, 3, 10.20)
	,(12, 7, 245656.23)
	,(13, 5, 5435.32)
	,(14, 4, 1.23)
	,(15, 6, 0.19)
	,(16, 2, 5345.34)
	,(17, 11, 76653.20)
	,(18, 1, 235469.89)


/*---------------------- EXERCISE -----------------------*/
USE Bank

/*--- TASK 9 --- FIND FULL NAME -------------------------*/
CREATE PROC usp_GetHoldersFullName
AS
	SELECT ah.FirstName + ' ' + ah.LastName AS [Full Name]
	FROM AccountHolders AS ah

EXEC usp_GetHoldersFullName

/*--- TASK 10 --- PEOPLE WITH BALANCE HIGHER THAN -------*/
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@value DECIMAL(16,2))
AS 
	SELECT ah.FirstName
		  ,ah.LastName
	FROM AccountHolders AS ah
	JOIN Accounts AS a ON a.AccountHolderId = ah.Id
	GROUP BY a.AccountHolderId, ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @value	
	ORDER BY ah.FirstName, ah.LastName

EXEC usp_GetHoldersWithBalanceHigherThan 10000

/*--- TASK 11 --- FUTURE VALUE FUNCTION -----------------*/
CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(16, 2), @yearlyRate FLOAT, @numberYears INT)
RETURNS DECIMAL(16, 4)
AS 
	BEGIN
		DECLARE @fv DECIMAL(16, 4) 

		SET @fv = @sum * (POWER(1 + @yearlyRate, @numberYears))
		RETURN @fv 
	END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5) AS [Output]

/*--- TASK 12 --- CALCULATING INTEREST ------------------*/
CREATE PROCEDURE usp_CalculateFutureValueForAccount(@accounID INT, @interestRate FLOAT, @years INT = 5)
AS 
	BEGIN
		SELECT a.Id
			  ,ah.FirstName
			  ,ah.LastName
			  ,a.Balance
			  ,dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, @years) AS [Balance in 5 years]
		FROM Accounts AS a
		JOIN AccountHolders AS ah ON ah.Id = a.AccountHolderId
		WHERE a.Id = @accounID
	END

EXEC usp_CalculateFutureValueForAccount 1, 0.1, 10

