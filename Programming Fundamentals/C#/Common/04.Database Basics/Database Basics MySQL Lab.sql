CREATE DATABASE softuni;

USE softuni;

/*---------- q01_CreateTable ----------*/
CREATE TABLE students (
	 id INT  AUTO_INCREMENT PRIMARY KEY
	,first_name VARCHAR(50) NULL
	,last_name VARCHAR(50) NULL
	,age INT NULL
	,grade DOUBLE NULL
);

/*---------- q02_InsertData -----------*/
INSERT INTO students (first_name, last_name, age, grade)
VALUES ('Guy', 'Gilbert', 15, 4.5),
		 ('Kevin', 'Brown', 17, 5.4),
		 ('Roberto', 'Tamburello', 19, 6),
		 ('Linda', 'Smith', 18, 5),
		 ('John', 'Stones', 16, 4.25),
		 ('Nicole', 'Nelson', 17, 5.50);
		
/*---------- q03_FindAllRecords -------*/
SELECT * FROM students;	 

/*-- q04_Find LastName Age and Grade --*/
SELECT last_name, age, grade
FROM students;

/*------ q05_Find First 5 Records -----*/ 
SELECT *
FROM students
LIMIT 5;

/*-- q06_Find First 5 Last Name and Grade --*/
SELECT last_name, grade
FROM students
LIMIT 5;

/*--------- q07_Truncate Table --------*/
TRUNCATE students;

/*----------- q08_Drop Table ----------*/
DROP TABLE students;

/*--------- q09_Drop Database ---------*/
DROP DATABASE softuni;


