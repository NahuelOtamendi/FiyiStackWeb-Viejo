CREATE PROCEDURE [dbo].[BasicCulture.Sex.SelectAll]

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
EXEC [dbo].[BasicCulture.Sex.SelectAll]
 *
 */

--Last modification on: 20/12/2022 20:18:05

SET DATEFORMAT DMY

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
ORDER BY 
    [BasicCulture.Sex].[SexId]