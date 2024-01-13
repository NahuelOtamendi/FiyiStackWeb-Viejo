USE [fiyistack_FiyiStackWeb]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

--Last modification on: 20/12/2022 20:14:59

ALTER TABLE [dbo].[BasicCulture.Province] ADD [ProvinceId] INT IDENTITY(1,1) NOT NULL
ALTER TABLE [dbo].[BasicCulture.Province] ADD [Name] VARCHAR(500) NOT NULL
ALTER TABLE [dbo].[BasicCulture.Province] ADD [GeographicalCoordinates] VARCHAR(200) NOT NULL
ALTER TABLE [dbo].[BasicCulture.Province] ADD [Code] VARCHAR(100) NOT NULL
ALTER TABLE [dbo].[BasicCulture.Province] ADD [CountryId] INT NOT NULL
ALTER TABLE [dbo].[BasicCulture.Province] ADD [Active] TINYINT NOT NULL
ALTER TABLE [dbo].[BasicCulture.Province] ADD [UserCreationId] INT NOT NULL
ALTER TABLE [dbo].[BasicCulture.Province] ADD [UserLastModificationId] INT NOT NULL
ALTER TABLE [dbo].[BasicCulture.Province] ADD [DateTimeCreation] DATETIME NOT NULL
ALTER TABLE [dbo].[BasicCulture.Province] ADD [DateTimeLastModification] DATETIME NOT NULL
