USE [DepInj]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210517152242_inittt', N'5.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210517205304_sgsqsq', N'5.0.6')
GO
SET IDENTITY_INSERT [dbo].[Teams] ON 

INSERT [dbo].[Teams] ([Id], [Name], [Position], [Surname], [Image]) VALUES (5, N'Avril', N'Singer', N'Lavin', N'496ef4a7-beb5-4e04-a123-48262adf9bc8-18.05.2021.03.28.19-team-1.jpg')
SET IDENTITY_INSERT [dbo].[Teams] OFF
GO
