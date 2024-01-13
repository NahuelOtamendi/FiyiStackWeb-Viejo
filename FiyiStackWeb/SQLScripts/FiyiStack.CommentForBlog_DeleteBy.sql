CREATE PROCEDURE [dbo].[FiyiStack.CommentForBlog.DeleteByCommentForBlogId]
(
    @CommentForBlogId INT,
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
DECLARE	@RowsAffected INT
EXEC [dbo].[FiyiStack.CommentForBlog.DeleteByCommentForBlogId]
    @CommentForBlogId = 1,
    @RowsAffected = @RowsAffected OUTPUT
SELECT @RowsAffected AS N'@RowsAffected'
 *
 */

--Last modification on: 20/12/2022 22:25:25

DELETE FROM 
    [FiyiStack.CommentForBlog]
WHERE 
    1 = 1
    AND [FiyiStack.CommentForBlog].[CommentForBlogId] = @CommentForBlogId

SELECT @RowsAffected = @@ROWCOUNT]
WHERE 
    1 = 1
    AND [FiyiStack.CommentForBlog].[CommentForBlogId] = @CommentForBlogId

SELECT @RowsAffected = @@ROWCOUNT