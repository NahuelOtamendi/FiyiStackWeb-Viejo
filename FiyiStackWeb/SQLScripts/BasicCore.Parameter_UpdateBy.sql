CREATE PROCEDURE [dbo].[BasicCore.Parameter.UpdateByParameterId]
(
    @ParameterId INT,
    @Name VARCHAR(200),
    @Value VARCHAR(8000),
    @IsPrivate TINYINT,
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
EXEC [dbo].[BasicCore.Parameter.UpdateByParameterId]
    @ParameterId = 1,
    @RowsAffected = @RowsAffected OUTPUT
SELECT @RowsAffected AS N'@RowsAffected'
 *
 */

--Last modification on: 20/12/2022 19:56:32

UPDATE [BasicCore.Parameter] SET
    [Name] = @Name,
    [Value] = @Value,
    [IsPrivate] = @IsPrivate,
    [Active] = @Active,
    [UserCreationId] = @UserCreationId,
    [UserLastModificationId] = @UserLastModificationId,
    [DateTimeCreation] = @DateTimeCreation,
    [DateTimeLastModification] = @DateTimeLastModification
WHERE 
    1 = 1 
    AND [BasicCore.Parameter].[ParameterId] = @ParameterId 

SELECT @RowsAffected = @@ROWCOUNTtModification
WHERE 
    1 = 1 
    AND [BasicCore.Parameter].[ParameterId]