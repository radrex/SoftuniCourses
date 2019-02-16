-------------------------------------------------------------------
-- This script will create a sample database "SoftUni" in        --
-- MS SQL Server and will populate sample data in its tables.    --
-------------------------------------------------------------------

USE master
GO

CREATE DATABASE SoftUni
GO

USE SoftUni
GO

CREATE TABLE Towns(
  TownID int IDENTITY NOT NULL,
  Name VARCHAR(50) NOT NULL,
  CONSTRAINT PK_Towns PRIMARY KEY CLUSTERED(TownID ASC)
)
GO

SET IDENTITY_INSERT Towns ON
INSERT INTO Towns (TownID, Name) VALUES 
	 (1, 'Redmond')		,(2, 'Calgary')		,(3, 'Edmonds')		,(4, 'Seattle')			,(5, 'Bellevue')	,(6, 'Issaquah')	,(7, 'Everett')		,(8, 'Bothell')		,(9, 'San Francisco')	,(10, 'Index')
	,(11, 'Snohomish')	,(12, 'Monroe')		,(13, 'Renton')		,(14, 'Newport Hills')	,(15, 'Carnation')	,(16, 'Sammamish')	,(17, 'Duvall')		,(18, 'Gold Bar')	,(19, 'Nevada')			,(20, 'Kenmore')
	,(21, 'Melbourne')	,(22, 'Kent')		,(23, 'Cambridge')	,(24, 'Minneapolis')	,(25, 'Portland')	,(26, 'Duluth')		,(27, 'Detroit')	,(28, 'Memphis')	,(29, 'Ottawa')			,(30, 'Bordeaux')
	,(31, 'Berlin')		,(32, 'Sofia')
SET IDENTITY_INSERT Towns OFF
GO

CREATE TABLE Addresses(
  AddressID int IDENTITY NOT NULL,
  AddressText VARCHAR(100) NOT NULL,
  TownID int NULL,
  CONSTRAINT PK_Addresses PRIMARY KEY CLUSTERED (AddressID ASC)
)
GO

SET IDENTITY_INSERT Addresses ON
INSERT INTO Addresses (AddressID, AddressText, TownID) VALUES
	 (1, '108 Lakeside Court', 5)			,(2, '1343 Prospect St', 5)				,(3, '1648 Eastgate Lane', 5)				,(4, '2284 Azalea Avenue', 5)			,(5, '2947 Vine Lane', 5)
	,(6, '3067 Maya', 5)					,(7, '3197 Thornhill Place', 5)			,(8, '3284 S. Blank Avenue', 5)				,(9, '332 Laguna Niguel', 5)			,(10, '3454 Bel Air Drive', 5)
	,(11, '3670 All Ways Drive', 5)			,(12, '3708 Montana', 5)				,(13, '3711 Rollingwood Dr', 5)				,(14, '3919 Pinto Road', 5)				,(15, '4311 Clay Rd', 5)
	,(16, '4777 Rockne Drive', 5)			,(17, '5678 Clear Court', 5)			,(18, '5863 Sierra', 5)						,(19, '6058 Hill Street', 5)			,(20, '6118 Grasswood Circle', 5)
	,(21, '620 Woodside Ct.', 5)			,(22, '6307 Greenbelt Way', 5)			,(23, '6448 Castle Court', 5)				,(24, '6774 Bonanza', 5)				,(25, '6968 Wren Ave.', 5)
	,(26, '7221 Peachwillow Street', 5)		,(27, '7270 Pepper Way', 5)				,(28, '7396 Stratton Circle', 5)			,(29, '7808 Brown St.', 5)				,(30, '7902 Grammercy Lane', 5)
	,(31, '8668 Via Neruda', 5)				,(32, '8684 Military East', 5)			,(33, '8751 Norse Drive', 5)				,(34, '9320 Teakwood Dr.', 5)			,(35, '9435 Breck Court', 5)
	,(36, '9745 Bonita Ct.', 5)				,(37, 'Pascalstr 951', 31)				,(38, '94, rue Descartes', 30)				,(39, '1226 Shoe St.', 8)				,(40, '1399 Firestone Drive', 8)
	,(41, '1902 Santa Cruz', 8)				,(42, '1970 Napa Ct.', 8)				,(43, '250 Race Court', 8)					,(44, '5672 Hale Dr.', 8)				,(45, '5747 Shirley Drive', 8)
	,(46, '6387 Scenic Avenue', 8)			,(47, '6872 Thornwood Dr.', 8)			,(48, '7484 Roundtree Drive', 8)			,(49, '8157 W. Book', 8)				,(50, '9539 Glenside Dr', 8)
	,(51, '9833 Mt. Dias Blv.', 8)			,(52, '10203 Acorn Avenue', 2)			,(53, '3997 Via De Luna', 23)				,(54, 'Downshire Way', 23)				,(55, '1411 Ranch Drive', 15)
	,(56, '3074 Arbor Drive', 15)			,(57, '390 Ridgewood Ct.', 15)			,(58, '9666 Northridge Ct.', 15)			,(59, '9752 Jeanne Circle', 15)			,(60, '8154 Via Mexico', 27)
	,(61, '80 Sunview Terrace', 26)			,(62, '1825 Corte Del Prado', 17)		,(63, '2598 La Vista Circle', 17)			,(64, '3421 Bouncing Road', 17)			,(65, '3977 Central Avenue', 17)
	,(66, '5086 Nottingham Place', 17)		,(67, '5379 Treasure Island Way', 17)	,(68, '8209 Green View Court', 17)			,(69, '8463 Vista Avenue', 17)			,(70, '9693 Mellowood Street', 17)
	,(71, '991 Vista Verde', 17)			,(72, '1061 Buskrik Avenue', 3)			,(73, '172 Turning Dr.', 3)					,(74, '2038 Encino Drive', 3)			,(75, '2046 Las Palmas', 3)
	,(76, '2059 Clay Rd', 3)				,(77, '207 Berry Court', 3)				,(78, '2080 Sycamore Drive', 3)				,(79, '2466 Clearland Circle', 3)		,(80, '2687 Ridge Road', 3)
	,(81, '2812 Mazatlan', 3)				,(82, '3026 Anchor Drive', 3)			,(83, '3281 Hillview Dr.', 3)				,(84, '3632 Bank Way', 3)				,(85, '371 Apple Dr.', 3)
	,(86, '504 O St.', 3)					,(87, '5423 Champion Rd.', 3)			,(88, '6057 Hill Street', 3)				,(89, '6870 D Bel Air Drive', 3)		,(90, '7338 Green St.', 3)
	,(91, '7511 Cooper Dr.', 3)				,(92, '8152 Claudia Dr.', 3)			,(93, '8411 Mt. Orange Place', 3)			,(94, '9277 Country View Lane', 3)		,(95, '9784 Mt Etna Drive', 3)
	,(96, '9825 Coralie Drive', 3)			,(97, '1185 Dallas Drive', 7)			,(98, '1362 Somerset Place', 7)				,(99, '181 Gaining Drive', 7)			,(100, '1962 Cotton Ct.', 7)
	,(101, '2176 Apollo Way', 7)			,(102, '2294 West 39th St.', 7)			,(103, '3238 Laguna Circle', 7)				,(104, '3385 Crestview Drive', 7)		,(105, '3665 Oak Creek Ct.', 7)
	,(106, '3928 San Francisco', 7)			,(107, '475 Santa Maria', 7)			,(108, '5242 Marvelle Ln.', 7)				,(109, '5452 Corte Gilberto', 7)		,(110, '6629 Polson Circle', 7)
	,(111, '7640 First Ave.', 7)			,(112, '7883 Missing Canyon Court', 7)	,(113, '8624 Pepper Way', 7)				,(114, '9241 St George Dr.', 7)			,(115, '213 Stonewood Drive', 18)
	,(116, '2425 Notre Dame Ave', 18)		,(117, '3884 Beauty Street', 18)		,(118, '8036 Summit View Dr.', 18)			,(119, '9605 Pheasant Circle', 18)		,(120, '1245 Clay Road', 10)
	,(121, '1748 Bird Drive', 10)			,(122, '310 Winter Lane', 10)			,(123, '3127 El Camino Drive', 10)			,(124, '3514 Sunshine', 10)				,(125, '1144 Paradise Ct.', 6)
	,(126, '1921 Ranch Road', 6)			,(127, '3333 Madhatter Circle', 6)		,(128, '342 San Simeon', 6)					,(129, '3848 East 39th Street', 6)		,(130, '5256 Chickpea Ct.', 6)
	,(131, '5979 El Pueblo', 6)				,(132, '6580 Poor Ridge Court', 6)		,(133, '7435 Ricardo', 6)					,(134, '7691 Benedict Ct.', 6)			,(135, '7772 Golden Meadow', 6)
	,(136, '8585 Los Gatos Ct.', 6)			,(137, '9314 Icicle Way', 6)			,(138, '9530 Vine Lane', 6)					,(139, '989 Crown Ct', 6)				,(140, '25 95th Ave NE', 20)
	,(141, '4095 Cooper Dr.', 20)			,(142, '4155 Working Drive', 20)		,(143, '463 H Stagecoach Rd.', 20)			,(144, '5050 Mt. Wilson Way', 20)		,(145, '5203 Virginia Lane', 20)
	,(146, '5458 Gladstone Drive', 20)		,(147, '5553 Cash Avenue', 20)			,(148, '5669 Ironwood Way', 20)				,(149, '6697 Ridge Park Drive', 20)		,(150, '7048 Laurel', 20)
	,(151, '8192 Seagull Court', 20)		,(152, '350 Pastel Drive', 22)			,(153, '34 Waterloo Road', 21)				,(154, '8291 Crossbow Way', 28)			,(155, '5678 Lakeview Blvd.', 24)
	,(156, '1356 Grove Way', 12)			,(157, '158 Walnut Ave', 12)			,(158, '1792 Belmont Rd.', 12)				,(159, '2275 Valley Blvd.', 12)			,(160, '3747 W. Landing Avenue', 12)
	,(161, '3841 Silver Oaks Place', 12)	,(162, '4566 La Jolla', 12)				,(163, '4734 Sycamore Court', 12)			,(164, '5030 Blue Ridge Dr.', 12)		,(165, '5734 Ashford Court', 12)
	,(166, '7726 Driftwood Drive', 12)		,(167, '8310 Ridge Circle', 12)			,(168, '896 Southdale', 12)					,(169, '9652 Los Angeles', 12)			,(170, '2487 Riverside Drive', 19)
	,(171, '1397 Paradise Ct.', 14)			,(172, '1400 Gate Drive', 14)			,(173, '3030 Blackburn Ct.', 14)			,(174, '4350 Minute Dr.', 14)			,(175, '8967 Hamilton Ave.', 14)
	,(176, '9297 Kenston Dr.', 14)			,(177, '9687 Shakespeare Drive', 14)	,(178, '9100 Sheppard Avenue North', 29)	,(179, '636 Vine Hill Way', 25)			,(180, '101 Candy Rd.', 1)
	,(181, '1275 West Street', 1)			,(182, '2137 Birchwood Dr', 1)			,(183, '2383 Pepper Drive', 1)				,(184, '2427 Notre Dame Ave.', 1)		,(185, '2482 Buckingham Dr.', 1)
	,(186, '3066 Wallace Dr.', 1)			,(187, '3397 Rancho View Drive', 1)		,(188, '3768 Door Way', 1)					,(189, '4909 Poco Lane', 1)				,(190, '6369 Ellis Street', 1)
	,(191, '6891 Ham Drive', 1)				,(192, '7297 RisingView', 1)			,(193, '8000 Crane Court', 1)				,(194, '8040 Hill Ct', 1)				,(195, '8467 Clifford Court', 1)
	,(196, '9006 Woodside Way', 1)			,(197, '9322 Driving Drive', 1)			,(198, '9863 Ridge Place', 1)				,(199, '9882 Clay Rde', 1)				,(200, '9906 Oak Grove Road', 1)
	,(201, '1378 String Dr', 13)			,(202, '1803 Olive Hill', 13)			,(203, '2176 Brown Street', 13)				,(204, '2266 Greenwood Circle', 13)		,(205, '2598 Breck Court', 13)
	,(206, '2736 Scramble Rd', 13)			,(207, '4312 Cambridge Drive', 13)		,(208, '5009 Orange Street', 13)			,(209, '5670 Bel Air Dr.', 13)			,(210, '5980 Icicle Circle', 13)
	,(211, '6510 Hacienda Drive', 13)		,(212, '6937 E. 42nd Street', 13)		,(213, '7165 Brock Lane', 13)				,(214, '7559 Worth Ct.', 13)			,(215, '7985 Center Street', 13)
	,(216, '9495 Limewood Place', 13)		,(217, '9533 Working Drive', 13)		,(218, '177 11th Ave', 16)					,(219, '1962 Ferndale Lane', 16)		,(220, '2473 Orchard Way', 16)
	,(221, '4096 San Remo', 16)				,(222, '4310 Kenston Dr.', 16)			,(223, '4444 Pepper Way', 16)				,(224, '4525 Benedict Ct.', 16)			,(225, '5263 Etcheverry Dr', 16)
	,(226, '535 Greendell Pl', 16)			,(227, '6871 Thornwood Dr.', 16)		,(228, '6951 Harmony Way', 16)				,(229, '7086 O St.', 16)				,(230, '7145 Matchstick Drive', 16)
	,(231, '7820 Bird Drive', 16)			,(232, '7939 Bayview Court', 16)		,(233, '8316 La Salle St.', 16)				,(234, '9104 Mt. Sequoia Ct.', 16)		,(235, '1234 Seaside Way', 9)
	,(236, '5725 Glaze Drive', 9)			,(237, '1064 Slow Creek Road', 4)		,(238, '1102 Ravenwood', 4)					,(239, '1220 Bradford Way', 4)			,(240, '1349 Steven Way', 4)
	,(241, '136 Balboa Court', 4)			,(242, '137 Mazatlan', 4)				,(243, '1398 Yorba Linda', 4)				,(244, '1619 Stillman Court', 4)		,(245, '2144 San Rafael', 4)
	,(246, '2354 Frame Ln.', 4)				,(247, '2639 Anchor Court', 4)			,(248, '3029 Pastime Dr', 4)				,(249, '3243 Buckingham Dr.', 4)		,(250, '426 San Rafael', 4)
	,(251, '4598 Manila Avenue', 4)			,(252, '4948 West 4th St', 4)			,(253, '502 Alexander Pl.', 4)				,(254, '5025 Holiday Hills', 4)			,(255, '5125 Cotton Ct.', 4)
	,(256, '5375 Clearland Circle', 4)		,(257, '5376 Catanzaro Way', 4)			,(258, '5407 Cougar Way', 4)				,(259, '5666 Hazelnut Lane', 4)			,(260, '5802 Ampersand Drive', 4)
	,(261, '6498 Mining Rd.', 4)			,(262, '6578 Woodhaven Ln.', 4)			,(263, '6657 Sand Pointe Lane', 4)			,(264, '6843 San Simeon Dr.', 4)		,(265, '7126 Ending Ct.', 4)
	,(266, '7127 Los Gatos Court', 4)		,(267, '7166 Brock Lane', 4)			,(268, '7403 N. Broadway', 4)				,(269, '7439 Laguna Niguel', 4)			,(270, '7594 Alexander Pl.', 4)
	,(271, '7616 Honey Court', 4)			,(272, '77 Birchwood', 4)				,(273, '7765 Sunsine Drive', 4)				,(274, '7842 Ygnacio Valley Road', 4)	,(275, '8290 Margaret Ct.', 4)
	,(276, '8656 Lakespring Place', 4)		,(277, '874 Olivera Road', 4)			,(278, '931 Corte De Luna', 4)				,(279, '9537 Ridgewood Drive', 4)		,(280, '9964 North Ridge Drive', 4)
	,(281, '1285 Greenbrier Street', 11)	,(282, '2115 Passing', 11)				,(283, '2601 Cambridge Drive', 11)			,(284, '3114 Notre Dame Ave.', 11)		,(285, '3280 Pheasant Circle', 11)
	,(286, '4231 Spar Court', 11)			,(287, '4852 Chaparral Court', 11)		,(288, '5724 Victory Lane', 11)				,(289, '591 Merriewood Drive', 11)		,(290, '7230 Vine Maple Street', 11)
	,(291, '163 Nishava Str, ent A, apt. 1', 32)
SET IDENTITY_INSERT Addresses OFF

GO

CREATE TABLE Projects(
  ProjectID int IDENTITY NOT NULL,
  Name VARCHAR(50) NOT NULL,
  Description ntext NULL,
  StartDate smalldatetime NOT NULL,
  EndDate smalldatetime NULL,
  CONSTRAINT PK_Projects PRIMARY KEY CLUSTERED (ProjectID ASC)
)
GO

SET IDENTITY_INSERT Projects ON

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate) VALUES
	 (1, 'Classic Vest', 'Research, design and development of Classic Vest. Light-weight, wind-resistant, packs to fit into a pocket.', '20030601', NULL)
	,(2, 'Cycling Cap', 'Research, design and development of Cycling Cap. Traditional style with a flip-up brim; one-size fits all.', '20010601', '20030601')
	,(3, 'Full-Finger Gloves', 'Research, design and development of Full-Finger Gloves. Synthetic palm, flexible knuckles, breathable mesh upper. Worn by the AWC team riders.', '20020601', '20030601')
	,(4, 'Half-Finger Gloves', 'Research, design and development of Half-Finger Gloves. Full padding, improved finger flex, durable palm, adjustable closure.', '20020601', '20030601')
	,(5, 'HL Mountain Frame', 'Research, design and development of HL Mountain Frame. Each frame is hand-crafted in our Bothell facility to the optimum diameter and wall-thickness required of a premium mountain frame. The heat-treated welded aluminum frame has a larger diameter tube that absorbs the bumps.', '20010601', '20030601')
	,(6, 'HL Road Frame', 'Research, design and development of HL Road Frame. Our lightest and best quality aluminum frame made from the newest alloy; it is welded and heat-treated for strength. Our innovative design results in maximum comfort and performance.', '19980502', '20030601')
	,(7, 'HL Touring Frame', 'Research, design and development of HL Touring Frame. The HL aluminum frame is custom-shaped for both good looks and strength; it will withstand the most rigorous challenges of daily riding. Men''s version.', '20050516 16:34:00', NULL)
	,(8, 'LL Mountain Frame', 'Research, design and development of LL Mountain Frame. Our best value utilizing the same, ground-breaking frame technology as the ML aluminum frame.', '20021120 09:57:00', '20030601')
	,(9, 'LL Road Frame', 'Research, design and development of LL Road Frame. The LL Frame provides a safe comfortable ride, while offering superior bump absorption in a value-priced aluminum frame.', '20010601', '20030601')
	,(10, 'LL Touring Frame', 'Research, design and development of LL Touring Frame. Lightweight butted aluminum frame provides a more upright riding position for a trip around town.  Our ground-breaking design provides optimum comfort.', '20050516 16:34:00', NULL)
	,(11, 'Long-Sleeve Logo Jersey', 'Research, design and development of Long-Sleeve Logo Jersey. Unisex long-sleeve AWC logo microfiber cycling jersey', '20010601', '20030601')
	,(12, 'Men''s Bib-Shorts', 'Research, design and development of Men''s Bib-Shorts. Designed for the AWC team with stay-put straps, moisture-control, chamois padding, and leg grippers.', '20020601', '20030601')
	,(19, 'Mountain-100', 'Research, design and development of Mountain-100. Top-of-the-line competition mountain bike. Performance-enhancing options include the innovative HL Frame, super-smooth front suspension, and traction for all terrain.', '20010601', '20030601')
	,(20, 'Mountain-200', 'Research, design and development of Mountain-200. Serious back-country riding. Perfect for all levels of competition. Uses the same HL Frame as the Mountain-100.', '20020601', '20040311 10:32:00')
	,(21, 'Mountain-300', 'Research, design and development of Mountain-300. For true trail addicts.  An extremely durable bike that will go anywhere and keep you in control on challenging terrain - without breaking your budget.', '20020601', '20030601')
	,(22, 'Mountain-400-W', 'Research, design and development of Mountain-400-W. This bike delivers a high-level of performance on a budget. It is responsive and maneuverable, and offers peace-of-mind when you decide to go off-road.', '20060222', NULL)
	,(23, 'Mountain-500', 'Research, design and development of Mountain-500. Suitable for any type of riding, on or off-road. Fits any budget. Smooth-shifting with a comfortable ride.', '20021120 09:57:00', '20030601')
	,(24, 'Racing Socks', 'Research, design and development of Racing Socks. Thin, lightweight and durable with cuffs that stay up.', '20051122', NULL)
	,(25, 'Road-150', 'Research, design and development of Road-150. This bike is ridden by race winners. Developed with the Adventure Works Cycles professional race team, it has a extremely light heat-treated aluminum frame, and steering that allows precision control.', '20010601', '20030601')
	,(26, 'Road-250', 'Research, design and development of Road-250. Alluminum-alloy frame provides a light, stiff ride, whether you are racing in the velodrome or on a demanding club ride on country roads.', '20020601', '20030601')
	,(27, 'Road-350-W', 'Research, design and development of Road-350-W. Cross-train, race, or just socialize on a sleek, aerodynamic bike designed for a woman.  Advanced seat technology provides comfort all day.', '20030601', NULL)
	,(28, 'Road-450', 'Research, design and development of Road-450. A true multi-sport bike that offers streamlined riding and a revolutionary design. Aerodynamic design lets you ride with the pros, and the gearing will conquer hilly roads.', '20010601', '20030601')
	,(29, 'Road-550-W', 'Research, design and development of Road-550-W. Same technology as all of our Road series bikes, but the frame is sized for a woman.  Perfect all-around bike for road or racing.', '20020601', '20030601')
	,(30, 'Road-650', 'Research, design and development of Road-650. Value-priced bike with many features of our top-of-the-line models. Has the same light, stiff frame, and the quick acceleration we''re famous for.', '20010601', '20030601')
	,(31, 'Road-750', 'Research, design and development of Road-750. Entry level adult bike; offers a comfortable ride cross-country or down the block. Quick-release hubs and rims.', '20021120 09:57:00', '20030601')
	,(32, 'Short-Sleeve Classic Jersey', 'Research, design and development of Short-Sleeve Classic Jersey. Short sleeve classic breathable jersey with superior moisture control, front zipper, and 3 back pockets.', '20030601', NULL)
	,(33, 'Sport-100', 'Research, design and development of Sport-100. Universal fit, well-vented, lightweight , snap-on visor.', '20010601', '20030601')
	,(34, 'Touring-1000', 'Research, design and development of Touring-1000. Travel in style and comfort. Designed for maximum comfort and safety. Wide gear range takes on all hills. High-tech aluminum alloy construction provides durability without added weight.', '20021120 09:57:00', '20030601')
	,(35, 'Touring-2000', 'Research, design and development of Touring-2000. The plush custom saddle keeps you riding all day,  and there''s plenty of space to add panniers and bike bags to the newly-redesigned carrier.  This bike has stability when fully-loaded.', '20021120 09:57:00', '20030601')
	,(36, 'Touring-3000', 'Research, design and development of Touring-3000. All-occasion value bike with our basic comfort and safety features. Offers wider, more stable tires for a ride around town or weekend trip.', '20021120 09:57:00', '20030601')
	,(37, 'Women''s Mountain Shorts', 'Research, design and development of Women''s Mountain Shorts. Heavy duty, abrasion-resistant shorts feature seamless, lycra inner shorts with anti-bacterial chamois for comfort.', '20030601', NULL)
	,(38, 'Women''s Tights', 'Research, design and development of Women''s Tights. Warm spandex tights for winter riding; seamless chamois construction eliminates pressure points.', '20020601', '20030601')
	,(39, 'Mountain-400', 'Research, design and development of Mountain-400. Suitable for any type of off-road trip. Fits any budget.', '20010601', '20030601')
	,(40, 'Road-550', 'Research, design and development of Road-550. Same technology as all of our Road series bikes.  Perfect all-around bike for road or racing.', '20020601', '20030601')
	,(41, 'Road-350', 'Research, design and development of Road-350. Cross-train, race, or just socialize on a sleek, aerodynamic bike.  Advanced seat technology provides comfort all day.', '20021120 09:57:00', '20030601')
	,(42, 'LL Mountain Front Wheel', 'Research, design and development of LL Mountain Front Wheel. Replacement mountain wheel for entry-level rider.', '20021120 09:57:00', '20030601')
	,(43, 'Touring Rear Wheel', 'Research, design and development of Touring Rear Wheel. Excellent aerodynamic rims guarantee a smooth ride.', '20050516 16:34:00', NULL)
	,(44, 'Touring Front Wheel', 'Research, design and development of Touring Front Wheel. Aerodynamic rims for smooth riding.', '20050516 16:34:00', NULL)
	,(45, 'ML Mountain Front Wheel', 'Research, design and development of ML Mountain Front Wheel. Replacement mountain wheel for the casual to serious rider.', '20020601', '20030601')
	,(46, 'HL Mountain Front Wheel', 'Research, design and development of HL Mountain Front Wheel. High-performance mountain replacement wheel.', '20020601', '20030601')
	,(47, 'LL Touring Handlebars', 'Research, design and development of LL Touring Handlebars. Unique shape reduces fatigue for entry level riders.', '20050516 16:34:00', NULL)
	,(48, 'HL Touring Handlebars', 'Research, design and development of HL Touring Handlebars. A light yet stiff aluminum bar for long distance riding.', '20050516 16:34:00', NULL)
	,(49, 'LL Road Front Wheel', 'Research, design and development of LL Road Front Wheel. Replacement road front wheel for entry-level cyclist.', '20020601', '20030601')
	,(50, 'ML Road Front Wheel', 'Research, design and development of ML Road Front Wheel. Sturdy alloy features a quick-release hub.', '20020601', '20030601')
	,(51, 'HL Road Front Wheel', 'Research, design and development of HL Road Front Wheel. Strong wheel with double-walled rim.', '20020601', '20030601')
	,(52, 'LL Mountain Handlebars', 'Research, design and development of LL Mountain Handlebars. All-purpose bar for on or off-road.', '20020601', '20030601')
	,(53, 'Touring Pedal', 'Research, design and development of Touring Pedal. A stable pedal for all-day riding.', '20050516 16:34:00', NULL)
	,(54, 'ML Mountain Handlebars', 'Research, design and development of ML Mountain Handlebars. Tough aluminum alloy bars for downhill.', '20020601', '20030601')
	,(55, 'HL Mountain Handlebars', 'Research, design and development of HL Mountain Handlebars. Flat bar strong enough for the pro circuit.', '20020601', '20030601')
	,(56, 'LL Road Handlebars', 'Research, design and development of LL Road Handlebars. Unique shape provides easier reach to the levers.', '20020601', '20030601')
	,(57, 'ML Road Handlebars', 'Research, design and development of ML Road Handlebars. Anatomically shaped aluminum tube bar will suit all riders.', '20020601', '20030601')
	,(58, 'HL Road Handlebars', 'Research, design and development of HL Road Handlebars. Designed for racers; high-end anatomically shaped bar from aluminum alloy.', '20020601', '20030601')
	,(59, 'LL Headset', 'Research, design and development of LL Headset. Threadless headset provides quality at an economical price.', '20020601', '20030601')
	,(60, 'ML Headset', 'Research, design and development of ML Headset. Sealed cartridge keeps dirt out.', '20020601', '20030601')
	,(61, 'HL Headset', 'Research, design and development of HL Headset. High-quality 1" threadless headset with a grease port for quick lubrication.', '20020601', '20030601')
	,(77, 'ML Road Rear Wheel', 'Research, design and development of ML Road Rear Wheel. Aluminum alloy rim with stainless steel spokes; built for speed.', '20020601', '20030601')
	,(78, 'HL Road Rear Wheel', 'Research, design and development of HL Road Rear Wheel. Strong rear wheel with double-walled rim.', '20020601', '20030601')
	,(79, 'LL Mountain Seat/Saddle 2', 'Research, design and development of LL Mountain Seat/Saddle 2. Synthetic leather. Features gel for increased comfort.', '20030601', NULL)
	,(80, 'ML Mountain Seat/Saddle 2', 'Research, design and development of ML Mountain Seat/Saddle 2. Designed to absorb shock.', '20030601', '20040311 10:32:00')
	,(104, 'LL Fork', 'Research, design and development of LL Fork. Stout design absorbs shock and offers more precise steering.', '20020601', '20030601')
	,(105, 'ML Fork', 'Research, design and development of ML Fork. Composite road fork with an aluminum steerer tube.', '20020601', '20030601')
	,(106, 'HL Fork', 'Research, design and development of HL Fork. High-performance carbon road fork with curved legs.', '20020601', '20030601')
	,(107, 'Hydration Pack', 'Research, design and development of Hydration Pack. Versatile 70 oz hydration pack offers extra storage, easy-fill access, and a waist belt.', '20030601', NULL)
	,(108, 'Taillight', 'Research, design and development of Taillight. Affordable light for safe night riding - uses 3 AAA batteries', '20020601', '20030601')
	,(109, 'Headlights - Dual-Beam', 'Research, design and development of Headlights - Dual-Beam. Rechargeable dual-beam headlight.', '20020601', '20030601')
	,(110, 'Headlights - Weatherproof', 'Research, design and development of Headlights - Weatherproof. Rugged weatherproof headlight.', '20020601', '20030601')
	,(111, 'Water Bottle', 'Research, design and development of Water Bottle. AWC logo water bottle - holds 30 oz; leak-proof.', '20030601', NULL)
	,(112, 'Mountain Bottle Cage', 'Research, design and development of Mountain Bottle Cage. Tough aluminum cage holds bottle securly on tough terrain.', '20030601', NULL)
	,(113, 'Road Bottle Cage', 'Research, design and development of Road Bottle Cage. Aluminum cage is lighter than our mountain version; perfect for long distance trips.', '20040221', NULL)
	,(114, 'Patch kit', 'Research, design and development of Patch kit. Includes 8 different size patches, glue and sandpaper.', '20030601', NULL)
	,(115, 'Cable Lock', 'Research, design and development of Cable Lock. Wraps to fit front and rear tires, carrier and 2 keys included.', '20020601', '20030601')
	,(116, 'Minipump', 'Research, design and development of Minipump. Designed for convenience. Fits in your pocket. Aluminum barrel. 160psi rated.', '20020601', '20030601')
	,(117, 'Mountain Pump', 'Research, design and development of Mountain Pump. Simple and light-weight. Emergency patches stored in handle.', '20020601', '20030601')
	,(118, 'Hitch Rack - 4-Bike', 'Research, design and development of Hitch Rack - 4-Bike. Carries 4 bikes securely; steel construction, fits 2" receiver hitch.', '20030601', NULL)
	,(119, 'Bike Wash', 'Research, design and development of Bike Wash. Washes off the toughest road grime; dissolves grease, environmentally safe. 1-liter bottle.', '20050801', NULL)
	,(120, 'Touring-Panniers', 'Research, design and development of Touring-Panniers. Durable, water-proof nylon construction with easy access. Large enough for weekend trips.', '20020601', '20030601')
	,(121, 'Fender Set - Mountain', 'Research, design and development of Fender Set - Mountain. Clip-on fenders fit most mountain bikes.', '20030601', NULL)
	,(122, 'All-Purpose Bike Stand', 'Research, design and development of All-Purpose Bike Stand. Perfect all-purpose bike stand for working on your bike at home. Quick-adjusting clamps and steel construction.', '20050901', NULL)
	,(127, 'Rear Derailleur', 'Research, design and development of Rear Derailleur. Wide-link design.', '20030601', NULL)
GO
SET IDENTITY_INSERT Projects OFF

CREATE TABLE EmployeesProjects(
  EmployeeID int NOT NULL,
  ProjectID int NOT NULL,
  CONSTRAINT PK_EmployeesProjects PRIMARY KEY CLUSTERED (EmployeeID ASC, ProjectID ASC)
)
GO

INSERT INTO EmployeesProjects (EmployeeID, ProjectID) VALUES 
	 (1, 4)				,(24, 30)			,(51, 23)			,(76, 12)			,(100, 52)			,(127, 19)			,(153, 117)			,(177, 39)			,(204, 38)			,(230, 117)
	,(1, 24)			,(24, 44)			,(51, 37)			,(76, 32)			,(100, 104)			,(127, 56)			,(154, 5)			,(177, 53)			,(204, 52)			,(232, 29)
	,(1, 38)			,(24, 119)			,(51, 112)			,(76, 46)			,(101, 25)			,(127, 108)			,(154, 25)			,(177, 105)			,(204, 104)			,(232, 43)
	,(1, 113)			,(25, 11)			,(52, 49)			,(76, 121)			,(101, 39)			,(127, 122)			,(154, 77)			,(177, 119)			,(205, 25)			,(232, 118)
	,(3, 1)				,(25, 31)			,(52, 78)			,(77, 7)			,(101, 53)			,(129, 41)			,(154, 114)			,(179, 34)			,(205, 39)			,(234, 20)
	,(3, 21)			,(25, 106)			,(52, 115)			,(77, 27)			,(101, 105)			,(129, 55)			,(155, 9)			,(179, 48)			,(205, 53)			,(234, 34)
	,(3, 58)			,(25, 120)			,(53, 7)			,(77, 41)			,(102, 2)			,(129, 107)			,(155, 52)			,(179, 77)			,(205, 105)			,(234, 109)
	,(3, 110)			,(26, 5)			,(53, 50)			,(77, 55)			,(102, 45)			,(129, 121)			,(155, 104)			,(179, 114)			,(206, 20)			,(234, 127)
	,(4, 25)			,(26, 25)			,(53, 79)			,(78, 19)			,(102, 59)			,(131, 29)			,(155, 118)			,(180, 35)			,(206, 34)			,(235, 1)
	,(4, 39)			,(26, 39)			,(53, 116)			,(78, 33)			,(102, 111)			,(131, 43)			,(156, 10)			,(180, 49)			,(206, 48)			,(235, 21)
	,(4, 53)			,(26, 114)			,(54, 7)			,(78, 47)			,(103, 5)			,(131, 57)			,(156, 53)			,(180, 78)			,(206, 77)			,(235, 35)
	,(4, 105)			,(27, 26)			,(54, 50)			,(78, 122)			,(103, 48)			,(131, 109)			,(156, 105)			,(180, 115)			,(207, 19)			,(235, 110)
	,(5, 27)			,(27, 40)			,(54, 79)			,(79, 9)			,(103, 77)			,(132, 21)			,(156, 119)			,(181, 36)			,(207, 33)			,(236, 22)
	,(5, 41)			,(27, 115)			,(54, 116)			,(79, 29)			,(103, 114)			,(132, 35)			,(157, 11)			,(181, 50)			,(207, 47)			,(236, 36)
	,(5, 55)			,(29, 7)			,(55, 8)			,(79, 43)			,(104, 19)			,(132, 49)			,(157, 54)			,(181, 79)			,(207, 61)			,(236, 111)
	,(5, 107)			,(29, 27)			,(55, 28)			,(79, 57)			,(104, 33)			,(132, 78)			,(157, 106)			,(181, 116)			,(208, 20)			,(237, 3)
	,(7, 12)			,(29, 41)			,(55, 80)			,(80, 20)			,(104, 47)			,(133, 30)			,(157, 120)			,(182, 1)			,(208, 34)			,(237, 23)
	,(7, 32)			,(29, 116)			,(55, 117)			,(80, 34)			,(104, 61)			,(133, 44)			,(158, 12)			,(182, 21)			,(208, 48)			,(237, 37)
	,(7, 107)			,(30, 26)			,(56, 9)			,(80, 48)			,(105, 20)			,(133, 58)			,(158, 32)			,(182, 35)			,(208, 77)			,(237, 112)
	,(7, 121)			,(30, 78)			,(56, 29)			,(80, 127)			,(105, 34)			,(133, 110)			,(158, 46)			,(182, 49)			,(209, 21)			,(239, 12)
	,(8, 2)				,(30, 115)			,(56, 104)			,(81, 1)			,(105, 48)			,(134, 31)			,(158, 60)			,(183, 26)			,(209, 35)			,(239, 32)
	,(8, 22)			,(31, 11)			,(56, 118)			,(81, 21)			,(105, 77)			,(134, 45)			,(159, 11)			,(183, 40)			,(209, 49)			,(239, 107)
	,(8, 36)			,(31, 31)			,(57, 10)			,(81, 35)			,(107, 11)			,(134, 59)			,(159, 31)			,(183, 54)			,(209, 78)			,(239, 121)
	,(8, 111)			,(31, 45)			,(57, 30)			,(81, 49)			,(107, 31)			,(134, 111)			,(159, 45)			,(183, 106)			,(210, 3)			,(240, 108)
	,(9, 9)				,(31, 120)			,(57, 105)			,(83, 4)			,(107, 45)			,(135, 7)			,(159, 120)			,(184, 19)			,(210, 23)			,(240, 122)
	,(9, 52)			,(32, 12)			,(57, 119)			,(83, 24)			,(107, 59)			,(135, 27)			,(160, 43)			,(184, 33)			,(210, 37)			,(243, 31)
	,(9, 104)			,(32, 32)			,(58, 11)			,(83, 38)			,(108, 8)			,(135, 41)			,(160, 57)			,(184, 47)			,(210, 51)			,(243, 106)
	,(9, 118)			,(32, 46)			,(58, 31)			,(83, 52)			,(108, 28)			,(135, 116)			,(160, 109)			,(184, 122)			,(211, 4)			,(243, 120)
	,(10, 3)			,(32, 121)			,(58, 106)			,(84, 5)			,(108, 42)			,(136, 26)			,(160, 127)			,(185, 20)			,(211, 24)			,(245, 20)
	,(10, 23)			,(33, 19)			,(58, 120)			,(84, 25)			,(108, 117)			,(136, 40)			,(161, 12)			,(185, 34)			,(211, 38)			,(245, 57)
	,(10, 37)			,(33, 33)			,(60, 8)			,(84, 39)			,(110, 10)			,(136, 54)			,(161, 55)			,(185, 48)			,(211, 52)			,(245, 109)
	,(10, 112)			,(33, 47)			,(60, 51)			,(84, 53)			,(110, 30)			,(136, 106)			,(161, 107)			,(185, 127)			,(212, 8)			,(245, 127)
	,(11, 10)			,(33, 122)			,(60, 80)			,(86, 9)			,(110, 44)			,(137, 27)			,(161, 121)			,(186, 32)			,(212, 51)			,(246, 1)
	,(11, 53)			,(36, 1)			,(60, 117)			,(86, 29)			,(110, 58)			,(137, 41)			,(162, 1)			,(186, 46)			,(212, 80)			,(246, 21)
	,(11, 105)			,(36, 21)			,(61, 9)			,(86, 43)			,(111, 26)			,(137, 55)			,(162, 44)			,(186, 60)			,(212, 117)			,(246, 58)
	,(11, 119)			,(36, 35)			,(61, 52)			,(86, 57)			,(111, 40)			,(137, 107)			,(162, 58)			,(186, 112)			,(213, 9)			,(246, 110)
	,(12, 28)			,(36, 49)			,(61, 104)			,(87, 9)			,(111, 54)			,(138, 28)			,(162, 110)			,(187, 33)			,(213, 29)			,(247, 22)
	,(12, 42)			,(37, 2)			,(61, 118)			,(87, 29)			,(112, 1)			,(138, 42)			,(163, 2)			,(187, 47)			,(213, 43)			,(247, 59)
	,(12, 56)			,(37, 22)			,(62, 10)			,(87, 43)			,(112, 44)			,(138, 56)			,(163, 45)			,(187, 61)			,(213, 57)			,(247, 111)
	,(12, 108)			,(37, 36)			,(62, 53)			,(87, 118)			,(112, 58)			,(138, 108)			,(163, 59)			,(187, 113)			,(214, 10)			,(248, 3)
	,(13, 20)			,(37, 50)			,(62, 105)			,(88, 2)			,(112, 110)			,(141, 35)			,(163, 111)			,(189, 27)			,(214, 30)			,(248, 23)
	,(13, 34)			,(38, 2)			,(62, 119)			,(88, 22)			,(113, 2)			,(141, 49)			,(165, 40)			,(189, 41)			,(214, 44)			,(248, 60)
	,(13, 48)			,(38, 22)			,(63, 11)			,(88, 36)			,(113, 45)			,(141, 78)			,(165, 54)			,(189, 55)			,(214, 58)			,(248, 112)
	,(13, 127)			,(38, 36)			,(63, 54)			,(88, 50)			,(113, 59)			,(141, 115)			,(165, 106)			,(189, 107)			,(215, 11)			,(249, 4)
	,(14, 19)			,(38, 111)			,(63, 106)			,(89, 3)			,(113, 111)			,(142, 36)			,(165, 120)			,(190, 28)			,(215, 31)			,(249, 24)
	,(14, 33)			,(39, 3)			,(63, 120)			,(89, 23)			,(114, 10)			,(142, 50)			,(167, 3)			,(190, 42)			,(215, 45)			,(249, 61)
	,(14, 108)			,(39, 23)			,(64, 4)			,(89, 37)			,(114, 30)			,(142, 79)			,(167, 46)			,(190, 56)			,(215, 59)			,(249, 113)
	,(14, 122)			,(39, 60)			,(64, 24)			,(89, 51)			,(114, 44)			,(142, 116)			,(167, 60)			,(190, 108)			,(217, 31)			,(250, 77)
	,(15, 1)			,(39, 112)			,(64, 38)			,(90, 20)			,(114, 58)			,(143, 26)			,(167, 112)			,(191, 4)			,(217, 45)			,(250, 114)
	,(15, 21)			,(40, 4)			,(64, 113)			,(90, 57)			,(115, 3)			,(143, 40)			,(168, 4)			,(191, 24)			,(217, 59)			,(252, 12)
	,(15, 35)			,(40, 24)			,(65, 5)			,(90, 109)			,(115, 46)			,(143, 115)			,(168, 47)			,(191, 61)			,(218, 3)			,(252, 55)
	,(15, 110)			,(40, 61)			,(65, 48)			,(90, 127)			,(115, 60)			,(144, 32)			,(168, 61)			,(191, 113)			,(218, 23)			,(252, 107)
	,(16, 20)			,(40, 113)			,(65, 77)			,(91, 26)			,(115, 112)			,(144, 46)			,(168, 113)			,(192, 29)			,(218, 60)			,(252, 121)
	,(16, 34)			,(41, 4)			,(65, 114)			,(91, 40)			,(116, 4)			,(144, 60)			,(169, 5)			,(192, 43)			,(218, 112)			,(253, 8)
	,(16, 109)			,(41, 24)			,(66, 1)			,(91, 54)			,(116, 47)			,(144, 112)			,(169, 48)			,(192, 57)			,(219, 53)			,(253, 42)
	,(16, 127)			,(41, 38)			,(66, 44)			,(92, 7)			,(116, 61)			,(145, 5)			,(169, 77)			,(192, 109)			,(220, 26)			,(253, 56)
	,(17, 20)			,(41, 52)			,(66, 58)			,(92, 27)			,(116, 113)			,(145, 25)			,(169, 114)			,(193, 30)			,(220, 40)			,(254, 26)
	,(17, 34)			,(42, 7)			,(66, 110)			,(92, 41)			,(118, 43)			,(145, 39)			,(170, 19)			,(193, 44)			,(220, 54)			,(254, 78)
	,(17, 109)			,(42, 27)			,(67, 20)			,(92, 55)			,(118, 57)			,(145, 53)			,(170, 33)			,(193, 58)			,(221, 7)			,(254, 115)
	,(17, 127)			,(42, 79)			,(67, 57)			,(93, 8)			,(118, 109)			,(146, 33)			,(170, 47)			,(193, 110)			,(221, 27)			,(255, 7)
	,(18, 1)			,(42, 116)			,(67, 109)			,(93, 28)			,(118, 127)			,(146, 47)			,(170, 61)			,(194, 31)			,(221, 41)			,(255, 27)
	,(18, 21)			,(43, 26)			,(67, 127)			,(93, 42)			,(120, 42)			,(146, 61)			,(171, 41)			,(194, 45)			,(221, 55)			,(255, 79)
	,(18, 35)			,(43, 78)			,(68, 1)			,(93, 56)			,(120, 56)			,(146, 113)			,(171, 55)			,(194, 59)			,(222, 8)			,(255, 116)
	,(18, 110)			,(43, 115)			,(68, 21)			,(95, 12)			,(120, 108)			,(147, 34)			,(171, 107)			,(194, 111)			,(222, 42)			,(256, 8)
	,(19, 12)			,(44, 9)			,(68, 58)			,(95, 32)			,(120, 122)			,(147, 48)			,(171, 121)			,(196, 22)			,(222, 56)			,(256, 80)
	,(19, 32)			,(44, 29)			,(68, 110)			,(95, 46)			,(122, 40)			,(147, 77)			,(172, 42)			,(196, 36)			,(224, 10)			,(256, 117)
	,(19, 107)			,(44, 104)			,(69, 2)			,(95, 60)			,(122, 54)			,(147, 114)			,(172, 56)			,(196, 50)			,(224, 44)			,(257, 29)
	,(19, 121)			,(44, 118)			,(69, 22)			,(96, 22)			,(122, 106)			,(148, 29)			,(172, 108)			,(196, 79)			,(224, 119)			,(257, 104)
	,(20, 19)			,(45, 5)			,(69, 59)			,(96, 36)			,(122, 120)			,(148, 43)			,(172, 122)			,(197, 2)			,(225, 22)			,(257, 118)
	,(20, 33)			,(45, 25)			,(69, 111)			,(96, 50)			,(123, 5)			,(148, 57)			,(173, 12)			,(197, 22)			,(225, 59)			,(258, 10)
	,(20, 108)			,(45, 77)			,(70, 49)			,(96, 79)			,(123, 25)			,(148, 109)			,(173, 32)			,(197, 36)			,(225, 111)			,(258, 105)
	,(20, 122)			,(45, 114)			,(70, 78)			,(97, 21)			,(123, 39)			,(149, 3)			,(173, 46)			,(197, 50)			,(226, 4)			,(258, 119)
	,(21, 10)			,(48, 12)			,(70, 115)			,(97, 35)			,(123, 114)			,(149, 46)			,(173, 121)			,(199, 23)			,(226, 24)			,(262, 56)
	,(21, 30)			,(48, 55)			,(73, 19)			,(97, 49)			,(124, 37)			,(149, 60)			,(174, 37)			,(199, 37)			,(226, 38)			,(262, 108)
	,(21, 105)			,(48, 107)			,(73, 56)			,(97, 78)			,(124, 51)			,(149, 112)			,(174, 51)			,(199, 51)			,(226, 113)			,(262, 122)
	,(21, 119)			,(48, 121)			,(73, 108)			,(98, 22)			,(124, 80)			,(151, 49)			,(174, 80)			,(199, 80)			,(227, 114)			,(263, 24)
	,(22, 8)			,(49, 8)			,(73, 122)			,(98, 36)			,(124, 117)			,(151, 78)			,(174, 117)			,(200, 3)			,(228, 26)			,(267, 37)
	,(22, 28)			,(49, 28)			,(74, 10)			,(98, 50)			,(125, 38)			,(151, 115)			,(175, 38)			,(200, 23)			,(228, 40)			,(267, 80)
	,(22, 42)			,(49, 80)			,(74, 30)			,(98, 79)			,(125, 52)			,(152, 7)			,(175, 52)			,(200, 37)			,(228, 115)
	,(22, 117)			,(49, 117)			,(74, 44)			,(99, 23)			,(125, 104)			,(152, 50)			,(175, 104)			,(200, 51)			,(229, 7)
	,(23, 9)			,(50, 7)			,(74, 119)			,(99, 37)			,(125, 118)			,(152, 79)			,(175, 118)			,(202, 12)			,(229, 27)
	,(23, 29)			,(50, 27)			,(75, 11)			,(99, 51)			,(126, 39)			,(152, 116)			,(176, 4)			,(202, 32)			,(229, 41)
	,(23, 43)			,(50, 79)			,(75, 31)			,(99, 80)			,(126, 53)			,(153, 8)			,(176, 47)			,(202, 46)			,(229, 116)
	,(23, 118)			,(50, 116)			,(75, 45)			,(100, 24)			,(126, 105)			,(153, 51)			,(176, 61)			,(202, 60)			,(230, 8)
	,(24, 10)			,(51, 3)			,(75, 120)			,(100, 38)			,(126, 119)			,(153, 80)			,(176, 113)			,(204, 24)			,(230, 42)
GO

CREATE TABLE Departments(
  DepartmentID int IDENTITY NOT NULL,
  Name VARCHAR(50) NOT NULL,
  ManagerID int NOT NULL,
  CONSTRAINT PK_Departments PRIMARY KEY CLUSTERED (DepartmentID ASC)
)
GO

SET IDENTITY_INSERT Departments ON

INSERT INTO Departments (DepartmentID, Name, ManagerID) VALUES 
	 (1, 'Engineering', 12)					,(2, 'Tool Design', 4)										,(3, 'Sales', 273)							,(4, 'Marketing', 46)
	,(5, 'Purchasing', 6)					,(6, 'Research and Development', 42)						,(7, 'Production', 148)						,(8, 'Production Control', 21)
	,(9, 'Human Resources', 30)				,(10, 'Finance', 3)											,(11, 'Information Services', 42)			,(12, 'Document Control', 90)
	,(13, 'Quality Assurance', 274)			,(14, 'Facilities and Maintenance', 218)					,(15, 'Shipping and Receiving', 85)			,(16, 'Executive', 109)
SET IDENTITY_INSERT Departments OFF
GO

CREATE TABLE Employees(
  EmployeeID int IDENTITY NOT NULL,
  FirstName VARCHAR(50) NOT NULL,
  LastName VARCHAR(50) NOT NULL,
  MiddleName VARCHAR(50) NULL,
  JobTitle VARCHAR(50) NOT NULL,
  DepartmentID int NOT NULL,
  ManagerID int NULL,
  HireDate smalldatetime NOT NULL,
  Salary money NOT NULL,
  AddressID int NULL,
  CONSTRAINT PK_Employees PRIMARY KEY CLUSTERED (EmployeeID ASC)
)
GO

SET IDENTITY_INSERT Employees ON
INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID) VALUES
	 (1, 'Guy', 'Gilbert', 'R', 'Production Technician', 7, 16, '19980731', 12500, 166)										,(2, 'Kevin', 'Brown', 'F', 'Marketing Assistant', 4, 6, '19990226', 13500, 102)
	,(3, 'Roberto', 'Tamburello', NULL, 'Engineering Manager', 1, 12, '19991212', 43300, 193)								,(4, 'Rob', 'Walters', NULL, 'Senior Tool Designer', 2, 3, '20000105', 29800, 155)
	,(5, 'Thierry', 'D''Hers', 'B', 'Tool Designer', 2, 263, '20000111', 25000, 40)											,(6, 'David', 'Bradley', 'M', 'Marketing Manager', 5, 109, '20000120', 37500, 199)
	,(7, 'JoLynn', 'Dobney', 'M', 'Production Supervisor', 7, 21, '20000126', 25000, 275)									,(8, 'Ruth', 'Ellerbrock', 'Ann', 'Production Technician', 7, 185, '20000206', 13500, 108)
	,(9, 'Gail', 'Erickson', 'A', 'Design Engineer', 1, 3, '20000206', 32700, 22)											,(10, 'Barry', 'Johnson', 'K', 'Production Technician', 7, 185, '20000207', 13500, 285)
	,(11, 'Jossef', 'Goldberg', 'H', 'Design Engineer', 1, 3, '20000224', 32700, 214)										,(12, 'Terri', 'Duffy', 'Lee', 'Vice President of Engineering', 1, 109, '20000303', 63500, 209)
	,(13, 'Sidney', 'Higa', 'M', 'Production Technician', 7, 185, '20000305', 13500, 73)									,(14, 'Taylor', 'Maxwell', 'R', 'Production Supervisor', 7, 21, '20000311', 25000, 82)
	,(15, 'Jeffrey', 'Ford', 'L', 'Production Technician', 7, 185, '20000323', 13500, 156)									,(16, 'Jo', 'Brown', 'A', 'Production Supervisor', 7, 21, '20000330', 25000, 70)
	,(17, 'Doris', 'Hartwig', 'M', 'Production Technician', 7, 185, '20000411', 13500, 144)									,(18, 'John', 'Campbell', 'T', 'Production Supervisor', 7, 21, '20000418', 25000, 245)
	,(19, 'Diane', 'Glimp', 'R', 'Production Technician', 7, 185, '20000429', 13500, 184)									,(20, 'Steven', 'Selikoff', 'T', 'Production Technician', 7, 173, '20010102', 9500, 104)
	,(21, 'Peter', 'Krebs', 'J', 'Production Control Manager', 8, 148, '20010102', 24500, 11)								,(22, 'Stuart', 'Munson', 'V', 'Production Technician', 7, 197, '20010103', 10000, 36)
	,(23, 'Greg', 'Alderson', 'F', 'Production Technician', 7, 197, '20010103', 10000, 18)									,(24, 'David', 'Johnson', '', 'Production Technician', 7, 184, '20010103', 9500, 142)
	,(25, 'Zheng', 'Mu', 'W', 'Production Supervisor', 7, 21, '20010104', 25000, 278)										,(26, 'Ivo', 'Salmre', 'William', 'Production Technician', 7, 108, '20010105', 14000, 165)
	,(27, 'Paul', 'Komosinski', 'B', 'Production Technician', 7, 87, '20010105', 15000, 32)									,(28, 'Ashvini', 'Sharma', 'R', 'Network Administrator', 11, 150, '20010105', 32500, 133)
	,(29, 'Kendall', 'Keil', 'C', 'Production Technician', 7, 14, '20010106', 11000, 257)									,(30, 'Paula', 'Barreto de Mattos', 'M', 'Human Resources Manager', 9, 140, '20010107', 27100, 2)
	,(31, 'Alejandro', 'McGuel', 'E', 'Production Technician', 7, 210, '20010107', 15000, 274)								,(32, 'Garrett', 'Young', 'R', 'Production Technician', 7, 184, '20010108', 9500, 283)
	,(33, 'Jian Shuo', 'Wang', NULL, 'Production Technician', 7, 135, '20010108', 9500, 160)								,(34, 'Susan', 'Eaton', 'W', 'Stocker', 15, 85, '20010108', 9000, 204)
	,(35, 'Vamsi', 'Kuppa', '', 'Shipping and Receiving Clerk', 15, 85, '20010108', 9500, 51)								,(36, 'Alice', 'Ciccu', 'O', 'Production Technician', 7, 38, '20010108', 11000, 284)
	,(37, 'Simon', 'Rapier', 'D', 'Production Technician', 7, 7, '20010109', 12500, 64)										,(38, 'Jinghao', 'Liu', 'K', 'Production Supervisor', 7, 21, '20010109', 25000, 55)
	,(39, 'Michael', 'Hines', 'T', 'Production Technician', 7, 182, '20010110', 14000, 168)									,(40, 'Yvonne', 'McKay', 'S', 'Production Technician', 7, 159, '20010110', 10000, 107)
	,(41, 'Peng', 'Wu', 'J', 'Quality Assurance Supervisor', 13, 200, '20010110', 21600, 39)								,(42, 'Jean', 'Trenary', 'E', 'Information Services Manager', 11, 109, '20010112', 50500, 194)
	,(43, 'Russell', 'Hunter', NULL, 'Production Technician', 7, 74, '20010113', 11000, 258)								,(44, 'A. Scott', 'Wright', NULL, 'Master Scheduler', 8, 148, '20010113', 23600, 172)
	,(45, 'Fred', 'Northup', 'T', 'Production Technician', 7, 210, '20010113', 15000, 282)									,(46, 'Sariya', 'Harnpadoungsataya', 'E', 'Marketing Specialist', 4, 6, '20010113', 14400, 106)
	,(47, 'Willis', 'Johnson', 'T', 'Recruiter', 9, 30, '20010114', 18300, 99)												,(48, 'Jun', 'Cao', 'T', 'Production Technician', 7, 38, '20010115', 11000, 197)
	,(49, 'Christian', 'Kleinerman', 'E', 'Maintenance Supervisor', 14, 218, '20010115', 20400, 118)						,(50, 'Susan', 'Metters', 'A', 'Production Technician', 7, 184, '20010115', 9500, 224)
	,(51, 'Reuben', 'D''sa', 'H', 'Production Supervisor', 7, 21, '20010116', 25000, 249)									,(52, 'Kirk', 'Koenigsbauer', 'J', 'Production Technician', 7, 123, '20010116', 10000, 250)
	,(53, 'David', 'Ortiz', 'J', 'Production Technician', 7, 18, '20010116', 12500, 267)									,(54, 'Tengiz', 'Kharatishvili', '', 'Control Specialist', 12, 90, '20010117', 16800, 129)
	,(55, 'Hanying', 'Feng', 'P', 'Production Technician', 7, 143, '20010117', 14000, 182)									,(56, 'Kevin', 'Liu', 'H', 'Production Technician', 7, 210, '20010118', 15000, 259)
	,(57, 'Annik', 'Stahl', 'O', 'Production Technician', 7, 16, '20010118', 12500, 262)									,(58, 'Suroor', 'Fatima', 'R', 'Production Technician', 7, 38, '20010118', 11000, 86)
	,(59, 'Deborah', 'Poe', 'E', 'Accounts Receivable Specialist', 10, 139, '20010119', 19000, 103)							,(60, 'Jim', 'Scardelis', 'H', 'Production Technician', 7, 74, '20010120', 11000, 88)
	,(61, 'Carole', 'Poland', 'M', 'Production Technician', 7, 173, '20010120', 9500, 72)									,(62, 'George', 'Li', 'Z', 'Production Technician', 7, 184, '20010122', 9500, 58)
	,(63, 'Gary', 'Yukish', 'W', 'Production Technician', 7, 87, '20010123', 15000, 80)										,(64, 'Cristian', 'Petculescu', 'K', 'Production Supervisor', 7, 21, '20010123', 25000, 276)
	,(65, 'Raymond', 'Sam', 'K', 'Production Technician', 7, 143, '20010124', 14000, 75)									,(66, 'Janaina', 'Bueno', 'Barreiro Gambaro', 'Application Specialist', 11, 42, '20010124', 27400, 131)
	,(67, 'Bob', 'Hohman', '', 'Production Technician', 7, 14, '20010125', 11000, 44)										,(68, 'Shammi', 'Mohamed', 'G', 'Production Technician', 7, 210, '20010125', 15000, 4)
	,(69, 'Linda', 'Moschell', 'K', 'Production Technician', 7, 38, '20010126', 11000, 5)									,(70, 'Mindy', 'Martin', 'C', 'Benefits Specialist', 9, 30, '20010126', 16600, 171)
	,(71, 'Wendy', 'Kahn', 'Beth', 'Finance Manager', 10, 140, '20010126', 43300, 232)										,(72, 'Kim', 'Ralls', 'T', 'Stocker', 15, 85, '20010127', 9000, 42)
	,(73, 'Sandra', 'Reategui Alayo', NULL, 'Production Technician', 7, 135, '20010127', 9500, 255)							,(74, 'Kok-Ho', 'Loh', 'T', 'Production Supervisor', 7, 21, '20010128', 25000, 10)
	,(75, 'Douglas', 'Hite', 'B', 'Production Technician', 7, 159, '20010128', 10000, 57)									,(76, 'James', 'Kramer', 'D', 'Production Technician', 7, 7, '20010128', 12500, 162)
	,(77, 'Sean', 'Alexander', 'P', 'Quality Assurance Technician', 13, 41, '20010129', 10600, 210)							,(78, 'Nitin', 'Mirchandani', 'S', 'Production Technician', 7, 182, '20010129', 14000, 231)
	,(79, 'Diane', 'Margheim', 'L', 'Research and Development Engineer', 6, 158, '20010130', 40900, 111)					,(80, 'Rebecca', 'Laszlo', 'A', 'Production Technician', 7, 16, '20010130', 12500, 6)
	,(81, 'Rajesh', 'Patel', 'M', 'Production Technician', 7, 210, '20010201', 15000, 81)									,(82, 'Vidur', 'Luthra', 'X', 'Recruiter', 9, 30, '20010202', 18300, 176)
	,(83, 'John', 'Evans', 'P', 'Production Technician', 7, 38, '20010202', 11000, 253)										,(84, 'Nancy', 'Anderson', 'A', 'Production Technician', 7, 7, '20010203', 12500, 227)
	,(85, 'Pilar', 'Ackerman', 'G', 'Shipping and Receiving Supervisor', 15, 21, '20010203', 19200, 269)					,(86, 'David', 'Yalovsky', 'A', 'Production Technician', 7, 184, '20010203', 9500, 241)
	,(87, 'David', 'Hamilton', 'P', 'Production Supervisor', 7, 21, '20010204', 25000, 150)									,(88, 'Laura', 'Steele', 'C', 'Production Technician', 7, 123, '20010204', 10000, 62)
	,(89, 'Margie', 'Shoop', 'W', 'Production Technician', 7, 16, '20010205', 12500, 92)									,(90, 'Zainal', 'Arifin', 'T', 'Document Control Manager', 12, 200, '20010205', 17800, 128)
	,(91, 'Lorraine', 'Nay', 'O', 'Production Technician', 7, 210, '20010205', 15000, 94)									,(92, 'Fadi', 'Fakhouri', 'K', 'Production Technician', 7, 143, '20010205', 14000, 281)
	,(93, 'Ryan', 'Cornelsen', 'L', 'Production Technician', 7, 51, '20010206', 15000, 228)									,(94, 'Candy', 'Spoon', 'L', 'Accounts Receivable Specialist', 10, 139, '20010207', 19000, 122)
	,(95, 'Nuan', 'Yu', NULL, 'Production Technician', 7, 74, '20010207', 11000, 12)										,(96, 'William', 'Vong', 'S', 'Scheduling Assistant', 8, 44, '20010208', 16000, 35)
	,(97, 'Bjorn', 'Rettig', 'M', 'Production Technician', 7, 173, '20010208', 9500, 268)									,(98, 'Scott', 'Gode', 'R', 'Production Technician', 7, 197, '20010209', 10000, 256)
	,(99, 'Michael', 'Rothkugel', 'L', 'Production Technician', 7, 87, '20010211', 15000, 93)								,(100, 'Lane', 'Sacksteder', 'M', 'Production Technician', 7, 143, '20010212', 14000, 239)
	,(101, 'Pete', 'Male', 'C', 'Production Technician', 7, 14, '20010212', 11000, 273)										,(102, 'Dan', 'Bacon', 'K', 'Application Specialist', 11, 42, '20010212', 27400, 126)
	,(103, 'David', 'Barber', 'M', 'Assistant to the Chief Financial Officer', 10, 140, '20010213', 13500, 173)				,(104, 'Lolan', 'Song', 'B', 'Production Technician', 7, 74, '20010213', 11000, 77)
	,(105, 'Paula', 'Nartker', 'R', 'Production Technician', 7, 210, '20010213', 15000, 247)								,(106, 'Mary', 'Gibson', 'E', 'Marketing Specialist', 4, 6, '20010213', 14400, 110)
	,(107, 'Mindaugas', 'Krapauskas', 'J', 'Production Technician', 7, 38, '20010214', 11000, 74)							,(108, 'Eric', 'Gubbels', NULL, 'Production Supervisor', 7, 21, '20010215', 25000, 85)
	,(109, 'Ken', 'Sanchez', 'J', 'Chief Executive Officer', 16, NULL, '20010215', 125500, 177)								,(110, 'Jason', 'Watters', 'M', 'Production Technician', 7, 135, '20010215', 9500, 21)
	,(111, 'Mark', 'Harrington', 'L', 'Quality Assurance Technician', 13, 41, '20010216', 10600, 139)						,(112, 'Janeth', 'Esteves', 'M', 'Production Technician', 7, 159, '20010216', 10000, 163)
	,(113, 'Marc', 'Ingle', 'J', 'Production Technician', 7, 184, '20010217', 9500, 230)									,(114, 'Gigi', 'Matthew', '', 'Research and Development Engineer', 6, 158, '20010217', 40900, 23)
	,(115, 'Paul', 'Singh', 'R', 'Production Technician', 7, 108, '20010218', 14000, 16)									,(116, 'Frank', 'Lee', 'T', 'Production Technician', 7, 210, '20010218', 15000, 263)
	,(117, 'Francois', 'Ajenstat', 'P', 'Database Administrator', 11, 42, '20010218', 38500, 127)							,(118, 'Diane', 'Tibbott', 'H', 'Production Technician', 7, 14, '20010219', 11000, 140)
	,(119, 'Jill', 'Williams', 'A', 'Marketing Specialist', 4, 6, '20010219', 14400, 114)									,(120, 'Angela', 'Barbariol', 'W', 'Production Technician', 7, 38, '20010221', 11000, 91)
	,(121, 'Matthias', 'Berndt', 'T', 'Shipping and Receiving Clerk', 15, 85, '20010221', 9500, 201)						,(122, 'Bryan', 'Baker', NULL, 'Production Technician', 7, 7, '20010222', 12500, 166)
	,(123, 'Jeff', 'Hay', 'V', 'Production Supervisor', 7, 21, '20010222', 25000, 113)										,(124, 'Eugene', 'Zabokritski', 'R', 'Production Technician', 7, 184, '20010222', 9500, 226)
	,(125, 'Barbara', 'Decker', 'S', 'Production Technician', 7, 182, '20010223', 14000, 219)								,(126, 'Chris', 'Preston', 'T', 'Production Technician', 7, 123, '20010223', 10000, 279)
	,(127, 'Sean', 'Chai', '', 'Document Control Assistant', 12, 90, '20010223', 10300, 138)								,(128, 'Dan', 'Wilson', 'B', 'Database Administrator', 11, 42, '20010223', 38500, 30)
	,(129, 'Mark', 'McArthur', 'K', 'Production Technician', 7, 16, '20010224', 12500, 186)									,(130, 'Bryan', 'Walton', 'A', 'Accounts Receivable Specialist', 10, 139, '20010225', 19000, 175)
	,(131, 'Houman', 'Pournasseh', '', 'Production Technician', 7, 74, '20010226', 11000, 185)								,(132, 'Sairaj', 'Uddin', 'L', 'Scheduling Assistant', 8, 44, '20010227', 16000, 190)
	,(133, 'Michiko', 'Osada', 'F', 'Production Technician', 7, 173, '20010227', 9500, 229)									,(134, 'Benjamin', 'Martin', 'R', 'Production Technician', 7, 184, '20010228', 9500, 286)
	,(135, 'Cynthia', 'Randall', 'S', 'Production Supervisor', 7, 21, '20010228', 25000, 147)								,(136, 'Kathie', 'Flood', 'E', 'Production Technician', 7, 197, '20010228', 10000, 100)
	,(137, 'Britta', 'Simon', 'L', 'Production Technician', 7, 16, '20010302', 12500, 95)									,(138, 'Brian', 'Lloyd', 'T', 'Production Technician', 7, 210, '20010302', 15000, 288)
	,(139, 'David', 'Liu', 'J', 'Accounts Manager', 10, 140, '20010303', 34700, 119)										,(140, 'Laura', 'Norman', 'F', 'Chief Financial Officer', 16, 109, '20010304', 60100, 215)
	,(141, 'Michael', 'Patten', 'W', 'Production Technician', 7, 38, '20010304', 11000, 96)									,(142, 'Andy', 'Ruth', 'M', 'Production Technician', 7, 135, '20010304', 9500, 1)
	,(143, 'Yuhong', 'Li', 'L', 'Production Supervisor', 7, 21, '20010305', 25000, 242)										,(144, 'Robert', 'Rounthwaite', 'J', 'Production Technician', 7, 159, '20010306', 10000, 280)
	,(145, 'Andreas', 'Berglund', 'T', 'Quality Assurance Technician', 13, 41, '20010306', 10600, 208)						,(146, 'Reed', 'Koch', 'T', 'Production Technician', 7, 184, '20010306', 9500, 191)
	,(147, 'Linda', 'Randall', 'A', 'Production Technician', 7, 143, '20010307', 14000, 260)								,(148, 'James', 'Hamilton', 'R', 'Vice President of Production', 7, 109, '20010307', 84100, 158)
	,(149, 'Ramesh', 'Meyyappan', 'V', 'Application Specialist', 11, 42, '20010307', 27400, 130)							,(150, 'Stephanie', 'Conroy', 'A', 'Network Manager', 11, 42, '20010308', 39700, 136)
	,(151, 'Samantha', 'Smith', 'H', 'Production Technician', 7, 108, '20010308', 14000, 14)								,(152, 'Tawana', 'Nusbaum', 'G', 'Production Technician', 7, 210, '20010309', 15000, 237)
	,(153, 'Denise', 'Smith', 'H', 'Production Technician', 7, 14, '20010309', 11000, 143)									,(154, 'Hao', 'Chen', 'O', 'Human Resources Administrative Assistant', 9, 30, '20010310', 13900, 135)
	,(155, 'Alex', 'Nayberg', 'M', 'Production Technician', 7, 123, '20010312', 10000, 174)									,(156, 'Eugene', 'Kogan', 'O', 'Production Technician', 7, 7, '20010312', 12500, 71)
	,(157, 'Brandon', 'Heidepriem', 'G', 'Production Technician', 7, 16, '20010312', 12500, 189)							,(158, 'Dylan', 'Miller', 'A', 'Research and Development Manager', 6, 3, '20010312', 50500, 141)
	,(159, 'Shane', 'Kim', 'S', 'Production Supervisor', 7, 21, '20010312', 25000, 20)										,(160, 'John', 'Chen', 'Y', 'Production Technician', 7, 182, '20010313', 14000, 65)
	,(161, 'Karen', 'Berge', 'R', 'Document Control Assistant', 12, 90, '20010313', 10300, 123)								,(162, 'Jose', 'Lugo', 'R', 'Production Technician', 7, 16, '20010314', 12500, 271)
	,(163, 'Mandar', 'Samant', 'H', 'Production Technician', 7, 74, '20010314', 11000, 63)									,(164, 'Mikael', 'Sandberg', 'Q', 'Buyer', 5, 274, '20010314', 18300, 50)
	,(165, 'Sameer', 'Tejani', 'A', 'Production Technician', 7, 74, '20010315', 11000, 66)									,(166, 'Dragan', 'Tomic', 'K', 'Accounts Payable Specialist', 10, 139, '20010315', 19000, 115)
	,(167, 'Carol', 'Philips', 'M', 'Production Technician', 7, 173, '20010316', 9500, 45)									,(168, 'Rob', 'Caron', 'T', 'Production Technician', 7, 87, '20010317', 15000, 161)
	,(169, 'Don', 'Hall', 'L', 'Production Technician', 7, 38, '20010317', 11000, 59)										,(170, 'Alan', 'Brewer', 'J', 'Scheduling Assistant', 8, 44, '20010317', 16000, 151)
	,(171, 'David', 'Lawrence', 'Oliver', 'Production Technician', 7, 184, '20010318', 9500, 167)							,(172, 'Baris', 'Cetinok', 'F', 'Production Technician', 7, 87, '20010319', 15000, 244)
	,(173, 'Michael', 'Ray', 'Sean', 'Production Supervisor', 7, 21, '20010319', 25000, 277)								,(174, 'Steve', 'Masters', 'F', 'Production Technician', 7, 18, '20010319', 12500, 252)
	,(175, 'Suchitra', 'Mohan', 'O', 'Production Technician', 7, 16, '20010320', 12500, 31)									,(176, 'Karen', 'Berg', 'A', 'Application Specialist', 11, 42, '20010320', 27400, 132)
	,(177, 'Terrence', 'Earls', 'W', 'Production Technician', 7, 143, '20010320', 14000, 34)								,(178, 'Barbara', 'Moreland', 'C', 'Accountant', 10, 139, '20010322', 26400, 254)
	,(179, 'Chad', 'Niswonger', 'W', 'Production Technician', 7, 38, '20010322', 11000, 46)									,(180, 'Rostislav', 'Shabalin', 'E', 'Production Technician', 7, 135, '20010323', 9500, 9)
	,(181, 'Belinda', 'Newman', 'M', 'Production Technician', 7, 197, '20010324', 10000, 43)								,(182, 'Katie', 'McAskill-White', 'L', 'Production Supervisor', 7, 21, '20010324', 25000, 240)
	,(183, 'Russell', 'King', 'M', 'Production Technician', 7, 184, '20010325', 9500, 3)									,(184, 'Jack', 'Richins', 'S', 'Production Supervisor', 7, 21, '20010325', 25000, 169)
	,(185, 'Andrew', 'Hill', 'R', 'Production Supervisor', 7, 21, '20010326', 25000, 97)									,(186, 'Nicole', 'Holliday', 'B', 'Production Technician', 7, 87, '20010326', 15000, 238)
	,(187, 'Frank', 'Miller', 'T', 'Production Technician', 7, 14, '20010327', 11000, 289)									,(188, 'Peter', 'Connelly', 'I', 'Network Administrator', 11, 150, '20010327', 32500, 137)
	,(189, 'Anibal', 'Sousa', 'T', 'Production Technician', 7, 108, '20010327', 14000, 183)									,(190, 'Ken', 'Myer', 'L', 'Production Technician', 7, 210, '20010328', 15000, 105)
	,(191, 'Grant', 'Culbertson', '', 'Human Resources Administrative Assistant', 9, 30, '20010329', 13900, 117)			,(192, 'Michael', 'Entin', 'T', 'Production Technician', 7, 38, '20010329', 11000, 195)
	,(193, 'Lionel', 'Penuchot', 'C', 'Production Technician', 7, 159, '20010330', 10000, 261)								,(194, 'Thomas', 'Michaels', 'R', 'Production Technician', 7, 7, '20010330', 12500, 78)
	,(195, 'Jimmy', 'Bischoff', 'T', 'Stocker', 15, 85, '20010330', 9000, 206)												,(196, 'Michael', 'Vanderhyde', 'T', 'Production Technician', 7, 135, '20010330', 9500, 90)
	,(197, 'Lori', 'Kane', 'A', 'Production Supervisor', 7, 21, '20010330', 25000, 198)										,(198, 'Arvind', 'Rao', 'B', 'Buyer', 5, 274, '20010401', 18300, 212)
	,(199, 'Stefen', 'Hesse', 'A', 'Production Technician', 7, 182, '20010401', 14000, 68)									,(200, 'Hazem', 'Abolrous', 'E', 'Quality Assurance Manager', 13, 148, '20010401', 28800, 148)
	,(201, 'Janet', 'Sheperdigian', 'L', 'Accounts Payable Specialist', 10, 139, '20010402', 19000, 218)					,(202, 'Elizabeth', 'Keyser', 'I', 'Production Technician', 7, 74, '20010403', 11000, 152)
	,(203, 'Terry', 'Eminhizer', 'J', 'Marketing Specialist', 4, 6, '20010403', 14400, 19)									,(204, 'John', 'Frum', '', 'Production Technician', 7, 184, '20010404', 9500, 112)
	,(205, 'Merav', 'Netz', 'A', 'Production Technician', 7, 173, '20010404', 9500, 270)									,(206, 'Brian', 'LaMee', 'P', 'Scheduling Assistant', 8, 44, '20010404', 16000, 109)
	,(207, 'Kitti', 'Lertpiriyasuwat', 'H', 'Production Technician', 7, 38, '20010405', 11000, 272)							,(208, 'Jay', 'Adams', 'G', 'Production Technician', 7, 18, '20010406', 12500, 157)
	,(209, 'Jan', 'Miksovsky', 'S', 'Production Technician', 7, 184, '20010406', 9500, 101)									,(210, 'Brenda', 'Diaz', 'M', 'Production Supervisor', 7, 21, '20010406', 25000, 251)
	,(211, 'Andrew', 'Cencini', 'M', 'Production Technician', 7, 123, '20010407', 10000, 233)								,(212, 'Chris', 'Norred', 'K', 'Control Specialist', 12, 90, '20010407', 16800, 125)
	,(213, 'Chris', 'Okelberry', 'O', 'Production Technician', 7, 16, '20010408', 12500, 188)								,(214, 'Shelley', 'Dyck', '', 'Production Technician', 7, 143, '20010408', 14000, 164)
	,(215, 'Gabe', 'Mares', 'B', 'Production Technician', 7, 210, '20010409', 15000, 87)									,(216, 'Mike', 'Seamans', 'K', 'Accountant', 10, 139, '20010409', 26400, 120)
	,(217, 'Michael', 'Raheem', NULL, 'Research and Development Manager', 6, 158, '20010604', 42500, 236)					,(218, 'Gary', 'Altman', 'E.', 'Facilities Manager', 14, 148, '20020103', 24000, 203)
	,(219, 'Charles', 'Fitzgerald', 'B', 'Production Technician', 7, 18, '20020104', 12500, 223)							,(220, 'Ebru', 'Ersan', '', 'Production Technician', 7, 25, '20020107', 13500, 225)
	,(221, 'Sylvester', 'Valdez', 'A', 'Production Technician', 7, 108, '20020112', 14000, 25)								,(222, 'Brian', 'Goldstein', 'Richard', 'Production Technician', 7, 51, '20020112', 15000, 48)
	,(223, 'Linda', 'Meisner', 'P', 'Buyer', 5, 274, '20020118', 18300, 28)													,(224, 'Betsy', 'Stadick', 'A', 'Production Technician', 7, 64, '20020119', 13500, 47)
	,(225, 'Magnus', 'Hedlund', 'E', 'Facilities Administrative Assistant', 14, 218, '20020122', 9800, 211)					,(226, 'Karan', 'Khanna', 'R', 'Production Technician', 7, 18, '20020123', 12500, 248)
	,(227, 'Mary', 'Baker', 'R', 'Production Technician', 7, 25, '20020126', 13500, 246)									,(228, 'Kevin', 'Homer', 'M', 'Production Technician', 7, 25, '20020126', 13500, 29)
	,(229, 'Mihail', 'Frintu', 'U', 'Production Technician', 7, 51, '20020130', 15000, 89)									,(230, 'Bonnie', 'Kearney', '', 'Production Technician', 7, 185, '20020202', 13500, 287)
	,(231, 'Fukiko', 'Ogisu', 'J', 'Buyer', 5, 274, '20020205', 18300, 17)													,(232, 'Hung-Fu', 'Ting', 'T', 'Production Technician', 7, 108, '20020207', 14000, 220)
	,(233, 'Gordon', 'Hee', 'L', 'Buyer', 5, 274, '20020212', 18300, 15)													,(234, 'Kimberly', 'Zimmerman', 'B', 'Production Technician', 7, 64, '20020213', 13500, 266)
	,(235, 'Kim', 'Abercrombie', 'B', 'Production Technician', 7, 16, '20020217', 12500, 56)								,(236, 'Sandeep', 'Kaliyath', 'P', 'Production Technician', 7, 51, '20020218', 15000, 234)
	,(237, 'Prasanna', 'Samarawickrama', 'E', 'Production Technician', 7, 108, '20020223', 14000, 187)						,(238, 'Frank', 'Pellow', 'S', 'Buyer', 5, 274, '20020224', 18300, 213)
	,(239, 'Min', 'Su', 'G', 'Production Technician', 7, 108, '20020225', 14000, 24)										,(240, 'Eric', 'Brown', 'L', 'Production Technician', 7, 51, '20020225', 15000, 67)
	,(241, 'Eric', 'Kurjan', 'S', 'Buyer', 5, 274, '20020228', 18300, 207)													,(242, 'Pat', 'Coleman', 'H', 'Janitor', 14, 49, '20020228', 9300, 116)
	,(243, 'Maciej', 'Dusza', 'W', 'Production Technician', 7, 18, '20020301', 12500, 83)									,(244, 'Erin', 'Hagens', 'M', 'Buyer', 5, 274, '20020303', 18300, 8)
	,(245, 'Patrick', 'Wedge', 'C', 'Production Technician', 7, 64, '20020304', 13500, 7)									,(246, 'Frank', 'Martinez', 'R', 'Production Technician', 7, 51, '20020308', 15000, 290)
	,(247, 'Ed', 'Dudenhoefer', 'R', 'Production Technician', 7, 16, '20020308', 12500, 243)								,(248, 'Christopher', 'Hill', 'E', 'Production Technician', 7, 25, '20020311', 13500, 41)
	,(249, 'Patrick', 'Cook', 'M', 'Production Technician', 7, 51, '20020315', 15000, 264)									,(250, 'Krishna', 'Sunkammurali', NULL, 'Production Technician', 7, 108, '20020316', 14000, 79)
	,(251, 'Lori', 'Penor', 'K', 'Janitor', 14, 49, '20020319', 9300, 124)													,(252, 'Danielle', 'Tiedt', 'C', 'Production Technician', 7, 64, '20020323', 13500, 146)
	,(253, 'Sootha', 'Charncherngkha', 'T', 'Quality Assurance Technician', 13, 41, '20020326', 10600, 149)					,(254, 'Michael', 'Zwilling', 'J', 'Production Technician', 7, 18, '20020326', 12500, 76)
	,(255, 'Randy', 'Reeves', 'T', 'Production Technician', 7, 18, '20020326', 12500, 84)									,(256, 'John', 'Kane', 'T', 'Production Technician', 7, 25, '20020330', 13500, 69)
	,(257, 'Jack', 'Creasey', 'T', 'Production Technician', 7, 51, '20020403', 15000, 265)									,(258, 'Olinda', 'Turner', 'C', 'Production Technician', 7, 108, '20020404', 14000, 33)
	,(259, 'Stuart', 'Macrae', 'J', 'Janitor', 14, 49, '20020405', 9300, 205)												,(260, 'Jo', 'Berry', 'L', 'Janitor', 14, 49, '20020407', 9300, 121)
	,(261, 'Ben', 'Miller', 'T', 'Buyer', 5, 274, '20020409', 18300, 192)													,(262, 'Tom', 'Vande Velde', 'M', 'Production Technician', 7, 64, '20020410', 13500, 98)
	,(263, 'Ovidiu', 'Cracium', 'V', 'Senior Tool Designer', 2, 3, '20030105', 28800, 145)									,(264, 'Annette', 'Hill', 'L', 'Purchasing Assistant', 5, 274, '20030106', 12800, 181)
	,(265, 'Janice', 'Galvin', 'M', 'Tool Designer', 2, 263, '20030123', 25000, 200)										,(266, 'Reinout', 'Hillmann', '', 'Purchasing Assistant', 5, 274, '20030125', 12800, 27)
	,(267, 'Michael', 'Sullivan', 'I', 'Senior Design Engineer', 1, 3, '20030130', 36100, 217)								,(268, 'Stephen', 'Jiang', 'Y', 'North American Sales Manager', 3, 273, '20030204', 48100, 196)
	,(269, 'Wanida', 'Benshoof', 'M', 'Marketing Assistant', 4, 6, '20030207', 13500, 221)									,(270, 'Sharon', 'Salavaria', 'B', 'Design Engineer', 1, 3, '20030218', 32700, 216)
	,(271, 'John', 'Wood', 'L', 'Marketing Specialist', 4, 6, '20030310', 14400, 180)										,(272, 'Mary', 'Dempsey', 'A', 'Marketing Assistant', 4, 6, '20030317', 13500, 26)
	,(273, 'Brian', 'Welcker', 'S', 'Vice President of Sales', 3, 109, '20030318', 72100, 134)								,(274, 'Sheela', 'Word', 'H', 'Purchasing Manager', 13, 71, '20030328', 30000, 222)
	,(275, 'Michael', 'Blythe', 'G', 'Sales Representative', 3, 268, '20030701', 23100, 60)									,(276, 'Linda', 'Mitchell', 'C', 'Sales Representative', 3, 268, '20030701', 23100, 170)
	,(277, 'Jillian', 'Carson', NULL, 'Sales Representative', 3, 268, '20030701', 23100, 61)								,(278, 'Garrett', 'Vargas', 'R', 'Sales Representative', 3, 268, '20030701', 23100, 52)
	,(279, 'Tsvi', 'Reiter', 'Michael', 'Sales Representative', 3, 268, '20030701', 23100, 154)								,(280, 'Pamela', 'Ansman-Wolfe', 'O', 'Sales Representative', 3, 268, '20030701', 23100, 179)
	,(281, 'Shu', 'Ito', 'K', 'Sales Representative', 3, 268, '20030701', 23100, 235)										,(282, 'Jose', 'Saraiva', 'Edvaldo', 'Sales Representative', 3, 268, '20030701', 23100, 178)
	,(283, 'David', 'Campbell', 'R', 'Sales Representative', 3, 268, '20030701', 23100, 13)									,(284, 'Amy', 'Alberts', 'E', 'European Sales Manager', 3, 273, '20040518', 48100, 202)
	,(285, 'Jae', 'Pak', 'B', 'Sales Representative', 3, 284, '20040701', 23100, 54)										,(286, 'Ranjit', 'Varkey Chudukatil', 'R', 'Sales Representative', 3, 284, '20040701', 23100, 38)
	,(287, 'Tete', 'Mensa-Annan', 'A', 'Sales Representative', 3, 268, '20041101', 23100, 53)								,(288, 'Syed', 'Abbas', 'E', 'Pacific Sales Manager', 3, 273, '20050415', 48100, 49)
	,(289, 'Rachel', 'Valdez', 'B', 'Sales Representative', 3, 284, '20050701', 23100, 37)									,(290, 'Lynn', 'Tsoflias', '', 'Sales Representative', 3, 288, '20050701', 23100, 153)
	,(291, 'Svetlin', 'Nakov', 'Ivanov', 'Independent Software Development  Consultant', 6, NULL, '20050301', 48000, 291)	,(292, 'Martin', 'Kulov', NULL, 'Independent .NET Consultant', 6, NULL, '20050301', 48000, 291)
	,(293, 'George', 'Denchev', NULL, 'Independent Java Consultant', 6, NULL, '20050301', 48000, 291)
SET IDENTITY_INSERT Employees OFF
GO

ALTER TABLE Employees
ADD CONSTRAINT FK_Employees_Addresses FOREIGN KEY(AddressID)
REFERENCES Addresses(AddressID)
GO

ALTER TABLE Employees
ADD CONSTRAINT FK_Employees_Departments FOREIGN KEY(DepartmentID)
REFERENCES Departments(DepartmentID)
GO

ALTER TABLE Employees
ADD CONSTRAINT FK_Employees_Employees FOREIGN KEY(ManagerID)
REFERENCES Employees(EmployeeID)
GO

ALTER TABLE EmployeesProjects
ADD CONSTRAINT FK_EmployeesProjects_Employees FOREIGN KEY(EmployeeID)
REFERENCES Employees(EmployeeID)
GO

ALTER TABLE EmployeesProjects
ADD CONSTRAINT FK_EmployeesProjects_Projects FOREIGN KEY(ProjectID)
REFERENCES Projects(ProjectID)
GO

ALTER TABLE Departments
ADD CONSTRAINT FK_Departments_Employees FOREIGN KEY(ManagerID)
REFERENCES Employees(EmployeeID)
GO

ALTER TABLE Addresses
ADD CONSTRAINT FK_Addresses_Towns FOREIGN KEY(TownID)
REFERENCES Towns(TownID)
GO

/*--- PROBLEM ------------ ADDRESSES WITH TOWNS ---------*/
USE SoftUni

SELECT TOP (50) e.FirstName
			   ,e.LastName
			   ,t.[Name] AS Town
			   ,a.AddressText
FROM Employees AS e
JOIN Addresses a ON e.AddressID = a.AddressID
JOIN Towns t ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName

/*--- PROBLEM ------------ SALES EMPLOYEES --------------*/
SELECT e.EmployeeID
	  ,e.FirstName
	  ,e.LastName 
	  ,d.[Name] AS DepartmentName
FROM Employees AS e 
INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID

/*--- PROBLEM ------------ EMPLOYEES HIRED AFTER --------*/
SELECT e.FirstName
	  ,e.LastName
	  ,e.HireDate
	  ,d.[Name] as DeptName
FROM Employees AS e
INNER JOIN Departments d ON (e.DepartmentId = d.DepartmentId AND e.HireDate > '1/1/1999' 
															 AND d.[Name] IN ('Sales', 'Finance'))
ORDER BY e.HireDate ASC

/*--- PROBLEM ------------ EMPLOYEE SUMMARY -------------*/
SELECT TOP (50) e.EmployeeID
			   ,e.FirstName + ' ' + e.LastName AS EmployeeName
			   ,m.FirstName + ' ' + m. LastName AS ManagerName
			   ,d.[Name] AS DepartmentName
FROM Employees AS e
LEFT JOIN Employees AS m ON m.EmployeeID = e.ManagerID
LEFT JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
ORDER BY e.EmployeeID ASC

/*--- PROBLEM ------------ MIN AVERAGE SALARY -----------*/
SELECT MIN(a.AverageSalary) AS MinAverageSalary
FROM 
	(
		SELECT e.DepartmentID 
			  ,AVG(e.Salary) AS AverageSalary
		FROM Employees AS e
	    GROUP BY e.DepartmentID
	) AS a

/*---------------------- EXERCISE -----------------------*/
USE SoftUni

/*--- TASK 1 --- EMPLOYEE ADDRESS -----------------------*/
SELECT TOP (5) e.EmployeeID
			  ,e.JobTitle
			  ,e.AddressID
			  ,a.AddressText 
FROM Employees AS e
JOIN Addresses AS a ON a.AddressID = e.AddressID
ORDER BY a.AddressID 

/*--- TASK 2 --- ADDRESSES WITH TOWNS -------------------*/
SELECT TOP (50) e.FirstName
			   ,e.LastName
			   ,t.[Name] AS Town
			   ,a.AddressText
FROM Employees AS e
JOIN Addresses a ON a.AddressID = e.AddressID
JOIN Towns t ON t.TownID = a.TownID
ORDER BY e.FirstName, e.LastName

/*--- TASK 3 --- SALES EMPLOYEES ------------------------*/
SELECT e.EmployeeID
	  ,e.FirstName
	  ,e.LastName 
	  ,d.[Name] AS DepartmentName
FROM Employees AS e 
INNER JOIN Departments d ON d.DepartmentID = e.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID

/*--- TASK 4 --- EMPLOYEES DEPARTMENTS ------------------*/
SELECT TOP (5) e.EmployeeID
			  ,e.FirstName
			  ,e.Salary
			  ,d.[Name] AS DepartmentName 
FROM Employees AS e
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID

/*--- TASK 5 --- EMPLOYEES WITHOUT PROJECTS -------------*/
SELECT TOP (3) e.EmployeeID
			  ,e.FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
WHERE ep.ProjectID IS NULL

/*--- TASK 6 --- EMPLOYEES HIRED AFTER ------------------*/
SELECT e.FirstName
	  ,e.LastName
	  ,e.HireDate
	  ,d.[Name] as DeptName
FROM Employees AS e
INNER JOIN Departments d ON (d.DepartmentId = e.DepartmentId AND e.HireDate > '1/1/1999' 
															 AND d.[Name] IN ('Sales', 'Finance'))
ORDER BY e.HireDate ASC

/*--- TASK 7 --- EMPLOYEES WITH PROJECT -----------------*/
SELECT TOP (5) e.EmployeeID
			  ,e.FirstName
			  ,p.[Name] AS ProjectName 
FROM Employees AS e
JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
JOIN Projects AS p ON p.ProjectID = ep.ProjectID AND p.StartDate > '2002-08-13' 
												 AND p.EndDate IS NULL
ORDER BY e.EmployeeID

/*--- TASK 8 --- EMPLOYEE 24 ----------------------------*/
SELECT e.EmployeeID
	  ,e.FirstName
	  ,CASE
			WHEN p.StartDate >= '2005-01-01' THEN NULL
			ELSE p.[Name]
	   END AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID AND e.EmployeeID = 24
JOIN Projects AS p ON p.ProjectID = ep.ProjectID

/*--- TASK 9 --- EMPLOYEE MANAGER -----------------------*/
SELECT e.EmployeeID
	  ,e.FirstName
	  ,e.ManagerID
	  ,m.FirstName AS ManagerName 
FROM Employees AS e
JOIN Employees AS m ON m.EmployeeID = e.ManagerID AND e.ManagerID IN(3, 7)
ORDER BY e.EmployeeID

/*--- TASK 10 --- EMPLOYEE SUMMARY ----------------------*/
SELECT TOP (50) e.EmployeeID
			   ,e.FirstName + ' ' + e.LastName AS EmployeeName
			   ,m.FirstName + ' ' + m. LastName AS ManagerName
			   ,d.[Name] AS DepartmentName
FROM Employees AS e
LEFT JOIN Employees AS m ON m.EmployeeID = e.ManagerID
LEFT JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
ORDER BY e.EmployeeID ASC

/*--- TASK 11 --- MIN AVERAGE SALARY --------------------*/
SELECT MIN(a.AverageSalary) AS MinAverageSalary
FROM 
	(
		SELECT e.DepartmentID 
			  ,AVG(e.Salary) AS AverageSalary
		FROM Employees AS e
	    GROUP BY e.DepartmentID
	) AS a





