using ClosedXML.Excel;
using CsvHelper;
using IronPdf;
using Microsoft.AspNetCore.Http;
using FiyiStackWeb.Areas.FiyiStack.Models;
using FiyiStackWeb.Areas.FiyiStack.DTOs;
using FiyiStackWeb.Areas.FiyiStack.Interfaces;
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

//Last modification on: 23/07/2023 22:03:13

namespace FiyiStackWeb.Areas.FiyiStack.Services
{
    /// <summary>
    /// Stack:             4<br/>
    /// Name:              C# Service. <br/>
    /// Function:          Allow you to separate data contract stored in C# model from business with your clients. <br/>
    /// Also, allow dependency injection inside controllers/web apis<br/>
    /// Last modification: 23/07/2023 22:03:13
    /// </summary>
    public partial class SendUsDBDiagramService : ISendUsDBDiagram
    {
        private readonly IHttpContextAccessor _IHttpContextAccessor;

        public SendUsDBDiagramService(IHttpContextAccessor IHttpContextAccessor)
        {
            _IHttpContextAccessor = IHttpContextAccessor;
        }

        #region Queries
        public SendUsDBDiagramModel Select1BySendUsDBDiagramIdToModel(int SendUsDBDiagramId)
        {
            return new SendUsDBDiagramModel().Select1BySendUsDBDiagramIdToModel(SendUsDBDiagramId);
        }

        public List<SendUsDBDiagramModel> SelectAllToList()
        {
            return new SendUsDBDiagramModel().SelectAllToList();
        }

        public sendusdbdiagramSelectAllPaged SelectAllPagedToModel(sendusdbdiagramSelectAllPaged sendusdbdiagramSelectAllPaged)
        {
            return new SendUsDBDiagramModel().SelectAllPagedToModel(sendusdbdiagramSelectAllPaged);
        } 
        #endregion

        #region Non-Queries
        public int Insert(SendUsDBDiagramModel SendUsDBDiagramModel)
        {
            return new SendUsDBDiagramModel().Insert(SendUsDBDiagramModel);
        }

        public int UpdateBySendUsDBDiagramId(SendUsDBDiagramModel SendUsDBDiagramModel)
        {
            return new SendUsDBDiagramModel().UpdateBySendUsDBDiagramId(SendUsDBDiagramModel);
        }

        public int DeleteBySendUsDBDiagramId(int SendUsDBDiagramId)
        {
            return new SendUsDBDiagramModel().DeleteBySendUsDBDiagramId(SendUsDBDiagramId);
        }

        public void DeleteManyOrAll(Ajax Ajax, string DeleteType)
        {
            if (DeleteType == "All")
            {
                SendUsDBDiagramModel SendUsDBDiagramModel = new SendUsDBDiagramModel();
                SendUsDBDiagramModel.DeleteAll();
            }
            else
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                for (int i = 0; i < RowsChecked.Length; i++)
                {
                    SendUsDBDiagramModel SendUsDBDiagramModel = new SendUsDBDiagramModel().Select1BySendUsDBDiagramIdToModel(Convert.ToInt32(RowsChecked[i]));
                    SendUsDBDiagramModel.DeleteBySendUsDBDiagramId(SendUsDBDiagramModel.SendUsDBDiagramId);
                }
            }
        }

        public int CopyBySendUsDBDiagramId(int SendUsDBDiagramId)
        {
            SendUsDBDiagramModel SendUsDBDiagramModel = new SendUsDBDiagramModel().Select1BySendUsDBDiagramIdToModel(SendUsDBDiagramId);
            int NewEnteredId = new SendUsDBDiagramModel().Insert(SendUsDBDiagramModel);

            return NewEnteredId;
        }

        public int[] CopyManyOrAll(Ajax Ajax, string CopyType)
        {
            if (CopyType == "All")
            {
                List<SendUsDBDiagramModel> lstSendUsDBDiagramModel = new List<SendUsDBDiagramModel> { };
                lstSendUsDBDiagramModel = new SendUsDBDiagramModel().SelectAllToList();

                int[] NewEnteredIds = new int[lstSendUsDBDiagramModel.Count];

                for (int i = 0; i < lstSendUsDBDiagramModel.Count; i++)
                {
                    NewEnteredIds[i] = lstSendUsDBDiagramModel[i].Insert();
                }

                return NewEnteredIds;
            }
            else
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');
                int[] NewEnteredIds = new int[RowsChecked.Length];

                for (int i = 0; i < RowsChecked.Length; i++)
                {
                    SendUsDBDiagramModel SendUsDBDiagramModel = new SendUsDBDiagramModel().Select1BySendUsDBDiagramIdToModel(Convert.ToInt32(RowsChecked[i]));
                    NewEnteredIds[i] = SendUsDBDiagramModel.Insert();
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
            List<SendUsDBDiagramModel> lstSendUsDBDiagramModel = new List<SendUsDBDiagramModel> { };

            if (ExportationType == "All")
            {
                lstSendUsDBDiagramModel = new SendUsDBDiagramModel().SelectAllToList();

            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {
                    SendUsDBDiagramModel SendUsDBDiagramModel = new SendUsDBDiagramModel().Select1BySendUsDBDiagramIdToModel(Convert.ToInt32(RowChecked));
                    lstSendUsDBDiagramModel.Add(SendUsDBDiagramModel);
                }
            }

            foreach (SendUsDBDiagramModel row in lstSendUsDBDiagramModel)
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
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #4c4c4c; font-size: 36px; line-height: 45px; font-weight: 300; letter-spacing: -1px;"">Registers of SendUsDBDiagram</span>
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
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">SendUsDBDiagramId&nbsp;&nbsp;&nbsp;</span>
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
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">Title&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">Description&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">FileUploaded&nbsp;&nbsp;&nbsp;</span>
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
").SaveAs($@"wwwroot/PDFFiles/FiyiStack/SendUsDBDiagram/SendUsDBDiagram_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.pdf");

            return Now;
        }

        public DateTime ExportAsExcel(Ajax Ajax, string ExportationType)
        {
            DateTime Now = DateTime.Now;

            using var Book = new XLWorkbook();

            if (ExportationType == "All")
            {
                DataTable dtSendUsDBDiagram = new DataTable();
                dtSendUsDBDiagram.TableName = "SendUsDBDiagram";

                //We define another DataTable dtSendUsDBDiagramCopy to avoid issue related to DateTime conversion
                DataTable dtSendUsDBDiagramCopy = new DataTable();
                dtSendUsDBDiagramCopy.TableName = "SendUsDBDiagram";

                #region Define columns for dtSendUsDBDiagramCopy
                DataColumn dtColumnSendUsDBDiagramIdFordtSendUsDBDiagramCopy = new DataColumn();
                    dtColumnSendUsDBDiagramIdFordtSendUsDBDiagramCopy.DataType = typeof(string);
                    dtColumnSendUsDBDiagramIdFordtSendUsDBDiagramCopy.ColumnName = "SendUsDBDiagramId";
                    dtSendUsDBDiagramCopy.Columns.Add(dtColumnSendUsDBDiagramIdFordtSendUsDBDiagramCopy);

                    DataColumn dtColumnActiveFordtSendUsDBDiagramCopy = new DataColumn();
                    dtColumnActiveFordtSendUsDBDiagramCopy.DataType = typeof(string);
                    dtColumnActiveFordtSendUsDBDiagramCopy.ColumnName = "Active";
                    dtSendUsDBDiagramCopy.Columns.Add(dtColumnActiveFordtSendUsDBDiagramCopy);

                    DataColumn dtColumnDateTimeCreationFordtSendUsDBDiagramCopy = new DataColumn();
                    dtColumnDateTimeCreationFordtSendUsDBDiagramCopy.DataType = typeof(string);
                    dtColumnDateTimeCreationFordtSendUsDBDiagramCopy.ColumnName = "DateTimeCreation";
                    dtSendUsDBDiagramCopy.Columns.Add(dtColumnDateTimeCreationFordtSendUsDBDiagramCopy);

                    DataColumn dtColumnDateTimeLastModificationFordtSendUsDBDiagramCopy = new DataColumn();
                    dtColumnDateTimeLastModificationFordtSendUsDBDiagramCopy.DataType = typeof(string);
                    dtColumnDateTimeLastModificationFordtSendUsDBDiagramCopy.ColumnName = "DateTimeLastModification";
                    dtSendUsDBDiagramCopy.Columns.Add(dtColumnDateTimeLastModificationFordtSendUsDBDiagramCopy);

                    DataColumn dtColumnUserCreationIdFordtSendUsDBDiagramCopy = new DataColumn();
                    dtColumnUserCreationIdFordtSendUsDBDiagramCopy.DataType = typeof(string);
                    dtColumnUserCreationIdFordtSendUsDBDiagramCopy.ColumnName = "UserCreationId";
                    dtSendUsDBDiagramCopy.Columns.Add(dtColumnUserCreationIdFordtSendUsDBDiagramCopy);

                    DataColumn dtColumnUserLastModificationIdFordtSendUsDBDiagramCopy = new DataColumn();
                    dtColumnUserLastModificationIdFordtSendUsDBDiagramCopy.DataType = typeof(string);
                    dtColumnUserLastModificationIdFordtSendUsDBDiagramCopy.ColumnName = "UserLastModificationId";
                    dtSendUsDBDiagramCopy.Columns.Add(dtColumnUserLastModificationIdFordtSendUsDBDiagramCopy);

                    DataColumn dtColumnTitleFordtSendUsDBDiagramCopy = new DataColumn();
                    dtColumnTitleFordtSendUsDBDiagramCopy.DataType = typeof(string);
                    dtColumnTitleFordtSendUsDBDiagramCopy.ColumnName = "Title";
                    dtSendUsDBDiagramCopy.Columns.Add(dtColumnTitleFordtSendUsDBDiagramCopy);

                    DataColumn dtColumnDescriptionFordtSendUsDBDiagramCopy = new DataColumn();
                    dtColumnDescriptionFordtSendUsDBDiagramCopy.DataType = typeof(string);
                    dtColumnDescriptionFordtSendUsDBDiagramCopy.ColumnName = "Description";
                    dtSendUsDBDiagramCopy.Columns.Add(dtColumnDescriptionFordtSendUsDBDiagramCopy);

                    DataColumn dtColumnFileUploadedFordtSendUsDBDiagramCopy = new DataColumn();
                    dtColumnFileUploadedFordtSendUsDBDiagramCopy.DataType = typeof(string);
                    dtColumnFileUploadedFordtSendUsDBDiagramCopy.ColumnName = "FileUploaded";
                    dtSendUsDBDiagramCopy.Columns.Add(dtColumnFileUploadedFordtSendUsDBDiagramCopy);

                    
                #endregion

                dtSendUsDBDiagram = new SendUsDBDiagramModel().SelectAllToDataTable();

                foreach (DataRow DataRow in dtSendUsDBDiagram.Rows)
                {
                    dtSendUsDBDiagramCopy.Rows.Add(DataRow.ItemArray);
                }

                var Sheet = Book.Worksheets.Add(dtSendUsDBDiagramCopy);

                Sheet.ColumnsUsed().AdjustToContents();

                Book.SaveAs($@"wwwroot/ExcelFiles/SendUsDBDiagraming/SendUsDBDiagram/SendUsDBDiagram_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.xlsx");
            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                DataSet dsSendUsDBDiagram = new DataSet();

                foreach (string RowChecked in RowsChecked)
                {
                    //We define another DataTable dtSendUsDBDiagramCopy to avoid issue related to DateTime conversion
                    DataTable dtSendUsDBDiagramCopy = new DataTable();
                    dtSendUsDBDiagramCopy.TableName = "SendUsDBDiagram";

                    #region Define columns for dtSendUsDBDiagramCopy
                    DataColumn dtColumnSendUsDBDiagramIdFordtSendUsDBDiagramCopy = new DataColumn();
                    dtColumnSendUsDBDiagramIdFordtSendUsDBDiagramCopy.DataType = typeof(string);
                    dtColumnSendUsDBDiagramIdFordtSendUsDBDiagramCopy.ColumnName = "SendUsDBDiagramId";
                    dtSendUsDBDiagramCopy.Columns.Add(dtColumnSendUsDBDiagramIdFordtSendUsDBDiagramCopy);

                    DataColumn dtColumnActiveFordtSendUsDBDiagramCopy = new DataColumn();
                    dtColumnActiveFordtSendUsDBDiagramCopy.DataType = typeof(string);
                    dtColumnActiveFordtSendUsDBDiagramCopy.ColumnName = "Active";
                    dtSendUsDBDiagramCopy.Columns.Add(dtColumnActiveFordtSendUsDBDiagramCopy);

                    DataColumn dtColumnDateTimeCreationFordtSendUsDBDiagramCopy = new DataColumn();
                    dtColumnDateTimeCreationFordtSendUsDBDiagramCopy.DataType = typeof(string);
                    dtColumnDateTimeCreationFordtSendUsDBDiagramCopy.ColumnName = "DateTimeCreation";
                    dtSendUsDBDiagramCopy.Columns.Add(dtColumnDateTimeCreationFordtSendUsDBDiagramCopy);

                    DataColumn dtColumnDateTimeLastModificationFordtSendUsDBDiagramCopy = new DataColumn();
                    dtColumnDateTimeLastModificationFordtSendUsDBDiagramCopy.DataType = typeof(string);
                    dtColumnDateTimeLastModificationFordtSendUsDBDiagramCopy.ColumnName = "DateTimeLastModification";
                    dtSendUsDBDiagramCopy.Columns.Add(dtColumnDateTimeLastModificationFordtSendUsDBDiagramCopy);

                    DataColumn dtColumnUserCreationIdFordtSendUsDBDiagramCopy = new DataColumn();
                    dtColumnUserCreationIdFordtSendUsDBDiagramCopy.DataType = typeof(string);
                    dtColumnUserCreationIdFordtSendUsDBDiagramCopy.ColumnName = "UserCreationId";
                    dtSendUsDBDiagramCopy.Columns.Add(dtColumnUserCreationIdFordtSendUsDBDiagramCopy);

                    DataColumn dtColumnUserLastModificationIdFordtSendUsDBDiagramCopy = new DataColumn();
                    dtColumnUserLastModificationIdFordtSendUsDBDiagramCopy.DataType = typeof(string);
                    dtColumnUserLastModificationIdFordtSendUsDBDiagramCopy.ColumnName = "UserLastModificationId";
                    dtSendUsDBDiagramCopy.Columns.Add(dtColumnUserLastModificationIdFordtSendUsDBDiagramCopy);

                    DataColumn dtColumnTitleFordtSendUsDBDiagramCopy = new DataColumn();
                    dtColumnTitleFordtSendUsDBDiagramCopy.DataType = typeof(string);
                    dtColumnTitleFordtSendUsDBDiagramCopy.ColumnName = "Title";
                    dtSendUsDBDiagramCopy.Columns.Add(dtColumnTitleFordtSendUsDBDiagramCopy);

                    DataColumn dtColumnDescriptionFordtSendUsDBDiagramCopy = new DataColumn();
                    dtColumnDescriptionFordtSendUsDBDiagramCopy.DataType = typeof(string);
                    dtColumnDescriptionFordtSendUsDBDiagramCopy.ColumnName = "Description";
                    dtSendUsDBDiagramCopy.Columns.Add(dtColumnDescriptionFordtSendUsDBDiagramCopy);

                    DataColumn dtColumnFileUploadedFordtSendUsDBDiagramCopy = new DataColumn();
                    dtColumnFileUploadedFordtSendUsDBDiagramCopy.DataType = typeof(string);
                    dtColumnFileUploadedFordtSendUsDBDiagramCopy.ColumnName = "FileUploaded";
                    dtSendUsDBDiagramCopy.Columns.Add(dtColumnFileUploadedFordtSendUsDBDiagramCopy);

                    
                    #endregion

                    dsSendUsDBDiagram.Tables.Add(dtSendUsDBDiagramCopy);

                    for (int i = 0; i < dsSendUsDBDiagram.Tables.Count; i++)
                    {
                        dtSendUsDBDiagramCopy = new SendUsDBDiagramModel().Select1BySendUsDBDiagramIdToDataTable(Convert.ToInt32(RowChecked));

                        foreach (DataRow DataRow in dtSendUsDBDiagramCopy.Rows)
                        {
                            dsSendUsDBDiagram.Tables[0].Rows.Add(DataRow.ItemArray);
                        }
                    }
                    
                }

                for (int i = 0; i < dsSendUsDBDiagram.Tables.Count; i++)
                {
                    var Sheet = Book.Worksheets.Add(dsSendUsDBDiagram.Tables[i]);
                    Sheet.ColumnsUsed().AdjustToContents();
                }

                Book.SaveAs($@"wwwroot/ExcelFiles/SendUsDBDiagraming/SendUsDBDiagram/SendUsDBDiagram_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.xlsx");
            }

            return Now;
        }

        public DateTime ExportAsCSV(Ajax Ajax, string ExportationType)
        {
            DateTime Now = DateTime.Now;
            List<SendUsDBDiagramModel> lstSendUsDBDiagramModel = new List<SendUsDBDiagramModel> { };

            if (ExportationType == "All")
            {
                lstSendUsDBDiagramModel = new SendUsDBDiagramModel().SelectAllToList();

            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {
                    SendUsDBDiagramModel SendUsDBDiagramModel = new SendUsDBDiagramModel().Select1BySendUsDBDiagramIdToModel(Convert.ToInt32(RowChecked));
                    lstSendUsDBDiagramModel.Add(SendUsDBDiagramModel);
                }
            }

            using (var Writer = new StreamWriter($@"wwwroot/CSVFiles/SendUsDBDiagraming/SendUsDBDiagram/SendUsDBDiagram_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.csv"))
            using (var CsvWriter = new CsvWriter(Writer, CultureInfo.InvariantCulture))
            {
                CsvWriter.WriteRecords(lstSendUsDBDiagramModel);
            }

            return Now;
        }
        #endregion
    }
}