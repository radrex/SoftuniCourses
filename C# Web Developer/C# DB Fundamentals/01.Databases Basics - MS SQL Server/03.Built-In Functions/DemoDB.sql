USE [master]
GO
/****** Object:  Database [Demo]    Script Date: 25.1.2017 г. 14:01:37 ******/
CREATE DATABASE [Demo]
USE [Demo]
GO

ALTER DATABASE [Demo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Demo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Demo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Demo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Demo] SET ARITHABORT OFF 
GO
ALTER DATABASE [Demo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Demo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Demo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Demo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Demo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Demo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Demo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Demo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Demo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Demo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Demo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Demo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Demo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Demo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Demo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Demo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Demo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Demo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Demo] SET  MULTI_USER 
GO
ALTER DATABASE [Demo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Demo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Demo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Demo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Demo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Demo] SET QUERY_STORE = OFF
GO
USE [Demo]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Demo]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 25.1.2017 г. 14:01:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[PaymentNumber] [char](16) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lines]    Script Date: 25.1.2017 г. 14:01:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lines](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[X1] [float] NOT NULL,
	[Y1] [float] NOT NULL,
	[X2] [float] NOT NULL,
	[Y2] [float] NOT NULL,
 CONSTRAINT [PK_Lines] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Minions]    Script Date: 25.1.2017 г. 14:01:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Minions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Age] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[People]    Script Date: 25.1.2017 г. 14:01:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Salary] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 25.1.2017 г. 14:01:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[BoxCapacity] [int] NOT NULL,
	[PalletCapacity] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rectangles]    Script Date: 25.1.2017 г. 14:01:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rectangles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[A] [float] NOT NULL,
	[B] [float] NOT NULL,
 CONSTRAINT [PK_Rectangles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Towns]    Script Date: 25.1.2017 г. 14:01:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Towns](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Triangles]    Script Date: 25.1.2017 г. 14:01:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Triangles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[A] [float] NOT NULL,
	[B] [float] NOT NULL,
	[C] [float] NOT NULL,
 CONSTRAINT [PK_Triangles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Triangles2]    Script Date: 25.1.2017 г. 14:01:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Triangles2](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[A] [float] NOT NULL,
	[H] [float] NOT NULL
) ON [PRIMARY]

GO
INSERT [dbo].[Customers] ([CustomerID], [FirstName], [LastName], [PaymentNumber]) VALUES 
	 (1, N'Guy', N'Gilbert', N'5645322227179083')						,(2, N'Kevin', N'Brown', N'4417937746396076')						,(3, N'Roberto', N'Tamburello', N'7927545745782378')
	,(4, N'Rob', N'Walters', N'8373866836827081')						,(5, N'Thierry', N'D''Hers', N'6324824830110281')					,(6, N'David', N'Bradley', N'9814901018722947')
	,(7, N'JoLynn', N'Dobney', N'4599692018956432')						,(8, N'Ruth', N'Ellerbrock', N'6122441931293978')					,(9, N'Gail', N'Erickson', N'1163087434114868')
	,(10, N'Barry', N'Johnson', N'3970818232390811')					,(11, N'Jossef', N'ldberg', N'9151658894664016')					,(12, N'Terri', N'Duffy', N'6183355082422774')
	,(13, N'Sidney', N'Higa', N'4120537582244300')						,(14, N'Taylor', N'Maxwell', N'1938568596870607')					,(15, N'Jeffrey', N'Ford', N'8915810955572860')
	,(16, N'Jo', N'Brown', N'7273205948371278')							,(17, N'Doris', N'Hartwig', N'5922753170391384')					,(18, N'John', N'Campbell', N'1209925930853143')
	,(19, N'Diane', N'Glimp', N'2476362479035343')						,(20, N'Steven', N'Selikoff', N'4815598168041326')					,(21, N'Peter', N'Krebs', N'3265508651416842')
	,(22, N'Stuart', N'Munson', N'2668216470313532')					,(23, N'Greg', N'Alderson', N'7251223138404247')					,(24, N'David', N'Johnson', N'6929964196396225')
	,(25, N'Zheng', N'Mu', N'7110549042521172')							,(26, N'Ivo', N'Salmre', N'9004736779009908')						,(27, N'Paul', N'Komosinski', N'9037774293366599')
	,(28, N'Ashvini', N'Sharma', N'8084587447142873')					,(29, N'Kendall', N'Keil', N'5872696533959082')						,(30, N'Paula', N'Barreto de Mattos', N'8844359368419097')
	,(31, N'Alejandro', N'McGuel', N'3109197055164785')					,(32, N'Garrett', N'Young', N'6519517838299156')					,(33, N'Jian Shuo', N'Wang', N'2363733520443413')
	,(34, N'Susan', N'Eaton', N'9367115272055768')						,(35, N'Vamsi', N'Kuppa', N'4209682755728257')						,(36, N'Alice', N'Ciccu', N'5267558936996135')
	,(37, N'Simon', N'Rapier', N'8970108450616046')						,(38, N'Jinghao', N'Liu', N'7432945187196856')						,(39, N'Michael', N'Hines', N'8774260387313280')
	,(40, N'Yvonne', N'McKay', N'9616182116114934')						,(41, N'Peng', N'Wu', N'6179870316211712')							,(42, N'Jean', N'Trenary', N'5296317916849649')
	,(43, N'Russell', N'Hunter', N'5775476574279567')					,(44, N'A. Scott', N'Wright', N'6518562162666714')					,(45, N'Fred', N'Northup', N'2300788501129671')
	,(46, N'Sariya', N'Harnpadoungsataya', N'8148745065538021')			,(47, N'Willis', N'Johnson', N'1624100548057725')					,(48, N'Jun', N'Cao', N'2825462680946393')
	,(49, N'Christian', N'Kleinerman', N'9625942215524469')				,(50, N'Susan', N'Metters', N'7040957321118931')					,(51, N'Reuben', N'D''sa', N'6504592353671722')
	,(52, N'Kirk', N'Koenigsbauer', N'4891114540364065')				,(53, N'David', N'Ortiz', N'3868546622008669')						,(54, N'Tengiz', N'Kharatishvili', N'8837587181443844')
	,(55, N'Hanying', N'Feng', N'2141729963267669')						,(56, N'Kevin', N'Liu', N'5682883488088952')						,(57, N'Annik', N'Stahl', N'5698978315073488')
	,(58, N'Suroor', N'Fatima', N'5374955487782798')					,(59, N'Deborah', N'Poe', N'2877525595357834')						,(60, N'Jim', N'Scardelis', N'6479803552302813')
	,(61, N'Carole', N'Poland', N'4605276124663141')					,(62, N'George', N'Li', N'7363210936606573')						,(63, N'Gary', N'Yukish', N'5138825330365260')
	,(64, N'Cristian', N'Petculescu', N'2412910923043320')				,(65, N'Raymond', N'Sam', N'3077304081241467')						,(66, N'Janaina', N'Bueno', N'3463360976684155')
	,(67, N'Bob', N'Hohman', N'2954138092016867')						,(68, N'Shammi', N'Mohamed', N'5351639369348379')					,(69, N'Linda', N'Moschell', N'8141750981374248')
	,(70, N'Mindy', N'Martin', N'8883961113738272')						,(71, N'Wendy', N'Kahn', N'9184130564334373')						,(72, N'Kim', N'Ralls', N'7786327852767652')
	,(73, N'Sandra', N'Reategui Alayo', N'5360938568407870')			,(74, N'Kok-Ho', N'Loh', N'4232997837143935')						,(75, N'Douglas', N'Hite', N'9070921883829678')
	,(76, N'James', N'Kramer', N'2146775071463607')						,(77, N'Sean', N'Alexander', N'7313952826834153')					,(78, N'Nitin', N'Mirchandani', N'3296819140813283')
	,(79, N'Diane', N'Margheim', N'5891437299591687')					,(80, N'Rebecca', N'Laszlo', N'8433252729699512')					,(81, N'Rajesh', N'Patel', N'3469434974728436')
	,(82, N'Vidur', N'Luthra', N'5235580777351856')						,(83, N'John', N'Evans', N'6823267130825578')						,(84, N'Nancy', N'Anderson', N'8505146310605636')
	,(85, N'Pilar', N'Ackerman', N'6753723148771716')					,(86, N'David', N'Yalovsky', N'4216467551008706')					,(87, N'David', N'Hamilton', N'1856387746715488')
	,(88, N'Laura', N'Steele', N'8130518688981523')						,(89, N'Margie', N'Shoop', N'5304293163488522')						,(90, N'Zainal', N'Arifin', N'2624734840262337')
	,(91, N'Lorraine', N'Nay', N'9187844150880843')						,(92, N'Fadi', N'Fakhouri', N'3495217525796088')					,(93, N'Ryan', N'Cornelsen', N'3533330030685704')
	,(94, N'Candy', N'Spoon', N'4851735094141587')						,(95, N'Nuan', N'Yu', N'7205104569023977')							,(96, N'William', N'Vong', N'1967385880412958')
	,(97, N'Bjorn', N'Rettig', N'9202608050797826')						,(98, N'Scott', N'de', N'3404229243612619')							,(99, N'Michael', N'Rothkugel', N'2581996622413596')
	,(100, N'Lane', N'Sacksteder', N'3344229237743186')					,(101, N'Pete', N'Male', N'5971284288741676')						,(102, N'Dan', N'Bacon', N'8257190729424129')
	,(103, N'David', N'Barber', N'3917930966008848')					,(104, N'Lolan', N'Song', N'5857117345582640')						,(105, N'Paula', N'Nartker', N'6166872648404718')
	,(106, N'Mary', N'Gibson', N'5461160193093344')						,(107, N'Mindaugas', N'Krapauskas', N'9160674453776619')			,(108, N'Eric', N'Gubbels', N'5729184214926461')
	,(109, N'Ken', N'Sanchez', N'5469419562316958')						,(110, N'Jason', N'Watters', N'1208260343171875')					,(111, N'Mark', N'Harrington', N'7067584113217553')
	,(112, N'Janeth', N'Esteves', N'7410399981241001')					,(113, N'Marc', N'Ingle', N'3514405562796816')						,(114, N'Gigi', N'Matthew', N'2468248896285846')
	,(115, N'Paul', N'Singh', N'2989836421728909')						,(116, N'Frank', N'Lee', N'4523905755659381')						,(117, N'Francois', N'Ajenstat', N'6871256525378619')
	,(118, N'Diane', N'Tibbott', N'5064955045588475')					,(119, N'Jill', N'Williams', N'2141654646759205')					,(120, N'Angela', N'Barbariol', N'2002689182068600')
	,(121, N'Matthias', N'Berndt', N'6158897539075660')					,(122, N'Bryan', N'Baker', N'5698547130333879')						,(123, N'Jeff', N'Hay', N'4967654749933032')
	,(124, N'Eugene', N'Zabokritski', N'8712482264087016')				,(125, N'Barbara', N'Decker', N'9580409985079387')					,(126, N'Chris', N'Preston', N'3831669775322551')
	,(127, N'Sean', N'Chai', N'9929334171913209')						,(128, N'Dan', N'Wilson', N'6700939478932423')						,(129, N'Mark', N'McArthur', N'7878340445148873')
	,(130, N'Bryan', N'Walton', N'1740643346238814')					,(131, N'Houman', N'Pournasseh', N'7510194456852004')				,(132, N'Sairaj', N'Uddin', N'8695190158681069')
	,(133, N'Michiko', N'Osada', N'4911159787986576')					,(134, N'Benjamin', N'Martin', N'8570977118393392')					,(135, N'Cynthia', N'Randall', N'5756939971236411')
	,(136, N'Kathie', N'Flood', N'3290721568961249')					,(137, N'Britta', N'Simon', N'2381906229394108')					,(138, N'Brian', N'Lloyd', N'1740711248766858')
	,(139, N'David', N'Liu', N'8235587346003226')						,(140, N'Laura', N'Norman', N'2149361985017015')					,(141, N'Michael', N'Patten', N'3911995510381143')
	,(142, N'Andy', N'Ruth', N'8776232010461256')						,(143, N'Yuhong', N'Li', N'3343820161731158')						,(144, N'Robert', N'Rounthwaite', N'4406318411005855')
	,(145, N'Andreas', N'Berglund', N'4658744893493835')				,(146, N'Reed', N'Koch', N'3907374575549085')						,(147, N'Linda', N'Randall', N'7982231395055108')
	,(148, N'James', N'Hamilton', N'4471295830796142')					,(149, N'Ramesh', N'Meyyappan', N'3175586359129538')				,(150, N'Stephanie', N'Conroy', N'6439881331627129')
	,(151, N'Samantha', N'Smith', N'6375547258982212')					,(152, N'Tawana', N'Nusbaum', N'3048459182158799')					,(153, N'Denise', N'Smith', N'7837808478399498')
	,(154, N'Hao', N'Chen', N'3334802217249823')						,(155, N'Alex', N'Nayberg', N'7756429079268287')					,(156, N'Eugene', N'Kogan', N'4086963789148153')
	,(157, N'Brandon', N'Heidepriem', N'3253528475107994')				,(158, N'Dylan', N'Miller', N'1288540516632469')					,(159, N'Shane', N'Kim', N'8855956821538612')
	,(160, N'John', N'Chen', N'5366774723651502')						,(161, N'Karen', N'Berge', N'2377333681391094')						,(162, N'Jose', N'Lu', N'6754885286113109')
	,(163, N'Mandar', N'Samant', N'5819705479593156')					,(164, N'Mikael', N'Sandberg', N'9076468191454679')					,(165, N'Sameer', N'Tejani', N'7866826862412857')
	,(166, N'Dragan', N'Tomic', N'4615629477913853')					,(167, N'Carol', N'Philips', N'6575104672172395')					,(168, N'Rob', N'Caron', N'7654816883169661')
	,(169, N'Don', N'Hall', N'3535155035887931')						,(170, N'Alan', N'Brewer', N'2650196510123656')						,(171, N'David', N'Lawrence', N'8655760568743291')
	,(172, N'Baris', N'Cetinok', N'2139898514786702')					,(173, N'Michael', N'Ray', N'8429509249641955')						,(174, N'Steve', N'Masters', N'1628342070144010')
	,(175, N'Suchitra', N'Mohan', N'6188517997559755')					,(176, N'Karen', N'Berg', N'7886378970418571')						,(177, N'Terrence', N'Earls', N'8766323199782798')
	,(178, N'Barbara', N'Moreland', N'7370220735977413')				,(179, N'Chad', N'Niswonger', N'7425858355805138')					,(180, N'Rostislav', N'Shabalin', N'8567117698541127')
	,(181, N'Belinda', N'Newman', N'8856414931597261')					,(182, N'Katie', N'McAskill-White', N'4705557459197921')			,(183, N'Russell', N'King', N'8477931330353829')
	,(184, N'Jack', N'Richins', N'9515486565451014')					,(185, N'Andrew', N'Hill', N'9067303105824436')						,(186, N'Nicole', N'Holliday', N'3834812797409012')
	,(187, N'Frank', N'Miller', N'1682833375984222')					,(188, N'Peter', N'Connelly', N'2471590684957039')					,(189, N'Anibal', N'Sousa', N'2619563305965789')
	,(190, N'Ken', N'Myer', N'4749338430682542')						,(191, N'Grant', N'Culbertson', N'7629594956649514')				,(192, N'Michael', N'Entin', N'8173737894026407')
	,(193, N'Lionel', N'Penuchot', N'3201015830725033')					,(194, N'Thomas', N'Michaels', N'7055740399756014')					,(195, N'Jimmy', N'Bischoff', N'7751184269274076')
	,(196, N'Michael', N'Vanderhyde', N'3683704828761364')				,(197, N'Lori', N'Kane', N'2284423086765347')						,(198, N'Arvind', N'Rao', N'4502817676389168')
	,(199, N'Stefen', N'Hesse', N'6753159566667889')					,(200, N'Hazem', N'Abolrous', N'4983555554013273')					,(201, N'Janet', N'Sheperdigian', N'7312672663906858')
	,(202, N'Elizabeth', N'Keyser', N'5109199883141077')				,(203, N'Terry', N'Eminhizer', N'1663916682167132')					,(204, N'John', N'Frum', N'3436395941323152')
	,(205, N'Merav', N'Netz', N'9414161918937594')						,(206, N'Brian', N'LaMee', N'9856480570987280')						,(207, N'Kitti', N'Lertpiriyasuwat', N'4967889030932488')
	,(208, N'Jay', N'Adams', N'2162474678846241')						,(209, N'Jan', N'Miksovsky', N'3827477855849801')					,(210, N'Brenda', N'Diaz', N'6375049601935691')
	,(211, N'Andrew', N'Cencini', N'7551222145104426')					,(212, N'Chris', N'Norred', N'8295206528365405')					,(213, N'Chris', N'Okelberry', N'3873554322156931')
	,(214, N'Shelley', N'Dyck', N'5699187148733042')					,(215, N'Gabe', N'Mares', N'3548517629134340')						,(216, N'Mike', N'Seamans', N'7862433200254898')
	,(217, N'Michael', N'Raheem', N'2881969196514889')					,(218, N'Gary', N'Altman', N'8044958776746557')						,(219, N'Charles', N'Fitzgerald', N'3616627229403845')
	,(220, N'Ebru', N'Ersan', N'2281862720044302')						,(221, N'Sylvester', N'Valdez', N'8015412453875775')				,(222, N'Brian', N'ldstein', N'7960731030682794')
	,(223, N'Linda', N'Meisner', N'6387669413804769')					,(224, N'Betsy', N'Stadick', N'9072311615082461')					,(225, N'Magnus', N'Hedlund', N'513356187265664 ')
	,(226, N'Karan', N'Khanna', N'1467373844324861')					,(227, N'Mary', N'Baker', N'7748242269298936')						,(228, N'Kevin', N'Homer', N'4693723971144217')
	,(229, N'Mihail', N'Frintu', N'6304368978779822')					,(230, N'Bonnie', N'Kearney', N'3224612792496020')					,(231, N'Fukiko', N'Ogisu', N'8788191674725854')
	,(232, N'Hung-Fu', N'Ting', N'9295495067368215')					,(233, N'rdon', N'Hee', N'7320199924209382')						,(234, N'Kimberly', N'Zimmerman', N'4800352323818237')
	,(235, N'Kim', N'Abercrombie', N'4812197151649653')					,(236, N'Sandeep', N'Kaliyath', N'4748793070421461')				,(237, N'Prasanna', N'Samarawickrama', N'2762289024791270')
	,(238, N'Frank', N'Pellow', N'2160497594005458')					,(239, N'Min', N'Su', N'2308226383789347')							,(240, N'Eric', N'Brown', N'5542743236055397')
	,(241, N'Eric', N'Kurjan', N'6942439156361877')						,(242, N'Pat', N'Coleman', N'2032180111941939')						,(243, N'Maciej', N'Dusza', N'7115552774817070')
	,(244, N'Erin', N'Hagens', N'9597350525931162')						,(245, N'Patrick', N'Wedge', N'6203220771529615')					,(246, N'Frank', N'Martinez', N'8077968499363265')
	,(247, N'Ed', N'Dudenhoefer', N'3280192061526458')					,(248, N'Christopher', N'Hill', N'5456142539079952')				,(249, N'Patrick', N'Cook', N'9193514152725704')
	,(250, N'Krishna', N'Sunkammurali', N'4241559090528010')			,(251, N'Lori', N'Penor', N'3857365693718829')						,(252, N'Danielle', N'Tiedt', N'5580568479487519')
	,(253, N'Sootha', N'Charncherngkha', N'5760648544535256')			,(254, N'Michael', N'Zwilling', N'8230795123798961')				,(255, N'Randy', N'Reeves', N'9001872489691596')
	,(256, N'John', N'Kane', N'2375668783096928')						,(257, N'Jack', N'Creasey', N'8980665575223814')					,(258, N'Olinda', N'Turner', N'9845222237342025')
	,(259, N'Stuart', N'Macrae', N'4225525581998404')					,(260, N'Jo', N'Berry', N'9578910110647263')						,(261, N'Ben', N'Miller', N'8127677090764333')
	,(262, N'Tom', N'Vande Velde', N'3235587598028158')					,(263, N'Ovidiu', N'Cracium', N'2629709865993472')					,(264, N'Annette', N'Hill', N'5755849590193404')
	,(265, N'Janice', N'Galvin', N'3411163859555972')					,(266, N'Reinout', N'Hillmann', N'9088911512535358')				,(267, N'Michael', N'Sullivan', N'3068678529276302')
	,(268, N'Stephen', N'Jiang', N'1995629604460464')					,(269, N'Wanida', N'Benshoof', N'2627950665853220')					,(270, N'Sharon', N'Salavaria', N'8899793310467186')
	,(271, N'John', N'Wood', N'6580626389352327')						,(272, N'Mary', N'Dempsey', N'5304775438985923')					,(273, N'Brian', N'Welcker', N'5438585412835872')
	,(274, N'Sheela', N'Word', N'3253710911347739')						,(275, N'Michael', N'Blythe', N'5615545620358899')					,(276, N'Linda', N'Mitchell', N'7657557974903337')
	,(277, N'Jillian', N'Carson', N'8077218855644836')					,(278, N'Garrett', N'Vargas', N'1191234082922521')					,(279, N'Tsvi', N'Reiter', N'6059331728207257')
	,(280, N'Pamela', N'Ansman-Wolfe', N'6129506925419558')				,(281, N'Shu', N'Ito', N'2544776320355089')							,(282, N'Jose', N'Saraiva', N'9588196742608987')
	,(283, N'David', N'Campbell', N'1144484385805176')					,(284, N'Amy', N'Alberts', N'8269139678239481')						,(285, N'Jae', N'Pak', N'2850215548023119')
	,(286, N'Ranjit', N'Varkey Chudukatil', N'4671543167568757')		,(287, N'Tete', N'Mensa-Annan', N'3643786748295126')				,(288, N'Syed', N'Abbas', N'3964815633391281')
	,(289, N'Rachel', N'Valdez', N'1665977863042383')					,(290, N'Lynn', N'Tsoflias', N'7807260283273161')					,(291, N'Svetlin', N'Nakov', N'7773538484630196')
	,(292, N'Martin', N'Kulov', N'3272933656756729')					,(293, N'George', N'Denchev', N'5845520684874546')
GO

SET IDENTITY_INSERT [dbo].[Lines] ON 
GO
INSERT [dbo].[Lines] ([Id], [X1], [Y1], [X2], [Y2]) VALUES 
	 (1, 0, 0, 10, 0)
	,(2, 0, 0, 5, 3)
	,(4, -1, 5, 8, -3)
	,(5, 18, 23, 8882, 134)
GO
SET IDENTITY_INSERT [dbo].[Lines] OFF
GO

INSERT [dbo].[Products] ([Id], [Name], [Quantity], [BoxCapacity], [PalletCapacity]) VALUES 
	 (1, N'Perlenbacher 500ml', 108, 6, 18)
	,(2, N'Perlenbacher 500ml', 10, 6, 18)
	,(3, N'Chocolate Chips', 350, 24, 3)
	,(4, N'Oil Pump', 100, 1, 12)
	,(5, N'OLED TV 50-Inch', 13, 1, 5)
	,(6, N'Penny', 1, 2239488, 1)
GO

SET IDENTITY_INSERT [dbo].[Rectangles] ON 
GO
INSERT [dbo].[Rectangles] ([Id], [A], [B]) VALUES 
	 (1, 2, 4)
	,(2, 1, 18)
	,(3, 4.5, 3)
	,(4, 8, 12)
	,(5, 3, 5)
GO
SET IDENTITY_INSERT [dbo].[Rectangles] OFF
GO

SET IDENTITY_INSERT [dbo].[Triangles] ON 
GO
INSERT [dbo].[Triangles] ([Id], [A], [B], [C]) VALUES 
	 (1, 3, 4, 5)
	,(2, 2, 5, 4)
	,(3, 1.5, 1.5, 2)
	,(4, 3.5, 4.15, 6)
	,(5, 4, 2, 4)
GO
SET IDENTITY_INSERT [dbo].[Triangles] OFF
GO

SET IDENTITY_INSERT [dbo].[Triangles2] ON 
GO
INSERT [dbo].[Triangles2] ([Id], [A], [H]) VALUES 
	 (1, 2, 4)
	,(2, 1, 18)
	,(3, 4.5, 3)
	,(4, 8, 12)
	,(5, 3, 5)
GO
SET IDENTITY_INSERT [dbo].[Triangles2] OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__People__A9D10534FDC618ED]    Script Date: 25.1.2017 г. 14:01:37 ******/
ALTER TABLE [dbo].[People] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Demo] SET  READ_WRITE 
GO


/*--- PROBLEM --- OBFUSCATE CC NUMBERS ----*/
USE Demo

SELECT CustomerID
      ,FirstName
      ,LastName
      ,LEFT(PaymentNumber, 6) + '**********' 
FROM Customers


CREATE VIEW v_PublicPaymentInfo AS
SELECT CustomerID
      ,FirstName
      ,LastName
      ,LEFT(PaymentNumber, 6) + '**********' AS [Obfuscated CC Numbers]
FROM Customers

/*--- PROBLEM --- PALLETS -----------------*/
SELECT
	CEILING(
		CEILING(
		  CAST(Quantity AS float) / 
		  BoxCapacity) / PalletCapacity)
    AS [Number of pallets]
FROM Products





