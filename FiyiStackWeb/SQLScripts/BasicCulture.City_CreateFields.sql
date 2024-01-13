USE [fiyistack_FiyiStackWeb]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

--Last modification on: 20/12/2022 20:06:24

ALTER TABLE [dbo].[BasicCulture.City] ADD [CityId] INT IDENTITY(1,1) NOT NULL
ALTER TABLE [dbo].[BasicCulture.City] ADD [Name] VARCHAR(500) NOT NULL
ALTER TABLE [dbo].[BasicCulture.City] ADD [GeographicalCoordinates] VARCHAR(200) NOT NULL
ALTER TABLE [dbo].[BasicCulture.City] ADD [Code] VARCHAR(100) NOT NULL
ALTER TABLE [dbo].[BasicCulture.City] ADD [ProvinceId] INT NOT NULL
ALTER TABLE [dbo].[BasicCulture.City] ADD [Active] TINYINT NOT NULL
ALTER TABLE [dbo].[BasicCulture.City] ADD [UserCreationId] INT NOT NULL
ALTER TABLE [dbo].[BasicCulture.City] ADD [UserLastModificationId] INT NOT NULL
ALTER TABLE [dbo].[BasicCulture.City] ADD [DateTimeCreation] DATETIME NOT NULL
ALTER TABLE [dbo].[BasicCulture.City] ADD [DateTimeLastModification] DATETIME NOT NULL
