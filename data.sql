USE [QLKS]
GO
SET IDENTITY_INSERT [dbo].[CUSTOMER] ON 

INSERT [dbo].[CUSTOMER] ([IdCustomer], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Nationality]) VALUES (1, N'Trương hưng', N'ktx A', CAST(N'2001-04-20' AS Date), N'0822904906', N'123456789', N'Nam', N'Việt Nam')
SET IDENTITY_INSERT [dbo].[CUSTOMER] OFF
GO
SET IDENTITY_INSERT [dbo].[EMPLOYEE] ON 

INSERT [dbo].[EMPLOYEE] ([IdEmployee], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Position], [Salary]) VALUES (1, N'Trương Hưng', N'ktx B', CAST(N'2001-05-12' AS Date), N'123456789', N'198745613', N'Nam', N'CEO', N'999999999999')
SET IDENTITY_INSERT [dbo].[EMPLOYEE] OFF
GO
SET IDENTITY_INSERT [dbo].[RESERVATION] ON 

INSERT [dbo].[RESERVATION] ([IdReservation], [IdEmployee], [IdCustomer], [Date], [Start_Date], [End_Date], [Amount]) VALUES (1, 1, 1, 5, CAST(N'2022-02-20T00:00:00.000' AS DateTime), CAST(N'2022-02-25T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[RESERVATION] OFF
GO
SET IDENTITY_INSERT [dbo].[CATEGORY_ROOM] ON 

INSERT [dbo].[CATEGORY_ROOM] ([IdCategoryRoom], [Name], [Price_Day], [Price_Hour], [Beds]) VALUES (1, N'Phòng đơn', 500000, 50000, 1)
INSERT [dbo].[CATEGORY_ROOM] ([IdCategoryRoom], [Name], [Price_Day], [Price_Hour], [Beds]) VALUES (2, N'Phòng đôi', 1000000, 75000, 2)
INSERT [dbo].[CATEGORY_ROOM] ([IdCategoryRoom], [Name], [Price_Day], [Price_Hour], [Beds]) VALUES (3, N'Phòng gia đình', 1500000, 100000, 4)
SET IDENTITY_INSERT [dbo].[CATEGORY_ROOM] OFF
GO
SET IDENTITY_INSERT [dbo].[ROOM] ON 

INSERT [dbo].[ROOM] ([IdRoom], [Name], [Clean], [IdCategoryRoom]) VALUES (1, N'101', N'Chưa dọn dẹp', 1)
INSERT [dbo].[ROOM] ([IdRoom], [Name], [Clean], [IdCategoryRoom]) VALUES (2, N'102', N'Chưa dọn dẹp', 2)
SET IDENTITY_INSERT [dbo].[ROOM] OFF
GO
SET IDENTITY_INSERT [dbo].[RENTAL] ON 

INSERT [dbo].[RENTAL] ([IdRental], [IdReservation], [IdRoom], [DateRental]) VALUES (2, 1, 1, CAST(N'2022-02-23' AS Date))
SET IDENTITY_INSERT [dbo].[RENTAL] OFF
GO
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([IdBill], [Total], [Name], [IdRental], [Date_Bill], [CategoryRoom]) VALUES (6, 2730000, N'Trương Hưng', 2, CAST(N'2022-02-24' AS Date), N'Phòng đơn')
SET IDENTITY_INSERT [dbo].[Bill] OFF
GO
SET IDENTITY_INSERT [dbo].[BILLINFO] ON 

INSERT [dbo].[BILLINFO] ([IdBillInfo], [IdBill], [Service], [Amount], [Price]) VALUES (10, 6, N'Mỳ trộn', 1, 15000)
INSERT [dbo].[BILLINFO] ([IdBillInfo], [IdBill], [Service], [Amount], [Price]) VALUES (11, 6, N'Pizza', 2, 100000)
INSERT [dbo].[BILLINFO] ([IdBillInfo], [IdBill], [Service], [Amount], [Price]) VALUES (12, 6, N'Coca', 1, 15000)
SET IDENTITY_INSERT [dbo].[BILLINFO] OFF
GO
SET IDENTITY_INSERT [dbo].[CATEGORY_SERVICE] ON 

INSERT [dbo].[CATEGORY_SERVICE] ([IdCategoryService], [Name]) VALUES (1, N'Đồ ăn nhanh')
INSERT [dbo].[CATEGORY_SERVICE] ([IdCategoryService], [Name]) VALUES (2, N'Nước uống')
SET IDENTITY_INSERT [dbo].[CATEGORY_SERVICE] OFF
GO
SET IDENTITY_INSERT [dbo].[SERVICE] ON 

INSERT [dbo].[SERVICE] ([IdService], [Name], [Price], [IdCategoryService]) VALUES (1, N'Mỳ trộn', 15000, 1)
INSERT [dbo].[SERVICE] ([IdService], [Name], [Price], [IdCategoryService]) VALUES (2, N'Pizza', 100000, 1)
INSERT [dbo].[SERVICE] ([IdService], [Name], [Price], [IdCategoryService]) VALUES (3, N'Coca', 15000, 2)
INSERT [dbo].[SERVICE] ([IdService], [Name], [Price], [IdCategoryService]) VALUES (4, N'Pepsi', 15000, 2)
SET IDENTITY_INSERT [dbo].[SERVICE] OFF
GO
SET IDENTITY_INSERT [dbo].[CATEGORY_USER] ON 

INSERT [dbo].[CATEGORY_USER] ([IdCategoryUser], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[CATEGORY_USER] ([IdCategoryUser], [Name]) VALUES (2, N'Staff')
SET IDENTITY_INSERT [dbo].[CATEGORY_USER] OFF
GO
SET IDENTITY_INSERT [dbo].[USERS] ON 

INSERT [dbo].[USERS] ([Users_Id], [UserName], [Password], [IdEmployee], [Type]) VALUES (2, N'admin', N'cdd96d3cc73d1dbdaffa03cc6cd7339b', 1, 1)
SET IDENTITY_INSERT [dbo].[USERS] OFF
GO
SET IDENTITY_INSERT [dbo].[RENTALDETAIL] ON 

INSERT [dbo].[RENTALDETAIL] ([IdRentalDetail], [IdRental], [IdService], [Amount], [Total]) VALUES (6, 2, 1, 1, 15000)
INSERT [dbo].[RENTALDETAIL] ([IdRentalDetail], [IdRental], [IdService], [Amount], [Total]) VALUES (7, 2, 2, 2, 200000)
INSERT [dbo].[RENTALDETAIL] ([IdRentalDetail], [IdRental], [IdService], [Amount], [Total]) VALUES (8, 2, 3, 1, 15000)
SET IDENTITY_INSERT [dbo].[RENTALDETAIL] OFF
GO
SET IDENTITY_INSERT [dbo].[RESERVATION_DETAIL] ON 

INSERT [dbo].[RESERVATION_DETAIL] ([IdReservationDetail], [IdRoom], [IdReservation], [Status]) VALUES (1, 1, 1, N'Phòng đã thanh toán')
SET IDENTITY_INSERT [dbo].[RESERVATION_DETAIL] OFF
GO
