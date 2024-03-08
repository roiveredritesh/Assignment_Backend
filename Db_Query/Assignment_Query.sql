/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 08-03-2024 11:35 AM ******/
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
/****** Object:  Table [dbo].[DepartmentMasters]    Script Date: 08-03-2024 11:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepartmentMasters](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](max) NOT NULL,
	[DepartmentDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_DepartmentMasters] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DivisionMasters]    Script Date: 08-03-2024 11:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DivisionMasters](
	[DivisionId] [int] IDENTITY(1,1) NOT NULL,
	[DivisionName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DivisionMasters] PRIMARY KEY CLUSTERED 
(
	[DivisionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentCenters]    Script Date: 08-03-2024 11:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentCenters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](max) NOT NULL,
	[FilePath] [nvarchar](max) NOT NULL,
	[UploadedFileName] [nvarchar](max) NOT NULL,
	[Type] [nvarchar](max) NULL,
	[Folder] [nvarchar](max) NULL,
	[ModifiedBy] [nvarchar](max) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[DivisionId] [int] NOT NULL,
	[OfficeId] [int] NOT NULL,
 CONSTRAINT [PK_DocumentCenters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OfficeMasters]    Script Date: 08-03-2024 11:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OfficeMasters](
	[OfficeId] [int] IDENTITY(1,1) NOT NULL,
	[OfficeName] [nvarchar](max) NOT NULL,
	[OfficeDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_OfficeMasters] PRIMARY KEY CLUSTERED 
(
	[OfficeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240308053510_initial1', N'8.0.2')
GO
SET IDENTITY_INSERT [dbo].[DepartmentMasters] ON 
GO
INSERT [dbo].[DepartmentMasters] ([DepartmentId], [DepartmentName], [DepartmentDescription]) VALUES (1, N'Networking Services', NULL)
GO
INSERT [dbo].[DepartmentMasters] ([DepartmentId], [DepartmentName], [DepartmentDescription]) VALUES (2, N'Server Information', NULL)
GO
SET IDENTITY_INSERT [dbo].[DepartmentMasters] OFF
GO
SET IDENTITY_INSERT [dbo].[DivisionMasters] ON 
GO
INSERT [dbo].[DivisionMasters] ([DivisionId], [DivisionName]) VALUES (1, N'TISS')
GO
INSERT [dbo].[DivisionMasters] ([DivisionId], [DivisionName]) VALUES (2, N'AISS')
GO
SET IDENTITY_INSERT [dbo].[DivisionMasters] OFF
GO
SET IDENTITY_INSERT [dbo].[DocumentCenters] ON 
GO
INSERT [dbo].[DocumentCenters] ([Id], [FileName], [FilePath], [UploadedFileName], [Type], [Folder], [ModifiedBy], [ModifiedDate], [DepartmentId], [DivisionId], [OfficeId]) VALUES (1, N'test 1asd', N'Resource\DocumentCenter\3135715.png', N'3135715.png', N'png', N'asd', N'asd', CAST(N'2024-03-08T11:21:50.1546008' AS DateTime2), 1, 1, 3)
GO
INSERT [dbo].[DocumentCenters] ([Id], [FileName], [FilePath], [UploadedFileName], [Type], [Folder], [ModifiedBy], [ModifiedDate], [DepartmentId], [DivisionId], [OfficeId]) VALUES (2, N'asd', N'Resource\DocumentCenter\3135715.png', N'3135715.png', N'png', N'asd', N'asd', CAST(N'2024-03-08T11:21:57.0624114' AS DateTime2), 1, 2, 3)
GO
SET IDENTITY_INSERT [dbo].[DocumentCenters] OFF
GO
SET IDENTITY_INSERT [dbo].[OfficeMasters] ON 
GO
INSERT [dbo].[OfficeMasters] ([OfficeId], [OfficeName], [OfficeDescription]) VALUES (3, N'Server Unit', NULL)
GO
INSERT [dbo].[OfficeMasters] ([OfficeId], [OfficeName], [OfficeDescription]) VALUES (4, N'Server Unit 2', NULL)
GO
SET IDENTITY_INSERT [dbo].[OfficeMasters] OFF
GO
ALTER TABLE [dbo].[DocumentCenters]  WITH CHECK ADD  CONSTRAINT [FK_DocumentCenters_DepartmentMasters_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[DepartmentMasters] ([DepartmentId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DocumentCenters] CHECK CONSTRAINT [FK_DocumentCenters_DepartmentMasters_DepartmentId]
GO
ALTER TABLE [dbo].[DocumentCenters]  WITH CHECK ADD  CONSTRAINT [FK_DocumentCenters_DivisionMasters_DivisionId] FOREIGN KEY([DivisionId])
REFERENCES [dbo].[DivisionMasters] ([DivisionId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DocumentCenters] CHECK CONSTRAINT [FK_DocumentCenters_DivisionMasters_DivisionId]
GO
ALTER TABLE [dbo].[DocumentCenters]  WITH CHECK ADD  CONSTRAINT [FK_DocumentCenters_OfficeMasters_OfficeId] FOREIGN KEY([OfficeId])
REFERENCES [dbo].[OfficeMasters] ([OfficeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DocumentCenters] CHECK CONSTRAINT [FK_DocumentCenters_OfficeMasters_OfficeId]
GO
