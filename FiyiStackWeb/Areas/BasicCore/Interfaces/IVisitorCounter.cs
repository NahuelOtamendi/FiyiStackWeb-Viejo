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

//Last modification on: 22/02/2023 13:29:13

namespace FiyiStackWeb.Areas.BasicCore.Interfaces
{
    /// <summary>
    /// Stack:             5<br/>
    /// Name:              C# Interface. <br/>
    /// Function:          This interface allow you to standardize the C# service associated. 
    ///                    In other words, define the functions that has to implement the C# service. <br/>
    /// Note:              Raise exception in case of missing any function declared here but not in the service. <br/>
    /// Last modification: 22/02/2023 13:29:13
    /// </summary>
    public partial interface IVisitorCounter
    {
        #region Queries
        /// <summary>
        /// Note: Raise exception when the query find duplicated IDs
        /// </summary>
        /// <param name="VisitorCounterId"></param>
        /// <returns></returns>
        VisitorCounterModel Select1ByVisitorCounterIdToModel(int VisitorCounterId);

        List<VisitorCounterModel> SelectAllToList();

        visitorcounterSelectAllPaged SelectAllPagedToModel(visitorcounterSelectAllPaged visitorcounterSelectAllPaged);
        
        List<visitorCounterPerMonth> SelectAllToVisitorsPerMonthChart();

        List<visitorCountPageVisits> SelectAllToVisitorsCounterPageChart();
        #endregion

        #region Non-Queries
        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull insertion in database
        /// </summary>
        /// <param name="VisitorCounter"></param>
        /// <returns>NewEnteredId: The ID of the last registry inserted in VisitorCounter table</returns>
        int Insert(VisitorCounterModel VisitorCounter);

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull update in database
        /// </summary>
        /// <param name="VisitorCounter"></param>
        /// <returns>The number of rows updated in VisitorCounter table</returns>
        int UpdateByVisitorCounterId(VisitorCounterModel VisitorCounter);

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull deletion in database
        /// </summary>
        /// <param name="VisitorCounterId"></param>
        /// <returns>The number of rows deleted in VisitorCounter table</returns>
        int DeleteByVisitorCounterId(int VisitorCounterId);

        void DeleteManyOrAll(Ajax Ajax, string DeleteType);

        int CopyByVisitorCounterId(int VisitorCounterId);

        int[] CopyManyOrAll(Ajax Ajax, string CopyType);
        #endregion

        #region Other actions
        DateTime ExportAsPDF(Ajax Ajax, string ExportationType);

        DateTime ExportAsExcel(Ajax Ajax, string ExportationType);

        DateTime ExportAsCSV(Ajax Ajax, string ExportationType);
        #endregion
    }
}