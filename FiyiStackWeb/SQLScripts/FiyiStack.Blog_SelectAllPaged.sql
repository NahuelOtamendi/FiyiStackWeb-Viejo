CREATE PROCEDURE [dbo].[FiyiStack.Blog.SelectAllPaged]
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
EXEC [dbo].[FiyiStack.Blog.SelectAllPaged]
    
    @QueryString = N'',
    @ActualPageNumber = 1,
    @RowsPerPage = 10,
    @SorterColumn = N'BlogId',
    @SortToggler = 0,
    @TotalRows = @TotalRows OUTPUT

SELECT @TotalRows AS N'@TotalRows'
*/

--Last modification on: 20/12/2022 22:25:19

SET DATEFORMAT DMY
SET NOCOUNT ON

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
    1=1
    AND (@QueryString = '' 
        OR ([FiyiStack.Blog].[BlogId] LIKE  '%' + @QueryString + '%')
        OR ([FiyiStack.Blog].[Active] LIKE  '%' + @QueryString + '%')
        OR ([FiyiStack.Blog].[DateTimeCreation] LIKE  '%' + @QueryString + '%')
        OR ([FiyiStack.Blog].[DateTimeLastModification] LIKE  '%' + @QueryString + '%')
        OR ([FiyiStack.Blog].[UserCreationId] LIKE  '%' + @QueryString + '%')
        OR ([FiyiStack.Blog].[UserLastModificationId] LIKE  '%' + @QueryString + '%')
        OR ([FiyiStack.Blog].[Title] LIKE  '%' + @QueryString + '%')
        OR ([FiyiStack.Blog].[Body] LIKE  '%' + @QueryString + '%')
        OR ([FiyiStack.Blog].[BackgroundImage] LIKE  '%' + @QueryString + '%')

    )
ORDER BY 
    CASE WHEN (@SorterColumn = 'BlogId' AND @SortToggler = 0) THEN [FiyiStack.Blog].[BlogId] END ASC,
    CASE WHEN (@SorterColumn = 'BlogId' AND @SortToggler = 1) THEN [FiyiStack.Blog].[BlogId] END DESC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 0) THEN [FiyiStack.Blog].[Active] END ASC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 1) THEN [FiyiStack.Blog].[Active] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 0) THEN [FiyiStack.Blog].[DateTimeCreation] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 1) THEN [FiyiStack.Blog].[DateTimeCreation] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 0) THEN [FiyiStack.Blog].[DateTimeLastModification] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 1) THEN [FiyiStack.Blog].[DateTimeLastModification] END DESC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 0) THEN [FiyiStack.Blog].[UserCreationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 1) THEN [FiyiStack.Blog].[UserCreationId] END DESC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 0) THEN [FiyiStack.Blog].[UserLastModificationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 1) THEN [FiyiStack.Blog].[UserLastModificationId] END DESC,
    CASE WHEN (@SorterColumn = 'Title' AND @SortToggler = 0) THEN [FiyiStack.Blog].[Title] END ASC,
    CASE WHEN (@SorterColumn = 'Title' AND @SortToggler = 1) THEN [FiyiStack.Blog].[Title] END DESC,
    CASE WHEN (@SorterColumn = 'Body' AND @SortToggler = 0) THEN [FiyiStack.Blog].[Body] END ASC,
    CASE WHEN (@SorterColumn = 'Body' AND @SortToggler = 1) THEN [FiyiStack.Blog].[Body] END DESC,
    CASE WHEN (@SorterColumn = 'BackgroundImage' AND @SortToggler = 0) THEN [FiyiStack.Blog].[BackgroundImage] END ASC,
    CASE WHEN (@SorterColumn = 'BackgroundImage' AND @SortToggler = 1) THEN [FiyiStack.Blog].[BackgroundImage] END DESC

OFFSET (@ActualPageNumber - 1) * @RowsPerPage ROWS
FETCH NEXT @RowsPerPage ROWS ONLY
SELECT @TotalRows = COUNT(*) FROM [FiyiStack.Blog]