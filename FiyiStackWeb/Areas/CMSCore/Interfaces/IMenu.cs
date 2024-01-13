using FiyiStackWeb.Areas.CMSCore.DTOs;
using FiyiStackWeb.Areas.CMSCore.Models;
using FiyiStackWeb.Library;
using System;
using System.Collections.Generic;

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * 
 * Coded by fiyistack.com
 * Copyright © 2023
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 */

//Last modification on: 21/02/2023 17:56:41

namespace FiyiStackWeb.Areas.CMSCore.Interfaces
{
    /// <summary>
    /// Stack:             5<br/>
    /// Name:              C# Interface. <br/>
    /// Function:          This interface allow you to standardize the C# service associated. 
    ///                    In other words, define the functions that has to implement the C# service. <br/>
    /// Note:              Raise exception in case of missing any function declared here but not in the service. <br/>
    /// Last modification: 21/02/2023 17:56:41
    /// </summary>
    public partial interface IMenu
    {
        #region Queries
        /// <summary>
        /// Note: Raise exception when the query find duplicated IDs
        /// </summary>
        /// <param name="MenuId"></param>
        /// <returns></returns>
        MenuModel Select1ByMenuIdToModel(int MenuId);

        List<MenuModel> SelectAllToList();

        menuSelectAllPaged SelectAllPagedToModel(menuSelectAllPaged menuSelectAllPaged);
        #endregion

        #region Non-Queries
        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull insertion in database
        /// </summary>
        /// <param name="Menu"></param>
        /// <returns>NewEnteredId: The ID of the last registry inserted in Menu table</returns>
        int Insert(MenuModel Menu);

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull update in database
        /// </summary>
        /// <param name="Menu"></param>
        /// <returns>The number of rows updated in Menu table</returns>
        int UpdateByMenuId(MenuModel Menu);

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull deletion in database
        /// </summary>
        /// <param name="MenuId"></param>
        /// <returns>The number of rows deleted in Menu table</returns>
        int DeleteByMenuId(int MenuId);

        void DeleteManyOrAll(Ajax Ajax, string DeleteType);

        int CopyByMenuId(int MenuId);

        int[] CopyManyOrAll(Ajax Ajax, string CopyType);
        #endregion

        #region Other actions
        DateTime ExportAsPDF(Ajax Ajax, string ExportationType);

        DateTime ExportAsExcel(Ajax Ajax, string ExportationType);

        DateTime ExportAsCSV(Ajax Ajax, string ExportationType);
        #endregion
    }
}