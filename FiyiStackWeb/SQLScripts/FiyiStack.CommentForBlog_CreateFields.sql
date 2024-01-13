USE [fiyistack_FiyiStackWeb]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

--Last modification on: 20/12/2022 22:25:25

ALTER TABLE [dbo].[FiyiStack.CommentForBlog] ADD [CommentForBlogId] INT IDENTITY(1,1) NOT NULL
ALTER TABLE [dbo].[FiyiStack.CommentForBlog] ADD [Active] TINYINT NOT NULL
ALTER TABLE [dbo].[FiyiStack.CommentForBlog] ADD [DateTimeCreation] DATETIME NOT NULL
ALTER TABLE [dbo].[FiyiStack.CommentForBlog] ADD [DateTimeLastModification] DATETIME NOT NULL
ALTER TABLE [dbo].[FiyiStack.CommentForBlog] ADD [UserCreationId] INT NOT NULL
ALTER TABLE [dbo].[FiyiStack.CommentForBlog] ADD [UserLastModificationId] INT NOT NULL
ALTER TABLE [dbo].[FiyiStack.CommentForBlog] ADD [Comment] VARCHAR(8000) NOT NULL
ALTER TABLE [dbo].[FiyiStack.CommentForBlog] ADD [BlogId] INT NOT NULL
