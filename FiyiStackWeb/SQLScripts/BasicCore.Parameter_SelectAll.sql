CREATE PROCEDURE [dbo].[BasicCore.Parameter.SelectAll]

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
EXEC [dbo].[BasicCore.Parameter.SelectAll]
 *
 */

--Last modification on: 20/12/2022 19:56:32

SET DATEFORMAT DMY

SELECT
    [BasicCore.Parameter].[ParameterId],
    [BasicCore.Parameter].[Name],
    [BasicCore.Parameter].[Value],
    [BasicCore.Parameter].[IsPrivate],
    [BasicCore.Parameter].[Active],
    [BasicCore.Parameter].[UserCreationId],
    [BasicCore.Parameter].[UserLastModificationId],
    [BasicCore.Parameter].[DateTimeCreation],
    [BasicCore.Parameter].[DateTimeLastModification]
FROM 
    [BasicCore.Parameter]
    LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserCreationId] ON [BasicCore.Parameter].[UserCreationId] = [CMSCore.User.UserCreationId].[UserId]
	LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserLastModificationId] ON [BasicCore.Parameter].[UserLastModificationId] = [CMSCore.User.UserLastModificationId].[UserId]
ORDER BY 
    [BasicCore.Parameter].[ParameterId]