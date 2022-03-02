USE [QLKS]
GO

-- Thêm CATEGORY_USER
SET IDENTITY_INSERT [dbo].[CATEGORY_USER] ON 
INSERT [dbo].[CATEGORY_USER] ([IdCategoryUser], [Name]) VALUES (1, N'Quản lý')
INSERT [dbo].[CATEGORY_USER] ([IdCategoryUser], [Name]) VALUES (2, N'Nhân viên')
SET IDENTITY_INSERT [dbo].[CATEGORY_USER] OFF
GO

-- Thêm EMPLOYEE
SET IDENTITY_INSERT [dbo].[EMPLOYEE] ON 
INSERT [dbo].[EMPLOYEE] ([IdEmployee], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Position], [Salary]) VALUES (1, N'Trương Hưng', N'KTX A', CAST(N'2001-03-09' AS Date), N'0981355338', N'198745613', N'Nam', N'Quản lý', N'10000000')
INSERT [dbo].[EMPLOYEE] ([IdEmployee], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Position], [Salary]) VALUES (2, N'Phúc Lê', N'KTX B', CAST(N'2001-06-12' AS Date), N'0337237908', N'312778230', N'Nam', N'Nhân viên', N'7000000')
INSERT [dbo].[EMPLOYEE] ([IdEmployee], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Position], [Salary]) VALUES (3, N'Huy Hoàng', N'KTX A', CAST(N'2001-02-04' AS Date), N'0336349561', N'176291648', N'Nam', N'Nhân viên', N'7000000')
SET IDENTITY_INSERT [dbo].[EMPLOYEE] OFF
GO

-- Thêm USER
SET IDENTITY_INSERT [dbo].[USERS] ON 
INSERT [dbo].[USERS] ([Users_Id], [UserName], [Password], [IdEmployee], [Type]) VALUES (1, N'admin', N'cdd96d3cc73d1dbdaffa03cc6cd7339b', 1, 1)
INSERT [dbo].[USERS] ([Users_Id], [UserName], [Password], [IdEmployee], [Type]) VALUES (2, N'nv1', N'cdd96d3cc73d1dbdaffa03cc6cd7339b', 2, 2)
INSERT [dbo].[USERS] ([Users_Id], [UserName], [Password], [IdEmployee], [Type]) VALUES (3, N'nv2', N'cdd96d3cc73d1dbdaffa03cc6cd7339b', 3, 2)
SET IDENTITY_INSERT [dbo].[USERS] OFF
GO

-- Thêm CATEGORY_SERVICE
SET IDENTITY_INSERT [dbo].[CATEGORY_SERVICE] ON 
INSERT [dbo].[CATEGORY_SERVICE] ([IdCategoryService], [Name]) VALUES (1, N'Đồ ăn')
INSERT [dbo].[CATEGORY_SERVICE] ([IdCategoryService], [Name]) VALUES (2, N'Nước uống')
INSERT [dbo].[CATEGORY_SERVICE] ([IdCategoryService], [Name]) VALUES (3, N'Giải trí')
INSERT [dbo].[CATEGORY_SERVICE] ([IdCategoryService], [Name]) VALUES (4, N'Vận chuyển')
SET IDENTITY_INSERT [dbo].[CATEGORY_SERVICE] OFF
GO

-- Thêm SERVICE
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

-- Thêm CATEGORY_ROOM
SET IDENTITY_INSERT [dbo].[CATEGORY_ROOM] ON 
INSERT [dbo].[CATEGORY_ROOM] ([IdCategoryRoom], [Name], [Price_Day], [Price_Hour], [Beds]) VALUES (1, N'Standard', 700000, 50000, 1)
INSERT [dbo].[CATEGORY_ROOM] ([IdCategoryRoom], [Name], [Price_Day], [Price_Hour], [Beds]) VALUES (2, N'Superior', 1000000, 100000, 2)
INSERT [dbo].[CATEGORY_ROOM] ([IdCategoryRoom], [Name], [Price_Day], [Price_Hour], [Beds]) VALUES (3, N'Deluxe', 1500000, 150000, 2)
INSERT [dbo].[CATEGORY_ROOM] ([IdCategoryRoom], [Name], [Price_Day], [Price_Hour], [Beds]) VALUES (4, N'Connecting ', 2000000, 250000, 3)
SET IDENTITY_INSERT [dbo].[CATEGORY_ROOM] OFF
GO

-- Thêm ROOM
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

-- Thêm CONVINIENT
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

-- Thêm CONVININENT_DETAIL
SET IDENTITY_INSERT [dbo].[DETAIL_CONVINIENT] ON 
--Phòng 1
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (1, 1, 1, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (2, 5, 1, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (3, 7, 1, 1)
--Phòng 2
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (4, 1, 2, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (5, 5, 2, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (6, 7, 2, 1)
--Phòng 3
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (7, 1, 3, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (8, 5, 3, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (9, 7, 3, 1)
--Phòng 4
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (10, 1, 4, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (11, 5, 4, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (12, 7, 4, 1)
--Phòng 5
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (13, 1, 5, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (14, 5, 5, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (15, 7, 5, 1)
--Phòng 6
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (16, 2, 6, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (17, 6, 6, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (18, 7, 6, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (19, 12, 6, 1)
--Phòng 7
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (20, 2, 7, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (21, 6, 7, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (22, 7, 7, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (23, 12, 7, 1)
--Phòng 8
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (24, 2, 8, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (25, 6, 8, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (26, 7, 8, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (27, 12, 8, 1)
--Phòng 9
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (28, 2, 9, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (29, 6, 9, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (30, 7, 9, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (31, 12, 9, 1)
--Phòng 10
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (32, 2, 10, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (33, 6, 10, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (34, 7, 10, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (35, 12, 10, 1)
--Phòng 11
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (37, 3, 11, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (38, 5, 11, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (39, 7, 11, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (40, 10, 11, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (41, 13, 11, 1)
--Phòng 12
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (42, 3, 12, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (43, 5, 12, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (44, 7, 12, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (45, 10, 12, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (46, 13, 12, 1)
--Phòng 13
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (47, 3, 13, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (48, 5, 13, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (49, 7, 13, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (50, 10, 13, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (51, 13, 13, 1)
--Phòng 14
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (52, 3, 14, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (53, 5, 14, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (54, 7, 14, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (55, 10, 14, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (56, 13, 14, 1)
--Phòng 15
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (57, 3, 15, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (58, 5, 15, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (59, 7, 15, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (60, 10, 15, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (61, 13, 15, 1)
--Phòng 16
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (62, 4, 16, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (63, 6, 16, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (64, 7, 16, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (65, 8, 16, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (66, 11, 16, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (67, 13, 16, 1)
--Phòng 17
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (68, 4, 17, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (69, 6, 17, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (70, 7, 17, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (71, 8, 17, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (72, 11, 17, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (73, 13, 17, 1)
--Phòng 18
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (74, 4, 18, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (75, 6, 18, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (76, 7, 18, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (77, 8, 18, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (78, 11, 18, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (79, 13, 18, 1)
--Phòng 19
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (80, 4, 19, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (81, 6, 19, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (82, 7, 19, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (83, 8, 19, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (84, 11, 19, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (85, 13, 19, 1)
--Phòng 20
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (86, 4, 20, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (87, 6, 20, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (88, 7, 20, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (89, 8, 20, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (90, 11, 20, 1)
INSERT [dbo].[DETAIL_CONVINIENT] ([IdConvinientDetail], [IdConvinient], [IdRoom], [Amount]) VALUES (91, 13, 20, 1)
SET IDENTITY_INSERT [dbo].[DETAIL_CONVINIENT] OFF 
GO
--Thêm CUSTOMER
SET IDENTITY_INSERT [dbo].[CUSTOMER] ON 
INSERT [dbo].[CUSTOMER] ([IdCustomer], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Nationality]) VALUES (1, N'Trương hưng', N'Đăk Lăk', CAST(N'2001-04-20' AS Date), N'0822904906', N'123456789', N'Nam', N'Việt Nam')
INSERT [dbo].[CUSTOMER] ([IdCustomer], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Nationality]) VALUES (2, N'Trương hưng', N'Đăk Lăk', CAST(N'2001-04-20' AS Date), N'0822904906', N'123456789', N'Nam', N'Việt Nam')
INSERT [dbo].[CUSTOMER] ([IdCustomer], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Nationality]) VALUES (3, N'Trương hưng', N'Đăk Lăk', CAST(N'2001-04-20' AS Date), N'0822904906', N'123456789', N'Nam', N'Việt Nam')
INSERT [dbo].[CUSTOMER] ([IdCustomer], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Nationality]) VALUES (4, N'Trương hưng', N'Đăk Lăk', CAST(N'2001-04-20' AS Date), N'0822904906', N'123456789', N'Nam', N'Việt Nam')
INSERT [dbo].[CUSTOMER] ([IdCustomer], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Nationality]) VALUES (5, N'Trương hưng', N'Đăk Lăk', CAST(N'2001-04-20' AS Date), N'0822904906', N'123456789', N'Nam', N'Việt Nam')
INSERT [dbo].[CUSTOMER] ([IdCustomer], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Nationality]) VALUES (6, N'Trương hưng', N'Đăk Lăk', CAST(N'2001-04-20' AS Date), N'0822904906', N'123456789', N'Nam', N'Việt Nam')
INSERT [dbo].[CUSTOMER] ([IdCustomer], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Nationality]) VALUES (7, N'Trương hưng', N'Đăk Lăk', CAST(N'2001-04-20' AS Date), N'0822904906', N'123456789', N'Nam', N'Việt Nam')
INSERT [dbo].[CUSTOMER] ([IdCustomer], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Nationality]) VALUES (8, N'Trương hưng', N'Đăk Lăk', CAST(N'2001-04-20' AS Date), N'0822904906', N'123456789', N'Nam', N'Việt Nam')
INSERT [dbo].[CUSTOMER] ([IdCustomer], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Nationality]) VALUES (9, N'Trương hưng', N'Đăk Lăk', CAST(N'2001-04-20' AS Date), N'0822904906', N'123456789', N'Nam', N'Việt Nam')
INSERT [dbo].[CUSTOMER] ([IdCustomer], [Name], [Address], [BirthDay], [Phone], [CCCD], [Sex], [Nationality]) VALUES (10, N'Trương hưng', N'Đăk Lăk', CAST(N'2001-04-20' AS Date), N'0822904906', N'123456789', N'Nam', N'Việt Nam')
SET IDENTITY_INSERT [dbo].[CUSTOMER] OFF
GO

-- Thêm RESERVATION
SET IDENTITY_INSERT [dbo].[RESERVATION] ON 
INSERT [dbo].[RESERVATION] ([IdReservation], [IdEmployee], [IdCustomer], [Date], [Start_Date], [End_Date], [Amount]) VALUES (1, 1, 1, 5, CAST(N'2022-02-20T00:00:00.000' AS DateTime), CAST(N'2022-02-25T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[RESERVATION] OFF
GO





