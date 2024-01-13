USE [fiyistack_FiyiStackWeb]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

--Last modification on: 20/12/2022 19:56:32

ALTER TABLE [dbo].[BasicCore.Parameter] ADD [ParameterId] INT IDENTITY(1,1) NOT NULL
ALTER TABLE [dbo].[BasicCore.Parameter] ADD [Name] VARCHAR(200) NOT NULL
ALTER TABLE [dbo].[BasicCore.Parameter] ADD [Value] VARCHAR(8000) NOT NULL
ALTER TABLE [dbo].[BasicCore.Parameter] ADD [IsPrivate] TINYINT NOT NULL
ALTER TABLE [dbo].[BasicCore.Parameter] ADD [Active] TINYINT NOT NULL
ALTER TABLE [dbo].[BasicCore.Parameter] ADD [UserCreationId] INT NOT NULL
ALTER TABLE [dbo].[BasicCore.Parameter] ADD [UserLastModificationId] INT NOT NULL
ALTER TABLE [dbo].[BasicCore.Parameter] ADD [DateTimeCreation] DATETIME NOT NULL
ALTER TABLE [dbo].[BasicCore.Parameter] ADD [DateTimeLastModification] DATETIME NOT NULL
