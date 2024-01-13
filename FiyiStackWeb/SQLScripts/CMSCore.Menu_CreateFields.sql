USE [fiyistack_FiyiStackWeb]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

--Last modification on: 20/12/2022 20:22:13

ALTER TABLE [dbo].[CMSCore.Menu] ADD [MenuId] INT IDENTITY(1,1) NOT NULL
ALTER TABLE [dbo].[CMSCore.Menu] ADD [Name] VARCHAR(200) NOT NULL
ALTER TABLE [dbo].[CMSCore.Menu] ADD [MenuFatherId] INT NOT NULL
ALTER TABLE [dbo].[CMSCore.Menu] ADD [Order] INT NOT NULL
ALTER TABLE [dbo].[CMSCore.Menu] ADD [URLPath] VARCHAR(8000) NOT NULL
ALTER TABLE [dbo].[CMSCore.Menu] ADD [IconURLPath] VARCHAR(8000) NOT NULL
ALTER TABLE [dbo].[CMSCore.Menu] ADD [Active] TINYINT NOT NULL
ALTER TABLE [dbo].[CMSCore.Menu] ADD [UserCreationId] INT NOT NULL
ALTER TABLE [dbo].[CMSCore.Menu] ADD [UserLastModificationId] INT NOT NULL
ALTER TABLE [dbo].[CMSCore.Menu] ADD [DateTimeCreation] DATETIME NOT NULL
ALTER TABLE [dbo].[CMSCore.Menu] ADD [DateTimeLastModification] DATETIME NOT NULL
