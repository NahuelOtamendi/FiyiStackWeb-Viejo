CREATE PROCEDURE [dbo].[CMSCore.Menu.SelectAllPaged]
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
EXEC [dbo].[CMSCore.Menu.SelectAllPaged]
    
    @QueryString = N'',
    @ActualPageNumber = 1,
    @RowsPerPage = 10,
    @SorterColumn = N'MenuId',
    @SortToggler = 0,
    @TotalRows = @TotalRows OUTPUT

SELECT @TotalRows AS N'@TotalRows'
*/

--Last modification on: 20/12/2022 20:22:13

SET DATEFORMAT DMY
SET NOCOUNT ON

SELECT
    [CMSCore.Menu].[MenuId],
    [CMSCore.Menu].[Name],
    [CMSCore.Menu].[MenuFatherId],
    [CMSCore.Menu].[Order],
    [CMSCore.Menu].[URLPath],
    [CMSCore.Menu].[IconURLPath],
    [CMSCore.Menu].[Active],
    [CMSCore.Menu].[UserCreationId],
    [CMSCore.Menu].[UserLastModificationId],
    [CMSCore.Menu].[DateTimeCreation],
    [CMSCore.Menu].[DateTimeLastModification]
FROM 
    [CMSCore.Menu]
    LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserCreationId] ON [CMSCore.Menu].[UserCreationId] = [CMSCore.User.UserCreationId].[UserId]
	LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserLastModificationId] ON [CMSCore.Menu].[UserLastModificationId] = [CMSCore.User.UserLastModificationId].[UserId]
WHERE
    1=1
    AND (@QueryString = '' 
        OR ([CMSCore.Menu].[MenuId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Menu].[Name] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Menu].[MenuFatherId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Menu].[Order] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Menu].[URLPath] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Menu].[IconURLPath] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Menu].[Active] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Menu].[UserCreationId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Menu].[UserLastModificationId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Menu].[DateTimeCreation] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Menu].[DateTimeLastModification] LIKE  '%' + @QueryString + '%')

    )
ORDER BY 
    CASE WHEN (@SorterColumn = 'MenuId' AND @SortToggler = 0) THEN [CMSCore.Menu].[MenuId] END ASC,
    CASE WHEN (@SorterColumn = 'MenuId' AND @SortToggler = 1) THEN [CMSCore.Menu].[MenuId] END DESC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 0) THEN [CMSCore.Menu].[Name] END ASC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 1) THEN [CMSCore.Menu].[Name] END DESC,
    CASE WHEN (@SorterColumn = 'MenuFatherId' AND @SortToggler = 0) THEN [CMSCore.Menu].[MenuFatherId] END ASC,
    CASE WHEN (@SorterColumn = 'MenuFatherId' AND @SortToggler = 1) THEN [CMSCore.Menu].[MenuFatherId] END DESC,
    CASE WHEN (@SorterColumn = 'Order' AND @SortToggler = 0) THEN [CMSCore.Menu].[Order] END ASC,
    CASE WHEN (@SorterColumn = 'Order' AND @SortToggler = 1) THEN [CMSCore.Menu].[Order] END DESC,
    CASE WHEN (@SorterColumn = 'URLPath' AND @SortToggler = 0) THEN [CMSCore.Menu].[URLPath] END ASC,
    CASE WHEN (@SorterColumn = 'URLPath' AND @SortToggler = 1) THEN [CMSCore.Menu].[URLPath] END DESC,
    CASE WHEN (@SorterColumn = 'IconURLPath' AND @SortToggler = 0) THEN [CMSCore.Menu].[IconURLPath] END ASC,
    CASE WHEN (@SorterColumn = 'IconURLPath' AND @SortToggler = 1) THEN [CMSCore.Menu].[IconURLPath] END DESC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 0) THEN [CMSCore.Menu].[Active] END ASC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 1) THEN [CMSCore.Menu].[Active] END DESC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 0) THEN [CMSCore.Menu].[UserCreationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 1) THEN [CMSCore.Menu].[UserCreationId] END DESC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 0) THEN [CMSCore.Menu].[UserLastModificationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 1) THEN [CMSCore.Menu].[UserLastModificationId] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 0) THEN [CMSCore.Menu].[DateTimeCreation] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 1) THEN [CMSCore.Menu].[DateTimeCreation] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 0) THEN [CMSCore.Menu].[DateTimeLastModification] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 1) THEN [CMSCore.Menu].[DateTimeLastModification] END DESC

OFFSET (@ActualPageNumber - 1) * @RowsPerPage ROWS
FETCH NEXT @RowsPerPage ROWS ONLY
SELECT @TotalRows = COUNT(*) FROM [CMSCore.Menu]