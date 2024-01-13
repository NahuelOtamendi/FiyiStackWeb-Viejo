USE [fiyistack_FiyiStackWeb]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

--Last modification on: 20/12/2022 20:09:01

ALTER TABLE [dbo].[BasicCulture.Country] ADD [CountryId] INT IDENTITY(1,1) NOT NULL
ALTER TABLE [dbo].[BasicCulture.Country] ADD [Name] VARCHAR(500) NOT NULL
ALTER TABLE [dbo].[BasicCulture.Country] ADD [GeographicalCoordinates] VARCHAR(200) NOT NULL
ALTER TABLE [dbo].[BasicCulture.Country] ADD [Code] VARCHAR(100) NOT NULL
ALTER TABLE [dbo].[BasicCulture.Country] ADD [PlanetId] INT NOT NULL
ALTER TABLE [dbo].[BasicCulture.Country] ADD [Active] TINYINT NOT NULL
ALTER TABLE [dbo].[BasicCulture.Country] ADD [UserCreationId] INT NOT NULL
ALTER TABLE [dbo].[BasicCulture.Country] ADD [UserLastModificationId] INT NOT NULL
ALTER TABLE [dbo].[BasicCulture.Country] ADD [DateTimeCreation] DATETIME NOT NULL
ALTER TABLE [dbo].[BasicCulture.Country] ADD [DateTimeLastModification] DATETIME NOT NULL
