CREATE PROCEDURE [dbo].[BasicCulture.Country.SelectAll]

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
EXEC [dbo].[BasicCulture.Country.SelectAll]
 *
 */

--Last modification on: 20/12/2022 20:09:01

SET DATEFORMAT DMY

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
ORDER BY 
    [BasicCulture.Country].[CountryId]