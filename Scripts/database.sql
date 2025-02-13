USE [master]
GO
/****** Object:  Database [ispp1113_2]    Script Date: 08.02.2025 12:53:17 ******/
CREATE DATABASE [ispp1113_2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ispp1113_2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ispp1113_2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'ispp1113_2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ispp1113_2_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ispp1113_2] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ispp1113_2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ispp1113_2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ispp1113_2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ispp1113_2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ispp1113_2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ispp1113_2] SET ARITHABORT OFF 
GO
ALTER DATABASE [ispp1113_2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ispp1113_2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ispp1113_2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ispp1113_2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ispp1113_2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ispp1113_2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ispp1113_2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ispp1113_2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ispp1113_2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ispp1113_2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ispp1113_2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ispp1113_2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ispp1113_2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ispp1113_2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ispp1113_2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ispp1113_2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ispp1113_2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ispp1113_2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ispp1113_2] SET  MULTI_USER 
GO
ALTER DATABASE [ispp1113_2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ispp1113_2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ispp1113_2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ispp1113_2] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ispp1113_2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ispp1113_2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ispp1113_2', N'ON'
GO
ALTER DATABASE [ispp1113_2] SET QUERY_STORE = ON
GO
ALTER DATABASE [ispp1113_2] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ispp1113_2]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 08.02.2025 12:53:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 08.02.2025 12:53:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materials]    Script Date: 08.02.2025 12:53:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materials](
	[Id] [int] NOT NULL,
	[Title] [nvarchar](20) NOT NULL,
	[Percent] [decimal](4, 2) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PartenersTypes]    Script Date: 08.02.2025 12:53:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartenersTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_PartenersTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Partners]    Script Date: 08.02.2025 12:53:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partners](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Director] [nvarchar](200) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Phone] [char](10) NOT NULL,
	[Address] [nvarchar](500) NOT NULL,
	[INN] [char](12) NOT NULL,
	[Rating] [smallint] NOT NULL,
	[Logo] [varbinary](max) NULL,
 CONSTRAINT [PK_Partners] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PartnersProducts]    Script Date: 08.02.2025 12:53:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartnersProducts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[PartnerId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[SaleDate] [date] NOT NULL,
 CONSTRAINT [PK_PartnersProducts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 08.02.2025 12:53:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductTypeId] [int] NOT NULL,
	[Title] [nvarchar](60) NOT NULL,
	[Articul] [varchar](50) NOT NULL,
	[MinPrice] [decimal](7, 2) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductType]    Script Date: 08.02.2025 12:53:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](20) NOT NULL,
	[Coefficient] [decimal](4, 2) NOT NULL,
 CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250208081508_FirstMigration', N'9.0.1')
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([Id], [Login], [Password]) VALUES (1, N'admin', N'admin')
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
INSERT [dbo].[Materials] ([Id], [Title], [Percent]) VALUES (1, N'Тип материала 1', CAST(0.10 AS Decimal(4, 2)))
INSERT [dbo].[Materials] ([Id], [Title], [Percent]) VALUES (2, N'Тип материала 2', CAST(0.95 AS Decimal(4, 2)))
INSERT [dbo].[Materials] ([Id], [Title], [Percent]) VALUES (3, N'Тип материала 3', CAST(0.28 AS Decimal(4, 2)))
INSERT [dbo].[Materials] ([Id], [Title], [Percent]) VALUES (4, N'Тип материала 4', CAST(0.55 AS Decimal(4, 2)))
INSERT [dbo].[Materials] ([Id], [Title], [Percent]) VALUES (5, N'Тип материала 5', CAST(0.34 AS Decimal(4, 2)))
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Account]    Script Date: 08.02.2025 12:53:17 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Account] ON [dbo].[Account]
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Partners_Type]    Script Date: 08.02.2025 12:53:17 ******/
CREATE NONCLUSTERED INDEX [IX_Partners_Type] ON [dbo].[Partners]
(
	[Type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PartnersProducts_PartnerId]    Script Date: 08.02.2025 12:53:17 ******/
CREATE NONCLUSTERED INDEX [IX_PartnersProducts_PartnerId] ON [dbo].[PartnersProducts]
(
	[PartnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PartnersProducts_ProductId]    Script Date: 08.02.2025 12:53:17 ******/
CREATE NONCLUSTERED INDEX [IX_PartnersProducts_ProductId] ON [dbo].[PartnersProducts]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_ProductTypeId]    Script Date: 08.02.2025 12:53:17 ******/
CREATE NONCLUSTERED INDEX [IX_Products_ProductTypeId] ON [dbo].[Products]
(
	[ProductTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Partners]  WITH CHECK ADD  CONSTRAINT [FK_Partners_PartenersTypes] FOREIGN KEY([Type])
REFERENCES [dbo].[PartenersTypes] ([Id])
GO
ALTER TABLE [dbo].[Partners] CHECK CONSTRAINT [FK_Partners_PartenersTypes]
GO
ALTER TABLE [dbo].[PartnersProducts]  WITH CHECK ADD  CONSTRAINT [FK_PartnersProducts_Partners] FOREIGN KEY([PartnerId])
REFERENCES [dbo].[Partners] ([Id])
GO
ALTER TABLE [dbo].[PartnersProducts] CHECK CONSTRAINT [FK_PartnersProducts_Partners]
GO
ALTER TABLE [dbo].[PartnersProducts]  WITH CHECK ADD  CONSTRAINT [FK_PartnersProducts_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[PartnersProducts] CHECK CONSTRAINT [FK_PartnersProducts_Products]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductType] FOREIGN KEY([ProductTypeId])
REFERENCES [dbo].[ProductType] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductType]
GO
USE [master]
GO
ALTER DATABASE [ispp1113_2] SET  READ_WRITE 
GO
