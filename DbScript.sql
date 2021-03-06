
USE [iDMSC2]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 31/08/2018 11:34:54 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Articles]    Script Date: 31/08/2018 11:34:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[Title] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[Published] [datetime2](7) NOT NULL,
	[Active] [bit] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Likes]    Script Date: 31/08/2018 11:34:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Likes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ArticleId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Likes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 31/08/2018 11:34:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Mobile] [nvarchar](max) NULL,
	[Role] [nvarchar](max) NULL,
	[UserName] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180831084821_Initial', N'2.1.2-rtm-30932')
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [CreatedAt], [CreatedBy], [FirstName], [LastName], [Email], [Mobile], [Role], [UserName], [Password]) VALUES (7, CAST(N'2018-08-31T10:31:47.7333155' AS DateTime2), N'admin@admin.com', N'Admin first', N'Admin last', N'admin@admin.com', N'07535353535', N'Admin', N'admin@pressford.com', N'123456')
INSERT [dbo].[Users] ([Id], [CreatedAt], [CreatedBy], [FirstName], [LastName], [Email], [Mobile], [Role], [UserName], [Password]) VALUES (8, CAST(N'2018-08-31T10:31:47.9464837' AS DateTime2), N'admin@admin.com', N'Publisher First', N'Publisher Last', N'publisher@pressford.com', N'07535353535', N'Publisher', N'publisher@pressford.com', N'123456')
INSERT [dbo].[Users] ([Id], [CreatedAt], [CreatedBy], [FirstName], [LastName], [Email], [Mobile], [Role], [UserName], [Password]) VALUES (9, CAST(N'2018-08-31T10:31:47.9674172' AS DateTime2), N'admin@admin.com', N'Employee First', N'Employee Last', N'employee@pressford.com', N'07535353535', N'Employee', N'employee@pressford.com', N'123456')
INSERT [dbo].[Users] ([Id], [CreatedAt], [CreatedBy], [FirstName], [LastName], [Email], [Mobile], [Role], [UserName], [Password]) VALUES (10, CAST(N'2018-08-31T10:31:47.9675165' AS DateTime2), N'admin@admin.com', N'Employee1 First', N'Employee1 Last', N'employee1@pressford.com', N'07535353535', N'Employee', N'employee1@pressford.com', N'123456')
INSERT [dbo].[Users] ([Id], [CreatedAt], [CreatedBy], [FirstName], [LastName], [Email], [Mobile], [Role], [UserName], [Password]) VALUES (11, CAST(N'2018-08-31T10:31:47.9676176' AS DateTime2), N'admin@admin.com', N'Employee2 First', N'Employee2 Last', N'employee2@pressford.com', N'07535353535', N'Employee', N'employee2@pressford.com', N'123456')
INSERT [dbo].[Users] ([Id], [CreatedAt], [CreatedBy], [FirstName], [LastName], [Email], [Mobile], [Role], [UserName], [Password]) VALUES (12, CAST(N'2018-08-31T10:31:47.9677395' AS DateTime2), N'admin@admin.com', N'Employee3 First', N'Employee3 Last', N'employee3@pressford.com', N'07535353535', N'Employee', N'employe3e@pressford.com', N'123456')
INSERT [dbo].[Users] ([Id], [CreatedAt], [CreatedBy], [FirstName], [LastName], [Email], [Mobile], [Role], [UserName], [Password]) VALUES (13, CAST(N'2018-08-31T10:31:47.9678629' AS DateTime2), N'admin@admin.com', N'Employee4 First', N'Employee4 Last', N'employee4@pressford.com', N'07535353535', N'Employee', N'employee4@pressford.com', N'123456')
SET IDENTITY_INSERT [dbo].[Users] OFF
/****** Object:  Index [IX_Articles_UserId]    Script Date: 31/08/2018 11:34:54 ******/
CREATE NONCLUSTERED INDEX [IX_Articles_UserId] ON [dbo].[Articles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Likes_ArticleId]    Script Date: 31/08/2018 11:34:54 ******/
CREATE NONCLUSTERED INDEX [IX_Likes_ArticleId] ON [dbo].[Likes]
(
	[ArticleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Likes_UserId]    Script Date: 31/08/2018 11:34:54 ******/
CREATE NONCLUSTERED INDEX [IX_Likes_UserId] ON [dbo].[Likes]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_Articles_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_Articles_Users_UserId]
GO
ALTER TABLE [dbo].[Likes]  WITH CHECK ADD  CONSTRAINT [FK_Likes_Articles_ArticleId] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[Articles] ([Id])
GO
ALTER TABLE [dbo].[Likes] CHECK CONSTRAINT [FK_Likes_Articles_ArticleId]
GO
ALTER TABLE [dbo].[Likes]  WITH CHECK ADD  CONSTRAINT [FK_Likes_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Likes] CHECK CONSTRAINT [FK_Likes_Users_UserId]
GO
USE [master]
GO
ALTER DATABASE [iDMSC2] SET  READ_WRITE 
GO
