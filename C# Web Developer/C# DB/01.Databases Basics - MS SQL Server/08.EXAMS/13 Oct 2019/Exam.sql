/*-------------------------------------------------------------------------------*/
/*--------------------------- SECTION 1 --- DDL ---------------------------------*/
/*-------------------------------------------------------------------------------*/
CREATE DATABASE Bitbucket
GO

USE Bitbucket
GO
/*--- TASK 1 ---- DATABASE DESIGN -----------*/
/*-------- USERS -------------*/
CREATE TABLE Users (
     Id INT PRIMARY KEY IDENTITY
    ,Username CHAR(30) NOT NULL
    ,[Password] CHAR(30) NOT NULL
    ,Email CHAR(50) NOT NULL
)
/*-------- REPOSITORIES ------*/
CREATE TABLE Repositories (
     Id INT PRIMARY KEY IDENTITY
    ,[Name] CHAR(50) NOT NULL
)
/*-------- REPOSITORIES-CONTRIBUTORS --------*/
CREATE TABLE RepositoriesContributors (
     RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id)
    ,ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
    ,PRIMARY KEY(RepositoryId, ContributorId)
)
/*-------- ISSUES -------------*/
CREATE TABLE Issues (
     Id INT PRIMARY KEY IDENTITY
    ,Title CHAR(255) NOT NULL
    ,IssueStatus CHAR(6) NOT NULL
    ,RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL
    ,AssigneeId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)
/*-------- COMMITS -----------*/
CREATE TABLE Commits (
     Id INT PRIMARY KEY IDENTITY
    ,[Message] CHAR(255) NOT NULL
    ,IssueId INT FOREIGN KEY REFERENCES Issues(Id)
    ,RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL
    ,ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)
/*-------- FILES -------------*/
CREATE TABLE Files (
     Id INT PRIMARY KEY IDENTITY
    ,[Name] CHAR(100) NOT NULL
    ,Size DECIMAL(15, 2) NOT NULL
    ,ParentId INT FOREIGN KEY REFERENCES Files(Id)
    ,CommitId INT FOREIGN KEY REFERENCES Commits(Id) NOT NULL
)

/*-------------------------------------------------------------------------------*/
/*--------------------------- SECTION 2 --- DML ---------------------------------*/
/*-------------------------------------------------------------------------------*/
/*--- TASK 2 --------- INSERT ---------------*/
INSERT INTO Files ([Name], Size, ParentId, CommitId) VALUES 
     ('Trade.idk', 2598.0, 1, 1)
    ,('menu.net', 9238.31, 2, 2)
    ,('Administrate.soshy', 1246.93, 3, 3)
    ,('Controller.php', 7353.15, 4, 4)
    ,('Find.java', 9957.86, 5, 5)
    ,('Controller.json', 14034.87, 3, 6)
    ,('Operate.xix', 7662.92, 7, 7)

INSERT INTO Issues (Title, IssueStatus, RepositoryId, AssigneeId) VALUES 
     ('Critical Problem with HomeController.cs file', 'open', 1, 4)
    ,('Typo fix in Judge.html', 'open', 4, 3)
    ,('Implement documentation for UsersService.cs', 'closed', 8, 2)
    ,('Unreachable code in Index.cs', 'open', 9, 8)

/*--- TASK 3 --------- UPDATE ---------------*/
UPDATE Issues
SET IssueStatus = 'closed'
WHERE Issues.AssigneeId = 6

/*--- TASK 4 --------- DELETE ---------------*/
DELETE
FROM RepositoriesContributors
WHERE RepositoryId = 3

DELETE
FROM Issues
WHERE RepositoryId = 3

/*-------------------------------------------------------------------------------*/
/*--------------------------- SECTION 3 --- QUERYING ----------------------------*/
/*-------------------------------------------------------------------------------*/

-- RECREATE DB AND IMPORT DATA SET AGAIN

/*--- TASK 5 --------- COMMITS ----------------------*/
SELECT Id
      ,[Message]
      ,RepositoryId
      ,ContributorId
FROM Commits
ORDER BY Id ASC, [Message] ASC, RepositoryId ASC, ContributorId ASC

/*--- TASK 6 --------- HEAVY HTML -------------------*/
SELECT Id
      ,[Name]
      ,Size
FROM Files
WHERE Size > 1000 AND [Name] LIKE '%html%'
ORDER BY Size DESC, Id ASC, [Name] ASC

/*--- TASK 7 --------- ISSUES AND USERS -------------*/
SELECT i.Id
      ,CONCAT(u.Username, ' : ', i.Title) AS [IssueAssignee]
FROM Issues AS i
JOIN Users AS u ON u.Id = i.AssigneeId
ORDER BY i.Id DESC, [IssueAssignee] ASC

/*--- TASK 8 --------- NON-DIRECTORY FILES ----------*/
SELECT pf.Id
      ,pf.[Name]
      ,CONCAT(pf.Size, 'KB') AS [Size]
FROM Files AS f
RIGHT JOIN Files AS pf ON pf.Id = f.ParentId
WHERE f.ParentId IS NULL
ORDER BY pf.Id ASC, pf.[Name], [Size]

/*--- TASK 9 --------- MOST CONTRIBUTED REPOSITORIES */
SELECT TOP 5 r.Id
          ,r.[Name]
          ,COUNT(c.Id) AS [Commits]
FROM Repositories AS r
JOIN Commits AS c ON c.RepositoryId = r.Id
JOIN RepositoriesContributors AS rc ON rc.RepositoryId = r.Id
GROUP BY r.Id, r.[Name]
ORDER BY [Commits] DESC, r.Id ASC, r.[Name] ASC

/*--- TASK 10 -------- USER AND FILES ---------------*/
SELECT x.Username
      ,AVG(x.Size) AS [Size]
FROM
    (
        SELECT u.Username, c.[Message], f.Size
        FROM Users AS u
        JOIN Commits AS c ON c.ContributorId = u.Id
        JOIN Files AS f ON f.CommitId = c.Id
    ) AS x
GROUP BY x.Username
ORDER BY [Size] DESC, x.Username ASC

/*-------------------------------------------------------------------------------*/
/*--------------------------- SECTION 4 --- PROGRAMMABILITY ---------------------*/
/*-------------------------------------------------------------------------------*/

/*--- TASK 11 -------- USER TOTAL COMMITS -----------*/
CREATE FUNCTION udf_UserTotalCommits(@username VARCHAR(50))
RETURNS INT
AS
BEGIN
    RETURN
    (
        SELECT COUNT(*)
        FROM Users AS u
        JOIN Commits AS c ON c.ContributorId = u.Id
        WHERE u.Username = @username
    )
END

SELECT dbo.udf_UserTotalCommits('UnderSinduxrein')

/*--- TASK 12 -------- FIND BY EXTENSIONS -----------*/
CREATE PROC usp_FindByExtension(@extension VARCHAR(50))
AS 
BEGIN
    SELECT f.Id
          ,f.[Name]
          ,CONCAT(f.Size, 'KB') AS [Size]
    FROM Files AS f
    WHERE CHARINDEX(@extension, f.[Name]) > 0
    ORDER BY f.Id ASC, f.[Name] ASC, [Size] DESC
END

EXEC usp_FindByExtension 'txt'
