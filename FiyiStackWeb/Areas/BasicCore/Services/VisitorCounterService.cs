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

//Last modification on: 22/02/2023 13:29:13

namespace FiyiStackWeb.Areas.BasicCore.Services
{
    /// <summary>
    /// Stack:             4<br/>
    /// Name:              C# Service. <br/>
    /// Function:          Allow you to separate data contract stored in C# model from business with your clients. <br/>
    /// Also, allow dependency injection inside controllers/web apis<br/>
    /// Last modification: 22/02/2023 13:29:13
    /// </summary>
    public partial class VisitorCounterService : IVisitorCounter
    {
        private readonly IHttpContextAccessor _IHttpContextAccessor;

        public VisitorCounterService(IHttpContextAccessor IHttpContextAccessor)
        {
            _IHttpContextAccessor = IHttpContextAccessor;
        }

        #region Queries
        public VisitorCounterModel Select1ByVisitorCounterIdToModel(int VisitorCounterId)
        {
            return new VisitorCounterModel().Select1ByVisitorCounterIdToModel(VisitorCounterId);
        }

        public List<VisitorCounterModel> SelectAllToList()
        {
            return new VisitorCounterModel().SelectAllToList();
        }

        public visitorcounterSelectAllPaged SelectAllPagedToModel(visitorcounterSelectAllPaged visitorcounterSelectAllPaged)
        {
            return new VisitorCounterModel().SelectAllPagedToModel(visitorcounterSelectAllPaged);
        }

        public List<visitorCounterPerMonth> SelectAllToVisitorsPerMonthChart()
        {
            return new VisitorCounterModel().SelectAllToVisitorsPerMonthChart();
        }

        public List<visitorCountPageVisits> SelectAllToVisitorsCounterPageChart()
        {
            return new VisitorCounterModel().SelectAllToVisitorsCounterPageChart();
        }
        #endregion

        #region Non-Queries
        public int Insert(VisitorCounterModel VisitorCounterModel)
        {
            return new VisitorCounterModel().Insert(VisitorCounterModel);
        }

        public int UpdateByVisitorCounterId(VisitorCounterModel VisitorCounterModel)
        {
            return new VisitorCounterModel().UpdateByVisitorCounterId(VisitorCounterModel);
        }

        public int DeleteByVisitorCounterId(int VisitorCounterId)
        {
            return new VisitorCounterModel().DeleteByVisitorCounterId(VisitorCounterId);
        }

        public void DeleteManyOrAll(Ajax Ajax, string DeleteType)
        {
            if (DeleteType == "All")
            {
                VisitorCounterModel VisitorCounterModel = new VisitorCounterModel();
                VisitorCounterModel.DeleteAll();
            }
            else
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                for (int i = 0; i < RowsChecked.Length; i++)
                {
                    VisitorCounterModel VisitorCounterModel = new VisitorCounterModel().Select1ByVisitorCounterIdToModel(Convert.ToInt32(RowsChecked[i]));
                    VisitorCounterModel.DeleteByVisitorCounterId(VisitorCounterModel.VisitorCounterId);
                }
            }
        }

        public int CopyByVisitorCounterId(int VisitorCounterId)
        {
            VisitorCounterModel VisitorCounterModel = new VisitorCounterModel().Select1ByVisitorCounterIdToModel(VisitorCounterId);
            int NewEnteredId = new VisitorCounterModel().Insert(VisitorCounterModel);

            return NewEnteredId;
        }

        public int[] CopyManyOrAll(Ajax Ajax, string CopyType)
        {
            if (CopyType == "All")
            {
                List<VisitorCounterModel> lstVisitorCounterModel = new List<VisitorCounterModel> { };
                lstVisitorCounterModel = new VisitorCounterModel().SelectAllToList();

                int[] NewEnteredIds = new int[lstVisitorCounterModel.Count];

                for (int i = 0; i < lstVisitorCounterModel.Count; i++)
                {
                    NewEnteredIds[i] = lstVisitorCounterModel[i].Insert();
                }

                return NewEnteredIds;
            }
            else
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');
                int[] NewEnteredIds = new int[RowsChecked.Length];

                for (int i = 0; i < RowsChecked.Length; i++)
                {
                    VisitorCounterModel VisitorCounterModel = new VisitorCounterModel().Select1ByVisitorCounterIdToModel(Convert.ToInt32(RowsChecked[i]));
                    NewEnteredIds[i] = VisitorCounterModel.Insert();
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
            List<VisitorCounterModel> lstVisitorCounterModel = new List<VisitorCounterModel> { };

            if (ExportationType == "All")
            {
                lstVisitorCounterModel = new VisitorCounterModel().SelectAllToList();

            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {
                    VisitorCounterModel VisitorCounterModel = new VisitorCounterModel().Select1ByVisitorCounterIdToModel(Convert.ToInt32(RowChecked));
                    lstVisitorCounterModel.Add(VisitorCounterModel);
                }
            }

            foreach (VisitorCounterModel row in lstVisitorCounterModel)
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
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #4c4c4c; font-size: 36px; line-height: 45px; font-weight: 300; letter-spacing: -1px;"">Registers of VisitorCounter</span>
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
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">VisitorCounterId&nbsp;&nbsp;&nbsp;</span>
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
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">DateTime&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">Page&nbsp;&nbsp;&nbsp;</span>
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
").SaveAs($@"wwwroot/PDFFiles/BasicCore/VisitorCounter/VisitorCounter_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.pdf");

            return Now;
        }

        public DateTime ExportAsExcel(Ajax Ajax, string ExportationType)
        {
            DateTime Now = DateTime.Now;

            using var Book = new XLWorkbook();

            if (ExportationType == "All")
            {
                DataTable dtVisitorCounter = new DataTable();
                dtVisitorCounter.TableName = "VisitorCounter";

                //We define another DataTable dtVisitorCounterCopy to avoid issue related to DateTime conversion
                DataTable dtVisitorCounterCopy = new DataTable();
                dtVisitorCounterCopy.TableName = "VisitorCounter";

                #region Define columns for dtVisitorCounterCopy
                DataColumn dtColumnVisitorCounterIdFordtVisitorCounterCopy = new DataColumn();
                    dtColumnVisitorCounterIdFordtVisitorCounterCopy.DataType = typeof(string);
                    dtColumnVisitorCounterIdFordtVisitorCounterCopy.ColumnName = "VisitorCounterId";
                    dtVisitorCounterCopy.Columns.Add(dtColumnVisitorCounterIdFordtVisitorCounterCopy);

                    DataColumn dtColumnActiveFordtVisitorCounterCopy = new DataColumn();
                    dtColumnActiveFordtVisitorCounterCopy.DataType = typeof(string);
                    dtColumnActiveFordtVisitorCounterCopy.ColumnName = "Active";
                    dtVisitorCounterCopy.Columns.Add(dtColumnActiveFordtVisitorCounterCopy);

                    DataColumn dtColumnDateTimeCreationFordtVisitorCounterCopy = new DataColumn();
                    dtColumnDateTimeCreationFordtVisitorCounterCopy.DataType = typeof(string);
                    dtColumnDateTimeCreationFordtVisitorCounterCopy.ColumnName = "DateTimeCreation";
                    dtVisitorCounterCopy.Columns.Add(dtColumnDateTimeCreationFordtVisitorCounterCopy);

                    DataColumn dtColumnDateTimeLastModificationFordtVisitorCounterCopy = new DataColumn();
                    dtColumnDateTimeLastModificationFordtVisitorCounterCopy.DataType = typeof(string);
                    dtColumnDateTimeLastModificationFordtVisitorCounterCopy.ColumnName = "DateTimeLastModification";
                    dtVisitorCounterCopy.Columns.Add(dtColumnDateTimeLastModificationFordtVisitorCounterCopy);

                    DataColumn dtColumnUserCreationIdFordtVisitorCounterCopy = new DataColumn();
                    dtColumnUserCreationIdFordtVisitorCounterCopy.DataType = typeof(string);
                    dtColumnUserCreationIdFordtVisitorCounterCopy.ColumnName = "UserCreationId";
                    dtVisitorCounterCopy.Columns.Add(dtColumnUserCreationIdFordtVisitorCounterCopy);

                    DataColumn dtColumnUserLastModificationIdFordtVisitorCounterCopy = new DataColumn();
                    dtColumnUserLastModificationIdFordtVisitorCounterCopy.DataType = typeof(string);
                    dtColumnUserLastModificationIdFordtVisitorCounterCopy.ColumnName = "UserLastModificationId";
                    dtVisitorCounterCopy.Columns.Add(dtColumnUserLastModificationIdFordtVisitorCounterCopy);

                    DataColumn dtColumnDateTimeFordtVisitorCounterCopy = new DataColumn();
                    dtColumnDateTimeFordtVisitorCounterCopy.DataType = typeof(string);
                    dtColumnDateTimeFordtVisitorCounterCopy.ColumnName = "DateTime";
                    dtVisitorCounterCopy.Columns.Add(dtColumnDateTimeFordtVisitorCounterCopy);

                    DataColumn dtColumnPageFordtVisitorCounterCopy = new DataColumn();
                    dtColumnPageFordtVisitorCounterCopy.DataType = typeof(string);
                    dtColumnPageFordtVisitorCounterCopy.ColumnName = "Page";
                    dtVisitorCounterCopy.Columns.Add(dtColumnPageFordtVisitorCounterCopy);

                    
                #endregion

                dtVisitorCounter = new VisitorCounterModel().SelectAllToDataTable();

                foreach (DataRow DataRow in dtVisitorCounter.Rows)
                {
                    dtVisitorCounterCopy.Rows.Add(DataRow.ItemArray);
                }

                var Sheet = Book.Worksheets.Add(dtVisitorCounterCopy);

                Sheet.ColumnsUsed().AdjustToContents();

                Book.SaveAs($@"wwwroot/ExcelFiles/VisitorCountering/VisitorCounter/VisitorCounter_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.xlsx");
            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                DataSet dsVisitorCounter = new DataSet();

                foreach (string RowChecked in RowsChecked)
                {
                    //We define another DataTable dtVisitorCounterCopy to avoid issue related to DateTime conversion
                    DataTable dtVisitorCounterCopy = new DataTable();
                    dtVisitorCounterCopy.TableName = "VisitorCounter";

                    #region Define columns for dtVisitorCounterCopy
                    DataColumn dtColumnVisitorCounterIdFordtVisitorCounterCopy = new DataColumn();
                    dtColumnVisitorCounterIdFordtVisitorCounterCopy.DataType = typeof(string);
                    dtColumnVisitorCounterIdFordtVisitorCounterCopy.ColumnName = "VisitorCounterId";
                    dtVisitorCounterCopy.Columns.Add(dtColumnVisitorCounterIdFordtVisitorCounterCopy);

                    DataColumn dtColumnActiveFordtVisitorCounterCopy = new DataColumn();
                    dtColumnActiveFordtVisitorCounterCopy.DataType = typeof(string);
                    dtColumnActiveFordtVisitorCounterCopy.ColumnName = "Active";
                    dtVisitorCounterCopy.Columns.Add(dtColumnActiveFordtVisitorCounterCopy);

                    DataColumn dtColumnDateTimeCreationFordtVisitorCounterCopy = new DataColumn();
                    dtColumnDateTimeCreationFordtVisitorCounterCopy.DataType = typeof(string);
                    dtColumnDateTimeCreationFordtVisitorCounterCopy.ColumnName = "DateTimeCreation";
                    dtVisitorCounterCopy.Columns.Add(dtColumnDateTimeCreationFordtVisitorCounterCopy);

                    DataColumn dtColumnDateTimeLastModificationFordtVisitorCounterCopy = new DataColumn();
                    dtColumnDateTimeLastModificationFordtVisitorCounterCopy.DataType = typeof(string);
                    dtColumnDateTimeLastModificationFordtVisitorCounterCopy.ColumnName = "DateTimeLastModification";
                    dtVisitorCounterCopy.Columns.Add(dtColumnDateTimeLastModificationFordtVisitorCounterCopy);

                    DataColumn dtColumnUserCreationIdFordtVisitorCounterCopy = new DataColumn();
                    dtColumnUserCreationIdFordtVisitorCounterCopy.DataType = typeof(string);
                    dtColumnUserCreationIdFordtVisitorCounterCopy.ColumnName = "UserCreationId";
                    dtVisitorCounterCopy.Columns.Add(dtColumnUserCreationIdFordtVisitorCounterCopy);

                    DataColumn dtColumnUserLastModificationIdFordtVisitorCounterCopy = new DataColumn();
                    dtColumnUserLastModificationIdFordtVisitorCounterCopy.DataType = typeof(string);
                    dtColumnUserLastModificationIdFordtVisitorCounterCopy.ColumnName = "UserLastModificationId";
                    dtVisitorCounterCopy.Columns.Add(dtColumnUserLastModificationIdFordtVisitorCounterCopy);

                    DataColumn dtColumnDateTimeFordtVisitorCounterCopy = new DataColumn();
                    dtColumnDateTimeFordtVisitorCounterCopy.DataType = typeof(string);
                    dtColumnDateTimeFordtVisitorCounterCopy.ColumnName = "DateTime";
                    dtVisitorCounterCopy.Columns.Add(dtColumnDateTimeFordtVisitorCounterCopy);

                    DataColumn dtColumnPageFordtVisitorCounterCopy = new DataColumn();
                    dtColumnPageFordtVisitorCounterCopy.DataType = typeof(string);
                    dtColumnPageFordtVisitorCounterCopy.ColumnName = "Page";
                    dtVisitorCounterCopy.Columns.Add(dtColumnPageFordtVisitorCounterCopy);

                    
                    #endregion

                    dsVisitorCounter.Tables.Add(dtVisitorCounterCopy);

                    for (int i = 0; i < dsVisitorCounter.Tables.Count; i++)
                    {
                        dtVisitorCounterCopy = new VisitorCounterModel().Select1ByVisitorCounterIdToDataTable(Convert.ToInt32(RowChecked));

                        foreach (DataRow DataRow in dtVisitorCounterCopy.Rows)
                        {
                            dsVisitorCounter.Tables[0].Rows.Add(DataRow.ItemArray);
                        }
                    }
                    
                }

                for (int i = 0; i < dsVisitorCounter.Tables.Count; i++)
                {
                    var Sheet = Book.Worksheets.Add(dsVisitorCounter.Tables[i]);
                    Sheet.ColumnsUsed().AdjustToContents();
                }

                Book.SaveAs($@"wwwroot/ExcelFiles/VisitorCountering/VisitorCounter/VisitorCounter_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.xlsx");
            }

            return Now;
        }

        public DateTime ExportAsCSV(Ajax Ajax, string ExportationType)
        {
            DateTime Now = DateTime.Now;
            List<VisitorCounterModel> lstVisitorCounterModel = new List<VisitorCounterModel> { };

            if (ExportationType == "All")
            {
                lstVisitorCounterModel = new VisitorCounterModel().SelectAllToList();

            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {
                    VisitorCounterModel VisitorCounterModel = new VisitorCounterModel().Select1ByVisitorCounterIdToModel(Convert.ToInt32(RowChecked));
                    lstVisitorCounterModel.Add(VisitorCounterModel);
                }
            }

            using (var Writer = new StreamWriter($@"wwwroot/CSVFiles/VisitorCountering/VisitorCounter/VisitorCounter_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.csv"))
            using (var CsvWriter = new CsvWriter(Writer, CultureInfo.InvariantCulture))
            {
                CsvWriter.WriteRecords(lstVisitorCounterModel);
            }

            return Now;
        }
        #endregion
    }
}