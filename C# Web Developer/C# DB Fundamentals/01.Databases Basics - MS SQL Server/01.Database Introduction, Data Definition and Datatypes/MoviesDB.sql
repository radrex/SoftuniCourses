/*--- TASK 13 ---- MOVIES DATABASE  ------------------*/
CREATE DATABASE Movies
USE Movies

CREATE TABLE Directors (
	 Id INT PRIMARY KEY IDENTITY
	,DirectorName NVARCHAR(150) NOT NULL
	,Notes NVARCHAR(MAX)
)

CREATE TABLE Genres (
	 Id INT PRIMARY KEY IDENTITY
	,GenreName NVARCHAR(100) NOT NULL UNIQUE
	,Notes NVARCHAR(MAX)
)

CREATE TABLE Categories (
	 Id INT PRIMARY KEY IDENTITY
	,CategoryName NVARCHAR(100) NOT NULL UNIQUE
	,Notes NVARCHAR(MAX)
)

CREATE TABLE Movies (
	 Id INT PRIMARY KEY IDENTITY
	,Title NVARCHAR(MAX) NOT NULL
	,DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL
	,CopyrightYear INT NOT NULL
	,[Length] TIME
	,GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL
	,CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
	,Rating DECIMAL(2,1)
	,Notes NVARCHAR(MAX)
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




