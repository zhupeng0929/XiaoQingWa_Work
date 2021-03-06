USE [master]
GO
/****** Object:  Database [XiaoQingWa]    Script Date: 2017/12/6 18:18:17 ******/
CREATE DATABASE [XiaoQingWa]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'XiaoQingWa', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\XiaoQingWa.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'XiaoQingWa_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\XiaoQingWa_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [XiaoQingWa] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [XiaoQingWa].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [XiaoQingWa] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [XiaoQingWa] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [XiaoQingWa] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [XiaoQingWa] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [XiaoQingWa] SET ARITHABORT OFF 
GO
ALTER DATABASE [XiaoQingWa] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [XiaoQingWa] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [XiaoQingWa] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [XiaoQingWa] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [XiaoQingWa] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [XiaoQingWa] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [XiaoQingWa] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [XiaoQingWa] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [XiaoQingWa] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [XiaoQingWa] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [XiaoQingWa] SET  DISABLE_BROKER 
GO
ALTER DATABASE [XiaoQingWa] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [XiaoQingWa] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [XiaoQingWa] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [XiaoQingWa] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [XiaoQingWa] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [XiaoQingWa] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [XiaoQingWa] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [XiaoQingWa] SET RECOVERY FULL 
GO
ALTER DATABASE [XiaoQingWa] SET  MULTI_USER 
GO
ALTER DATABASE [XiaoQingWa] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [XiaoQingWa] SET DB_CHAINING OFF 
GO
ALTER DATABASE [XiaoQingWa] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [XiaoQingWa] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'XiaoQingWa', N'ON'
GO
USE [XiaoQingWa]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 2017/12/6 18:18:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[PassWord] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[UserSex] [tinyint] NOT NULL,
	[UserPhone] [nvarchar](20) NOT NULL,
	[UserMail] [nvarchar](50) NOT NULL,
	[UserAddress] [nvarchar](100) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UserState] [tinyint] NOT NULL,
	[IsDelete] [tinyint] NOT NULL,
 CONSTRAINT [PK__Table__3214EC0718D88324] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_PassWord]  DEFAULT ('') FOR [PassWord]
GO
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF__Table__UserName__108B795B]  DEFAULT ('') FOR [UserName]
GO
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_UserSex]  DEFAULT ((0)) FOR [UserSex]
GO
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_UserPhone]  DEFAULT ('') FOR [UserPhone]
GO
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_UserMail]  DEFAULT ('') FOR [UserMail]
GO
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_UserAddress]  DEFAULT ('') FOR [UserAddress]
GO
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_UserState]  DEFAULT ((0)) FOR [UserState]
GO
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'PassWord'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'UserSex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'UserPhone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'UserMail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'UserAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'UserState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
USE [master]
GO
ALTER DATABASE [XiaoQingWa] SET  READ_WRITE 
GO
