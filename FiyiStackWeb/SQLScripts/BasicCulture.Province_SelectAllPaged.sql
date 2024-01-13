CREATE PROCEDURE [dbo].[BasicCulture.Province.SelectAllPaged]
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
EXEC [dbo].[BasicCulture.Province.SelectAllPaged]
    
    @QueryString = N'',
    @ActualPageNumber = 1,
    @RowsPerPage = 10,
    @SorterColumn = N'ProvinceId',
    @SortToggler = 0,
    @TotalRows = @TotalRows OUTPUT

SELECT @TotalRows AS N'@TotalRows'
*/

--Last modification on: 20/12/2022 20:14:59

SET DATEFORMAT DMY
SET NOCOUNT ON

SELECT
    [BasicCulture.Province].[ProvinceId],
    [BasicCulture.Province].[Name],
    [BasicCulture.Province].[GeographicalCoordinates],
    [BasicCulture.Province].[Code],
    [BasicCulture.Province].[CountryId],
    [BasicCulture.Province].[Active],
    [BasicCulture.Province].[UserCreationId],
    [BasicCulture.Province].[UserLastModificationId],
    [BasicCulture.Province].[DateTimeCreation],
    [BasicCulture.Province].[DateTimeLastModification]
FROM 
    [BasicCulture.Province]
    LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserCreationId] ON [BasicCulture.Province].[UserCreationId] = [CMSCore.User.UserCreationId].[UserId]
	LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserLastModificationId] ON [BasicCulture.Province].[UserLastModificationId] = [CMSCore.User.UserLastModificationId].[UserId]
WHERE
    1=1
    AND (@QueryString = '' 
        OR ([BasicCulture.Province].[ProvinceId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Province].[Name] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Province].[GeographicalCoordinates] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Province].[Code] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Province].[CountryId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Province].[Active] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Province].[UserCreationId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Province].[UserLastModificationId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Province].[DateTimeCreation] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Province].[DateTimeLastModification] LIKE  '%' + @QueryString + '%')

    )
ORDER BY 
    CASE WHEN (@SorterColumn = 'ProvinceId' AND @SortToggler = 0) THEN [BasicCulture.Province].[ProvinceId] END ASC,
    CASE WHEN (@SorterColumn = 'ProvinceId' AND @SortToggler = 1) THEN [BasicCulture.Province].[ProvinceId] END DESC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 0) THEN [BasicCulture.Province].[Name] END ASC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 1) THEN [BasicCulture.Province].[Name] END DESC,
    CASE WHEN (@SorterColumn = 'GeographicalCoordinates' AND @SortToggler = 0) THEN [BasicCulture.Province].[GeographicalCoordinates] END ASC,
    CASE WHEN (@SorterColumn = 'GeographicalCoordinates' AND @SortToggler = 1) THEN [BasicCulture.Province].[GeographicalCoordinates] END DESC,
    CASE WHEN (@SorterColumn = 'Code' AND @SortToggler = 0) THEN [BasicCulture.Province].[Code] END ASC,
    CASE WHEN (@SorterColumn = 'Code' AND @SortToggler = 1) THEN [BasicCulture.Province].[Code] END DESC,
    CASE WHEN (@SorterColumn = 'CountryId' AND @SortToggler = 0) THEN [BasicCulture.Province].[CountryId] END ASC,
    CASE WHEN (@SorterColumn = 'CountryId' AND @SortToggler = 1) THEN [BasicCulture.Province].[CountryId] END DESC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 0) THEN [BasicCulture.Province].[Active] END ASC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 1) THEN [BasicCulture.Province].[Active] END DESC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 0) THEN [BasicCulture.Province].[UserCreationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 1) THEN [BasicCulture.Province].[UserCreationId] END DESC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 0) THEN [BasicCulture.Province].[UserLastModificationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 1) THEN [BasicCulture.Province].[UserLastModificationId] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 0) THEN [BasicCulture.Province].[DateTimeCreation] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 1) THEN [BasicCulture.Province].[DateTimeCreation] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 0) THEN [BasicCulture.Province].[DateTimeLastModification] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 1) THEN [BasicCulture.Province].[DateTimeLastModification] END DESC

OFFSET (@ActualPageNumber - 1) * @RowsPerPage ROWS
FETCH NEXT @RowsPerPage ROWS ONLY
SELECT @TotalRows = COUNT(*) FROM [BasicCulture.Province]