using FiyiStackWeb.Areas.FiyiStack.DTOs;
using FiyiStackWeb.Areas.FiyiStack.Models;
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

//Last modification on: 23/07/2023 22:03:13

namespace FiyiStackWeb.Areas.FiyiStack.Interfaces
{
    /// <summary>
    /// Stack:             5<br/>
    /// Name:              C# Interface. <br/>
    /// Function:          This interface allow you to standardize the C# service associated. 
    ///                    In other words, define the functions that has to implement the C# service. <br/>
    /// Note:              Raise exception in case of missing any function declared here but not in the service. <br/>
    /// Last modification: 23/07/2023 22:03:13
    /// </summary>
    public partial interface ISendUsDBDiagram
    {
        #region Queries
        /// <summary>
        /// Note: Raise exception when the query find duplicated IDs
        /// </summary>
        /// <param name="SendUsDBDiagramId"></param>
        /// <returns></returns>
        SendUsDBDiagramModel Select1BySendUsDBDiagramIdToModel(int SendUsDBDiagramId);

        List<SendUsDBDiagramModel> SelectAllToList();

        sendusdbdiagramSelectAllPaged SelectAllPagedToModel(sendusdbdiagramSelectAllPaged sendusdbdiagramSelectAllPaged);
        #endregion

        #region Non-Queries
        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull insertion in database
        /// </summary>
        /// <param name="SendUsDBDiagram"></param>
        /// <returns>NewEnteredId: The ID of the last registry inserted in SendUsDBDiagram table</returns>
        int Insert(SendUsDBDiagramModel SendUsDBDiagram);

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull update in database
        /// </summary>
        /// <param name="SendUsDBDiagram"></param>
        /// <returns>The number of rows updated in SendUsDBDiagram table</returns>
        int UpdateBySendUsDBDiagramId(SendUsDBDiagramModel SendUsDBDiagram);

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull deletion in database
        /// </summary>
        /// <param name="SendUsDBDiagramId"></param>
        /// <returns>The number of rows deleted in SendUsDBDiagram table</returns>
        int DeleteBySendUsDBDiagramId(int SendUsDBDiagramId);

        void DeleteManyOrAll(Ajax Ajax, string DeleteType);

        int CopyBySendUsDBDiagramId(int SendUsDBDiagramId);

        int[] CopyManyOrAll(Ajax Ajax, string CopyType);
        #endregion

        #region Other actions
        DateTime ExportAsPDF(Ajax Ajax, string ExportationType);

        DateTime ExportAsExcel(Ajax Ajax, string ExportationType);

        DateTime ExportAsCSV(Ajax Ajax, string ExportationType);
        #endregion
    }
}