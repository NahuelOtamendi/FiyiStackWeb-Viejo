USE [fiyistack_FiyiStackWeb]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

--Last modification on: 20/12/2022 20:18:05

ALTER TABLE [dbo].[BasicCulture.Sex] ADD [SexId] INT IDENTITY(1,1) NOT NULL
ALTER TABLE [dbo].[BasicCulture.Sex] ADD [Name] VARCHAR(500) NOT NULL
ALTER TABLE [dbo].[BasicCulture.Sex] ADD [Active] TINYINT NOT NULL
ALTER TABLE [dbo].[BasicCulture.Sex] ADD [UserCreationId] INT NOT NULL
ALTER TABLE [dbo].[BasicCulture.Sex] ADD [UserLastModificationId] INT NOT NULL
ALTER TABLE [dbo].[BasicCulture.Sex] ADD [DateTimeCreation] DATETIME NOT NULL
ALTER TABLE [dbo].[BasicCulture.Sex] ADD [DateTimeLastModification] DATETIME NOT NULL
