CREATE PROCEDURE [dbo].[CMSCore.User.SelectAllPaged]
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
EXEC [dbo].[CMSCore.User.SelectAllPaged]
    
    @QueryString = N'',
    @ActualPageNumber = 1,
    @RowsPerPage = 10,
    @SorterColumn = N'UserId',
    @SortToggler = 0,
    @TotalRows = @TotalRows OUTPUT

SELECT @TotalRows AS N'@TotalRows'
*/

--Last modification on: 20/12/2022 21:44:06

SET DATEFORMAT DMY
SET NOCOUNT ON

SELECT
    [CMSCore.User].[UserId],
    [CMSCore.User].[FantasyName],
    [CMSCore.User].[Email],
    [CMSCore.User].[Password],
    [CMSCore.User].[RoleId],
    [CMSCore.User].[Active],
    [CMSCore.User].[UserCreationId],
    [CMSCore.User].[UserLastModificationId],
    [CMSCore.User].[DateTimeCreation],
    [CMSCore.User].[DateTimeLastModification],
    [CMSCore.User].[RegistrationToken]
FROM 
    [CMSCore.User]
    LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserCreationId] ON [CMSCore.User].[UserCreationId] = [CMSCore.User.UserCreationId].[UserId]
	LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserLastModificationId] ON [CMSCore.User].[UserLastModificationId] = [CMSCore.User.UserLastModificationId].[UserId]
WHERE
    1=1
    AND (@QueryString = '' 
        OR ([CMSCore.User].[UserId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.User].[FantasyName] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.User].[Email] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.User].[Password] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.User].[RoleId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.User].[Active] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.User].[UserCreationId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.User].[UserLastModificationId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.User].[DateTimeCreation] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.User].[DateTimeLastModification] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.User].[RegistrationToken] LIKE  '%' + @QueryString + '%')

    )
ORDER BY 
    CASE WHEN (@SorterColumn = 'UserId' AND @SortToggler = 0) THEN [CMSCore.User].[UserId] END ASC,
    CASE WHEN (@SorterColumn = 'UserId' AND @SortToggler = 1) THEN [CMSCore.User].[UserId] END DESC,
    CASE WHEN (@SorterColumn = 'FantasyName' AND @SortToggler = 0) THEN [CMSCore.User].[FantasyName] END ASC,
    CASE WHEN (@SorterColumn = 'FantasyName' AND @SortToggler = 1) THEN [CMSCore.User].[FantasyName] END DESC,
    CASE WHEN (@SorterColumn = 'Email' AND @SortToggler = 0) THEN [CMSCore.User].[Email] END ASC,
    CASE WHEN (@SorterColumn = 'Email' AND @SortToggler = 1) THEN [CMSCore.User].[Email] END DESC,
    CASE WHEN (@SorterColumn = 'Password' AND @SortToggler = 0) THEN [CMSCore.User].[Password] END ASC,
    CASE WHEN (@SorterColumn = 'Password' AND @SortToggler = 1) THEN [CMSCore.User].[Password] END DESC,
    CASE WHEN (@SorterColumn = 'RoleId' AND @SortToggler = 0) THEN [CMSCore.User].[RoleId] END ASC,
    CASE WHEN (@SorterColumn = 'RoleId' AND @SortToggler = 1) THEN [CMSCore.User].[RoleId] END DESC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 0) THEN [CMSCore.User].[Active] END ASC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 1) THEN [CMSCore.User].[Active] END DESC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 0) THEN [CMSCore.User].[UserCreationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 1) THEN [CMSCore.User].[UserCreationId] END DESC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 0) THEN [CMSCore.User].[UserLastModificationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 1) THEN [CMSCore.User].[UserLastModificationId] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 0) THEN [CMSCore.User].[DateTimeCreation] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 1) THEN [CMSCore.User].[DateTimeCreation] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 0) THEN [CMSCore.User].[DateTimeLastModification] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 1) THEN [CMSCore.User].[DateTimeLastModification] END DESC,
    CASE WHEN (@SorterColumn = 'RegistrationToken' AND @SortToggler = 0) THEN [CMSCore.User].[RegistrationToken] END ASC,
    CASE WHEN (@SorterColumn = 'RegistrationToken' AND @SortToggler = 1) THEN [CMSCore.User].[RegistrationToken] END DESC

OFFSET (@ActualPageNumber - 1) * @RowsPerPage ROWS
FETCH NEXT @RowsPerPage ROWS ONLY
SELECT @TotalRows = COUNT(*) FROM [CMSCore.User]