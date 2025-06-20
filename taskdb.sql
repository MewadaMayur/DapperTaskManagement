USE [master]
GO
/****** Object:  Database [taskdb]    Script Date: 15-06-2025 01:31:23 ******/
CREATE DATABASE [taskdb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'taskdb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MAYURMEWADA\MSSQL\DATA\taskdb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'taskdb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MAYURMEWADA\MSSQL\DATA\taskdb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [taskdb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [taskdb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [taskdb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [taskdb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [taskdb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [taskdb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [taskdb] SET ARITHABORT OFF 
GO
ALTER DATABASE [taskdb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [taskdb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [taskdb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [taskdb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [taskdb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [taskdb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [taskdb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [taskdb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [taskdb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [taskdb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [taskdb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [taskdb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [taskdb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [taskdb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [taskdb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [taskdb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [taskdb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [taskdb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [taskdb] SET  MULTI_USER 
GO
ALTER DATABASE [taskdb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [taskdb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [taskdb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [taskdb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [taskdb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [taskdb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [taskdb] SET QUERY_STORE = ON
GO
ALTER DATABASE [taskdb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [taskdb]
GO
/****** Object:  Table [dbo].[tblrole]    Script Date: 15-06-2025 01:31:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblrole](
	[roleid] [int] IDENTITY(1,1) NOT NULL,
	[rolename] [varchar](10) NULL,
 CONSTRAINT [PK_tblrole] PRIMARY KEY CLUSTERED 
(
	[roleid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbltask]    Script Date: 15-06-2025 01:31:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbltask](
	[taskid] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](50) NULL,
	[description] [varchar](200) NULL,
	[status] [varchar](50) NULL,
	[assignedid] [int] NULL,
 CONSTRAINT [PK_tbltask] PRIMARY KEY CLUSTERED 
(
	[taskid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbluser]    Script Date: 15-06-2025 01:31:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbluser](
	[uid] [int] IDENTITY(1,1) NOT NULL,
	[uname] [varchar](30) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[pass] [varchar](50) NOT NULL,
	[profilephoto] [varchar](max) NULL,
	[roleid] [int] NULL,
 CONSTRAINT [PK_tbluser] PRIMARY KEY CLUSTERED 
(
	[uid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblusertask]    Script Date: 15-06-2025 01:31:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblusertask](
	[utaskid] [int] IDENTITY(1,1) NOT NULL,
	[taskid] [int] NULL,
	[uid] [int] NULL,
 CONSTRAINT [PK_tblusertask] PRIMARY KEY CLUSTERED 
(
	[utaskid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblrole] ON 

INSERT [dbo].[tblrole] ([roleid], [rolename]) VALUES (1, N'Admin')
INSERT [dbo].[tblrole] ([roleid], [rolename]) VALUES (2, N'User')
SET IDENTITY_INSERT [dbo].[tblrole] OFF
GO
SET IDENTITY_INSERT [dbo].[tbltask] ON 

INSERT [dbo].[tbltask] ([taskid], [title], [description], [status], [assignedid]) VALUES (1, N'Development', N'develop app', N'In Progress', NULL)
INSERT [dbo].[tbltask] ([taskid], [title], [description], [status], [assignedid]) VALUES (2, N'Marketing', N'Marketing', N'Pending', 1)
INSERT [dbo].[tbltask] ([taskid], [title], [description], [status], [assignedid]) VALUES (3, N'Recruitment', N'Get Hiring details and enroll from campus', N'Work In Progress', 0)
INSERT [dbo].[tbltask] ([taskid], [title], [description], [status], [assignedid]) VALUES (4, N'Testing', N'Unit Testing', N'Pending', 2)
INSERT [dbo].[tbltask] ([taskid], [title], [description], [status], [assignedid]) VALUES (5, N'HRs', N'Recruiting', N'Work In Progress', 5)
INSERT [dbo].[tbltask] ([taskid], [title], [description], [status], [assignedid]) VALUES (6, N'Developments', N'Marketing App', N'Pending', 4)
INSERT [dbo].[tbltask] ([taskid], [title], [description], [status], [assignedid]) VALUES (8, N'Hiring', N'enorlllment', N'Work In Progress', 4)
INSERT [dbo].[tbltask] ([taskid], [title], [description], [status], [assignedid]) VALUES (9, N'Silver Oak ', N'Silved Oak', N'Completed', 4)
SET IDENTITY_INSERT [dbo].[tbltask] OFF
GO
SET IDENTITY_INSERT [dbo].[tbluser] ON 

INSERT [dbo].[tbluser] ([uid], [uname], [email], [pass], [profilephoto], [roleid]) VALUES (2, N'Mayur', N'mandip2@gmail.c', N'12345', N'', 1)
INSERT [dbo].[tbluser] ([uid], [uname], [email], [pass], [profilephoto], [roleid]) VALUES (4, N'Mandip', N'mandip2@gmail.coms', N'123456', N'', 2)
INSERT [dbo].[tbluser] ([uid], [uname], [email], [pass], [profilephoto], [roleid]) VALUES (5, N'Hetal', N'hetal@gmail.com', N'12345', NULL, 2)
INSERT [dbo].[tbluser] ([uid], [uname], [email], [pass], [profilephoto], [roleid]) VALUES (6, N'Pinal', N'pinal@gmail.com', N'12345', NULL, 2)
INSERT [dbo].[tbluser] ([uid], [uname], [email], [pass], [profilephoto], [roleid]) VALUES (9, N'Vanshika', N'vanshika@gmail.com', N'12354', NULL, 1)
INSERT [dbo].[tbluser] ([uid], [uname], [email], [pass], [profilephoto], [roleid]) VALUES (10, N'Viraj', N'viraj@gmail.com', N'45678', NULL, 2)
SET IDENTITY_INSERT [dbo].[tbluser] OFF
GO
USE [master]
GO
ALTER DATABASE [taskdb] SET  READ_WRITE 
GO
