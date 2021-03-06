USE [HiTechDB]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 12/14/2020 7:23:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[AuthorId] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuthorsBooks]    Script Date: 12/14/2020 7:23:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthorsBooks](
	[AuthorId] [int] NOT NULL,
	[ISBN] [nvarchar](15) NOT NULL,
	[YearPublished] [nvarchar](4) NOT NULL,
	[Edition] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_AuthorsBooks] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC,
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 12/14/2020 7:23:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[ISBN] [nvarchar](15) NOT NULL,
	[BookTitle] [nvarchar](100) NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[QOH] [int] NOT NULL,
	[PublisherId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 12/14/2020 7:23:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 12/14/2020 7:23:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] NOT NULL,
	[CustomerName] [nvarchar](50) NOT NULL,
	[StreetName] [nvarchar](50) NOT NULL,
	[Province] [nvarchar](30) NOT NULL,
	[City] [nvarchar](30) NOT NULL,
	[PostalCode] [nvarchar](10) NOT NULL,
	[PhoneNumber] [nvarchar](15) NOT NULL,
	[ContactName] [nvarchar](30) NOT NULL,
	[ContactEmail] [nvarchar](100) NOT NULL,
	[CreditLimit] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 12/14/2020 7:23:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[PhoneNumber] [nvarchar](15) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[JobId] [int] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jobs]    Script Date: 12/14/2020 7:23:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jobs](
	[JobId] [int] NOT NULL,
	[JobTitle] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Jobs] PRIMARY KEY CLUSTERED 
(
	[JobId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderLines]    Script Date: 12/14/2020 7:23:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderLines](
	[OrderId] [int] NOT NULL,
	[ISBN] [nvarchar](15) NOT NULL,
	[QuantityOrdered] [int] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 12/14/2020 7:23:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] NOT NULL,
	[OrderDate] [date] NOT NULL,
	[OrderType] [nvarchar](20) NOT NULL,
	[RequiredDate] [date] NOT NULL,
	[ShippingDate] [date] NOT NULL,
	[OrderStatus] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publishers]    Script Date: 12/14/2020 7:23:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publishers](
	[PublisherId] [int] NOT NULL,
	[PublisherName] [nvarchar](50) NOT NULL,
	[WebAddress] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Publishers] PRIMARY KEY CLUSTERED 
(
	[PublisherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Statuses]    Script Date: 12/14/2020 7:23:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Statuses](
	[Id] [int] NOT NULL,
	[Description] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Statuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAccounts]    Script Date: 12/14/2020 7:23:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccounts](
	[UserId] [int] NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[EmployeeId] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Authors] ([AuthorId], [FirstName], [LastName], [Email]) VALUES (111, N'Matthes', N'Eric', N'ericMatthes@gmail.com')
INSERT [dbo].[Authors] ([AuthorId], [FirstName], [LastName], [Email]) VALUES (222, N'Daniel', N'Zingaro', N'danielZingaro@gmail.com')
INSERT [dbo].[Authors] ([AuthorId], [FirstName], [LastName], [Email]) VALUES (333, N'Matthes', N'Eric', N'ericMatthes@gmail.com')
INSERT [dbo].[Authors] ([AuthorId], [FirstName], [LastName], [Email]) VALUES (444, N'Emily', N'Collins', N'emilyCollins@gmail.com')
INSERT [dbo].[Authors] ([AuthorId], [FirstName], [LastName], [Email]) VALUES (555, N'Alice', N'Coorey', N'aliceCoorey@gmail.com')
GO
INSERT [dbo].[AuthorsBooks] ([AuthorId], [ISBN], [YearPublished], [Edition]) VALUES (111, N'1212121212121', N'2019', N'6th Edition')
INSERT [dbo].[AuthorsBooks] ([AuthorId], [ISBN], [YearPublished], [Edition]) VALUES (111, N'9781509307760', N'2010', N'2nd Eddition')
INSERT [dbo].[AuthorsBooks] ([AuthorId], [ISBN], [YearPublished], [Edition]) VALUES (111, N'9781587052026', N'2012', N'9th Eddition')
INSERT [dbo].[AuthorsBooks] ([AuthorId], [ISBN], [YearPublished], [Edition]) VALUES (222, N'9781509307760', N'2010', N'2nd Eddition')
INSERT [dbo].[AuthorsBooks] ([AuthorId], [ISBN], [YearPublished], [Edition]) VALUES (222, N'9781593276034', N'2015', N'1st Eddition')
INSERT [dbo].[AuthorsBooks] ([AuthorId], [ISBN], [YearPublished], [Edition]) VALUES (222, N'9781718500808', N'2020', N'3rd Edition')
INSERT [dbo].[AuthorsBooks] ([AuthorId], [ISBN], [YearPublished], [Edition]) VALUES (333, N'9781593276034', N'2015', N'1st Eddition')
INSERT [dbo].[AuthorsBooks] ([AuthorId], [ISBN], [YearPublished], [Edition]) VALUES (333, N'9781718500808', N'2020', N'3rd Eddition')
INSERT [dbo].[AuthorsBooks] ([AuthorId], [ISBN], [YearPublished], [Edition]) VALUES (444, N'1212121212123', N'2011', N'5th Edition')
INSERT [dbo].[AuthorsBooks] ([AuthorId], [ISBN], [YearPublished], [Edition]) VALUES (555, N'1212121212121', N'2019', N'6th Edition')
GO
INSERT [dbo].[Books] ([ISBN], [BookTitle], [UnitPrice], [QOH], [PublisherId], [CategoryId], [Status]) VALUES (N'1212121212121', N'Introduction To Networking', CAST(43.25 AS Decimal(18, 2)), 1000, 4, 22, 8)
INSERT [dbo].[Books] ([ISBN], [BookTitle], [UnitPrice], [QOH], [PublisherId], [CategoryId], [Status]) VALUES (N'1212121212123', N'C For Beginners', CAST(43.25 AS Decimal(18, 2)), 1000, 3, 11, 10)
INSERT [dbo].[Books] ([ISBN], [BookTitle], [UnitPrice], [QOH], [PublisherId], [CategoryId], [Status]) VALUES (N'9781509307760', N'Microsoft Visual C# Step by Step', CAST(54.99 AS Decimal(18, 2)), 5000, 5, 11, 11)
INSERT [dbo].[Books] ([ISBN], [BookTitle], [UnitPrice], [QOH], [PublisherId], [CategoryId], [Status]) VALUES (N'9781587052026', N'Routing TCP/IP', CAST(72.49 AS Decimal(18, 2)), 0, 2, 22, 9)
INSERT [dbo].[Books] ([ISBN], [BookTitle], [UnitPrice], [QOH], [PublisherId], [CategoryId], [Status]) VALUES (N'9781593276034', N'Python Crash Course', CAST(34.25 AS Decimal(18, 2)), 7000, 1, 11, 8)
INSERT [dbo].[Books] ([ISBN], [BookTitle], [UnitPrice], [QOH], [PublisherId], [CategoryId], [Status]) VALUES (N'9781718500808', N'Algorithmic Thinking: A Problem-Based Introduction', CAST(49.95 AS Decimal(18, 2)), 9100, 1, 33, 10)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (11, N'Programming')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (22, N'Networking')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (33, N'Algorithm')
GO
INSERT [dbo].[Customers] ([CustomerId], [CustomerName], [StreetName], [Province], [City], [PostalCode], [PhoneNumber], [ContactName], [ContactEmail], [CreditLimit], [Status]) VALUES (111111, N'LaSalle College', N'Saint Catherine', N'Quebec', N'Montreal', N'H3H 2T3', N'(514) 111-1111', N'Steven Tyler', N'lasalle@lasalle.edu', 5000, 5)
INSERT [dbo].[Customers] ([CustomerId], [CustomerName], [StreetName], [Province], [City], [PostalCode], [PhoneNumber], [ContactName], [ContactEmail], [CreditLimit], [Status]) VALUES (222222, N'Concordia University', N'Maisonneuve', N'Quebec', N'Montreal', N'H3G 1M8', N'(514)222-2222', N'George Williams', N'concordia@concordia.edu', 7000, 5)
INSERT [dbo].[Customers] ([CustomerId], [CustomerName], [StreetName], [Province], [City], [PostalCode], [PhoneNumber], [ContactName], [ContactEmail], [CreditLimit], [Status]) VALUES (333333, N'McGill University', N'Sherbrooke', N'Quebec', N'Montreal', N'H3A 0G4', N'(514)333-3333', N'James Smith', N'mcgill@mcgill.edu', 7000, 6)
INSERT [dbo].[Customers] ([CustomerId], [CustomerName], [StreetName], [Province], [City], [PostalCode], [PhoneNumber], [ContactName], [ContactEmail], [CreditLimit], [Status]) VALUES (444444, N'Dawson College', N'Sherbrooke', N'Quebec', N'Montreal', N'H3Z 1A4', N'(514) 444-4444', N'Sandra Kim', N'dawson@dawson.edu', 5000, 5)
GO
INSERT [dbo].[Employees] ([EmployeeId], [LastName], [FirstName], [PhoneNumber], [Email], [JobId]) VALUES (1111, N'Brown', N'Henry', N'(514) 111-1111', N'henryBrown@yahoo.com', 11111)
INSERT [dbo].[Employees] ([EmployeeId], [LastName], [FirstName], [PhoneNumber], [Email], [JobId]) VALUES (2222, N'Moore', N'Thomas', N'(514)-222-2222', N'thomasMoore@gmail.com', 22222)
INSERT [dbo].[Employees] ([EmployeeId], [LastName], [FirstName], [PhoneNumber], [Email], [JobId]) VALUES (3333, N'Wang', N'Peter', N'(514)-333-3333', N'peterWang@gmail.com', 33333)
INSERT [dbo].[Employees] ([EmployeeId], [LastName], [FirstName], [PhoneNumber], [Email], [JobId]) VALUES (4444, N'Brown', N'Mary', N'(514)-444-4444', N'maryBrown@gmail.com', 44444)
INSERT [dbo].[Employees] ([EmployeeId], [LastName], [FirstName], [PhoneNumber], [Email], [JobId]) VALUES (5555, N'Bouchard', N'Jennifer', N'(514)-555-5555', N'jenniferBouchard@gmail', 44444)
INSERT [dbo].[Employees] ([EmployeeId], [LastName], [FirstName], [PhoneNumber], [Email], [JobId]) VALUES (6666, N'Nguyen', N'Kim Hoa', N'(514)-666-6666', N'kimNguyen@gmail.com', 55555)
GO
INSERT [dbo].[Jobs] ([JobId], [JobTitle]) VALUES (11111, N'MIS Manager')
INSERT [dbo].[Jobs] ([JobId], [JobTitle]) VALUES (22222, N'Sales Manager')
INSERT [dbo].[Jobs] ([JobId], [JobTitle]) VALUES (33333, N'Inventory Controller')
INSERT [dbo].[Jobs] ([JobId], [JobTitle]) VALUES (44444, N'Order Clerks')
INSERT [dbo].[Jobs] ([JobId], [JobTitle]) VALUES (55555, N'Accountant')
GO
INSERT [dbo].[OrderLines] ([OrderId], [ISBN], [QuantityOrdered]) VALUES (1111111, N'9781509307760', 700)
INSERT [dbo].[OrderLines] ([OrderId], [ISBN], [QuantityOrdered]) VALUES (1111111, N'9781593276034', 100)
INSERT [dbo].[OrderLines] ([OrderId], [ISBN], [QuantityOrdered]) VALUES (1111112, N'9781587052026', 200)
INSERT [dbo].[OrderLines] ([OrderId], [ISBN], [QuantityOrdered]) VALUES (1111113, N'9781509307760', 150)
INSERT [dbo].[OrderLines] ([OrderId], [ISBN], [QuantityOrdered]) VALUES (1111113, N'9781718500808', 350)
INSERT [dbo].[OrderLines] ([OrderId], [ISBN], [QuantityOrdered]) VALUES (1111114, N'9781587052026', 50)
INSERT [dbo].[OrderLines] ([OrderId], [ISBN], [QuantityOrdered]) VALUES (1111115, N'9781718500808', 400)
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [OrderType], [RequiredDate], [ShippingDate], [OrderStatus], [CustomerId], [EmployeeId]) VALUES (1111111, CAST(N'2019-12-03' AS Date), N'By Phone', CAST(N'2020-01-03' AS Date), CAST(N'2020-01-01' AS Date), 3, 222222, 5555)
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [OrderType], [RequiredDate], [ShippingDate], [OrderStatus], [CustomerId], [EmployeeId]) VALUES (1111112, CAST(N'2020-12-12' AS Date), N'By Email', CAST(N'2021-12-12' AS Date), CAST(N'2021-12-10' AS Date), 7, 111111, 4444)
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [OrderType], [RequiredDate], [ShippingDate], [OrderStatus], [CustomerId], [EmployeeId]) VALUES (1111113, CAST(N'2020-12-12' AS Date), N'By Phone', CAST(N'2020-12-18' AS Date), CAST(N'2020-12-15' AS Date), 1, 222222, 5555)
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [OrderType], [RequiredDate], [ShippingDate], [OrderStatus], [CustomerId], [EmployeeId]) VALUES (1111114, CAST(N'2019-12-12' AS Date), N'By Email', CAST(N'2020-12-04' AS Date), CAST(N'2020-10-04' AS Date), 3, 444444, 5555)
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [OrderType], [RequiredDate], [ShippingDate], [OrderStatus], [CustomerId], [EmployeeId]) VALUES (1111115, CAST(N'2020-12-12' AS Date), N'By Phone', CAST(N'2021-12-12' AS Date), CAST(N'2021-10-12' AS Date), 2, 333333, 4444)
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [OrderType], [RequiredDate], [ShippingDate], [OrderStatus], [CustomerId], [EmployeeId]) VALUES (1111116, CAST(N'2020-12-14' AS Date), N'By Phone', CAST(N'2020-12-16' AS Date), CAST(N'2020-12-15' AS Date), 7, 111111, 4444)
GO
INSERT [dbo].[Publishers] ([PublisherId], [PublisherName], [WebAddress]) VALUES (1, N'No Starch Press', N'https://nostarch.com/')
INSERT [dbo].[Publishers] ([PublisherId], [PublisherName], [WebAddress]) VALUES (2, N'Cisco Press', N'https://www.ciscopress.com/')
INSERT [dbo].[Publishers] ([PublisherId], [PublisherName], [WebAddress]) VALUES (3, N'SciTech Publishing Inc', N'https://publishersarchive.com/')
INSERT [dbo].[Publishers] ([PublisherId], [PublisherName], [WebAddress]) VALUES (4, N'Wrox Press', N'https://publishersarchive.com/')
INSERT [dbo].[Publishers] ([PublisherId], [PublisherName], [WebAddress]) VALUES (5, N'Microsoft Press', N'https://www.microsoftpressstore.com/')
GO
INSERT [dbo].[Statuses] ([Id], [Description]) VALUES (1, N'In Process')
INSERT [dbo].[Statuses] ([Id], [Description]) VALUES (2, N'Pending')
INSERT [dbo].[Statuses] ([Id], [Description]) VALUES (3, N'Completed')
INSERT [dbo].[Statuses] ([Id], [Description]) VALUES (4, N'Shipped')
INSERT [dbo].[Statuses] ([Id], [Description]) VALUES (5, N'Active')
INSERT [dbo].[Statuses] ([Id], [Description]) VALUES (6, N'Inactive')
INSERT [dbo].[Statuses] ([Id], [Description]) VALUES (7, N'Cancelled')
INSERT [dbo].[Statuses] ([Id], [Description]) VALUES (8, N'In Stock')
INSERT [dbo].[Statuses] ([Id], [Description]) VALUES (9, N'Out of Stock')
INSERT [dbo].[Statuses] ([Id], [Description]) VALUES (10, N'New Arrival')
INSERT [dbo].[Statuses] ([Id], [Description]) VALUES (11, N'Bestseller')
GO
INSERT [dbo].[UserAccounts] ([UserId], [Password], [EmployeeId]) VALUES (1111, N'henrybrown', 1111)
INSERT [dbo].[UserAccounts] ([UserId], [Password], [EmployeeId]) VALUES (2222, N'thomasmoore', 2222)
INSERT [dbo].[UserAccounts] ([UserId], [Password], [EmployeeId]) VALUES (3333, N'peterwang', 3333)
INSERT [dbo].[UserAccounts] ([UserId], [Password], [EmployeeId]) VALUES (4444, N'marybrown', 4444)
INSERT [dbo].[UserAccounts] ([UserId], [Password], [EmployeeId]) VALUES (5555, N'jenniferbouchard', 5555)
GO
ALTER TABLE [dbo].[AuthorsBooks]  WITH CHECK ADD  CONSTRAINT [FK_AuthorsBooks_Authors] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([AuthorId])
GO
ALTER TABLE [dbo].[AuthorsBooks] CHECK CONSTRAINT [FK_AuthorsBooks_Authors]
GO
ALTER TABLE [dbo].[AuthorsBooks]  WITH CHECK ADD  CONSTRAINT [FK_AuthorsBooks_Books] FOREIGN KEY([ISBN])
REFERENCES [dbo].[Books] ([ISBN])
GO
ALTER TABLE [dbo].[AuthorsBooks] CHECK CONSTRAINT [FK_AuthorsBooks_Books]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Categories]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Publishers] FOREIGN KEY([PublisherId])
REFERENCES [dbo].[Publishers] ([PublisherId])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Publishers]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Statuses] FOREIGN KEY([Status])
REFERENCES [dbo].[Statuses] ([Id])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Statuses]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Statuses] FOREIGN KEY([Status])
REFERENCES [dbo].[Statuses] ([Id])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_Statuses]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Jobs] FOREIGN KEY([JobId])
REFERENCES [dbo].[Jobs] ([JobId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Jobs]
GO
ALTER TABLE [dbo].[OrderLines]  WITH CHECK ADD  CONSTRAINT [FK_OrderLines_Books] FOREIGN KEY([ISBN])
REFERENCES [dbo].[Books] ([ISBN])
GO
ALTER TABLE [dbo].[OrderLines] CHECK CONSTRAINT [FK_OrderLines_Books]
GO
ALTER TABLE [dbo].[OrderLines]  WITH CHECK ADD  CONSTRAINT [FK_OrderLines_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[OrderLines] CHECK CONSTRAINT [FK_OrderLines_Orders]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Employees]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Statuses] FOREIGN KEY([OrderStatus])
REFERENCES [dbo].[Statuses] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Statuses]
GO
ALTER TABLE [dbo].[UserAccounts]  WITH CHECK ADD  CONSTRAINT [FK_Users_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[UserAccounts] CHECK CONSTRAINT [FK_Users_Employees]
GO
USE [master]
GO
ALTER DATABASE [HiTechDB] SET  READ_WRITE 
GO
