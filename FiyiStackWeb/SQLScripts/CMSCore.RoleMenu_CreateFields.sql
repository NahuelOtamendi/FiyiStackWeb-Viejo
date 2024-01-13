USE [fiyistack_FiyiStackWeb]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

--Last modification on: 20/12/2022 20:28:32

ALTER TABLE [dbo].[CMSCore.RoleMenu] ADD [RoleMenuId] INT IDENTITY(1,1) NOT NULL
ALTER TABLE [dbo].[CMSCore.RoleMenu] ADD [RoleId] INT NOT NULL
ALTER TABLE [dbo].[CMSCore.RoleMenu] ADD [MenuId] INT NOT NULL
ALTER TABLE [dbo].[CMSCore.RoleMenu] ADD [Active] TINYINT NOT NULL
ALTER TABLE [dbo].[CMSCore.RoleMenu] ADD [UserCreationId] INT NOT NULL
ALTER TABLE [dbo].[CMSCore.RoleMenu] ADD [UserLastModificationId] INT NOT NULL
ALTER TABLE [dbo].[CMSCore.RoleMenu] ADD [DateTimeCreation] DATETIME NOT NULL
ALTER TABLE [dbo].[CMSCore.RoleMenu] ADD [DateTimeLastModification] DATETIME NOT NULL
