CREATE PROCEDURE [dbo].[BasicCore.Failure.UpdateByFailureId]
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
DECLARE	@RowsAffected int
EXEC [dbo].[BasicCore.Failure.UpdateByFailureId]
    @FailureId = 1,
    @RowsAffected = @RowsAffected OUTPUT
SELECT @RowsAffected AS N'@RowsAffected'
 *
 */

--Last modification on: 20/12/2022 19:54:13

UPDATE [BasicCore.Failure] SET
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
    AND [BasicCore.Failure].[FailureId] = @FailureId 

SELECT @RowsAffected = @@ROWCOUNTimeLastModification
WHERE 
    1 = 1 
    AND [BasicCore.Failure].[FailureId] = @FailureId 

SELECT @RowsAffected = @@ROWCOUNT