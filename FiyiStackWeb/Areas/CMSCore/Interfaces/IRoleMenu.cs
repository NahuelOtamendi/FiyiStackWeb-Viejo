using FiyiStackWeb.Areas.CMSCore.Models;
using FiyiStackWeb.Library;
using System;
using System.Collections.Generic;

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

//Last modification on: 20/12/2022 20:28:32

namespace FiyiStackWeb.Areas.CMSCore.Interfaces
{
    /// <summary>
    /// Stack:             5<br/>
    /// Name:              C# Interface. <br/>
    /// Function:          This interface allow you to standardize the C# service associated. 
    ///                    In other words, define the functions that has to implement the C# service. <br/>
    /// Note:              Raise exception in case of missing any function declared here but not in the service. <br/>
    /// Last modification: 20/12/2022 20:28:32
    /// </summary>
    public partial interface IRoleMenu
    {
        #region Queries
        /// <summary>
        /// Note: Raise exception when the query find duplicated IDs
        /// </summary>
        /// <param name="RoleMenuId"></param>
        /// <returns></returns>
        RoleMenuModel Select1ByRoleMenuIdToModel(int RoleMenuId);

        List<RoleMenuModel> SelectAllToList();

        rolemenuModelQuery SelectAllPagedToModel(rolemenuModelQuery rolemenuModelQuery);

        List<roleMenuForChechboxes> SelectAllByRoleIdToRoleMenuForChechboxes(int RoleId);
        #endregion

        #region Non-Queries
        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull insertion in database
        /// </summary>
        /// <param name="RoleMenu"></param>
        /// <returns>NewEnteredId: The ID of the last registry inserted in RoleMenu table</returns>
        int Insert(RoleMenuModel RoleMenu);

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull update in database
        /// </summary>
        /// <param name="RoleMenu"></param>
        /// <returns>The number of rows updated in RoleMenu table</returns>
        int UpdateByRoleMenuId(RoleMenuModel RoleMenu);

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull deletion in database
        /// </summary>
        /// <param name="RoleMenuId"></param>
        /// <returns>The number of rows deleted in RoleMenu table</returns>
        int DeleteByRoleMenuId(int RoleMenuId);

        void DeleteManyOrAll(Ajax Ajax, string DeleteType);

        int CopyByRoleMenuId(int RoleMenuId);

        int[] CopyManyOrAll(Ajax Ajax, string CopyType);

        void UpdateByRoleIdByMenuId(int RoleId, int MenuId, bool Selected);
        #endregion

        #region Other actions
        DateTime ExportAsPDF(Ajax Ajax, string ExportationType);

        DateTime ExportAsExcel(Ajax Ajax, string ExportationType);

        DateTime ExportAsCSV(Ajax Ajax, string ExportationType);
        #endregion
    }
}