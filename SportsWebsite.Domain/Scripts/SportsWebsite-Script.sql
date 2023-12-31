USE [aspnet-SprotsWebsite-8a8ad126-c42c-4008-a0ab-7b5e713cd456]
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'369c26a0-eefe-47e7-880b-713b9cb25ac4', N'Admin@Gmail.com', N'ADMIN@GMAIL.COM', N'Admin@Gmail.com', N'ADMIN@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEKJDckK7bcXzPCn6WrR+Pva/MDx8qnz5rGTo8B1OJl3SmDlT1QJBcq/yMhf4UgIicw==', N'JQPXVHHBRBQSZQZTWHB3CR6BUGFO6GY4', N'553707d5-c253-4e43-bbe2-080ca7742c4d', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Images] ON 

INSERT [dbo].[Images] ([Id], [PhotoName], [IsDeleted]) VALUES (1, N'grgkfbvg.pnm.png', 0)
INSERT [dbo].[Images] ([Id], [PhotoName], [IsDeleted]) VALUES (2, N'33chlegc.taq.png', 0)
INSERT [dbo].[Images] ([Id], [PhotoName], [IsDeleted]) VALUES (3, N'lyozt13e.4yz.png', 0)
INSERT [dbo].[Images] ([Id], [PhotoName], [IsDeleted]) VALUES (4, N'yjm5tdiv.c1i.png', 0)
INSERT [dbo].[Images] ([Id], [PhotoName], [IsDeleted]) VALUES (5, N'bxbk00xz.jn1.png', 0)
SET IDENTITY_INSERT [dbo].[Images] OFF
GO
SET IDENTITY_INSERT [dbo].[Teams] ON 

INSERT [dbo].[Teams] ([Id], [Name], [Description], [WebsiteURL], [FoundationDate], [ImageId], [IsDeleted], [CreatedAt]) VALUES (1, N'Al-Ahly', N'Red Team', N'https://www.alahlyegypt.com/', CAST(N'1907-01-01T00:00:00.0000000' AS DateTime2), 1, 0, CAST(N'2023-11-13T19:42:59.5295273' AS DateTime2))
INSERT [dbo].[Teams] ([Id], [Name], [Description], [WebsiteURL], [FoundationDate], [ImageId], [IsDeleted], [CreatedAt]) VALUES (2, N'Zamalek', N'White Team', N'https://www.zamalektoday.com/', CAST(N'1911-01-01T00:00:00.0000000' AS DateTime2), 2, 0, CAST(N'2023-11-13T19:44:48.0303340' AS DateTime2))
INSERT [dbo].[Teams] ([Id], [Name], [Description], [WebsiteURL], [FoundationDate], [ImageId], [IsDeleted], [CreatedAt]) VALUES (3, N'Pyramids', N'Blue Team', N'https://pyramidsfc.com', CAST(N'2018-01-01T00:00:00.0000000' AS DateTime2), 3, 0, CAST(N'2023-11-13T19:45:44.8622412' AS DateTime2))
INSERT [dbo].[Teams] ([Id], [Name], [Description], [WebsiteURL], [FoundationDate], [ImageId], [IsDeleted], [CreatedAt]) VALUES (4, N'Al Ittihad Alexandria', N'Green Team', N'https://www.itthadclub.com/', CAST(N'1914-01-01T00:00:00.0000000' AS DateTime2), 4, 0, CAST(N'2023-11-13T20:00:56.9691544' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Teams] OFF
GO
SET IDENTITY_INSERT [dbo].[Tournaments] ON 

INSERT [dbo].[Tournaments] ([Id], [Name], [Description], [IsDeleted], [ImageId], [VideoUrl]) VALUES (1, N'Egyptian Premier League', N'League', 0, 5, N'https://www.youtube.com/embed/9PBHTQKTUb4?si=Cp26r2wPfthNKRv3')
SET IDENTITY_INSERT [dbo].[Tournaments] OFF
GO
SET IDENTITY_INSERT [dbo].[Players] ON 

INSERT [dbo].[Players] ([Id], [Name], [DateOfBirth], [TeamId], [IsDeleted]) VALUES (1, N'Emam Ashour', CAST(N'1998-02-20T00:00:00.0000000' AS DateTime2), 1, 0)
INSERT [dbo].[Players] ([Id], [Name], [DateOfBirth], [TeamId], [IsDeleted]) VALUES (2, N'Shikabala', CAST(N'1986-03-05T00:00:00.0000000' AS DateTime2), 2, 0)
INSERT [dbo].[Players] ([Id], [Name], [DateOfBirth], [TeamId], [IsDeleted]) VALUES (3, N'Mohamed El-Shenawy', CAST(N'1988-12-18T00:00:00.0000000' AS DateTime2), 1, 0)
SET IDENTITY_INSERT [dbo].[Players] OFF
GO
SET IDENTITY_INSERT [dbo].[TournamentsTeams] ON 

INSERT [dbo].[TournamentsTeams] ([Id], [TeamId], [TournamentId], [IsDeleted]) VALUES (1, 1, 1, 0)
INSERT [dbo].[TournamentsTeams] ([Id], [TeamId], [TournamentId], [IsDeleted]) VALUES (2, 2, 1, 0)
INSERT [dbo].[TournamentsTeams] ([Id], [TeamId], [TournamentId], [IsDeleted]) VALUES (3, 3, 1, 0)
SET IDENTITY_INSERT [dbo].[TournamentsTeams] OFF
GO

