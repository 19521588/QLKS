USE [QLKS]
GO
ALTER TABLE [dbo].[USERS] DROP CONSTRAINT [FK__USERS__Type__29572725]
GO
ALTER TABLE [dbo].[USERS] DROP CONSTRAINT [FK__USERS__IdEmploye__286302EC]
GO
ALTER TABLE [dbo].[SERVICE] DROP CONSTRAINT [FK__SERVICE__IdCateg__34C8D9D1]
GO
ALTER TABLE [dbo].[ROOM] DROP CONSTRAINT [FK__ROOM__IdCategory__300424B4]
GO
ALTER TABLE [dbo].[RESERVATION] DROP CONSTRAINT [FK__RESERVATI__IdRoo__3C69FB99]
GO
ALTER TABLE [dbo].[RESERVATION] DROP CONSTRAINT [FK__RESERVATI__IdRes__3B75D760]
GO
ALTER TABLE [dbo].[RESERVATION] DROP CONSTRAINT [FK__RESERVATI__IdEmp__398D8EEE]
GO
ALTER TABLE [dbo].[RESERVATION] DROP CONSTRAINT [FK__RESERVATI__IdCus__3A81B327]
GO
ALTER TABLE [dbo].[RENTALDETAIL] DROP CONSTRAINT [FK__RENTALDET__IdSer__412EB0B6]
GO
ALTER TABLE [dbo].[RENTAL] DROP CONSTRAINT [FK__RENTAL__IdRoom__45F365D3]
GO
ALTER TABLE [dbo].[RENTAL] DROP CONSTRAINT [FK__RENTAL__IdReserv__440B1D61]
GO
ALTER TABLE [dbo].[RENTAL] DROP CONSTRAINT [FK__RENTAL__IdRental__44FF419A]
GO
ALTER TABLE [dbo].[Bill] DROP CONSTRAINT [FK__Bill__IdRental__48CFD27E]
GO
ALTER TABLE [dbo].[Bill] DROP CONSTRAINT [FK__Bill__IdBillInfo__49C3F6B7]
GO
/****** Object:  Table [dbo].[USERS]    Script Date: 10/02/2022 7:25:44 CH ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USERS]') AND type in (N'U'))
DROP TABLE [dbo].[USERS]
GO
/****** Object:  Table [dbo].[SERVICE]    Script Date: 10/02/2022 7:25:44 CH ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SERVICE]') AND type in (N'U'))
DROP TABLE [dbo].[SERVICE]
GO
/****** Object:  Table [dbo].[ROOM]    Script Date: 10/02/2022 7:25:44 CH ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ROOM]') AND type in (N'U'))
DROP TABLE [dbo].[ROOM]
GO
/****** Object:  Table [dbo].[RESERVATION_DETAIL]    Script Date: 10/02/2022 7:25:44 CH ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RESERVATION_DETAIL]') AND type in (N'U'))
DROP TABLE [dbo].[RESERVATION_DETAIL]
GO
/****** Object:  Table [dbo].[RESERVATION]    Script Date: 10/02/2022 7:25:44 CH ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RESERVATION]') AND type in (N'U'))
DROP TABLE [dbo].[RESERVATION]
GO
/****** Object:  Table [dbo].[RENTALDETAIL]    Script Date: 10/02/2022 7:25:44 CH ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RENTALDETAIL]') AND type in (N'U'))
DROP TABLE [dbo].[RENTALDETAIL]
GO
/****** Object:  Table [dbo].[RENTAL]    Script Date: 10/02/2022 7:25:44 CH ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RENTAL]') AND type in (N'U'))
DROP TABLE [dbo].[RENTAL]
GO
/****** Object:  Table [dbo].[EMPLOYEE]    Script Date: 10/02/2022 7:25:44 CH ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EMPLOYEE]') AND type in (N'U'))
DROP TABLE [dbo].[EMPLOYEE]
GO
/****** Object:  Table [dbo].[CUSTOMER]    Script Date: 10/02/2022 7:25:44 CH ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CUSTOMER]') AND type in (N'U'))
DROP TABLE [dbo].[CUSTOMER]
GO
/****** Object:  Table [dbo].[CATEGORY_USER]    Script Date: 10/02/2022 7:25:44 CH ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CATEGORY_USER]') AND type in (N'U'))
DROP TABLE [dbo].[CATEGORY_USER]
GO
/****** Object:  Table [dbo].[CATEGORY_SERVICE]    Script Date: 10/02/2022 7:25:44 CH ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CATEGORY_SERVICE]') AND type in (N'U'))
DROP TABLE [dbo].[CATEGORY_SERVICE]
GO
/****** Object:  Table [dbo].[CATEGORY_ROOM]    Script Date: 10/02/2022 7:25:44 CH ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CATEGORY_ROOM]') AND type in (N'U'))
DROP TABLE [dbo].[CATEGORY_ROOM]
GO
/****** Object:  Table [dbo].[BILLINFO]    Script Date: 10/02/2022 7:25:44 CH ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BILLINFO]') AND type in (N'U'))
DROP TABLE [dbo].[BILLINFO]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 10/02/2022 7:25:44 CH ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bill]') AND type in (N'U'))
DROP TABLE [dbo].[Bill]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 10/02/2022 7:25:44 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[IdBill] [int] IDENTITY(1,1) NOT NULL,
	[IdBillInfo] [int] NOT NULL,
	[Total] [int] NULL,
	[Name] [nvarchar](100) NOT NULL,
	[IdRental] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdBill] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BILLINFO]    Script Date: 10/02/2022 7:25:44 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BILLINFO](
	[IdBillInfo] [int] IDENTITY(1,1) NOT NULL,
	[Service] [nvarchar](100) NOT NULL,
	[Amount] [int] NOT NULL,
	[Price] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdBillInfo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CATEGORY_ROOM]    Script Date: 10/02/2022 7:25:44 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORY_ROOM](
	[IdCategoryRoom] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Price_Day] [int] NULL,
	[Price_Hour] [int] NULL,
	[Beds] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCategoryRoom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CATEGORY_SERVICE]    Script Date: 10/02/2022 7:25:44 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORY_SERVICE](
	[IdCategoryService] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCategoryService] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CATEGORY_USER]    Script Date: 10/02/2022 7:25:44 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORY_USER](
	[IdCategoryUser] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCategoryUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CUSTOMER]    Script Date: 10/02/2022 7:25:44 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUSTOMER](
	[IdCustomer] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[BirthDay] [date] NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[CCCD] [nvarchar](100) NOT NULL,
	[Sex] [nvarchar](20) NOT NULL,
	[Nationality] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCustomer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EMPLOYEE]    Script Date: 10/02/2022 7:25:44 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMPLOYEE](
	[IdEmployee] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[BirthDay] [date] NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[CCCD] [nvarchar](100) NOT NULL,
	[Sex] [nvarchar](20) NOT NULL,
	[Position] [nvarchar](100) NOT NULL,
	[Salary] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEmployee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RENTAL]    Script Date: 10/02/2022 7:25:44 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RENTAL](
	[IdRental] [int] IDENTITY(1,1) NOT NULL,
	[IdReservation] [int] NOT NULL,
	[IdRentalDetail] [int] NOT NULL,
	[IdRoom] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRental] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RENTALDETAIL]    Script Date: 10/02/2022 7:25:44 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RENTALDETAIL](
	[IdRentalDetail] [int] IDENTITY(1,1) NOT NULL,
	[IdService] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRentalDetail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RESERVATION]    Script Date: 10/02/2022 7:25:44 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RESERVATION](
	[IdReservation] [int] IDENTITY(1,1) NOT NULL,
	[IdEmployee] [int] NOT NULL,
	[IdCustomer] [int] NOT NULL,
	[Date] [int] NULL,
	[IdReservationDetail] [int] NOT NULL,
	[IdRoom] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdReservation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RESERVATION_DETAIL]    Script Date: 10/02/2022 7:25:44 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RESERVATION_DETAIL](
	[IdReservationDetail] [int] IDENTITY(1,1) NOT NULL,
	[Start_Date] [date] NOT NULL,
	[End_Date] [date] NOT NULL,
	[Start_Time] [date] NOT NULL,
	[End_Time] [date] NOT NULL,
	[Amount] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdReservationDetail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ROOM]    Script Date: 10/02/2022 7:25:44 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROOM](
	[IdRoom] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[Clean] [nvarchar](50) NOT NULL,
	[IdCategoryRoom] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRoom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SERVICE]    Script Date: 10/02/2022 7:25:44 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SERVICE](
	[IdService] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Price] [int] NOT NULL,
	[IdCategoryService] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdService] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USERS]    Script Date: 10/02/2022 7:25:44 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USERS](
	[Users_Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[IdEmployee] [int] NOT NULL,
	[Type] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Users_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CATEGORY_USER] ON 

INSERT [dbo].[CATEGORY_USER] ([IdCategoryUser], [Name]) VALUES (1, N'CEO')
SET IDENTITY_INSERT [dbo].[CATEGORY_USER] OFF
GO
SET IDENTITY_INSERT [dbo].[EMPLOYEE] ON 

INSERT [dbo].[EMPLOYEE] ([IdEmployee], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Position], [Salary]) VALUES (1, N'HUNG', N'Dak Lak', CAST(N'2001-04-04' AS Date), N'12345789', N'12345789', N'Nam', N'CEO', N'99999999')
SET IDENTITY_INSERT [dbo].[EMPLOYEE] OFF
GO
SET IDENTITY_INSERT [dbo].[USERS] ON 

INSERT [dbo].[USERS] ([Users_Id], [UserName], [Password], [IdEmployee], [Type]) VALUES (2, N'admin', N'1', 1, 1)
SET IDENTITY_INSERT [dbo].[USERS] OFF
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([IdBillInfo])
REFERENCES [dbo].[BILLINFO] ([IdBillInfo])
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([IdRental])
REFERENCES [dbo].[RENTAL] ([IdRental])
GO
ALTER TABLE [dbo].[RENTAL]  WITH CHECK ADD FOREIGN KEY([IdRentalDetail])
REFERENCES [dbo].[RENTALDETAIL] ([IdRentalDetail])
GO
ALTER TABLE [dbo].[RENTAL]  WITH CHECK ADD FOREIGN KEY([IdReservation])
REFERENCES [dbo].[RESERVATION] ([IdReservation])
GO
ALTER TABLE [dbo].[RENTAL]  WITH CHECK ADD FOREIGN KEY([IdRoom])
REFERENCES [dbo].[ROOM] ([IdRoom])
GO
ALTER TABLE [dbo].[RENTALDETAIL]  WITH CHECK ADD FOREIGN KEY([IdService])
REFERENCES [dbo].[SERVICE] ([IdService])
GO
ALTER TABLE [dbo].[RESERVATION]  WITH CHECK ADD FOREIGN KEY([IdCustomer])
REFERENCES [dbo].[CUSTOMER] ([IdCustomer])
GO
ALTER TABLE [dbo].[RESERVATION]  WITH CHECK ADD FOREIGN KEY([IdEmployee])
REFERENCES [dbo].[EMPLOYEE] ([IdEmployee])
GO
ALTER TABLE [dbo].[RESERVATION]  WITH CHECK ADD FOREIGN KEY([IdReservationDetail])
REFERENCES [dbo].[RESERVATION_DETAIL] ([IdReservationDetail])
GO
ALTER TABLE [dbo].[RESERVATION]  WITH CHECK ADD FOREIGN KEY([IdRoom])
REFERENCES [dbo].[ROOM] ([IdRoom])
GO
ALTER TABLE [dbo].[ROOM]  WITH CHECK ADD FOREIGN KEY([IdCategoryRoom])
REFERENCES [dbo].[CATEGORY_ROOM] ([IdCategoryRoom])
GO
ALTER TABLE [dbo].[SERVICE]  WITH CHECK ADD FOREIGN KEY([IdCategoryService])
REFERENCES [dbo].[CATEGORY_SERVICE] ([IdCategoryService])
GO
ALTER TABLE [dbo].[USERS]  WITH CHECK ADD FOREIGN KEY([IdEmployee])
REFERENCES [dbo].[EMPLOYEE] ([IdEmployee])
GO
ALTER TABLE [dbo].[USERS]  WITH CHECK ADD FOREIGN KEY([Type])
REFERENCES [dbo].[CATEGORY_USER] ([IdCategoryUser])
GO
