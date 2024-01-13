CREATE PROCEDURE [dbo].[FiyiStack.CommentForBlog.SelectAllPaged]
(
    @QueryString VARCHAR(100),
    @ActualPageNumber INT,
    @RowsPerPage INT,
    @SorterColumn VARCHAR(100),
    @SortToggler TINYINT,
    @TotalRows INT OUTPUT
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

/*Execute this stored procedure with the next script as example

DECLARE	@TotalRows int
EXEC [dbo].[FiyiStack.CommentForBlog.SelectAllPaged]
    
    @QueryString = N'',
    @ActualPageNumber = 1,
    @RowsPerPage = 10,
    @SorterColumn = N'CommentForBlogId',
    @SortToggler = 0,
    @TotalRows = @TotalRows OUTPUT

SELECT @TotalRows AS N'@TotalRows'
*/

--Last modification on: 20/12/2022 22:25:25

SET DATEFORMAT DMY
SET NOCOUNT ON

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
WHERE
    1=1
    AND (@QueryString = '' 
        OR ([FiyiStack.CommentForBlog].[CommentForBlogId] LIKE  '%' + @QueryString + '%')
        OR ([FiyiStack.CommentForBlog].[Active] LIKE  '%' + @QueryString + '%')
        OR ([FiyiStack.CommentForBlog].[DateTimeCreation] LIKE  '%' + @QueryString + '%')
        OR ([FiyiStack.CommentForBlog].[DateTimeLastModification] LIKE  '%' + @QueryString + '%')
        OR ([FiyiStack.CommentForBlog].[UserCreationId] LIKE  '%' + @QueryString + '%')
        OR ([FiyiStack.CommentForBlog].[UserLastModificationId] LIKE  '%' + @QueryString + '%')
        OR ([FiyiStack.CommentForBlog].[Comment] LIKE  '%' + @QueryString + '%')
        OR ([FiyiStack.CommentForBlog].[BlogId] LIKE  '%' + @QueryString + '%')

    )
ORDER BY 
    CASE WHEN (@SorterColumn = 'CommentForBlogId' AND @SortToggler = 0) THEN [FiyiStack.CommentForBlog].[CommentForBlogId] END ASC,
    CASE WHEN (@SorterColumn = 'CommentForBlogId' AND @SortToggler = 1) THEN [FiyiStack.CommentForBlog].[CommentForBlogId] END DESC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 0) THEN [FiyiStack.CommentForBlog].[Active] END ASC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 1) THEN [FiyiStack.CommentForBlog].[Active] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 0) THEN [FiyiStack.CommentForBlog].[DateTimeCreation] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 1) THEN [FiyiStack.CommentForBlog].[DateTimeCreation] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 0) THEN [FiyiStack.CommentForBlog].[DateTimeLastModification] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 1) THEN [FiyiStack.CommentForBlog].[DateTimeLastModification] END DESC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 0) THEN [FiyiStack.CommentForBlog].[UserCreationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 1) THEN [FiyiStack.CommentForBlog].[UserCreationId] END DESC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 0) THEN [FiyiStack.CommentForBlog].[UserLastModificationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 1) THEN [FiyiStack.CommentForBlog].[UserLastModificationId] END DESC,
    CASE WHEN (@SorterColumn = 'Comment' AND @SortToggler = 0) THEN [FiyiStack.CommentForBlog].[Comment] END ASC,
    CASE WHEN (@SorterColumn = 'Comment' AND @SortToggler = 1) THEN [FiyiStack.CommentForBlog].[Comment] END DESC,
    CASE WHEN (@SorterColumn = 'BlogId' AND @SortToggler = 0) THEN [FiyiStack.CommentForBlog].[BlogId] END ASC,
    CASE WHEN (@SorterColumn = 'BlogId' AND @SortToggler = 1) THEN [FiyiStack.CommentForBlog].[BlogId] END DESC

OFFSET (@ActualPageNumber - 1) * @RowsPerPage ROWS
FETCH NEXT @RowsPerPage ROWS ONLY
SELECT @TotalRows = COUNT(*) FROM [FiyiStack.CommentForBlog]