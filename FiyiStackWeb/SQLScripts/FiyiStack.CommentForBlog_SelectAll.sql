CREATE PROCEDURE [dbo].[FiyiStack.CommentForBlog.SelectAll]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * 
 * Coded by fiyistack.com
 * Copyright © 2022
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[FiyiStack.CommentForBlog.SelectAll]
 *
 */

--Last modification on: 20/12/2022 22:25:25

SET DATEFORMAT DMY

SELECT
    [FiyiStack.CommentForBlog].[CommentForBlogId],
    [FiyiStack.CommentForBlog].[Active],
    [FiyiStack.CommentForBlog].[DateTimeCreation],
    [FiyiStack.CommentForBlog].[DateTimeLastModification],
    [FiyiStack.CommentForBlog].[UserCreationId],
    [FiyiStack.CommentForBlog].[UserLastModificationId],
    [FiyiStack.CommentForBlog].[Comment],
    [FiyiStack.CommentForBlog].[BlogId]
FROM 
    [FiyiStack.CommentForBlog]
    LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserCreationId] ON [FiyiStack.CommentForBlog].[UserCreationId] = [CMSCore.User.UserCreationId].[UserId]
	LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserLastModificationId] ON [FiyiStack.CommentForBlog].[UserLastModificationId] = [CMSCore.User.UserLastModificationId].[UserId]
ORDER BY 
    [FiyiStack.CommentForBlog].[CommentForBlogId]