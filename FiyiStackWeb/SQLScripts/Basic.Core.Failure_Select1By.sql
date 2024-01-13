CREATE PROCEDURE [dbo].[Basic.Core.Failure.Select1ByFailureId]
(
    @FailureId INT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[Failure.Select1ByFailureId]
    @FailureId = 1
 *
 */

--Last modification on: 08/12/2022 6:38:40

SET DATEFORMAT DMY

SELECT
    [Basic.Core.Failure].[FailureId] AS [FailureId],
    [Basic.Core.Failure].[HTTPCode] AS [HTTPCode],
    [Basic.Core.Failure].[EmergencyLevel] AS [EmergencyLevel],
    [Basic.Core.Failure].[Message] AS [Message],
    [Basic.Core.Failure].[StackTrace] AS [StackTrace],
    [Basic.Core.Failure].[Source] AS [Source],
    [Basic.Core.Failure].[Comment] AS [Comment],
    [Basic.Core.Failure].[Active] AS [Active],
    [Basic.Core.Failure].[UserCreationId] AS [UserCreationId],
    [Basic.Core.Failure].[UserLastModificationId] AS [UserLastModificationId],
    [Basic.Core.Failure].[DateTimeCreation] AS [DateTimeCreation],
    [Basic.Core.Failure].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [Basic.Core.Failure]
WHERE 
    1 = 1
    AND [Basic.Core.Failure].[FailureId] = @FailureId
ORDER BY 
    [Basic.Core.Failure].[FailureId]]