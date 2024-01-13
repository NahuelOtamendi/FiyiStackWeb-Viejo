CREATE PROCEDURE [dbo].[CMSCore.Menu.UpdateByMenuId]
(
    @MenuId INT,
    @Name VARCHAR(200),
    @MenuFatherId INT,
    @Order INT,
    @URLPath VARCHAR(8000),
    @IconURLPath VARCHAR(8000),
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
EXEC [dbo].[CMSCore.Menu.UpdateByMenuId]
    @MenuId = 1,
    @RowsAffected = @RowsAffected OUTPUT
SELECT @RowsAffected AS N'@RowsAffected'
 *
 */

--Last modification on: 20/12/2022 20:22:13

UPDATE [CMSCore.Menu] SET
    [Name] = @Name,
    [MenuFatherId] = @MenuFatherId,
    [Order] = @Order,
    [URLPath] = @URLPath,
    [IconURLPath] = @IconURLPath,
    [Active] = @Active,
    [UserCreationId] = @UserCreationId,
    [UserLastModificationId] = @UserLastModificationId,
    [DateTimeCreation] = @DateTimeCreation,
    [DateTimeLastModification] = @DateTimeLastModification
WHERE 
    1 = 1 
    AND [CMSCore.Menu].[MenuId] = @MenuId 

SELECT @RowsAffected = @@ROWCOUNTon] = @DateTimeLastModification
WHERE 
    1 = 1 
    AND [CMSCore.Menu].[MenuId] = @MenuId 

SELECT @RowsAffected = @@ROWCOUNT