using FiyiStackWeb.Areas.BasicCulture.DTOs;
using FiyiStackWeb.Areas.BasicCulture.Models;
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

//Last modification on: 21/02/2023 17:54:25

namespace FiyiStackWeb.Areas.BasicCulture.Interfaces
{
    /// <summary>
    /// Stack:             5<br/>
    /// Name:              C# Interface. <br/>
    /// Function:          This interface allow you to standardize the C# service associated. 
    ///                    In other words, define the functions that has to implement the C# service. <br/>
    /// Note:              Raise exception in case of missing any function declared here but not in the service. <br/>
    /// Last modification: 21/02/2023 17:54:25
    /// </summary>
    public partial interface ISex
    {
        #region Queries
        /// <summary>
        /// Note: Raise exception when the query find duplicated IDs
        /// </summary>
        /// <param name="SexId"></param>
        /// <returns></returns>
        SexModel Select1BySexIdToModel(int SexId);

        List<SexModel> SelectAllToList();

        sexSelectAllPaged SelectAllPagedToModel(sexSelectAllPaged sexSelectAllPaged);
        #endregion

        #region Non-Queries
        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull insertion in database
        /// </summary>
        /// <param name="Sex"></param>
        /// <returns>NewEnteredId: The ID of the last registry inserted in Sex table</returns>
        int Insert(SexModel Sex);

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull update in database
        /// </summary>
        /// <param name="Sex"></param>
        /// <returns>The number of rows updated in Sex table</returns>
        int UpdateBySexId(SexModel Sex);

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull deletion in database
        /// </summary>
        /// <param name="SexId"></param>
        /// <returns>The number of rows deleted in Sex table</returns>
        int DeleteBySexId(int SexId);

        void DeleteManyOrAll(Ajax Ajax, string DeleteType);

        int CopyBySexId(int SexId);

        int[] CopyManyOrAll(Ajax Ajax, string CopyType);
        #endregion

        #region Other actions
        DateTime ExportAsPDF(Ajax Ajax, string ExportationType);

        DateTime ExportAsExcel(Ajax Ajax, string ExportationType);

        DateTime ExportAsCSV(Ajax Ajax, string ExportationType);
        #endregion
    }
}