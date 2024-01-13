using FiyiStackWeb.Areas.BasicCore.DTOs;
using FiyiStackWeb.Areas.BasicCore.Models;
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

//Last modification on: 21/02/2023 17:35:10

namespace FiyiStackWeb.Areas.BasicCore.Interfaces
{
    /// <summary>
    /// Stack:             5<br/>
    /// Name:              C# Interface. <br/>
    /// Function:          This interface allow you to standardize the C# service associated. 
    ///                    In other words, define the functions that has to implement the C# service. <br/>
    /// Note:              Raise exception in case of missing any function declared here but not in the service. <br/>
    /// Last modification: 21/02/2023 17:35:10
    /// </summary>
    public partial interface IFailure
    {
        #region Queries
        /// <summary>
        /// Note: Raise exception when the query find duplicated IDs
        /// </summary>
        /// <param name="FailureId"></param>
        /// <returns></returns>
        FailureModel Select1ByFailureIdToModel(int FailureId);

        List<FailureModel> SelectAllToList();

        failureSelectAllPaged SelectAllPagedToModel(failureSelectAllPaged failureSelectAllPaged);
        #endregion

        #region Non-Queries
        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull insertion in database
        /// </summary>
        /// <param name="Failure"></param>
        /// <returns>NewEnteredId: The ID of the last registry inserted in Failure table</returns>
        int Insert(FailureModel Failure);

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull update in database
        /// </summary>
        /// <param name="Failure"></param>
        /// <returns>The number of rows updated in Failure table</returns>
        int UpdateByFailureId(FailureModel Failure);

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull deletion in database
        /// </summary>
        /// <param name="FailureId"></param>
        /// <returns>The number of rows deleted in Failure table</returns>
        int DeleteByFailureId(int FailureId);

        void DeleteManyOrAll(Ajax Ajax, string DeleteType);

        int CopyByFailureId(int FailureId);

        int[] CopyManyOrAll(Ajax Ajax, string CopyType);
        #endregion

        #region Other actions
        DateTime ExportAsPDF(Ajax Ajax, string ExportationType);

        DateTime ExportAsExcel(Ajax Ajax, string ExportationType);

        DateTime ExportAsCSV(Ajax Ajax, string ExportationType);
        #endregion
    }
}