USE [fiyistack_FiyiStackWeb]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

--Last modification on: 20/12/2022 20:47:32

ALTER TABLE [dbo].[CMSCore.Role] ADD [RoleId] INT IDENTITY(1,1) NOT NULL
ALTER TABLE [dbo].[CMSCore.Role] ADD [Name] VARCHAR(200) NOT NULL
ALTER TABLE [dbo].[CMSCore.Role] ADD [Active] TINYINT NOT NULL
ALTER TABLE [dbo].[CMSCore.Role] ADD [UserCreationId] INT NOT NULL
ALTER TABLE [dbo].[CMSCore.Role] ADD [UserLastModificationId] INT NOT NULL
ALTER TABLE [dbo].[CMSCore.Role] ADD [DateTimeCreation] DATETIME NOT NULL
ALTER TABLE [dbo].[CMSCore.Role] ADD [DateTimeLastModification] DATETIME NOT NULL
