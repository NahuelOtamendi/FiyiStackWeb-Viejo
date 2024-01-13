CREATE PROCEDURE [dbo].[CMSCore.RoleMenu.Select1ByRoleMenuId]
(
    @RoleMenuId INT
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
EXEC [dbo].[RoleMenu.Select1ByRoleMenuId]
    @RoleMenuId = 1
 *
 */

--Last modification on: 20/12/2022 20:28:32

SET DATEFORMAT DMY

SELECT
    [CMSCore.RoleMenu].[RoleMenuId],
    [CMSCore.RoleMenu].[RoleId],
    [CMSCore.RoleMenu].[MenuId],
    [CMSCore.RoleMenu].[Active],
    [CMSCore.RoleMenu].[UserCreationId],
    [CMSCore.RoleMenu].[UserLastModificationId],
    [CMSCore.RoleMenu].[DateTimeCreation],
    [CMSCore.RoleMenu].[DateTimeLastModification]
FROM 
    [CMSCore.RoleMenu]
    LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserCreationId] ON [CMSCore.RoleMenu].[UserCreationId] = [CMSCore.User.UserCreationId].[UserId]
	LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserLastModificationId] ON [CMSCore.RoleMenu].[UserLastModificationId] = [CMSCore.User.UserLastModificationId].[UserId]
WHERE 
    1 = 1
    AND [CMSCore.RoleMenu].[RoleMenuId] = @RoleMenuId
ORDER BY 
    [CMSCore.RoleMenu].[RoleMenuId]