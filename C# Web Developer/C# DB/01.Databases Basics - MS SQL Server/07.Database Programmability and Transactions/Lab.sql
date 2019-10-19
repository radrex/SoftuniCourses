/*--- TASK 1 --------- SALARY LEVEL FUNCTION-----------------------*/
USE SoftUni
GO

CREATE FUNCTION ufn_GetSalaryLevel(@Salary MONEY)
RETURNS NVARCHAR(10)
AS
BEGIN
    DECLARE @salaryLevel NVARCHAR(10)

    IF(@Salary < 30000)
	    SET @salaryLevel = 'Low'
    ELSE IF(@Salary >= 30000 AND @Salary <= 50000)
        SET @salaryLevel = 'Average'
    ELSE
        SET @salaryLevel = 'High'

    RETURN @salaryLevel
END;

SELECT FirstName
      ,Salary
      ,dbo.ufn_GetSalaryLevel(Salary) AS SalaryLevel
FROM Employees

/*--- TASK 2 --------- EMPLOYEES WITH THREE PROJECTS --------------*/
CREATE PROCEDURE udp_AssignProject (@EmployeeID INT, @ProjectID INT)
AS
BEGIN
    DECLARE @maxEmployeeProjectsCount INT = 3
    DECLARE @employeeProjectsCount INT

    SET @employeeProjectsCount = 
    (
        SELECT COUNT(*)
		FROM [dbo].[EmployeesProjects] AS ep
		WHERE ep.EmployeeID = @EmployeeID
     )
END;

-- Transaction
BEGIN TRAN
    INSERT INTO [dbo].[EmployeesProjects] (EmployeeID, ProjectID) VALUES (@EmployeeID, @ProjectID)

    IF(@employeeProjectsCount >= @maxEmployeeProjectsCount)
    BEGIN
        RAISERROR('The employee has too many projects!', 16, 1)
		ROLLBACK
    END
    ELSE
        COMMIT
END

