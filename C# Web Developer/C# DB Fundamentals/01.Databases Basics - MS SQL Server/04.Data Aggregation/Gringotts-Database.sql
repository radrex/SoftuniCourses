USE [master]
GO

CREATE DATABASE [Gringotts]
GO

USE [Gringotts]
GO

CREATE TABLE [WizzardDeposits](
	[Id] INT PRIMARY KEY,
	[FirstName] VARCHAR(50),
	[LastName] VARCHAR(60),
	[Notes] TEXT,
	[Age] INT,
	[MagicWandCreator] VARCHAR(100),
	[MagicWandSize] SMALLINT,
	[DepositGroup] VARCHAR(20),
	[DepositStartDate] DATE,
	[DepositAmount] DECIMAL(8,2),
	[DepositInterest] DECIMAL(5,2),
	[DepositCharge] DECIMAL (8,2),
	[DepositExpirationDate] DATE,
	[IsDepositExpired] BIT
)

INSERT [dbo].[WizzardDeposits] ([Id], [FirstName], [LastName], [Notes], [Age], [MagicWandCreator], [MagicWandSize], [DepositGroup], [DepositStartDate], [DepositAmount], [DepositInterest], [DepositCharge], [DepositExpirationDate], [IsDepositExpired]) VALUES 
	 (1, 'Hannah', 'Abbott', 'Hufflepuff student in Harry''s year and member of Dumbledore''s Army.', 71, 'Antioch Peverell', 19, 'Troll Chest', CAST('1990-09-27' AS Date), CAST(47443.03 AS Decimal(8, 2)), CAST(29.28 AS Decimal(5, 2)), CAST(73.00 AS Decimal(8, 2)), CAST('1991-04-08' AS Date), 0)
	,(2, 'Bathsheda', 'Babbling', 'Ancient Runes teacher at Hogwarts', 63, 'Ollivander family', 20, 'Human Pride', CAST('1986-03-27' AS Date), CAST(46597.40 AS Decimal(8, 2)), CAST(26.64 AS Decimal(5, 2)), CAST(64.00 AS Decimal(8, 2)), CAST('1986-05-16' AS Date), 1)
	,(3, 'Ludo', 'Bagman', 'Quidditch Beater for the Wimbourne Wasps and Head of the Department of Magical Games and Sports within the Ministry of Magic', 19, 'Mykew Grerovitch', 18, 'Venomous Tongue', CAST('1990-07-04' AS Date), CAST(23190.94 AS Decimal(8, 2)), CAST(14.92 AS Decimal(5, 2)), CAST(30.00 AS Decimal(8, 2)), CAST('1990-12-27' AS Date), 0)
	,(4, 'Bathilda', 'Bagshot', 'Author of A History of Magic, great aunt of Gellert Grindelwald.', 52, 'Jimmy Kiddell', 15, 'Blue Phoenix', CAST('1993-06-07' AS Date), CAST(687.67 AS Decimal(8, 2)), CAST(18.18 AS Decimal(5, 2)), CAST(62.00 AS Decimal(8, 2)), CAST('1993-09-10' AS Date), 0)
	,(5, 'Katie', 'Bell', 'Gryffindor student one year above Harry Potter; Chaser on the Gryffindor Quidditch team.', 40, 'Arturo Cephalopos', 14, 'Troll Chest', CAST('1981-05-08' AS Date), CAST(8092.93 AS Decimal(8, 2)), CAST(16.58 AS Decimal(5, 2)), CAST(11.00 AS Decimal(8, 2)), CAST('1982-02-03' AS Date), 1)
	,(6, 'Cuthbert', 'Binns', 'Ghost, History of Magic professor.', 28, 'Death', 23, 'Human Pride', CAST('1985-10-26' AS Date), CAST(11902.72 AS Decimal(8, 2)), CAST(24.84 AS Decimal(5, 2)), CAST(95.00 AS Decimal(8, 2)), CAST('1985-12-27' AS Date), 1)
	,(7, 'Phineas', 'Nigellus', 'deceased great-great-grandfather of Sirius Black and former headmaster of Hogwarts, whose painting still hangs in the office and helps out the current headmaster.', 47, 'Mykew Grerovitch', 18, 'Venomous Tongue', CAST('1985-12-05' AS Date), CAST(11248.58 AS Decimal(8, 2)), CAST(12.31 AS Decimal(5, 2)), CAST(32.00 AS Decimal(8, 2)), CAST('1986-11-12' AS Date), 1)
	,(8, 'Regulus', 'Arcturus', 'Late brother of Sirius Black, a Death Eater who had turned against Lord Voldemort.', 46, 'Ollivander family', 22, 'Blue Phoenix', CAST('1989-05-31' AS Date), CAST(1173.12 AS Decimal(8, 2)), CAST(9.68 AS Decimal(5, 2)), CAST(56.00 AS Decimal(8, 2)), CAST('1989-10-13' AS Date), 0)
	,(9, 'Sirius', 'Black', 'Harry Potter''s dfather, a member of the Order of the Phoenix and prisoner on the run.', 25, 'Mykew Grerovitch', 30, 'Troll Chest', CAST('1993-08-29' AS Date), CAST(15793.54 AS Decimal(8, 2)), CAST(26.34 AS Decimal(5, 2)), CAST(17.00 AS Decimal(8, 2)), CAST('1994-05-21' AS Date), 0)
	,(10, 'Amelia', 'Bones', 'Head of the Department of Magical Law Enforcement, aunt of Susan Bones.', 16, 'Antioch Peverell', 30, 'Human Pride', CAST('1981-05-15' AS Date), CAST(18778.37 AS Decimal(8, 2)), CAST(7.85 AS Decimal(5, 2)), CAST(54.00 AS Decimal(8, 2)), CAST('1982-05-06' AS Date), 1)
	,(11, 'Susan', 'Bones', 'Hufflepuff student in Harry''s year, a member of Dumbledore''s Army.', 72, 'Ollivander family', 11, 'Venomous Tongue', CAST('1992-05-03' AS Date), CAST(26463.40 AS Decimal(8, 2)), CAST(30.54 AS Decimal(5, 2)), CAST(30.00 AS Decimal(8, 2)), CAST('1993-03-11' AS Date), 0)
	,(12, 'Terry', 'Boot', 'Ravenclaw student in Harry''s year, a member of Dumbledore''s Army.', 69, 'Mykew Grerovitch', 28, 'Blue Phoenix', CAST('1989-09-09' AS Date), CAST(31029.60 AS Decimal(8, 2)), CAST(27.98 AS Decimal(5, 2)), CAST(10.00 AS Decimal(8, 2)), CAST('1990-02-15' AS Date), 0)
	,(13, 'Lavender', 'Brown', 'Gryffindor student in Harry''s year, a member of Dumbledore''s Army, briefly Ron Weasley''s girlfriend.', 31, 'Jimmy Kiddell', 24, 'Troll Chest', CAST('1992-03-26' AS Date), CAST(26572.86 AS Decimal(8, 2)), CAST(26.64 AS Decimal(5, 2)), CAST(94.00 AS Decimal(8, 2)), CAST('1992-08-21' AS Date), 0)
	,(14, 'Millicent', 'Bulstrode', 'Slytherin student in Harry''s year, a member of Umbridge''s Inquisitorial Squad.', 65, 'Arturo Cephalopos', 17, 'Human Pride', CAST('1988-08-16' AS Date), CAST(33309.81 AS Decimal(8, 2)), CAST(25.43 AS Decimal(5, 2)), CAST(44.00 AS Decimal(8, 2)), CAST('1988-08-21' AS Date), 1)
	,(15, 'Charity', 'Burbage', 'Professor of Muggle Studies at Hogwarts during Harry''s time at school.', 38, 'Death', 30, 'Venomous Tongue', CAST('1994-07-21' AS Date), CAST(33508.64 AS Decimal(8, 2)), CAST(17.14 AS Decimal(5, 2)), CAST(31.00 AS Decimal(8, 2)), CAST('1995-04-06' AS Date), 0)
	,(16, 'Frank', 'Bryce', 'Muggle gardener for the Riddle family.', 24, 'Antioch Peverell', 29, 'Blue Phoenix', CAST('1991-12-20' AS Date), CAST(19955.71 AS Decimal(8, 2)), CAST(6.52 AS Decimal(5, 2)), CAST(30.00 AS Decimal(8, 2)), CAST('1992-07-22' AS Date), 0)
	,(17, 'Alecto', 'Carrow', 'Sister of Amycus Carrow, Death Eater and professor of Muggle Studies for one year, Deputy Headmistress of Hogwarts under Severus Snape', 52, 'Jimmy Kiddell', 24, 'Troll Chest', CAST('1982-03-28' AS Date), CAST(25434.21 AS Decimal(8, 2)), CAST(14.96 AS Decimal(5, 2)), CAST(36.00 AS Decimal(8, 2)), CAST('1982-09-17' AS Date), 1)
	,(18, 'Amycus', 'Carrow', 'Brother of Alecto Carrow, Death Eater and professor of Defence Against the Dark Arts for one year, even though he changed it to just "Dark Arts", Deputy Headmaster of Hogwarts under Severus Snape', 23, 'Arturo Cephalopos', 30, 'Human Pride', CAST('1988-04-18' AS Date), CAST(46943.10 AS Decimal(8, 2)), CAST(5.08 AS Decimal(5, 2)), CAST(6.00 AS Decimal(8, 2)), CAST('1988-08-05' AS Date), 1)
	,(19, 'Reginald', 'Cattermole', 'Employee of the Magical Maintenance Department for the Ministry of Magic, impersonated by Ron Weasley', 25, 'Death', 28, 'Venomous Tongue', CAST('1981-08-14' AS Date), CAST(39864.33 AS Decimal(8, 2)), CAST(15.75 AS Decimal(5, 2)), CAST(8.00 AS Decimal(8, 2)), CAST('1981-11-24' AS Date), 1)
	,(20, 'Mary', 'Cattermole', 'Muggle-born wife of Reginald Cattermole, saved by Harry Potter from the Muggle-born Registration Commission.', 53, 'Antioch Peverell', 25, 'Blue Phoenix', CAST('1981-08-18' AS Date), CAST(34176.09 AS Decimal(8, 2)), CAST(12.34 AS Decimal(5, 2)), CAST(71.00 AS Decimal(8, 2)), CAST('1982-04-21' AS Date), 1)
	,(21, 'Cho', 'Chang', 'Ravenclaw student one year above Harry, Quidditch Seeker, member of Dumbledore''s Army and Harry''s first Love interest', 64, 'Ollivander family', 20, 'Troll Chest', CAST('1984-01-31' AS Date), CAST(49964.03 AS Decimal(8, 2)), CAST(10.83 AS Decimal(5, 2)), CAST(53.00 AS Decimal(8, 2)), CAST('1984-03-29' AS Date), 1)
	,(22, 'Penelope', 'Clearwater', 'Ravenclaw prefect and girlfriend of Percy Weasley', 58, 'Mykew Grerovitch', 17, 'Human Pride', CAST('1983-05-06' AS Date), CAST(5130.24 AS Decimal(8, 2)), CAST(11.04 AS Decimal(5, 2)), CAST(42.00 AS Decimal(8, 2)), CAST('1983-06-11' AS Date), 1)
	,(23, 'Michael', 'Corner', 'Ravenclaw student in Harry''s year, member of Dumbledore''s Army', 56, 'Jimmy Kiddell', 15, 'Venomous Tongue', CAST('1985-03-23' AS Date), CAST(23295.97 AS Decimal(8, 2)), CAST(20.97 AS Decimal(5, 2)), CAST(35.00 AS Decimal(8, 2)), CAST('1985-04-13' AS Date), 1)
	,(24, 'Vincent', 'Crabbe,', 'Death Eater, father of Vincent Crabbe', 37, 'Arturo Cephalopos', 24, 'Blue Phoenix', CAST('1993-03-30' AS Date), CAST(35436.82 AS Decimal(8, 2)), CAST(26.54 AS Decimal(5, 2)), CAST(17.00 AS Decimal(8, 2)), CAST('1993-04-07' AS Date), 0)
	,(25, 'Vincent', 'Crabbe', 'Slytherin student in Harry''s year, son of Death Eater, Slytherin Quidditch team Beater, a member of the Inquisitorial Squad, a friend of Draco Malfoy.', 37, 'Death', 12, 'Troll Chest', CAST('1986-07-18' AS Date), CAST(8597.40 AS Decimal(8, 2)), CAST(20.09 AS Decimal(5, 2)), CAST(97.00 AS Decimal(8, 2)), CAST('1986-10-18' AS Date), 1)
	,(26, 'Colin', 'Creevey', 'Muggle-born Gryffindor student one year below Harry, brother of Dennis Creevey, member of Dumbledore''s Army, killed during the Battle of Hogwarts, after sneaking away from the younger evacuated students in the seventh book', 38, 'Antioch Peverell', 15, 'Human Pride', CAST('1991-02-19' AS Date), CAST(27282.08 AS Decimal(8, 2)), CAST(11.82 AS Decimal(5, 2)), CAST(76.00 AS Decimal(8, 2)), CAST('1992-01-08' AS Date), 0)
	,(27, 'Dennis', 'Creevey', 'Muggle-born Gryffindor student three years below Harry, brother of Colin Creevey, member of Dumbledore''s Army', 61, 'Ollivander family', 24, 'Venomous Tongue', CAST('1992-07-13' AS Date), CAST(10649.78 AS Decimal(8, 2)), CAST(1.77 AS Decimal(5, 2)), CAST(23.00 AS Decimal(8, 2)), CAST('1992-09-24' AS Date), 0)
	,(28, 'Dirk', 'Cresswell', 'Muggle-born Head of the blin Liaison Office, went on the run in Deathly Hallows with fellow muggle-born Ted Tonks, Dean Thomas and blins rnuk and Griphook.', 65, 'Mykew Grerovitch', 26, 'Blue Phoenix', CAST('1985-02-14' AS Date), CAST(11481.54 AS Decimal(8, 2)), CAST(25.13 AS Decimal(5, 2)), CAST(23.00 AS Decimal(8, 2)), CAST('1985-04-22' AS Date), 1)
	,(29, 'Bartemius', 'Barty', 'Head of the Department of International Magical Cooperation, killed by his son Barty Crouch Jr, Transfigurated into a bone before being buried', 48, 'Jimmy Kiddell', 20, 'Troll Chest', CAST('1992-01-24' AS Date), CAST(11137.18 AS Decimal(8, 2)), CAST(3.48 AS Decimal(5, 2)), CAST(74.00 AS Decimal(8, 2)), CAST('1992-02-17' AS Date), 0)
	,(30, 'Bartemius', 'Barty', 'Death Eater, credited with facilitating the return of Lord Voldemort, received a Dementor''s Kiss, used Polyjuice Potion to impersonate Alastor Moody', 69, 'Arturo Cephalopos', 25, 'Human Pride', CAST('1984-08-03' AS Date), CAST(615.09 AS Decimal(8, 2)), CAST(29.72 AS Decimal(5, 2)), CAST(36.00 AS Decimal(8, 2)), CAST('1984-11-18' AS Date), 1)
	,(31, 'John', 'Dawlish', '', 30, 'Death', 19, 'Venomous Tongue', CAST('1984-09-14' AS Date), CAST(45046.67 AS Decimal(8, 2)), CAST(9.80 AS Decimal(5, 2)), CAST(93.00 AS Decimal(8, 2)), CAST('1985-07-11' AS Date), 1)
	,(32, 'Fleur', 'Delacour', 'French student who participated in the Triwizard Tournament representing Beauxbatons, later wed Bill Weasley.', 49, 'Antioch Peverell', 13, 'Blue Phoenix', CAST('1982-07-24' AS Date), CAST(33063.59 AS Decimal(8, 2)), CAST(23.49 AS Decimal(5, 2)), CAST(67.00 AS Decimal(8, 2)), CAST('1982-12-08' AS Date), 1)
	,(33, 'Gabrielle', 'Delacour', 'Younger sister of Fleur Delacour, saved by Harry in the Triwizard Tournament', 66, 'Ollivander family', 14, 'Troll Chest', CAST('1993-11-24' AS Date), CAST(9488.33 AS Decimal(8, 2)), CAST(19.45 AS Decimal(5, 2)), CAST(22.00 AS Decimal(8, 2)), CAST('1994-06-21' AS Date), 0)
	,(34, 'Dedalus', 'Diggle', 'Member of the Order of the Phoenix who took the Dursleys into hiding', 39, 'Mykew Grerovitch', 26, 'Human Pride', CAST('1980-10-10' AS Date), CAST(45456.26 AS Decimal(8, 2)), CAST(15.85 AS Decimal(5, 2)), CAST(85.00 AS Decimal(8, 2)), CAST('1981-06-02' AS Date), 1)
	,(35, 'Amos', 'Digry', 'Works for the Department for the Regulation and Control of Magical Creatures, father of Cedric Digry', 54, 'Jimmy Kiddell', 17, 'Venomous Tongue', CAST('1985-01-27' AS Date), CAST(17997.81 AS Decimal(8, 2)), CAST(9.87 AS Decimal(5, 2)), CAST(41.00 AS Decimal(8, 2)), CAST('1985-02-20' AS Date), 1)
	,(36, 'Cedric', 'Digry', 'Hufflepuff student two years above Harry, school prefect, Quidditch Seeker and captain, co-winner of the Triwizard Tournament', 19, 'Arturo Cephalopos', 27, 'Blue Phoenix', CAST('1981-01-13' AS Date), CAST(16443.96 AS Decimal(8, 2)), CAST(1.12 AS Decimal(5, 2)), CAST(37.00 AS Decimal(8, 2)), CAST('1982-01-14' AS Date), 1)
	,(37, 'Elphias', 'Doge', 'School friend of Albus Dumbledore', 59, 'Death', 24, 'Troll Chest', CAST('1982-07-07' AS Date), CAST(32356.08 AS Decimal(8, 2)), CAST(9.68 AS Decimal(5, 2)), CAST(37.00 AS Decimal(8, 2)), CAST('1983-06-11' AS Date), 1)
	,(38, 'Antonin', 'Dolohov', 'Death Eater who killed Fabian Prewett, Gideon Prewett, and Remus Lupin.', 28, 'Antioch Peverell', 23, 'Human Pride', CAST('1991-02-28' AS Date), CAST(5585.72 AS Decimal(8, 2)), CAST(21.16 AS Decimal(5, 2)), CAST(36.00 AS Decimal(8, 2)), CAST('1991-04-16' AS Date), 0)
	,(39, 'Aberforth', 'Dumbledore', 'Brother of Albus and Ariana Dumbledore, owner of the Hog''s Head', 49, 'Ollivander family', 11, 'Venomous Tongue', CAST('1991-04-02' AS Date), CAST(22349.31 AS Decimal(8, 2)), CAST(9.72 AS Decimal(5, 2)), CAST(81.00 AS Decimal(8, 2)), CAST('1992-02-21' AS Date), 0)
	,(40, 'Albus', 'Dumbledore', 'Hogwarts Headmaster in Harry Potter''s time, Transfiguration professor in Tom Riddle''s time, founder of the Order of the Phoenix.', 50, 'Mykew Grerovitch', 10, 'Blue Phoenix', CAST('1992-12-18' AS Date), CAST(21106.66 AS Decimal(8, 2)), CAST(15.75 AS Decimal(5, 2)), CAST(93.00 AS Decimal(8, 2)), CAST('1993-12-07' AS Date), 0)
	,(41, 'Ariana', 'Dumbledore', '', 27, 'Jimmy Kiddell', 22, 'Troll Chest', CAST('1980-07-26' AS Date), CAST(27191.21 AS Decimal(8, 2)), CAST(11.67 AS Decimal(5, 2)), CAST(13.00 AS Decimal(8, 2)), CAST('1981-06-12' AS Date), 1)
	,(42, 'Dudley', 'Dursley', 'Muggle son of Vernon Dursley and Petunia Evans, first cousin of Harry Potter', 15, 'Arturo Cephalopos', 29, 'Human Pride', CAST('1994-10-07' AS Date), CAST(49767.47 AS Decimal(8, 2)), CAST(21.73 AS Decimal(5, 2)), CAST(40.00 AS Decimal(8, 2)), CAST('1995-04-01' AS Date), 0)
	,(43, 'Marjorie', 'Marge', 'Muggle sister of Vernon Dursley, breeds bulldogs, her favourite one named Ripper.', 65, 'Death', 25, 'Venomous Tongue', CAST('1994-01-05' AS Date), CAST(909.41 AS Decimal(8, 2)), CAST(13.29 AS Decimal(5, 2)), CAST(14.00 AS Decimal(8, 2)), CAST('1994-04-14' AS Date), 0)
	,(44, 'Petunia', 'Dursley', 'Harry''s aunt, the sister of his mother Lily. Married to Vernon Dursley and mother of Dudley Dursley', 27, 'Ollivander family', 12, 'Blue Phoenix', CAST('1994-05-15' AS Date), CAST(36558.54 AS Decimal(8, 2)), CAST(19.54 AS Decimal(5, 2)), CAST(57.00 AS Decimal(8, 2)), CAST('1994-09-02' AS Date), 0)
	,(45, 'Vernon', 'Dursley', 'Harry Potter''s muggle uncle, married to his aunt Petunia and father of Dudley Dursley.', 22, 'Mykew Grerovitch', 22, 'Troll Chest', CAST('1983-07-28' AS Date), CAST(6498.38 AS Decimal(8, 2)), CAST(11.41 AS Decimal(5, 2)), CAST(44.00 AS Decimal(8, 2)), CAST('1984-01-08' AS Date), 1)
	,(46, 'Marietta', 'Edgecombe', 'Ravenclaw student one year above Harry, member of Dumbledore''s Army', 17, 'Jimmy Kiddell', 16, 'Human Pride', CAST('1993-06-10' AS Date), CAST(13938.86 AS Decimal(8, 2)), CAST(9.44 AS Decimal(5, 2)), CAST(16.00 AS Decimal(8, 2)), CAST('1993-07-16' AS Date), 0)
	,(47, 'Everard', '', 'Former Headmaster of Hogwarts, a particularly famous wizard, whose portrait hangs in many institutions, including the Ministry of Magic', 54, 'Arturo Cephalopos', 30, 'Venomous Tongue', CAST('1984-03-31' AS Date), CAST(31293.40 AS Decimal(8, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(77.00 AS Decimal(8, 2)), CAST('1984-08-31' AS Date), 1)
	,(48, 'Arabella', 'Figg', 'Squib neighbour of the Dursleys'', member of the Order of the Phoenix.', 59, 'Death', 28, 'Blue Phoenix', CAST('1986-05-09' AS Date), CAST(40953.48 AS Decimal(8, 2)), CAST(12.53 AS Decimal(5, 2)), CAST(71.00 AS Decimal(8, 2)), CAST('1986-05-15' AS Date), 1)
	,(49, 'Argus', 'Filch', 'Squib caretaker of Hogwarts', 67, 'Ollivander family', 10, 'Troll Chest', CAST('1982-07-12' AS Date), CAST(21519.32 AS Decimal(8, 2)), CAST(6.94 AS Decimal(5, 2)), CAST(28.00 AS Decimal(8, 2)), CAST('1983-01-18' AS Date), 1)
	,(50, 'Justin', 'Finch-Fletchley', 'Muggle-born Hufflepuff student in Harry''s year, a member of Dumbledore''s Army.', 61, 'Mykew Grerovitch', 28, 'Human Pride', CAST('1987-04-02' AS Date), CAST(40613.55 AS Decimal(8, 2)), CAST(0.93 AS Decimal(5, 2)), CAST(67.00 AS Decimal(8, 2)), CAST('1987-04-04' AS Date), 1)
	,(51, 'Seamus', 'Finnigan', 'Irish Gryffindor student in Harry''s year, a member of Dumbledore''s Army best friend of Dean Thomas.', 35, 'Jimmy Kiddell', 25, 'Venomous Tongue', CAST('1993-12-26' AS Date), CAST(43680.93 AS Decimal(8, 2)), CAST(30.44 AS Decimal(5, 2)), CAST(66.00 AS Decimal(8, 2)), CAST('1994-07-08' AS Date), 0)
	,(52, 'Marcus', 'Flint', 'Slytherin sixth year Quidditch captain', 57, 'Arturo Cephalopos', 30, 'Blue Phoenix', CAST('1988-02-06' AS Date), CAST(346.16 AS Decimal(8, 2)), CAST(30.17 AS Decimal(5, 2)), CAST(20.00 AS Decimal(8, 2)), CAST('1988-07-31' AS Date), 1)
	,(53, 'Nicolas', 'Flamel', 'alchemist, the only known creator of the Philosopher''s Stone.', 42, 'Death', 27, 'Troll Chest', CAST('1990-01-02' AS Date), CAST(31483.33 AS Decimal(8, 2)), CAST(23.72 AS Decimal(5, 2)), CAST(26.00 AS Decimal(8, 2)), CAST('1990-08-27' AS Date), 0)
	,(54, 'Mundungus', 'Fletcher', 'Common thief and shifty member of the Order of the Phoenix', 73, 'Antioch Peverell', 29, 'Human Pride', CAST('1993-11-02' AS Date), CAST(42130.06 AS Decimal(8, 2)), CAST(17.24 AS Decimal(5, 2)), CAST(68.00 AS Decimal(8, 2)), CAST('1994-03-21' AS Date), 0)
	,(55, 'Filius', 'Flitwick', 'Charms professor at Hogwarts and Head of Ravenclaw', 34, 'Ollivander family', 28, 'Venomous Tongue', CAST('1990-07-14' AS Date), CAST(33656.19 AS Decimal(8, 2)), CAST(21.72 AS Decimal(5, 2)), CAST(24.00 AS Decimal(8, 2)), CAST('1990-08-17' AS Date), 0)
	,(56, 'Cornelius', 'Fudge', 'Minister for Magic in the first five books, sacked when he denied Lord Voldemort''s return for a year.', 15, 'Mykew Grerovitch', 22, 'Blue Phoenix', CAST('1990-03-08' AS Date), CAST(48394.70 AS Decimal(8, 2)), CAST(1.00 AS Decimal(5, 2)), CAST(46.00 AS Decimal(8, 2)), CAST('1991-02-06' AS Date), 0)
	,(57, 'Marvolo', 'Gaunt', 'Pure-blood father of Merope and Morfin Gaunt, grandfather of Tom Marvolo Riddle.', 41, 'Antioch Peverell', 14, 'Troll Chest', CAST('1981-04-12' AS Date), CAST(22895.49 AS Decimal(8, 2)), CAST(0.15 AS Decimal(5, 2)), CAST(89.00 AS Decimal(8, 2)), CAST('1981-09-20' AS Date), 1)
	,(58, 'Merope', 'Gaunt', 'Daughter of Marvolo Gaunt, sister of Morfin Gaunt, wife of Tom Riddle Sr, mother of Tom Marvolo Riddle/Lord Voldemort, died after childbirth, named for Merope, one of the Pleiades, who married a mortal[1]', 15, 'Ollivander family', 25, 'Human Pride', CAST('1992-03-13' AS Date), CAST(20809.21 AS Decimal(8, 2)), CAST(18.62 AS Decimal(5, 2)), CAST(19.00 AS Decimal(8, 2)), CAST('1993-02-08' AS Date), 0)
	,(59, 'Morfin', 'Gaunt', 'Son of Marvolo Gaunt, brother of Merope Gaunt, uncle of Tom Marvolo Riddle, framed by his nephew for Muggle killings.', 45, 'Mykew Grerovitch', 25, 'Venomous Tongue', CAST('1994-05-03' AS Date), CAST(33175.63 AS Decimal(8, 2)), CAST(20.71 AS Decimal(5, 2)), CAST(14.00 AS Decimal(8, 2)), CAST('1995-03-24' AS Date), 0)
	,(60, 'Anthony', 'ldstein', 'Ravenclaw student in Harry''s year, member of Dumbledore''s Army', 34, 'Jimmy Kiddell', 26, 'Blue Phoenix', CAST('1980-05-11' AS Date), CAST(5264.16 AS Decimal(8, 2)), CAST(29.66 AS Decimal(5, 2)), CAST(4.00 AS Decimal(8, 2)), CAST('1980-05-22' AS Date), 1)
	,(61, 'yle', 'Sr', 'Death Eater, father of Grery yle', 65, 'Arturo Cephalopos', 31, 'Troll Chest', CAST('1981-05-01' AS Date), CAST(42520.28 AS Decimal(8, 2)), CAST(4.72 AS Decimal(5, 2)), CAST(75.00 AS Decimal(8, 2)), CAST('1982-03-30' AS Date), 1)
	,(62, 'Grery', 'yle', 'Slytherin student in Harry''s year, Slytherin Quidditch Beater, a member of the Inquisitorial Squad.', 51, 'Death', 25, 'Human Pride', CAST('1983-04-06' AS Date), CAST(22014.91 AS Decimal(8, 2)), CAST(21.61 AS Decimal(5, 2)), CAST(33.00 AS Decimal(8, 2)), CAST('1984-02-20' AS Date), 1)
	,(63, 'Hermione', 'Granger', 'Muggle-born Gryffindor student in Harry''s year, one of Harry''s best friends, founder of Dumbledore''s Army, Gryffindor Prefect', 18, 'Antioch Peverell', 16, 'Venomous Tongue', CAST('1980-11-17' AS Date), CAST(20232.87 AS Decimal(8, 2)), CAST(17.54 AS Decimal(5, 2)), CAST(27.00 AS Decimal(8, 2)), CAST('1981-01-13' AS Date), 1)
	,(64, 'Grerovitch', '', 'highly regarded East European wand-maker.', 28, 'Death', 22, 'Blue Phoenix', CAST('1992-07-18' AS Date), CAST(44377.51 AS Decimal(8, 2)), CAST(22.05 AS Decimal(5, 2)), CAST(80.00 AS Decimal(8, 2)), CAST('1992-09-01' AS Date), 0)
	,(65, 'Fenrir', 'Greyback', 'Werewolf, infected Remus Lupin, maimed Bill Weasley and wounded Lavender Brown.', 72, 'Antioch Peverell', 11, 'Troll Chest', CAST('1991-09-05' AS Date), CAST(15747.72 AS Decimal(8, 2)), CAST(18.22 AS Decimal(5, 2)), CAST(94.00 AS Decimal(8, 2)), CAST('1992-05-21' AS Date), 0)
	,(66, 'Gellert', 'Grindelwald', 'Dark Wizard, friend, and later rival, of Albus Dumbledore who defeated him in the 1940s.', 52, 'Ollivander family', 20, 'Human Pride', CAST('1985-04-16' AS Date), CAST(12681.80 AS Decimal(8, 2)), CAST(14.28 AS Decimal(5, 2)), CAST(19.00 AS Decimal(8, 2)), CAST('1985-12-27' AS Date), 1)
	,(67, 'Wilhelmina', 'Grubbly-Plank', 'Substitute Care of Magical Creatures professor during Harry''s fourth year', 29, 'Mykew Grerovitch', 18, 'Venomous Tongue', CAST('1980-08-19' AS Date), CAST(21263.21 AS Decimal(8, 2)), CAST(5.66 AS Decimal(5, 2)), CAST(76.00 AS Decimal(8, 2)), CAST('1980-08-21' AS Date), 1)
	,(68, 'dric', 'Gryffindor', 'One of the four founders of Hogwarts', 24, 'Jimmy Kiddell', 16, 'Blue Phoenix', CAST('1991-06-06' AS Date), CAST(30425.03 AS Decimal(8, 2)), CAST(22.28 AS Decimal(5, 2)), CAST(89.00 AS Decimal(8, 2)), CAST('1991-09-13' AS Date), 0)
	,(69, 'Rubeus', 'Hagrid', 'Half-giant keeper of Keys and Grounds at Hogwarts, Care of Magical Creatures professor starting from Harry''s third year, a member of the Order of the Phoenix. Once a Hogwarts student, Hagrid was expelled in his third year.', 15, 'Death', 14, 'Troll Chest', CAST('1983-02-04' AS Date), CAST(29087.26 AS Decimal(8, 2)), CAST(19.94 AS Decimal(5, 2)), CAST(94.00 AS Decimal(8, 2)), CAST('1983-02-18' AS Date), 1)
	,(70, 'Rolanda', 'Hooch', 'Hogwarts flying instructor, Quidditch referee', 38, 'Antioch Peverell', 29, 'Human Pride', CAST('1989-05-05' AS Date), CAST(30985.51 AS Decimal(8, 2)), CAST(8.64 AS Decimal(5, 2)), CAST(33.00 AS Decimal(8, 2)), CAST('1989-07-03' AS Date), 0)
	,(71, 'Mafalda', 'Hopkirk', 'Witch who works in the Ministry of Magic, impersonated by Hermione Granger in Deathly Hallows.', 63, 'Ollivander family', 23, 'Venomous Tongue', CAST('1980-08-27' AS Date), CAST(39189.95 AS Decimal(8, 2)), CAST(12.73 AS Decimal(5, 2)), CAST(46.00 AS Decimal(8, 2)), CAST('1981-07-26' AS Date), 1)
	,(72, 'Helga', 'Hufflepuff', 'One of the four founders of Hogwarts, ancestor of Hepzibah Smith', 72, 'Mykew Grerovitch', 16, 'Blue Phoenix', CAST('1987-02-12' AS Date), CAST(25971.83 AS Decimal(8, 2)), CAST(23.85 AS Decimal(5, 2)), CAST(74.00 AS Decimal(8, 2)), CAST('1987-06-02' AS Date), 1)
	,(73, 'Angelina', 'Johnson', 'Gryffindor student two years above Harry, Quidditch Chaser and later captain', 70, 'Jimmy Kiddell', 21, 'Troll Chest', CAST('1984-04-04' AS Date), CAST(17479.62 AS Decimal(8, 2)), CAST(3.20 AS Decimal(5, 2)), CAST(39.00 AS Decimal(8, 2)), CAST('1984-08-25' AS Date), 1)
	,(74, 'Lee', 'Jordan', 'Gryffindor student two years above Harry, Hogwarts Quidditch commentator, od friend of Fred and George Weasley at Hogwarts', 67, 'Arturo Cephalopos', 26, 'Human Pride', CAST('1994-07-28' AS Date), CAST(11937.54 AS Decimal(8, 2)), CAST(17.30 AS Decimal(5, 2)), CAST(39.00 AS Decimal(8, 2)), CAST('1994-12-23' AS Date), 0)
	,(75, 'Bertha', 'Jorkins', '', 58, 'Death', 11, 'Venomous Tongue', CAST('1987-07-25' AS Date), CAST(42482.75 AS Decimal(8, 2)), CAST(30.46 AS Decimal(5, 2)), CAST(51.00 AS Decimal(8, 2)), CAST('1988-03-20' AS Date), 1)
	,(76, 'Ir', 'Karkaroff', 'Reformed Death Eater, Headmaster of Durmstrang.', 31, 'Mykew Grerovitch', 25, 'Blue Phoenix', CAST('1986-12-30' AS Date), CAST(21847.43 AS Decimal(8, 2)), CAST(12.66 AS Decimal(5, 2)), CAST(88.00 AS Decimal(8, 2)), CAST('1987-09-24' AS Date), 1)
	,(77, 'Viktor', 'Krum', 'Durmstrang student, Bulgarian Quidditch Seeker, participated in the Triwizard Tournament.', 37, 'Jimmy Kiddell', 28, 'Troll Chest', CAST('1980-12-28' AS Date), CAST(31596.15 AS Decimal(8, 2)), CAST(21.29 AS Decimal(5, 2)), CAST(35.00 AS Decimal(8, 2)), CAST('1981-09-02' AS Date), 1)
	,(78, 'Bellatrix', 'Lestrange', 'Death Eater, sister of Narcissa Malfoy and Andromeda Tonks, cousin of Sirius and Regulus Black, she tortured Frank and Alice Longbottom into insanity.', 14, 'Arturo Cephalopos', 12, 'Human Pride', CAST('1983-05-09' AS Date), CAST(37635.01 AS Decimal(8, 2)), CAST(5.85 AS Decimal(5, 2)), CAST(43.00 AS Decimal(8, 2)), CAST('1983-08-21' AS Date), 1)
	,(79, 'Rabastan', 'Lestrange', 'Death Eater, brother of Rodolphus Lestrange', 55, 'Death', 29, 'Venomous Tongue', CAST('1984-10-22' AS Date), CAST(39468.45 AS Decimal(8, 2)), CAST(23.33 AS Decimal(5, 2)), CAST(69.00 AS Decimal(8, 2)), CAST('1985-04-23' AS Date), 1)
	,(80, 'Rodolphus', 'Lestrange', 'Death Eater, brother of Rabastan Lestrange, husband of Bellatrix Lestrange', 71, 'Antioch Peverell', 23, 'Blue Phoenix', CAST('1982-03-26' AS Date), CAST(1302.18 AS Decimal(8, 2)), CAST(0.02 AS Decimal(5, 2)), CAST(75.00 AS Decimal(8, 2)), CAST('1982-08-25' AS Date), 1)
	,(81, 'Gilderoy', 'Lockhart', 'Fraudulent celebrity author, Defence Against the Dark Arts teacher.', 60, 'Death', 18, 'Troll Chest', CAST('1980-10-19' AS Date), CAST(15745.69 AS Decimal(8, 2)), CAST(23.18 AS Decimal(5, 2)), CAST(16.00 AS Decimal(8, 2)), CAST('1981-07-06' AS Date), 1)
	,(82, 'Alice', 'Longbottom', 'Wife of Frank Longbottom, mother of Neville Longbottom, member of the original Order of the Phoenix, Auror, tortured into insanity by Bellatrix Lestrange along with her husband', 40, 'Antioch Peverell', 17, 'Human Pride', CAST('1985-01-26' AS Date), CAST(4817.78 AS Decimal(8, 2)), CAST(29.58 AS Decimal(5, 2)), CAST(79.00 AS Decimal(8, 2)), CAST('1985-02-10' AS Date), 1)
	,(83, 'Augusta', 'Longbottom', 'Mother of Frank Longbottom and grandmother of Neville Longbottom', 29, 'Ollivander family', 22, 'Venomous Tongue', CAST('1982-08-17' AS Date), CAST(28036.29 AS Decimal(8, 2)), CAST(16.55 AS Decimal(5, 2)), CAST(87.00 AS Decimal(8, 2)), CAST('1983-07-27' AS Date), 1)
	,(84, 'Frank', 'Longbottom', 'Father of Neville Longbottom, a member of the original Order of the Phoenix, Auror, tortured into insanity by Bellatrix Lestrange along with his wife.', 24, 'Mykew Grerovitch', 31, 'Blue Phoenix', CAST('1991-06-23' AS Date), CAST(31439.10 AS Decimal(8, 2)), CAST(11.55 AS Decimal(5, 2)), CAST(57.00 AS Decimal(8, 2)), CAST('1991-09-09' AS Date), 0)
	,(85, 'Neville', 'Longbottom', 'Gryffindor student in Harry''s year, a member of Dumbledore''s Army.', 47, 'Jimmy Kiddell', 20, 'Troll Chest', CAST('1992-07-19' AS Date), CAST(1369.52 AS Decimal(8, 2)), CAST(21.04 AS Decimal(5, 2)), CAST(1.00 AS Decimal(8, 2)), CAST('1993-05-13' AS Date), 0)
	,(86, 'Luna', 'Loveod', 'Ravenclaw student one year below Harry, a member of Dumbledore''s Army.', 14, 'Arturo Cephalopos', 21, 'Human Pride', CAST('1986-12-21' AS Date), CAST(9014.64 AS Decimal(8, 2)), CAST(2.83 AS Decimal(5, 2)), CAST(24.00 AS Decimal(8, 2)), CAST('1987-10-29' AS Date), 1)
	,(87, 'Xenophilius', 'Loveod', 'Father of Luna Loveod, and editor of The Quibbler.', 25, 'Death', 16, 'Venomous Tongue', CAST('1992-08-09' AS Date), CAST(5908.36 AS Decimal(8, 2)), CAST(6.99 AS Decimal(5, 2)), CAST(1.00 AS Decimal(8, 2)), CAST('1992-11-19' AS Date), 0)
	,(88, 'Remus', 'Lupin', 'Gryffindor student before Harry''s time, Marauder, a friend of James Potter, werewolf, Professor of Defence Against the Dark Arts in Harry''s third year, a member of the Order of the Phoenix.', 19, 'Death', 11, 'Blue Phoenix', CAST('1982-05-08' AS Date), CAST(17821.66 AS Decimal(8, 2)), CAST(19.64 AS Decimal(5, 2)), CAST(45.00 AS Decimal(8, 2)), CAST('1982-06-04' AS Date), 1)
	,(89, 'Walden', 'Macnair', 'The Committee of Disposal of Dangerous Creatures''s executioner, also a Death-Eater', 48, 'Antioch Peverell', 29, 'Troll Chest', CAST('1986-09-22' AS Date), CAST(23216.19 AS Decimal(8, 2)), CAST(29.39 AS Decimal(5, 2)), CAST(46.00 AS Decimal(8, 2)), CAST('1986-11-01' AS Date), 1)
	,(90, 'Draco', 'Malfoy', 'Slytherin student in Harry''s year, Slytherin Quidditch Seeker, school prefect, member of the Inquisitorial Squad, Death Eater', 18, 'Ollivander family', 14, 'Human Pride', CAST('1989-12-02' AS Date), CAST(33253.04 AS Decimal(8, 2)), CAST(8.37 AS Decimal(5, 2)), CAST(7.00 AS Decimal(8, 2)), CAST('1990-05-07' AS Date), 0)
	,(91, 'Lucius', 'Malfoy', 'Draco Malfoy''s father, an influential Death-Eater, and, early in the series, vernor of Hogwarts', 25, 'Mykew Grerovitch', 22, 'Venomous Tongue', CAST('1981-07-29' AS Date), CAST(36572.61 AS Decimal(8, 2)), CAST(2.45 AS Decimal(5, 2)), CAST(5.00 AS Decimal(8, 2)), CAST('1981-11-19' AS Date), 1)
	,(92, 'Narcissa', 'Malfoy', 'Lucius Malfoy''s wife and Draco Malfoy''s mother, sister of Bellatrix Lestrange.', 17, 'Jimmy Kiddell', 18, 'Blue Phoenix', CAST('1988-06-16' AS Date), CAST(1169.86 AS Decimal(8, 2)), CAST(25.09 AS Decimal(5, 2)), CAST(98.00 AS Decimal(8, 2)), CAST('1988-07-17' AS Date), 1)
	,(93, 'Madam', 'Malkin', 'Clothes shop owner at Dian Alley', 23, 'Arturo Cephalopos', 15, 'Troll Chest', CAST('1985-07-17' AS Date), CAST(40137.28 AS Decimal(8, 2)), CAST(8.17 AS Decimal(5, 2)), CAST(45.00 AS Decimal(8, 2)), CAST('1986-06-13' AS Date), 1)
	,(94, 'Olympe', 'Maxime', 'Half-giantess, Headmistress of Beauxbatons', 56, 'Death', 22, 'Human Pride', CAST('1986-02-22' AS Date), CAST(27473.95 AS Decimal(8, 2)), CAST(22.31 AS Decimal(5, 2)), CAST(39.00 AS Decimal(8, 2)), CAST('1986-05-22' AS Date), 1)
	,(95, 'Ernie', 'Macmillan', 'Hufflepuff student in Harry''s year, school prefect, member of Dumbledore''s Army', 63, 'Arturo Cephalopos', 13, 'Venomous Tongue', CAST('1989-04-15' AS Date), CAST(18960.62 AS Decimal(8, 2)), CAST(13.15 AS Decimal(5, 2)), CAST(22.00 AS Decimal(8, 2)), CAST('1989-12-12' AS Date), 0)
	,(96, 'Minerva', 'Mcnagall', 'Hogwarts Transfiguration professor, Head of Gryffindor House, Deputy Headmistress of Hogwarts, a member of the Order of the Phoenix.', 29, 'Death', 16, 'Blue Phoenix', CAST('1988-07-08' AS Date), CAST(7298.35 AS Decimal(8, 2)), CAST(15.19 AS Decimal(5, 2)), CAST(39.00 AS Decimal(8, 2)), CAST('1988-12-24' AS Date), 1)
	,(97, 'Alastor', 'Mad-Eye', 'Retired Auror, member of the Order of the Phoenix, impersonated by Barty Crouch Jr. in ''The blet of Fire''', 27, 'Mykew Grerovitch', 21, 'Troll Chest', CAST('1987-02-17' AS Date), CAST(8294.06 AS Decimal(8, 2)), CAST(18.27 AS Decimal(5, 2)), CAST(90.00 AS Decimal(8, 2)), CAST('1988-01-08' AS Date), 1)
	,(98, 'Theodore', 'Nott', 'Slytherin student in the same year as Harry Potter. Nott is one of the few students who can see Thestrals, suggesting that he has witnessed a death at some point. His father is a Death Eater and described as an elderly widower.', 17, 'Jimmy Kiddell', 26, 'Human Pride', CAST('1982-01-20' AS Date), CAST(49041.09 AS Decimal(8, 2)), CAST(26.22 AS Decimal(5, 2)), CAST(15.00 AS Decimal(8, 2)), CAST('1982-04-14' AS Date), 1)
	,(99, 'Garrick', 'Ollivander', 'Wandmaker, owner of Ollivanders shop.', 72, 'Arturo Cephalopos', 27, 'Venomous Tongue', CAST('1994-07-01' AS Date), CAST(41627.25 AS Decimal(8, 2)), CAST(30.61 AS Decimal(5, 2)), CAST(22.00 AS Decimal(8, 2)), CAST('1994-10-11' AS Date), 0)
	,(100, 'Pansy', 'Parkinson', 'Slytherin student in Harry''s year, school prefect, a member of the Inquisitorial Squad, Draco Malfoy''s girlfriend for some time.', 35, 'Death', 21, 'Blue Phoenix', CAST('1994-01-20' AS Date), CAST(11941.54 AS Decimal(8, 2)), CAST(29.19 AS Decimal(5, 2)), CAST(71.00 AS Decimal(8, 2)), CAST('1994-05-29' AS Date), 0)
	,(101, 'Padma', 'Patil', 'Ravenclaw student in Harry''s year, identical twin sister of Gryffindor Parvati Patil, a member of Dumbledore''s Army.', 37, 'Antioch Peverell', 22, 'Troll Chest', CAST('1980-05-09' AS Date), CAST(26117.57 AS Decimal(8, 2)), CAST(9.05 AS Decimal(5, 2)), CAST(47.00 AS Decimal(8, 2)), CAST('1981-03-30' AS Date), 1)
	,(102, 'Parvati', 'Patil', 'Gryffindor student in Harry''s year, identical twin sister of Ravenclaw Padma Patil, a member of Dumbledore''s Army.', 55, 'Death', 25, 'Human Pride', CAST('1990-01-12' AS Date), CAST(11798.51 AS Decimal(8, 2)), CAST(1.00 AS Decimal(5, 2)), CAST(71.00 AS Decimal(8, 2)), CAST('1990-03-19' AS Date), 0)
	,(103, 'Peter', 'Pettigrew', 'Former school friend of James Potter, Sirius Black and Remus Lupin. Betrays James and Lily Potter. Death Eater, an unregistered animagus, Pettigrew is first introduced as a rat known as Scabbers.', 41, 'Jimmy Kiddell', 29, 'Venomous Tongue', CAST('1993-03-12' AS Date), CAST(43424.70 AS Decimal(8, 2)), CAST(19.06 AS Decimal(5, 2)), CAST(87.00 AS Decimal(8, 2)), CAST('1993-07-06' AS Date), 0)
	,(104, 'Antioch', 'Peverell', 'Original owner of The Elder Wand in The Tale of the Three Brothers.', 49, 'Arturo Cephalopos', 26, 'Blue Phoenix', CAST('1989-01-19' AS Date), CAST(36394.90 AS Decimal(8, 2)), CAST(20.56 AS Decimal(5, 2)), CAST(18.00 AS Decimal(8, 2)), CAST('1989-08-09' AS Date), 0)
	,(105, 'Cadmus', 'Peverell', 'Original owner of The Resurrection Stone in The Tale of the Three Brothers', 36, 'Death', 20, 'Troll Chest', CAST('1983-12-16' AS Date), CAST(22327.50 AS Decimal(8, 2)), CAST(30.46 AS Decimal(5, 2)), CAST(82.00 AS Decimal(8, 2)), CAST('1984-03-20' AS Date), 1)
	,(106, 'Ignotus', 'Peverell', 'Original owner of The Invisibility Cloak in The Tale of the Three Brothers.', 43, 'Ollivander family', 29, 'Human Pride', CAST('1983-06-10' AS Date), CAST(35261.39 AS Decimal(8, 2)), CAST(9.39 AS Decimal(5, 2)), CAST(68.00 AS Decimal(8, 2)), CAST('1983-10-05' AS Date), 1)
	,(107, 'Irma', 'Pince', 'Hogwarts librarian', 19, 'Mykew Grerovitch', 17, 'Venomous Tongue', CAST('1984-05-03' AS Date), CAST(12766.45 AS Decimal(8, 2)), CAST(17.02 AS Decimal(5, 2)), CAST(85.00 AS Decimal(8, 2)), CAST('1984-08-05' AS Date), 1)
	,(108, 'Sturgis', 'Podmore', 'Member of the Order of the Phoenix, imprisoned in Azkaban', 64, 'Jimmy Kiddell', 24, 'Blue Phoenix', CAST('1980-04-07' AS Date), CAST(22485.06 AS Decimal(8, 2)), CAST(15.05 AS Decimal(5, 2)), CAST(67.00 AS Decimal(8, 2)), CAST('1981-03-22' AS Date), 1)
	,(109, 'Poppy', 'Pomfrey', 'Hogwarts school nurse', 32, 'Arturo Cephalopos', 23, 'Troll Chest', CAST('1988-04-19' AS Date), CAST(27957.52 AS Decimal(8, 2)), CAST(6.77 AS Decimal(5, 2)), CAST(68.00 AS Decimal(8, 2)), CAST('1988-06-12' AS Date), 1)
	,(110, 'Harry', 'Potter', 'Main character of the series, son of James Potter and Lily Evans, Gryffindor student, Gryffindor Quidditch Seeker and captain, leader of Dumbledore''s Army.', 68, 'Death', 18, 'Human Pride', CAST('1986-09-21' AS Date), CAST(44889.88 AS Decimal(8, 2)), CAST(23.09 AS Decimal(5, 2)), CAST(10.00 AS Decimal(8, 2)), CAST('1986-11-15' AS Date), 1)
	,(111, 'James', 'Potter', 'Harry Potter''s father, a member of the Order of the Phoenix, murdered by Lord Voldemort before the series begins.', 47, 'Ollivander family', 31, 'Venomous Tongue', CAST('1993-06-16' AS Date), CAST(27296.66 AS Decimal(8, 2)), CAST(1.22 AS Decimal(5, 2)), CAST(86.00 AS Decimal(8, 2)), CAST('1993-11-16' AS Date), 0)
	,(112, 'Lily', 'Potter', 'Harry Potter''s mother, a member of the Order of the Phoenix, murdered by Lord Voldemort before the series begins.', 28, 'Antioch Peverell', 13, 'Blue Phoenix', CAST('1984-02-27' AS Date), CAST(21972.24 AS Decimal(8, 2)), CAST(26.11 AS Decimal(5, 2)), CAST(49.00 AS Decimal(8, 2)), CAST('1984-06-16' AS Date), 1)
	,(113, 'Ernest', 'Ernie', '(fl. 1993-1997), also called Ern by Stanley Shunpike, was the driver of the Knight Bus.', 58, 'Ollivander family', 20, 'Troll Chest', CAST('1991-11-05' AS Date), CAST(11948.37 AS Decimal(8, 2)), CAST(16.85 AS Decimal(5, 2)), CAST(99.00 AS Decimal(8, 2)), CAST('1992-07-10' AS Date), 0)
	,(114, 'Quirinus', 'Quirrell', 'Defence Against the Dark Arts professor in Harry''s first year, possessed by Lord Voldemort in Philosopher''s Stone.', 34, 'Mykew Grerovitch', 15, 'Human Pride', CAST('1992-10-17' AS Date), CAST(13212.49 AS Decimal(8, 2)), CAST(5.67 AS Decimal(5, 2)), CAST(55.00 AS Decimal(8, 2)), CAST('1992-12-26' AS Date), 0)
	,(115, 'Helena', 'Ravenclaw/The', 'Daughter of Rowena Ravenclaw, stole her mother''s diadem and hid it, killed by the Bloody Baron and became Ravenclaw''s house ghost.', 62, 'Jimmy Kiddell', 18, 'Venomous Tongue', CAST('1985-10-13' AS Date), CAST(1238.51 AS Decimal(8, 2)), CAST(10.17 AS Decimal(5, 2)), CAST(57.00 AS Decimal(8, 2)), CAST('1985-12-30' AS Date), 1)
	,(116, 'Rowena', 'Ravenclaw', 'Co-founder of Hogwarts, mother of Helena Ravenclaw', 40, 'Arturo Cephalopos', 28, 'Blue Phoenix', CAST('1994-10-16' AS Date), CAST(16236.00 AS Decimal(8, 2)), CAST(11.11 AS Decimal(5, 2)), CAST(26.00 AS Decimal(8, 2)), CAST('1995-04-25' AS Date), 0)
	,(117, 'Mary', 'Riddle', 'Muggle wife of Thomas Riddle, mother of Tom Riddle Sr, mother-in-law of Merope Gaunt, grandmother of Tom Marvolo Riddle/Lord Voldemort, killed by her grandson', 24, 'Death', 12, 'Troll Chest', CAST('1982-06-14' AS Date), CAST(43375.01 AS Decimal(8, 2)), CAST(23.97 AS Decimal(5, 2)), CAST(82.00 AS Decimal(8, 2)), CAST('1982-08-30' AS Date), 1)
	,(118, 'Thomas', 'Riddle', 'Muggle husband of Mary Riddle, father of Tom Riddle Sr, grandfather of Tom Marvolo Riddle/Lord Voldemort, killed by his grandson.', 36, 'Arturo Cephalopos', 28, 'Human Pride', CAST('1989-05-14' AS Date), CAST(24304.57 AS Decimal(8, 2)), CAST(21.47 AS Decimal(5, 2)), CAST(86.00 AS Decimal(8, 2)), CAST('1989-12-04' AS Date), 0)
	,(119, 'Tom', 'Riddle', 'Muggle husband of Merope Gaunt, father of Tom Marvolo Riddle/Lord Voldemort, son of Thomas and Mary Riddle, killed by his son', 26, 'Death', 23, 'Venomous Tongue', CAST('1990-04-22' AS Date), CAST(44456.65 AS Decimal(8, 2)), CAST(25.24 AS Decimal(5, 2)), CAST(76.00 AS Decimal(8, 2)), CAST('1990-08-03' AS Date), 0)
	,(120, 'Tom', 'Marvolo', 'see Lord Voldemort', 33, 'Mykew Grerovitch', 30, 'Blue Phoenix', CAST('1986-05-20' AS Date), CAST(23897.12 AS Decimal(8, 2)), CAST(29.66 AS Decimal(5, 2)), CAST(23.00 AS Decimal(8, 2)), CAST('1987-01-27' AS Date), 1)
	,(121, 'Demelza', 'Robins', '', 45, 'Mykew Grerovitch', 24, 'Troll Chest', CAST('1988-09-19' AS Date), CAST(8523.42 AS Decimal(8, 2)), CAST(5.34 AS Decimal(5, 2)), CAST(40.00 AS Decimal(8, 2)), CAST('1989-02-21' AS Date), 0)
	,(122, 'Augustus', 'Rookwood', 'Death Eater, spy working in the Department of Mysteries', 26, 'Death', 28, 'Human Pride', CAST('1994-12-06' AS Date), CAST(43137.27 AS Decimal(8, 2)), CAST(13.09 AS Decimal(5, 2)), CAST(61.00 AS Decimal(8, 2)), CAST('1995-01-01' AS Date), 0)
	,(123, 'Albert', 'Runcorn', '', 23, 'Jimmy Kiddell', 12, 'Venomous Tongue', CAST('1982-12-06' AS Date), CAST(47140.32 AS Decimal(8, 2)), CAST(3.77 AS Decimal(5, 2)), CAST(35.00 AS Decimal(8, 2)), CAST('1983-01-13' AS Date), 1)
	,(124, 'Scabior', '', 'Snatcher who captures Harry Potter, Ron Weasley and Hermione Granger in Deathly Hallows.', 23, 'Arturo Cephalopos', 21, 'Blue Phoenix', CAST('1992-06-06' AS Date), CAST(25342.73 AS Decimal(8, 2)), CAST(14.88 AS Decimal(5, 2)), CAST(27.00 AS Decimal(8, 2)), CAST('1993-05-07' AS Date), 0)
	,(125, 'Newt', 'Scamander', 'Author of Fantastic Beasts and Where to Find Them, among other books. Headmaster and, Hufflepuff student at Hogwarts.', 49, 'Death', 24, 'Troll Chest', CAST('1988-02-08' AS Date), CAST(36247.69 AS Decimal(8, 2)), CAST(28.85 AS Decimal(5, 2)), CAST(22.00 AS Decimal(8, 2)), CAST('1988-12-31' AS Date), 1)
	,(126, 'Rufus', 'Scrimgeour', 'Head of the Auror Office, replaces Cornelius Fudge as Minister for Magic.', 61, 'Ollivander family', 13, 'Human Pride', CAST('1987-07-31' AS Date), CAST(39764.02 AS Decimal(8, 2)), CAST(25.14 AS Decimal(5, 2)), CAST(10.00 AS Decimal(8, 2)), CAST('1988-04-03' AS Date), 1)
	,(127, 'Kingsley', 'Shacklebolt', 'Auror, replaces Pius Thicknesse as Minister for Magic, member of the Order of the Phoenix', 33, 'Mykew Grerovitch', 26, 'Venomous Tongue', CAST('1992-03-06' AS Date), CAST(31218.37 AS Decimal(8, 2)), CAST(8.53 AS Decimal(5, 2)), CAST(42.00 AS Decimal(8, 2)), CAST('1993-01-30' AS Date), 0)
	,(128, 'Stan', 'Shunpike', 'Conductor of the Knight Bus, later jailed in Azkaban on suspicions of being a death-eater.', 30, 'Jimmy Kiddell', 22, 'Blue Phoenix', CAST('1992-09-21' AS Date), CAST(19775.78 AS Decimal(8, 2)), CAST(0.14 AS Decimal(5, 2)), CAST(61.00 AS Decimal(8, 2)), CAST('1992-12-07' AS Date), 0)
	,(129, 'Aurora', 'Sinistra', 'Professor and member of the Astronomy Department at Hogwarts, a witch with dark skin, hair, and eyes.', 47, 'Arturo Cephalopos', 22, 'Troll Chest', CAST('1991-06-28' AS Date), CAST(17257.17 AS Decimal(8, 2)), CAST(30.67 AS Decimal(5, 2)), CAST(45.00 AS Decimal(8, 2)), CAST('1992-01-25' AS Date), 0)
	,(130, 'Rita', 'Skeeter', 'Reporter for the Daily Prophet, author of The Life and Lies of Albus Dumbledore, unregistered animagus.', 38, 'Death', 13, 'Human Pride', CAST('1990-04-18' AS Date), CAST(22876.54 AS Decimal(8, 2)), CAST(17.02 AS Decimal(5, 2)), CAST(3.00 AS Decimal(8, 2)), CAST('1990-07-06' AS Date), 0)
	,(131, 'Horace', 'Slughorn', 'Former Potions professor at Hogwarts and Head of Slytherin House who taught Tom Marvolo Riddle and returns to Hogwarts in Harry''s sixth year.', 32, 'Ollivander family', 10, 'Venomous Tongue', CAST('1986-10-30' AS Date), CAST(19165.02 AS Decimal(8, 2)), CAST(7.95 AS Decimal(5, 2)), CAST(76.00 AS Decimal(8, 2)), CAST('1987-09-27' AS Date), 1)
	,(132, 'Salazar', 'Slytherin', 'Co-founder of Hogwarts, Parseltongue, ancestor of the Gaunt family and Lord Voldemort.', 59, 'Antioch Peverell', 28, 'Blue Phoenix', CAST('1980-10-26' AS Date), CAST(1168.22 AS Decimal(8, 2)), CAST(26.55 AS Decimal(5, 2)), CAST(71.00 AS Decimal(8, 2)), CAST('1981-01-30' AS Date), 1)
	,(133, 'Hepzibah', 'Smith', 'Elderly, wealthy antique collector, descendant of Helga Hufflepuff, murdered and robbed by Tom Marvolo Riddle', 30, 'Ollivander family', 12, 'Troll Chest', CAST('1983-05-25' AS Date), CAST(33665.13 AS Decimal(8, 2)), CAST(7.98 AS Decimal(5, 2)), CAST(21.00 AS Decimal(8, 2)), CAST('1983-08-17' AS Date), 1)
	,(134, 'Zacharias', 'Smith', 'Hufflepuff student, a member of Dumbledore''s Army.', 39, 'Antioch Peverell', 15, 'Human Pride', CAST('1985-12-01' AS Date), CAST(45543.40 AS Decimal(8, 2)), CAST(24.78 AS Decimal(5, 2)), CAST(98.00 AS Decimal(8, 2)), CAST('1986-10-29' AS Date), 1)
	,(135, 'Severus', 'Snape', 'Hogwarts, Potions and later Defence Against the Dark Arts professor, Head of Slytherin House, a member of both the Death Eaters and the Order of the Phoenix.', 53, 'Mykew Grerovitch', 15, 'Venomous Tongue', CAST('1992-11-06' AS Date), CAST(17820.90 AS Decimal(8, 2)), CAST(16.53 AS Decimal(5, 2)), CAST(38.00 AS Decimal(8, 2)), CAST('1992-12-20' AS Date), 0)
	,(136, 'Alicia', 'Spinnet', 'Chaser on the Gryffindor Quidditch team, two years above Harry Potter at Hogwarts. Member of Dumbledore''s Army.', 65, 'Jimmy Kiddell', 16, 'Blue Phoenix', CAST('1980-02-06' AS Date), CAST(6269.39 AS Decimal(8, 2)), CAST(3.66 AS Decimal(5, 2)), CAST(77.00 AS Decimal(8, 2)), CAST('1980-03-04' AS Date), 1)
	,(137, 'Pomona', 'Sprout', 'Hogwarts Herbology professor, Head of Hufflepuff House.', 46, 'Arturo Cephalopos', 24, 'Troll Chest', CAST('1993-06-10' AS Date), CAST(16789.73 AS Decimal(8, 2)), CAST(30.80 AS Decimal(5, 2)), CAST(58.00 AS Decimal(8, 2)), CAST('1993-10-07' AS Date), 0)
	,(138, 'Pius', 'Thicknesse', 'Minister for Magic while under the Imperius Curse, later replaced by Kingsley Shacklebolt.', 47, 'Death', 24, 'Human Pride', CAST('1982-06-01' AS Date), CAST(8359.46 AS Decimal(8, 2)), CAST(26.64 AS Decimal(5, 2)), CAST(59.00 AS Decimal(8, 2)), CAST('1983-01-04' AS Date), 1)
	,(139, 'Dean', 'Thomas', 'Gryffindor student in Harry''s year, a member of Dumbledore''s Army, briefly Ginny Weasley''s boyfriend, Gryffindor Quidditch Chaser.', 69, 'Antioch Peverell', 18, 'Venomous Tongue', CAST('1992-12-04' AS Date), CAST(6579.08 AS Decimal(8, 2)), CAST(7.43 AS Decimal(5, 2)), CAST(69.00 AS Decimal(8, 2)), CAST('1993-04-09' AS Date), 0)
	,(140, 'Andromeda', 'Tonks', 'Sister of Bellatrix Lestrange and Narcissa Malfoy, disowned by her family for marrying Muggle-born Ted Tonks, mother of Nymphadora Tonks.', 68, 'Death', 28, 'Blue Phoenix', CAST('1993-02-18' AS Date), CAST(30024.64 AS Decimal(8, 2)), CAST(8.80 AS Decimal(5, 2)), CAST(36.00 AS Decimal(8, 2)), CAST('1993-06-14' AS Date), 0)
	,(141, 'Nymphadora', 'Tonks', 'Daughter of Ted and Andromeda Tonks, Auror and member of the Order of the Phoenix. She marries Remus Lupin, and become the mother of Teddy Lupin.', 18, 'Jimmy Kiddell', 13, 'Troll Chest', CAST('1982-11-25' AS Date), CAST(16724.98 AS Decimal(8, 2)), CAST(22.83 AS Decimal(5, 2)), CAST(37.00 AS Decimal(8, 2)), CAST('1983-09-21' AS Date), 1)
	,(142, 'Ted', 'Tonks', 'Muggle-born husband of Andromeda and father of Nymphadora Tonks.', 19, 'Arturo Cephalopos', 13, 'Human Pride', CAST('1984-03-07' AS Date), CAST(39096.67 AS Decimal(8, 2)), CAST(25.20 AS Decimal(5, 2)), CAST(82.00 AS Decimal(8, 2)), CAST('1984-10-04' AS Date), 1)
	,(143, 'Travers', '', '', 53, 'Death', 24, 'Venomous Tongue', CAST('1984-01-05' AS Date), CAST(25085.58 AS Decimal(8, 2)), CAST(1.95 AS Decimal(5, 2)), CAST(91.00 AS Decimal(8, 2)), CAST('1984-05-27' AS Date), 1)
	,(144, 'Sybill', 'Patricia', 'Hogwarts Divination professor, predicted the prophecy that prompted Lord Voldemort to  after the Potters', 25, 'Ollivander family', 17, 'Blue Phoenix', CAST('1994-07-05' AS Date), CAST(15237.30 AS Decimal(8, 2)), CAST(7.31 AS Decimal(5, 2)), CAST(21.00 AS Decimal(8, 2)), CAST('1994-07-21' AS Date), 0)
	,(145, 'Dolores', 'Jane', 'Senior Undersecretary to the Minister for Magic, Defence Against the Dark Arts professor, Hogwarts High Inquisitor, Headmistress of Hogwarts, who enthusiastically joins in the persecution of half-bloods under Voldermort.', 34, 'Mykew Grerovitch', 30, 'Troll Chest', CAST('1982-09-25' AS Date), CAST(10628.58 AS Decimal(8, 2)), CAST(12.08 AS Decimal(5, 2)), CAST(50.00 AS Decimal(8, 2)), CAST('1983-01-22' AS Date), 1)
	,(146, 'Emmeline', 'Vance', 'a member of the party that brings Harry to Grimmauld Place, a member of the Order of the Phoenix. Described as "A stately looking witch in an emerald green shawl".', 57, 'Jimmy Kiddell', 25, 'Human Pride', CAST('1992-10-30' AS Date), CAST(34993.10 AS Decimal(8, 2)), CAST(29.94 AS Decimal(5, 2)), CAST(82.00 AS Decimal(8, 2)), CAST('1992-11-03' AS Date), 0)
	,(147, 'Romilda', 'Vane', 'Hogwarts student who tried to romance Harry with Chocolate Cauldrons containing a love potion from Weasley''s Wizard Wheezes', 17, 'Mykew Grerovitch', 16, 'Venomous Tongue', CAST('1983-09-06' AS Date), CAST(26267.34 AS Decimal(8, 2)), CAST(16.63 AS Decimal(5, 2)), CAST(100.00 AS Decimal(8, 2)), CAST('1984-04-15' AS Date), 1)
	,(148, 'Septima', 'Vector', 'Arithmancy professor at Hogwarts.', 43, 'Arturo Cephalopos', 26, 'Blue Phoenix', CAST('1981-01-23' AS Date), CAST(6146.94 AS Decimal(8, 2)), CAST(6.57 AS Decimal(5, 2)), CAST(66.00 AS Decimal(8, 2)), CAST('1982-01-22' AS Date), 1)
	,(149, 'Lord', 'Voldemort', 'The villain of the series, the murderer of Harry Potter''s parents and many others in his quest for immortality and absolute power.', 25, 'Death', 31, 'Troll Chest', CAST('1989-04-28' AS Date), CAST(38085.84 AS Decimal(8, 2)), CAST(22.53 AS Decimal(5, 2)), CAST(88.00 AS Decimal(8, 2)), CAST('1989-08-01' AS Date), 0)
	,(150, 'Arthur', 'Weasley', 'Muggle-obsessed Ministry of Magic employee. Husband of Molly Weasley, father of Bill, Charlie, Percy, Fred, George, Ron, and Ginny Weasley, member of the Order of the Phoenix', 65, 'Antioch Peverell', 26, 'Human Pride', CAST('1989-09-05' AS Date), CAST(6647.70 AS Decimal(8, 2)), CAST(15.82 AS Decimal(5, 2)), CAST(23.00 AS Decimal(8, 2)), CAST('1989-09-28' AS Date), 0)
	,(151, 'Bill', 'Weasley', 'Oldest son of Arthur and Molly Weasley, Grintts employee.', 51, 'Death', 30, 'Venomous Tongue', CAST('1988-04-01' AS Date), CAST(11346.57 AS Decimal(8, 2)), CAST(2.63 AS Decimal(5, 2)), CAST(98.00 AS Decimal(8, 2)), CAST('1988-08-03' AS Date), 1)
	,(152, 'Charlie', 'Weasley', 'Second son of Arthur and Molly Weasley, and a member of the Order of the Phoenix, works with drans in Romania.', 21, 'Jimmy Kiddell', 16, 'Blue Phoenix', CAST('1988-11-14' AS Date), CAST(7831.46 AS Decimal(8, 2)), CAST(26.31 AS Decimal(5, 2)), CAST(20.00 AS Decimal(8, 2)), CAST('1989-07-26' AS Date), 0)
	,(153, 'Fred', 'Weasley', 'Son of Arthur and Molly Weasley and identical twin brother of George Weasley, a member of Dumbledore''s Army, Gryffindor Quidditch Beater, co-owner of Weasleys'' Wizard Wheezes, killed in an explosion caused by Augustus Rookwood in the Battle of Hogwarts.', 48, 'Arturo Cephalopos', 18, 'Troll Chest', CAST('1992-02-22' AS Date), CAST(23860.37 AS Decimal(8, 2)), CAST(28.37 AS Decimal(5, 2)), CAST(39.00 AS Decimal(8, 2)), CAST('1992-05-06' AS Date), 0)
	,(154, 'George', 'Weasley', 'Son of Arthur and Molly Weasley and identical twin brother of Fred Weasley, member of Dumbledore''s Army, Gryffindor Quidditch Beater, co-owner of Weasleys'' Wizard Wheezes, marries Angelina Johnson', 48, 'Death', 13, 'Human Pride', CAST('1994-11-16' AS Date), CAST(16556.88 AS Decimal(8, 2)), CAST(2.82 AS Decimal(5, 2)), CAST(19.00 AS Decimal(8, 2)), CAST('1994-12-13' AS Date), 0)
	,(155, 'Ginny', 'Weasley', 'Only daughter and youngest child of Arthur and Molly Weasley, Gryffindor student one year under Harry, Gryffindor Quidditch Seeker and Chaser, a member of Dumbledore''s Army.', 47, 'Ollivander family', 12, 'Venomous Tongue', CAST('1990-03-21' AS Date), CAST(9347.41 AS Decimal(8, 2)), CAST(28.27 AS Decimal(5, 2)), CAST(78.00 AS Decimal(8, 2)), CAST('1990-03-31' AS Date), 0)
	,(156, 'Molly', 'Weasley', 'Wife of Arthur Weasley, mother of Bill, Charlie, Percy, Fred, George, Ron and Ginny Weasley, a member of the Order of the Phoenix.', 14, 'Mykew Grerovitch', 18, 'Blue Phoenix', CAST('1992-02-03' AS Date), CAST(39815.04 AS Decimal(8, 2)), CAST(9.43 AS Decimal(5, 2)), CAST(53.00 AS Decimal(8, 2)), CAST('1992-08-30' AS Date), 0)
	,(157, 'Percy', 'Weasley', 'Third son of Arthur and Molly Weasley, Gryffindor prefect and Head Boy then Ministry of Magic employee, long estranged from his family before joining them against the Death Eaters in Deathly Hallows,', 54, 'Arturo Cephalopos', 14, 'Troll Chest', CAST('1985-04-24' AS Date), CAST(25537.20 AS Decimal(8, 2)), CAST(3.05 AS Decimal(5, 2)), CAST(12.00 AS Decimal(8, 2)), CAST('1985-05-16' AS Date), 1)
	,(158, 'Ron', 'Weasley', 'Harry''s close friend, youngest Son of Arthur and Molly Weasley, Gryffindor Quidditch Keeper, school prefect, a member of Dumbledore''s Army.', 51, 'Death', 26, 'Human Pride', CAST('1985-07-16' AS Date), CAST(4085.37 AS Decimal(8, 2)), CAST(25.25 AS Decimal(5, 2)), CAST(32.00 AS Decimal(8, 2)), CAST('1985-09-29' AS Date), 1)
	,(159, 'Oliver', 'Wood', 'Hogwarts student, Gryffindor Quidditch Keeper and captain.', 26, 'Ollivander family', 10, 'Venomous Tongue', CAST('1985-06-29' AS Date), CAST(40902.03 AS Decimal(8, 2)), CAST(10.82 AS Decimal(5, 2)), CAST(68.00 AS Decimal(8, 2)), CAST('1985-08-01' AS Date), 1)
	,(160, 'Kennilworthy', 'Whisp', 'author of "Quidditch Through the Ages"', 57, 'Mykew Grerovitch', 31, 'Blue Phoenix', CAST('1989-03-11' AS Date), CAST(17335.62 AS Decimal(8, 2)), CAST(21.72 AS Decimal(5, 2)), CAST(7.00 AS Decimal(8, 2)), CAST('1989-10-09' AS Date), 0)
	,(161, 'Yaxley', '', 'Death Eater, Head of Magical Law Enforcement under Voldemort''s regime.', 38, 'Jimmy Kiddell', 16, 'Troll Chest', CAST('1988-01-03' AS Date), CAST(26638.92 AS Decimal(8, 2)), CAST(7.11 AS Decimal(5, 2)), CAST(74.00 AS Decimal(8, 2)), CAST('1988-02-21' AS Date), 1)
	,(162, 'Blaise', 'Zabini', 'Slytherin student in Harry''s year, friends with Draco Malfoy.', 16, 'Mykew Gregorovitch', 11, 'Human Pride', CAST('1990-03-28' AS Date), CAST(3049.06 AS Decimal(8, 2)), CAST(6.27 AS Decimal(5, 2)), CAST(61.00 AS Decimal(8, 2)), CAST('1990-07-04' AS Date), 0)
GO


/*---------------------- EXERCISE -----------------------*/
USE Gringotts

/*--- TASK 1 ---------- RECORDS COUNT -------------------*/
SELECT COUNT(*) AS [Count]
FROM WizzardDeposits 

/*--- TASK 2 -------- LONGEST MAGIC WAND ----------------*/
SELECT MAX(MagicWandSize) AS LongestMagicWand 
FROM WizzardDeposits

/*--- TASK 3 --- LONGEST MAGIC WAND PER DEPOSIT GROUPS --*/
SELECT DepositGroup
	  ,MAX(MagicWandSize) AS LongestMagicWand 
FROM WizzardDeposits
GROUP BY DepositGroup

/*--- TASK 4 --- SMALLEST DEPOSIT GROUP PER MAGIC WAND SIZE --*/
SELECT TOP 2 DepositGroup 
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

/*--- TASK 5 --- DEPOSIT SUM ---------------------------------*/
SELECT DepositGroup
	  ,SUM(DepositAmount) AS TotalSum 
FROM WizzardDeposits
GROUP BY DepositGroup

/*--- TASK 6 --- DEPOSIT SUM FOR OLLIVANDER FAMILLY ----------*/
SELECT DepositGroup
	  ,SUM(DepositAmount) AS TotalSum 
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander Family'
GROUP BY DepositGroup

/*--- TASK 7 --- DEPOSITS FILTER -----------------------------*/
SELECT DepositGroup
	  ,SUM(DepositAmount) AS TotalSum 
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander Family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

/*--- TASK 8 --- DEPOSIT CHARGE ------------------------------*/
SELECT DepositGroup
	  ,MagicWandCreator
	  ,MIN(DepositCharge) AS MinDepositCharge 
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

/*--- TASK 9 --- AGE GROUPS ----------------------------------*/
SELECT AgeGroupTable.AgeGroup
	  ,COUNT(AgeGroupTable.AgeGroup) AS WizardCount 
FROM 
	(
		SELECT 
			CASE
			   WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
			   WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			   WHEN Age BETWEEN 21 and 30 THEN '[21-30]'
			   WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			   WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			   WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			   ELSE '[61+]'
			END AS AgeGroup 
		FROM WizzardDeposits
	) AS AgeGroupTable
GROUP BY AgeGroup
ORDER BY AgeGroup

/*--- TASK 10 --- FIRST LETTER -------------------------------*/
SELECT LEFT(FirstName, 1) AS FirstLetter 
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)

/*--- TASK 11 --- AVERAGE INTEREST ---------------------------*/
SELECT DepositGroup
	  ,IsDepositExpired
	  ,AVG(DepositInterest) 
FROM WizzardDeposits
WHERE DATEPART(YEAR, DepositStartDate) >= 1985
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired

/*--- TASK 12 --- RICH WIZARD POOR WIZARD --------------------*/
SELECT SUM([Difference]) AS SumDifference 
FROM 
(
	SELECT w.FirstName AS [Host Wizzard]
		  ,w.DepositAmount AS [Host Wizzard Deposit]
		  ,wd.FirstName AS [Guest Wizzard]
		  ,wd.DepositAmount AS [Guest Wizzard Deposit]
		  ,w.DepositAmount - wd.DepositAmount AS [Difference]
	  FROM WizzardDeposits AS w
	  JOIN WizzardDeposits AS wd ON w.Id = wd.Id - 1
) AS WizardTable


