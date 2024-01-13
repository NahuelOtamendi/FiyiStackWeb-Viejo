CREATE PROCEDURE [dbo].[Basic.Core.Failure.UpdateByFailureId]
(
    @FailureId INT,
    @HTTPCode INT,
    @EmergencyLevel INT,
    @Message VARCHAR(8000),
    @StackTrace VARCHAR(8000),
    @Source VARCHAR(8000),
    @Comment VARCHAR(8000),
    @Active TINYINT,
    @UserCreationId INT,
    @UserLastModificationId INT,
    @DateTimeCreation DATETIME,
    @DateTimeLastModification DATETIME,

    @RowsAffected INT OUTPUT
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
DECLARE	@RowsAffected int
EXEC [dbo].[Basic.Core.Failure.UpdateByFailureId]
    @FailureId = 1,
    @RowsAffected = @RowsAffected OUTPUT
SELECT @RowsAffected AS N'@RowsAffected'
 *
 */

--Last modification on: 08/12/2022 6:38:40

UPDATE [Basic.Core.Failure] SET
    [HTTPCode] = @HTTPCode,
    [EmergencyLevel] = @EmergencyLevel,
    [Message] = @Message,
    [StackTrace] = @StackTrace,
    [Source] = @Source,
    [Comment] = @Comment,
    [Active] = @Active,
    [UserCreationId] = @UserCreationId,
    [UserLastModificationId] = @UserLastModificationId,
    [DateTimeCreation] = @DateTimeCreation,
    [DateTimeLastModification] = @DateTimeLastModification
WHERE 
    1 = 1 
    AND [Basic.Core.Failure].[FailureId] = @FailureId 

SELECT @RowsAffected = @@ROWCOUNTT