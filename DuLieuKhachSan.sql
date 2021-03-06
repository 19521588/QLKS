USE [QLKS]
GO
SET IDENTITY_INSERT [dbo].[CUSTOMER] ON 

INSERT [dbo].[CUSTOMER] ([IdCustomer], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Nationality]) VALUES (1, N'Trương Hưng', N'Đăk Lăk', CAST(N'2001-04-20' AS Date), N'0822904906', N'123456789', N'Nam', N'Việt Nam')
INSERT [dbo].[CUSTOMER] ([IdCustomer], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Nationality]) VALUES (2, N'Huy Hoàng', N'Bình Định', CAST(N'2001-06-05' AS Date), N'0384237411', N'123456788', N'Nam', N'Việt Nam')
INSERT [dbo].[CUSTOMER] ([IdCustomer], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Nationality]) VALUES (3, N'Hoàng Phúc', N'Tiền Giang', CAST(N'2001-12-10' AS Date), N'0821989126', N'123456787', N'Nam', N'Việt Nam')
INSERT [dbo].[CUSTOMER] ([IdCustomer], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Nationality]) VALUES (4, N'Lê Phúc', N'Tiền Giang', CAST(N'2001-04-21' AS Date), N'0123466231', N'123456786', N'Nam', N'Việt Nam')
INSERT [dbo].[CUSTOMER] ([IdCustomer], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Nationality]) VALUES (5, N'Trần Bảo Hoàng', N'Bình Định', CAST(N'2001-04-22' AS Date), N'0822904906', N'123456785', N'Nữ', N'Việt Nam')
INSERT [dbo].[CUSTOMER] ([IdCustomer], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Nationality]) VALUES (6, N'Nguyễn Văn cự', N'Bình Định', CAST(N'2001-04-23' AS Date), N'0345876781', N'123456784', N'Nam', N'Việt Nam')
INSERT [dbo].[CUSTOMER] ([IdCustomer], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Nationality]) VALUES (7, N'Trương Công Hưng', N'Phú Yên', CAST(N'2001-04-24' AS Date), N'0346106812', N'123456783', N'Nam', N'Việt Nam')
INSERT [dbo].[CUSTOMER] ([IdCustomer], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Nationality]) VALUES (8, N'Bùi Khắc Lam', N'Quảng Ngãi', CAST(N'2001-04-25' AS Date), N'0987165465', N'123456782', N'Nam', N'Việt Nam')
INSERT [dbo].[CUSTOMER] ([IdCustomer], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Nationality]) VALUES (9, N'Trần Văn Hậu', N'Bến Tre', CAST(N'2001-04-26' AS Date), N'0985190944', N'123456781', N'Nam', N'Việt Nam')
INSERT [dbo].[CUSTOMER] ([IdCustomer], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Nationality]) VALUES (10, N'Lê Văn Nhất', N'Vũng Tàu', CAST(N'2001-04-10' AS Date), N'0822846522', N'123456780', N'Nam', N'Việt Nam')
INSERT [dbo].[CUSTOMER] ([IdCustomer], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Nationality]) VALUES (11, N'Trương Hưng', N'Đăk Lăk', CAST(N'2001-04-20' AS Date), N'0822904906', N'123456789', N'Nam', N'Việt Nam')
INSERT [dbo].[CUSTOMER] ([IdCustomer], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Nationality]) VALUES (12, N'Huy Hoàng', N'Bình Định', CAST(N'2001-06-05' AS Date), N'0384237411', N'123456788', N'Nam', N'Việt Nam')
SET IDENTITY_INSERT [dbo].[CUSTOMER] OFF
GO
SET IDENTITY_INSERT [dbo].[EMPLOYEE] ON 

INSERT [dbo].[EMPLOYEE] ([IdEmployee], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Position], [Salary]) VALUES (1, N'Trương Hưng', N'KTX A', CAST(N'2001-03-09' AS Date), N'0981355338', N'198745613', N'Nam', N'Quản lý', N'10000000')
INSERT [dbo].[EMPLOYEE] ([IdEmployee], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Position], [Salary]) VALUES (2, N'Phúc Lê', N'KTX B', CAST(N'2001-06-12' AS Date), N'0337237908', N'312778230', N'Nam', N'Nhân viên', N'7000000')
INSERT [dbo].[EMPLOYEE] ([IdEmployee], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Position], [Salary]) VALUES (3, N'Huy Hoàng', N'KTX A', CAST(N'2001-02-04' AS Date), N'0336349561', N'176291648', N'Nam', N'Nhân viên', N'7000000')
SET IDENTITY_INSERT [dbo].[EMPLOYEE] OFF
GO
SET IDENTITY_INSERT [dbo].[RESERVATION] ON 

INSERT [dbo].[RESERVATION] ([IdReservation], [IdEmployee], [IdCustomer], [Date], [Start_Date], [End_Date], [Amount]) VALUES (1, 1, 1, 1, CAST(N'2021-08-20T00:00:00.000' AS DateTime), CAST(N'2021-08-21T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[RESERVATION] ([IdReservation], [IdEmployee], [IdCustomer], [Date], [Start_Date], [End_Date], [Amount]) VALUES (2, 1, 2, 5, CAST(N'2021-08-22T00:00:00.000' AS DateTime), CAST(N'2021-08-27T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[RESERVATION] ([IdReservation], [IdEmployee], [IdCustomer], [Date], [Start_Date], [End_Date], [Amount]) VALUES (3, 1, 3, 5, CAST(N'2021-09-24T00:00:00.000' AS DateTime), CAST(N'2021-09-29T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[RESERVATION] ([IdReservation], [IdEmployee], [IdCustomer], [Date], [Start_Date], [End_Date], [Amount]) VALUES (4, 1, 4, 1, CAST(N'2021-10-21T00:00:00.000' AS DateTime), CAST(N'2021-10-22T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[RESERVATION] ([IdReservation], [IdEmployee], [IdCustomer], [Date], [Start_Date], [End_Date], [Amount]) VALUES (5, 2, 5, 1, CAST(N'2021-10-25T00:00:00.000' AS DateTime), CAST(N'2021-10-26T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[RESERVATION] ([IdReservation], [IdEmployee], [IdCustomer], [Date], [Start_Date], [End_Date], [Amount]) VALUES (6, 1, 6, 2, CAST(N'2021-10-27T00:00:00.000' AS DateTime), CAST(N'2021-10-29T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[RESERVATION] ([IdReservation], [IdEmployee], [IdCustomer], [Date], [Start_Date], [End_Date], [Amount]) VALUES (7, 1, 7, 3, CAST(N'2021-11-20T00:00:00.000' AS DateTime), CAST(N'2021-11-23T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[RESERVATION] ([IdReservation], [IdEmployee], [IdCustomer], [Date], [Start_Date], [End_Date], [Amount]) VALUES (8, 1, 8, 2, CAST(N'2021-12-26T00:00:00.000' AS DateTime), CAST(N'2021-12-28T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[RESERVATION] ([IdReservation], [IdEmployee], [IdCustomer], [Date], [Start_Date], [End_Date], [Amount]) VALUES (9, 3, 9, 0, CAST(N'2022-01-20T00:00:00.000' AS DateTime), CAST(N'2022-01-20T00:07:00.000' AS DateTime), 1)
INSERT [dbo].[RESERVATION] ([IdReservation], [IdEmployee], [IdCustomer], [Date], [Start_Date], [End_Date], [Amount]) VALUES (10, 1, 10, 1, CAST(N'2022-02-20T00:00:00.000' AS DateTime), CAST(N'2022-02-25T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[RESERVATION] ([IdReservation], [IdEmployee], [IdCustomer], [Date], [Start_Date], [End_Date], [Amount]) VALUES (11, 1, 11, 0, CAST(N'2022-03-10T21:20:00.000' AS DateTime), CAST(N'2022-03-11T12:00:00.000' AS DateTime), 1)
INSERT [dbo].[RESERVATION] ([IdReservation], [IdEmployee], [IdCustomer], [Date], [Start_Date], [End_Date], [Amount]) VALUES (12, 1, 12, 0, CAST(N'2022-03-10T21:27:00.000' AS DateTime), CAST(N'2022-03-10T22:00:00.000' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[RESERVATION] OFF
GO
SET IDENTITY_INSERT [dbo].[CATEGORY_ROOM] ON 

INSERT [dbo].[CATEGORY_ROOM] ([IdCategoryRoom], [Name], [Price_Day], [Price_Hour], [Beds]) VALUES (1, N'Standard', 700000, 50000, 1)
INSERT [dbo].[CATEGORY_ROOM] ([IdCategoryRoom], [Name], [Price_Day], [Price_Hour], [Beds]) VALUES (2, N'Superior', 1000000, 100000, 2)
INSERT [dbo].[CATEGORY_ROOM] ([IdCategoryRoom], [Name], [Price_Day], [Price_Hour], [Beds]) VALUES (3, N'Deluxe', 1500000, 150000, 2)
INSERT [dbo].[CATEGORY_ROOM] ([IdCategoryRoom], [Name], [Price_Day], [Price_Hour], [Beds]) VALUES (4, N'Connecting ', 2000000, 250000, 3)
SET IDENTITY_INSERT [dbo].[CATEGORY_ROOM] OFF
GO
SET IDENTITY_INSERT [dbo].[ROOM] ON 

INSERT [dbo].[ROOM] ([IdRoom], [Name], [Clean], [IdCategoryRoom]) VALUES (1, N'101', N'Đã dọn dẹp', 1)
INSERT [dbo].[ROOM] ([IdRoom], [Name], [Clean], [IdCategoryRoom]) VALUES (2, N'102', N'Đã dọn dẹp', 1)
INSERT [dbo].[ROOM] ([IdRoom], [Name], [Clean], [IdCategoryRoom]) VALUES (3, N'103', N'Đã dọn dẹp', 1)
INSERT [dbo].[ROOM] ([IdRoom], [Name], [Clean], [IdCategoryRoom]) VALUES (4, N'104', N'Đã dọn dẹp', 1)
INSERT [dbo].[ROOM] ([IdRoom], [Name], [Clean], [IdCategoryRoom]) VALUES (5, N'105', N'Đã dọn dẹp', 1)
INSERT [dbo].[ROOM] ([IdRoom], [Name], [Clean], [IdCategoryRoom]) VALUES (6, N'201', N'Đã dọn dẹp', 2)
INSERT [dbo].[ROOM] ([IdRoom], [Name], [Clean], [IdCategoryRoom]) VALUES (7, N'202', N'Đã dọn dẹp', 2)
INSERT [dbo].[ROOM] ([IdRoom], [Name], [Clean], [IdCategoryRoom]) VALUES (8, N'203', N'Đã dọn dẹp', 2)
INSERT [dbo].[ROOM] ([IdRoom], [Name], [Clean], [IdCategoryRoom]) VALUES (9, N'204', N'Đã dọn dẹp', 2)
INSERT [dbo].[ROOM] ([IdRoom], [Name], [Clean], [IdCategoryRoom]) VALUES (10, N'205', N'Đã dọn dẹp', 2)
INSERT [dbo].[ROOM] ([IdRoom], [Name], [Clean], [IdCategoryRoom]) VALUES (11, N'301', N'Đã dọn dẹp', 3)
INSERT [dbo].[ROOM] ([IdRoom], [Name], [Clean], [IdCategoryRoom]) VALUES (12, N'302', N'Đã dọn dẹp', 3)
INSERT [dbo].[ROOM] ([IdRoom], [Name], [Clean], [IdCategoryRoom]) VALUES (13, N'303', N'Đã dọn dẹp', 3)
INSERT [dbo].[ROOM] ([IdRoom], [Name], [Clean], [IdCategoryRoom]) VALUES (14, N'304', N'Đã dọn dẹp', 3)
INSERT [dbo].[ROOM] ([IdRoom], [Name], [Clean], [IdCategoryRoom]) VALUES (15, N'305', N'Đã dọn dẹp', 3)
INSERT [dbo].[ROOM] ([IdRoom], [Name], [Clean], [IdCategoryRoom]) VALUES (16, N'401', N'Đã dọn dẹp', 4)
INSERT [dbo].[ROOM] ([IdRoom], [Name], [Clean], [IdCategoryRoom]) VALUES (17, N'402', N'Đã dọn dẹp', 4)
INSERT [dbo].[ROOM] ([IdRoom], [Name], [Clean], [IdCategoryRoom]) VALUES (18, N'403', N'Đã dọn dẹp', 4)
INSERT [dbo].[ROOM] ([IdRoom], [Name], [Clean], [IdCategoryRoom]) VALUES (19, N'404', N'Đã dọn dẹp', 4)
INSERT [dbo].[ROOM] ([IdRoom], [Name], [Clean], [IdCategoryRoom]) VALUES (20, N'405', N'Đã dọn dẹp', 4)
SET IDENTITY_INSERT [dbo].[ROOM] OFF
GO
SET IDENTITY_INSERT [dbo].[RENTAL] ON 

INSERT [dbo].[RENTAL] ([IdRental], [IdReservation], [IdRoom], [DateRental]) VALUES (1, 1, 1, CAST(N'2021-08-20' AS Date))
INSERT [dbo].[RENTAL] ([IdRental], [IdReservation], [IdRoom], [DateRental]) VALUES (2, 2, 2, CAST(N'2021-08-22' AS Date))
INSERT [dbo].[RENTAL] ([IdRental], [IdReservation], [IdRoom], [DateRental]) VALUES (3, 3, 3, CAST(N'2021-09-24' AS Date))
INSERT [dbo].[RENTAL] ([IdRental], [IdReservation], [IdRoom], [DateRental]) VALUES (4, 3, 1, CAST(N'2021-09-24' AS Date))
INSERT [dbo].[RENTAL] ([IdRental], [IdReservation], [IdRoom], [DateRental]) VALUES (5, 4, 1, CAST(N'2021-10-21' AS Date))
INSERT [dbo].[RENTAL] ([IdRental], [IdReservation], [IdRoom], [DateRental]) VALUES (6, 4, 2, CAST(N'2021-10-21' AS Date))
INSERT [dbo].[RENTAL] ([IdRental], [IdReservation], [IdRoom], [DateRental]) VALUES (7, 5, 3, CAST(N'2021-10-25' AS Date))
INSERT [dbo].[RENTAL] ([IdRental], [IdReservation], [IdRoom], [DateRental]) VALUES (8, 6, 2, CAST(N'2021-10-27' AS Date))
INSERT [dbo].[RENTAL] ([IdRental], [IdReservation], [IdRoom], [DateRental]) VALUES (9, 6, 3, CAST(N'2021-10-27' AS Date))
INSERT [dbo].[RENTAL] ([IdRental], [IdReservation], [IdRoom], [DateRental]) VALUES (10, 7, 1, CAST(N'2021-11-20' AS Date))
INSERT [dbo].[RENTAL] ([IdRental], [IdReservation], [IdRoom], [DateRental]) VALUES (11, 8, 2, CAST(N'2021-12-26' AS Date))
INSERT [dbo].[RENTAL] ([IdRental], [IdReservation], [IdRoom], [DateRental]) VALUES (12, 9, 1, CAST(N'2022-01-20' AS Date))
INSERT [dbo].[RENTAL] ([IdRental], [IdReservation], [IdRoom], [DateRental]) VALUES (13, 10, 1, CAST(N'2022-02-20' AS Date))
INSERT [dbo].[RENTAL] ([IdRental], [IdReservation], [IdRoom], [DateRental]) VALUES (14, 11, 1, CAST(N'2022-03-10' AS Date))
INSERT [dbo].[RENTAL] ([IdRental], [IdReservation], [IdRoom], [DateRental]) VALUES (15, 12, 3, CAST(N'2022-03-10' AS Date))
SET IDENTITY_INSERT [dbo].[RENTAL] OFF
GO
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([IdBill], [Total], [Surcharge], [Discount], [SurchargePercent], [DiscountPercent], [Name], [IdRental], [Date_Bill], [CategoryRoom]) VALUES (2, 760000, 0, 0, 0, 0, N'Trương Hưng', 1, CAST(N'2021-08-20' AS Date), N'1')
INSERT [dbo].[Bill] ([IdBill], [Total], [Surcharge], [Discount], [SurchargePercent], [DiscountPercent], [Name], [IdRental], [Date_Bill], [CategoryRoom]) VALUES (3, 367000, 0, 0, 0, 0, N'Phúc Lê', 2, CAST(N'2021-08-22' AS Date), N'1')
INSERT [dbo].[Bill] ([IdBill], [Total], [Surcharge], [Discount], [SurchargePercent], [DiscountPercent], [Name], [IdRental], [Date_Bill], [CategoryRoom]) VALUES (4, 392000, 0, 0, 0, 0, N'Huy Hoàng', 3, CAST(N'2021-09-24' AS Date), N'1')
INSERT [dbo].[Bill] ([IdBill], [Total], [Surcharge], [Discount], [SurchargePercent], [DiscountPercent], [Name], [IdRental], [Date_Bill], [CategoryRoom]) VALUES (5, 3750000, 0, 0, 0, 0, N'Trương Hưng', 4, CAST(N'2021-09-24' AS Date), N'1')
INSERT [dbo].[Bill] ([IdBill], [Total], [Surcharge], [Discount], [SurchargePercent], [DiscountPercent], [Name], [IdRental], [Date_Bill], [CategoryRoom]) VALUES (7, 109000, 0, 0, 0, 0, N'Trương Hưng', 5, CAST(N'2021-10-21' AS Date), N'1')
INSERT [dbo].[Bill] ([IdBill], [Total], [Surcharge], [Discount], [SurchargePercent], [DiscountPercent], [Name], [IdRental], [Date_Bill], [CategoryRoom]) VALUES (8, 715000, 0, 0, 0, 0, N'Trương Hưng', 6, CAST(N'2021-10-21' AS Date), N'1')
INSERT [dbo].[Bill] ([IdBill], [Total], [Surcharge], [Discount], [SurchargePercent], [DiscountPercent], [Name], [IdRental], [Date_Bill], [CategoryRoom]) VALUES (9, 700000, 0, 0, 0, 0, N'Huy Hoàng', 7, CAST(N'2021-10-25' AS Date), N'1')
INSERT [dbo].[Bill] ([IdBill], [Total], [Surcharge], [Discount], [SurchargePercent], [DiscountPercent], [Name], [IdRental], [Date_Bill], [CategoryRoom]) VALUES (10, 1700000, 0, 0, 0, 0, N'Phúc Lê', 8, CAST(N'2021-10-27' AS Date), N'1')
INSERT [dbo].[Bill] ([IdBill], [Total], [Surcharge], [Discount], [SurchargePercent], [DiscountPercent], [Name], [IdRental], [Date_Bill], [CategoryRoom]) VALUES (14, 1400000, 0, 0, 0, 0, N'Phúc Lê', 9, CAST(N'2021-10-27' AS Date), N'1')
INSERT [dbo].[Bill] ([IdBill], [Total], [Surcharge], [Discount], [SurchargePercent], [DiscountPercent], [Name], [IdRental], [Date_Bill], [CategoryRoom]) VALUES (15, 2400000, 0, 0, 0, 0, N'Trương Hưng', 10, CAST(N'2021-11-20' AS Date), N'1')
INSERT [dbo].[Bill] ([IdBill], [Total], [Surcharge], [Discount], [SurchargePercent], [DiscountPercent], [Name], [IdRental], [Date_Bill], [CategoryRoom]) VALUES (20, 2130000, 0, 0, 0, 0, N'Trương Hưng', 11, CAST(N'2021-12-26' AS Date), N'1')
INSERT [dbo].[Bill] ([IdBill], [Total], [Surcharge], [Discount], [SurchargePercent], [DiscountPercent], [Name], [IdRental], [Date_Bill], [CategoryRoom]) VALUES (21, 580000, 0, 0, 0, 0, N'Trương Hưng', 12, CAST(N'2022-01-20' AS Date), N'1')
INSERT [dbo].[Bill] ([IdBill], [Total], [Surcharge], [Discount], [SurchargePercent], [DiscountPercent], [Name], [IdRental], [Date_Bill], [CategoryRoom]) VALUES (22, 700000, 0, 0, 0, 0, N'Trương Hưng', 13, CAST(N'2022-02-20' AS Date), N'1')
INSERT [dbo].[Bill] ([IdBill], [Total], [Surcharge], [Discount], [SurchargePercent], [DiscountPercent], [Name], [IdRental], [Date_Bill], [CategoryRoom]) VALUES (23, 750000, 225000, 0, 30, 0, N'Trương Hưng', 14, CAST(N'2022-03-10' AS Date), N'Standard')
INSERT [dbo].[Bill] ([IdBill], [Total], [Surcharge], [Discount], [SurchargePercent], [DiscountPercent], [Name], [IdRental], [Date_Bill], [CategoryRoom]) VALUES (24, 315000, 15000, 0, 30, 0, N'Trương Hưng', 15, CAST(N'2022-03-10' AS Date), N'Standard')
SET IDENTITY_INSERT [dbo].[Bill] OFF
GO
SET IDENTITY_INSERT [dbo].[BILLINFO] ON 

INSERT [dbo].[BILLINFO] ([IdBillInfo], [IdBill], [Service], [Amount], [Price]) VALUES (1, 2, N'1', 2, 40000)
INSERT [dbo].[BILLINFO] ([IdBillInfo], [IdBill], [Service], [Amount], [Price]) VALUES (2, 2, N'9', 2, 20000)
INSERT [dbo].[BILLINFO] ([IdBillInfo], [IdBill], [Service], [Amount], [Price]) VALUES (3, 3, N'11', 1, 100000)
INSERT [dbo].[BILLINFO] ([IdBillInfo], [IdBill], [Service], [Amount], [Price]) VALUES (4, 3, N'Sting', 2, 30000)
INSERT [dbo].[BILLINFO] ([IdBillInfo], [IdBill], [Service], [Amount], [Price]) VALUES (5, 3, N'Mì xào', 2, 40000)
INSERT [dbo].[BILLINFO] ([IdBillInfo], [IdBill], [Service], [Amount], [Price]) VALUES (6, 4, N'Phở', 3, 75000)
INSERT [dbo].[BILLINFO] ([IdBillInfo], [IdBill], [Service], [Amount], [Price]) VALUES (7, 4, N'Seven up', 3, 45000)
INSERT [dbo].[BILLINFO] ([IdBillInfo], [IdBill], [Service], [Amount], [Price]) VALUES (8, 4, N'Chuyển đồ', 3, 300000)
INSERT [dbo].[BILLINFO] ([IdBillInfo], [IdBill], [Service], [Amount], [Price]) VALUES (9, 5, N'Karaoke', 2, 200000)
INSERT [dbo].[BILLINFO] ([IdBillInfo], [IdBill], [Service], [Amount], [Price]) VALUES (10, 5, N'Mì xào', 2, 50000)
INSERT [dbo].[BILLINFO] ([IdBillInfo], [IdBill], [Service], [Amount], [Price]) VALUES (12, 7, N'Cơm chiên', 3, 60000)
INSERT [dbo].[BILLINFO] ([IdBillInfo], [IdBill], [Service], [Amount], [Price]) VALUES (13, 7, N'Mì xào', 4, 80000)
INSERT [dbo].[BILLINFO] ([IdBillInfo], [IdBill], [Service], [Amount], [Price]) VALUES (14, 7, N'Phở', 1, 25000)
INSERT [dbo].[BILLINFO] ([IdBillInfo], [IdBill], [Service], [Amount], [Price]) VALUES (15, 8, N'Seven up', 1, 15000)
INSERT [dbo].[BILLINFO] ([IdBillInfo], [IdBill], [Service], [Amount], [Price]) VALUES (17, 10, N'Karaoke', 1, 100000)
INSERT [dbo].[BILLINFO] ([IdBillInfo], [IdBill], [Service], [Amount], [Price]) VALUES (18, 10, N'11', 2, 200000)
INSERT [dbo].[BILLINFO] ([IdBillInfo], [IdBill], [Service], [Amount], [Price]) VALUES (19, 15, N'Chuyển đồ', 2, 200000)
INSERT [dbo].[BILLINFO] ([IdBillInfo], [IdBill], [Service], [Amount], [Price]) VALUES (20, 15, N'Phở', 4, 100000)
INSERT [dbo].[BILLINFO] ([IdBillInfo], [IdBill], [Service], [Amount], [Price]) VALUES (21, 20, N'Mỳ trộn', 1, 20000)
INSERT [dbo].[BILLINFO] ([IdBillInfo], [IdBill], [Service], [Amount], [Price]) VALUES (22, 21, N'Seven up', 2, 30000)
INSERT [dbo].[BILLINFO] ([IdBillInfo], [IdBill], [Service], [Amount], [Price]) VALUES (23, 21, N'Phở', 4, 100000)
INSERT [dbo].[BILLINFO] ([IdBillInfo], [IdBill], [Service], [Amount], [Price]) VALUES (24, 24, N'Mỳ trộn', 5, 20000)
INSERT [dbo].[BILLINFO] ([IdBillInfo], [IdBill], [Service], [Amount], [Price]) VALUES (25, 24, N'Mì xào', 3, 20000)
INSERT [dbo].[BILLINFO] ([IdBillInfo], [IdBill], [Service], [Amount], [Price]) VALUES (26, 24, N'Phở', 3, 25000)
INSERT [dbo].[BILLINFO] ([IdBillInfo], [IdBill], [Service], [Amount], [Price]) VALUES (27, 24, N'Nước suối', 3, 10000)
SET IDENTITY_INSERT [dbo].[BILLINFO] OFF
GO
SET IDENTITY_INSERT [dbo].[CATEGORY_SERVICE] ON 

INSERT [dbo].[CATEGORY_SERVICE] ([IdCategoryService], [Name]) VALUES (1, N'Đồ ăn')
INSERT [dbo].[CATEGORY_SERVICE] ([IdCategoryService], [Name]) VALUES (2, N'Nước uống')
INSERT [dbo].[CATEGORY_SERVICE] ([IdCategoryService], [Name]) VALUES (3, N'Giải trí')
INSERT [dbo].[CATEGORY_SERVICE] ([IdCategoryService], [Name]) VALUES (4, N'Vận chuyển')
SET IDENTITY_INSERT [dbo].[CATEGORY_SERVICE] OFF
GO
SET IDENTITY_INSERT [dbo].[SERVICE] ON 

INSERT [dbo].[SERVICE] ([IdService], [Name], [Price], [IdCategoryService]) VALUES (1, N'Mỳ trộn', 20000, 1)
INSERT [dbo].[SERVICE] ([IdService], [Name], [Price], [IdCategoryService]) VALUES (2, N'Mì xào', 20000, 1)
INSERT [dbo].[SERVICE] ([IdService], [Name], [Price], [IdCategoryService]) VALUES (3, N'Cơm chiên', 20000, 1)
INSERT [dbo].[SERVICE] ([IdService], [Name], [Price], [IdCategoryService]) VALUES (4, N'Bún bò', 25000, 1)
INSERT [dbo].[SERVICE] ([IdService], [Name], [Price], [IdCategoryService]) VALUES (5, N'Phở', 25000, 1)
INSERT [dbo].[SERVICE] ([IdService], [Name], [Price], [IdCategoryService]) VALUES (6, N'Pepsi', 15000, 2)
INSERT [dbo].[SERVICE] ([IdService], [Name], [Price], [IdCategoryService]) VALUES (7, N'Sting', 15000, 2)
INSERT [dbo].[SERVICE] ([IdService], [Name], [Price], [IdCategoryService]) VALUES (8, N'Seven up', 15000, 2)
INSERT [dbo].[SERVICE] ([IdService], [Name], [Price], [IdCategoryService]) VALUES (9, N'Nước suối', 10000, 2)
INSERT [dbo].[SERVICE] ([IdService], [Name], [Price], [IdCategoryService]) VALUES (10, N'Karaoke', 100000, 3)
INSERT [dbo].[SERVICE] ([IdService], [Name], [Price], [IdCategoryService]) VALUES (11, N'Đưa đón sân bay', 100000, 4)
INSERT [dbo].[SERVICE] ([IdService], [Name], [Price], [IdCategoryService]) VALUES (12, N'Chuyển đồ', 100000, 4)
SET IDENTITY_INSERT [dbo].[SERVICE] OFF
GO
SET IDENTITY_INSERT [dbo].[CATEGORY_USER] ON 

INSERT [dbo].[CATEGORY_USER] ([IdCategoryUser], [Name]) VALUES (1, N'Quản lý')
INSERT [dbo].[CATEGORY_USER] ([IdCategoryUser], [Name]) VALUES (2, N'Nhân viên')
SET IDENTITY_INSERT [dbo].[CATEGORY_USER] OFF
GO
SET IDENTITY_INSERT [dbo].[USERS] ON 

INSERT [dbo].[USERS] ([Users_Id], [UserName], [Password], [IdEmployee], [Type]) VALUES (1, N'admin', N'cdd96d3cc73d1dbdaffa03cc6cd7339b', 1, 1)
INSERT [dbo].[USERS] ([Users_Id], [UserName], [Password], [IdEmployee], [Type]) VALUES (2, N'nv1', N'cdd96d3cc73d1dbdaffa03cc6cd7339b', 2, 2)
INSERT [dbo].[USERS] ([Users_Id], [UserName], [Password], [IdEmployee], [Type]) VALUES (3, N'nv2', N'cdd96d3cc73d1dbdaffa03cc6cd7339b', 3, 2)
SET IDENTITY_INSERT [dbo].[USERS] OFF
GO
SET IDENTITY_INSERT [dbo].[CONVINIENT] ON 

INSERT [dbo].[CONVINIENT] ([IdConvinient], [Name]) VALUES (1, N'Giường đơn')
INSERT [dbo].[CONVINIENT] ([IdConvinient], [Name]) VALUES (2, N'Giường đôi')
INSERT [dbo].[CONVINIENT] ([IdConvinient], [Name]) VALUES (3, N'Giường đôi lớn')
INSERT [dbo].[CONVINIENT] ([IdConvinient], [Name]) VALUES (4, N'Giường cỡ lớn')
INSERT [dbo].[CONVINIENT] ([IdConvinient], [Name]) VALUES (5, N'Quạt treo tường')
INSERT [dbo].[CONVINIENT] ([IdConvinient], [Name]) VALUES (6, N'Quạt đứng')
INSERT [dbo].[CONVINIENT] ([IdConvinient], [Name]) VALUES (7, N'Máy lạnh')
INSERT [dbo].[CONVINIENT] ([IdConvinient], [Name]) VALUES (8, N'Máy giặt')
INSERT [dbo].[CONVINIENT] ([IdConvinient], [Name]) VALUES (9, N'Máy sấy')
INSERT [dbo].[CONVINIENT] ([IdConvinient], [Name]) VALUES (10, N'Bàn nhỏ')
INSERT [dbo].[CONVINIENT] ([IdConvinient], [Name]) VALUES (11, N'Bàn lớn')
INSERT [dbo].[CONVINIENT] ([IdConvinient], [Name]) VALUES (12, N'Ghế sofa')
INSERT [dbo].[CONVINIENT] ([IdConvinient], [Name]) VALUES (13, N'Ghế gỗ')
SET IDENTITY_INSERT [dbo].[CONVINIENT] OFF
GO
SET IDENTITY_INSERT [dbo].[DETAIL_CONVINIENT] ON 

INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (1, 1, 1, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (2, 1, 5, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (3, 1, 7, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (4, 2, 1, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (5, 2, 5, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (6, 2, 7, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (7, 3, 1, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (8, 3, 5, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (9, 3, 7, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (10, 4, 1, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (11, 4, 5, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (12, 4, 7, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (13, 5, 1, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (14, 5, 5, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (15, 5, 7, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (16, 6, 2, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (17, 6, 6, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (18, 6, 7, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (19, 6, 12, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (20, 7, 2, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (21, 7, 6, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (22, 7, 7, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (23, 7, 12, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (24, 8, 2, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (25, 8, 6, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (26, 8, 7, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (27, 8, 12, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (28, 9, 2, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (29, 9, 6, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (30, 9, 7, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (31, 9, 12, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (32, 10, 2, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (33, 10, 6, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (34, 10, 7, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (35, 10, 12, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (37, 11, 3, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (38, 11, 5, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (39, 11, 7, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (40, 11, 10, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (41, 11, 13, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (42, 12, 3, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (43, 12, 5, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (44, 12, 7, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (45, 12, 10, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (46, 12, 13, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (47, 13, 3, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (48, 13, 5, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (49, 13, 7, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (50, 13, 10, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (51, 13, 13, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (52, 14, 3, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (53, 14, 5, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (54, 14, 7, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (55, 14, 10, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (56, 14, 13, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (57, 15, 3, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (58, 15, 5, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (59, 15, 7, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (60, 15, 10, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (61, 15, 13, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (62, 16, 4, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (63, 16, 6, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (64, 16, 7, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (65, 16, 8, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (66, 16, 11, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (67, 16, 13, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (68, 17, 4, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (69, 17, 6, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (70, 17, 7, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (71, 17, 8, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (72, 17, 11, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (73, 17, 13, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (74, 18, 4, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (75, 18, 6, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (76, 18, 7, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (77, 18, 8, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (78, 18, 11, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (79, 18, 13, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (80, 19, 4, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (81, 19, 6, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (82, 19, 7, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (83, 19, 8, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (84, 19, 11, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (85, 19, 13, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (86, 20, 4, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (87, 20, 6, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (88, 20, 7, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (89, 20, 8, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (90, 20, 11, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdRoom], [IdConvinient], [Amount]) VALUES (91, 20, 13, 1)
SET IDENTITY_INSERT [dbo].[DETAIL_CONVINIENT] OFF
GO
SET IDENTITY_INSERT [dbo].[RENTALDETAIL] ON 

INSERT [dbo].[RENTALDETAIL] ([IdRentalDetail], [IdRental], [IdService], [Amount], [Total]) VALUES (1, 1, 1, 2, 40000)
INSERT [dbo].[RENTALDETAIL] ([IdRentalDetail], [IdRental], [IdService], [Amount], [Total]) VALUES (2, 1, 9, 2, 20000)
INSERT [dbo].[RENTALDETAIL] ([IdRentalDetail], [IdRental], [IdService], [Amount], [Total]) VALUES (3, 2, 11, 1, 100000)
INSERT [dbo].[RENTALDETAIL] ([IdRentalDetail], [IdRental], [IdService], [Amount], [Total]) VALUES (4, 2, 7, 2, 30000)
INSERT [dbo].[RENTALDETAIL] ([IdRentalDetail], [IdRental], [IdService], [Amount], [Total]) VALUES (5, 2, 2, 2, 40000)
INSERT [dbo].[RENTALDETAIL] ([IdRentalDetail], [IdRental], [IdService], [Amount], [Total]) VALUES (6, 3, 5, 3, 75000)
INSERT [dbo].[RENTALDETAIL] ([IdRentalDetail], [IdRental], [IdService], [Amount], [Total]) VALUES (7, 3, 8, 3, 45000)
INSERT [dbo].[RENTALDETAIL] ([IdRentalDetail], [IdRental], [IdService], [Amount], [Total]) VALUES (8, 3, 12, 3, 300000)
INSERT [dbo].[RENTALDETAIL] ([IdRentalDetail], [IdRental], [IdService], [Amount], [Total]) VALUES (9, 4, 10, 2, 200000)
INSERT [dbo].[RENTALDETAIL] ([IdRentalDetail], [IdRental], [IdService], [Amount], [Total]) VALUES (10, 4, 2, 2, 50000)
INSERT [dbo].[RENTALDETAIL] ([IdRentalDetail], [IdRental], [IdService], [Amount], [Total]) VALUES (12, 5, 3, 3, 60000)
INSERT [dbo].[RENTALDETAIL] ([IdRentalDetail], [IdRental], [IdService], [Amount], [Total]) VALUES (13, 5, 2, 4, 80000)
INSERT [dbo].[RENTALDETAIL] ([IdRentalDetail], [IdRental], [IdService], [Amount], [Total]) VALUES (14, 5, 5, 1, 25000)
INSERT [dbo].[RENTALDETAIL] ([IdRentalDetail], [IdRental], [IdService], [Amount], [Total]) VALUES (15, 6, 8, 1, 15000)
INSERT [dbo].[RENTALDETAIL] ([IdRentalDetail], [IdRental], [IdService], [Amount], [Total]) VALUES (17, 8, 10, 1, 100000)
INSERT [dbo].[RENTALDETAIL] ([IdRentalDetail], [IdRental], [IdService], [Amount], [Total]) VALUES (18, 8, 11, 2, 200000)
INSERT [dbo].[RENTALDETAIL] ([IdRentalDetail], [IdRental], [IdService], [Amount], [Total]) VALUES (19, 10, 12, 2, 200000)
INSERT [dbo].[RENTALDETAIL] ([IdRentalDetail], [IdRental], [IdService], [Amount], [Total]) VALUES (20, 10, 5, 4, 100000)
INSERT [dbo].[RENTALDETAIL] ([IdRentalDetail], [IdRental], [IdService], [Amount], [Total]) VALUES (21, 11, 1, 1, 20000)
INSERT [dbo].[RENTALDETAIL] ([IdRentalDetail], [IdRental], [IdService], [Amount], [Total]) VALUES (22, 12, 8, 2, 30000)
INSERT [dbo].[RENTALDETAIL] ([IdRentalDetail], [IdRental], [IdService], [Amount], [Total]) VALUES (23, 12, 5, 4, 100000)
SET IDENTITY_INSERT [dbo].[RENTALDETAIL] OFF
GO
SET IDENTITY_INSERT [dbo].[RESERVATION_DETAIL] ON 

INSERT [dbo].[RESERVATION_DETAIL] ([IdReservationDetail], [IdRoom], [IdReservation], [Status]) VALUES (1, 1, 1, N'Đã Thanh Toán')
INSERT [dbo].[RESERVATION_DETAIL] ([IdReservationDetail], [IdRoom], [IdReservation], [Status]) VALUES (2, 2, 2, N'Đã Thanh Toán')
INSERT [dbo].[RESERVATION_DETAIL] ([IdReservationDetail], [IdRoom], [IdReservation], [Status]) VALUES (3, 3, 3, N'Đã Thanh Toán')
INSERT [dbo].[RESERVATION_DETAIL] ([IdReservationDetail], [IdRoom], [IdReservation], [Status]) VALUES (4, 1, 3, N'Đã Thanh Toán')
INSERT [dbo].[RESERVATION_DETAIL] ([IdReservationDetail], [IdRoom], [IdReservation], [Status]) VALUES (5, 1, 4, N'Đã Thanh Toán')
INSERT [dbo].[RESERVATION_DETAIL] ([IdReservationDetail], [IdRoom], [IdReservation], [Status]) VALUES (6, 2, 4, N'Đã Thanh Toán')
INSERT [dbo].[RESERVATION_DETAIL] ([IdReservationDetail], [IdRoom], [IdReservation], [Status]) VALUES (7, 3, 5, N'Đã Thanh Toán')
INSERT [dbo].[RESERVATION_DETAIL] ([IdReservationDetail], [IdRoom], [IdReservation], [Status]) VALUES (8, 2, 6, N'Đã Thanh Toán')
INSERT [dbo].[RESERVATION_DETAIL] ([IdReservationDetail], [IdRoom], [IdReservation], [Status]) VALUES (9, 3, 6, N'Đã Thanh Toán')
INSERT [dbo].[RESERVATION_DETAIL] ([IdReservationDetail], [IdRoom], [IdReservation], [Status]) VALUES (10, 1, 7, N'Đã Thanh Toán')
INSERT [dbo].[RESERVATION_DETAIL] ([IdReservationDetail], [IdRoom], [IdReservation], [Status]) VALUES (11, 2, 8, N'Đã Thanh Toán')
INSERT [dbo].[RESERVATION_DETAIL] ([IdReservationDetail], [IdRoom], [IdReservation], [Status]) VALUES (12, 1, 9, N'Đã Thanh Toán')
INSERT [dbo].[RESERVATION_DETAIL] ([IdReservationDetail], [IdRoom], [IdReservation], [Status]) VALUES (13, 1, 10, N'Đã Thanh Toán')
INSERT [dbo].[RESERVATION_DETAIL] ([IdReservationDetail], [IdRoom], [IdReservation], [Status]) VALUES (14, 1, 11, N'Phòng đã thanh toán')
INSERT [dbo].[RESERVATION_DETAIL] ([IdReservationDetail], [IdRoom], [IdReservation], [Status]) VALUES (15, 3, 12, N'Phòng đã thanh toán')
SET IDENTITY_INSERT [dbo].[RESERVATION_DETAIL] OFF
GO
INSERT [dbo].[SETTING] ([ID], [Surcharge], [Discount]) VALUES (1, 30, 0)
GO
