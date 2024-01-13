CREATE PROCEDURE [dbo].[BasicCulture.Country.UpdateByCountryId]
(
    @CountryId INT,
    @Name VARCHAR(500),
    @GeographicalCoordinates VARCHAR(200),
    @Code VARCHAR(100),
    @PlanetId INT,
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
EXEC [dbo].[BasicCulture.Country.UpdateByCountryId]
    @CountryId = 1,
    @RowsAffected = @RowsAffected OUTPUT
SELECT @RowsAffected AS N'@RowsAffected'
 *
 */

--Last modification on: 20/12/2022 20:09:00

UPDATE [BasicCulture.Country] SET
    [Name] = @Name,
    [GeographicalCoordinates] = @GeographicalCoordinates,
    [Code] = @Code,
    [PlanetId] = @PlanetId,
    [Active] = @Active,
    [UserCreationId] = @UserCreationId,
    [UserLastModificationId] = @UserLastModificationId,
    [DateTimeCreation] = @DateTimeCreation,
    [DateTimeLastModification] = @DateTimeLastModification
WHERE 
    1 = 1 
    AND [BasicCulture.Country].[CountryId] = @CountryId 

SELECT @RowsAffected = @@ROWCOUNT