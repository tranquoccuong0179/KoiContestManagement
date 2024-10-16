USE [master]
GO
/****** Object:  Database [PRN221]    Script Date: 13/10/2024 5:44:07 CH ******/
CREATE DATABASE [PRN221]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PRN221', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\PRN221.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PRN221_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\PRN221_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PRN221] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PRN221].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PRN221] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PRN221] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PRN221] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PRN221] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PRN221] SET ARITHABORT OFF 
GO
ALTER DATABASE [PRN221] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PRN221] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PRN221] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PRN221] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PRN221] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PRN221] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PRN221] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PRN221] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PRN221] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PRN221] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PRN221] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PRN221] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PRN221] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PRN221] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PRN221] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PRN221] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PRN221] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PRN221] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PRN221] SET  MULTI_USER 
GO
ALTER DATABASE [PRN221] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PRN221] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PRN221] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PRN221] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PRN221] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PRN221] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PRN221] SET QUERY_STORE = ON
GO
ALTER DATABASE [PRN221] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PRN221]
GO
/****** Object:  Table [dbo].[Achievement]    Script Date: 13/10/2024 5:44:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Achievement](
	[Id] [uniqueidentifier] NOT NULL,
	[KoiId] [uniqueidentifier] NOT NULL,
	[ResultId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
	[DeleteAt] [datetime] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Achievement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 13/10/2024 5:44:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Size] [float] NOT NULL,
	[Variety] [nvarchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
	[DeleteAt] [datetime] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompetitionCategory]    Script Date: 13/10/2024 5:44:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompetitionCategory](
	[Id] [uniqueidentifier] NOT NULL,
	[CompetitionId] [uniqueidentifier] NOT NULL,
	[CategoryId] [uniqueidentifier] NOT NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
	[DeleteAt] [datetime] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_NewTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompetitionRound]    Script Date: 13/10/2024 5:44:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompetitionRound](
	[Id] [uniqueidentifier] NOT NULL,
	[KoiId] [uniqueidentifier] NOT NULL,
	[CompetitionId] [uniqueidentifier] NOT NULL,
	[RoundId] [uniqueidentifier] NOT NULL,
	[Active] [bit] NOT NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
	[DeleteAt] [datetime] NULL,
 CONSTRAINT [PK_CompetitionRound] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Competitions]    Script Date: 13/10/2024 5:44:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Competitions](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Location] [nvarchar](50) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[MaxApplication] [int] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
	[DeleteAt] [datetime] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Competitions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Criteria]    Script Date: 13/10/2024 5:44:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Criteria](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Percent] [float] NOT NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
	[DeleteAt] [datetime] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Criteria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CriteriaPoint]    Script Date: 13/10/2024 5:44:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CriteriaPoint](
	[Id] [uniqueidentifier] NOT NULL,
	[CriteriaId] [uniqueidentifier] NOT NULL,
	[RefereeMarkId] [uniqueidentifier] NOT NULL,
	[Point] [float] NOT NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
	[DeleteAt] [datetime] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_CriteriaPoint] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Koi]    Script Date: 13/10/2024 5:44:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Koi](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Variety] [nvarchar](50) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[Size] [float] NOT NULL,
	[Image] [varchar](max) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
	[DeleteAt] [datetime] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Koi] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mark]    Script Date: 13/10/2024 5:44:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mark](
	[Id] [uniqueidentifier] NOT NULL,
	[CompetitionRoudId] [uniqueidentifier] NOT NULL,
	[Point] [float] NOT NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
	[DeleteAt] [datetime] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Mark] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Predictions]    Script Date: 13/10/2024 5:44:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Predictions](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[CompetitionRoundId] [uniqueidentifier] NOT NULL,
	[Point] [float] NOT NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
	[DeleteAt] [datetime] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Predictions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RefereeMark]    Script Date: 13/10/2024 5:44:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RefereeMark](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[CompetitionRoundId] [uniqueidentifier] NOT NULL,
	[Point] [float] NOT NULL,
	[MarkId] [uniqueidentifier] NOT NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
	[DeleteAt] [datetime] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_RefereeMark] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 13/10/2024 5:44:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registration](
	[Id] [uniqueidentifier] NOT NULL,
	[KoiId] [uniqueidentifier] NOT NULL,
	[CompetitionCategoryId] [uniqueidentifier] NOT NULL,
	[IsCheckIn] [bit] NOT NULL,
	[CheckInTime] [datetime] NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
	[DeleteAt] [datetime] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Result]    Script Date: 13/10/2024 5:44:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Result](
	[Id] [uniqueidentifier] NOT NULL,
	[RegistrationId] [uniqueidentifier] NOT NULL,
	[KoiId] [uniqueidentifier] NOT NULL,
	[FinalMark] [float] NOT NULL,
	[Ranking] [int] NOT NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
	[DeleteAt] [datetime] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Result] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 13/10/2024 5:44:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Round]    Script Date: 13/10/2024 5:44:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Round](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
	[DeleteAt] [datetime] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Round] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 13/10/2024 5:44:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 13/10/2024 5:44:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Pasword] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
	[DeleteAt] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Achievement]  WITH CHECK ADD  CONSTRAINT [FK_Achievement_Koi] FOREIGN KEY([KoiId])
REFERENCES [dbo].[Koi] ([Id])
GO
ALTER TABLE [dbo].[Achievement] CHECK CONSTRAINT [FK_Achievement_Koi]
GO
ALTER TABLE [dbo].[Achievement]  WITH CHECK ADD  CONSTRAINT [FK_Achievement_Result_1] FOREIGN KEY([ResultId])
REFERENCES [dbo].[Result] ([Id])
GO
ALTER TABLE [dbo].[Achievement] CHECK CONSTRAINT [FK_Achievement_Result_1]
GO
ALTER TABLE [dbo].[CompetitionCategory]  WITH CHECK ADD  CONSTRAINT [FK_NewTable_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[CompetitionCategory] CHECK CONSTRAINT [FK_NewTable_Category]
GO
ALTER TABLE [dbo].[CompetitionCategory]  WITH CHECK ADD  CONSTRAINT [FK_NewTable_Competitions_1] FOREIGN KEY([CompetitionId])
REFERENCES [dbo].[Competitions] ([Id])
GO
ALTER TABLE [dbo].[CompetitionCategory] CHECK CONSTRAINT [FK_NewTable_Competitions_1]
GO
ALTER TABLE [dbo].[CompetitionRound]  WITH CHECK ADD  CONSTRAINT [FK_CompetitionRound_Competitions_2] FOREIGN KEY([CompetitionId])
REFERENCES [dbo].[Competitions] ([Id])
GO
ALTER TABLE [dbo].[CompetitionRound] CHECK CONSTRAINT [FK_CompetitionRound_Competitions_2]
GO
ALTER TABLE [dbo].[CompetitionRound]  WITH CHECK ADD  CONSTRAINT [FK_CompetitionRound_Koi] FOREIGN KEY([KoiId])
REFERENCES [dbo].[Koi] ([Id])
GO
ALTER TABLE [dbo].[CompetitionRound] CHECK CONSTRAINT [FK_CompetitionRound_Koi]
GO
ALTER TABLE [dbo].[CompetitionRound]  WITH CHECK ADD  CONSTRAINT [FK_CompetitionRound_Round_1] FOREIGN KEY([RoundId])
REFERENCES [dbo].[Round] ([Id])
GO
ALTER TABLE [dbo].[CompetitionRound] CHECK CONSTRAINT [FK_CompetitionRound_Round_1]
GO
ALTER TABLE [dbo].[CriteriaPoint]  WITH CHECK ADD  CONSTRAINT [FK_CriteriaPoint_CriteriaPoint] FOREIGN KEY([CriteriaId])
REFERENCES [dbo].[CriteriaPoint] ([Id])
GO
ALTER TABLE [dbo].[CriteriaPoint] CHECK CONSTRAINT [FK_CriteriaPoint_CriteriaPoint]
GO
ALTER TABLE [dbo].[CriteriaPoint]  WITH CHECK ADD  CONSTRAINT [FK_CriteriaPoint_RefereeMark] FOREIGN KEY([RefereeMarkId])
REFERENCES [dbo].[RefereeMark] ([Id])
GO
ALTER TABLE [dbo].[CriteriaPoint] CHECK CONSTRAINT [FK_CriteriaPoint_RefereeMark]
GO
ALTER TABLE [dbo].[Koi]  WITH CHECK ADD  CONSTRAINT [FK_Koi_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Koi] CHECK CONSTRAINT [FK_Koi_Users]
GO
ALTER TABLE [dbo].[Mark]  WITH CHECK ADD  CONSTRAINT [FK_Mark_CompetitionRound] FOREIGN KEY([CompetitionRoudId])
REFERENCES [dbo].[CompetitionRound] ([Id])
GO
ALTER TABLE [dbo].[Mark] CHECK CONSTRAINT [FK_Mark_CompetitionRound]
GO
ALTER TABLE [dbo].[Predictions]  WITH CHECK ADD  CONSTRAINT [FK_Predictions_CompetitionRound] FOREIGN KEY([CompetitionRoundId])
REFERENCES [dbo].[CompetitionRound] ([Id])
GO
ALTER TABLE [dbo].[Predictions] CHECK CONSTRAINT [FK_Predictions_CompetitionRound]
GO
ALTER TABLE [dbo].[Predictions]  WITH CHECK ADD  CONSTRAINT [FK_Predictions_Users_1] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Predictions] CHECK CONSTRAINT [FK_Predictions_Users_1]
GO
ALTER TABLE [dbo].[RefereeMark]  WITH CHECK ADD  CONSTRAINT [FK_RefereeMark_CompetitionRound_1] FOREIGN KEY([CompetitionRoundId])
REFERENCES [dbo].[CompetitionRound] ([Id])
GO
ALTER TABLE [dbo].[RefereeMark] CHECK CONSTRAINT [FK_RefereeMark_CompetitionRound_1]
GO
ALTER TABLE [dbo].[RefereeMark]  WITH CHECK ADD  CONSTRAINT [FK_RefereeMark_Mark_2] FOREIGN KEY([MarkId])
REFERENCES [dbo].[Mark] ([Id])
GO
ALTER TABLE [dbo].[RefereeMark] CHECK CONSTRAINT [FK_RefereeMark_Mark_2]
GO
ALTER TABLE [dbo].[RefereeMark]  WITH CHECK ADD  CONSTRAINT [FK_RefereeMark_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[RefereeMark] CHECK CONSTRAINT [FK_RefereeMark_Users]
GO
ALTER TABLE [dbo].[Registration]  WITH CHECK ADD  CONSTRAINT [FK_Registration_CompetitionCategory] FOREIGN KEY([CompetitionCategoryId])
REFERENCES [dbo].[CompetitionCategory] ([Id])
GO
ALTER TABLE [dbo].[Registration] CHECK CONSTRAINT [FK_Registration_CompetitionCategory]
GO
ALTER TABLE [dbo].[Registration]  WITH CHECK ADD  CONSTRAINT [FK_Registration_Koi_1] FOREIGN KEY([KoiId])
REFERENCES [dbo].[Koi] ([Id])
GO
ALTER TABLE [dbo].[Registration] CHECK CONSTRAINT [FK_Registration_Koi_1]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result_Koi] FOREIGN KEY([KoiId])
REFERENCES [dbo].[Koi] ([Id])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result_Koi]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result_Registration_1] FOREIGN KEY([RegistrationId])
REFERENCES [dbo].[Registration] ([Id])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result_Registration_1]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Roles]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Users_1] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Users_1]
GO
USE [master]
GO
ALTER DATABASE [PRN221] SET  READ_WRITE 
GO
