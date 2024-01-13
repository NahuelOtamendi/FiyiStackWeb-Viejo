CREATE PROCEDURE [dbo].[CMSCore.Role.SelectAllPaged]
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
EXEC [dbo].[CMSCore.Role.SelectAllPaged]
    
    @QueryString = N'',
    @ActualPageNumber = 1,
    @RowsPerPage = 10,
    @SorterColumn = N'RoleId',
    @SortToggler = 0,
    @TotalRows = @TotalRows OUTPUT

SELECT @TotalRows AS N'@TotalRows'
*/

--Last modification on: 20/12/2022 20:47:32

SET DATEFORMAT DMY
SET NOCOUNT ON

SELECT
    [CMSCore.Role].[RoleId],
    [CMSCore.Role].[Name],
    [CMSCore.Role].[Active],
    [CMSCore.Role].[UserCreationId],
    [CMSCore.Role].[UserLastModificationId],
    [CMSCore.Role].[DateTimeCreation],
    [CMSCore.Role].[DateTimeLastModification]
FROM 
    [CMSCore.Role]
    LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserCreationId] ON [CMSCore.Role].[UserCreationId] = [CMSCore.User.UserCreationId].[UserId]
	LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserLastModificationId] ON [CMSCore.Role].[UserLastModificationId] = [CMSCore.User.UserLastModificationId].[UserId]
WHERE
    1=1
    AND (@QueryString = '' 
        OR ([CMSCore.Role].[RoleId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Role].[Name] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Role].[Active] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Role].[UserCreationId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Role].[UserLastModificationId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Role].[DateTimeCreation] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Role].[DateTimeLastModification] LIKE  '%' + @QueryString + '%')

    )
ORDER BY 
    CASE WHEN (@SorterColumn = 'RoleId' AND @SortToggler = 0) THEN [CMSCore.Role].[RoleId] END ASC,
    CASE WHEN (@SorterColumn = 'RoleId' AND @SortToggler = 1) THEN [CMSCore.Role].[RoleId] END DESC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 0) THEN [CMSCore.Role].[Name] END ASC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 1) THEN [CMSCore.Role].[Name] END DESC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 0) THEN [CMSCore.Role].[Active] END ASC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 1) THEN [CMSCore.Role].[Active] END DESC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 0) THEN [CMSCore.Role].[UserCreationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 1) THEN [CMSCore.Role].[UserCreationId] END DESC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 0) THEN [CMSCore.Role].[UserLastModificationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 1) THEN [CMSCore.Role].[UserLastModificationId] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 0) THEN [CMSCore.Role].[DateTimeCreation] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 1) THEN [CMSCore.Role].[DateTimeCreation] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 0) THEN [CMSCore.Role].[DateTimeLastModification] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 1) THEN [CMSCore.Role].[DateTimeLastModification] END DESC

OFFSET (@ActualPageNumber - 1) * @RowsPerPage ROWS
FETCH NEXT @RowsPerPage ROWS ONLY
SELECT @TotalRows = COUNT(*) FROM [CMSCore.Role]