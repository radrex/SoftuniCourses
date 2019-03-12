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

/*--- TASK 14 --- CREATE TABLE LOGS ---------------------*/
CREATE TABLE Logs (
	 LogId INT PRIMARY KEY IDENTITY
	,AccountId INT FOREIGN KEY REFERENCES Accounts(Id)
	,OldSum DECIMAL(15, 2)
	,NewSum DECIMAL(15, 2)
)

/*------- TRIGGER FOR JUDGE -------*/
CREATE TRIGGER tr_InsertAccountInfo ON Accounts FOR UPDATE
AS
	
	DECLARE @newSum DECIMAL(15, 2) = (SELECT Balance FROM inserted)
	DECLARE @oldSum DECIMAL(15, 2) = (SELECT Balance FROM deleted) 
	DECLARE @accountId INT = (SELECT Id FROM inserted)

	INSERT INTO Logs (AccountId, NewSum, OldSum) VALUES
		(@accountId, @newSum, @oldSum)
/*---------------------------------*/
	UPDATE Accounts
	SET Balance += 10
	WHERE Id = 1

	SELECT * FROM Accounts
	WHERE Id = 1

	SELECT * FROM Logs

/*--- TASK 15 --- CREATE TABLE EMAILS -------------------*/
CREATE TABLE NotificationEmails (
	 Id INT PRIMARY KEY IDENTITY
	,Recipient INT FOREIGN KEY REFERENCES Accounts(Id)
	,[Subject] VARCHAR(50)
	,Body VARCHAR(MAX)
)
/*------- TRIGGER FOR JUDGE -------*/
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
/*---------------------------------*/

UPDATE Accounts
SET Balance += 100
WHERE Id = 1
	
SELECT * FROM Accounts WHERE Id = 1
SELECT * FROM Logs
SELECT * FROM NotificationEmails

/*--- TASK 16 --- DEPOSIT MONEY -------------------------*/
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
/*---------------------------------*/
SELECT * FROM Accounts WHERE Id = 1
EXEC usp_DepositMoney 1, 234.14
SELECT * FROM Accounts WHERE Id = 1

/*--- TASK 17 --- WITHDRAW MONEY PROCEDURE --------------*/
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

		IF(@accountBalance - @moneyAmount< 0)
		BEGIN
			ROLLBACK
			RAISERROR('Insufficient funds', 16, 1)
			RETURN
		END

	UPDATE Accounts
	SET Balance -= @moneyAmount
	WHERE Id = @accountId
	COMMIT
/*---------------------------------*/
SELECT * FROM Accounts WHERE Id = 1
EXEC usp_WithdrawMoney 1, 150.14
SELECT * FROM Accounts WHERE Id = 1

/*--- TASK 18 --- MONEY TRANSFER ------------------------*/
CREATE PROC usp_TransferMoney(@senderId INT, @receiverId INT, @amount DECIMAL(15,4))
AS
	BEGIN TRANSACTION
		EXEC usp_WithdrawMoney @senderId, @amount
		EXEC usp_DepositMoney @receiverId, @amount
	COMMIT
/*---------------------------------*/
SELECT * FROM Accounts WHERE Id IN(1, 2)
EXEC usp_TransferMoney 1, 2, 100
SELECT * FROM Accounts WHERE Id IN(1, 2)












