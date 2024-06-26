USE [master]
GO
DROP DATABASE ShopDB
GO
/****** Object:  Database [ShopDB]    Script Date: 4/7/2024 21:53:41 ******/
CREATE DATABASE [ShopDB]
GO
USE [ShopDB]
GO
ALTER DATABASE [ShopDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShopDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShopDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShopDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShopDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShopDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShopDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShopDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShopDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShopDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShopDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShopDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShopDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShopDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShopDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShopDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShopDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ShopDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShopDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShopDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShopDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShopDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShopDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ShopDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShopDB] SET RECOVERY FULL 
GO
ALTER DATABASE [ShopDB] SET  MULTI_USER 
GO
ALTER DATABASE [ShopDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShopDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShopDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShopDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShopDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ShopDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ShopDB', N'ON'
GO
ALTER DATABASE [ShopDB] SET QUERY_STORE = OFF
GO
USE [ShopDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/7/2024 21:53:41 ******/
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
/****** Object:  Table [dbo].[Address]    Script Date: 4/7/2024 21:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[NickName] [nvarchar](max) NULL,
	[AddressName] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[isDefault] [bit] NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 4/7/2024 21:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 4/7/2024 21:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 4/7/2024 21:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[NickName] [nvarchar](max) NULL,
	[AddressName] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Total] [bigint] NOT NULL,
	[OrderStatus] [int] NOT NULL,
	[PaymentIntenId] [nvarchar](max) NULL,
	[MomoRequestId] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItem]    Script Date: 4/7/2024 21:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [uniqueidentifier] NOT NULL,
	[ItemId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_OrderItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 4/7/2024 21:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [bigint] NOT NULL,
	[PictureUrl] [nvarchar](max) NULL,
	[QuantityInStock] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
	[BrandID] [int] NOT NULL,
	[PublicIdCloudary] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleClaims]    Script Date: 4/7/2024 21:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_RoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 4/7/2024 21:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShoppingCart]    Script Date: 4/7/2024 21:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShoppingCart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[PaymentIntenId] [nvarchar](max) NULL,
	[ClientSecret] [nvarchar](max) NULL,
 CONSTRAINT [PK_ShoppingCart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShoppingCartItem]    Script Date: 4/7/2024 21:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShoppingCartItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShoppingCartID] [int] NOT NULL,
	[ItemId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_ShoppingCartItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Token]    Script Date: 4/7/2024 21:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Token](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[IPAddress] [nvarchar](max) NULL,
	[UserAgent] [nvarchar](max) NULL,
	[RefreshToken] [nvarchar](max) NULL,
	[ExpiresAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Token] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserClaims]    Script Date: 4/7/2024 21:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogins]    Script Date: 4/7/2024 21:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_UserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 4/7/2024 21:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/7/2024 21:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [nvarchar](450) NOT NULL,
	[FullName] [nvarchar](100) NULL,
	[Birthday] [datetime2](7) NULL,
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
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTokens]    Script Date: 4/7/2024 21:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240407144256_v1', N'6.0.11')
GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([Id], [UserId], [NickName], [AddressName], [Phone], [City], [isDefault]) VALUES (1, N'd68dcb5f-2706-4cb5-bb0b-37bf39400420', N'Huynh Tuan Kiet', N'172/26 Ly Thai To, Q.3', N'0386226362', N'HCM', 1)
INSERT [dbo].[Address] ([Id], [UserId], [NickName], [AddressName], [Phone], [City], [isDefault]) VALUES (2, N'd68dcb5f-2706-4cb5-bb0b-37bf39400420', N'Au Duong Phong', N'175 Duong so 1, Go Vap', N'0129629521', N'HCM', 0)
SET IDENTITY_INSERT [dbo].[Address] OFF
GO
SET IDENTITY_INSERT [dbo].[Brand] ON 

INSERT [dbo].[Brand] ([Id], [Name], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (1, N'Dell', 0, CAST(N'2024-04-07T14:42:56.3284702' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Brand] ([Id], [Name], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (2, N'Apple', 0, CAST(N'2024-04-07T14:42:56.3284704' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Brand] ([Id], [Name], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (3, N'Gigabyte', 0, CAST(N'2024-04-07T14:42:56.3284705' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Brand] ([Id], [Name], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (4, N'Corsair', 0, CAST(N'2024-04-07T14:42:56.3284706' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Brand] ([Id], [Name], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (5, N'LG', 0, CAST(N'2024-04-07T14:42:56.3284707' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Brand] ([Id], [Name], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (6, N'Asus', 0, CAST(N'2024-04-07T14:42:56.3284707' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Brand] ([Id], [Name], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (7, N'Viewsonic', 0, CAST(N'2024-04-07T14:42:56.3284708' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Brand] ([Id], [Name], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (8, N'Acer', 0, CAST(N'2024-04-07T14:42:56.3284708' AS DateTime2), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Brand] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (1, N'Laptop', 0, CAST(N'2024-04-07T14:42:56.3284974' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Category] ([Id], [Name], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (2, N'Ipad', 0, CAST(N'2024-04-07T14:42:56.3284976' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Category] ([Id], [Name], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (3, N'Screen', 0, CAST(N'2024-04-07T14:42:56.3284977' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Category] ([Id], [Name], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (4, N'Iphone', 0, CAST(N'2024-04-07T14:42:56.3284978' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Category] ([Id], [Name], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (5, N'Macbook', 0, CAST(N'2024-04-07T14:42:56.3285019' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Category] ([Id], [Name], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (6, N'Mainboard', 0, CAST(N'2024-04-07T14:42:56.3285020' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Category] ([Id], [Name], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (7, N'Case', 0, CAST(N'2024-04-07T14:42:56.3285021' AS DateTime2), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (1, N'Dell Latitude 7320', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 1000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693471/shopee/products/jqyuena1vpsuojaht4vu.png', 100, 1, 1, NULL, 0, CAST(N'2024-04-07T14:42:56.3284495' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (2, N'Dell Latitude 7330', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 2000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693471/shopee/products/n28l0eh9rjx2bihtxoy5.jpg', 100, 1, 1, NULL, 0, CAST(N'2024-04-07T14:42:56.3284500' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (3, N'Dell Inspiron 6430', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 3000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/hpgz7xlaqa52xo7ubjw9.png', 100, 1, 1, NULL, 0, CAST(N'2024-04-07T14:42:56.3284502' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (4, N'Dell Inspiron 6530', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 4000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/enebiqezhcup3lgkcstb.png', 100, 1, 1, NULL, 0, CAST(N'2024-04-07T14:42:56.3284503' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (5, N'Ipad M1 12.9', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 5000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/gpomm9nf5w3w4juiooiv.png', 100, 2, 2, NULL, 0, CAST(N'2024-04-07T14:42:56.3284504' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (6, N'Ipad M1 12.9', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 6000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/yysgxkbqiufbui1hb9si.jpg', 100, 2, 2, NULL, 0, CAST(N'2024-04-07T14:42:56.3284505' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (7, N'Dell Screen 27inch', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 7000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/wsb51zjp5mc4wqbfxatp.png', 100, 3, 1, NULL, 0, CAST(N'2024-04-07T14:42:56.3284506' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (8, N'Dell Screen 27inch', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 8000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693473/shopee/products/teghmyo3k3hdkau9qne7.png', 100, 3, 1, NULL, 0, CAST(N'2024-04-07T14:42:56.3284509' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (9, N'Iphone 14 Pro Max', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 9000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693473/shopee/products/i39drgkscnglo4qh6tvr.jpg', 100, 4, 2, NULL, 0, CAST(N'2024-04-07T14:42:56.3284510' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (10, N'Iphone 14 Pro Max', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 10000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693473/shopee/products/iwoww4fcebhsximqr2e7.jpg', 100, 4, 2, NULL, 0, CAST(N'2024-04-07T14:42:56.3284511' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (11, N'Macbook Air M1', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 11000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693473/shopee/products/bsca35kdtcrrsrahalrb.jpg', 100, 5, 2, NULL, 0, CAST(N'2024-04-07T14:42:56.3284513' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (12, N'Macbook Air M1', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 12000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693474/shopee/products/eiwqbjg53c1iiyfyuubx.png', 100, 5, 2, NULL, 0, CAST(N'2024-04-07T14:42:56.3284514' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (13, N'Mainboard Gigabyte 6330', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 13000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693474/shopee/products/vhxrw4q797mox11xllpf.png', 100, 6, 3, NULL, 0, CAST(N'2024-04-07T14:42:56.3284515' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (14, N'Mainboard Gigabyte 6330', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 14000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693471/shopee/products/jxdj5mfcy47ee0bwfmnp.webp', 100, 6, 3, NULL, 0, CAST(N'2024-04-07T14:42:56.3284516' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (15, N'Case Corsair', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 15000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693471/shopee/products/iilp2mh1066ifpxiluur.png', 100, 7, 4, NULL, 0, CAST(N'2024-04-07T14:42:56.3284517' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (16, N'LG Ultra Gear', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 16000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693471/shopee/products/x8nbir1cb3vymmubj0qd.webp', 100, 3, 5, NULL, 0, CAST(N'2024-04-07T14:42:56.3284518' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (17, N'LG Ultra Gear', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 17000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/kvk93lqt9iyjfnbhf39u.webp', 100, 3, 5, NULL, 0, CAST(N'2024-04-07T14:42:56.3284519' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (18, N'MSI 27', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 18000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/k5uu8rmgex2g8nr45ldi.webp', 100, 3, 6, NULL, 0, CAST(N'2024-04-07T14:42:56.3284520' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (19, N'Viewsonic 24', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 19000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/v01sbaf9rbkzw8yhtdwv.webp', 100, 3, 7, NULL, 0, CAST(N'2024-04-07T14:42:56.3284521' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (20, N'Acer 27', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 10000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693473/shopee/products/njtxjkkamuulhb4alvdg.webp', 100, 3, 8, NULL, 0, CAST(N'2024-04-07T14:42:56.3284522' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (21, N'Asus 27 Freesync', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 21000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693473/shopee/products/jhxgm22du9zgbe2sw5zc.webp', 100, 3, 6, NULL, 0, CAST(N'2024-04-07T14:42:56.3284523' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (22, N'Asus 24 Freesync', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 22000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693474/shopee/products/lrjtodqgvmojr94durpt.webp', 100, 3, 6, NULL, 0, CAST(N'2024-04-07T14:42:56.3284567' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (23, N'Viewsonic 24 Freesync', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 23000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693474/shopee/products/tihrkueyfuawaaob6f0g.webp', 100, 3, 7, NULL, 0, CAST(N'2024-04-07T14:42:56.3284570' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (24, N'Viewsonic 24 Freesync 75Hz', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 24000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693474/shopee/products/timgmpaw7v0i9gpx0ayv.webp', 100, 3, 7, NULL, 0, CAST(N'2024-04-07T14:42:56.3284571' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (25, N'Asus TUF Gaming 24', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 25000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693474/shopee/products/tmjzsdvpgixl7dedthkm.webp', 100, 3, 6, NULL, 0, CAST(N'2024-04-07T14:42:56.3284572' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (26, N'Gigabyte 24', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 26000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693474/shopee/products/ncpg1p2grvu9mbj66gh4.webp', 100, 3, 3, NULL, 0, CAST(N'2024-04-07T14:42:56.3284573' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (27, N'Asus GM27', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 27000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693476/shopee/products/qmauhpz1jych8vf6g2hb.webp', 100, 3, 6, NULL, 0, CAST(N'2024-04-07T14:42:56.3284574' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (28, N'Acer 75hz 27', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 28000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693474/shopee/products/qamr31r8gxd9rfcxkaiw.webp', 100, 3, 8, NULL, 0, CAST(N'2024-04-07T14:42:56.3284576' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (29, N'LG 75hz 27', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 29000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693475/shopee/products/gwt4kwqllyybkrwofd1m.webp', 100, 3, 5, NULL, 0, CAST(N'2024-04-07T14:42:56.3284577' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (30, N'Asus 100hz 27', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 30000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693475/shopee/products/feqpxb8w3aw97cwq3d8v.webp', 100, 3, 6, NULL, 0, CAST(N'2024-04-07T14:42:56.3284578' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (31, N'Dell Latitude 7320 - 2', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 1000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693471/shopee/products/jqyuena1vpsuojaht4vu.png', 100, 1, 1, NULL, 0, CAST(N'2024-04-07T14:42:56.3284579' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (32, N'Dell Latitude 7330 - 2', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 2000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693471/shopee/products/n28l0eh9rjx2bihtxoy5.jpg', 100, 1, 1, NULL, 0, CAST(N'2024-04-07T14:42:56.3284581' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (33, N'Dell Inspiron 6430 - 2', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 3000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/hpgz7xlaqa52xo7ubjw9.png', 100, 1, 1, NULL, 0, CAST(N'2024-04-07T14:42:56.3284583' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (34, N'Dell Inspiron 6530 - 2', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 4000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/enebiqezhcup3lgkcstb.png', 100, 1, 1, NULL, 0, CAST(N'2024-04-07T14:42:56.3284584' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (35, N'Ipad M1 12.9 - 2', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 5000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/gpomm9nf5w3w4juiooiv.png', 100, 2, 2, NULL, 0, CAST(N'2024-04-07T14:42:56.3284585' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (36, N'Ipad M1 12.9 - 3', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 6000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/yysgxkbqiufbui1hb9si.jpg', 100, 2, 2, NULL, 0, CAST(N'2024-04-07T14:42:56.3284586' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [PictureUrl], [QuantityInStock], [CategoryID], [BrandID], [PublicIdCloudary], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (37, N'Dell Screen 27inch - 2', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 7000, N'https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/wsb51zjp5mc4wqbfxatp.png', 100, 3, 1, NULL, 0, CAST(N'2024-04-07T14:42:56.3284587' AS DateTime2), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[RoleClaims] ON 

INSERT [dbo].[RoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (1, N'44bc1c18-51a6-46b0-8e20-0df40a2ae0b9', N'Permission', N'CanManageUsers')
INSERT [dbo].[RoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (2, N'44bc1c18-51a6-46b0-8e20-0df40a2ae0b9', N'Permission', N'CanManageProducts')
INSERT [dbo].[RoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (3, N'4d267d01-3ce5-44d4-bf99-a3fd2172ba17', N'Permission', N'CanViewProducts')
SET IDENTITY_INSERT [dbo].[RoleClaims] OFF
GO
INSERT [dbo].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'44bc1c18-51a6-46b0-8e20-0df40a2ae0b9', N'Admin', N'ADMIN', N'9c574a20-f6c8-4800-9b5e-92933a25f61d')
INSERT [dbo].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'4d267d01-3ce5-44d4-bf99-a3fd2172ba17', N'User', N'USER', N'55f13cb4-8de0-4d0d-8ab9-115b675bd3b6')
GO
SET IDENTITY_INSERT [dbo].[ShoppingCart] ON 

INSERT [dbo].[ShoppingCart] ([Id], [UserId], [PaymentIntenId], [ClientSecret]) VALUES (1, N'd68dcb5f-2706-4cb5-bb0b-37bf39400420', NULL, NULL)
SET IDENTITY_INSERT [dbo].[ShoppingCart] OFF
GO
SET IDENTITY_INSERT [dbo].[UserClaims] ON 

INSERT [dbo].[UserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (1, N'd68dcb5f-2706-4cb5-bb0b-37bf39400420', N'Country', N'VN')
SET IDENTITY_INSERT [dbo].[UserClaims] OFF
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'd68dcb5f-2706-4cb5-bb0b-37bf39400420', N'44bc1c18-51a6-46b0-8e20-0df40a2ae0b9')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'd68dcb5f-2706-4cb5-bb0b-37bf39400420', N'4d267d01-3ce5-44d4-bf99-a3fd2172ba17')
GO
INSERT [dbo].[Users] ([Id], [FullName], [Birthday], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'd68dcb5f-2706-4cb5-bb0b-37bf39400420', N'admin', NULL, N'admin@gmail.com', NULL, N'admin@gmail.com', NULL, 0, N'AQAAAAEAACcQAAAAEORqsu30Xu2m4FyF5WRg8ScZ6GZOtWBBeEVNO3Hgfq03k/bjHmUAKOh0SWJRkMjVdA==', N'427e8a16-f050-4451-a3fa-69725f141318', N'7845f7d8-da38-4104-be18-176f4e06fdda', NULL, 0, 0, NULL, 0, 0)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Address_UserId]    Script Date: 4/7/2024 21:53:41 ******/
CREATE NONCLUSTERED INDEX [IX_Address_UserId] ON [dbo].[Address]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Order_UserId]    Script Date: 4/7/2024 21:53:41 ******/
CREATE NONCLUSTERED INDEX [IX_Order_UserId] ON [dbo].[Order]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderItem_ItemId]    Script Date: 4/7/2024 21:53:41 ******/
CREATE NONCLUSTERED INDEX [IX_OrderItem_ItemId] ON [dbo].[OrderItem]
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderItem_OrderID]    Script Date: 4/7/2024 21:53:41 ******/
CREATE NONCLUSTERED INDEX [IX_OrderItem_OrderID] ON [dbo].[OrderItem]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_BrandID]    Script Date: 4/7/2024 21:53:41 ******/
CREATE NONCLUSTERED INDEX [IX_Product_BrandID] ON [dbo].[Product]
(
	[BrandID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_CategoryID]    Script Date: 4/7/2024 21:53:41 ******/
CREATE NONCLUSTERED INDEX [IX_Product_CategoryID] ON [dbo].[Product]
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleClaims_RoleId]    Script Date: 4/7/2024 21:53:41 ******/
CREATE NONCLUSTERED INDEX [IX_RoleClaims_RoleId] ON [dbo].[RoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 4/7/2024 21:53:41 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[Roles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ShoppingCart_UserId]    Script Date: 4/7/2024 21:53:41 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_ShoppingCart_UserId] ON [dbo].[ShoppingCart]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ShoppingCartItem_ItemId]    Script Date: 4/7/2024 21:53:41 ******/
CREATE NONCLUSTERED INDEX [IX_ShoppingCartItem_ItemId] ON [dbo].[ShoppingCartItem]
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ShoppingCartItem_ShoppingCartID]    Script Date: 4/7/2024 21:53:41 ******/
CREATE NONCLUSTERED INDEX [IX_ShoppingCartItem_ShoppingCartID] ON [dbo].[ShoppingCartItem]
(
	[ShoppingCartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Token_UserId]    Script Date: 4/7/2024 21:53:41 ******/
CREATE NONCLUSTERED INDEX [IX_Token_UserId] ON [dbo].[Token]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserClaims_UserId]    Script Date: 4/7/2024 21:53:41 ******/
CREATE NONCLUSTERED INDEX [IX_UserClaims_UserId] ON [dbo].[UserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserLogins_UserId]    Script Date: 4/7/2024 21:53:41 ******/
CREATE NONCLUSTERED INDEX [IX_UserLogins_UserId] ON [dbo].[UserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserRoles_RoleId]    Script Date: 4/7/2024 21:53:41 ******/
CREATE NONCLUSTERED INDEX [IX_UserRoles_RoleId] ON [dbo].[UserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 4/7/2024 21:53:41 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[Users]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 4/7/2024 21:53:41 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[Users]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Users_UserId]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Users_UserId]
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK_OrderItem_Order_OrderID] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK_OrderItem_Order_OrderID]
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK_OrderItem_Product_ItemId] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK_OrderItem_Product_ItemId]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Brand_BrandID] FOREIGN KEY([BrandID])
REFERENCES [dbo].[Brand] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Brand_BrandID]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category_CategoryID] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category_CategoryID]
GO
ALTER TABLE [dbo].[RoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_RoleClaims_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleClaims] CHECK CONSTRAINT [FK_RoleClaims_Roles_RoleId]
GO
ALTER TABLE [dbo].[ShoppingCart]  WITH CHECK ADD  CONSTRAINT [FK_ShoppingCart_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ShoppingCart] CHECK CONSTRAINT [FK_ShoppingCart_Users_UserId]
GO
ALTER TABLE [dbo].[ShoppingCartItem]  WITH CHECK ADD  CONSTRAINT [FK_ShoppingCartItem_Product_ItemId] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ShoppingCartItem] CHECK CONSTRAINT [FK_ShoppingCartItem_Product_ItemId]
GO
ALTER TABLE [dbo].[ShoppingCartItem]  WITH CHECK ADD  CONSTRAINT [FK_ShoppingCartItem_ShoppingCart_ShoppingCartID] FOREIGN KEY([ShoppingCartID])
REFERENCES [dbo].[ShoppingCart] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ShoppingCartItem] CHECK CONSTRAINT [FK_ShoppingCartItem_ShoppingCart_ShoppingCartID]
GO
ALTER TABLE [dbo].[Token]  WITH CHECK ADD  CONSTRAINT [FK_Token_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Token] CHECK CONSTRAINT [FK_Token_Users_UserId]
GO
ALTER TABLE [dbo].[UserClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserClaims_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserClaims] CHECK CONSTRAINT [FK_UserClaims_Users_UserId]
GO
ALTER TABLE [dbo].[UserLogins]  WITH CHECK ADD  CONSTRAINT [FK_UserLogins_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLogins] CHECK CONSTRAINT [FK_UserLogins_Users_UserId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles_RoleId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users_UserId]
GO
ALTER TABLE [dbo].[UserTokens]  WITH CHECK ADD  CONSTRAINT [FK_UserTokens_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserTokens] CHECK CONSTRAINT [FK_UserTokens_Users_UserId]
GO
USE [master]
GO
ALTER DATABASE [ShopDB] SET  READ_WRITE 
GO
