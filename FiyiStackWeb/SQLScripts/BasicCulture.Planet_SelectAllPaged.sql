CREATE PROCEDURE [dbo].[BasicCulture.Planet.SelectAllPaged]
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
EXEC [dbo].[BasicCulture.Planet.SelectAllPaged]
    
    @QueryString = N'',
    @ActualPageNumber = 1,
    @RowsPerPage = 10,
    @SorterColumn = N'PlanetId',
    @SortToggler = 0,
    @TotalRows = @TotalRows OUTPUT

SELECT @TotalRows AS N'@TotalRows'
*/

--Last modification on: 20/12/2022 20:12:21

SET DATEFORMAT DMY
SET NOCOUNT ON

SELECT
    [BasicCulture.Planet].[PlanetId],
    [BasicCulture.Planet].[Name],
    [BasicCulture.Planet].[Code],
    [BasicCulture.Planet].[Active],
    [BasicCulture.Planet].[UserCreationId],
    [BasicCulture.Planet].[UserLastModificationId],
    [BasicCulture.Planet].[DateTimeCreation],
    [BasicCulture.Planet].[DateTimeLastModification]
FROM 
    [BasicCulture.Planet]
    LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserCreationId] ON [BasicCulture.Planet].[UserCreationId] = [CMSCore.User.UserCreationId].[UserId]
	LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserLastModificationId] ON [BasicCulture.Planet].[UserLastModificationId] = [CMSCore.User.UserLastModificationId].[UserId]
WHERE
    1=1
    AND (@QueryString = '' 
        OR ([BasicCulture.Planet].[PlanetId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Planet].[Name] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Planet].[Code] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Planet].[Active] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Planet].[UserCreationId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Planet].[UserLastModificationId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Planet].[DateTimeCreation] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Planet].[DateTimeLastModification] LIKE  '%' + @QueryString + '%')

    )
ORDER BY 
    CASE WHEN (@SorterColumn = 'PlanetId' AND @SortToggler = 0) THEN [BasicCulture.Planet].[PlanetId] END ASC,
    CASE WHEN (@SorterColumn = 'PlanetId' AND @SortToggler = 1) THEN [BasicCulture.Planet].[PlanetId] END DESC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 0) THEN [BasicCulture.Planet].[Name] END ASC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 1) THEN [BasicCulture.Planet].[Name] END DESC,
    CASE WHEN (@SorterColumn = 'Code' AND @SortToggler = 0) THEN [BasicCulture.Planet].[Code] END ASC,
    CASE WHEN (@SorterColumn = 'Code' AND @SortToggler = 1) THEN [BasicCulture.Planet].[Code] END DESC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 0) THEN [BasicCulture.Planet].[Active] END ASC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 1) THEN [BasicCulture.Planet].[Active] END DESC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 0) THEN [BasicCulture.Planet].[UserCreationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 1) THEN [BasicCulture.Planet].[UserCreationId] END DESC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 0) THEN [BasicCulture.Planet].[UserLastModificationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 1) THEN [BasicCulture.Planet].[UserLastModificationId] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 0) THEN [BasicCulture.Planet].[DateTimeCreation] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 1) THEN [BasicCulture.Planet].[DateTimeCreation] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 0) THEN [BasicCulture.Planet].[DateTimeLastModification] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 1) THEN [BasicCulture.Planet].[DateTimeLastModification] END DESC

OFFSET (@ActualPageNumber - 1) * @RowsPerPage ROWS
FETCH NEXT @RowsPerPage ROWS ONLY
SELECT @TotalRows = COUNT(*) FROM [BasicCulture.Planet]