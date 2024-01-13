CREATE PROCEDURE [dbo].[BasicCulture.City.Select1ByCityId]
(
    @CityId INT
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

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[City.Select1ByCityId]
    @CityId = 1
 *
 */

--Last modification on: 20/12/2022 20:06:24

SET DATEFORMAT DMY

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
    1 = 1
    AND [BasicCulture.City].[CityId] = @CityId
ORDER BY 
    [BasicCulture.City].[CityId]