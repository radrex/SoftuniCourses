/*--- TASK 1 --------- EMPLOYEES WITH SALARY ABOVE 35000 ----------*/
USE SoftUni
GO

CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
    SELECT FirstName
          ,LastName
    FROM Employees
    WHERE Salary > 35000

EXEC usp_GetEmployeesSalaryAbove35000

/*--- TASK 2 --------- EMPLOYEES WITH SALARY ABOVE NUMBER ---------*/
CREATE PROC usp_GetEmployeesSalaryAboveNumber(@Number DECIMAL(18,4))
AS
    SELECT FirstName
          ,LastName
    FROM Employees
    WHERE Salary >= @Number

EXEC usp_GetEmployeesSalaryAboveNumber 48100

/*--- TASK 3 --------- TOWN NAMES STARTING WITH -------------------*/
CREATE PROC usp_GetTownsStartingWith(@String NVARCHAR(50))
AS
    SELECT [Name]
    FROM Towns
    WHERE [Name] LIKE @String + '%'

EXEC usp_GetTownsStartingWith 'b'

/*--- TASK 4 --------- EMPLOYEES FROM TOWN ------------------------*/
CREATE PROC usp_GetEmployeesFromTown(@TownName NVARCHAR(50))
AS
    SELECT e.FirstName AS [First Name]
	      ,e.LastName AS [Last Name]
    FROM Employees AS e
    JOIN Addresses AS a ON a.AddressID = e.AddressID
    JOIN Towns AS t ON t.TownID = a.TownID
	WHERE t.[Name] = @TownName

EXEC usp_GetEmployeesFromTown 'Sofia'

/*--- TASK 5 --------- SALARY LEVEL FUNCTION ----------------------*/
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(20)
AS
BEGIN
    DECLARE @salaryLevel NVARCHAR(10)

    IF(@salary < 30000)
        SET @salaryLevel = 'Low'
    ELSE IF(@salary >= 30000 AND @salary <= 50000)
        SET @salaryLevel = 'Average'
    ELSE
        SET @salaryLevel = 'High'

	RETURN @salaryLevel
END

SELECT Salary
      ,dbo.ufn_GetSalaryLevel(Salary) AS SalaryLevel
FROM Employees
GROUP BY Salary

/*--- TASK 6 --------- EMPLOYEES BY SALARY LEVEL ------------------*/
CREATE PROC usp_EmployeesBySalaryLevel(@SalaryLevel NVARCHAR(20))
AS
    SELECT FirstName AS [First Name]
          ,LastName AS [Last Name]
    FROM Employees
    WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel

EXEC usp_EmployeesBySalaryLevel 'High'

/*--- TASK 7 --------- DEFINE FUNCTION ----------------------------*/
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
RETURNS BIT
BEGIN
    DECLARE @index INT = 1
    DECLARE @wordMatch NVARCHAR(MAX)

    WHILE (@index <= LEN(@word))
    BEGIN
        DECLARE @letter NCHAR(1) = SUBSTRING(@word, @index, 1)
		
        IF(@setOfLetters LIKE '%' + @letter + '%')
        BEGIN
            SET @wordMatch = CONCAT(@wordMatch, @letter);
        END

        SET @index += 1		-- increment while loop
    END
	
    IF(@word = @wordMatch)
    BEGIN
        RETURN 1
    END 
    RETURN 0
END

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia') AS Result
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves') AS Result
SELECT dbo.ufn_IsWordComprised('bobr', 'Rob') AS Result
SELECT dbo.ufn_IsWordComprised('pppp', 'Guy') AS Result

/*--- TASK 8 --------- DELETE EMPLOYEES AND DEPARTMENTS -----------*/
CREATE PROC usp_DeleteEmployeesFromDepartment(@departmentId INT)
AS

    ALTER TABLE Departments
    ALTER COLUMN ManagerID INT

    DELETE FROM EmployeesProjects
    WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

    UPDATE Departments
    SET ManagerID = NULL
    WHERE DepartmentID = @departmentId

    UPDATE Employees
    SET ManagerID = NULL
    WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

    DELETE FROM Employees
    WHERE DepartmentID = @departmentId

    DELETE FROM Departments
    WHERE DepartmentID = @departmentId

SELECT COUNT(*)
FROM Employees
WHERE DepartmentID = @departmentId

/*--- TASK 9 --------- FIND FULL NAME -----------------------------*/
USE Bank
GO

CREATE PROC usp_GetHoldersFullName
AS
    SELECT ah.FirstName + ' ' + ah.LastName AS [Full Name]
    FROM AccountHolders AS ah

EXEC usp_GetHoldersFullName

/*--- TASK 10 -------- PEOPLE WITH BALANCE HIGHER THAN ------------*/
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

/*--- TASK 11 -------- FUTURE VALUE FUNCTION ----------------------*/
CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(16, 2), @yearlyRate FLOAT, @numberYears INT)
RETURNS DECIMAL(16, 4)
AS 
    BEGIN
        DECLARE @fv DECIMAL(16, 4) 

        SET @fv = @sum * (POWER(1 + @yearlyRate, @numberYears))
        RETURN @fv 
    END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5) AS [Output]
/*--- TASK 12 -------- CALCULATING INTEREST  ----------------------*/
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

/*--- TASK 13 -------- CASH IN USER GAMES ODD ROWS ----------------*/
USE Diablo
GO

CREATE FUNCTION ufn_CashInUsersGames(@gameName NVARCHAR(MAX))
RETURNS TABLE
AS 
	RETURN (SELECT SUM(fQuerry.Cash) AS SumCash
			FROM
				(
					SELECT ug.Cash AS Cash
						  ,ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS [Row Number]
					FROM UsersGames AS ug
					JOIN Games AS g ON g.Id = ug.GameId
					WHERE g.[Name] = @gameName
				) 
				AS fQuerry
			WHERE fQuerry.[Row Number] % 2 = 1)


SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')

/*--- TASK 14 -------- CREATE TABLE LOGS --------------------------*/
USE Bank
GO

CREATE TABLE Logs (
     LogId INT CONSTRAINT PK_Logs PRIMARY KEY IDENTITY NOT NULL
    ,AccountId INT CONSTRAINT FK_Logs_Accounts FOREIGN KEY REFERENCES Accounts(Id)
    ,OldSum DECIMAL(15,2) NOT NULL
    ,NewSum DECIMAL(15,2) NOT NULL
)

CREATE TRIGGER tr_InsertAccountInfo ON Accounts FOR UPDATE
AS
    DECLARE @newSum DECIMAL(15, 2) = (SELECT Balance FROM inserted)
    DECLARE @oldSum DECIMAL(15, 2) = (SELECT Balance FROM deleted)
    DECLARE @accountId INT = (SELECT Id FROM inserted)

    INSERT INTO Logs (AccountId, NewSum, OldSum) VALUES
    (@accountId, @newSum, @oldSum)

UPDATE Accounts
SET Balance += 10
WHERE Id = 1
   
SELECT * FROM Accounts
WHERE Id = 1

SELECT * FROM Logs

/*--- TASK 15 -------- CREATE TABLE EMAILS ------------------------*/
CREATE TABLE NotificationEmails (
     Id INT PRIMARY KEY IDENTITY
    ,Recipient INT FOREIGN KEY REFERENCES Accounts(Id)
    ,[Subject] VARCHAR(50)
    ,Body VARCHAR(MAX)
)

CREATE TRIGGER tr_LogEmail ON Logs FOR INSERT
AS	
    DECLARE @accountId INT = (SELECT TOP(1) AccountId FROM inserted)
    DECLARE @oldSum DECIMAL(15, 2) = (SELECT TOP(1) OldSum FROM inserted)
    DECLARE @newSum DECIMAL(15, 2) = (SELECT TOP(1) NewSum FROM inserted)

    INSERT INTO NotificationEmails (Recipient, [Subject], Body) VALUES
        (
            @accountId
           ,'Balance change for account: ' + CAST(@accountId AS VARCHAR(20))
           ,'On ' + CONVERT(VARCHAR(30), GETDATE(), 103) + ' your balance was changed from ' + CAST(@oldSum AS VARCHAR(20)) + ' to ' + CAST(@newSum AS VARCHAR(20))
        )

UPDATE Accounts
SET Balance += 100
WHERE Id = 1
	
SELECT * FROM Accounts WHERE Id = 1
SELECT * FROM Logs
SELECT * FROM NotificationEmails

/*--- TASK 16 -------- DEPOSIT MONEY ------------------------------*/
CREATE PROC usp_DepositMoney @accountId INT, @moneyAmount DECIMAL(15,4)
AS
    BEGIN TRANSACTION
        DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @accountId)
		
        IF(@accountId IS NULL)
        BEGIN
            ROLLBACK
            RAISERROR('Invalid account Id!', 16, 1)
            RETURN
        END
		
        IF(@moneyAmount < 0)
        BEGIN
            ROLLBACK
            RAISERROR('Negative amount!', 16, 1)
            RETURN
        END

UPDATE Accounts
SET Balance += @moneyAmount
WHERE Id = @accountId
COMMIT

SELECT * FROM Accounts WHERE Id = 1
EXEC usp_DepositMoney 1, 234.14
SELECT * FROM Accounts WHERE Id = 1

/*--- TASK 17 -------- WITHDRAW MONEY -----------------------------*/
CREATE PROC usp_WithdrawMoney @accountId INT, @moneyAmount DECIMAL(15,4)
AS
    BEGIN TRANSACTION
        DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @accountId)
        DECLARE @accountBalance DECIMAL(15,4) = (SELECT Balance FROM Accounts WHERE Id = @accountId)
		
        IF(@accountId IS NULL)
        BEGIN
            ROLLBACK
            RAISERROR('Invalid account Id!', 16, 1)
            RETURN
        END
		
        IF(@moneyAmount < 0)
        BEGIN
            ROLLBACK
            RAISERROR('Negative amount!', 16, 1)
            RETURN
        END

        IF(@accountBalance - @moneyAmount < 0)
        BEGIN
            ROLLBACK
            RAISERROR('Insufficient funds', 16, 1)
            RETURN
        END

    UPDATE Accounts
    SET Balance -= @moneyAmount
    WHERE Id = @accountId
    COMMIT

SELECT * FROM Accounts WHERE Id = 1
EXEC usp_WithdrawMoney 1, 150.14
SELECT * FROM Accounts WHERE Id = 1

/*--- TASK 18 -------- MONEY TRANSFER -----------------------------*/
CREATE PROC usp_TransferMoney(@senderId INT, @receiverId INT, @amount DECIMAL(15,4))
AS
    BEGIN TRANSACTION
        EXEC usp_WithdrawMoney @senderId, @amount
        EXEC usp_DepositMoney @receiverId, @amount
    COMMIT

SELECT * FROM Accounts WHERE Id IN(1, 2)
EXEC usp_TransferMoney 1, 2, 100
SELECT * FROM Accounts WHERE Id IN(1, 2)

/*--- TASK 19 -------- TRIGGER ------------------------------------*/
CREATE TRIGGER tr_RestrictItems ON UserGameItems INSTEAD OF INSERT
AS
	DECLARE @itemId INT = (SELECT ItemId FROM inserted)
	DECLARE @userGameId INT = (SELECT UserGameId FROM inserted)

	DECLARE @itemLevel INT = (SELECT MinLevel FROM Items WHERE Id = @itemId)
	DECLARE @userGameLevel INT = (SELECT [Level] FROM UsersGames WHERE Id = @userGameId)

	IF(@userGameLevel >= @itemLevel)
	BEGIN
		INSERT INTO UserGameItems (ItemId, UserGameId) VALUES
			(@itemId, @userGameId)
	END

/*--- TASK 20 -------- MASSIVE SHOPPING ---------------------------*/
DECLARE @gameId INT, @sum1 MONEY, @sum2 MONEY;

SELECT @gameId = usg.[Id]
FROM UsersGames AS usg
     JOIN Games AS g ON usg.[GameId] = g.[Id]
WHERE g.[Name] = 'Safflower';

SET @sum1 =
(
    SELECT SUM(i.Price)
    FROM Items AS i
    WHERE MinLevel BETWEEN 11 AND 12
);

SET @sum2 =
(
    SELECT SUM(i.Price)
    FROM Items AS i
    WHERE MinLevel BETWEEN 19 AND 21
);

BEGIN TRANSACTION;

IF
(
    SELECT Cash
    FROM UsersGames
    WHERE Id = @gameId
) < @sum1
    BEGIN
        ROLLBACK;
END
    ELSE
    BEGIN
        UPDATE UsersGames
          SET
              Cash = Cash - @sum1
        WHERE Id = @gameId;

        INSERT INTO UserGameItems(UserGameId,
                                  ItemId
                                 )
               SELECT @gameId,
                      Id
               FROM Items
               WHERE MinLevel BETWEEN 11 AND 12;
        COMMIT;
END;

BEGIN TRANSACTION;

IF
(
    SELECT Cash
    FROM UsersGames
    WHERE Id = @gameId
) < @sum2
    BEGIN
        ROLLBACK;
END
    ELSE
    BEGIN
        UPDATE UsersGames
          SET
              Cash = Cash - @sum2
        WHERE Id = @gameId;

        INSERT INTO UserGameItems(UserGameId,
                                  ItemId
                                 )
               SELECT @gameId,
                      Id
               FROM Items
               WHERE MinLevel BETWEEN 19 AND 21;
        COMMIT;
END;

SELECT i.Name AS 'Item Name'
FROM UserGameItems AS ugi
     JOIN Items AS i ON ugi.ItemId = i.Id
WHERE ugi.UserGameId = @gameId;

/*--- TASK 21 -------- EMPLOYEES WITH THREE PROJECTS --------------*/
CREATE PROCEDURE usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN 
	DECLARE @maxProjectsAllowed INT = 3; 
	DECLARE @currentProjects INT;

	SET @currentProjects = 
	(SELECT COUNT(*) 
	FROM Employees AS e
	JOIN EmployeesProjects AS ep
	ON ep.EmployeeID = e.EmployeeID
	WHERE ep.EmployeeID = @emloyeeId)

BEGIN TRANSACTION 	
	IF(@currentProjects >= @maxProjectsAllowed)
	BEGIN 
		RAISERROR('The employee has too many projects!', 16, 1);
		ROLLBACK;
		RETURN;
	END

	INSERT INTO EmployeesProjects
	VALUES
	(@emloyeeId, @projectID)

COMMIT	
END 

/*--- TASK 22 -------- DELETE EMPLOYEES ---------------------------*/
CREATE TRIGGER tr_DeletedEmp 
ON Employees 
AFTER DELETE 
AS
	INSERT INTO Deleted_Employees
	SELECT 	
		d.FirstName, 
		d.LastName, 
		d.MiddleName, 
		d.JobTitle, 
		d.DepartmentID, 
		d.Salary
FROM deleted as d