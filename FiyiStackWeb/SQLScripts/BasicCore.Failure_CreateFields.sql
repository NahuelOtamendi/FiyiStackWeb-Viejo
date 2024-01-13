USE [fiyistack_FiyiStackWeb]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

--Last modification on: 20/12/2022 19:54:13

ALTER TABLE [dbo].[BasicCore.Failure] ADD [FailureId] INT IDENTITY(1,1) NOT NULL
ALTER TABLE [dbo].[BasicCore.Failure] ADD [HTTPCode] INT NOT NULL
ALTER TABLE [dbo].[BasicCore.Failure] ADD [EmergencyLevel] INT NOT NULL
ALTER TABLE [dbo].[BasicCore.Failure] ADD [Message] VARCHAR(8000) NOT NULL
ALTER TABLE [dbo].[BasicCore.Failure] ADD [StackTrace] VARCHAR(8000) NOT NULL
ALTER TABLE [dbo].[BasicCore.Failure] ADD [Source] VARCHAR(8000) NOT NULL
ALTER TABLE [dbo].[BasicCore.Failure] ADD [Comment] VARCHAR(8000) NOT NULL
ALTER TABLE [dbo].[BasicCore.Failure] ADD [Active] TINYINT NOT NULL
ALTER TABLE [dbo].[BasicCore.Failure] ADD [UserCreationId] INT NOT NULL
ALTER TABLE [dbo].[BasicCore.Failure] ADD [UserLastModificationId] INT NOT NULL
ALTER TABLE [dbo].[BasicCore.Failure] ADD [DateTimeCreation] DATETIME NOT NULL
ALTER TABLE [dbo].[BasicCore.Failure] ADD [DateTimeLastModification] DATETIME NOT NULL
