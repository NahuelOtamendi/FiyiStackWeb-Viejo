CREATE PROCEDURE [dbo].[FiyiStack.Blog.Select1ByBlogId]
(
    @BlogId INT
)

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
EXEC [dbo].[Blog.Select1ByBlogId]
    @BlogId = 1
 *
 */

--Last modification on: 20/12/2022 22:25:19

SET DATEFORMAT DMY

SELECT
    [FiyiStack.Blog].[BlogId],
    [FiyiStack.Blog].[Active],
    [FiyiStack.Blog].[DateTimeCreation],
    [FiyiStack.Blog].[DateTimeLastModification],
    [FiyiStack.Blog].[UserCreationId],
    [FiyiStack.Blog].[UserLastModificationId],
    [FiyiStack.Blog].[Title],
    [FiyiStack.Blog].[Body],
    [FiyiStack.Blog].[BackgroundImage]
FROM 
    [FiyiStack.Blog]
    LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserCreationId] ON [FiyiStack.Blog].[UserCreationId] = [CMSCore.User.UserCreationId].[UserId]
	LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserLastModificationId] ON [FiyiStack.Blog].[UserLastModificationId] = [CMSCore.User.UserLastModificationId].[UserId]
WHERE 
    1 = 1
    AND [FiyiStack.Blog].[BlogId] = @BlogId
ORDER BY 
    [FiyiStack.Blog].[BlogId]