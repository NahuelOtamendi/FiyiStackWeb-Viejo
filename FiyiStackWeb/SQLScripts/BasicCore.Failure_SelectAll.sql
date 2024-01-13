CREATE PROCEDURE [dbo].[BasicCore.Failure.SelectAll]

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
EXEC [dbo].[BasicCore.Failure.SelectAll]
 *
 */

--Last modification on: 20/12/2022 19:54:13

SET DATEFORMAT DMY

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
ORDER BY 
    [BasicCore.Failure].[FailureId]