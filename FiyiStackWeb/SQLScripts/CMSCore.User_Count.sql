CREATE PROCEDURE [dbo].[CMSCore.User.Count]

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
DECLARE	@Counter int

EXEC	@Counter = [dbo].[CMSCore.User.Count]

SELECT	'Counter' = @Counter
 *
 */

--Last modification on: 20/12/2022 21:44:06

SELECT 
	COUNT(*)
FROM 
	[CMSCore.User]

SELECT	'Counter' = @Counter
 *
 */

--Last modification on: 15/12/2022 12:54:59

SELECT 
	COUNT(*)
FROM 
	[CMSCore.User]