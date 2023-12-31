USE [master]
GO
/****** Object:  Database [SchoolApplication]    Script Date: 20.12.2023 17:00:02 ******/
CREATE DATABASE [SchoolApplication]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SchoolApplication', FILENAME = N'D:\Program Files\MSSQL16.SQLEXPRESS\MSSQL\DATA\SchoolApplication.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SchoolApplication_log', FILENAME = N'D:\Program Files\MSSQL16.SQLEXPRESS\MSSQL\DATA\SchoolApplication_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [SchoolApplication] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SchoolApplication].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SchoolApplication] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SchoolApplication] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SchoolApplication] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SchoolApplication] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SchoolApplication] SET ARITHABORT OFF 
GO
ALTER DATABASE [SchoolApplication] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SchoolApplication] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SchoolApplication] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SchoolApplication] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SchoolApplication] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SchoolApplication] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SchoolApplication] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SchoolApplication] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SchoolApplication] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SchoolApplication] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SchoolApplication] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SchoolApplication] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SchoolApplication] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SchoolApplication] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SchoolApplication] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SchoolApplication] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SchoolApplication] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SchoolApplication] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SchoolApplication] SET  MULTI_USER 
GO
ALTER DATABASE [SchoolApplication] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SchoolApplication] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SchoolApplication] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SchoolApplication] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SchoolApplication] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SchoolApplication] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SchoolApplication] SET QUERY_STORE = ON
GO
ALTER DATABASE [SchoolApplication] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [SchoolApplication]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 20.12.2023 17:00:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[ClassId] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [nvarchar](25) NOT NULL,
	[TeacherId] [int] NOT NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[ClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lesson]    Script Date: 20.12.2023 17:00:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lesson](
	[LessonId] [int] IDENTITY(1,1) NOT NULL,
	[LessonName] [nvarchar](50) NOT NULL,
	[TeacherId] [int] NOT NULL,
 CONSTRAINT [PK_Lesson] PRIMARY KEY CLUSTERED 
(
	[LessonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 20.12.2023 17:00:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[NewsId] [int] IDENTITY(1,1) NOT NULL,
	[NameNews] [nvarchar](50) NOT NULL,
	[Date] [date] NOT NULL,
	[Text] [nvarchar](1000) NOT NULL,
	[Image] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[NewsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 20.12.2023 17:00:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 20.12.2023 17:00:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[TeacherId] [int] IDENTITY(1,1) NOT NULL,
	[TeacherName] [nvarchar](75) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Image] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 20.12.2023 17:00:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](25) NOT NULL,
	[RoleId] [int] NOT NULL,
	[ClassId] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Class] ON 

INSERT [dbo].[Class] ([ClassId], [ClassName], [TeacherId]) VALUES (3, N'5А', 3)
INSERT [dbo].[Class] ([ClassId], [ClassName], [TeacherId]) VALUES (4, N'5Б', 6)
INSERT [dbo].[Class] ([ClassId], [ClassName], [TeacherId]) VALUES (5, N'8Б', 5)
INSERT [dbo].[Class] ([ClassId], [ClassName], [TeacherId]) VALUES (6, N'9А', 7)
INSERT [dbo].[Class] ([ClassId], [ClassName], [TeacherId]) VALUES (7, N'9Б', 8)
INSERT [dbo].[Class] ([ClassId], [ClassName], [TeacherId]) VALUES (10, N'-', 9)
SET IDENTITY_INSERT [dbo].[Class] OFF
GO
SET IDENTITY_INSERT [dbo].[Lesson] ON 

INSERT [dbo].[Lesson] ([LessonId], [LessonName], [TeacherId]) VALUES (3, N'Математика', 3)
INSERT [dbo].[Lesson] ([LessonId], [LessonName], [TeacherId]) VALUES (4, N'Физика', 5)
INSERT [dbo].[Lesson] ([LessonId], [LessonName], [TeacherId]) VALUES (5, N'ОБЖ', 6)
INSERT [dbo].[Lesson] ([LessonId], [LessonName], [TeacherId]) VALUES (6, N'История', 7)
INSERT [dbo].[Lesson] ([LessonId], [LessonName], [TeacherId]) VALUES (7, N'Информатика', 8)
SET IDENTITY_INSERT [dbo].[Lesson] OFF
GO
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([NewsId], [NameNews], [Date], [Text], [Image]) VALUES (1, N'Тотальный тест "Доступная среда"', CAST(N'2021-12-02' AS Date), N'2 декабря педагогический коллектив МБОУ "Мухтоловская средняя школа №1" приняли участие в Тотальном тестировании "Доступная среда", приуроченном к Международному Дню инвалидов.', N'http://mssh-1.ucoz.ru/2022/korru/Xl0UBnPeNFcL0W8QWhEPWjHLYKJ_Jz8ADOaAxZpHVQe64nPimS.jpg')
INSERT [dbo].[News] ([NewsId], [NameNews], [Date], [Text], [Image]) VALUES (2, N'Всероссийская неделя сбережений', CAST(N'2022-11-05' AS Date), N'В ноябре 2022 года в МБОУ МСШ №1 прошла Всероссийская неделя сбережений - ежегодное мероприятие, проводимое в рамках Проекта Министерства финансов Российской Федерации «Содействие повышению уровня финансовой грамотности населения и развитию финансового образования в Российской Федерации». Мероприятия Недели направлены на привлечение внимания граждан к вопросам разумного финансового поведения, ответственного отношения к личным финансам и содействие повышению уровня финансовой грамотности населения. Учащиеся 2-11 классов узнали, почему важно быть финансово грамотными в любом возрасте, определи уровень своей финансовой грамотности, попытались разобраться откуда берутся деньги у государства и кто ими распоряжается, каковы финансовые цели государства.', N'https://sun9-87.userapi.com/impg/qBxAAKAWZ5lEvm3YZd9mE36g_Us94dLIKt5xsg/MHeznzYsuhE.jpg?size=1280x960&quality=96&sign=5a3570cfe7b5241095d960527d4cdcc7&type=album')
INSERT [dbo].[News] ([NewsId], [NameNews], [Date], [Text], [Image]) VALUES (3, N'Декада ГТО', CAST(N'2022-03-17' AS Date), N'В период с 17 по 31 марта в МБОУ "Мухтоловская средняя школа №1" прошла Декада ГТО.  К ней приурочили классные часы, открытые уроки, соревнования и единые дни сдачи норм ГТО. Общий охват обучающихся составил 132 человека.', N'http://mssh-1.ucoz.ru/_nw/5/97856010.jpg')
INSERT [dbo].[News] ([NewsId], [NameNews], [Date], [Text], [Image]) VALUES (4, N'Орлята России', CAST(N'2022-05-12' AS Date), N'В рамках проекта"Орлята России" в Мухтоловской средней школе N1 был реализован первый образовательный трек
 " Орленок- Эрудит". Он был направлен на развитие творческого мышления,познавательной активности и командной работы.Ребята в игровой форме решали задачи с ловушкой,разгадывали ребусы,анаграммы,отправляли друг другу тайные сообщения - шифровки.
А ещё теперь у маленьких Орлят в классе есть настоящий ОРЛЯТСКИЙ УГОЛОК. На нём ребята будут отмечать важные события каждого образовательного трека. Теперь у отряда есть название, девиз и эмблема.
Так держать Орлята! Вперёд к новым открытиям!!!', N'https://sun9-40.userapi.com/impg/_e2rZbLk528c8L1jXbDz5RL2i_L4TTaph0Xi1Q/SLnuG0vsM44.jpg?size=1600x1196&quality=96&sign=ed210d712df7201418ed498b1548a995&type=album')
INSERT [dbo].[News] ([NewsId], [NameNews], [Date], [Text], [Image]) VALUES (5, N'Лыжня России 2021', CAST(N'2021-02-04' AS Date), N'4 февраля 2021 года на базе  МБОУ "Мухтоловская средняя школа №1" прошел школьный этап Всероссийской массовой лыжной гонки "Лыжня России - 2021". В заезде приняли участие  около 100 человек с 5 по 11 класс.', N'http://mssh-1.ucoz.ru/_nw/4/26055138.jpg')
INSERT [dbo].[News] ([NewsId], [NameNews], [Date], [Text], [Image]) VALUES (6, N'Международный День борьбы с коррупцией', CAST(N'2021-12-09' AS Date), N'9 декабря в МБОУ МСШ №1 прошли квесты, посвященные Международному Дню Борьбы с коррупцией. Приняли участие старшеклассники. Итоги были подведены за круглым столом.', N'http://mssh-1.ucoz.ru/_nw/4/08406667.jpg')
INSERT [dbo].[News] ([NewsId], [NameNews], [Date], [Text], [Image]) VALUES (8, N'Взаимодействие с прокуратурой', CAST(N'2019-11-28' AS Date), N'28 ноября 2019 года в МБОУ МСШ №1 прошла встреча обучающихся 9-11 классов с помощником прокурора Ардатовского района. Донец Давид Станиславович рассказал ученикам об ответственности подростков за совершение преступлений.', N'http://mssh-1.ucoz.ru/_nw/4/00765525.jpg')
SET IDENTITY_INSERT [dbo].[News] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (1, N'Ученик')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (2, N'Администратор')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (3, N'Директор')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [DateOfBirth], [Image]) VALUES (3, N'Булаева Валентина Федоровна', CAST(N'1981-05-24' AS Date), N'https://sun9-34.userapi.com/impg/Orbp_49L9luzJ7CJyQmJinrgKsGzQS9Is0aucQ/851vBArAex8.jpg?size=656x656&quality=95&sign=15439bd08dadadf30b38cc616dccada9&type=album')
INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [DateOfBirth], [Image]) VALUES (5, N'Варганов Александр Александрович', CAST(N'1988-04-01' AS Date), N'https://sun9-33.userapi.com/impg/Y-ApHmUId1z_4agLv_uVhWdSF1s9gV-wSjpm-w/HgjiaA7mQhA.jpg?size=336x448&quality=95&sign=7271350b4ece0de95d1b93e6c60d5979&type=album')
INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [DateOfBirth], [Image]) VALUES (6, N'Крючков Сергей Николаевич', CAST(N'1978-07-23' AS Date), N'https://sun9-82.userapi.com/impg/EdfyF3-dg-6k9atbA0wl6QdvhwncNK4W6D1AeQ/MRdgD7iTUiA.jpg?size=1080x1080&quality=95&sign=46498db40eae5245abae7cee3dd9ed4a&type=album')
INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [DateOfBirth], [Image]) VALUES (7, N'Шадрина Ольга Николаевна', CAST(N'1989-06-14' AS Date), N'https://sun9-81.userapi.com/impg/iQuGDLzE-FLZTGC7_KxQzSOop4V2Uov5M531ig/cqJTCDw6VNo.jpg?size=1202x1600&quality=95&sign=cd26d21ddddfccd7a14b9fbc21eef0db&type=album')
INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [DateOfBirth], [Image]) VALUES (8, N'Юдкина Юлия Ивановна', CAST(N'1988-10-17' AS Date), N'https://sun9-33.userapi.com/impg/MNOXSsiBYSeJ-ON1x0J6x1DV24f4ofncEek_kA/CbEL2SD8BcY.jpg?size=1200x1600&quality=95&sign=c00b1e2c73644bb1e66ee986eb6769e2&type=album')
INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [DateOfBirth], [Image]) VALUES (9, N'-', CAST(N'0001-01-01' AS Date), N'-')
SET IDENTITY_INSERT [dbo].[Teacher] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [UserName], [DateOfBirth], [Email], [Login], [Password], [RoleId], [ClassId]) VALUES (14, N'Петренко Сергей Иванович', CAST(N'2008-10-05' AS Date), N'Penreco@email.com', N'Petrenco08', N'1005', 1, 7)
INSERT [dbo].[User] ([UserId], [UserName], [DateOfBirth], [Email], [Login], [Password], [RoleId], [ClassId]) VALUES (15, N'Зайчук Роман Николаевич', CAST(N'2008-12-06' AS Date), N'Zaichyk@email.com', N'Zaichyk08', N'1206', 1, 6)
INSERT [dbo].[User] ([UserId], [UserName], [DateOfBirth], [Email], [Login], [Password], [RoleId], [ClassId]) VALUES (16, N'Олеевская Диана Игоревна', CAST(N'2008-12-20' AS Date), N'Oleevska@email.com', N'Oleevska08', N'1220', 1, 7)
INSERT [dbo].[User] ([UserId], [UserName], [DateOfBirth], [Email], [Login], [Password], [RoleId], [ClassId]) VALUES (17, N'Гордиев Лев Михайлович', CAST(N'2009-03-08' AS Date), N'Gordeev@email.com', N'Gordeev09', N'0308', 1, 5)
INSERT [dbo].[User] ([UserId], [UserName], [DateOfBirth], [Email], [Login], [Password], [RoleId], [ClassId]) VALUES (19, N'Агапов Иван Сергеевич', CAST(N'2012-06-10' AS Date), N'Agapov@email.com', N'Agapov12', N'0610', 1, 4)
INSERT [dbo].[User] ([UserId], [UserName], [DateOfBirth], [Email], [Login], [Password], [RoleId], [ClassId]) VALUES (20, N'Птицына Ольга Семеновна', CAST(N'2012-09-15' AS Date), N'Ptichina@email.com', N'Ptichina12', N'0915', 1, 3)
INSERT [dbo].[User] ([UserId], [UserName], [DateOfBirth], [Email], [Login], [Password], [RoleId], [ClassId]) VALUES (22, N'Форумов Семен Юрьевич', CAST(N'1998-07-10' AS Date), N'Forymov@email.com', N'Admin', N'0710', 2, 10)
INSERT [dbo].[User] ([UserId], [UserName], [DateOfBirth], [Email], [Login], [Password], [RoleId], [ClassId]) VALUES (24, N'Малинин Елисей Матвеевич', CAST(N'1995-05-12' AS Date), N'Malinin@email.ru', N'Director', N'0711', 3, 10)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [FK_Class_Teacher] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([TeacherId])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [FK_Class_Teacher]
GO
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD  CONSTRAINT [FK_Lesson_Teacher] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([TeacherId])
GO
ALTER TABLE [dbo].[Lesson] CHECK CONSTRAINT [FK_Lesson_Teacher]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Class] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Class] ([ClassId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Class]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [SchoolApplication] SET  READ_WRITE 
GO
