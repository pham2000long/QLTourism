USE [master]
GO
/****** Object:  Database [tourism]    Script Date: 8/28/2021 9:59:25 PM ******/
CREATE DATABASE [tourism]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'tourism', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\tourism.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'tourism_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\tourism_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [tourism] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [tourism].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [tourism] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [tourism] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [tourism] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [tourism] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [tourism] SET ARITHABORT OFF 
GO
ALTER DATABASE [tourism] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [tourism] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [tourism] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [tourism] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [tourism] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [tourism] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [tourism] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [tourism] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [tourism] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [tourism] SET  DISABLE_BROKER 
GO
ALTER DATABASE [tourism] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [tourism] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [tourism] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [tourism] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [tourism] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [tourism] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [tourism] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [tourism] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [tourism] SET  MULTI_USER 
GO
ALTER DATABASE [tourism] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [tourism] SET DB_CHAINING OFF 
GO
ALTER DATABASE [tourism] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [tourism] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [tourism] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [tourism] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [tourism] SET QUERY_STORE = OFF
GO
USE [tourism]
GO
/****** Object:  Table [dbo].[BookingDetails]    Script Date: 8/28/2021 9:59:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingDetails](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Price] [int] NULL,
	[bookingId] [int] NULL,
	[packageId] [int] NULL,
	[bookingInfor] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 8/28/2021 9:59:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[bookingDate] [datetime] NULL,
	[bookingNo] [nvarchar](50) NULL,
	[customerId] [int] NULL,
	[country] [nvarchar](50) NULL,
	[city] [nvarchar](50) NULL,
	[address] [nvarchar](255) NULL,
	[customerNote] [nvarchar](255) NULL,
 CONSTRAINT [PK__Bookings__3213E83FCAE2C97A] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 8/28/2021 9:59:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[parentId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 8/28/2021 9:59:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](100) NULL,
	[password] [varchar](255) NULL,
	[name] [nvarchar](255) NULL,
	[email] [varchar](255) NULL,
	[phone] [varchar](20) NULL,
	[gender] [bit] NULL,
	[city] [nvarchar](50) NOT NULL,
	[country] [nvarchar](50) NULL,
	[avatar] [varchar](255) NULL,
	[birthday] [date] NULL,
	[address] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers_Rewards]    Script Date: 8/28/2021 9:59:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers_Rewards](
	[customerId] [int] NOT NULL,
	[rewardId] [int] NOT NULL,
	[rwdNumber] [nvarchar](25) NOT NULL,
 CONSTRAINT [Customers_Rewards_PK] PRIMARY KEY NONCLUSTERED 
(
	[customerId] ASC,
	[rewardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Media]    Script Date: 8/28/2021 9:59:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Media](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [int] NOT NULL,
	[path] [varchar](255) NULL,
	[packageId] [int] NOT NULL,
 CONSTRAINT [PK_Media] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 8/28/2021 9:59:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[id] [int] NOT NULL,
	[title] [nvarchar](255) NULL,
	[date] [date] NULL,
	[summary] [nvarchar](255) NULL,
	[detail] [ntext] NULL,
	[categoryId] [int] NOT NULL,
	[thumbail] [varchar](255) NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Packages]    Script Date: 8/28/2021 9:59:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Packages](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pkgName] [nvarchar](255) NOT NULL,
	[pkgStartDate] [date] NULL,
	[pkgTimePeriod] [nvarchar](255) NULL,
	[pkgStartPlace] [nvarchar](255) NULL,
	[pkgEndPlace] [nvarchar](255) NULL,
	[pkgDesc] [ntext] NULL,
	[pkgRules] [nvarchar](255) NULL,
	[pkgTransporter] [nvarchar](255) NULL,
	[pkgBasePrice] [int] NOT NULL,
	[pkgCondition] [nvarchar](255) NULL,
	[pkgSlot] [int] NULL,
	[active] [int] NULL,
	[categoryId] [int] NULL,
	[thumbail] [varchar](255) NULL,
 CONSTRAINT [PK__Packages__3213E83F5918DF9B] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prices]    Script Date: 8/28/2021 9:59:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prices](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](255) NULL,
	[price] [int] NULL,
	[packageId] [int] NULL,
 CONSTRAINT [PK_Prices] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Programs]    Script Date: 8/28/2021 9:59:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Programs](
	[id] [int] NOT NULL,
	[title] [nvarchar](255) NULL,
	[summary] [nvarchar](255) NULL,
	[detail] [nvarchar](255) NULL,
	[packageId] [int] NULL,
 CONSTRAINT [PK_Programs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rewards]    Script Date: 8/28/2021 9:59:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rewards](
	[id] [int] NOT NULL,
	[rwdName] [nvarchar](255) NULL,
	[rwdDesc] [nvarchar](255) NULL,
 CONSTRAINT [PK_Rewards] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 8/28/2021 9:59:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sliders]    Script Date: 8/28/2021 9:59:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sliders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[imagePath] [varchar](255) NULL,
	[urlPath] [varchar](255) NULL,
 CONSTRAINT [PK_Sliders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TripTypes]    Script Date: 8/28/2021 9:59:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TripTypes](
	[id] [nvarchar](1) NOT NULL,
	[ttName] [nvarchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 8/28/2021 9:59:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](255) NOT NULL,
	[name] [nvarchar](255) NULL,
	[email] [varchar](255) NULL,
	[phone] [varchar](20) NULL,
	[gender] [bit] NULL,
	[avatar] [varchar](255) NULL,
	[birthday] [date] NULL,
	[address] [nvarchar](255) NULL,
	[roleId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categories] ADD  DEFAULT ((0)) FOR [parentId]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [roleId]
GO
ALTER TABLE [dbo].[BookingDetails]  WITH CHECK ADD  CONSTRAINT [FK_BookingDetails_Bookings] FOREIGN KEY([bookingId])
REFERENCES [dbo].[Bookings] ([id])
GO
ALTER TABLE [dbo].[BookingDetails] CHECK CONSTRAINT [FK_BookingDetails_Bookings]
GO
ALTER TABLE [dbo].[BookingDetails]  WITH CHECK ADD  CONSTRAINT [FK_BookingDetails_Packages] FOREIGN KEY([packageId])
REFERENCES [dbo].[Packages] ([id])
GO
ALTER TABLE [dbo].[BookingDetails] CHECK CONSTRAINT [FK_BookingDetails_Packages]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Customers] FOREIGN KEY([customerId])
REFERENCES [dbo].[Customers] ([id])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Customers]
GO
ALTER TABLE [dbo].[Customers_Rewards]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Rewards_Customers] FOREIGN KEY([customerId])
REFERENCES [dbo].[Customers] ([id])
GO
ALTER TABLE [dbo].[Customers_Rewards] CHECK CONSTRAINT [FK_Customers_Rewards_Customers]
GO
ALTER TABLE [dbo].[Customers_Rewards]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Rewards_Rewards] FOREIGN KEY([rewardId])
REFERENCES [dbo].[Rewards] ([id])
GO
ALTER TABLE [dbo].[Customers_Rewards] CHECK CONSTRAINT [FK_Customers_Rewards_Rewards]
GO
ALTER TABLE [dbo].[Media]  WITH CHECK ADD  CONSTRAINT [FK_Media_Packages] FOREIGN KEY([packageId])
REFERENCES [dbo].[Packages] ([id])
GO
ALTER TABLE [dbo].[Media] CHECK CONSTRAINT [FK_Media_Packages]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_Categories] FOREIGN KEY([categoryId])
REFERENCES [dbo].[Categories] ([id])
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_Categories]
GO
ALTER TABLE [dbo].[Packages]  WITH CHECK ADD  CONSTRAINT [FK_Packages_Categories] FOREIGN KEY([categoryId])
REFERENCES [dbo].[Categories] ([id])
GO
ALTER TABLE [dbo].[Packages] CHECK CONSTRAINT [FK_Packages_Categories]
GO
ALTER TABLE [dbo].[Prices]  WITH CHECK ADD  CONSTRAINT [FK_Prices_Packages] FOREIGN KEY([packageId])
REFERENCES [dbo].[Packages] ([id])
GO
ALTER TABLE [dbo].[Prices] CHECK CONSTRAINT [FK_Prices_Packages]
GO
ALTER TABLE [dbo].[Programs]  WITH CHECK ADD  CONSTRAINT [FK_Programs_Packages] FOREIGN KEY([packageId])
REFERENCES [dbo].[Packages] ([id])
GO
ALTER TABLE [dbo].[Programs] CHECK CONSTRAINT [FK_Programs_Packages]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([roleId])
REFERENCES [dbo].[Roles] ([id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
USE [master]
GO
ALTER DATABASE [tourism] SET  READ_WRITE 
GO
