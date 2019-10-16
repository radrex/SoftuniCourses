USE master
GO

/*--- TASK 13 --------- MOVIES DATABASE ----------------------------*/
CREATE DATABASE Movies
GO

USE Movies
GO

CREATE TABLE Directors (
	 Id INT CONSTRAINT PK_Directors PRIMARY KEY IDENTITY
	,DirectorName NVARCHAR(50) CONSTRAINT UC_Director UNIQUE NOT NULL
	,Notes NVARCHAR(200)
)


CREATE TABLE Genres (
	 Id INT CONSTRAINT PK_Genres PRIMARY KEY IDENTITY
	,GenreName NVARCHAR(50) CONSTRAINT UC_Genre UNIQUE NOT NULL
	,Notes NVARCHAR(200)
)

CREATE TABLE Categories (
	 Id INT CONSTRAINT PK_Categories PRIMARY KEY IDENTITY
	,CategoryName NVARCHAR(50) CONSTRAINT UC_Category UNIQUE NOT NULL
	,Notes NVARCHAR(200)
)

CREATE TABLE Movies (
	 Id INT CONSTRAINT PK_Movies PRIMARY KEY IDENTITY
	,Title NVARCHAR(50) NOT NULL
	,DirectorId INT CONSTRAINT FK_Movies_Directors FOREIGN KEY REFERENCES Directors(Id) NOT NULL
	,CopyrightYear INT
	,[Length] TIME
	,GenreId INT CONSTRAINT FK_Movies_Genres FOREIGN KEY REFERENCES Genres(Id) NOT NULL
	,CategoryId INT CONSTRAINT FK_Movies_Categories FOREIGN KEY REFERENCES Categories(Id) NOT NULL
	,Rating DECIMAL(2,1)
	,Notes NVARCHAR(200)
)

INSERT INTO Directors (DirectorName) VALUES 
	 ('Alfred Hitchcock')
	,('Stanley Kubrick')
	,('Martin Scorsese')
	,('Francis Ford Coppola')
	,('Steven Spielberg')

INSERT INTO Genres (GenreName) VALUES
	 ('Crime')
	,('Sci-Fi')
	,('Drama')
	,('Thriller')
	,('Comedy')

INSERT INTO Categories (CategoryName) VALUES
	 ('1')
	,('2')
	,('3')
	,('4')
	,('5')

INSERT INTO Movies (Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating) VALUES
	 ('Dial M for Murder', 1, 1954, '1:45:00', 1, 5, 8.2)
	,('2001: A Space Odyssey', 2, 1968, '2:29:00', 2, 4, 8.3)
	,('Taxi Driver', 3, 1976, '1:54:00', 3, 3, 8.3)
	,('Apocalypse Now', 4, 1979, '2:27:00', 3, 2, 8.5)
	,('Jaws', 5, 1975, '2:04:00', 4, 1, 8.0)