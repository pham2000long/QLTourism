USE [master]
GO
/****** Object:  Database [tourism]    Script Date: 8/3/2021 2:51:44 AM ******/
CREATE DATABASE [tourism]
go
--ALTER DATABASE [tourism] SET COMPATIBILITY_LEVEL = 150
--GO
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
EXEC sys.sp_db_vardecimal_storage_format N'tourism', N'ON'
GO
ALTER DATABASE [tourism] SET QUERY_STORE = OFF
GO
USE [tourism]
GO
/****** Object:  Table [dbo].[BookingDetails]    Script Date: 8/3/2021 2:51:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingDetails](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[itineraryNo] [float] NULL,
	[tripStart] [datetime] NULL,
	[tripEnd] [datetime] NULL,
	[description] [nvarchar](255) NULL,
	[destination] [nvarchar](255) NULL,
	[Price] [money] NULL,
	[customerNote] [nchar](10) NULL,
	[bookingId] [int] NULL,
 CONSTRAINT [PK__BookingD__3213E83F15BD5600] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 8/3/2021 2:51:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[bookingDate] [datetime] NULL,
	[bookingNo] [nvarchar](50) NULL,
	[travelerCount] [float] NULL,
	[customerId] [int] NULL,
	[tripTypeId] [nvarchar](1) NULL,
	[packageId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 8/3/2021 2:51:44 AM ******/
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
/****** Object:  Table [dbo].[Customers]    Script Date: 8/3/2021 2:51:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[id] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[Customers_Rewards]    Script Date: 8/3/2021 2:51:44 AM ******/
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
/****** Object:  Table [dbo].[Media]    Script Date: 8/3/2021 2:51:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Media](
	[id] [int] NOT NULL,
	[type] [int] NOT NULL,
	[path] [varchar](255) NULL,
	[packageId] [int] NOT NULL,
 CONSTRAINT [PK_Media] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Memberships]    Script Date: 8/3/2021 2:51:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Memberships](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NULL,
	[email] [varchar](255) NULL,
	[phone] [varchar](20) NULL,
	[gender] [bit] NULL,
	[avatar] [varchar](255) NULL,
	[birthday] [date] NULL,
	[address] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 8/3/2021 2:51:44 AM ******/
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
/****** Object:  Table [dbo].[Packages]    Script Date: 8/3/2021 2:51:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Packages](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pkgName] [nvarchar](50) NOT NULL,
	[pkgStartDate] [datetime] NULL,
	[pkgTimePeriod] [nchar](10) NULL,
	[pkgStartPlace] [nchar](10) NULL,
	[pkgEndPlace] [nchar](10) NULL,
	[pkgDesc] [nvarchar](50) NULL,
	[pkgRules] [nchar](10) NULL,
	[pkgTransporter] [nchar](10) NULL,
	[pkgBasePrice] [money] NOT NULL,
	[pkgCondition] [nchar](10) NULL,
	[pkgSlot] [nchar](10) NULL,
	[active] [nchar](10) NULL,
	[categoryId] [int] NULL,
 CONSTRAINT [PK__Packages__3213E83F5918DF9B] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prices]    Script Date: 8/3/2021 2:51:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prices](
	[id] [int] NOT NULL,
	[title] [nvarchar](255) NULL,
	[price] [money] NULL,
	[packageId] [int] NULL,
 CONSTRAINT [PK_Prices] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Programs]    Script Date: 8/3/2021 2:51:44 AM ******/
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
/****** Object:  Table [dbo].[Rewards]    Script Date: 8/3/2021 2:51:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rewards](
	[id] [int] NOT NULL,
	[rwdName] [nvarchar](50) NULL,
	[rwdDesc] [nvarchar](50) NULL,
 CONSTRAINT [PK_Rewards] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 8/3/2021 2:51:44 AM ******/
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
/****** Object:  Table [dbo].[TripTypes]    Script Date: 8/3/2021 2:51:44 AM ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 8/3/2021 2:51:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](255) NULL,
	[customerId] [int] NULL,
	[membershipId] [int] NULL,
	[roleId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categories] ADD  DEFAULT ((0)) FOR [parentId]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (NULL) FOR [customerId]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (NULL) FOR [membershipId]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [roleId]
GO
ALTER TABLE [dbo].[BookingDetails]  WITH CHECK ADD  CONSTRAINT [FK_BookingDetails_Bookings] FOREIGN KEY([bookingId])
REFERENCES [dbo].[Bookings] ([id])
GO
ALTER TABLE [dbo].[BookingDetails] CHECK CONSTRAINT [FK_BookingDetails_Bookings]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Customers] FOREIGN KEY([customerId])
REFERENCES [dbo].[Customers] ([id])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Customers]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Packages] FOREIGN KEY([packageId])
REFERENCES [dbo].[Packages] ([id])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Packages]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_TripTypes] FOREIGN KEY([tripTypeId])
REFERENCES [dbo].[TripTypes] ([id])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_TripTypes]
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
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Customers] FOREIGN KEY([customerId])
REFERENCES [dbo].[Customers] ([id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Customers]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Memberships] FOREIGN KEY([membershipId])
REFERENCES [dbo].[Memberships] ([id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Memberships]
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
