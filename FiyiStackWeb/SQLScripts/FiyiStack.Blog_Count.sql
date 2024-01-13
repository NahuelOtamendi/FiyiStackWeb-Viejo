CREATE PROCEDURE [dbo].[FiyiStack.Blog.Count]

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

EXEC	@Counter = [dbo].[FiyiStack.Blog.Count]

SELECT	'Counter' = @Counter
 *
 */

--Last modification on: 20/12/2022 22:25:19

SELECT 
	COUNT(*)
FROM 
	[FiyiStack.Blog]
SELECT	'Counter' = @Counter
 *
 */

--Last modification on: 16/12/2022 10:50:10

SELECT 
	COUNT(*)
FROM 
	[FiyiStack.Blog]