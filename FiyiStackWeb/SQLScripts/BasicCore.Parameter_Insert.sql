CREATE PROCEDURE [dbo].[BasicCore.Parameter.Insert] 
(
    @Name VARCHAR(200),
    @Value VARCHAR(8000),
    @IsPrivate TINYINT,
    @Active TINYINT,
    @UserCreationId INT,
    @UserLastModificationId INT,
    @DateTimeCreation DATETIME,
    @DateTimeLastModification DATETIME,

    @NewEnteredId INT OUTPUT
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
DECLARE	@NewEnteredId INT
EXEC [dbo].[BasicCore.Parameter.Insert]

    @Name = N'PutName',
    @Value = N'PutValue',
    @IsPrivate = 1,
    @Active = 1,
    @UserCreationId = 1,
    @UserLastModificationId = 1,
    @DateTimeCreation = N'01/01/1753 0:00:00.001',
    @DateTimeLastModification = N'01/01/1753 0:00:00.001',

@NewEnteredId = @NewEnteredId OUTPUT

SELECT @NewEnteredId AS N'@NewEnteredId'
 *
 */

--Last modification on: 20/12/2022 19:56:32

INSERT INTO [BasicCore.Parameter]
(
    [Name],
    [Value],
    [IsPrivate],
    [Active],
    [UserCreationId],
    [UserLastModificationId],
    [DateTimeCreation],
    [DateTimeLastModification]
)
VALUES
(
    @Name,
    @Value,
    @IsPrivate,
    @Active,
    @UserCreationId,
    @UserLastModificationId,
    @DateTimeCreation,
    @DateTimeLastModification
)

SELECT @NewEnteredId = @@IDENTITY