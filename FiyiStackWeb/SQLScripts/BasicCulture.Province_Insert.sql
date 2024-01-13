CREATE PROCEDURE [dbo].[BasicCulture.Province.Insert] 
(
    @Name VARCHAR(500),
    @GeographicalCoordinates VARCHAR(200),
    @Code VARCHAR(100),
    @CountryId INT,
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
EXEC [dbo].[BasicCulture.Province.Insert]

    @Name = N'PutName',
    @GeographicalCoordinates = N'PutGeographicalCoordinates',
    @Code = N'PutCode',
     @CountryId = 1,
    @Active = 1,
    @UserCreationId = 1,
    @UserLastModificationId = 1,
    @DateTimeCreation = N'01/01/1753 0:00:00.001',
    @DateTimeLastModification = N'01/01/1753 0:00:00.001',

@NewEnteredId = @NewEnteredId OUTPUT

SELECT @NewEnteredId AS N'@NewEnteredId'
 *
 */

--Last modification on: 20/12/2022 20:14:58

INSERT INTO [BasicCulture.Province]
(
    [Name],
    [GeographicalCoordinates],
    [Code],
    [CountryId],
    [Active],
    [UserCreationId],
    [UserLastModificationId],
    [DateTimeCreation],
    [DateTimeLastModification]
)
VALUES
(
    @Name,
    @GeographicalCoordinates,
    @Code,
    @CountryId,
    @Active,
    @UserCreationId,
    @UserLastModificationId,
    @DateTimeCreation,
    @DateTimeLastModification
)

SELECT @NewEnteredId = @@IDENTITYtionId,
    @UserLastModificationId,
    @DateTimeCreation,
    @DateTimeLastModification
)

SELECT @NewEnteredId = @@IDENTITY