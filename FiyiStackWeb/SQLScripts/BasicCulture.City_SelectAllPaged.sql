CREATE PROCEDURE [dbo].[BasicCulture.City.SelectAllPaged]
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
EXEC [dbo].[BasicCulture.City.SelectAllPaged]
    
    @QueryString = N'',
    @ActualPageNumber = 1,
    @RowsPerPage = 10,
    @SorterColumn = N'CityId',
    @SortToggler = 0,
    @TotalRows = @TotalRows OUTPUT

SELECT @TotalRows AS N'@TotalRows'
*/

--Last modification on: 20/12/2022 20:06:24

SET DATEFORMAT DMY
SET NOCOUNT ON

SELECT
    [BasicCulture.City].[CityId],
    [BasicCulture.City].[Name],
    [BasicCulture.City].[GeographicalCoordinates],
    [BasicCulture.City].[Code],
    [BasicCulture.City].[ProvinceId],
    [BasicCulture.City].[Active],
    [BasicCulture.City].[UserCreationId],
    [BasicCulture.City].[UserLastModificationId],
    [BasicCulture.City].[DateTimeCreation],
    [BasicCulture.City].[DateTimeLastModification]
FROM 
    [BasicCulture.City]
    LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserCreationId] ON [BasicCulture.City].[UserCreationId] = [CMSCore.User.UserCreationId].[UserId]
	LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserLastModificationId] ON [BasicCulture.City].[UserLastModificationId] = [CMSCore.User.UserLastModificationId].[UserId]
WHERE
    1=1
    AND (@QueryString = '' 
        OR ([BasicCulture.City].[CityId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.City].[Name] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.City].[GeographicalCoordinates] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.City].[Code] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.City].[ProvinceId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.City].[Active] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.City].[UserCreationId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.City].[UserLastModificationId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.City].[DateTimeCreation] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.City].[DateTimeLastModification] LIKE  '%' + @QueryString + '%')

    )
ORDER BY 
    CASE WHEN (@SorterColumn = 'CityId' AND @SortToggler = 0) THEN [BasicCulture.City].[CityId] END ASC,
    CASE WHEN (@SorterColumn = 'CityId' AND @SortToggler = 1) THEN [BasicCulture.City].[CityId] END DESC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 0) THEN [BasicCulture.City].[Name] END ASC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 1) THEN [BasicCulture.City].[Name] END DESC,
    CASE WHEN (@SorterColumn = 'GeographicalCoordinates' AND @SortToggler = 0) THEN [BasicCulture.City].[GeographicalCoordinates] END ASC,
    CASE WHEN (@SorterColumn = 'GeographicalCoordinates' AND @SortToggler = 1) THEN [BasicCulture.City].[GeographicalCoordinates] END DESC,
    CASE WHEN (@SorterColumn = 'Code' AND @SortToggler = 0) THEN [BasicCulture.City].[Code] END ASC,
    CASE WHEN (@SorterColumn = 'Code' AND @SortToggler = 1) THEN [BasicCulture.City].[Code] END DESC,
    CASE WHEN (@SorterColumn = 'ProvinceId' AND @SortToggler = 0) THEN [BasicCulture.City].[ProvinceId] END ASC,
    CASE WHEN (@SorterColumn = 'ProvinceId' AND @SortToggler = 1) THEN [BasicCulture.City].[ProvinceId] END DESC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 0) THEN [BasicCulture.City].[Active] END ASC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 1) THEN [BasicCulture.City].[Active] END DESC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 0) THEN [BasicCulture.City].[UserCreationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 1) THEN [BasicCulture.City].[UserCreationId] END DESC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 0) THEN [BasicCulture.City].[UserLastModificationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 1) THEN [BasicCulture.City].[UserLastModificationId] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 0) THEN [BasicCulture.City].[DateTimeCreation] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 1) THEN [BasicCulture.City].[DateTimeCreation] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 0) THEN [BasicCulture.City].[DateTimeLastModification] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 1) THEN [BasicCulture.City].[DateTimeLastModification] END DESC

OFFSET (@ActualPageNumber - 1) * @RowsPerPage ROWS
FETCH NEXT @RowsPerPage ROWS ONLY
SELECT @TotalRows = COUNT(*) FROM [BasicCulture.City]