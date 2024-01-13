using ClosedXML.Excel;
using CsvHelper;
using IronPdf;
using Microsoft.AspNetCore.Http;
using FiyiStackWeb.Areas.BasicCulture.Models;
using FiyiStackWeb.Areas.BasicCulture.DTOs;
using FiyiStackWeb.Areas.BasicCulture.Interfaces;
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

//Last modification on: 21/02/2023 17:54:25

namespace FiyiStackWeb.Areas.BasicCulture.Services
{
    /// <summary>
    /// Stack:             4<br/>
    /// Name:              C# Service. <br/>
    /// Function:          Allow you to separate data contract stored in C# model from business with your clients. <br/>
    /// Also, allow dependency injection inside controllers/web apis<br/>
    /// Last modification: 21/02/2023 17:54:25
    /// </summary>
    public partial class SexService : ISex
    {
        private readonly IHttpContextAccessor _IHttpContextAccessor;

        public SexService(IHttpContextAccessor IHttpContextAccessor)
        {
            _IHttpContextAccessor = IHttpContextAccessor;
        }

        #region Queries
        public SexModel Select1BySexIdToModel(int SexId)
        {
            return new SexModel().Select1BySexIdToModel(SexId);
        }

        public List<SexModel> SelectAllToList()
        {
            return new SexModel().SelectAllToList();
        }

        public sexSelectAllPaged SelectAllPagedToModel(sexSelectAllPaged sexSelectAllPaged)
        {
            return new SexModel().SelectAllPagedToModel(sexSelectAllPaged);
        } 
        #endregion

        #region Non-Queries
        public int Insert(SexModel SexModel)
        {
            return new SexModel().Insert(SexModel);
        }

        public int UpdateBySexId(SexModel SexModel)
        {
            return new SexModel().UpdateBySexId(SexModel);
        }

        public int DeleteBySexId(int SexId)
        {
            return new SexModel().DeleteBySexId(SexId);
        }

        public void DeleteManyOrAll(Ajax Ajax, string DeleteType)
        {
            if (DeleteType == "All")
            {
                SexModel SexModel = new SexModel();
                SexModel.DeleteAll();
            }
            else
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                for (int i = 0; i < RowsChecked.Length; i++)
                {
                    SexModel SexModel = new SexModel().Select1BySexIdToModel(Convert.ToInt32(RowsChecked[i]));
                    SexModel.DeleteBySexId(SexModel.SexId);
                }
            }
        }

        public int CopyBySexId(int SexId)
        {
            SexModel SexModel = new SexModel().Select1BySexIdToModel(SexId);
            int NewEnteredId = new SexModel().Insert(SexModel);

            return NewEnteredId;
        }

        public int[] CopyManyOrAll(Ajax Ajax, string CopyType)
        {
            if (CopyType == "All")
            {
                List<SexModel> lstSexModel = new List<SexModel> { };
                lstSexModel = new SexModel().SelectAllToList();

                int[] NewEnteredIds = new int[lstSexModel.Count];

                for (int i = 0; i < lstSexModel.Count; i++)
                {
                    NewEnteredIds[i] = lstSexModel[i].Insert();
                }

                return NewEnteredIds;
            }
            else
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');
                int[] NewEnteredIds = new int[RowsChecked.Length];

                for (int i = 0; i < RowsChecked.Length; i++)
                {
                    SexModel SexModel = new SexModel().Select1BySexIdToModel(Convert.ToInt32(RowsChecked[i]));
                    NewEnteredIds[i] = SexModel.Insert();
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
            List<SexModel> lstSexModel = new List<SexModel> { };

            if (ExportationType == "All")
            {
                lstSexModel = new SexModel().SelectAllToList();

            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {
                    SexModel SexModel = new SexModel().Select1BySexIdToModel(Convert.ToInt32(RowChecked));
                    lstSexModel.Add(SexModel);
                }
            }

            foreach (SexModel row in lstSexModel)
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
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #4c4c4c; font-size: 36px; line-height: 45px; font-weight: 300; letter-spacing: -1px;"">Registers of Sex</span>
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
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">SexId&nbsp;&nbsp;&nbsp;</span>
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
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">Name&nbsp;&nbsp;&nbsp;</span>
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
").SaveAs($@"wwwroot/PDFFiles/BasicCulture/Sex/Sex_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.pdf");

            return Now;
        }

        public DateTime ExportAsExcel(Ajax Ajax, string ExportationType)
        {
            DateTime Now = DateTime.Now;

            using var Book = new XLWorkbook();

            if (ExportationType == "All")
            {
                DataTable dtSex = new DataTable();
                dtSex.TableName = "Sex";

                //We define another DataTable dtSexCopy to avoid issue related to DateTime conversion
                DataTable dtSexCopy = new DataTable();
                dtSexCopy.TableName = "Sex";

                #region Define columns for dtSexCopy
                DataColumn dtColumnSexIdFordtSexCopy = new DataColumn();
                    dtColumnSexIdFordtSexCopy.DataType = typeof(string);
                    dtColumnSexIdFordtSexCopy.ColumnName = "SexId";
                    dtSexCopy.Columns.Add(dtColumnSexIdFordtSexCopy);

                    DataColumn dtColumnActiveFordtSexCopy = new DataColumn();
                    dtColumnActiveFordtSexCopy.DataType = typeof(string);
                    dtColumnActiveFordtSexCopy.ColumnName = "Active";
                    dtSexCopy.Columns.Add(dtColumnActiveFordtSexCopy);

                    DataColumn dtColumnDateTimeCreationFordtSexCopy = new DataColumn();
                    dtColumnDateTimeCreationFordtSexCopy.DataType = typeof(string);
                    dtColumnDateTimeCreationFordtSexCopy.ColumnName = "DateTimeCreation";
                    dtSexCopy.Columns.Add(dtColumnDateTimeCreationFordtSexCopy);

                    DataColumn dtColumnDateTimeLastModificationFordtSexCopy = new DataColumn();
                    dtColumnDateTimeLastModificationFordtSexCopy.DataType = typeof(string);
                    dtColumnDateTimeLastModificationFordtSexCopy.ColumnName = "DateTimeLastModification";
                    dtSexCopy.Columns.Add(dtColumnDateTimeLastModificationFordtSexCopy);

                    DataColumn dtColumnUserCreationIdFordtSexCopy = new DataColumn();
                    dtColumnUserCreationIdFordtSexCopy.DataType = typeof(string);
                    dtColumnUserCreationIdFordtSexCopy.ColumnName = "UserCreationId";
                    dtSexCopy.Columns.Add(dtColumnUserCreationIdFordtSexCopy);

                    DataColumn dtColumnUserLastModificationIdFordtSexCopy = new DataColumn();
                    dtColumnUserLastModificationIdFordtSexCopy.DataType = typeof(string);
                    dtColumnUserLastModificationIdFordtSexCopy.ColumnName = "UserLastModificationId";
                    dtSexCopy.Columns.Add(dtColumnUserLastModificationIdFordtSexCopy);

                    DataColumn dtColumnNameFordtSexCopy = new DataColumn();
                    dtColumnNameFordtSexCopy.DataType = typeof(string);
                    dtColumnNameFordtSexCopy.ColumnName = "Name";
                    dtSexCopy.Columns.Add(dtColumnNameFordtSexCopy);

                    
                #endregion

                dtSex = new SexModel().SelectAllToDataTable();

                foreach (DataRow DataRow in dtSex.Rows)
                {
                    dtSexCopy.Rows.Add(DataRow.ItemArray);
                }

                var Sheet = Book.Worksheets.Add(dtSexCopy);

                Sheet.ColumnsUsed().AdjustToContents();

                Book.SaveAs($@"wwwroot/ExcelFiles/Sexing/Sex/Sex_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.xlsx");
            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                DataSet dsSex = new DataSet();

                foreach (string RowChecked in RowsChecked)
                {
                    //We define another DataTable dtSexCopy to avoid issue related to DateTime conversion
                    DataTable dtSexCopy = new DataTable();
                    dtSexCopy.TableName = "Sex";

                    #region Define columns for dtSexCopy
                    DataColumn dtColumnSexIdFordtSexCopy = new DataColumn();
                    dtColumnSexIdFordtSexCopy.DataType = typeof(string);
                    dtColumnSexIdFordtSexCopy.ColumnName = "SexId";
                    dtSexCopy.Columns.Add(dtColumnSexIdFordtSexCopy);

                    DataColumn dtColumnActiveFordtSexCopy = new DataColumn();
                    dtColumnActiveFordtSexCopy.DataType = typeof(string);
                    dtColumnActiveFordtSexCopy.ColumnName = "Active";
                    dtSexCopy.Columns.Add(dtColumnActiveFordtSexCopy);

                    DataColumn dtColumnDateTimeCreationFordtSexCopy = new DataColumn();
                    dtColumnDateTimeCreationFordtSexCopy.DataType = typeof(string);
                    dtColumnDateTimeCreationFordtSexCopy.ColumnName = "DateTimeCreation";
                    dtSexCopy.Columns.Add(dtColumnDateTimeCreationFordtSexCopy);

                    DataColumn dtColumnDateTimeLastModificationFordtSexCopy = new DataColumn();
                    dtColumnDateTimeLastModificationFordtSexCopy.DataType = typeof(string);
                    dtColumnDateTimeLastModificationFordtSexCopy.ColumnName = "DateTimeLastModification";
                    dtSexCopy.Columns.Add(dtColumnDateTimeLastModificationFordtSexCopy);

                    DataColumn dtColumnUserCreationIdFordtSexCopy = new DataColumn();
                    dtColumnUserCreationIdFordtSexCopy.DataType = typeof(string);
                    dtColumnUserCreationIdFordtSexCopy.ColumnName = "UserCreationId";
                    dtSexCopy.Columns.Add(dtColumnUserCreationIdFordtSexCopy);

                    DataColumn dtColumnUserLastModificationIdFordtSexCopy = new DataColumn();
                    dtColumnUserLastModificationIdFordtSexCopy.DataType = typeof(string);
                    dtColumnUserLastModificationIdFordtSexCopy.ColumnName = "UserLastModificationId";
                    dtSexCopy.Columns.Add(dtColumnUserLastModificationIdFordtSexCopy);

                    DataColumn dtColumnNameFordtSexCopy = new DataColumn();
                    dtColumnNameFordtSexCopy.DataType = typeof(string);
                    dtColumnNameFordtSexCopy.ColumnName = "Name";
                    dtSexCopy.Columns.Add(dtColumnNameFordtSexCopy);

                    
                    #endregion

                    dsSex.Tables.Add(dtSexCopy);

                    for (int i = 0; i < dsSex.Tables.Count; i++)
                    {
                        dtSexCopy = new SexModel().Select1BySexIdToDataTable(Convert.ToInt32(RowChecked));

                        foreach (DataRow DataRow in dtSexCopy.Rows)
                        {
                            dsSex.Tables[0].Rows.Add(DataRow.ItemArray);
                        }
                    }
                    
                }

                for (int i = 0; i < dsSex.Tables.Count; i++)
                {
                    var Sheet = Book.Worksheets.Add(dsSex.Tables[i]);
                    Sheet.ColumnsUsed().AdjustToContents();
                }

                Book.SaveAs($@"wwwroot/ExcelFiles/Sexing/Sex/Sex_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.xlsx");
            }

            return Now;
        }

        public DateTime ExportAsCSV(Ajax Ajax, string ExportationType)
        {
            DateTime Now = DateTime.Now;
            List<SexModel> lstSexModel = new List<SexModel> { };

            if (ExportationType == "All")
            {
                lstSexModel = new SexModel().SelectAllToList();

            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {
                    SexModel SexModel = new SexModel().Select1BySexIdToModel(Convert.ToInt32(RowChecked));
                    lstSexModel.Add(SexModel);
                }
            }

            using (var Writer = new StreamWriter($@"wwwroot/CSVFiles/Sexing/Sex/Sex_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.csv"))
            using (var CsvWriter = new CsvWriter(Writer, CultureInfo.InvariantCulture))
            {
                CsvWriter.WriteRecords(lstSexModel);
            }

            return Now;
        }
        #endregion
    }
}