CREATE PROCEDURE [dbo].[CMSCore.User.Select1ByUserId]
(
    @UserId INT
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
EXEC [dbo].[User.Select1ByUserId]
    @UserId = 1
 *
 */

--Last modification on: 20/12/2022 21:44:06

SET DATEFORMAT DMY

SELECT
    [CMSCore.User].[UserId],
    [CMSCore.User].[FantasyName],
    [CMSCore.User].[Email],
    [CMSCore.User].[Password],
    [CMSCore.User].[RoleId],
    [CMSCore.User].[Active],
    [CMSCore.User].[UserCreationId],
    [CMSCore.User].[UserLastModificationId],
    [CMSCore.User].[DateTimeCreation],
    [CMSCore.User].[DateTimeLastModification],
    [CMSCore.User].[RegistrationToken]
FROM 
    [CMSCore.User]
    LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserCreationId] ON [CMSCore.User].[UserCreationId] = [CMSCore.User.UserCreationId].[UserId]
	LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserLastModificationId] ON [CMSCore.User].[UserLastModificationId] = [CMSCore.User.UserLastModificationId].[UserId]
WHERE 
    1 = 1
    AND [CMSCore.User].[UserId] = @UserId
ORDER BY 
    [CMSCore.User].[UserId]CMSCore.User].[UserId]