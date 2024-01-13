CREATE PROCEDURE [dbo].[BasicCulture.Sex.DeleteBySexId]
(
    @SexId INT,
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
EXEC [dbo].[BasicCulture.Sex.DeleteBySexId]
    @SexId = 1,
    @RowsAffected = @RowsAffected OUTPUT
SELECT @RowsAffected AS N'@RowsAffected'
 *
 */

--Last modification on: 20/12/2022 20:18:05

DELETE FROM 
    [BasicCulture.Sex]
WHERE 
    1 = 1
    AND [BasicCulture.Sex].[SexId] = @SexId

SELECT @RowsAffected = @@ROWCOUNTE FROM 
    [BasicCulture.Sex]
WHERE 
    1 = 1
    AND [BasicCulture.Sex].[SexId] = @SexId

SELECT @RowsAffected = @@ROWCOUNT