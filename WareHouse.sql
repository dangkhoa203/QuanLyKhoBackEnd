USE [master]
GO
/****** Object:  Database [Warehouse]    Script Date: 24/04/2025 20:42:59 ******/
CREATE DATABASE [Warehouse]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Warehouse', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Warehouse.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Warehouse_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Warehouse.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Warehouse] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Warehouse].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Warehouse] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [Warehouse] SET ANSI_NULLS ON 
GO
ALTER DATABASE [Warehouse] SET ANSI_PADDING ON 
GO
ALTER DATABASE [Warehouse] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [Warehouse] SET ARITHABORT ON 
GO
ALTER DATABASE [Warehouse] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Warehouse] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Warehouse] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Warehouse] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Warehouse] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [Warehouse] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [Warehouse] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Warehouse] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [Warehouse] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Warehouse] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Warehouse] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Warehouse] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Warehouse] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Warehouse] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Warehouse] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Warehouse] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Warehouse] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Warehouse] SET RECOVERY FULL 
GO
ALTER DATABASE [Warehouse] SET  MULTI_USER 
GO
ALTER DATABASE [Warehouse] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Warehouse] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Warehouse] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Warehouse] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Warehouse] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Warehouse] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Warehouse', N'ON'
GO
ALTER DATABASE [Warehouse] SET QUERY_STORE = ON
GO
ALTER DATABASE [Warehouse] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Warehouse]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 24/04/2025 20:42:59 ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 24/04/2025 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 24/04/2025 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 24/04/2025 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 24/04/2025 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 24/04/2025 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 24/04/2025 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[ServiceId] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 24/04/2025 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerBuyReceiptDetails]    Script Date: 24/04/2025 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerBuyReceiptDetails](
	[ProductId] [nvarchar](450) NOT NULL,
	[ReceiptId] [nvarchar](450) NOT NULL,
	[Quantity] [int] NOT NULL,
	[PriceOfOne] [real] NOT NULL,
	[TotalPrice] [real] NOT NULL,
 CONSTRAINT [PK_CustomerBuyReceiptDetails] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[ReceiptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerBuyReceipts]    Script Date: 24/04/2025 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerBuyReceipts](
	[Id] [nvarchar](450) NOT NULL,
	[DateOrder] [datetime2](7) NOT NULL,
	[ReceiptValue] [real] NOT NULL,
	[CustomerId] [nvarchar](450) NULL,
	[ServiceId] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_CustomerBuyReceipts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerGroups]    Script Date: 24/04/2025 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerGroups](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[ServiceId] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_CustomerGroups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 24/04/2025 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[CustomerGroupId] [nvarchar](450) NULL,
	[ServiceId] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExportDetails]    Script Date: 24/04/2025 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExportDetails](
	[ProductId] [nvarchar](450) NOT NULL,
	[FormId] [nvarchar](450) NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_ExportDetails] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[FormId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExportForms]    Script Date: 24/04/2025 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExportForms](
	[Id] [nvarchar](450) NOT NULL,
	[ReceiptId] [nvarchar](450) NOT NULL,
	[ExportDate] [datetime2](7) NOT NULL,
	[ServiceId] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_ExportForms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImportDetails]    Script Date: 24/04/2025 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImportDetails](
	[ProductId] [nvarchar](450) NOT NULL,
	[FormId] [nvarchar](450) NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_ImportDetails] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[FormId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImportForms]    Script Date: 24/04/2025 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImportForms](
	[Id] [nvarchar](450) NOT NULL,
	[ReceiptId] [nvarchar](450) NOT NULL,
	[ImportDate] [datetime2](7) NOT NULL,
	[ServiceId] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_ImportForms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 24/04/2025 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[PricePerUnit] [real] NOT NULL,
	[MeasureUnit] [nvarchar](max) NOT NULL,
	[ProductTypeId] [nvarchar](450) NULL,
	[ServiceId] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductTypes]    Script Date: 24/04/2025 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductTypes](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[ServiceId] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_ProductTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceRegistereds]    Script Date: 24/04/2025 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceRegistereds](
	[Id] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_ServiceRegistereds] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stocks]    Script Date: 24/04/2025 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stocks](
	[ProductId] [nvarchar](450) NOT NULL,
	[ServiceId] [nvarchar](max) NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Stocks] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorGroups]    Script Date: 24/04/2025 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendorGroups](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[ServiceId] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_VendorGroups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorReplenishReceiptDetails]    Script Date: 24/04/2025 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendorReplenishReceiptDetails](
	[ProductId] [nvarchar](450) NOT NULL,
	[ReceiptId] [nvarchar](450) NOT NULL,
	[Quantity] [int] NOT NULL,
	[PriceOfOne] [real] NOT NULL,
	[TotalPrice] [real] NOT NULL,
 CONSTRAINT [PK_VendorReplenishReceiptDetails] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[ReceiptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorReplenishReceipts]    Script Date: 24/04/2025 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendorReplenishReceipts](
	[Id] [nvarchar](450) NOT NULL,
	[DateOrder] [datetime2](7) NOT NULL,
	[ReceiptValue] [real] NOT NULL,
	[VendorId] [nvarchar](450) NULL,
	[ServiceId] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_VendorReplenishReceipts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vendors]    Script Date: 24/04/2025 20:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendors](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[VendorGroupId] [nvarchar](450) NULL,
	[ServiceId] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Vendors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 24/04/2025 20:42:59 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 24/04/2025 20:42:59 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 24/04/2025 20:42:59 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 24/04/2025 20:42:59 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 24/04/2025 20:42:59 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 24/04/2025 20:42:59 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUsers_ServiceId]    Script Date: 24/04/2025 20:42:59 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_ServiceId] ON [dbo].[AspNetUsers]
(
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 24/04/2025 20:42:59 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_CustomerBuyReceiptDetails_ReceiptId]    Script Date: 24/04/2025 20:42:59 ******/
CREATE NONCLUSTERED INDEX [IX_CustomerBuyReceiptDetails_ReceiptId] ON [dbo].[CustomerBuyReceiptDetails]
(
	[ReceiptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_CustomerBuyReceipts_CustomerId]    Script Date: 24/04/2025 20:42:59 ******/
CREATE NONCLUSTERED INDEX [IX_CustomerBuyReceipts_CustomerId] ON [dbo].[CustomerBuyReceipts]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Customers_CustomerGroupId]    Script Date: 24/04/2025 20:42:59 ******/
CREATE NONCLUSTERED INDEX [IX_Customers_CustomerGroupId] ON [dbo].[Customers]
(
	[CustomerGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ExportDetails_FormId]    Script Date: 24/04/2025 20:42:59 ******/
CREATE NONCLUSTERED INDEX [IX_ExportDetails_FormId] ON [dbo].[ExportDetails]
(
	[FormId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ExportForms_ReceiptId]    Script Date: 24/04/2025 20:42:59 ******/
CREATE NONCLUSTERED INDEX [IX_ExportForms_ReceiptId] ON [dbo].[ExportForms]
(
	[ReceiptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ImportDetails_FormId]    Script Date: 24/04/2025 20:42:59 ******/
CREATE NONCLUSTERED INDEX [IX_ImportDetails_FormId] ON [dbo].[ImportDetails]
(
	[FormId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ImportForms_ReceiptId]    Script Date: 24/04/2025 20:42:59 ******/
CREATE NONCLUSTERED INDEX [IX_ImportForms_ReceiptId] ON [dbo].[ImportForms]
(
	[ReceiptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Products_ProductTypeId]    Script Date: 24/04/2025 20:42:59 ******/
CREATE NONCLUSTERED INDEX [IX_Products_ProductTypeId] ON [dbo].[Products]
(
	[ProductTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_VendorReplenishReceiptDetails_ReceiptId]    Script Date: 24/04/2025 20:42:59 ******/
CREATE NONCLUSTERED INDEX [IX_VendorReplenishReceiptDetails_ReceiptId] ON [dbo].[VendorReplenishReceiptDetails]
(
	[ReceiptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_VendorReplenishReceipts_VendorId]    Script Date: 24/04/2025 20:42:59 ******/
CREATE NONCLUSTERED INDEX [IX_VendorReplenishReceipts_VendorId] ON [dbo].[VendorReplenishReceipts]
(
	[VendorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Vendors_VendorGroupId]    Script Date: 24/04/2025 20:42:59 ******/
CREATE NONCLUSTERED INDEX [IX_Vendors_VendorGroupId] ON [dbo].[Vendors]
(
	[VendorGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_ServiceRegistereds_ServiceId] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[ServiceRegistereds] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_ServiceRegistereds_ServiceId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CustomerBuyReceiptDetails]  WITH CHECK ADD  CONSTRAINT [FK_orderdetail_product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[CustomerBuyReceiptDetails] CHECK CONSTRAINT [FK_orderdetail_product]
GO
ALTER TABLE [dbo].[CustomerBuyReceiptDetails]  WITH CHECK ADD  CONSTRAINT [FK_orderdetail_receipt] FOREIGN KEY([ReceiptId])
REFERENCES [dbo].[CustomerBuyReceipts] ([Id])
GO
ALTER TABLE [dbo].[CustomerBuyReceiptDetails] CHECK CONSTRAINT [FK_orderdetail_receipt]
GO
ALTER TABLE [dbo].[CustomerBuyReceipts]  WITH CHECK ADD  CONSTRAINT [FK_CustomerBuyReceipts_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[CustomerBuyReceipts] CHECK CONSTRAINT [FK_CustomerBuyReceipts_Customers_CustomerId]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_CustomerGroups_CustomerGroupId] FOREIGN KEY([CustomerGroupId])
REFERENCES [dbo].[CustomerGroups] ([Id])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_CustomerGroups_CustomerGroupId]
GO
ALTER TABLE [dbo].[ExportDetails]  WITH CHECK ADD  CONSTRAINT [FK_exportdetail_form] FOREIGN KEY([FormId])
REFERENCES [dbo].[ExportForms] ([Id])
GO
ALTER TABLE [dbo].[ExportDetails] CHECK CONSTRAINT [FK_exportdetail_form]
GO
ALTER TABLE [dbo].[ExportDetails]  WITH CHECK ADD  CONSTRAINT [FK_exportdetail_product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[ExportDetails] CHECK CONSTRAINT [FK_exportdetail_product]
GO
ALTER TABLE [dbo].[ExportForms]  WITH CHECK ADD  CONSTRAINT [FK_ExportForms_CustomerBuyReceipts_ReceiptId] FOREIGN KEY([ReceiptId])
REFERENCES [dbo].[CustomerBuyReceipts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExportForms] CHECK CONSTRAINT [FK_ExportForms_CustomerBuyReceipts_ReceiptId]
GO
ALTER TABLE [dbo].[ImportDetails]  WITH CHECK ADD  CONSTRAINT [FK_importdetail_form] FOREIGN KEY([FormId])
REFERENCES [dbo].[ImportForms] ([Id])
GO
ALTER TABLE [dbo].[ImportDetails] CHECK CONSTRAINT [FK_importdetail_form]
GO
ALTER TABLE [dbo].[ImportDetails]  WITH CHECK ADD  CONSTRAINT [FK_importdetail_product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[ImportDetails] CHECK CONSTRAINT [FK_importdetail_product]
GO
ALTER TABLE [dbo].[ImportForms]  WITH CHECK ADD  CONSTRAINT [FK_ImportForms_VendorReplenishReceipts_ReceiptId] FOREIGN KEY([ReceiptId])
REFERENCES [dbo].[VendorReplenishReceipts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImportForms] CHECK CONSTRAINT [FK_ImportForms_VendorReplenishReceipts_ReceiptId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductTypes_ProductTypeId] FOREIGN KEY([ProductTypeId])
REFERENCES [dbo].[ProductTypes] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductTypes_ProductTypeId]
GO
ALTER TABLE [dbo].[Stocks]  WITH CHECK ADD  CONSTRAINT [FK_stock_product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Stocks] CHECK CONSTRAINT [FK_stock_product]
GO
ALTER TABLE [dbo].[VendorReplenishReceiptDetails]  WITH CHECK ADD  CONSTRAINT [FK_replenishdetail_product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[VendorReplenishReceiptDetails] CHECK CONSTRAINT [FK_replenishdetail_product]
GO
ALTER TABLE [dbo].[VendorReplenishReceiptDetails]  WITH CHECK ADD  CONSTRAINT [FK_replenishdetail_receipt] FOREIGN KEY([ReceiptId])
REFERENCES [dbo].[VendorReplenishReceipts] ([Id])
GO
ALTER TABLE [dbo].[VendorReplenishReceiptDetails] CHECK CONSTRAINT [FK_replenishdetail_receipt]
GO
ALTER TABLE [dbo].[VendorReplenishReceipts]  WITH CHECK ADD  CONSTRAINT [FK_VendorReplenishReceipts_Vendors_VendorId] FOREIGN KEY([VendorId])
REFERENCES [dbo].[Vendors] ([Id])
GO
ALTER TABLE [dbo].[VendorReplenishReceipts] CHECK CONSTRAINT [FK_VendorReplenishReceipts_Vendors_VendorId]
GO
ALTER TABLE [dbo].[Vendors]  WITH CHECK ADD  CONSTRAINT [FK_Vendors_VendorGroups_VendorGroupId] FOREIGN KEY([VendorGroupId])
REFERENCES [dbo].[VendorGroups] ([Id])
GO
ALTER TABLE [dbo].[Vendors] CHECK CONSTRAINT [FK_Vendors_VendorGroups_VendorGroupId]
GO
USE [master]
GO
ALTER DATABASE [Warehouse] SET  READ_WRITE 
GO
