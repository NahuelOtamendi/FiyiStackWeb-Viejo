CREATE PROCEDURE [dbo].[BasicCore.Parameter.SelectAllPaged]
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
EXEC [dbo].[BasicCore.Parameter.SelectAllPaged]
    
    @QueryString = N'',
    @ActualPageNumber = 1,
    @RowsPerPage = 10,
    @SorterColumn = N'ParameterId',
    @SortToggler = 0,
    @TotalRows = @TotalRows OUTPUT

SELECT @TotalRows AS N'@TotalRows'
*/

--Last modification on: 20/12/2022 19:56:32

SET DATEFORMAT DMY
SET NOCOUNT ON

SELECT
    [BasicCore.Parameter].[ParameterId],
    [BasicCore.Parameter].[Name],
    [BasicCore.Parameter].[Value],
    [BasicCore.Parameter].[IsPrivate],
    [BasicCore.Parameter].[Active],
    [BasicCore.Parameter].[UserCreationId],
    [BasicCore.Parameter].[UserLastModificationId],
    [BasicCore.Parameter].[DateTimeCreation],
    [BasicCore.Parameter].[DateTimeLastModification]
FROM 
    [BasicCore.Parameter]
    LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserCreationId] ON [BasicCore.Parameter].[UserCreationId] = [CMSCore.User.UserCreationId].[UserId]
	LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserLastModificationId] ON [BasicCore.Parameter].[UserLastModificationId] = [CMSCore.User.UserLastModificationId].[UserId]
WHERE
    1=1
    AND (@QueryString = '' 
        OR ([BasicCore.Parameter].[ParameterId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Parameter].[Name] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Parameter].[Value] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Parameter].[IsPrivate] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Parameter].[Active] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Parameter].[UserCreationId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Parameter].[UserLastModificationId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Parameter].[DateTimeCreation] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Parameter].[DateTimeLastModification] LIKE  '%' + @QueryString + '%')

    )
ORDER BY 
    CASE WHEN (@SorterColumn = 'ParameterId' AND @SortToggler = 0) THEN [BasicCore.Parameter].[ParameterId] END ASC,
    CASE WHEN (@SorterColumn = 'ParameterId' AND @SortToggler = 1) THEN [BasicCore.Parameter].[ParameterId] END DESC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 0) THEN [BasicCore.Parameter].[Name] END ASC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 1) THEN [BasicCore.Parameter].[Name] END DESC,
    CASE WHEN (@SorterColumn = 'Value' AND @SortToggler = 0) THEN [BasicCore.Parameter].[Value] END ASC,
    CASE WHEN (@SorterColumn = 'Value' AND @SortToggler = 1) THEN [BasicCore.Parameter].[Value] END DESC,
    CASE WHEN (@SorterColumn = 'IsPrivate' AND @SortToggler = 0) THEN [BasicCore.Parameter].[IsPrivate] END ASC,
    CASE WHEN (@SorterColumn = 'IsPrivate' AND @SortToggler = 1) THEN [BasicCore.Parameter].[IsPrivate] END DESC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 0) THEN [BasicCore.Parameter].[Active] END ASC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 1) THEN [BasicCore.Parameter].[Active] END DESC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 0) THEN [BasicCore.Parameter].[UserCreationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 1) THEN [BasicCore.Parameter].[UserCreationId] END DESC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 0) THEN [BasicCore.Parameter].[UserLastModificationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 1) THEN [BasicCore.Parameter].[UserLastModificationId] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 0) THEN [BasicCore.Parameter].[DateTimeCreation] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 1) THEN [BasicCore.Parameter].[DateTimeCreation] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 0) THEN [BasicCore.Parameter].[DateTimeLastModification] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 1) THEN [BasicCore.Parameter].[DateTimeLastModification] END DESC

OFFSET (@ActualPageNumber - 1) * @RowsPerPage ROWS
FETCH NEXT @RowsPerPage ROWS ONLY
SELECT @TotalRows = COUNT(*) FROM [BasicCore.Parameter]