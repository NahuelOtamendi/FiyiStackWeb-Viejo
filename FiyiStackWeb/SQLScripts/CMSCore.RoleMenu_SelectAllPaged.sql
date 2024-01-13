CREATE PROCEDURE [dbo].[CMSCore.RoleMenu.SelectAllPaged]
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
EXEC [dbo].[CMSCore.RoleMenu.SelectAllPaged]
    
    @QueryString = N'',
    @ActualPageNumber = 1,
    @RowsPerPage = 10,
    @SorterColumn = N'RoleMenuId',
    @SortToggler = 0,
    @TotalRows = @TotalRows OUTPUT

SELECT @TotalRows AS N'@TotalRows'
*/

--Last modification on: 20/12/2022 20:28:32

SET DATEFORMAT DMY
SET NOCOUNT ON

SELECT
    [CMSCore.RoleMenu].[RoleMenuId],
    [CMSCore.RoleMenu].[RoleId],
    [CMSCore.RoleMenu].[MenuId],
    [CMSCore.RoleMenu].[Active],
    [CMSCore.RoleMenu].[UserCreationId],
    [CMSCore.RoleMenu].[UserLastModificationId],
    [CMSCore.RoleMenu].[DateTimeCreation],
    [CMSCore.RoleMenu].[DateTimeLastModification]
FROM 
    [CMSCore.RoleMenu]
    LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserCreationId] ON [CMSCore.RoleMenu].[UserCreationId] = [CMSCore.User.UserCreationId].[UserId]
	LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserLastModificationId] ON [CMSCore.RoleMenu].[UserLastModificationId] = [CMSCore.User.UserLastModificationId].[UserId]
WHERE
    1=1
    AND (@QueryString = '' 
        OR ([CMSCore.RoleMenu].[RoleMenuId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.RoleMenu].[RoleId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.RoleMenu].[MenuId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.RoleMenu].[Active] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.RoleMenu].[UserCreationId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.RoleMenu].[UserLastModificationId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.RoleMenu].[DateTimeCreation] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.RoleMenu].[DateTimeLastModification] LIKE  '%' + @QueryString + '%')

    )
ORDER BY 
    CASE WHEN (@SorterColumn = 'RoleMenuId' AND @SortToggler = 0) THEN [CMSCore.RoleMenu].[RoleMenuId] END ASC,
    CASE WHEN (@SorterColumn = 'RoleMenuId' AND @SortToggler = 1) THEN [CMSCore.RoleMenu].[RoleMenuId] END DESC,
    CASE WHEN (@SorterColumn = 'RoleId' AND @SortToggler = 0) THEN [CMSCore.RoleMenu].[RoleId] END ASC,
    CASE WHEN (@SorterColumn = 'RoleId' AND @SortToggler = 1) THEN [CMSCore.RoleMenu].[RoleId] END DESC,
    CASE WHEN (@SorterColumn = 'MenuId' AND @SortToggler = 0) THEN [CMSCore.RoleMenu].[MenuId] END ASC,
    CASE WHEN (@SorterColumn = 'MenuId' AND @SortToggler = 1) THEN [CMSCore.RoleMenu].[MenuId] END DESC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 0) THEN [CMSCore.RoleMenu].[Active] END ASC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 1) THEN [CMSCore.RoleMenu].[Active] END DESC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 0) THEN [CMSCore.RoleMenu].[UserCreationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 1) THEN [CMSCore.RoleMenu].[UserCreationId] END DESC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 0) THEN [CMSCore.RoleMenu].[UserLastModificationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 1) THEN [CMSCore.RoleMenu].[UserLastModificationId] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 0) THEN [CMSCore.RoleMenu].[DateTimeCreation] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 1) THEN [CMSCore.RoleMenu].[DateTimeCreation] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 0) THEN [CMSCore.RoleMenu].[DateTimeLastModification] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 1) THEN [CMSCore.RoleMenu].[DateTimeLastModification] END DESC

OFFSET (@ActualPageNumber - 1) * @RowsPerPage ROWS
FETCH NEXT @RowsPerPage ROWS ONLY
SELECT @TotalRows = COUNT(*) FROM [CMSCore.RoleMenu]