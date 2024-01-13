CREATE PROCEDURE [dbo].[FiyiStack.CommentForBlog.UpdateByCommentForBlogId]
(
    @CommentForBlogId INT,
    @Active TINYINT,
    @DateTimeCreation DATETIME,
    @DateTimeLastModification DATETIME,
    @UserCreationId INT,
    @UserLastModificationId INT,
    @Comment VARCHAR(8000),
    @BlogId INT,

    @RowsAffected INT OUTPUT
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
DECLARE	@RowsAffected int
EXEC [dbo].[FiyiStack.CommentForBlog.UpdateByCommentForBlogId]
    @CommentForBlogId = 1,
    @RowsAffected = @RowsAffected OUTPUT
SELECT @RowsAffected AS N'@RowsAffected'
 *
 */

--Last modification on: 20/12/2022 22:25:25

UPDATE [FiyiStack.CommentForBlog] SET
    [Active] = @Active,
    [DateTimeCreation] = @DateTimeCreation,
    [DateTimeLastModification] = @DateTimeLastModification,
    [UserCreationId] = @UserCreationId,
    [UserLastModificationId] = @UserLastModificationId,
    [Comment] = @Comment,
    [BlogId] = @BlogId
WHERE 
    1 = 1 
    AND [FiyiStack.CommentForBlog].[CommentForBlogId] = @CommentForBlogId 

SELECT @RowsAffected = @@ROWCOUNT
WHERE 
    1 = 1 
    AND [FiyiStack.CommentForBlog].[CommentForBlogId] = @CommentForBlogId 

SELECT @RowsAffected = @@ROWCOUNT