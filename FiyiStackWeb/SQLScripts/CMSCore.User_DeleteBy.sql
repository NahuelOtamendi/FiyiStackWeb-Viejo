CREATE PROCEDURE [dbo].[CMSCore.User.DeleteByUserId]
(
    @UserId INT,
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
DECLARE	@RowsAffected INT
EXEC [dbo].[CMSCore.User.DeleteByUserId]
    @UserId = 1,
    @RowsAffected = @RowsAffected OUTPUT
SELECT @RowsAffected AS N'@RowsAffected'
 *
 */

--Last modification on: 20/12/2022 21:44:05

DELETE FROM 
    [CMSCore.User]
WHERE 
    1 = 1
    AND [CMSCore.User].[UserId] = @UserId

SELECT @RowsAffected = @@ROWCOUNT
DELETE FROM 
    [CMSCore.User]
WHERE 
    1 = 1
    AND [CMSCore.User].[UserId] = @UserId

SELECT @RowsAffected = @@ROWCOUNT