USE [fiyistack_FiyiStackWeb]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

--Last modification on: 20/12/2022 20:12:21

ALTER TABLE [dbo].[BasicCulture.Planet] ADD [PlanetId] INT IDENTITY(1,1) NOT NULL
ALTER TABLE [dbo].[BasicCulture.Planet] ADD [Name] VARCHAR(500) NOT NULL
ALTER TABLE [dbo].[BasicCulture.Planet] ADD [Code] VARCHAR(100) NOT NULL
ALTER TABLE [dbo].[BasicCulture.Planet] ADD [Active] TINYINT NOT NULL
ALTER TABLE [dbo].[BasicCulture.Planet] ADD [UserCreationId] INT NOT NULL
ALTER TABLE [dbo].[BasicCulture.Planet] ADD [UserLastModificationId] INT NOT NULL
ALTER TABLE [dbo].[BasicCulture.Planet] ADD [DateTimeCreation] DATETIME NOT NULL
ALTER TABLE [dbo].[BasicCulture.Planet] ADD [DateTimeLastModification] DATETIME NOT NULL
