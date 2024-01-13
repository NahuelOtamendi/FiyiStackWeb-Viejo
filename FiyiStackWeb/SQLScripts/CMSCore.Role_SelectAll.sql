CREATE PROCEDURE [dbo].[CMSCore.Role.SelectAll]

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
EXEC [dbo].[CMSCore.Role.SelectAll]
 *
 */

--Last modification on: 20/12/2022 20:47:32

SET DATEFORMAT DMY

SELECT
    [CMSCore.Role].[RoleId],
    [CMSCore.Role].[Name],
    [CMSCore.Role].[Active],
    [CMSCore.Role].[UserCreationId],
    [CMSCore.Role].[UserLastModificationId],
    [CMSCore.Role].[DateTimeCreation],
    [CMSCore.Role].[DateTimeLastModification]
FROM 
    [CMSCore.Role]
    LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserCreationId] ON [CMSCore.Role].[UserCreationId] = [CMSCore.User.UserCreationId].[UserId]
	LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserLastModificationId] ON [CMSCore.Role].[UserLastModificationId] = [CMSCore.User.UserLastModificationId].[UserId]
ORDER BY 
    [CMSCore.Role].[RoleId]