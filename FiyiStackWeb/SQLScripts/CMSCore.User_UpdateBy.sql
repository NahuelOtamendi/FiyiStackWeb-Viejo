CREATE PROCEDURE [dbo].[CMSCore.User.UpdateByUserId]
(
    @UserId INT,
    @FantasyName VARCHAR(200),
    @Email VARCHAR(320),
    @Password VARCHAR(8000),
    @RoleId INT,
    @Active TINYINT,
    @UserCreationId INT,
    @UserLastModificationId INT,
    @DateTimeCreation DATETIME,
    @DateTimeLastModification DATETIME,
    @RegistrationToken VARCHAR(8000),

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
EXEC [dbo].[CMSCore.User.UpdateByUserId]
    @UserId = 1,
    @RowsAffected = @RowsAffected OUTPUT
SELECT @RowsAffected AS N'@RowsAffected'
 *
 */

--Last modification on: 20/12/2022 21:44:05

UPDATE [CMSCore.User] SET
    [FantasyName] = @FantasyName,
    [Email] = @Email,
    [Password] = @Password,
    [RoleId] = @RoleId,
    [Active] = @Active,
    [UserCreationId] = @UserCreationId,
    [UserLastModificationId] = @UserLastModificationId,
    [DateTimeCreation] = @DateTimeCreation,
    [DateTimeLastModification] = @DateTimeLastModification,
    [RegistrationToken] = @RegistrationToken
WHERE 
    1 = 1 
    AND [CMSCore.User].[UserId] = @UserId 

SELECT @RowsAffected = @@ROWCOUNTtionToken] = @RegistrationToken
WHERE 
    1 = 1 
    AND [CMSCore.User].[UserId] = @UserId 

SELECT @RowsAffected = @@ROWCOUNT