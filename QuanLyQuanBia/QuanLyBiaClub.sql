USE [QuanLyBilliardsClub]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 7/9/2024 1:06:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](100) NOT NULL,
	[password] [nvarchar](100) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[role] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 7/9/2024 1:06:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[timeCheckIn] [datetime] NOT NULL,
	[timeCheckOut] [datetime] NULL,
	[idTableBia] [int] NOT NULL,
	[status] [int] NOT NULL,
	[totalPrice] [float] NULL,
 CONSTRAINT [PK__Bill__3213E83FD987061C] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillInfo]    Script Date: 7/9/2024 1:06:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idBill] [int] NOT NULL,
	[idWater] [int] NOT NULL,
	[quantity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TableBia]    Script Date: 7/9/2024 1:06:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableBia](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[status] [nvarchar](100) NOT NULL,
	[idCategory] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TableCategory]    Script Date: 7/9/2024 1:06:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableCategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[price] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Water]    Script Date: 7/9/2024 1:06:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Water](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[price] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([id], [username], [password], [name], [role]) VALUES (1, N'ronaldo', N'123', N'Messi', 1)
INSERT [dbo].[Account] ([id], [username], [password], [name], [role]) VALUES (2, N'quyendz03', N'1', N'Quyene', 1)
INSERT [dbo].[Account] ([id], [username], [password], [name], [role]) VALUES (5, N'hehe', N'1', N'kkaka', 1)
INSERT [dbo].[Account] ([id], [username], [password], [name], [role]) VALUES (6, N'hhi13', N'1212', N'quyen', 1)
INSERT [dbo].[Account] ([id], [username], [password], [name], [role]) VALUES (8, N'ahhi', N'1', N'123', 1)
INSERT [dbo].[Account] ([id], [username], [password], [name], [role]) VALUES (9, N'yasuo', N'messi', N'Ronaldo', 1)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (1, CAST(N'2024-07-04T00:00:00.000' AS DateTime), CAST(N'2024-07-07T21:16:22.733' AS DateTime), 1, 1, 100)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (2, CAST(N'2024-07-04T00:00:00.000' AS DateTime), CAST(N'2024-07-07T17:30:02.387' AS DateTime), 2, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (3, CAST(N'2024-07-04T22:34:00.000' AS DateTime), CAST(N'2024-07-07T21:27:22.400' AS DateTime), 3, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (4, CAST(N'2024-07-05T00:33:57.843' AS DateTime), CAST(N'2024-07-07T17:30:02.837' AS DateTime), 1, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (5, CAST(N'2024-07-05T16:29:37.660' AS DateTime), CAST(N'2024-07-07T17:35:44.113' AS DateTime), 4, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (6, CAST(N'2024-07-07T00:29:43.870' AS DateTime), CAST(N'2024-07-07T17:34:38.037' AS DateTime), 43, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (7, CAST(N'2024-07-07T00:32:20.597' AS DateTime), CAST(N'2024-07-07T17:30:01.837' AS DateTime), 6, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (8, CAST(N'2024-07-07T00:32:56.323' AS DateTime), CAST(N'2024-07-08T15:52:45.573' AS DateTime), 9, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (9, CAST(N'2024-07-07T00:33:45.667' AS DateTime), CAST(N'2024-07-07T17:29:28.333' AS DateTime), 5, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (10, CAST(N'2024-07-07T14:26:26.723' AS DateTime), CAST(N'2024-07-08T15:24:10.093' AS DateTime), 7, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (11, CAST(N'2024-07-07T15:19:41.513' AS DateTime), CAST(N'2024-07-07T17:35:10.410' AS DateTime), 31, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (12, CAST(N'2024-07-07T17:30:28.577' AS DateTime), CAST(N'2024-07-08T15:24:01.567' AS DateTime), 43, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (13, CAST(N'2024-07-07T17:31:11.083' AS DateTime), CAST(N'2024-07-07T21:22:24.853' AS DateTime), 30, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (14, CAST(N'2024-07-07T17:35:51.547' AS DateTime), CAST(N'2024-07-07T17:36:41.127' AS DateTime), 4, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (15, CAST(N'2024-07-07T21:18:04.623' AS DateTime), CAST(N'2024-07-08T15:24:01.567' AS DateTime), 43, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (16, CAST(N'2024-07-07T23:27:37.167' AS DateTime), CAST(N'2024-07-07T23:29:14.050' AS DateTime), 43, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (17, CAST(N'2024-07-08T01:02:00.570' AS DateTime), CAST(N'2024-07-08T15:24:01.567' AS DateTime), 9, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (18, CAST(N'2024-07-08T01:03:00.250' AS DateTime), CAST(N'2024-07-08T10:35:34.220' AS DateTime), 1, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (19, CAST(N'2024-07-08T01:24:39.073' AS DateTime), CAST(N'2024-07-08T15:24:07.110' AS DateTime), 43, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (20, CAST(N'2024-07-08T09:53:50.820' AS DateTime), CAST(N'2024-07-08T15:24:05.173' AS DateTime), 31, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (21, CAST(N'2024-07-08T09:53:58.043' AS DateTime), CAST(N'2024-07-08T15:24:01.567' AS DateTime), 5, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (22, CAST(N'2024-07-08T09:56:36.437' AS DateTime), CAST(N'2024-07-08T15:24:01.567' AS DateTime), 3, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (23, CAST(N'2024-07-08T09:56:55.213' AS DateTime), CAST(N'2024-07-08T10:35:37.490' AS DateTime), 2, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (24, CAST(N'2024-07-08T10:25:02.583' AS DateTime), CAST(N'2024-07-08T15:24:42.113' AS DateTime), 30, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (25, CAST(N'2024-07-08T10:29:30.093' AS DateTime), CAST(N'2024-07-08T15:24:19.210' AS DateTime), 28, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (26, CAST(N'2024-07-08T10:35:09.540' AS DateTime), CAST(N'2024-07-08T15:24:39.520' AS DateTime), 4, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (27, CAST(N'2024-07-08T10:35:29.147' AS DateTime), CAST(N'2024-07-08T15:24:36.013' AS DateTime), 3, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (28, CAST(N'2024-07-08T15:38:44.213' AS DateTime), CAST(N'2024-07-08T15:52:53.897' AS DateTime), 31, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (29, CAST(N'2024-07-08T15:46:30.337' AS DateTime), CAST(N'2024-07-08T15:47:18.033' AS DateTime), 1, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (30, CAST(N'2024-07-08T15:46:54.740' AS DateTime), CAST(N'2024-07-08T15:47:15.323' AS DateTime), 5, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (31, CAST(N'2024-07-08T15:52:08.200' AS DateTime), CAST(N'2024-07-08T15:52:41.747' AS DateTime), 4, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (32, CAST(N'2024-07-08T15:57:08.477' AS DateTime), CAST(N'2024-07-08T16:10:21.677' AS DateTime), 1, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (33, CAST(N'2024-07-08T16:10:18.820' AS DateTime), CAST(N'2024-07-08T16:46:04.537' AS DateTime), 3, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (34, CAST(N'2024-07-08T16:44:45.560' AS DateTime), CAST(N'2024-07-08T16:44:52.697' AS DateTime), 3, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (35, CAST(N'2024-07-08T16:45:13.453' AS DateTime), CAST(N'2024-07-08T16:45:34.380' AS DateTime), 3, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (36, CAST(N'2024-07-08T16:51:39.727' AS DateTime), CAST(N'2024-07-08T17:15:26.953' AS DateTime), 2, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (37, CAST(N'2024-07-08T16:51:56.513' AS DateTime), CAST(N'2024-07-08T16:55:47.383' AS DateTime), 2, 1, 101)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (38, CAST(N'2024-07-08T17:15:11.303' AS DateTime), CAST(N'2024-07-08T22:26:57.360' AS DateTime), 3, 1, 564.80634722222226)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (39, CAST(N'2024-07-08T17:16:59.953' AS DateTime), CAST(N'2024-07-08T22:09:36.133' AS DateTime), 2, 1, 215.06866666666667)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (40, CAST(N'2024-07-08T22:05:51.263' AS DateTime), CAST(N'2024-07-08T22:27:33.157' AS DateTime), 4, 1, 25919.605555555554)
INSERT [dbo].[Bill] ([id], [timeCheckIn], [timeCheckOut], [idTableBia], [status], [totalPrice]) VALUES (41, CAST(N'2024-07-09T00:52:36.743' AS DateTime), CAST(N'2024-07-09T00:53:54.960' AS DateTime), 6, 1, 38.30361666666667)
SET IDENTITY_INSERT [dbo].[Bill] OFF
GO
SET IDENTITY_INSERT [dbo].[BillInfo] ON 

INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (1, 1, 2, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (2, 2, 5, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (3, 3, 9, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (4, 1, 3, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (5, 1, 4, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (6, 1, 6, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (7, 5, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (8, 3, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (9, 1, 10, 10)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (10, 3, 10, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (11, 2, 1, 9)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (12, 2, 4, 9)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (13, 5, 4, 9)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (14, 5, 4, 9)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (15, 5, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (16, 2, 1, 7)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (17, 5, 1, 7)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (18, 2, 6, 7)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (19, 2, 6, 7)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (20, 1, 1, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (21, 6, 1, 7)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (22, 6, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (23, 6, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (24, 6, 1, 7)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (25, 6, 10, 10)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (26, 7, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (27, 7, 9, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (28, 8, 9, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (29, 9, 6, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (30, 5, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (31, 8, 1, 10)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (32, 8, 4, 5)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (34, 8, 4, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (35, 10, 1, 7)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (36, 8, 3, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (37, 8, 7, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (38, 8, 8, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (39, 8, 2, 8)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (40, 8, 2, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (42, 1, 8, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (43, 11, 8, 7)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (44, 11, 6, 5)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (45, 6, 6, 5)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (46, 1, 9, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (47, 1, 5, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (49, 8, 10, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (50, 6, 7, 25)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (51, 9, 1, 7)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (52, 4, 1, 5)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (53, 13, 1, 6)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (54, 14, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (55, 14, 4, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (56, 15, 5, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (57, 13, 5, 7)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (58, 16, 9, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (59, 16, 4, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (60, 8, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (61, 18, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (62, 18, 7, 5)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (63, 10, 7, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (64, 19, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (65, 20, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (66, 21, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (67, 22, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (68, 30, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (69, 31, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (70, 32, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (71, 33, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (72, 34, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (73, 34, 8, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (74, 35, 8, 8)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (75, 35, 3, 7)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (76, 36, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (77, 36, 7, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (78, 37, 9, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (79, 38, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (80, 38, 9, 5)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (81, 39, 1, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (82, 40, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (83, 38, 10, 10)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (84, 40, 10, 10)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (85, 40, 8, 10)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (86, 40, 4, 10)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (87, 40, 2, 10)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (88, 41, 7, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idWater], [quantity]) VALUES (89, 41, 8, 1)
SET IDENTITY_INSERT [dbo].[BillInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[TableBia] ON 

INSERT [dbo].[TableBia] ([id], [name], [status], [idCategory]) VALUES (1, N'Bàn 1', N'Trống', 1)
INSERT [dbo].[TableBia] ([id], [name], [status], [idCategory]) VALUES (2, N'Bàn 2', N'Trống', 1)
INSERT [dbo].[TableBia] ([id], [name], [status], [idCategory]) VALUES (3, N'Bàn 3', N'Trống', 2)
INSERT [dbo].[TableBia] ([id], [name], [status], [idCategory]) VALUES (4, N'Bàn 4', N'Trống', 5)
INSERT [dbo].[TableBia] ([id], [name], [status], [idCategory]) VALUES (5, N'Bàn 5', N'Trống', 2)
INSERT [dbo].[TableBia] ([id], [name], [status], [idCategory]) VALUES (6, N'Bàn 6', N'Trống', 3)
INSERT [dbo].[TableBia] ([id], [name], [status], [idCategory]) VALUES (7, N'Bàn 7', N'Trống', 1)
INSERT [dbo].[TableBia] ([id], [name], [status], [idCategory]) VALUES (9, N'Bàn 9', N'Trống', 3)
INSERT [dbo].[TableBia] ([id], [name], [status], [idCategory]) VALUES (28, N'Bàn 13', N'Trống', 4)
INSERT [dbo].[TableBia] ([id], [name], [status], [idCategory]) VALUES (30, N'Bàn 16', N'Trống', 3)
INSERT [dbo].[TableBia] ([id], [name], [status], [idCategory]) VALUES (31, N'Bàn 10', N'Trống', 1)
INSERT [dbo].[TableBia] ([id], [name], [status], [idCategory]) VALUES (43, N'Bàn 14', N'Trống', 4)
SET IDENTITY_INSERT [dbo].[TableBia] OFF
GO
SET IDENTITY_INSERT [dbo].[TableCategory] ON 

INSERT [dbo].[TableCategory] ([id], [name], [price]) VALUES (1, N'Bàn Pool', 40)
INSERT [dbo].[TableCategory] ([id], [name], [price]) VALUES (2, N'Bàn Carom ', 50)
INSERT [dbo].[TableCategory] ([id], [name], [price]) VALUES (3, N'Bàn Snooker', 60)
INSERT [dbo].[TableCategory] ([id], [name], [price]) VALUES (4, N'Bàn Proam ', 55)
INSERT [dbo].[TableCategory] ([id], [name], [price]) VALUES (5, N'Bàn Kingkong ', 70)
SET IDENTITY_INSERT [dbo].[TableCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[Water] ON 

INSERT [dbo].[Water] ([id], [name], [price]) VALUES (1, N'Nước lọc', 5)
INSERT [dbo].[Water] ([id], [name], [price]) VALUES (2, N'Sting đỏ', 10)
INSERT [dbo].[Water] ([id], [name], [price]) VALUES (3, N'Bò húc', 15)
INSERT [dbo].[Water] ([id], [name], [price]) VALUES (4, N'0 Độ', 10)
INSERT [dbo].[Water] ([id], [name], [price]) VALUES (5, N'C2', 10)
INSERT [dbo].[Water] ([id], [name], [price]) VALUES (6, N'Trà sữa', 25)
INSERT [dbo].[Water] ([id], [name], [price]) VALUES (7, N'Bạc xỉu', 22)
INSERT [dbo].[Water] ([id], [name], [price]) VALUES (8, N'Trà Cam1', 15)
INSERT [dbo].[Water] ([id], [name], [price]) VALUES (9, N'Sting vàng', 10)
INSERT [dbo].[Water] ([id], [name], [price]) VALUES (10, N'Trà đào cam xả', 25)
INSERT [dbo].[Water] ([id], [name], [price]) VALUES (22, N'Trà sữa 2', 25)
SET IDENTITY_INSERT [dbo].[Water] OFF
GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_Role]  DEFAULT ((1)) FOR [role]
GO
ALTER TABLE [dbo].[Bill] ADD  CONSTRAINT [DF__Bill__timeCheckI__534D60F1]  DEFAULT (getdate()) FOR [timeCheckIn]
GO
ALTER TABLE [dbo].[Bill] ADD  CONSTRAINT [DF__Bill__status__5441852A]  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[Bill] ADD  CONSTRAINT [DF__Bill__totalPrice__4D5F7D71]  DEFAULT ((0)) FOR [totalPrice]
GO
ALTER TABLE [dbo].[BillInfo] ADD  DEFAULT ((0)) FOR [quantity]
GO
ALTER TABLE [dbo].[TableBia] ADD  DEFAULT (N'Trống') FOR [status]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_TableBia] FOREIGN KEY([idTableBia])
REFERENCES [dbo].[TableBia] ([id])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_TableBia]
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD  CONSTRAINT [FK__BillInfo__idBill__5812160E] FOREIGN KEY([idBill])
REFERENCES [dbo].[Bill] ([id])
GO
ALTER TABLE [dbo].[BillInfo] CHECK CONSTRAINT [FK__BillInfo__idBill__5812160E]
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([idWater])
REFERENCES [dbo].[Water] ([id])
GO
ALTER TABLE [dbo].[TableBia]  WITH CHECK ADD FOREIGN KEY([idCategory])
REFERENCES [dbo].[TableCategory] ([id])
GO
