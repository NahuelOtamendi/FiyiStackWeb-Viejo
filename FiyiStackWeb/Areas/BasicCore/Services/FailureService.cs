using ClosedXML.Excel;
using CsvHelper;
using IronPdf;
using Microsoft.AspNetCore.Http;
using FiyiStackWeb.Areas.BasicCore.Models;
using FiyiStackWeb.Areas.BasicCore.DTOs;
using FiyiStackWeb.Areas.BasicCore.Interfaces;
using FiyiStackWeb.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;

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

namespace FiyiStackWeb.Areas.BasicCore.Services
{
    /// <summary>
    /// Stack:             4<br/>
    /// Name:              C# Service. <br/>
    /// Function:          Allow you to separate data contract stored in C# model from business with your clients. <br/>
    /// Also, allow dependency injection inside controllers/web apis<br/>
    /// Last modification: 21/02/2023 17:35:10
    /// </summary>
    public partial class FailureService : IFailure
    {
        private readonly IHttpContextAccessor _IHttpContextAccessor;

        public FailureService(IHttpContextAccessor IHttpContextAccessor)
        {
            _IHttpContextAccessor = IHttpContextAccessor;
        }

        #region Queries
        public FailureModel Select1ByFailureIdToModel(int FailureId)
        {
            return new FailureModel().Select1ByFailureIdToModel(FailureId);
        }

        public List<FailureModel> SelectAllToList()
        {
            return new FailureModel().SelectAllToList();
        }

        public failureSelectAllPaged SelectAllPagedToModel(failureSelectAllPaged failureSelectAllPaged)
        {
            return new FailureModel().SelectAllPagedToModel(failureSelectAllPaged);
        } 
        #endregion

        #region Non-Queries
        public int Insert(FailureModel FailureModel)
        {
            return new FailureModel().Insert(FailureModel);
        }

        public int UpdateByFailureId(FailureModel FailureModel)
        {
            return new FailureModel().UpdateByFailureId(FailureModel);
        }

        public int DeleteByFailureId(int FailureId)
        {
            return new FailureModel().DeleteByFailureId(FailureId);
        }

        public void DeleteManyOrAll(Ajax Ajax, string DeleteType)
        {
            if (DeleteType == "All")
            {
                FailureModel FailureModel = new FailureModel();
                FailureModel.DeleteAll();
            }
            else
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                for (int i = 0; i < RowsChecked.Length; i++)
                {
                    FailureModel FailureModel = new FailureModel().Select1ByFailureIdToModel(Convert.ToInt32(RowsChecked[i]));
                    FailureModel.DeleteByFailureId(FailureModel.FailureId);
                }
            }
        }

        public int CopyByFailureId(int FailureId)
        {
            FailureModel FailureModel = new FailureModel().Select1ByFailureIdToModel(FailureId);
            int NewEnteredId = new FailureModel().Insert(FailureModel);

            return NewEnteredId;
        }

        public int[] CopyManyOrAll(Ajax Ajax, string CopyType)
        {
            if (CopyType == "All")
            {
                List<FailureModel> lstFailureModel = new List<FailureModel> { };
                lstFailureModel = new FailureModel().SelectAllToList();

                int[] NewEnteredIds = new int[lstFailureModel.Count];

                for (int i = 0; i < lstFailureModel.Count; i++)
                {
                    NewEnteredIds[i] = lstFailureModel[i].Insert();
                }

                return NewEnteredIds;
            }
            else
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');
                int[] NewEnteredIds = new int[RowsChecked.Length];

                for (int i = 0; i < RowsChecked.Length; i++)
                {
                    FailureModel FailureModel = new FailureModel().Select1ByFailureIdToModel(Convert.ToInt32(RowsChecked[i]));
                    NewEnteredIds[i] = FailureModel.Insert();
                }

                return NewEnteredIds;
            }
        }
        #endregion

        #region Other services
        public DateTime ExportAsPDF(Ajax Ajax, string ExportationType)
        {
            var Renderer = new HtmlToPdf();
            DateTime Now = DateTime.Now;
            string RowsAsHTML = "";
            List<FailureModel> lstFailureModel = new List<FailureModel> { };

            if (ExportationType == "All")
            {
                lstFailureModel = new FailureModel().SelectAllToList();

            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {
                    FailureModel FailureModel = new FailureModel().Select1ByFailureIdToModel(Convert.ToInt32(RowChecked));
                    lstFailureModel.Add(FailureModel);
                }
            }

            foreach (FailureModel row in lstFailureModel)
            {
                RowsAsHTML += $@"{row.ToStringOnlyValuesForHTML()}";
            }

            Renderer.RenderHtmlAsPdf($@"<table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""88%"" style=""width: 88% !important; min-width: 88%; max-width: 88%;"">
    <tr>
    <td align=""left"" valign=""top"">
        <font face=""'Source Sans Pro', sans-serif"" color=""#1a1a1a"" style=""font-size: 52px; line-height: 55px; font-weight: 300; letter-spacing: -1.5px;"">
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #1a1a1a; font-size: 52px; line-height: 55px; font-weight: 300; letter-spacing: -1.5px;"">Mikromatica</span>
        </font>
        <div style=""height: 25px; line-height: 25px; font-size: 23px;"">&nbsp;</div>
        <font face=""'Source Sans Pro', sans-serif"" color=""#4c4c4c"" style=""font-size: 36px; line-height: 45px; font-weight: 300; letter-spacing: -1px;"">
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #4c4c4c; font-size: 36px; line-height: 45px; font-weight: 300; letter-spacing: -1px;"">Registers of Failure</span>
        </font>
        <div style=""height: 35px; line-height: 35px; font-size: 33px;"">&nbsp;</div>
    </td>
    </tr>
</table>
<br>
<table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""100%"" style=""width: 100% !important; min-width: 100%; max-width: 100%;"">
    <tr>
        <th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">FailureId&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">Active&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">DateTimeCreation&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">DateTimeLastModification&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">UserCreationId&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">UserLastModificationId&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">HTTPCode&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">Message&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">EmergencyLevel&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">StackTrace&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">Source&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">Comment&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th>
    </tr>
    {RowsAsHTML}
</table>
<br>
<font face=""'Source Sans Pro', sans-serif"" color=""#868686"" style=""font-size: 17px; line-height: 20px;"">
    <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #868686; font-size: 17px; line-height: 20px;"">Printed on: {Now}</span>
</font>
").SaveAs($@"wwwroot/PDFFiles/BasicCore/Failure/Failure_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.pdf");

            return Now;
        }

        public DateTime ExportAsExcel(Ajax Ajax, string ExportationType)
        {
            DateTime Now = DateTime.Now;

            using var Book = new XLWorkbook();

            if (ExportationType == "All")
            {
                DataTable dtFailure = new DataTable();
                dtFailure.TableName = "Failure";

                //We define another DataTable dtFailureCopy to avoid issue related to DateTime conversion
                DataTable dtFailureCopy = new DataTable();
                dtFailureCopy.TableName = "Failure";

                #region Define columns for dtFailureCopy
                DataColumn dtColumnFailureIdFordtFailureCopy = new DataColumn();
                    dtColumnFailureIdFordtFailureCopy.DataType = typeof(string);
                    dtColumnFailureIdFordtFailureCopy.ColumnName = "FailureId";
                    dtFailureCopy.Columns.Add(dtColumnFailureIdFordtFailureCopy);

                    DataColumn dtColumnActiveFordtFailureCopy = new DataColumn();
                    dtColumnActiveFordtFailureCopy.DataType = typeof(string);
                    dtColumnActiveFordtFailureCopy.ColumnName = "Active";
                    dtFailureCopy.Columns.Add(dtColumnActiveFordtFailureCopy);

                    DataColumn dtColumnDateTimeCreationFordtFailureCopy = new DataColumn();
                    dtColumnDateTimeCreationFordtFailureCopy.DataType = typeof(string);
                    dtColumnDateTimeCreationFordtFailureCopy.ColumnName = "DateTimeCreation";
                    dtFailureCopy.Columns.Add(dtColumnDateTimeCreationFordtFailureCopy);

                    DataColumn dtColumnDateTimeLastModificationFordtFailureCopy = new DataColumn();
                    dtColumnDateTimeLastModificationFordtFailureCopy.DataType = typeof(string);
                    dtColumnDateTimeLastModificationFordtFailureCopy.ColumnName = "DateTimeLastModification";
                    dtFailureCopy.Columns.Add(dtColumnDateTimeLastModificationFordtFailureCopy);

                    DataColumn dtColumnUserCreationIdFordtFailureCopy = new DataColumn();
                    dtColumnUserCreationIdFordtFailureCopy.DataType = typeof(string);
                    dtColumnUserCreationIdFordtFailureCopy.ColumnName = "UserCreationId";
                    dtFailureCopy.Columns.Add(dtColumnUserCreationIdFordtFailureCopy);

                    DataColumn dtColumnUserLastModificationIdFordtFailureCopy = new DataColumn();
                    dtColumnUserLastModificationIdFordtFailureCopy.DataType = typeof(string);
                    dtColumnUserLastModificationIdFordtFailureCopy.ColumnName = "UserLastModificationId";
                    dtFailureCopy.Columns.Add(dtColumnUserLastModificationIdFordtFailureCopy);

                    DataColumn dtColumnHTTPCodeFordtFailureCopy = new DataColumn();
                    dtColumnHTTPCodeFordtFailureCopy.DataType = typeof(string);
                    dtColumnHTTPCodeFordtFailureCopy.ColumnName = "HTTPCode";
                    dtFailureCopy.Columns.Add(dtColumnHTTPCodeFordtFailureCopy);

                    DataColumn dtColumnMessageFordtFailureCopy = new DataColumn();
                    dtColumnMessageFordtFailureCopy.DataType = typeof(string);
                    dtColumnMessageFordtFailureCopy.ColumnName = "Message";
                    dtFailureCopy.Columns.Add(dtColumnMessageFordtFailureCopy);

                    DataColumn dtColumnEmergencyLevelFordtFailureCopy = new DataColumn();
                    dtColumnEmergencyLevelFordtFailureCopy.DataType = typeof(string);
                    dtColumnEmergencyLevelFordtFailureCopy.ColumnName = "EmergencyLevel";
                    dtFailureCopy.Columns.Add(dtColumnEmergencyLevelFordtFailureCopy);

                    DataColumn dtColumnStackTraceFordtFailureCopy = new DataColumn();
                    dtColumnStackTraceFordtFailureCopy.DataType = typeof(string);
                    dtColumnStackTraceFordtFailureCopy.ColumnName = "StackTrace";
                    dtFailureCopy.Columns.Add(dtColumnStackTraceFordtFailureCopy);

                    DataColumn dtColumnSourceFordtFailureCopy = new DataColumn();
                    dtColumnSourceFordtFailureCopy.DataType = typeof(string);
                    dtColumnSourceFordtFailureCopy.ColumnName = "Source";
                    dtFailureCopy.Columns.Add(dtColumnSourceFordtFailureCopy);

                    DataColumn dtColumnCommentFordtFailureCopy = new DataColumn();
                    dtColumnCommentFordtFailureCopy.DataType = typeof(string);
                    dtColumnCommentFordtFailureCopy.ColumnName = "Comment";
                    dtFailureCopy.Columns.Add(dtColumnCommentFordtFailureCopy);

                    
                #endregion

                dtFailure = new FailureModel().SelectAllToDataTable();

                foreach (DataRow DataRow in dtFailure.Rows)
                {
                    dtFailureCopy.Rows.Add(DataRow.ItemArray);
                }

                var Sheet = Book.Worksheets.Add(dtFailureCopy);

                Sheet.ColumnsUsed().AdjustToContents();

                Book.SaveAs($@"wwwroot/ExcelFiles/Failureing/Failure/Failure_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.xlsx");
            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                DataSet dsFailure = new DataSet();

                foreach (string RowChecked in RowsChecked)
                {
                    //We define another DataTable dtFailureCopy to avoid issue related to DateTime conversion
                    DataTable dtFailureCopy = new DataTable();
                    dtFailureCopy.TableName = "Failure";

                    #region Define columns for dtFailureCopy
                    DataColumn dtColumnFailureIdFordtFailureCopy = new DataColumn();
                    dtColumnFailureIdFordtFailureCopy.DataType = typeof(string);
                    dtColumnFailureIdFordtFailureCopy.ColumnName = "FailureId";
                    dtFailureCopy.Columns.Add(dtColumnFailureIdFordtFailureCopy);

                    DataColumn dtColumnActiveFordtFailureCopy = new DataColumn();
                    dtColumnActiveFordtFailureCopy.DataType = typeof(string);
                    dtColumnActiveFordtFailureCopy.ColumnName = "Active";
                    dtFailureCopy.Columns.Add(dtColumnActiveFordtFailureCopy);

                    DataColumn dtColumnDateTimeCreationFordtFailureCopy = new DataColumn();
                    dtColumnDateTimeCreationFordtFailureCopy.DataType = typeof(string);
                    dtColumnDateTimeCreationFordtFailureCopy.ColumnName = "DateTimeCreation";
                    dtFailureCopy.Columns.Add(dtColumnDateTimeCreationFordtFailureCopy);

                    DataColumn dtColumnDateTimeLastModificationFordtFailureCopy = new DataColumn();
                    dtColumnDateTimeLastModificationFordtFailureCopy.DataType = typeof(string);
                    dtColumnDateTimeLastModificationFordtFailureCopy.ColumnName = "DateTimeLastModification";
                    dtFailureCopy.Columns.Add(dtColumnDateTimeLastModificationFordtFailureCopy);

                    DataColumn dtColumnUserCreationIdFordtFailureCopy = new DataColumn();
                    dtColumnUserCreationIdFordtFailureCopy.DataType = typeof(string);
                    dtColumnUserCreationIdFordtFailureCopy.ColumnName = "UserCreationId";
                    dtFailureCopy.Columns.Add(dtColumnUserCreationIdFordtFailureCopy);

                    DataColumn dtColumnUserLastModificationIdFordtFailureCopy = new DataColumn();
                    dtColumnUserLastModificationIdFordtFailureCopy.DataType = typeof(string);
                    dtColumnUserLastModificationIdFordtFailureCopy.ColumnName = "UserLastModificationId";
                    dtFailureCopy.Columns.Add(dtColumnUserLastModificationIdFordtFailureCopy);

                    DataColumn dtColumnHTTPCodeFordtFailureCopy = new DataColumn();
                    dtColumnHTTPCodeFordtFailureCopy.DataType = typeof(string);
                    dtColumnHTTPCodeFordtFailureCopy.ColumnName = "HTTPCode";
                    dtFailureCopy.Columns.Add(dtColumnHTTPCodeFordtFailureCopy);

                    DataColumn dtColumnMessageFordtFailureCopy = new DataColumn();
                    dtColumnMessageFordtFailureCopy.DataType = typeof(string);
                    dtColumnMessageFordtFailureCopy.ColumnName = "Message";
                    dtFailureCopy.Columns.Add(dtColumnMessageFordtFailureCopy);

                    DataColumn dtColumnEmergencyLevelFordtFailureCopy = new DataColumn();
                    dtColumnEmergencyLevelFordtFailureCopy.DataType = typeof(string);
                    dtColumnEmergencyLevelFordtFailureCopy.ColumnName = "EmergencyLevel";
                    dtFailureCopy.Columns.Add(dtColumnEmergencyLevelFordtFailureCopy);

                    DataColumn dtColumnStackTraceFordtFailureCopy = new DataColumn();
                    dtColumnStackTraceFordtFailureCopy.DataType = typeof(string);
                    dtColumnStackTraceFordtFailureCopy.ColumnName = "StackTrace";
                    dtFailureCopy.Columns.Add(dtColumnStackTraceFordtFailureCopy);

                    DataColumn dtColumnSourceFordtFailureCopy = new DataColumn();
                    dtColumnSourceFordtFailureCopy.DataType = typeof(string);
                    dtColumnSourceFordtFailureCopy.ColumnName = "Source";
                    dtFailureCopy.Columns.Add(dtColumnSourceFordtFailureCopy);

                    DataColumn dtColumnCommentFordtFailureCopy = new DataColumn();
                    dtColumnCommentFordtFailureCopy.DataType = typeof(string);
                    dtColumnCommentFordtFailureCopy.ColumnName = "Comment";
                    dtFailureCopy.Columns.Add(dtColumnCommentFordtFailureCopy);

                    
                    #endregion

                    dsFailure.Tables.Add(dtFailureCopy);

                    for (int i = 0; i < dsFailure.Tables.Count; i++)
                    {
                        dtFailureCopy = new FailureModel().Select1ByFailureIdToDataTable(Convert.ToInt32(RowChecked));

                        foreach (DataRow DataRow in dtFailureCopy.Rows)
                        {
                            dsFailure.Tables[0].Rows.Add(DataRow.ItemArray);
                        }
                    }
                    
                }

                for (int i = 0; i < dsFailure.Tables.Count; i++)
                {
                    var Sheet = Book.Worksheets.Add(dsFailure.Tables[i]);
                    Sheet.ColumnsUsed().AdjustToContents();
                }

                Book.SaveAs($@"wwwroot/ExcelFiles/Failureing/Failure/Failure_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.xlsx");
            }

            return Now;
        }

        public DateTime ExportAsCSV(Ajax Ajax, string ExportationType)
        {
            DateTime Now = DateTime.Now;
            List<FailureModel> lstFailureModel = new List<FailureModel> { };

            if (ExportationType == "All")
            {
                lstFailureModel = new FailureModel().SelectAllToList();

            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {
                    FailureModel FailureModel = new FailureModel().Select1ByFailureIdToModel(Convert.ToInt32(RowChecked));
                    lstFailureModel.Add(FailureModel);
                }
            }

            using (var Writer = new StreamWriter($@"wwwroot/CSVFiles/Failureing/Failure/Failure_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.csv"))
            using (var CsvWriter = new CsvWriter(Writer, CultureInfo.InvariantCulture))
            {
                CsvWriter.WriteRecords(lstFailureModel);
            }

            return Now;
        }
        #endregion
    }
}