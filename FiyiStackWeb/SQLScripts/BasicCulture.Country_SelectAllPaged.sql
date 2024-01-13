CREATE PROCEDURE [dbo].[BasicCulture.Country.SelectAllPaged]
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
EXEC [dbo].[BasicCulture.Country.SelectAllPaged]
    
    @QueryString = N'',
    @ActualPageNumber = 1,
    @RowsPerPage = 10,
    @SorterColumn = N'CountryId',
    @SortToggler = 0,
    @TotalRows = @TotalRows OUTPUT

SELECT @TotalRows AS N'@TotalRows'
*/

--Last modification on: 20/12/2022 20:09:01

SET DATEFORMAT DMY
SET NOCOUNT ON

SELECT
    [BasicCulture.Country].[CountryId],
    [BasicCulture.Country].[Name],
    [BasicCulture.Country].[GeographicalCoordinates],
    [BasicCulture.Country].[Code],
    [BasicCulture.Country].[PlanetId],
    [BasicCulture.Country].[Active],
    [BasicCulture.Country].[UserCreationId],
    [BasicCulture.Country].[UserLastModificationId],
    [BasicCulture.Country].[DateTimeCreation],
    [BasicCulture.Country].[DateTimeLastModification]
FROM 
    [BasicCulture.Country]
    LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserCreationId] ON [BasicCulture.Country].[UserCreationId] = [CMSCore.User.UserCreationId].[UserId]
	LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserLastModificationId] ON [BasicCulture.Country].[UserLastModificationId] = [CMSCore.User.UserLastModificationId].[UserId]
WHERE
    1=1
    AND (@QueryString = '' 
        OR ([BasicCulture.Country].[CountryId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Country].[Name] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Country].[GeographicalCoordinates] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Country].[Code] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Country].[PlanetId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Country].[Active] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Country].[UserCreationId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Country].[UserLastModificationId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Country].[DateTimeCreation] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Country].[DateTimeLastModification] LIKE  '%' + @QueryString + '%')

    )
ORDER BY 
    CASE WHEN (@SorterColumn = 'CountryId' AND @SortToggler = 0) THEN [BasicCulture.Country].[CountryId] END ASC,
    CASE WHEN (@SorterColumn = 'CountryId' AND @SortToggler = 1) THEN [BasicCulture.Country].[CountryId] END DESC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 0) THEN [BasicCulture.Country].[Name] END ASC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 1) THEN [BasicCulture.Country].[Name] END DESC,
    CASE WHEN (@SorterColumn = 'GeographicalCoordinates' AND @SortToggler = 0) THEN [BasicCulture.Country].[GeographicalCoordinates] END ASC,
    CASE WHEN (@SorterColumn = 'GeographicalCoordinates' AND @SortToggler = 1) THEN [BasicCulture.Country].[GeographicalCoordinates] END DESC,
    CASE WHEN (@SorterColumn = 'Code' AND @SortToggler = 0) THEN [BasicCulture.Country].[Code] END ASC,
    CASE WHEN (@SorterColumn = 'Code' AND @SortToggler = 1) THEN [BasicCulture.Country].[Code] END DESC,
    CASE WHEN (@SorterColumn = 'PlanetId' AND @SortToggler = 0) THEN [BasicCulture.Country].[PlanetId] END ASC,
    CASE WHEN (@SorterColumn = 'PlanetId' AND @SortToggler = 1) THEN [BasicCulture.Country].[PlanetId] END DESC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 0) THEN [BasicCulture.Country].[Active] END ASC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 1) THEN [BasicCulture.Country].[Active] END DESC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 0) THEN [BasicCulture.Country].[UserCreationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 1) THEN [BasicCulture.Country].[UserCreationId] END DESC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 0) THEN [BasicCulture.Country].[UserLastModificationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 1) THEN [BasicCulture.Country].[UserLastModificationId] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 0) THEN [BasicCulture.Country].[DateTimeCreation] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 1) THEN [BasicCulture.Country].[DateTimeCreation] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 0) THEN [BasicCulture.Country].[DateTimeLastModification] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 1) THEN [BasicCulture.Country].[DateTimeLastModification] END DESC

OFFSET (@ActualPageNumber - 1) * @RowsPerPage ROWS
FETCH NEXT @RowsPerPage ROWS ONLY
SELECT @TotalRows = COUNT(*) FROM [BasicCulture.Country]