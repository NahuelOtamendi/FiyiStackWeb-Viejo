CREATE PROCEDURE [dbo].[BasicCulture.Sex.SelectAllPaged]
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
EXEC [dbo].[BasicCulture.Sex.SelectAllPaged]
    
    @QueryString = N'',
    @ActualPageNumber = 1,
    @RowsPerPage = 10,
    @SorterColumn = N'SexId',
    @SortToggler = 0,
    @TotalRows = @TotalRows OUTPUT

SELECT @TotalRows AS N'@TotalRows'
*/

--Last modification on: 20/12/2022 20:18:05

SET DATEFORMAT DMY
SET NOCOUNT ON

SELECT
    [BasicCulture.Sex].[SexId],
    [BasicCulture.Sex].[Name],
    [BasicCulture.Sex].[Active],
    [BasicCulture.Sex].[UserCreationId],
    [BasicCulture.Sex].[UserLastModificationId],
    [BasicCulture.Sex].[DateTimeCreation],
    [BasicCulture.Sex].[DateTimeLastModification]
FROM 
    [BasicCulture.Sex]
    LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserCreationId] ON [BasicCulture.Sex].[UserCreationId] = [CMSCore.User.UserCreationId].[UserId]
	LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserLastModificationId] ON [BasicCulture.Sex].[UserLastModificationId] = [CMSCore.User.UserLastModificationId].[UserId]
WHERE
    1=1
    AND (@QueryString = '' 
        OR ([BasicCulture.Sex].[SexId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Sex].[Name] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Sex].[Active] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Sex].[UserCreationId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Sex].[UserLastModificationId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Sex].[DateTimeCreation] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Sex].[DateTimeLastModification] LIKE  '%' + @QueryString + '%')

    )
ORDER BY 
    CASE WHEN (@SorterColumn = 'SexId' AND @SortToggler = 0) THEN [BasicCulture.Sex].[SexId] END ASC,
    CASE WHEN (@SorterColumn = 'SexId' AND @SortToggler = 1) THEN [BasicCulture.Sex].[SexId] END DESC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 0) THEN [BasicCulture.Sex].[Name] END ASC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 1) THEN [BasicCulture.Sex].[Name] END DESC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 0) THEN [BasicCulture.Sex].[Active] END ASC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 1) THEN [BasicCulture.Sex].[Active] END DESC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 0) THEN [BasicCulture.Sex].[UserCreationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 1) THEN [BasicCulture.Sex].[UserCreationId] END DESC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 0) THEN [BasicCulture.Sex].[UserLastModificationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 1) THEN [BasicCulture.Sex].[UserLastModificationId] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 0) THEN [BasicCulture.Sex].[DateTimeCreation] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 1) THEN [BasicCulture.Sex].[DateTimeCreation] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 0) THEN [BasicCulture.Sex].[DateTimeLastModification] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 1) THEN [BasicCulture.Sex].[DateTimeLastModification] END DESC

OFFSET (@ActualPageNumber - 1) * @RowsPerPage ROWS
FETCH NEXT @RowsPerPage ROWS ONLY
SELECT @TotalRows = COUNT(*) FROM [BasicCulture.Sex]