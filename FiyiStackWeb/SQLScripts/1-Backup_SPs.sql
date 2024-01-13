USE [fiyistack_FiyiStackWeb]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.User.UpdateByUserId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.User.UpdateByUserId]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.User.SelectAllPaged]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.User.SelectAllPaged]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.User.SelectAll]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.User.SelectAll]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.User.Select1ByUserId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.User.Select1ByUserId]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.User.Login]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.User.Login]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.User.Insert]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.User.Insert]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.User.DeleteByUserId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.User.DeleteByUserId]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.User.DeleteAll]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.User.DeleteAll]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.User.Count]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.User.Count]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.RoleMenu.UpdateByRoleMenuId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.RoleMenu.UpdateByRoleMenuId]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.RoleMenu.UpdateByRoleIdByMenuId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.RoleMenu.UpdateByRoleIdByMenuId]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.RoleMenu.SelectMenuesByRoleId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.RoleMenu.SelectMenuesByRoleId]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.RoleMenu.SelectAllPaged]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.RoleMenu.SelectAllPaged]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.RoleMenu.SelectAllByRoleId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.RoleMenu.SelectAllByRoleId]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.RoleMenu.SelectAll]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.RoleMenu.SelectAll]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.RoleMenu.Select1ByRoleMenuId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.RoleMenu.Select1ByRoleMenuId]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.RoleMenu.Insert]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.RoleMenu.Insert]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.RoleMenu.DeleteByRoleMenuId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.RoleMenu.DeleteByRoleMenuId]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.RoleMenu.DeleteAll]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.RoleMenu.DeleteAll]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.RoleMenu.Count]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.RoleMenu.Count]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Role.UpdateByRoleId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.Role.UpdateByRoleId]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Role.SelectAllPaged]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.Role.SelectAllPaged]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Role.SelectAll]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.Role.SelectAll]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Role.Select1ByRoleId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.Role.Select1ByRoleId]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Role.Insert]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.Role.Insert]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Role.DeleteByRoleId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.Role.DeleteByRoleId]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Role.DeleteAll]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.Role.DeleteAll]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Role.Count]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.Role.Count]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Menu.UpdateByMenuId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.Menu.UpdateByMenuId]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Menu.SelectAllPaged]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.Menu.SelectAllPaged]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Menu.SelectAll]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.Menu.SelectAll]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Menu.Select1ByMenuId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.Menu.Select1ByMenuId]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Menu.Insert]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.Menu.Insert]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Menu.DeleteByMenuId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.Menu.DeleteByMenuId]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Menu.DeleteAll]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.Menu.DeleteAll]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Menu.Count]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[CMSCore.Menu.Count]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Sex.UpdateBySexId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Sex.UpdateBySexId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Sex.SelectAllPaged]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Sex.SelectAllPaged]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Sex.SelectAll]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Sex.SelectAll]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Sex.Select1BySexId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Sex.Select1BySexId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Sex.Insert]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Sex.Insert]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Sex.DeleteBySexId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Sex.DeleteBySexId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Sex.DeleteAll]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Sex.DeleteAll]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Sex.Count]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Sex.Count]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Province.UpdateByProvinceId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Province.UpdateByProvinceId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Province.SelectAllPaged]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Province.SelectAllPaged]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Province.SelectAll]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Province.SelectAll]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Province.Select1ByProvinceId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Province.Select1ByProvinceId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Province.Insert]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Province.Insert]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Province.DeleteByProvinceId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Province.DeleteByProvinceId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Province.DeleteAll]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Province.DeleteAll]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Province.Count]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Province.Count]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Planet.UpdateByPlanetId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Planet.UpdateByPlanetId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Planet.SelectAllPaged]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Planet.SelectAllPaged]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Planet.SelectAll]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Planet.SelectAll]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Planet.Select1ByPlanetId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Planet.Select1ByPlanetId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Planet.Insert]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Planet.Insert]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Planet.DeleteByPlanetId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Planet.DeleteByPlanetId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Planet.DeleteAll]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Planet.DeleteAll]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Planet.Count]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Planet.Count]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Country.UpdateByCountryId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Country.UpdateByCountryId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Country.SelectAllPaged]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Country.SelectAllPaged]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Country.SelectAll]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Country.SelectAll]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Country.Select1ByCountryId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Country.Select1ByCountryId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Country.Insert]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Country.Insert]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Country.DeleteByCountryId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Country.DeleteByCountryId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Country.DeleteAll]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Country.DeleteAll]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Country.Count]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.Country.Count]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.City.UpdateByCityId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.City.UpdateByCityId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.City.SelectAllPaged]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.City.SelectAllPaged]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.City.SelectAll]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.City.SelectAll]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.City.Select1ByCityId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.City.Select1ByCityId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.City.Insert]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.City.Insert]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.City.DeleteByCityId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.City.DeleteByCityId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.City.DeleteAll]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.City.DeleteAll]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.City.Count]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCulture.City.Count]
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Parameter.UpdateByParameterId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCore.Parameter.UpdateByParameterId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Parameter.SelectAllPaged]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCore.Parameter.SelectAllPaged]
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Parameter.SelectAll]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCore.Parameter.SelectAll]
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Parameter.Select1ByParameterId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCore.Parameter.Select1ByParameterId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Parameter.Insert]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCore.Parameter.Insert]
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Parameter.DeleteByParameterId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCore.Parameter.DeleteByParameterId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Parameter.DeleteAll]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCore.Parameter.DeleteAll]
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Parameter.Count]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCore.Parameter.Count]
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Failure.UpdateByFailureId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCore.Failure.UpdateByFailureId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Failure.SelectAllPaged]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCore.Failure.SelectAllPaged]
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Failure.SelectAll]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCore.Failure.SelectAll]
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Failure.Select1ByFailureId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCore.Failure.Select1ByFailureId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Failure.Insert]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCore.Failure.Insert]
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Failure.DeleteByFailureId]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCore.Failure.DeleteByFailureId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Failure.DeleteAll]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCore.Failure.DeleteAll]
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Failure.Count]    Script Date: 13/12/2022 20:49:48 ******/
DROP PROCEDURE [dbo].[BasicCore.Failure.Count]
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Failure.Count]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCore.Failure.Count]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@Counter int

EXEC	@Counter = [dbo].[BasicCore.Failure.Count]

SELECT	'Counter' = @Counter
 *
 */

--Last modification on: 08/12/2022 7:45:13

SELECT 
	COUNT(*)
FROM 
	[BasicCore.Failure]
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Failure.DeleteAll]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCore.Failure.DeleteAll]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[BasicCore.Failure.DeleteAll]
 *
 */

--Last modification on: 08/12/2022 7:45:13

DELETE FROM [BasicCore.Failure]
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Failure.DeleteByFailureId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCore.Failure.DeleteByFailureId]
(
    @FailureId INT,
    @RowsAffected INT OUTPUT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@RowsAffected INT
EXEC [dbo].[BasicCore.Failure.DeleteByFailureId]
    @FailureId = 1,
    @RowsAffected = @RowsAffected OUTPUT
SELECT @RowsAffected AS N'@RowsAffected'
 *
 */

--Last modification on: 08/12/2022 7:45:13

DELETE FROM 
    [BasicCore.Failure]
WHERE 
    1 = 1
    AND [BasicCore.Failure].[FailureId] = @FailureId

SELECT @RowsAffected = @@ROWCOUNT
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Failure.Insert]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCore.Failure.Insert] 
(
    @HTTPCode INT,
    @EmergencyLevel INT,
    @Message VARCHAR(8000),
    @StackTrace VARCHAR(8000),
    @Source VARCHAR(8000),
    @Comment VARCHAR(8000),
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
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@NewEnteredId INT
EXEC [dbo].[BasicCore.Failure.Insert]

    @HTTPCode = 1,
    @EmergencyLevel = 1,
    @Message = N'PutMessage',
    @StackTrace = N'PutStackTrace',
    @Source = N'PutSource',
    @Comment = N'PutComment',
    @Active = 1,
    @UserCreationId = 1,
    @UserLastModificationId = 1,
    @DateTimeCreation = N'01/01/1753 0:00:00.001',
    @DateTimeLastModification = N'01/01/1753 0:00:00.001',

@NewEnteredId = @NewEnteredId OUTPUT

SELECT @NewEnteredId AS N'@NewEnteredId'
 *
 */

--Last modification on: 08/12/2022 7:45:13

INSERT INTO [BasicCore.Failure]
(
    [HTTPCode],
    [EmergencyLevel],
    [Message],
    [StackTrace],
    [Source],
    [Comment],
    [Active],
    [UserCreationId],
    [UserLastModificationId],
    [DateTimeCreation],
    [DateTimeLastModification]
)
VALUES
(
    @HTTPCode,
    @EmergencyLevel,
    @Message,
    @StackTrace,
    @Source,
    @Comment,
    @Active,
    @UserCreationId,
    @UserLastModificationId,
    @DateTimeCreation,
    @DateTimeLastModification
)

SELECT @NewEnteredId = @@IDENTITY
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Failure.Select1ByFailureId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCore.Failure.Select1ByFailureId]
(
    @FailureId INT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[Failure.Select1ByFailureId]
    @FailureId = 1
 *
 */

--Last modification on: 08/12/2022 7:45:13

SET DATEFORMAT DMY

SELECT
    [BasicCore.Failure].[FailureId] AS [FailureId],
    [BasicCore.Failure].[HTTPCode] AS [HTTPCode],
    [BasicCore.Failure].[EmergencyLevel] AS [EmergencyLevel],
    [BasicCore.Failure].[Message] AS [Message],
    [BasicCore.Failure].[StackTrace] AS [StackTrace],
    [BasicCore.Failure].[Source] AS [Source],
    [BasicCore.Failure].[Comment] AS [Comment],
    [BasicCore.Failure].[Active] AS [Active],
    [BasicCore.Failure].[UserCreationId] AS [UserCreationId],
    [BasicCore.Failure].[UserLastModificationId] AS [UserLastModificationId],
    [BasicCore.Failure].[DateTimeCreation] AS [DateTimeCreation],
    [BasicCore.Failure].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [BasicCore.Failure]
WHERE 
    1 = 1
    AND [BasicCore.Failure].[FailureId] = @FailureId
ORDER BY 
    [BasicCore.Failure].[FailureId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Failure.SelectAll]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCore.Failure.SelectAll]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[BasicCore.Failure.SelectAll]
 *
 */

--Last modification on: 08/12/2022 7:45:13

SET DATEFORMAT DMY

SELECT
    [BasicCore.Failure].[FailureId] AS [FailureId],
    [BasicCore.Failure].[HTTPCode] AS [HTTPCode],
    [BasicCore.Failure].[EmergencyLevel] AS [EmergencyLevel],
    [BasicCore.Failure].[Message] AS [Message],
    [BasicCore.Failure].[StackTrace] AS [StackTrace],
    [BasicCore.Failure].[Source] AS [Source],
    [BasicCore.Failure].[Comment] AS [Comment],
    [BasicCore.Failure].[Active] AS [Active],
    [BasicCore.Failure].[UserCreationId] AS [UserCreationId],
    [BasicCore.Failure].[UserLastModificationId] AS [UserLastModificationId],
    [BasicCore.Failure].[DateTimeCreation] AS [DateTimeCreation],
    [BasicCore.Failure].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [BasicCore.Failure]
ORDER BY 
    [BasicCore.Failure].[FailureId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Failure.SelectAllPaged]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCore.Failure.SelectAllPaged]
(
    @QueryString VARCHAR(100),
    @ActualPageNumber INT,
    @RowsPerPage INT,
    @SorterColumn VARCHAR(100),
    @SortToggler TINYINT,
    @TotalRows INT OUTPUT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*Execute this stored procedure with the next script as example

DECLARE	@TotalRows int
EXEC [dbo].[BasicCore.Failure.SelectAllPaged]
    
    @QueryString = N'',
    @ActualPageNumber = 1,
    @RowsPerPage = 10,
    @SorterColumn = N'FailureId',
    @SortToggler = 0,
    @TotalRows = @TotalRows OUTPUT

SELECT @TotalRows AS N'@TotalRows'
*/

--Last modification on: 08/12/2022 7:45:13

SET DATEFORMAT DMY
SET NOCOUNT ON

SELECT
    [BasicCore.Failure].[FailureId] AS [FailureId],
    [BasicCore.Failure].[HTTPCode] AS [HTTPCode],
    [BasicCore.Failure].[EmergencyLevel] AS [EmergencyLevel],
    [BasicCore.Failure].[Message] AS [Message],
    [BasicCore.Failure].[StackTrace] AS [StackTrace],
    [BasicCore.Failure].[Source] AS [Source],
    [BasicCore.Failure].[Comment] AS [Comment],
    [BasicCore.Failure].[Active] AS [Active],
    [BasicCore.Failure].[UserCreationId] AS [UserCreationId],
    [BasicCore.Failure].[UserLastModificationId] AS [UserLastModificationId],
    [BasicCore.Failure].[DateTimeCreation] AS [DateTimeCreation],
    [BasicCore.Failure].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [BasicCore.Failure]
WHERE
    1=1
    AND (@QueryString = '' 
        OR ([BasicCore.Failure].[FailureId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Failure].[HTTPCode] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Failure].[EmergencyLevel] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Failure].[Message] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Failure].[StackTrace] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Failure].[Source] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Failure].[Comment] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Failure].[Active] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Failure].[UserCreationId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Failure].[UserLastModificationId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Failure].[DateTimeCreation] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Failure].[DateTimeLastModification] LIKE  '%' + @QueryString + '%')

    )
ORDER BY 
    CASE WHEN (@SorterColumn = 'FailureId' AND @SortToggler = 0) THEN [FailureId] END ASC,
    CASE WHEN (@SorterColumn = 'FailureId' AND @SortToggler = 1) THEN [FailureId] END DESC,
    CASE WHEN (@SorterColumn = 'HTTPCode' AND @SortToggler = 0) THEN [HTTPCode] END ASC,
    CASE WHEN (@SorterColumn = 'HTTPCode' AND @SortToggler = 1) THEN [HTTPCode] END DESC,
    CASE WHEN (@SorterColumn = 'EmergencyLevel' AND @SortToggler = 0) THEN [EmergencyLevel] END ASC,
    CASE WHEN (@SorterColumn = 'EmergencyLevel' AND @SortToggler = 1) THEN [EmergencyLevel] END DESC,
    CASE WHEN (@SorterColumn = 'Message' AND @SortToggler = 0) THEN [Message] END ASC,
    CASE WHEN (@SorterColumn = 'Message' AND @SortToggler = 1) THEN [Message] END DESC,
    CASE WHEN (@SorterColumn = 'StackTrace' AND @SortToggler = 0) THEN [StackTrace] END ASC,
    CASE WHEN (@SorterColumn = 'StackTrace' AND @SortToggler = 1) THEN [StackTrace] END DESC,
    CASE WHEN (@SorterColumn = 'Source' AND @SortToggler = 0) THEN [Source] END ASC,
    CASE WHEN (@SorterColumn = 'Source' AND @SortToggler = 1) THEN [Source] END DESC,
    CASE WHEN (@SorterColumn = 'Comment' AND @SortToggler = 0) THEN [Comment] END ASC,
    CASE WHEN (@SorterColumn = 'Comment' AND @SortToggler = 1) THEN [Comment] END DESC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 0) THEN [Active] END ASC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 1) THEN [Active] END DESC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 0) THEN [UserCreationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 1) THEN [UserCreationId] END DESC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 0) THEN [UserLastModificationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 1) THEN [UserLastModificationId] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 0) THEN [DateTimeCreation] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 1) THEN [DateTimeCreation] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 0) THEN [DateTimeLastModification] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 1) THEN [DateTimeLastModification] END DESC

OFFSET (@ActualPageNumber - 1) * @RowsPerPage ROWS
FETCH NEXT @RowsPerPage ROWS ONLY
SELECT @TotalRows = COUNT(*) FROM [BasicCore.Failure]
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Failure.UpdateByFailureId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCore.Failure.UpdateByFailureId]
(
    @FailureId INT,
    @HTTPCode INT,
    @EmergencyLevel INT,
    @Message VARCHAR(8000),
    @StackTrace VARCHAR(8000),
    @Source VARCHAR(8000),
    @Comment VARCHAR(8000),
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
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@RowsAffected int
EXEC [dbo].[BasicCore.Failure.UpdateByFailureId]
    @FailureId = 1,
    @RowsAffected = @RowsAffected OUTPUT
SELECT @RowsAffected AS N'@RowsAffected'
 *
 */

--Last modification on: 08/12/2022 7:45:13

UPDATE [BasicCore.Failure] SET
    [HTTPCode] = @HTTPCode,
    [EmergencyLevel] = @EmergencyLevel,
    [Message] = @Message,
    [StackTrace] = @StackTrace,
    [Source] = @Source,
    [Comment] = @Comment,
    [Active] = @Active,
    [UserCreationId] = @UserCreationId,
    [UserLastModificationId] = @UserLastModificationId,
    [DateTimeCreation] = @DateTimeCreation,
    [DateTimeLastModification] = @DateTimeLastModification
WHERE 
    1 = 1 
    AND [BasicCore.Failure].[FailureId] = @FailureId 

SELECT @RowsAffected = @@ROWCOUNT
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Parameter.Count]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCore.Parameter.Count]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@Counter int

EXEC	@Counter = [dbo].[BasicCore.Parameter.Count]

SELECT	'Counter' = @Counter
 *
 */

--Last modification on: 08/12/2022 8:07:23

SELECT 
	COUNT(*)
FROM 
	[BasicCore.Parameter]
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Parameter.DeleteAll]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCore.Parameter.DeleteAll]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[BasicCore.Parameter.DeleteAll]
 *
 */

--Last modification on: 08/12/2022 8:07:23

DELETE FROM [BasicCore.Parameter]
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Parameter.DeleteByParameterId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCore.Parameter.DeleteByParameterId]
(
    @ParameterId INT,
    @RowsAffected INT OUTPUT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@RowsAffected INT
EXEC [dbo].[BasicCore.Parameter.DeleteByParameterId]
    @ParameterId = 1,
    @RowsAffected = @RowsAffected OUTPUT
SELECT @RowsAffected AS N'@RowsAffected'
 *
 */

--Last modification on: 08/12/2022 8:07:23

DELETE FROM 
    [BasicCore.Parameter]
WHERE 
    1 = 1
    AND [BasicCore.Parameter].[ParameterId] = @ParameterId

SELECT @RowsAffected = @@ROWCOUNT
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Parameter.Insert]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

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
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
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

--Last modification on: 08/12/2022 8:07:23

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
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Parameter.Select1ByParameterId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCore.Parameter.Select1ByParameterId]
(
    @ParameterId INT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[Parameter.Select1ByParameterId]
    @ParameterId = 1
 *
 */

--Last modification on: 08/12/2022 8:07:23

SET DATEFORMAT DMY

SELECT
    [BasicCore.Parameter].[ParameterId] AS [ParameterId],
    [BasicCore.Parameter].[Name] AS [Name],
    [BasicCore.Parameter].[Value] AS [Value],
    [BasicCore.Parameter].[IsPrivate] AS [IsPrivate],
    [BasicCore.Parameter].[Active] AS [Active],
    [BasicCore.Parameter].[UserCreationId] AS [UserCreationId],
    [BasicCore.Parameter].[UserLastModificationId] AS [UserLastModificationId],
    [BasicCore.Parameter].[DateTimeCreation] AS [DateTimeCreation],
    [BasicCore.Parameter].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [BasicCore.Parameter]
WHERE 
    1 = 1
    AND [BasicCore.Parameter].[ParameterId] = @ParameterId
ORDER BY 
    [BasicCore.Parameter].[ParameterId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Parameter.SelectAll]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCore.Parameter.SelectAll]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[BasicCore.Parameter.SelectAll]
 *
 */

--Last modification on: 08/12/2022 8:07:23

SET DATEFORMAT DMY

SELECT
    [BasicCore.Parameter].[ParameterId] AS [ParameterId],
    [BasicCore.Parameter].[Name] AS [Name],
    [BasicCore.Parameter].[Value] AS [Value],
    [BasicCore.Parameter].[IsPrivate] AS [IsPrivate],
    [BasicCore.Parameter].[Active] AS [Active],
    [BasicCore.Parameter].[UserCreationId] AS [UserCreationId],
    [BasicCore.Parameter].[UserLastModificationId] AS [UserLastModificationId],
    [BasicCore.Parameter].[DateTimeCreation] AS [DateTimeCreation],
    [BasicCore.Parameter].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [BasicCore.Parameter]
ORDER BY 
    [BasicCore.Parameter].[ParameterId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Parameter.SelectAllPaged]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCore.Parameter.SelectAllPaged]
(
    @QueryString VARCHAR(100),
    @ActualPageNumber INT,
    @RowsPerPage INT,
    @SorterColumn VARCHAR(100),
    @SortToggler TINYINT,
    @TotalRows INT OUTPUT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*Execute this stored procedure with the next script as example

DECLARE	@TotalRows int
EXEC [dbo].[BasicCore.Parameter.SelectAllPaged]
    
    @QueryString = N'',
    @ActualPageNumber = 1,
    @RowsPerPage = 10,
    @SorterColumn = N'ParameterId',
    @SortToggler = 0,
    @TotalRows = @TotalRows OUTPUT

SELECT @TotalRows AS N'@TotalRows'
*/

--Last modification on: 08/12/2022 8:07:23

SET DATEFORMAT DMY
SET NOCOUNT ON

SELECT
    [BasicCore.Parameter].[ParameterId] AS [ParameterId],
    [BasicCore.Parameter].[Name] AS [Name],
    [BasicCore.Parameter].[Value] AS [Value],
    [BasicCore.Parameter].[IsPrivate] AS [IsPrivate],
    [BasicCore.Parameter].[Active] AS [Active],
    [BasicCore.Parameter].[UserCreationId] AS [UserCreationId],
    [BasicCore.Parameter].[UserLastModificationId] AS [UserLastModificationId],
    [BasicCore.Parameter].[DateTimeCreation] AS [DateTimeCreation],
    [BasicCore.Parameter].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [BasicCore.Parameter]
WHERE
    1=1
    AND (@QueryString = '' 
        OR ([BasicCore.Parameter].[ParameterId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Parameter].[Name] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Parameter].[Value] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Parameter].[IsPrivate] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Parameter].[Active] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Parameter].[UserCreationId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Parameter].[UserLastModificationId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Parameter].[DateTimeCreation] LIKE  '%' + @QueryString + '%')
        OR ([BasicCore.Parameter].[DateTimeLastModification] LIKE  '%' + @QueryString + '%')

    )
ORDER BY 
    CASE WHEN (@SorterColumn = 'ParameterId' AND @SortToggler = 0) THEN [ParameterId] END ASC,
    CASE WHEN (@SorterColumn = 'ParameterId' AND @SortToggler = 1) THEN [ParameterId] END DESC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 0) THEN [Name] END ASC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 1) THEN [Name] END DESC,
    CASE WHEN (@SorterColumn = 'Value' AND @SortToggler = 0) THEN [Value] END ASC,
    CASE WHEN (@SorterColumn = 'Value' AND @SortToggler = 1) THEN [Value] END DESC,
    CASE WHEN (@SorterColumn = 'IsPrivate' AND @SortToggler = 0) THEN [IsPrivate] END ASC,
    CASE WHEN (@SorterColumn = 'IsPrivate' AND @SortToggler = 1) THEN [IsPrivate] END DESC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 0) THEN [Active] END ASC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 1) THEN [Active] END DESC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 0) THEN [UserCreationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 1) THEN [UserCreationId] END DESC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 0) THEN [UserLastModificationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 1) THEN [UserLastModificationId] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 0) THEN [DateTimeCreation] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 1) THEN [DateTimeCreation] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 0) THEN [DateTimeLastModification] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 1) THEN [DateTimeLastModification] END DESC

OFFSET (@ActualPageNumber - 1) * @RowsPerPage ROWS
FETCH NEXT @RowsPerPage ROWS ONLY
SELECT @TotalRows = COUNT(*) FROM [BasicCore.Parameter]
GO

/****** Object:  StoredProcedure [dbo].[BasicCore.Parameter.UpdateByParameterId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

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
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
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

--Last modification on: 08/12/2022 8:07:23

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

SELECT @RowsAffected = @@ROWCOUNT
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.City.Count]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.City.Count]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@Counter int

EXEC	@Counter = [dbo].[BasicCulture.City.Count]

SELECT	'Counter' = @Counter
 *
 */

--Last modification on: 09/12/2022 19:23:11

SELECT 
	COUNT(*)
FROM 
	[BasicCulture.City]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.City.DeleteAll]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.City.DeleteAll]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[BasicCulture.City.DeleteAll]
 *
 */

--Last modification on: 09/12/2022 19:23:11

DELETE FROM [BasicCulture.City]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.City.DeleteByCityId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.City.DeleteByCityId]
(
    @CityId INT,
    @RowsAffected INT OUTPUT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@RowsAffected INT
EXEC [dbo].[BasicCulture.City.DeleteByCityId]
    @CityId = 1,
    @RowsAffected = @RowsAffected OUTPUT
SELECT @RowsAffected AS N'@RowsAffected'
 *
 */

--Last modification on: 09/12/2022 19:23:11

DELETE FROM 
    [BasicCulture.City]
WHERE 
    1 = 1
    AND [BasicCulture.City].[CityId] = @CityId

SELECT @RowsAffected = @@ROWCOUNT
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.City.Insert]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.City.Insert] 
(
    @Name VARCHAR(500),
    @GeographicalCoordinates VARCHAR(200),
    @Code VARCHAR(100),
    @ProvinceId INT,
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
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@NewEnteredId INT
EXEC [dbo].[BasicCulture.City.Insert]

    @Name = N'PutName',
    @GeographicalCoordinates = N'PutGeographicalCoordinates',
    @Code = N'PutCode',
     @ProvinceId = 1,
    @Active = 1,
    @UserCreationId = 1,
    @UserLastModificationId = 1,
    @DateTimeCreation = N'01/01/1753 0:00:00.001',
    @DateTimeLastModification = N'01/01/1753 0:00:00.001',

@NewEnteredId = @NewEnteredId OUTPUT

SELECT @NewEnteredId AS N'@NewEnteredId'
 *
 */

--Last modification on: 09/12/2022 19:23:11

INSERT INTO [BasicCulture.City]
(
    [Name],
    [GeographicalCoordinates],
    [Code],
    [ProvinceId],
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
    @ProvinceId,
    @Active,
    @UserCreationId,
    @UserLastModificationId,
    @DateTimeCreation,
    @DateTimeLastModification
)

SELECT @NewEnteredId = @@IDENTITY
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.City.Select1ByCityId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.City.Select1ByCityId]
(
    @CityId INT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[City.Select1ByCityId]
    @CityId = 1
 *
 */

--Last modification on: 09/12/2022 19:23:11

SET DATEFORMAT DMY

SELECT
    [BasicCulture.City].[CityId] AS [CityId],
    [BasicCulture.City].[Name] AS [Name],
    [BasicCulture.City].[GeographicalCoordinates] AS [GeographicalCoordinates],
    [BasicCulture.City].[Code] AS [Code],
    [BasicCulture.City].[ProvinceId] AS [ProvinceId],
    [BasicCulture.City].[Active] AS [Active],
    [BasicCulture.City].[UserCreationId] AS [UserCreationId],
    [BasicCulture.City].[UserLastModificationId] AS [UserLastModificationId],
    [BasicCulture.City].[DateTimeCreation] AS [DateTimeCreation],
    [BasicCulture.City].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [BasicCulture.City]
WHERE 
    1 = 1
    AND [BasicCulture.City].[CityId] = @CityId
ORDER BY 
    [BasicCulture.City].[CityId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.City.SelectAll]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.City.SelectAll]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[BasicCulture.City.SelectAll]
 *
 */

--Last modification on: 09/12/2022 19:23:11

SET DATEFORMAT DMY

SELECT
    [BasicCulture.City].[CityId] AS [CityId],
    [BasicCulture.City].[Name] AS [Name],
    [BasicCulture.City].[GeographicalCoordinates] AS [GeographicalCoordinates],
    [BasicCulture.City].[Code] AS [Code],
    [BasicCulture.City].[ProvinceId] AS [ProvinceId],
    [BasicCulture.City].[Active] AS [Active],
    [BasicCulture.City].[UserCreationId] AS [UserCreationId],
    [BasicCulture.City].[UserLastModificationId] AS [UserLastModificationId],
    [BasicCulture.City].[DateTimeCreation] AS [DateTimeCreation],
    [BasicCulture.City].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [BasicCulture.City]
ORDER BY 
    [BasicCulture.City].[CityId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.City.SelectAllPaged]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.City.SelectAllPaged]
(
    @QueryString VARCHAR(100),
    @ActualPageNumber INT,
    @RowsPerPage INT,
    @SorterColumn VARCHAR(100),
    @SortToggler TINYINT,
    @TotalRows INT OUTPUT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*Execute this stored procedure with the next script as example

DECLARE	@TotalRows int
EXEC [dbo].[BasicCulture.City.SelectAllPaged]
    
    @QueryString = N'',
    @ActualPageNumber = 1,
    @RowsPerPage = 10,
    @SorterColumn = N'CityId',
    @SortToggler = 0,
    @TotalRows = @TotalRows OUTPUT

SELECT @TotalRows AS N'@TotalRows'
*/

--Last modification on: 09/12/2022 19:23:11

SET DATEFORMAT DMY
SET NOCOUNT ON

SELECT
    [BasicCulture.City].[CityId] AS [CityId],
    [BasicCulture.City].[Name] AS [Name],
    [BasicCulture.City].[GeographicalCoordinates] AS [GeographicalCoordinates],
    [BasicCulture.City].[Code] AS [Code],
    [BasicCulture.City].[ProvinceId] AS [ProvinceId],
    [BasicCulture.City].[Active] AS [Active],
    [BasicCulture.City].[UserCreationId] AS [UserCreationId],
    [BasicCulture.City].[UserLastModificationId] AS [UserLastModificationId],
    [BasicCulture.City].[DateTimeCreation] AS [DateTimeCreation],
    [BasicCulture.City].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [BasicCulture.City]
WHERE
    1=1
    AND (@QueryString = '' 
        OR ([BasicCulture.City].[CityId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.City].[Name] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.City].[GeographicalCoordinates] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.City].[Code] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.City].[ProvinceId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.City].[Active] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.City].[UserCreationId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.City].[UserLastModificationId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.City].[DateTimeCreation] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.City].[DateTimeLastModification] LIKE  '%' + @QueryString + '%')

    )
ORDER BY 
    CASE WHEN (@SorterColumn = 'CityId' AND @SortToggler = 0) THEN [CityId] END ASC,
    CASE WHEN (@SorterColumn = 'CityId' AND @SortToggler = 1) THEN [CityId] END DESC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 0) THEN [Name] END ASC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 1) THEN [Name] END DESC,
    CASE WHEN (@SorterColumn = 'GeographicalCoordinates' AND @SortToggler = 0) THEN [GeographicalCoordinates] END ASC,
    CASE WHEN (@SorterColumn = 'GeographicalCoordinates' AND @SortToggler = 1) THEN [GeographicalCoordinates] END DESC,
    CASE WHEN (@SorterColumn = 'Code' AND @SortToggler = 0) THEN [Code] END ASC,
    CASE WHEN (@SorterColumn = 'Code' AND @SortToggler = 1) THEN [Code] END DESC,
    CASE WHEN (@SorterColumn = 'ProvinceId' AND @SortToggler = 0) THEN [ProvinceId] END ASC,
    CASE WHEN (@SorterColumn = 'ProvinceId' AND @SortToggler = 1) THEN [ProvinceId] END DESC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 0) THEN [Active] END ASC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 1) THEN [Active] END DESC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 0) THEN [UserCreationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 1) THEN [UserCreationId] END DESC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 0) THEN [UserLastModificationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 1) THEN [UserLastModificationId] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 0) THEN [DateTimeCreation] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 1) THEN [DateTimeCreation] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 0) THEN [DateTimeLastModification] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 1) THEN [DateTimeLastModification] END DESC

OFFSET (@ActualPageNumber - 1) * @RowsPerPage ROWS
FETCH NEXT @RowsPerPage ROWS ONLY
SELECT @TotalRows = COUNT(*) FROM [BasicCulture.City]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.City.UpdateByCityId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.City.UpdateByCityId]
(
    @CityId INT,
    @Name VARCHAR(500),
    @GeographicalCoordinates VARCHAR(200),
    @Code VARCHAR(100),
    @ProvinceId INT,
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
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@RowsAffected int
EXEC [dbo].[BasicCulture.City.UpdateByCityId]
    @CityId = 1,
    @RowsAffected = @RowsAffected OUTPUT
SELECT @RowsAffected AS N'@RowsAffected'
 *
 */

--Last modification on: 09/12/2022 19:23:11

UPDATE [BasicCulture.City] SET
    [Name] = @Name,
    [GeographicalCoordinates] = @GeographicalCoordinates,
    [Code] = @Code,
    [ProvinceId] = @ProvinceId,
    [Active] = @Active,
    [UserCreationId] = @UserCreationId,
    [UserLastModificationId] = @UserLastModificationId,
    [DateTimeCreation] = @DateTimeCreation,
    [DateTimeLastModification] = @DateTimeLastModification
WHERE 
    1 = 1 
    AND [BasicCulture.City].[CityId] = @CityId 

SELECT @RowsAffected = @@ROWCOUNT
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Country.Count]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.Country.Count]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@Counter int

EXEC	@Counter = [dbo].[BasicCulture.Country.Count]

SELECT	'Counter' = @Counter
 *
 */

--Last modification on: 09/12/2022 19:23:19

SELECT 
	COUNT(*)
FROM 
	[BasicCulture.Country]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Country.DeleteAll]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.Country.DeleteAll]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[BasicCulture.Country.DeleteAll]
 *
 */

--Last modification on: 09/12/2022 19:23:19

DELETE FROM [BasicCulture.Country]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Country.DeleteByCountryId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.Country.DeleteByCountryId]
(
    @CountryId INT,
    @RowsAffected INT OUTPUT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@RowsAffected INT
EXEC [dbo].[BasicCulture.Country.DeleteByCountryId]
    @CountryId = 1,
    @RowsAffected = @RowsAffected OUTPUT
SELECT @RowsAffected AS N'@RowsAffected'
 *
 */

--Last modification on: 09/12/2022 19:23:19

DELETE FROM 
    [BasicCulture.Country]
WHERE 
    1 = 1
    AND [BasicCulture.Country].[CountryId] = @CountryId

SELECT @RowsAffected = @@ROWCOUNT
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Country.Insert]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.Country.Insert] 
(
    @Name VARCHAR(500),
    @GeographicalCoordinates VARCHAR(200),
    @Code VARCHAR(100),
    @PlanetId INT,
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
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@NewEnteredId INT
EXEC [dbo].[BasicCulture.Country.Insert]

    @Name = N'PutName',
    @GeographicalCoordinates = N'PutGeographicalCoordinates',
    @Code = N'PutCode',
     @PlanetId = 1,
    @Active = 1,
    @UserCreationId = 1,
    @UserLastModificationId = 1,
    @DateTimeCreation = N'01/01/1753 0:00:00.001',
    @DateTimeLastModification = N'01/01/1753 0:00:00.001',

@NewEnteredId = @NewEnteredId OUTPUT

SELECT @NewEnteredId AS N'@NewEnteredId'
 *
 */

--Last modification on: 09/12/2022 19:23:19

INSERT INTO [BasicCulture.Country]
(
    [Name],
    [GeographicalCoordinates],
    [Code],
    [PlanetId],
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
    @PlanetId,
    @Active,
    @UserCreationId,
    @UserLastModificationId,
    @DateTimeCreation,
    @DateTimeLastModification
)

SELECT @NewEnteredId = @@IDENTITY
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Country.Select1ByCountryId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.Country.Select1ByCountryId]
(
    @CountryId INT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[Country.Select1ByCountryId]
    @CountryId = 1
 *
 */

--Last modification on: 09/12/2022 19:23:19

SET DATEFORMAT DMY

SELECT
    [BasicCulture.Country].[CountryId] AS [CountryId],
    [BasicCulture.Country].[Name] AS [Name],
    [BasicCulture.Country].[GeographicalCoordinates] AS [GeographicalCoordinates],
    [BasicCulture.Country].[Code] AS [Code],
    [BasicCulture.Country].[PlanetId] AS [PlanetId],
    [BasicCulture.Country].[Active] AS [Active],
    [BasicCulture.Country].[UserCreationId] AS [UserCreationId],
    [BasicCulture.Country].[UserLastModificationId] AS [UserLastModificationId],
    [BasicCulture.Country].[DateTimeCreation] AS [DateTimeCreation],
    [BasicCulture.Country].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [BasicCulture.Country]
WHERE 
    1 = 1
    AND [BasicCulture.Country].[CountryId] = @CountryId
ORDER BY 
    [BasicCulture.Country].[CountryId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Country.SelectAll]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.Country.SelectAll]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[BasicCulture.Country.SelectAll]
 *
 */

--Last modification on: 09/12/2022 19:23:19

SET DATEFORMAT DMY

SELECT
    [BasicCulture.Country].[CountryId] AS [CountryId],
    [BasicCulture.Country].[Name] AS [Name],
    [BasicCulture.Country].[GeographicalCoordinates] AS [GeographicalCoordinates],
    [BasicCulture.Country].[Code] AS [Code],
    [BasicCulture.Country].[PlanetId] AS [PlanetId],
    [BasicCulture.Country].[Active] AS [Active],
    [BasicCulture.Country].[UserCreationId] AS [UserCreationId],
    [BasicCulture.Country].[UserLastModificationId] AS [UserLastModificationId],
    [BasicCulture.Country].[DateTimeCreation] AS [DateTimeCreation],
    [BasicCulture.Country].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [BasicCulture.Country]
ORDER BY 
    [BasicCulture.Country].[CountryId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Country.SelectAllPaged]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.Country.SelectAllPaged]
(
    @QueryString VARCHAR(100),
    @ActualPageNumber INT,
    @RowsPerPage INT,
    @SorterColumn VARCHAR(100),
    @SortToggler TINYINT,
    @TotalRows INT OUTPUT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*Execute this stored procedure with the next script as example

DECLARE	@TotalRows int
EXEC [dbo].[BasicCulture.Country.SelectAllPaged]
    
    @QueryString = N'',
    @ActualPageNumber = 1,
    @RowsPerPage = 10,
    @SorterColumn = N'CountryId',
    @SortToggler = 0,
    @TotalRows = @TotalRows OUTPUT

SELECT @TotalRows AS N'@TotalRows'
*/

--Last modification on: 09/12/2022 19:23:19

SET DATEFORMAT DMY
SET NOCOUNT ON

SELECT
    [BasicCulture.Country].[CountryId] AS [CountryId],
    [BasicCulture.Country].[Name] AS [Name],
    [BasicCulture.Country].[GeographicalCoordinates] AS [GeographicalCoordinates],
    [BasicCulture.Country].[Code] AS [Code],
    [BasicCulture.Country].[PlanetId] AS [PlanetId],
    [BasicCulture.Country].[Active] AS [Active],
    [BasicCulture.Country].[UserCreationId] AS [UserCreationId],
    [BasicCulture.Country].[UserLastModificationId] AS [UserLastModificationId],
    [BasicCulture.Country].[DateTimeCreation] AS [DateTimeCreation],
    [BasicCulture.Country].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [BasicCulture.Country]
WHERE
    1=1
    AND (@QueryString = '' 
        OR ([BasicCulture.Country].[CountryId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Country].[Name] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Country].[GeographicalCoordinates] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Country].[Code] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Country].[PlanetId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Country].[Active] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Country].[UserCreationId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Country].[UserLastModificationId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Country].[DateTimeCreation] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Country].[DateTimeLastModification] LIKE  '%' + @QueryString + '%')

    )
ORDER BY 
    CASE WHEN (@SorterColumn = 'CountryId' AND @SortToggler = 0) THEN [CountryId] END ASC,
    CASE WHEN (@SorterColumn = 'CountryId' AND @SortToggler = 1) THEN [CountryId] END DESC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 0) THEN [Name] END ASC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 1) THEN [Name] END DESC,
    CASE WHEN (@SorterColumn = 'GeographicalCoordinates' AND @SortToggler = 0) THEN [GeographicalCoordinates] END ASC,
    CASE WHEN (@SorterColumn = 'GeographicalCoordinates' AND @SortToggler = 1) THEN [GeographicalCoordinates] END DESC,
    CASE WHEN (@SorterColumn = 'Code' AND @SortToggler = 0) THEN [Code] END ASC,
    CASE WHEN (@SorterColumn = 'Code' AND @SortToggler = 1) THEN [Code] END DESC,
    CASE WHEN (@SorterColumn = 'PlanetId' AND @SortToggler = 0) THEN [PlanetId] END ASC,
    CASE WHEN (@SorterColumn = 'PlanetId' AND @SortToggler = 1) THEN [PlanetId] END DESC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 0) THEN [Active] END ASC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 1) THEN [Active] END DESC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 0) THEN [UserCreationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 1) THEN [UserCreationId] END DESC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 0) THEN [UserLastModificationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 1) THEN [UserLastModificationId] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 0) THEN [DateTimeCreation] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 1) THEN [DateTimeCreation] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 0) THEN [DateTimeLastModification] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 1) THEN [DateTimeLastModification] END DESC

OFFSET (@ActualPageNumber - 1) * @RowsPerPage ROWS
FETCH NEXT @RowsPerPage ROWS ONLY
SELECT @TotalRows = COUNT(*) FROM [BasicCulture.Country]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Country.UpdateByCountryId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

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
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
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

--Last modification on: 09/12/2022 19:23:19

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
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Planet.Count]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.Planet.Count]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@Counter int

EXEC	@Counter = [dbo].[BasicCulture.Planet.Count]

SELECT	'Counter' = @Counter
 *
 */

--Last modification on: 09/12/2022 19:23:24

SELECT 
	COUNT(*)
FROM 
	[BasicCulture.Planet]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Planet.DeleteAll]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.Planet.DeleteAll]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[BasicCulture.Planet.DeleteAll]
 *
 */

--Last modification on: 09/12/2022 19:23:24

DELETE FROM [BasicCulture.Planet]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Planet.DeleteByPlanetId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.Planet.DeleteByPlanetId]
(
    @PlanetId INT,
    @RowsAffected INT OUTPUT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@RowsAffected INT
EXEC [dbo].[BasicCulture.Planet.DeleteByPlanetId]
    @PlanetId = 1,
    @RowsAffected = @RowsAffected OUTPUT
SELECT @RowsAffected AS N'@RowsAffected'
 *
 */

--Last modification on: 09/12/2022 19:23:24

DELETE FROM 
    [BasicCulture.Planet]
WHERE 
    1 = 1
    AND [BasicCulture.Planet].[PlanetId] = @PlanetId

SELECT @RowsAffected = @@ROWCOUNT
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Planet.Insert]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.Planet.Insert] 
(
    @Name VARCHAR(500),
    @Code VARCHAR(100),
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
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@NewEnteredId INT
EXEC [dbo].[BasicCulture.Planet.Insert]

    @Name = N'PutName',
    @Code = N'PutCode',
    @Active = 1,
    @UserCreationId = 1,
    @UserLastModificationId = 1,
    @DateTimeCreation = N'01/01/1753 0:00:00.001',
    @DateTimeLastModification = N'01/01/1753 0:00:00.001',

@NewEnteredId = @NewEnteredId OUTPUT

SELECT @NewEnteredId AS N'@NewEnteredId'
 *
 */

--Last modification on: 09/12/2022 19:23:24

INSERT INTO [BasicCulture.Planet]
(
    [Name],
    [Code],
    [Active],
    [UserCreationId],
    [UserLastModificationId],
    [DateTimeCreation],
    [DateTimeLastModification]
)
VALUES
(
    @Name,
    @Code,
    @Active,
    @UserCreationId,
    @UserLastModificationId,
    @DateTimeCreation,
    @DateTimeLastModification
)

SELECT @NewEnteredId = @@IDENTITY
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Planet.Select1ByPlanetId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.Planet.Select1ByPlanetId]
(
    @PlanetId INT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[Planet.Select1ByPlanetId]
    @PlanetId = 1
 *
 */

--Last modification on: 09/12/2022 19:23:24

SET DATEFORMAT DMY

SELECT
    [BasicCulture.Planet].[PlanetId] AS [PlanetId],
    [BasicCulture.Planet].[Name] AS [Name],
    [BasicCulture.Planet].[Code] AS [Code],
    [BasicCulture.Planet].[Active] AS [Active],
    [BasicCulture.Planet].[UserCreationId] AS [UserCreationId],
    [BasicCulture.Planet].[UserLastModificationId] AS [UserLastModificationId],
    [BasicCulture.Planet].[DateTimeCreation] AS [DateTimeCreation],
    [BasicCulture.Planet].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [BasicCulture.Planet]
WHERE 
    1 = 1
    AND [BasicCulture.Planet].[PlanetId] = @PlanetId
ORDER BY 
    [BasicCulture.Planet].[PlanetId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Planet.SelectAll]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.Planet.SelectAll]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[BasicCulture.Planet.SelectAll]
 *
 */

--Last modification on: 09/12/2022 19:23:24

SET DATEFORMAT DMY

SELECT
    [BasicCulture.Planet].[PlanetId] AS [PlanetId],
    [BasicCulture.Planet].[Name] AS [Name],
    [BasicCulture.Planet].[Code] AS [Code],
    [BasicCulture.Planet].[Active] AS [Active],
    [BasicCulture.Planet].[UserCreationId] AS [UserCreationId],
    [BasicCulture.Planet].[UserLastModificationId] AS [UserLastModificationId],
    [BasicCulture.Planet].[DateTimeCreation] AS [DateTimeCreation],
    [BasicCulture.Planet].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [BasicCulture.Planet]
ORDER BY 
    [BasicCulture.Planet].[PlanetId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Planet.SelectAllPaged]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.Planet.SelectAllPaged]
(
    @QueryString VARCHAR(100),
    @ActualPageNumber INT,
    @RowsPerPage INT,
    @SorterColumn VARCHAR(100),
    @SortToggler TINYINT,
    @TotalRows INT OUTPUT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*Execute this stored procedure with the next script as example

DECLARE	@TotalRows int
EXEC [dbo].[BasicCulture.Planet.SelectAllPaged]
    
    @QueryString = N'',
    @ActualPageNumber = 1,
    @RowsPerPage = 10,
    @SorterColumn = N'PlanetId',
    @SortToggler = 0,
    @TotalRows = @TotalRows OUTPUT

SELECT @TotalRows AS N'@TotalRows'
*/

--Last modification on: 09/12/2022 19:23:24

SET DATEFORMAT DMY
SET NOCOUNT ON

SELECT
    [BasicCulture.Planet].[PlanetId] AS [PlanetId],
    [BasicCulture.Planet].[Name] AS [Name],
    [BasicCulture.Planet].[Code] AS [Code],
    [BasicCulture.Planet].[Active] AS [Active],
    [BasicCulture.Planet].[UserCreationId] AS [UserCreationId],
    [BasicCulture.Planet].[UserLastModificationId] AS [UserLastModificationId],
    [BasicCulture.Planet].[DateTimeCreation] AS [DateTimeCreation],
    [BasicCulture.Planet].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [BasicCulture.Planet]
WHERE
    1=1
    AND (@QueryString = '' 
        OR ([BasicCulture.Planet].[PlanetId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Planet].[Name] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Planet].[Code] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Planet].[Active] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Planet].[UserCreationId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Planet].[UserLastModificationId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Planet].[DateTimeCreation] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Planet].[DateTimeLastModification] LIKE  '%' + @QueryString + '%')

    )
ORDER BY 
    CASE WHEN (@SorterColumn = 'PlanetId' AND @SortToggler = 0) THEN [PlanetId] END ASC,
    CASE WHEN (@SorterColumn = 'PlanetId' AND @SortToggler = 1) THEN [PlanetId] END DESC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 0) THEN [Name] END ASC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 1) THEN [Name] END DESC,
    CASE WHEN (@SorterColumn = 'Code' AND @SortToggler = 0) THEN [Code] END ASC,
    CASE WHEN (@SorterColumn = 'Code' AND @SortToggler = 1) THEN [Code] END DESC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 0) THEN [Active] END ASC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 1) THEN [Active] END DESC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 0) THEN [UserCreationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 1) THEN [UserCreationId] END DESC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 0) THEN [UserLastModificationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 1) THEN [UserLastModificationId] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 0) THEN [DateTimeCreation] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 1) THEN [DateTimeCreation] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 0) THEN [DateTimeLastModification] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 1) THEN [DateTimeLastModification] END DESC

OFFSET (@ActualPageNumber - 1) * @RowsPerPage ROWS
FETCH NEXT @RowsPerPage ROWS ONLY
SELECT @TotalRows = COUNT(*) FROM [BasicCulture.Planet]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Planet.UpdateByPlanetId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.Planet.UpdateByPlanetId]
(
    @PlanetId INT,
    @Name VARCHAR(500),
    @Code VARCHAR(100),
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
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@RowsAffected int
EXEC [dbo].[BasicCulture.Planet.UpdateByPlanetId]
    @PlanetId = 1,
    @RowsAffected = @RowsAffected OUTPUT
SELECT @RowsAffected AS N'@RowsAffected'
 *
 */

--Last modification on: 09/12/2022 19:23:24

UPDATE [BasicCulture.Planet] SET
    [Name] = @Name,
    [Code] = @Code,
    [Active] = @Active,
    [UserCreationId] = @UserCreationId,
    [UserLastModificationId] = @UserLastModificationId,
    [DateTimeCreation] = @DateTimeCreation,
    [DateTimeLastModification] = @DateTimeLastModification
WHERE 
    1 = 1 
    AND [BasicCulture.Planet].[PlanetId] = @PlanetId 

SELECT @RowsAffected = @@ROWCOUNT
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Province.Count]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.Province.Count]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@Counter int

EXEC	@Counter = [dbo].[BasicCulture.Province.Count]

SELECT	'Counter' = @Counter
 *
 */

--Last modification on: 09/12/2022 19:23:16

SELECT 
	COUNT(*)
FROM 
	[BasicCulture.Province]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Province.DeleteAll]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.Province.DeleteAll]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[BasicCulture.Province.DeleteAll]
 *
 */

--Last modification on: 09/12/2022 19:23:16

DELETE FROM [BasicCulture.Province]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Province.DeleteByProvinceId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.Province.DeleteByProvinceId]
(
    @ProvinceId INT,
    @RowsAffected INT OUTPUT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@RowsAffected INT
EXEC [dbo].[BasicCulture.Province.DeleteByProvinceId]
    @ProvinceId = 1,
    @RowsAffected = @RowsAffected OUTPUT
SELECT @RowsAffected AS N'@RowsAffected'
 *
 */

--Last modification on: 09/12/2022 19:23:15

DELETE FROM 
    [BasicCulture.Province]
WHERE 
    1 = 1
    AND [BasicCulture.Province].[ProvinceId] = @ProvinceId

SELECT @RowsAffected = @@ROWCOUNT
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Province.Insert]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

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
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
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

--Last modification on: 09/12/2022 19:23:15

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

SELECT @NewEnteredId = @@IDENTITY
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Province.Select1ByProvinceId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.Province.Select1ByProvinceId]
(
    @ProvinceId INT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[Province.Select1ByProvinceId]
    @ProvinceId = 1
 *
 */

--Last modification on: 09/12/2022 19:23:15

SET DATEFORMAT DMY

SELECT
    [BasicCulture.Province].[ProvinceId] AS [ProvinceId],
    [BasicCulture.Province].[Name] AS [Name],
    [BasicCulture.Province].[GeographicalCoordinates] AS [GeographicalCoordinates],
    [BasicCulture.Province].[Code] AS [Code],
    [BasicCulture.Province].[CountryId] AS [CountryId],
    [BasicCulture.Province].[Active] AS [Active],
    [BasicCulture.Province].[UserCreationId] AS [UserCreationId],
    [BasicCulture.Province].[UserLastModificationId] AS [UserLastModificationId],
    [BasicCulture.Province].[DateTimeCreation] AS [DateTimeCreation],
    [BasicCulture.Province].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [BasicCulture.Province]
WHERE 
    1 = 1
    AND [BasicCulture.Province].[ProvinceId] = @ProvinceId
ORDER BY 
    [BasicCulture.Province].[ProvinceId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Province.SelectAll]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.Province.SelectAll]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[BasicCulture.Province.SelectAll]
 *
 */

--Last modification on: 09/12/2022 19:23:15

SET DATEFORMAT DMY

SELECT
    [BasicCulture.Province].[ProvinceId] AS [ProvinceId],
    [BasicCulture.Province].[Name] AS [Name],
    [BasicCulture.Province].[GeographicalCoordinates] AS [GeographicalCoordinates],
    [BasicCulture.Province].[Code] AS [Code],
    [BasicCulture.Province].[CountryId] AS [CountryId],
    [BasicCulture.Province].[Active] AS [Active],
    [BasicCulture.Province].[UserCreationId] AS [UserCreationId],
    [BasicCulture.Province].[UserLastModificationId] AS [UserLastModificationId],
    [BasicCulture.Province].[DateTimeCreation] AS [DateTimeCreation],
    [BasicCulture.Province].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [BasicCulture.Province]
ORDER BY 
    [BasicCulture.Province].[ProvinceId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Province.SelectAllPaged]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.Province.SelectAllPaged]
(
    @QueryString VARCHAR(100),
    @ActualPageNumber INT,
    @RowsPerPage INT,
    @SorterColumn VARCHAR(100),
    @SortToggler TINYINT,
    @TotalRows INT OUTPUT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*Execute this stored procedure with the next script as example

DECLARE	@TotalRows int
EXEC [dbo].[BasicCulture.Province.SelectAllPaged]
    
    @QueryString = N'',
    @ActualPageNumber = 1,
    @RowsPerPage = 10,
    @SorterColumn = N'ProvinceId',
    @SortToggler = 0,
    @TotalRows = @TotalRows OUTPUT

SELECT @TotalRows AS N'@TotalRows'
*/

--Last modification on: 09/12/2022 19:23:16

SET DATEFORMAT DMY
SET NOCOUNT ON

SELECT
    [BasicCulture.Province].[ProvinceId] AS [ProvinceId],
    [BasicCulture.Province].[Name] AS [Name],
    [BasicCulture.Province].[GeographicalCoordinates] AS [GeographicalCoordinates],
    [BasicCulture.Province].[Code] AS [Code],
    [BasicCulture.Province].[CountryId] AS [CountryId],
    [BasicCulture.Province].[Active] AS [Active],
    [BasicCulture.Province].[UserCreationId] AS [UserCreationId],
    [BasicCulture.Province].[UserLastModificationId] AS [UserLastModificationId],
    [BasicCulture.Province].[DateTimeCreation] AS [DateTimeCreation],
    [BasicCulture.Province].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [BasicCulture.Province]
WHERE
    1=1
    AND (@QueryString = '' 
        OR ([BasicCulture.Province].[ProvinceId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Province].[Name] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Province].[GeographicalCoordinates] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Province].[Code] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Province].[CountryId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Province].[Active] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Province].[UserCreationId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Province].[UserLastModificationId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Province].[DateTimeCreation] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Province].[DateTimeLastModification] LIKE  '%' + @QueryString + '%')

    )
ORDER BY 
    CASE WHEN (@SorterColumn = 'ProvinceId' AND @SortToggler = 0) THEN [ProvinceId] END ASC,
    CASE WHEN (@SorterColumn = 'ProvinceId' AND @SortToggler = 1) THEN [ProvinceId] END DESC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 0) THEN [Name] END ASC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 1) THEN [Name] END DESC,
    CASE WHEN (@SorterColumn = 'GeographicalCoordinates' AND @SortToggler = 0) THEN [GeographicalCoordinates] END ASC,
    CASE WHEN (@SorterColumn = 'GeographicalCoordinates' AND @SortToggler = 1) THEN [GeographicalCoordinates] END DESC,
    CASE WHEN (@SorterColumn = 'Code' AND @SortToggler = 0) THEN [Code] END ASC,
    CASE WHEN (@SorterColumn = 'Code' AND @SortToggler = 1) THEN [Code] END DESC,
    CASE WHEN (@SorterColumn = 'CountryId' AND @SortToggler = 0) THEN [CountryId] END ASC,
    CASE WHEN (@SorterColumn = 'CountryId' AND @SortToggler = 1) THEN [CountryId] END DESC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 0) THEN [Active] END ASC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 1) THEN [Active] END DESC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 0) THEN [UserCreationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 1) THEN [UserCreationId] END DESC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 0) THEN [UserLastModificationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 1) THEN [UserLastModificationId] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 0) THEN [DateTimeCreation] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 1) THEN [DateTimeCreation] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 0) THEN [DateTimeLastModification] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 1) THEN [DateTimeLastModification] END DESC

OFFSET (@ActualPageNumber - 1) * @RowsPerPage ROWS
FETCH NEXT @RowsPerPage ROWS ONLY
SELECT @TotalRows = COUNT(*) FROM [BasicCulture.Province]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Province.UpdateByProvinceId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.Province.UpdateByProvinceId]
(
    @ProvinceId INT,
    @Name VARCHAR(500),
    @GeographicalCoordinates VARCHAR(200),
    @Code VARCHAR(100),
    @CountryId INT,
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
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@RowsAffected int
EXEC [dbo].[BasicCulture.Province.UpdateByProvinceId]
    @ProvinceId = 1,
    @RowsAffected = @RowsAffected OUTPUT
SELECT @RowsAffected AS N'@RowsAffected'
 *
 */

--Last modification on: 09/12/2022 19:23:15

UPDATE [BasicCulture.Province] SET
    [Name] = @Name,
    [GeographicalCoordinates] = @GeographicalCoordinates,
    [Code] = @Code,
    [CountryId] = @CountryId,
    [Active] = @Active,
    [UserCreationId] = @UserCreationId,
    [UserLastModificationId] = @UserLastModificationId,
    [DateTimeCreation] = @DateTimeCreation,
    [DateTimeLastModification] = @DateTimeLastModification
WHERE 
    1 = 1 
    AND [BasicCulture.Province].[ProvinceId] = @ProvinceId 

SELECT @RowsAffected = @@ROWCOUNT
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Sex.Count]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.Sex.Count]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@Counter int

EXEC	@Counter = [dbo].[BasicCulture.Sex.Count]

SELECT	'Counter' = @Counter
 *
 */

--Last modification on: 09/12/2022 19:23:30

SELECT 
	COUNT(*)
FROM 
	[BasicCulture.Sex]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Sex.DeleteAll]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.Sex.DeleteAll]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[BasicCulture.Sex.DeleteAll]
 *
 */

--Last modification on: 09/12/2022 19:23:30

DELETE FROM [BasicCulture.Sex]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Sex.DeleteBySexId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.Sex.DeleteBySexId]
(
    @SexId INT,
    @RowsAffected INT OUTPUT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
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

--Last modification on: 09/12/2022 19:23:30

DELETE FROM 
    [BasicCulture.Sex]
WHERE 
    1 = 1
    AND [BasicCulture.Sex].[SexId] = @SexId

SELECT @RowsAffected = @@ROWCOUNT
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Sex.Insert]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.Sex.Insert] 
(
    @Name VARCHAR(500),
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
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@NewEnteredId INT
EXEC [dbo].[BasicCulture.Sex.Insert]

    @Name = N'PutName',
    @Active = 1,
    @UserCreationId = 1,
    @UserLastModificationId = 1,
    @DateTimeCreation = N'01/01/1753 0:00:00.001',
    @DateTimeLastModification = N'01/01/1753 0:00:00.001',

@NewEnteredId = @NewEnteredId OUTPUT

SELECT @NewEnteredId AS N'@NewEnteredId'
 *
 */

--Last modification on: 09/12/2022 19:23:30

INSERT INTO [BasicCulture.Sex]
(
    [Name],
    [Active],
    [UserCreationId],
    [UserLastModificationId],
    [DateTimeCreation],
    [DateTimeLastModification]
)
VALUES
(
    @Name,
    @Active,
    @UserCreationId,
    @UserLastModificationId,
    @DateTimeCreation,
    @DateTimeLastModification
)

SELECT @NewEnteredId = @@IDENTITY
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Sex.Select1BySexId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.Sex.Select1BySexId]
(
    @SexId INT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[Sex.Select1BySexId]
    @SexId = 1
 *
 */

--Last modification on: 09/12/2022 19:23:30

SET DATEFORMAT DMY

SELECT
    [BasicCulture.Sex].[SexId] AS [SexId],
    [BasicCulture.Sex].[Name] AS [Name],
    [BasicCulture.Sex].[Active] AS [Active],
    [BasicCulture.Sex].[UserCreationId] AS [UserCreationId],
    [BasicCulture.Sex].[UserLastModificationId] AS [UserLastModificationId],
    [BasicCulture.Sex].[DateTimeCreation] AS [DateTimeCreation],
    [BasicCulture.Sex].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [BasicCulture.Sex]
WHERE 
    1 = 1
    AND [BasicCulture.Sex].[SexId] = @SexId
ORDER BY 
    [BasicCulture.Sex].[SexId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Sex.SelectAll]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.Sex.SelectAll]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[BasicCulture.Sex.SelectAll]
 *
 */

--Last modification on: 09/12/2022 19:23:30

SET DATEFORMAT DMY

SELECT
    [BasicCulture.Sex].[SexId] AS [SexId],
    [BasicCulture.Sex].[Name] AS [Name],
    [BasicCulture.Sex].[Active] AS [Active],
    [BasicCulture.Sex].[UserCreationId] AS [UserCreationId],
    [BasicCulture.Sex].[UserLastModificationId] AS [UserLastModificationId],
    [BasicCulture.Sex].[DateTimeCreation] AS [DateTimeCreation],
    [BasicCulture.Sex].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [BasicCulture.Sex]
ORDER BY 
    [BasicCulture.Sex].[SexId]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Sex.SelectAllPaged]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.Sex.SelectAllPaged]
(
    @QueryString VARCHAR(100),
    @ActualPageNumber INT,
    @RowsPerPage INT,
    @SorterColumn VARCHAR(100),
    @SortToggler TINYINT,
    @TotalRows INT OUTPUT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*Execute this stored procedure with the next script as example

DECLARE	@TotalRows int
EXEC [dbo].[BasicCulture.Sex.SelectAllPaged]
    
    @QueryString = N'',
    @ActualPageNumber = 1,
    @RowsPerPage = 10,
    @SorterColumn = N'SexId',
    @SortToggler = 0,
    @TotalRows = @TotalRows OUTPUT

SELECT @TotalRows AS N'@TotalRows'
*/

--Last modification on: 09/12/2022 19:23:30

SET DATEFORMAT DMY
SET NOCOUNT ON

SELECT
    [BasicCulture.Sex].[SexId] AS [SexId],
    [BasicCulture.Sex].[Name] AS [Name],
    [BasicCulture.Sex].[Active] AS [Active],
    [BasicCulture.Sex].[UserCreationId] AS [UserCreationId],
    [BasicCulture.Sex].[UserLastModificationId] AS [UserLastModificationId],
    [BasicCulture.Sex].[DateTimeCreation] AS [DateTimeCreation],
    [BasicCulture.Sex].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [BasicCulture.Sex]
WHERE
    1=1
    AND (@QueryString = '' 
        OR ([BasicCulture.Sex].[SexId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Sex].[Name] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Sex].[Active] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Sex].[UserCreationId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Sex].[UserLastModificationId] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Sex].[DateTimeCreation] LIKE  '%' + @QueryString + '%')
        OR ([BasicCulture.Sex].[DateTimeLastModification] LIKE  '%' + @QueryString + '%')

    )
ORDER BY 
    CASE WHEN (@SorterColumn = 'SexId' AND @SortToggler = 0) THEN [SexId] END ASC,
    CASE WHEN (@SorterColumn = 'SexId' AND @SortToggler = 1) THEN [SexId] END DESC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 0) THEN [Name] END ASC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 1) THEN [Name] END DESC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 0) THEN [Active] END ASC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 1) THEN [Active] END DESC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 0) THEN [UserCreationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 1) THEN [UserCreationId] END DESC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 0) THEN [UserLastModificationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 1) THEN [UserLastModificationId] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 0) THEN [DateTimeCreation] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 1) THEN [DateTimeCreation] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 0) THEN [DateTimeLastModification] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 1) THEN [DateTimeLastModification] END DESC

OFFSET (@ActualPageNumber - 1) * @RowsPerPage ROWS
FETCH NEXT @RowsPerPage ROWS ONLY
SELECT @TotalRows = COUNT(*) FROM [BasicCulture.Sex]
GO

/****** Object:  StoredProcedure [dbo].[BasicCulture.Sex.UpdateBySexId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BasicCulture.Sex.UpdateBySexId]
(
    @SexId INT,
    @Name VARCHAR(500),
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
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@RowsAffected int
EXEC [dbo].[BasicCulture.Sex.UpdateBySexId]
    @SexId = 1,
    @RowsAffected = @RowsAffected OUTPUT
SELECT @RowsAffected AS N'@RowsAffected'
 *
 */

--Last modification on: 09/12/2022 19:23:30

UPDATE [BasicCulture.Sex] SET
    [Name] = @Name,
    [Active] = @Active,
    [UserCreationId] = @UserCreationId,
    [UserLastModificationId] = @UserLastModificationId,
    [DateTimeCreation] = @DateTimeCreation,
    [DateTimeLastModification] = @DateTimeLastModification
WHERE 
    1 = 1 
    AND [BasicCulture.Sex].[SexId] = @SexId 

SELECT @RowsAffected = @@ROWCOUNT
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Menu.Count]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.Menu.Count]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@Counter int

EXEC	@Counter = [dbo].[CMSCore.Menu.Count]

SELECT	'Counter' = @Counter
 *
 */

--Last modification on: 09/12/2022 19:23:03

SELECT 
	COUNT(*)
FROM 
	[CMSCore.Menu]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Menu.DeleteAll]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.Menu.DeleteAll]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[CMSCore.Menu.DeleteAll]
 *
 */

--Last modification on: 09/12/2022 19:23:03

DELETE FROM [CMSCore.Menu]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Menu.DeleteByMenuId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.Menu.DeleteByMenuId]
(
    @MenuId INT,
    @RowsAffected INT OUTPUT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@RowsAffected INT
EXEC [dbo].[CMSCore.Menu.DeleteByMenuId]
    @MenuId = 1,
    @RowsAffected = @RowsAffected OUTPUT
SELECT @RowsAffected AS N'@RowsAffected'
 *
 */

--Last modification on: 09/12/2022 19:23:03

DELETE FROM 
    [CMSCore.Menu]
WHERE 
    1 = 1
    AND [CMSCore.Menu].[MenuId] = @MenuId

SELECT @RowsAffected = @@ROWCOUNT
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Menu.Insert]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.Menu.Insert] 
(
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

    @NewEnteredId INT OUTPUT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@NewEnteredId INT
EXEC [dbo].[CMSCore.Menu.Insert]

    @Name = N'PutName',
    @MenuFatherId = 1,
    @Order = 1,
    @URLPath = N'PutURLPath',
    @IconURLPath = N'PutIconURLPath',
    @Active = 1,
    @UserCreationId = 1,
    @UserLastModificationId = 1,
    @DateTimeCreation = N'01/01/1753 0:00:00.001',
    @DateTimeLastModification = N'01/01/1753 0:00:00.001',

@NewEnteredId = @NewEnteredId OUTPUT

SELECT @NewEnteredId AS N'@NewEnteredId'
 *
 */

--Last modification on: 09/12/2022 19:23:03

INSERT INTO [CMSCore.Menu]
(
    [Name],
    [MenuFatherId],
    [Order],
    [URLPath],
    [IconURLPath],
    [Active],
    [UserCreationId],
    [UserLastModificationId],
    [DateTimeCreation],
    [DateTimeLastModification]
)
VALUES
(
    @Name,
    @MenuFatherId,
    @Order,
    @URLPath,
    @IconURLPath,
    @Active,
    @UserCreationId,
    @UserLastModificationId,
    @DateTimeCreation,
    @DateTimeLastModification
)

SELECT @NewEnteredId = @@IDENTITY
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Menu.Select1ByMenuId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.Menu.Select1ByMenuId]
(
    @MenuId INT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[Menu.Select1ByMenuId]
    @MenuId = 1
 *
 */

--Last modification on: 09/12/2022 19:23:03

SET DATEFORMAT DMY

SELECT
    [CMSCore.Menu].[MenuId] AS [MenuId],
    [CMSCore.Menu].[Name] AS [Name],
    [CMSCore.Menu].[MenuFatherId] AS [MenuFatherId],
    [CMSCore.Menu].[Order] AS [Order],
    [CMSCore.Menu].[URLPath] AS [URLPath],
    [CMSCore.Menu].[IconURLPath] AS [IconURLPath],
    [CMSCore.Menu].[Active] AS [Active],
    [CMSCore.Menu].[UserCreationId] AS [UserCreationId],
    [CMSCore.Menu].[UserLastModificationId] AS [UserLastModificationId],
    [CMSCore.Menu].[DateTimeCreation] AS [DateTimeCreation],
    [CMSCore.Menu].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [CMSCore.Menu]
WHERE 
    1 = 1
    AND [CMSCore.Menu].[MenuId] = @MenuId
ORDER BY 
    [CMSCore.Menu].[MenuId]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Menu.SelectAll]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.Menu.SelectAll]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[CMSCore.Menu.SelectAll]
 *
 */

--Last modification on: 09/12/2022 19:23:03

SET DATEFORMAT DMY

SELECT
    [CMSCore.Menu].[MenuId] AS [MenuId],
    [CMSCore.Menu].[Name] AS [Name],
    [CMSCore.Menu].[MenuFatherId] AS [MenuFatherId],
    [CMSCore.Menu].[Order] AS [Order],
    [CMSCore.Menu].[URLPath] AS [URLPath],
    [CMSCore.Menu].[IconURLPath] AS [IconURLPath],
    [CMSCore.Menu].[Active] AS [Active],
    [CMSCore.Menu].[UserCreationId] AS [UserCreationId],
    [CMSCore.Menu].[UserLastModificationId] AS [UserLastModificationId],
    [CMSCore.Menu].[DateTimeCreation] AS [DateTimeCreation],
    [CMSCore.Menu].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [CMSCore.Menu]
ORDER BY 
    [CMSCore.Menu].[MenuId]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Menu.SelectAllPaged]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.Menu.SelectAllPaged]
(
    @QueryString VARCHAR(100),
    @ActualPageNumber INT,
    @RowsPerPage INT,
    @SorterColumn VARCHAR(100),
    @SortToggler TINYINT,
    @TotalRows INT OUTPUT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*Execute this stored procedure with the next script as example

DECLARE	@TotalRows int
EXEC [dbo].[CMSCore.Menu.SelectAllPaged]
    
    @QueryString = N'',
    @ActualPageNumber = 1,
    @RowsPerPage = 10,
    @SorterColumn = N'MenuId',
    @SortToggler = 0,
    @TotalRows = @TotalRows OUTPUT

SELECT @TotalRows AS N'@TotalRows'
*/

--Last modification on: 09/12/2022 19:23:03

SET DATEFORMAT DMY
SET NOCOUNT ON

SELECT
    [CMSCore.Menu].[MenuId] AS [MenuId],
    [CMSCore.Menu].[Name] AS [Name],
    [CMSCore.Menu].[MenuFatherId] AS [MenuFatherId],
    [CMSCore.Menu].[Order] AS [Order],
    [CMSCore.Menu].[URLPath] AS [URLPath],
    [CMSCore.Menu].[IconURLPath] AS [IconURLPath],
    [CMSCore.Menu].[Active] AS [Active],
    [CMSCore.Menu].[UserCreationId] AS [UserCreationId],
    [CMSCore.Menu].[UserLastModificationId] AS [UserLastModificationId],
    [CMSCore.Menu].[DateTimeCreation] AS [DateTimeCreation],
    [CMSCore.Menu].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [CMSCore.Menu]
WHERE
    1=1
    AND (@QueryString = '' 
        OR ([CMSCore.Menu].[MenuId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Menu].[Name] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Menu].[MenuFatherId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Menu].[Order] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Menu].[URLPath] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Menu].[IconURLPath] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Menu].[Active] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Menu].[UserCreationId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Menu].[UserLastModificationId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Menu].[DateTimeCreation] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Menu].[DateTimeLastModification] LIKE  '%' + @QueryString + '%')

    )
ORDER BY 
    CASE WHEN (@SorterColumn = 'MenuId' AND @SortToggler = 0) THEN [MenuId] END ASC,
    CASE WHEN (@SorterColumn = 'MenuId' AND @SortToggler = 1) THEN [MenuId] END DESC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 0) THEN [Name] END ASC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 1) THEN [Name] END DESC,
    CASE WHEN (@SorterColumn = 'MenuFatherId' AND @SortToggler = 0) THEN [MenuFatherId] END ASC,
    CASE WHEN (@SorterColumn = 'MenuFatherId' AND @SortToggler = 1) THEN [MenuFatherId] END DESC,
    CASE WHEN (@SorterColumn = 'Order' AND @SortToggler = 0) THEN [Order] END ASC,
    CASE WHEN (@SorterColumn = 'Order' AND @SortToggler = 1) THEN [Order] END DESC,
    CASE WHEN (@SorterColumn = 'URLPath' AND @SortToggler = 0) THEN [URLPath] END ASC,
    CASE WHEN (@SorterColumn = 'URLPath' AND @SortToggler = 1) THEN [URLPath] END DESC,
    CASE WHEN (@SorterColumn = 'IconURLPath' AND @SortToggler = 0) THEN [IconURLPath] END ASC,
    CASE WHEN (@SorterColumn = 'IconURLPath' AND @SortToggler = 1) THEN [IconURLPath] END DESC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 0) THEN [Active] END ASC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 1) THEN [Active] END DESC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 0) THEN [UserCreationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 1) THEN [UserCreationId] END DESC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 0) THEN [UserLastModificationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 1) THEN [UserLastModificationId] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 0) THEN [DateTimeCreation] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 1) THEN [DateTimeCreation] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 0) THEN [DateTimeLastModification] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 1) THEN [DateTimeLastModification] END DESC

OFFSET (@ActualPageNumber - 1) * @RowsPerPage ROWS
FETCH NEXT @RowsPerPage ROWS ONLY
SELECT @TotalRows = COUNT(*) FROM [CMSCore.Menu]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Menu.UpdateByMenuId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

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
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
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

--Last modification on: 09/12/2022 19:23:03

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

SELECT @RowsAffected = @@ROWCOUNT
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Role.Count]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.Role.Count]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@Counter int

EXEC	@Counter = [dbo].[CMSCore.Role.Count]

SELECT	'Counter' = @Counter
 *
 */

--Last modification on: 09/12/2022 19:22:49

SELECT 
	COUNT(*)
FROM 
	[CMSCore.Role]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Role.DeleteAll]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.Role.DeleteAll]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[CMSCore.Role.DeleteAll]
 *
 */

--Last modification on: 09/12/2022 19:22:49

DELETE FROM [CMSCore.Role]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Role.DeleteByRoleId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.Role.DeleteByRoleId]
(
    @RoleId INT,
    @RowsAffected INT OUTPUT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@RowsAffected INT
EXEC [dbo].[CMSCore.Role.DeleteByRoleId]
    @RoleId = 1,
    @RowsAffected = @RowsAffected OUTPUT
SELECT @RowsAffected AS N'@RowsAffected'
 *
 */

--Last modification on: 09/12/2022 19:22:49

DELETE FROM 
    [CMSCore.Role]
WHERE 
    1 = 1
    AND [CMSCore.Role].[RoleId] = @RoleId

SELECT @RowsAffected = @@ROWCOUNT
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Role.Insert]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.Role.Insert] 
(
    @Name VARCHAR(200),
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
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@NewEnteredId INT
EXEC [dbo].[CMSCore.Role.Insert]

    @Name = N'PutName',
    @Active = 1,
    @UserCreationId = 1,
    @UserLastModificationId = 1,
    @DateTimeCreation = N'01/01/1753 0:00:00.001',
    @DateTimeLastModification = N'01/01/1753 0:00:00.001',

@NewEnteredId = @NewEnteredId OUTPUT

SELECT @NewEnteredId AS N'@NewEnteredId'
 *
 */

--Last modification on: 09/12/2022 19:22:49

INSERT INTO [CMSCore.Role]
(
    [Name],
    [Active],
    [UserCreationId],
    [UserLastModificationId],
    [DateTimeCreation],
    [DateTimeLastModification]
)
VALUES
(
    @Name,
    @Active,
    @UserCreationId,
    @UserLastModificationId,
    @DateTimeCreation,
    @DateTimeLastModification
)

SELECT @NewEnteredId = @@IDENTITY
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Role.Select1ByRoleId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.Role.Select1ByRoleId]
(
    @RoleId INT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[Role.Select1ByRoleId]
    @RoleId = 1
 *
 */

--Last modification on: 09/12/2022 19:22:49

SET DATEFORMAT DMY

SELECT
    [CMSCore.Role].[RoleId] AS [RoleId],
    [CMSCore.Role].[Name] AS [Name],
    [CMSCore.Role].[Active] AS [Active],
    [CMSCore.Role].[UserCreationId] AS [UserCreationId],
    [CMSCore.Role].[UserLastModificationId] AS [UserLastModificationId],
    [CMSCore.Role].[DateTimeCreation] AS [DateTimeCreation],
    [CMSCore.Role].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [CMSCore.Role]
WHERE 
    1 = 1
    AND [CMSCore.Role].[RoleId] = @RoleId
ORDER BY 
    [CMSCore.Role].[RoleId]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Role.SelectAll]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.Role.SelectAll]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[CMSCore.Role.SelectAll]
 *
 */

--Last modification on: 09/12/2022 19:22:49

SET DATEFORMAT DMY

SELECT
    [CMSCore.Role].[RoleId] AS [RoleId],
    [CMSCore.Role].[Name] AS [Name],
    [CMSCore.Role].[Active] AS [Active],
    [CMSCore.Role].[UserCreationId] AS [UserCreationId],
    [CMSCore.Role].[UserLastModificationId] AS [UserLastModificationId],
    [CMSCore.Role].[DateTimeCreation] AS [DateTimeCreation],
    [CMSCore.Role].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [CMSCore.Role]
ORDER BY 
    [CMSCore.Role].[RoleId]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Role.SelectAllPaged]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.Role.SelectAllPaged]
(
    @QueryString VARCHAR(100),
    @ActualPageNumber INT,
    @RowsPerPage INT,
    @SorterColumn VARCHAR(100),
    @SortToggler TINYINT,
    @TotalRows INT OUTPUT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*Execute this stored procedure with the next script as example

DECLARE	@TotalRows int
EXEC [dbo].[CMSCore.Role.SelectAllPaged]
    
    @QueryString = N'',
    @ActualPageNumber = 1,
    @RowsPerPage = 10,
    @SorterColumn = N'RoleId',
    @SortToggler = 0,
    @TotalRows = @TotalRows OUTPUT

SELECT @TotalRows AS N'@TotalRows'
*/

--Last modification on: 09/12/2022 19:22:49

SET DATEFORMAT DMY
SET NOCOUNT ON

SELECT
    [CMSCore.Role].[RoleId] AS [RoleId],
    [CMSCore.Role].[Name] AS [Name],
    [CMSCore.Role].[Active] AS [Active],
    [CMSCore.Role].[UserCreationId] AS [UserCreationId],
    [CMSCore.Role].[UserLastModificationId] AS [UserLastModificationId],
    [CMSCore.Role].[DateTimeCreation] AS [DateTimeCreation],
    [CMSCore.Role].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [CMSCore.Role]
WHERE
    1=1
    AND (@QueryString = '' 
        OR ([CMSCore.Role].[RoleId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Role].[Name] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Role].[Active] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Role].[UserCreationId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Role].[UserLastModificationId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Role].[DateTimeCreation] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.Role].[DateTimeLastModification] LIKE  '%' + @QueryString + '%')

    )
ORDER BY 
    CASE WHEN (@SorterColumn = 'RoleId' AND @SortToggler = 0) THEN [RoleId] END ASC,
    CASE WHEN (@SorterColumn = 'RoleId' AND @SortToggler = 1) THEN [RoleId] END DESC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 0) THEN [Name] END ASC,
    CASE WHEN (@SorterColumn = 'Name' AND @SortToggler = 1) THEN [Name] END DESC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 0) THEN [Active] END ASC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 1) THEN [Active] END DESC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 0) THEN [UserCreationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 1) THEN [UserCreationId] END DESC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 0) THEN [UserLastModificationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 1) THEN [UserLastModificationId] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 0) THEN [DateTimeCreation] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 1) THEN [DateTimeCreation] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 0) THEN [DateTimeLastModification] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 1) THEN [DateTimeLastModification] END DESC

OFFSET (@ActualPageNumber - 1) * @RowsPerPage ROWS
FETCH NEXT @RowsPerPage ROWS ONLY
SELECT @TotalRows = COUNT(*) FROM [CMSCore.Role]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.Role.UpdateByRoleId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.Role.UpdateByRoleId]
(
    @RoleId INT,
    @Name VARCHAR(200),
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
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@RowsAffected int
EXEC [dbo].[CMSCore.Role.UpdateByRoleId]
    @RoleId = 1,
    @RowsAffected = @RowsAffected OUTPUT
SELECT @RowsAffected AS N'@RowsAffected'
 *
 */

--Last modification on: 09/12/2022 19:22:49

UPDATE [CMSCore.Role] SET
    [Name] = @Name,
    [Active] = @Active,
    [UserCreationId] = @UserCreationId,
    [UserLastModificationId] = @UserLastModificationId,
    [DateTimeCreation] = @DateTimeCreation,
    [DateTimeLastModification] = @DateTimeLastModification
WHERE 
    1 = 1 
    AND [CMSCore.Role].[RoleId] = @RoleId 

SELECT @RowsAffected = @@ROWCOUNT
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.RoleMenu.Count]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.RoleMenu.Count]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@Counter int

EXEC	@Counter = [dbo].[CMSCore.RoleMenu.Count]

SELECT	'Counter' = @Counter
 *
 */

--Last modification on: 09/12/2022 19:22:56

SELECT 
	COUNT(*)
FROM 
	[CMSCore.RoleMenu]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.RoleMenu.DeleteAll]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.RoleMenu.DeleteAll]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[CMSCore.RoleMenu.DeleteAll]
 *
 */

--Last modification on: 09/12/2022 19:22:56

DELETE FROM [CMSCore.RoleMenu]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.RoleMenu.DeleteByRoleMenuId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.RoleMenu.DeleteByRoleMenuId]
(
    @RoleMenuId INT,
    @RowsAffected INT OUTPUT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@RowsAffected INT
EXEC [dbo].[CMSCore.RoleMenu.DeleteByRoleMenuId]
    @RoleMenuId = 1,
    @RowsAffected = @RowsAffected OUTPUT
SELECT @RowsAffected AS N'@RowsAffected'
 *
 */

--Last modification on: 09/12/2022 19:22:56

DELETE FROM 
    [CMSCore.RoleMenu]
WHERE 
    1 = 1
    AND [CMSCore.RoleMenu].[RoleMenuId] = @RoleMenuId

SELECT @RowsAffected = @@ROWCOUNT
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.RoleMenu.Insert]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.RoleMenu.Insert] 
(
    @RoleId INT,
    @MenuId INT,
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
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@NewEnteredId INT
EXEC [dbo].[CMSCore.RoleMenu.Insert]

     @RoleId = 1,
     @MenuId = 1,
    @Active = 1,
    @UserCreationId = 1,
    @UserLastModificationId = 1,
    @DateTimeCreation = N'01/01/1753 0:00:00.001',
    @DateTimeLastModification = N'01/01/1753 0:00:00.001',

@NewEnteredId = @NewEnteredId OUTPUT

SELECT @NewEnteredId AS N'@NewEnteredId'
 *
 */

--Last modification on: 09/12/2022 19:22:56

INSERT INTO [CMSCore.RoleMenu]
(
    [RoleId],
    [MenuId],
    [Active],
    [UserCreationId],
    [UserLastModificationId],
    [DateTimeCreation],
    [DateTimeLastModification]
)
VALUES
(
    @RoleId,
    @MenuId,
    @Active,
    @UserCreationId,
    @UserLastModificationId,
    @DateTimeCreation,
    @DateTimeLastModification
)

SELECT @NewEnteredId = @@IDENTITY
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.RoleMenu.Select1ByRoleMenuId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.RoleMenu.Select1ByRoleMenuId]
(
    @RoleMenuId INT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[RoleMenu.Select1ByRoleMenuId]
    @RoleMenuId = 1
 *
 */

--Last modification on: 09/12/2022 19:22:56

SET DATEFORMAT DMY

SELECT
    [CMSCore.RoleMenu].[RoleMenuId] AS [RoleMenuId],
    [CMSCore.RoleMenu].[RoleId] AS [RoleId],
    [CMSCore.RoleMenu].[MenuId] AS [MenuId],
    [CMSCore.RoleMenu].[Active] AS [Active],
    [CMSCore.RoleMenu].[UserCreationId] AS [UserCreationId],
    [CMSCore.RoleMenu].[UserLastModificationId] AS [UserLastModificationId],
    [CMSCore.RoleMenu].[DateTimeCreation] AS [DateTimeCreation],
    [CMSCore.RoleMenu].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [CMSCore.RoleMenu]
WHERE 
    1 = 1
    AND [CMSCore.RoleMenu].[RoleMenuId] = @RoleMenuId
ORDER BY 
    [CMSCore.RoleMenu].[RoleMenuId]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.RoleMenu.SelectAll]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.RoleMenu.SelectAll]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[CMSCore.RoleMenu.SelectAll]
 *
 */

--Last modification on: 09/12/2022 19:22:56

SET DATEFORMAT DMY

SELECT
    [CMSCore.RoleMenu].[RoleMenuId] AS [RoleMenuId],
    [CMSCore.RoleMenu].[RoleId] AS [RoleId],
    [CMSCore.RoleMenu].[MenuId] AS [MenuId],
    [CMSCore.RoleMenu].[Active] AS [Active],
    [CMSCore.RoleMenu].[UserCreationId] AS [UserCreationId],
    [CMSCore.RoleMenu].[UserLastModificationId] AS [UserLastModificationId],
    [CMSCore.RoleMenu].[DateTimeCreation] AS [DateTimeCreation],
    [CMSCore.RoleMenu].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [CMSCore.RoleMenu]
ORDER BY 
    [CMSCore.RoleMenu].[RoleMenuId]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.RoleMenu.SelectAllByRoleId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[CMSCore.RoleMenu.SelectAllByRoleId]
(
	@RoleId int
)

AS

SET DATEFORMAT dmy

CREATE TABLE #Table
(
	[Value] INT,
	[Text] VARCHAR(MAX),
	[Selected] INT,
	[MenuName1] VARCHAR(MAX),
	[MenuName2] VARCHAR(MAX)
)

INSERT INTO #Table
SELECT 
	[CMSCore.Menu].[MenuId] AS [Value], 
	UPPER([CMSCore.Menu].[Name]) AS [Text], 
	1 AS [Selected], 
	[CMSCore.Menu].[Name], 
	'[___'
FROM 
	[CMSCore.RoleMenu], 
	[CMSCore.Menu]
WHERE 
	1 = 1
	AND [CMSCore.RoleMenu].[MenuId] = [CMSCore.Menu].[MenuId]
	AND [CMSCore.RoleMenu].[RoleId] = @RoleId
	AND [CMSCore.Menu].[Active] = 1
	AND [CMSCore.RoleMenu].[RoleId] = @RoleId 
	AND [CMSCore.Menu].[MenuFatherId] = 0

INSERT INTO #Table
SELECT 
	Menu.[MenuId] AS [Value], 
	UPPER(FatherMenu.[Name] + ' | ' + Menu.[Name]) AS [Text],
	1 AS [Selected], 
	FatherMenu.[Name], 
	'[___'
FROM 
	[CMSCore.RoleMenu], 
	[CMSCore.Menu] Menu, 
	[CMSCore.Menu] FatherMenu
where 
	1 = 1
	AND [CMSCore.RoleMenu].[MenuId] = Menu.[MenuId]
	AND [CMSCore.RoleMenu].[RoleId] = @RoleId
	AND Menu.[Active] = 1
	AND Menu.[MenuFatherId] = FatherMenu.[MenuId]
	AND Menu.[MenuFatherId] <> 0

INSERT INTO #Table
SELECT 
	Menu.[MenuId] AS [Value], 
	UPPER(FatherMenu.[Name] + ' | ' + Menu.[Name]) AS [Text], 
	0 AS [Selected], 
	FatherMenu.[Name], 
	Menu.[Name]
FROM 
	[CMSCore.Menu] Menu, 
	[CMSCore.Menu] FatherMenu
WHERE 
	1 = 1
	AND Menu.[Active] = 1
	AND Menu.[MenuFatherId] = FatherMenu.[MenuId]
	AND Menu.[MenuId] not in (select #Table.[Value] from #Table)
	AND Menu.[MenuFatherId] <> 0
ORDER BY 
	FatherMenu.[Name], 
	Menu.[Name]

INSERT INTO #Table
SELECT 
	[CMSCore.Menu].[MenuId] AS [Value], 
	UPPER([CMSCore.Menu].[Name]) AS [Text], 
	0 AS [Selected], 
	[CMSCore.Menu].[Name],
	[CMSCore.Menu].[Name]
FROM 
	[CMSCore.Menu] 
WHERE 
	1 = 1
	AND [CMSCore.Menu].[Active] = 1 
	AND [CMSCore.Menu].[MenuFatherId] = 0 
	AND [CMSCore.Menu].[MenuId] NOT IN (SELECT 
											#Table.[Value] 
										FROM 
											#Table)

SELECT 
	[Value], 
	[Text], 
	[Selected] 
FROM #Table 
ORDER BY
	[MenuName1], 
	[MenuName2]

DROP TABLE #Table



GO

/****** Object:  StoredProcedure [dbo].[CMSCore.RoleMenu.SelectAllPaged]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.RoleMenu.SelectAllPaged]
(
    @QueryString VARCHAR(100),
    @ActualPageNumber INT,
    @RowsPerPage INT,
    @SorterColumn VARCHAR(100),
    @SortToggler TINYINT,
    @TotalRows INT OUTPUT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*Execute this stored procedure with the next script as example

DECLARE	@TotalRows int
EXEC [dbo].[CMSCore.RoleMenu.SelectAllPaged]
    
    @QueryString = N'',
    @ActualPageNumber = 1,
    @RowsPerPage = 10,
    @SorterColumn = N'RoleMenuId',
    @SortToggler = 0,
    @TotalRows = @TotalRows OUTPUT

SELECT @TotalRows AS N'@TotalRows'
*/

--Last modification on: 09/12/2022 19:22:56

SET DATEFORMAT DMY
SET NOCOUNT ON

SELECT
    [CMSCore.RoleMenu].[RoleMenuId] AS [RoleMenuId],
    [CMSCore.RoleMenu].[RoleId] AS [RoleId],
    [CMSCore.RoleMenu].[MenuId] AS [MenuId],
    [CMSCore.RoleMenu].[Active] AS [Active],
    [CMSCore.RoleMenu].[UserCreationId] AS [UserCreationId],
    [CMSCore.RoleMenu].[UserLastModificationId] AS [UserLastModificationId],
    [CMSCore.RoleMenu].[DateTimeCreation] AS [DateTimeCreation],
    [CMSCore.RoleMenu].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [CMSCore.RoleMenu]
WHERE
    1=1
    AND (@QueryString = '' 
        OR ([CMSCore.RoleMenu].[RoleMenuId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.RoleMenu].[RoleId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.RoleMenu].[MenuId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.RoleMenu].[Active] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.RoleMenu].[UserCreationId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.RoleMenu].[UserLastModificationId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.RoleMenu].[DateTimeCreation] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.RoleMenu].[DateTimeLastModification] LIKE  '%' + @QueryString + '%')

    )
ORDER BY 
    CASE WHEN (@SorterColumn = 'RoleMenuId' AND @SortToggler = 0) THEN [RoleMenuId] END ASC,
    CASE WHEN (@SorterColumn = 'RoleMenuId' AND @SortToggler = 1) THEN [RoleMenuId] END DESC,
    CASE WHEN (@SorterColumn = 'RoleId' AND @SortToggler = 0) THEN [RoleId] END ASC,
    CASE WHEN (@SorterColumn = 'RoleId' AND @SortToggler = 1) THEN [RoleId] END DESC,
    CASE WHEN (@SorterColumn = 'MenuId' AND @SortToggler = 0) THEN [MenuId] END ASC,
    CASE WHEN (@SorterColumn = 'MenuId' AND @SortToggler = 1) THEN [MenuId] END DESC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 0) THEN [Active] END ASC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 1) THEN [Active] END DESC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 0) THEN [UserCreationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 1) THEN [UserCreationId] END DESC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 0) THEN [UserLastModificationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 1) THEN [UserLastModificationId] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 0) THEN [DateTimeCreation] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 1) THEN [DateTimeCreation] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 0) THEN [DateTimeLastModification] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 1) THEN [DateTimeLastModification] END DESC

OFFSET (@ActualPageNumber - 1) * @RowsPerPage ROWS
FETCH NEXT @RowsPerPage ROWS ONLY
SELECT @TotalRows = COUNT(*) FROM [CMSCore.RoleMenu]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.RoleMenu.SelectMenuesByRoleId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[CMSCore.RoleMenu.SelectMenuesByRoleId]
(
	@RoleId INT,
	@Menues VARCHAR(8000) OUTPUT
)

AS

SET DATEFORMAT dmy

DECLARE @MenuId INT, @MenuName VARCHAR(1000), @MenuURLPath VARCHAR(1000)

SELECT @Menues = ''

DECLARE CursorMenuFatherId CURSOR FOR 

SELECT 
	[CMSCore.Menu].[MenuId], 
	[CMSCore.Menu].[Name], 
	[CMSCore.Menu].[URLPath]
FROM 
	[CMSCore.Menu], [CMSCore.RoleMenu]
WHERE 1 = 1
	AND [CMSCore.Menu].[MenuId] = [CMSCore.RoleMenu].[MenuId]
	AND [CMSCore.RoleMenu].[RoleId] = @RoleId
	AND [CMSCore.Menu].[MenuFatherId] = 0
ORDER BY 
	[CMSCore.Menu].[Order]

OPEN CursorMenuFatherId
FETCH NEXT FROM CursorMenuFatherId INTO @MenuId, @MenuName, @MenuURLPath
WHILE @@FETCH_STATUS = 0
BEGIN
	--Run MenuFatherId
	SELECT @Menues = @Menues + '
					<h3>' + @MenuName + '</h3>
				<ul class=""breadcrumb"">'

    SELECT 
		@Menues = @Menues + '
		<li><a class="btn btn-white text-dark mb-2" href="' + [CMSCore.Menu].[URLPath] + '">' + LTRIM(RTRIM([CMSCore.Menu].[Name])) + '</a> </li>'
    FROM 
		[CMSCore.Menu], [CMSCore.RoleMenu]  
    WHERE 
		[CMSCore.Menu].[MenuFatherId] = @MenuId 
		AND [CMSCore.Menu].[Active] = 1
		AND [CMSCore.Menu].[MenuId] = [CMSCore.RoleMenu].[MenuId]
		AND [CMSCore.RoleMenu].[RoleId] = @RoleId
    ORDER BY 
		[CMSCore.Menu].[Name]
   
	SELECT @Menues = @Menues + '
	</ul><br />'
   
    FETCH NEXT FROM CursorMenuFatherId INTO @MenuId, @MenuName, @MenuURLPath
END
CLOSE CursorMenuFatherId
DEALLOCATE CursorMenuFatherId

SELECT @Menues AS Chain
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.RoleMenu.UpdateByRoleIdByMenuId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[CMSCore.RoleMenu.UpdateByRoleIdByMenuId]
(
	@RoleId INT,
	@MenuId INT,
	@Selected TINYINT
)

AS

SET DATEFORMAT dmy

IF @Selected = 0
	BEGIN
		DELETE FROM [CMSCore.RoleMenu] 
		WHERE
			RoleId = @RoleId
			AND MenuId = @MenuId
	END
ELSE
	BEGIN
		DELETE FROM [CMSCore.RoleMenu] 
		WHERE 
			RoleId = @RoleId 
			AND MenuId = @MenuId
		INSERT INTO [CMSCore.RoleMenu] SELECT @RoleId, @MenuId, 1, 1, 1, null, null
	END

SELECT 1

GO

/****** Object:  StoredProcedure [dbo].[CMSCore.RoleMenu.UpdateByRoleMenuId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.RoleMenu.UpdateByRoleMenuId]
(
    @RoleMenuId INT,
    @RoleId INT,
    @MenuId INT,
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
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@RowsAffected int
EXEC [dbo].[CMSCore.RoleMenu.UpdateByRoleMenuId]
    @RoleMenuId = 1,
    @RowsAffected = @RowsAffected OUTPUT
SELECT @RowsAffected AS N'@RowsAffected'
 *
 */

--Last modification on: 09/12/2022 19:22:56

UPDATE [CMSCore.RoleMenu] SET
    [RoleId] = @RoleId,
    [MenuId] = @MenuId,
    [Active] = @Active,
    [UserCreationId] = @UserCreationId,
    [UserLastModificationId] = @UserLastModificationId,
    [DateTimeCreation] = @DateTimeCreation,
    [DateTimeLastModification] = @DateTimeLastModification
WHERE 
    1 = 1 
    AND [CMSCore.RoleMenu].[RoleMenuId] = @RoleMenuId 

SELECT @RowsAffected = @@ROWCOUNT
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.User.Count]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.User.Count]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@Counter int

EXEC	@Counter = [dbo].[CMSCore.User.Count]

SELECT	'Counter' = @Counter
 *
 */

--Last modification on: 08/12/2022 10:43:01

SELECT 
	COUNT(*)
FROM 
	[CMSCore.User]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.User.DeleteAll]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.User.DeleteAll]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[CMSCore.User.DeleteAll]
 *
 */

--Last modification on: 08/12/2022 10:43:01

DELETE FROM [CMSCore.User]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.User.DeleteByUserId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.User.DeleteByUserId]
(
    @UserId INT,
    @RowsAffected INT OUTPUT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
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

--Last modification on: 08/12/2022 10:43:01

DELETE FROM 
    [CMSCore.User]
WHERE 
    1 = 1
    AND [CMSCore.User].[UserId] = @UserId

SELECT @RowsAffected = @@ROWCOUNT
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.User.Insert]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.User.Insert] 
(
    @FantasyName VARCHAR(200),
    @Email VARCHAR(320),
    @Password VARCHAR(8000),
    @ProfileImageURL VARCHAR(8000),
    @DateTimeBirth DATETIME,
    @VerificationToken VARCHAR(8000),
    @CookieToken VARCHAR(8000),
    @RoleId INT,
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
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@NewEnteredId INT
EXEC [dbo].[CMSCore.User.Insert]

    @FantasyName = N'PutFantasyName',
    @Email = N'PutEmail',
    @Password = N'PutPassword',
    @ProfileImageURL = N'PutProfileImageURL',
    @DateTimeBirth = N'01/01/1753 0:00:00.001',
    @VerificationToken = N'PutVerificationToken',
    @CookieToken = N'PutCookieToken',
     @RoleId = 1,
    @Active = 1,
    @UserCreationId = 1,
    @UserLastModificationId = 1,
    @DateTimeCreation = N'01/01/1753 0:00:00.001',
    @DateTimeLastModification = N'01/01/1753 0:00:00.001',

@NewEnteredId = @NewEnteredId OUTPUT

SELECT @NewEnteredId AS N'@NewEnteredId'
 *
 */

--Last modification on: 08/12/2022 10:43:01

INSERT INTO [CMSCore.User]
(
    [FantasyName],
    [Email],
    [Password],
    [ProfileImageURL],
    [DateTimeBirth],
    [VerificationToken],
    [CookieToken],
    [RoleId],
    [Active],
    [UserCreationId],
    [UserLastModificationId],
    [DateTimeCreation],
    [DateTimeLastModification]
)
VALUES
(
    @FantasyName,
    @Email,
    @Password,
    @ProfileImageURL,
    @DateTimeBirth,
    @VerificationToken,
    @CookieToken,
    @RoleId,
    @Active,
    @UserCreationId,
    @UserLastModificationId,
    @DateTimeCreation,
    @DateTimeLastModification
)

SELECT @NewEnteredId = @@IDENTITY
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.User.Login]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[CMSCore.User.Login]
(
    @FantasyNameOrEmail VARCHAR(200),
	@Password VARCHAR(MAX)
)

AS

SET DATEFORMAT DMY

SELECT
    [CMSCore.User].[UserId] AS [UserId],
    [CMSCore.User].[FantasyName] AS [FantasyName],
    [CMSCore.User].[Email] AS [Email],
    [CMSCore.User].[Password] AS [Password],
    [CMSCore.User].[ProfileImageURL] AS [ProfileImageURL],
    [CMSCore.User].[DateTimeBirth] AS [DateTimeBirth],
    [CMSCore.User].[VerificationToken] AS [VerificationToken],
    [CMSCore.User].[CookieToken] AS [CookieToken],
    [CMSCore.User].[RoleId] AS [RoleId],
    [CMSCore.User].[Active] AS [Active],
    [CMSCore.User].[UserCreationId] AS [UserCreationId],
    [CMSCore.User].[UserLastModificationId] AS [UserLastModificationId],
    [CMSCore.User].[DateTimeCreation] AS [DateTimeCreation],
    [CMSCore.User].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [CMSCore.User]
WHERE 
    1 = 1
    AND ([CMSCore.User].[FantasyName] = @FantasyNameOrEmail OR [CMSCore.User].[Email] = @FantasyNameOrEmail)
	AND [CMSCore.User].[Password] = @Password
ORDER BY 
    [CMSCore.User].[UserId]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.User.Select1ByUserId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.User.Select1ByUserId]
(
    @UserId INT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[User.Select1ByUserId]
    @UserId = 1
 *
 */

--Last modification on: 08/12/2022 10:43:01

SET DATEFORMAT DMY

SELECT
    [CMSCore.User].[UserId] AS [UserId],
    [CMSCore.User].[FantasyName] AS [FantasyName],
    [CMSCore.User].[Email] AS [Email],
    [CMSCore.User].[Password] AS [Password],
    [CMSCore.User].[ProfileImageURL] AS [ProfileImageURL],
    [CMSCore.User].[DateTimeBirth] AS [DateTimeBirth],
    [CMSCore.User].[VerificationToken] AS [VerificationToken],
    [CMSCore.User].[CookieToken] AS [CookieToken],
    [CMSCore.User].[RoleId] AS [RoleId],
    [CMSCore.User].[Active] AS [Active],
    [CMSCore.User].[UserCreationId] AS [UserCreationId],
    [CMSCore.User].[UserLastModificationId] AS [UserLastModificationId],
    [CMSCore.User].[DateTimeCreation] AS [DateTimeCreation],
    [CMSCore.User].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [CMSCore.User]
WHERE 
    1 = 1
    AND [CMSCore.User].[UserId] = @UserId
ORDER BY 
    [CMSCore.User].[UserId]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.User.SelectAll]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.User.SelectAll]

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [dbo].[CMSCore.User.SelectAll]
 *
 */

--Last modification on: 08/12/2022 10:43:01

SET DATEFORMAT DMY

SELECT
    [CMSCore.User].[UserId] AS [UserId],
    [CMSCore.User].[FantasyName] AS [FantasyName],
    [CMSCore.User].[Email] AS [Email],
    [CMSCore.User].[Password] AS [Password],
    [CMSCore.User].[ProfileImageURL] AS [ProfileImageURL],
    [CMSCore.User].[DateTimeBirth] AS [DateTimeBirth],
    [CMSCore.User].[VerificationToken] AS [VerificationToken],
    [CMSCore.User].[CookieToken] AS [CookieToken],
    [CMSCore.User].[RoleId] AS [RoleId],
    [CMSCore.User].[Active] AS [Active],
    [CMSCore.User].[UserCreationId] AS [UserCreationId],
    [CMSCore.User].[UserLastModificationId] AS [UserLastModificationId],
    [CMSCore.User].[DateTimeCreation] AS [DateTimeCreation],
    [CMSCore.User].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [CMSCore.User]
ORDER BY 
    [CMSCore.User].[UserId]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.User.SelectAllPaged]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.User.SelectAllPaged]
(
    @QueryString VARCHAR(100),
    @ActualPageNumber INT,
    @RowsPerPage INT,
    @SorterColumn VARCHAR(100),
    @SortToggler TINYINT,
    @TotalRows INT OUTPUT
)

AS

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
 */

/*Execute this stored procedure with the next script as example

DECLARE	@TotalRows int
EXEC [dbo].[CMSCore.User.SelectAllPaged]
    
    @QueryString = N'',
    @ActualPageNumber = 1,
    @RowsPerPage = 10,
    @SorterColumn = N'UserId',
    @SortToggler = 0,
    @TotalRows = @TotalRows OUTPUT

SELECT @TotalRows AS N'@TotalRows'
*/

--Last modification on: 08/12/2022 10:43:01

SET DATEFORMAT DMY
SET NOCOUNT ON

SELECT
    [CMSCore.User].[UserId] AS [UserId],
    [CMSCore.User].[FantasyName] AS [FantasyName],
    [CMSCore.User].[Email] AS [Email],
    [CMSCore.User].[Password] AS [Password],
    [CMSCore.User].[ProfileImageURL] AS [ProfileImageURL],
    [CMSCore.User].[DateTimeBirth] AS [DateTimeBirth],
    [CMSCore.User].[VerificationToken] AS [VerificationToken],
    [CMSCore.User].[CookieToken] AS [CookieToken],
    [CMSCore.User].[RoleId] AS [RoleId],
    [CMSCore.User].[Active] AS [Active],
    [CMSCore.User].[UserCreationId] AS [UserCreationId],
    [CMSCore.User].[UserLastModificationId] AS [UserLastModificationId],
    [CMSCore.User].[DateTimeCreation] AS [DateTimeCreation],
    [CMSCore.User].[DateTimeLastModification] AS [DateTimeLastModification]
FROM 
    [CMSCore.User]
WHERE
    1=1
    AND (@QueryString = '' 
        OR ([CMSCore.User].[UserId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.User].[FantasyName] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.User].[Email] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.User].[Password] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.User].[ProfileImageURL] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.User].[DateTimeBirth] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.User].[VerificationToken] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.User].[CookieToken] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.User].[RoleId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.User].[Active] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.User].[UserCreationId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.User].[UserLastModificationId] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.User].[DateTimeCreation] LIKE  '%' + @QueryString + '%')
        OR ([CMSCore.User].[DateTimeLastModification] LIKE  '%' + @QueryString + '%')

    )
ORDER BY 
    CASE WHEN (@SorterColumn = 'UserId' AND @SortToggler = 0) THEN [UserId] END ASC,
    CASE WHEN (@SorterColumn = 'UserId' AND @SortToggler = 1) THEN [UserId] END DESC,
    CASE WHEN (@SorterColumn = 'FantasyName' AND @SortToggler = 0) THEN [FantasyName] END ASC,
    CASE WHEN (@SorterColumn = 'FantasyName' AND @SortToggler = 1) THEN [FantasyName] END DESC,
    CASE WHEN (@SorterColumn = 'Email' AND @SortToggler = 0) THEN [Email] END ASC,
    CASE WHEN (@SorterColumn = 'Email' AND @SortToggler = 1) THEN [Email] END DESC,
    CASE WHEN (@SorterColumn = 'Password' AND @SortToggler = 0) THEN [Password] END ASC,
    CASE WHEN (@SorterColumn = 'Password' AND @SortToggler = 1) THEN [Password] END DESC,
    CASE WHEN (@SorterColumn = 'ProfileImageURL' AND @SortToggler = 0) THEN [ProfileImageURL] END ASC,
    CASE WHEN (@SorterColumn = 'ProfileImageURL' AND @SortToggler = 1) THEN [ProfileImageURL] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeBirth' AND @SortToggler = 0) THEN [DateTimeBirth] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeBirth' AND @SortToggler = 1) THEN [DateTimeBirth] END DESC,
    CASE WHEN (@SorterColumn = 'VerificationToken' AND @SortToggler = 0) THEN [VerificationToken] END ASC,
    CASE WHEN (@SorterColumn = 'VerificationToken' AND @SortToggler = 1) THEN [VerificationToken] END DESC,
    CASE WHEN (@SorterColumn = 'CookieToken' AND @SortToggler = 0) THEN [CookieToken] END ASC,
    CASE WHEN (@SorterColumn = 'CookieToken' AND @SortToggler = 1) THEN [CookieToken] END DESC,
    CASE WHEN (@SorterColumn = 'RoleId' AND @SortToggler = 0) THEN [RoleId] END ASC,
    CASE WHEN (@SorterColumn = 'RoleId' AND @SortToggler = 1) THEN [RoleId] END DESC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 0) THEN [Active] END ASC,
    CASE WHEN (@SorterColumn = 'Active' AND @SortToggler = 1) THEN [Active] END DESC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 0) THEN [UserCreationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserCreationId' AND @SortToggler = 1) THEN [UserCreationId] END DESC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 0) THEN [UserLastModificationId] END ASC,
    CASE WHEN (@SorterColumn = 'UserLastModificationId' AND @SortToggler = 1) THEN [UserLastModificationId] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 0) THEN [DateTimeCreation] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeCreation' AND @SortToggler = 1) THEN [DateTimeCreation] END DESC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 0) THEN [DateTimeLastModification] END ASC,
    CASE WHEN (@SorterColumn = 'DateTimeLastModification' AND @SortToggler = 1) THEN [DateTimeLastModification] END DESC

OFFSET (@ActualPageNumber - 1) * @RowsPerPage ROWS
FETCH NEXT @RowsPerPage ROWS ONLY
SELECT @TotalRows = COUNT(*) FROM [CMSCore.User]
GO

/****** Object:  StoredProcedure [dbo].[CMSCore.User.UpdateByUserId]    Script Date: 13/12/2022 20:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CMSCore.User.UpdateByUserId]
(
    @UserId INT,
    @FantasyName VARCHAR(200),
    @Email VARCHAR(320),
    @Password VARCHAR(8000),
    @ProfileImageURL VARCHAR(8000),
    @DateTimeBirth DATETIME,
    @VerificationToken VARCHAR(8000),
    @CookieToken VARCHAR(8000),
    @RoleId INT,
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
 * Licensed to a unique person with this Token:IAmTheOwnerOfThis
 * 
 * Coded by www.fiyistack.com
 * Copyright © 2021
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * Auto generated code. It should not be modified from here.
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

--Last modification on: 08/12/2022 10:43:01

UPDATE [CMSCore.User] SET
    [FantasyName] = @FantasyName,
    [Email] = @Email,
    [Password] = @Password,
    [ProfileImageURL] = @ProfileImageURL,
    [DateTimeBirth] = @DateTimeBirth,
    [VerificationToken] = @VerificationToken,
    [CookieToken] = @CookieToken,
    [RoleId] = @RoleId,
    [Active] = @Active,
    [UserCreationId] = @UserCreationId,
    [UserLastModificationId] = @UserLastModificationId,
    [DateTimeCreation] = @DateTimeCreation,
    [DateTimeLastModification] = @DateTimeLastModification
WHERE 
    1 = 1 
    AND [CMSCore.User].[UserId] = @UserId 

SELECT @RowsAffected = @@ROWCOUNT
GO


