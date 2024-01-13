USE [fiyistack_FiyiStackWeb]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

--Last modification on: 08/12/2022 6:38:41

ALTER TABLE [dbo].[Failure] ADD [FailureId] INT IDENTITY(1,1) NOT NULL
ALTER TABLE [dbo].[Failure] ADD [HTTPCode] INT NOT NULL
ALTER TABLE [dbo].[Failure] ADD [EmergencyLevel] INT NOT NULL
ALTER TABLE [dbo].[Failure] ADD [Message] VARCHAR(8000)NOT NULL
ALTER TABLE [dbo].[Failure] ADD [StackTrace] VARCHAR(8000)NOT NULL
ALTER TABLE [dbo].[Failure] ADD [Source] VARCHAR(8000)NOT NULL
ALTER TABLE [dbo].[Failure] ADD [Comment] VARCHAR(8000)NOT NULL
ALTER TABLE [dbo].[Failure] ADD [Active] TINYINT NOT NULL
ALTER TABLE [dbo].[Failure] ADD [UserCreationId] INT NOT NULL
ALTER TABLE [dbo].[Failure] ADD [UserLastModificationId] INT NOT NULL
ALTER TABLE [dbo].[Failure] ADD [DateTimeCreation] DATETIME NOT NULL
ALTER TABLE [dbo].[Failure] ADD [DateTimeLastModification] DATETIME NOT NULL

