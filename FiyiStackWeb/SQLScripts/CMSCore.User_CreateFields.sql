USE [fiyistack_FiyiStackWeb]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

--Last modification on: 20/12/2022 21:44:06

ALTER TABLE [dbo].[CMSCore.User] ADD [UserId] INT IDENTITY(1,1) NOT NULL
ALTER TABLE [dbo].[CMSCore.User] ADD [FantasyName] VARCHAR(200) NOT NULL
ALTER TABLE [dbo].[CMSCore.User] ADD [Email] VARCHAR(320) NOT NULL
ALTER TABLE [dbo].[CMSCore.User] ADD [Password] VARCHAR(8000) NOT NULL
ALTER TABLE [dbo].[CMSCore.User] ADD [RoleId] INT NOT NULL
ALTER TABLE [dbo].[CMSCore.User] ADD [Active] TINYINT NOT NULL
ALTER TABLE [dbo].[CMSCore.User] ADD [UserCreationId] INT NOT NULL
ALTER TABLE [dbo].[CMSCore.User] ADD [UserLastModificationId] INT NOT NULL
ALTER TABLE [dbo].[CMSCore.User] ADD [DateTimeCreation] DATETIME NOT NULL
ALTER TABLE [dbo].[CMSCore.User] ADD [DateTimeLastModification] DATETIME NOT NULL
ALTER TABLE [dbo].[CMSCore.User] ADD [RegistrationToken] VARCHAR(8000) NOT NULL
