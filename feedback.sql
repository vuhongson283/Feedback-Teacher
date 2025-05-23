USE [FeedbackSystem]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/27/2025 2:59:26 PM ******/
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
/****** Object:  Table [dbo].[ClassAssignments]    Script Date: 3/27/2025 2:59:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassAssignments](
	[AssignmentId] [int] IDENTITY(1,1) NOT NULL,
	[ClassId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
	[TeacherId] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AssignmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 3/27/2025 2:59:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[ClassId] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [nvarchar](255) NOT NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FeedbackAnswers]    Script Date: 3/27/2025 2:59:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedbackAnswers](
	[AnswerId] [int] IDENTITY(1,1) NOT NULL,
	[FormId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[QuestionId] [int] NOT NULL,
	[Answer] [nvarchar](50) NOT NULL,
	[SubmittedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AnswerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FeedbackForms]    Script Date: 3/27/2025 2:59:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedbackForms](
	[FormId] [int] IDENTITY(1,1) NOT NULL,
	[ClassId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
	[TeacherId] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[FormId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FeedbackQuestions]    Script Date: 3/27/2025 2:59:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedbackQuestions](
	[QuestionId] [int] IDENTITY(1,1) NOT NULL,
	[QuestionText] [nvarchar](1000) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentClass]    Script Date: 3/27/2025 2:59:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentClass](
	[StudentClassId] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[ClassId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 3/27/2025 2:59:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[SubjectId] [int] IDENTITY(1,1) NOT NULL,
	[SubjectName] [nvarchar](255) NOT NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/27/2025 2:59:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[PasswordHash] [nvarchar](255) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ClassAssignments] ON 

INSERT [dbo].[ClassAssignments] ([AssignmentId], [ClassId], [SubjectId], [TeacherId], [StartDate], [EndDate]) VALUES (1, 1, 1, 1, CAST(N'2025-03-01' AS Date), CAST(N'2025-06-01' AS Date))
INSERT [dbo].[ClassAssignments] ([AssignmentId], [ClassId], [SubjectId], [TeacherId], [StartDate], [EndDate]) VALUES (2, 2, 2, 1, CAST(N'2025-03-01' AS Date), CAST(N'2025-06-01' AS Date))
INSERT [dbo].[ClassAssignments] ([AssignmentId], [ClassId], [SubjectId], [TeacherId], [StartDate], [EndDate]) VALUES (4, 3, 3, 7, CAST(N'2025-03-01' AS Date), CAST(N'2025-06-01' AS Date))
INSERT [dbo].[ClassAssignments] ([AssignmentId], [ClassId], [SubjectId], [TeacherId], [StartDate], [EndDate]) VALUES (5, 4, 4, 7, CAST(N'2025-03-01' AS Date), CAST(N'2025-06-01' AS Date))
SET IDENTITY_INSERT [dbo].[ClassAssignments] OFF
GO
SET IDENTITY_INSERT [dbo].[Classes] ON 

INSERT [dbo].[Classes] ([ClassId], [ClassName], [CreatedAt]) VALUES (1, N'Lop CNTT 1', CAST(N'2025-03-16T00:36:34.093' AS DateTime))
INSERT [dbo].[Classes] ([ClassId], [ClassName], [CreatedAt]) VALUES (2, N'Lop CNTT 2', CAST(N'2025-03-16T00:36:34.093' AS DateTime))
INSERT [dbo].[Classes] ([ClassId], [ClassName], [CreatedAt]) VALUES (3, N'SE1753', CAST(N'2025-03-21T08:04:35.817' AS DateTime))
INSERT [dbo].[Classes] ([ClassId], [ClassName], [CreatedAt]) VALUES (4, N'SE1762', CAST(N'2025-03-21T08:07:27.603' AS DateTime))
SET IDENTITY_INSERT [dbo].[Classes] OFF
GO
SET IDENTITY_INSERT [dbo].[FeedbackAnswers] ON 

INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (7, 2, 3, 3, N'Always punctual', CAST(N'2025-03-20T19:32:08.420' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (8, 2, 3, 4, N'Mostly covered', CAST(N'2025-03-20T19:32:08.420' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (9, 2, 3, 5, N'Answered immediately or just after the session', CAST(N'2025-03-20T19:32:08.420' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (10, 2, 3, 6, N'Very Good', CAST(N'2025-03-20T19:32:08.420' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (11, 2, 3, 7, N'Good', CAST(N'2025-03-20T19:32:08.420' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (12, 2, 3, 8, N'Very Satisfied', CAST(N'2025-03-20T19:32:08.420' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (13, 3, 3, 3, N'Always punctual', CAST(N'2025-03-24T22:08:18.297' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (14, 3, 3, 4, N'Fully covered', CAST(N'2025-03-24T22:08:18.297' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (15, 3, 3, 5, N'Answered immediately or just after the session', CAST(N'2025-03-24T22:08:18.297' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (16, 3, 3, 6, N'Very Good', CAST(N'2025-03-24T22:08:18.297' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (17, 3, 3, 7, N'Very Good', CAST(N'2025-03-24T22:08:18.297' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (18, 3, 3, 8, N'Very Satisfied', CAST(N'2025-03-24T22:08:18.297' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (19, 4, 4, 3, N'Always punctual', CAST(N'2025-03-25T10:55:29.447' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (20, 4, 4, 4, N'Fully covered', CAST(N'2025-03-25T10:55:29.447' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (21, 4, 4, 5, N'Answered immediately or just after the session', CAST(N'2025-03-25T10:55:29.447' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (22, 4, 4, 6, N'Very Good', CAST(N'2025-03-25T10:55:29.447' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (23, 4, 4, 7, N'Very Good', CAST(N'2025-03-25T10:55:29.447' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (24, 4, 4, 8, N'Very Satisfied', CAST(N'2025-03-25T10:55:29.447' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (25, 5, 5, 3, N'Always punctual', CAST(N'2025-03-25T11:38:32.823' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (26, 5, 5, 4, N'Fully covered', CAST(N'2025-03-25T11:38:32.823' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (27, 5, 5, 5, N'Answered immediately or just after the session', CAST(N'2025-03-25T11:38:32.823' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (28, 5, 5, 6, N'Very Good', CAST(N'2025-03-25T11:38:32.823' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (29, 5, 5, 7, N'Very Good', CAST(N'2025-03-25T11:38:32.823' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (30, 5, 5, 8, N'Very Satisfied', CAST(N'2025-03-25T11:38:32.823' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (31, 1, 2, 3, N'Always punctual', CAST(N'2025-03-25T11:41:21.087' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (32, 1, 2, 4, N'Fully covered', CAST(N'2025-03-25T11:41:21.087' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (33, 1, 2, 5, N'Answered immediately or just after the session', CAST(N'2025-03-25T11:41:21.087' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (34, 1, 2, 6, N'Very Good', CAST(N'2025-03-25T11:41:21.087' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (35, 1, 2, 7, N'Very Good', CAST(N'2025-03-25T11:41:21.087' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (36, 1, 2, 8, N'Very Satisfied', CAST(N'2025-03-25T11:41:21.087' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (37, 5, 8, 3, N'Always punctual', CAST(N'2025-03-25T11:49:36.170' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (38, 5, 8, 4, N'Mostly covered', CAST(N'2025-03-25T11:49:36.170' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (39, 5, 8, 5, N'Answered immediately or just after the session', CAST(N'2025-03-25T11:49:36.170' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (40, 5, 8, 6, N'Very Good', CAST(N'2025-03-25T11:49:36.170' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (41, 5, 8, 7, N'Good', CAST(N'2025-03-25T11:49:36.170' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (42, 5, 8, 8, N'Very Satisfied', CAST(N'2025-03-25T11:49:36.170' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (43, 5, 8, 9, N'hay qua', CAST(N'2025-03-25T11:49:36.170' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (44, 5, 9, 3, N'Rarely punctual', CAST(N'2025-03-25T11:51:39.517' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (45, 5, 9, 4, N'Fully covered', CAST(N'2025-03-25T11:51:39.517' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (46, 5, 9, 5, N'Answered immediately or just after the session', CAST(N'2025-03-25T11:51:39.517' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (47, 5, 9, 6, N'Very Good', CAST(N'2025-03-25T11:51:39.517' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (48, 5, 9, 7, N'Good', CAST(N'2025-03-25T11:51:39.517' AS DateTime))
INSERT [dbo].[FeedbackAnswers] ([AnswerId], [FormId], [StudentId], [QuestionId], [Answer], [SubmittedAt]) VALUES (49, 5, 9, 8, N'Very Satisfied', CAST(N'2025-03-25T11:51:39.517' AS DateTime))
SET IDENTITY_INSERT [dbo].[FeedbackAnswers] OFF
GO
SET IDENTITY_INSERT [dbo].[FeedbackForms] ON 

INSERT [dbo].[FeedbackForms] ([FormId], [ClassId], [SubjectId], [TeacherId], [StartDate], [EndDate], [IsActive]) VALUES (1, 1, 1, 1, CAST(N'2025-04-01' AS Date), CAST(N'2025-04-30' AS Date), 1)
INSERT [dbo].[FeedbackForms] ([FormId], [ClassId], [SubjectId], [TeacherId], [StartDate], [EndDate], [IsActive]) VALUES (2, 2, 2, 1, CAST(N'2025-04-01' AS Date), CAST(N'2025-04-30' AS Date), 1)
INSERT [dbo].[FeedbackForms] ([FormId], [ClassId], [SubjectId], [TeacherId], [StartDate], [EndDate], [IsActive]) VALUES (3, 2, 2, 1, CAST(N'2025-03-16' AS Date), CAST(N'2025-03-17' AS Date), 1)
INSERT [dbo].[FeedbackForms] ([FormId], [ClassId], [SubjectId], [TeacherId], [StartDate], [EndDate], [IsActive]) VALUES (4, 3, 3, 7, CAST(N'2025-03-24' AS Date), CAST(N'2025-04-24' AS Date), 1)
INSERT [dbo].[FeedbackForms] ([FormId], [ClassId], [SubjectId], [TeacherId], [StartDate], [EndDate], [IsActive]) VALUES (5, 4, 4, 7, CAST(N'2025-03-25' AS Date), CAST(N'2025-04-25' AS Date), 1)
SET IDENTITY_INSERT [dbo].[FeedbackForms] OFF
GO
SET IDENTITY_INSERT [dbo].[FeedbackQuestions] ON 

INSERT [dbo].[FeedbackQuestions] ([QuestionId], [QuestionText]) VALUES (3, N'1. Regarding the teacher''s punctuality')
INSERT [dbo].[FeedbackQuestions] ([QuestionId], [QuestionText]) VALUES (4, N'2. The teacher adequately covers the topics required by the syllabus')
INSERT [dbo].[FeedbackQuestions] ([QuestionId], [QuestionText]) VALUES (5, N'3. Teacher''s response to student''s questions in class')
INSERT [dbo].[FeedbackQuestions] ([QuestionId], [QuestionText]) VALUES (6, N'4. Teaching skills of teacher')
INSERT [dbo].[FeedbackQuestions] ([QuestionId], [QuestionText]) VALUES (7, N'5. Support from the teacher - guidance for practical exercises, answering questions out side of class')
INSERT [dbo].[FeedbackQuestions] ([QuestionId], [QuestionText]) VALUES (8, N'6. To what extent are you pleased with the quality and effectiveness of the lecturer''s teaching and mentoring in your learning progress?')
INSERT [dbo].[FeedbackQuestions] ([QuestionId], [QuestionText]) VALUES (9, N'Comment')
SET IDENTITY_INSERT [dbo].[FeedbackQuestions] OFF
GO
SET IDENTITY_INSERT [dbo].[StudentClass] ON 

INSERT [dbo].[StudentClass] ([StudentClassId], [StudentId], [ClassId]) VALUES (1, 2, 1)
INSERT [dbo].[StudentClass] ([StudentClassId], [StudentId], [ClassId]) VALUES (2, 3, 2)
INSERT [dbo].[StudentClass] ([StudentClassId], [StudentId], [ClassId]) VALUES (3, 4, 3)
INSERT [dbo].[StudentClass] ([StudentClassId], [StudentId], [ClassId]) VALUES (4, 5, 4)
INSERT [dbo].[StudentClass] ([StudentClassId], [StudentId], [ClassId]) VALUES (5, 8, 4)
INSERT [dbo].[StudentClass] ([StudentClassId], [StudentId], [ClassId]) VALUES (6, 9, 4)
SET IDENTITY_INSERT [dbo].[StudentClass] OFF
GO
SET IDENTITY_INSERT [dbo].[Subjects] ON 

INSERT [dbo].[Subjects] ([SubjectId], [SubjectName], [CreatedAt]) VALUES (1, N'Lap trình Web', CAST(N'2025-03-16T00:36:34.093' AS DateTime))
INSERT [dbo].[Subjects] ([SubjectId], [SubjectName], [CreatedAt]) VALUES (2, N'Co so du lieu', CAST(N'2025-03-16T00:36:34.093' AS DateTime))
INSERT [dbo].[Subjects] ([SubjectId], [SubjectName], [CreatedAt]) VALUES (3, N'PRN231', CAST(N'2025-03-21T08:11:24.570' AS DateTime))
INSERT [dbo].[Subjects] ([SubjectId], [SubjectName], [CreatedAt]) VALUES (4, N'PRN221', CAST(N'2025-03-21T08:11:36.213' AS DateTime))
SET IDENTITY_INSERT [dbo].[Subjects] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [FullName], [Email], [PasswordHash], [Role], [CreatedAt]) VALUES (1, N'Nguyen Van A', N'teacher1@fe.edu.vn', N'12345', N'Teacher', CAST(N'2025-03-16T00:36:34.090' AS DateTime))
INSERT [dbo].[Users] ([UserId], [FullName], [Email], [PasswordHash], [Role], [CreatedAt]) VALUES (2, N'Tran Thi B', N'student1@fpt.edu.vn', N'12345', N'Student', CAST(N'2025-03-16T00:36:34.090' AS DateTime))
INSERT [dbo].[Users] ([UserId], [FullName], [Email], [PasswordHash], [Role], [CreatedAt]) VALUES (3, N'Lê Van C', N'student2@fpt.edu.vn', N'12345', N'Student', CAST(N'2025-03-16T00:36:34.090' AS DateTime))
INSERT [dbo].[Users] ([UserId], [FullName], [Email], [PasswordHash], [Role], [CreatedAt]) VALUES (4, N'Vu Hong Son', N'sonvhhe171961@fpt.edu.vn', N'12345', N'Student', CAST(N'2025-03-21T07:44:58.153' AS DateTime))
INSERT [dbo].[Users] ([UserId], [FullName], [Email], [PasswordHash], [Role], [CreatedAt]) VALUES (5, N'Nguyen Sinh Hung', N'hungnshe12345@fpt.edu.vn', N'12345', N'Student', CAST(N'2021-03-21T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([UserId], [FullName], [Email], [PasswordHash], [Role], [CreatedAt]) VALUES (7, N'Tien Dinh Ta', N'tientd17@fe.edu.vn', N'12345', N'Teacher', CAST(N'2021-02-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([UserId], [FullName], [Email], [PasswordHash], [Role], [CreatedAt]) VALUES (8, N'son1', N'abc@fpt.edu.vn', N'12345', N'Student', CAST(N'2025-03-25T11:44:43.430' AS DateTime))
INSERT [dbo].[Users] ([UserId], [FullName], [Email], [PasswordHash], [Role], [CreatedAt]) VALUES (9, N'son22', N'abcd@fpt.edu.vn', N'12345', N'Student', CAST(N'2025-03-25T11:50:49.313' AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__A9D10534999D6412]    Script Date: 3/27/2025 2:59:26 PM ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Classes] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[FeedbackAnswers] ADD  DEFAULT (getdate()) FOR [SubmittedAt]
GO
ALTER TABLE [dbo].[FeedbackForms] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Subjects] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[ClassAssignments]  WITH CHECK ADD FOREIGN KEY([ClassId])
REFERENCES [dbo].[Classes] ([ClassId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClassAssignments]  WITH CHECK ADD FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([SubjectId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClassAssignments]  WITH CHECK ADD FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FeedbackAnswers]  WITH CHECK ADD FOREIGN KEY([FormId])
REFERENCES [dbo].[FeedbackForms] ([FormId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FeedbackAnswers]  WITH CHECK ADD FOREIGN KEY([QuestionId])
REFERENCES [dbo].[FeedbackQuestions] ([QuestionId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FeedbackAnswers]  WITH CHECK ADD FOREIGN KEY([StudentId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[FeedbackForms]  WITH CHECK ADD FOREIGN KEY([ClassId])
REFERENCES [dbo].[Classes] ([ClassId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FeedbackForms]  WITH CHECK ADD FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([SubjectId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FeedbackForms]  WITH CHECK ADD FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentClass]  WITH CHECK ADD FOREIGN KEY([ClassId])
REFERENCES [dbo].[Classes] ([ClassId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentClass]  WITH CHECK ADD FOREIGN KEY([StudentId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD CHECK  (([Role]='Teacher' OR [Role]='Student'))
GO
