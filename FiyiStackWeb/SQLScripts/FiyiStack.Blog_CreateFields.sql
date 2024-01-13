USE [fiyistack_FiyiStackWeb]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

--Last modification on: 20/12/2022 22:25:19

ALTER TABLE [dbo].[FiyiStack.Blog] ADD [BlogId] INT IDENTITY(1,1) NOT NULL
ALTER TABLE [dbo].[FiyiStack.Blog] ADD [Active] TINYINT NOT NULL
ALTER TABLE [dbo].[FiyiStack.Blog] ADD [DateTimeCreation] DATETIME NOT NULL
ALTER TABLE [dbo].[FiyiStack.Blog] ADD [DateTimeLastModification] DATETIME NOT NULL
ALTER TABLE [dbo].[FiyiStack.Blog] ADD [UserCreationId] INT NOT NULL
ALTER TABLE [dbo].[FiyiStack.Blog] ADD [UserLastModificationId] INT NOT NULL
ALTER TABLE [dbo].[FiyiStack.Blog] ADD [Title] VARCHAR(100) NOT NULL
ALTER TABLE [dbo].[FiyiStack.Blog] ADD [Body] VARCHAR(8000) NOT NULL
ALTER TABLE [dbo].[FiyiStack.Blog] ADD [BackgroundImage] VARCHAR(8000) NOT NULL
