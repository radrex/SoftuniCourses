CREATE DATABASE Incomes

USE Incomes

 CREATE TABLE DailyIncome(
	VendorId NVARCHAR(10), 
	IncomeDay NVARCHAR(10), 
	IncomeAmount INT
 )

INSERT INTO DailyIncome VALUES 
     ('SPIKE', 'FRI', 100)
	,('SPIKE', 'MON', 300)
	,('FREDS', 'SUN', 400)
	,('SPIKE', 'WED', 500)
	,('SPIKE', 'TUE', 200)
	,('JOHNS', 'WED', 900)
	,('SPIKE', 'FRI', 100)
	,('JOHNS', 'MON', 300)
	,('SPIKE', 'SUN', 400)
	,('JOHNS', 'FRI', 300)
	,('FREDS', 'TUE', 500)
	,('FREDS', 'TUE', 200)
	,('SPIKE', 'MON', 900)
	,('FREDS', 'FRI', 900)
	,('FREDS', 'MON', 500)
	,('JOHNS', 'SUN', 600)
	,('SPIKE', 'FRI', 300)
	,('SPIKE', 'WED', 500)
	,('SPIKE', 'FRI', 300)
	,('JOHNS', 'THU', 800)
	,('JOHNS', 'SAT', 800)
	,('SPIKE', 'TUE', 100)
	,('SPIKE', 'THU', 300)
	,('FREDS', 'WED', 500)
	,('SPIKE', 'SAT', 100)
	,('FREDS', 'SAT', 500)
	,('FREDS', 'THU', 800)
	,('JOHNS', 'TUE', 600)

SELECt * FROM DailyIncome

SELECT * FROM DailyIncome
PIVOT (
	AVG (IncomeAmount) FOR IncomeDay 
		IN ([MON],[TUE],[WED],[THU],[FRI],[SAT],[SUN])
	  ) 
	 AS AvgIncomePerDay


