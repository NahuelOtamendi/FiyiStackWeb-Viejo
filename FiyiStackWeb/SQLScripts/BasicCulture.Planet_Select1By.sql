CREATE PROCEDURE [dbo].[BasicCulture.Planet.Select1ByPlanetId]
(
    @PlanetId INT
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
EXEC [dbo].[Planet.Select1ByPlanetId]
    @PlanetId = 1
 *
 */

--Last modification on: 20/12/2022 20:12:21

SET DATEFORMAT DMY

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
    1 = 1
    AND [BasicCulture.Planet].[PlanetId] = @PlanetId
ORDER BY 
    [BasicCulture.Planet].[PlanetId]