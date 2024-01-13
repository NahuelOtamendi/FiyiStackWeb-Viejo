CREATE PROCEDURE [dbo].[CMSCore.Menu.Select1ByMenuId]
(
    @MenuId INT
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
EXEC [dbo].[Menu.Select1ByMenuId]
    @MenuId = 1
 *
 */

--Last modification on: 20/12/2022 20:22:13

SET DATEFORMAT DMY

SELECT
    [CMSCore.Menu].[MenuId],
    [CMSCore.Menu].[Name],
    [CMSCore.Menu].[MenuFatherId],
    [CMSCore.Menu].[Order],
    [CMSCore.Menu].[URLPath],
    [CMSCore.Menu].[IconURLPath],
    [CMSCore.Menu].[Active],
    [CMSCore.Menu].[UserCreationId],
    [CMSCore.Menu].[UserLastModificationId],
    [CMSCore.Menu].[DateTimeCreation],
    [CMSCore.Menu].[DateTimeLastModification]
FROM 
    [CMSCore.Menu]
    LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserCreationId] ON [CMSCore.Menu].[UserCreationId] = [CMSCore.User.UserCreationId].[UserId]
	LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserLastModificationId] ON [CMSCore.Menu].[UserLastModificationId] = [CMSCore.User.UserLastModificationId].[UserId]
WHERE 
    1 = 1
    AND [CMSCore.Menu].[MenuId] = @MenuId
ORDER BY 
    [CMSCore.Menu].[MenuId]Menu].[MenuId]