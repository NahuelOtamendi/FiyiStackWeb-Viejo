CREATE PROCEDURE [dbo].[BasicCore.Failure.SelectAllPaged]
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
EXEC [dbo].[BasicCore.Failure.SelectAllPaged]
    
    @QueryString = N'',
    @ActualPageNumber = 1,
    @RowsPerPage = 10,
    @SorterColumn = N'FailureId',
    @SortToggler = 0,
    @TotalRows = @TotalRows OUTPUT

SELECT @TotalRows AS N'@TotalRows'
*/

--Last modification on: 20/12/2022 19:54:13

SET DATEFORMAT DMY
SET NOCOUNT ON

SELECT
    [BasicCore.Failure].[FailureId],
    [BasicCore.Failure].[HTTPCode],
    [BasicCore.Failure].[EmergencyLevel],
    [BasicCore.Failure].[Message],
    [BasicCore.Failure].[StackTrace],
    [BasicCore.Failure].[Source],
    [BasicCore.Failure].[Comment],
    [BasicCore.Failure].[Active],
    [BasicCore.Failure].[UserCreationId],
    [BasicCore.Failure].[UserLastModificationId],
    [BasicCore.Failure].[DateTimeCreation],
    [BasicCore.Failure].[DateTimeLastModification]
FROM 
    [BasicCore.Failure]
    LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserCreationId] ON [BasicCore.Failure].[UserCreationId] = [CMSCore.User.UserCreationId].[UserId]
	LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserLastModificationId] ON [BasicCore.Failure].[UserLastModificationId] = [CMSCore.User.UserLastModificationId].[UserId]
WHERE
    1=1
    AND (@QueryString = '' 
        OR ([BasicCore.Failure].[FailureId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Failure].[HTTPCode] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Failure].[EmergencyLevel] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Failure].[Message] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Failure].[StackTrace] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Failure].[Source] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Failure].[Comment] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Failure].[Active] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Failure].[UserCreationId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Failure].[UserLastModificationId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Failure].[DateTimeCreation] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Failure].[DateTimeLastModification] LIKE  '%' + @QueryString + '%')

    )
ORDER BY 
    CASE WHEN (@SorterColumn = 'FailureId' AND @SortToggler = 0) THEN [BasicCore.Failure].[FailureId] END ASC,
    CASE WHEN (@SorterColumn = 'FailureId' AND @SortToggler = 1) THEN [BasicCore.Failure].[FailureId] END DESC,
    CASE WHEN (@SorterColumn = 'HTTPCode' AND @SortToggler = 0) THEN [BasicCore.Failure].[HTTPCode] END ASC,
    CASE WHEN (@SorterColumn = 'HTTPCode' AND @SortToggler = 1) THEN [BasicCore.Failure].[HTTPCode] END DESC,
    CASE WHEN (@SorterColumn = 'EmergencyLevel' AND @SortToggler = 0) THEN [BasicCore.Failure].[EmergencyLevel] END ASC,
    CASE WHEN (@SorterColumn = 'EmergencyLevel' AND @SortToggler = 1) THEN [BasicCore.Failure].[EmergencyLevel] END DESC,
    CASE WHEN (@SorterColumn = 'Message' AND @SortToggler = 0) THEN [BasicCore.Failure].[Message] END ASC,
    CASE WHEN (@SorterColumn = 'Message' AND @SortToggler = 1) THEN [BasicCore.Failure].[Message] END DESC,
    CASE WHEN (@SorterColumn = 'StackTrace' AND @SortToggler = 0) THEN [BasicCore.Failure].[StackTrace] END ASC,
    CASE WHEN (@SorterColumn = 'StackTrace' AND @SortToggler = 1) THEN [BasicCore.Failure].[StackTrace] END DESC,
    CASE WHEN (@SorterColumn = 'Source' AND @SortToggler = 0) THEN [BasicCore.Failure].[Source] END ASC,
    CASE WHEN (@SorterColumn = 'Source' AND @SortToggler = 1) THEN [BasicCore.Failure].[Source] END DESC,
    CASE WHEN (@SorterColumn = 'Comment' AND @SortToggler = 0) THEN [BasicCore.Failure].[Comment] END ASC,
    CASE WHEN (@SorterColumn = 'Comment' AND @SortToggler = 1) THEN [BasicCore.Failure].[Comment] END DESC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 0) THEN [BasicCore.Failure].[Active] END ASC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 1) THEN [BasicCore.Failure].[Active] END DESC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 0) THEN [BasicCore.Failure].[UserCreationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 1) THEN [BasicCore.Failure].[UserCreationId] END DESC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 0) THEN [BasicCore.Failure].[UserLastModificationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 1) THEN [BasicCore.Failure].[UserLastModificationId] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 0) THEN [BasicCore.Failure].[DateTimeCreation] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 1) THEN [BasicCore.Failure].[DateTimeCreation] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 0) THEN [BasicCore.Failure].[DateTimeLastModification] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 1) THEN [BasicCore.Failure].[DateTimeLastModification] END DESC

OFFSET (@ActualPageNumber - 1) * @RowsPerPage ROWS
FETCH NEXT @RowsPerPage ROWS ONLY
SELECT @TotalRows = COUNT(*) FROM [BasicCore.Failure]