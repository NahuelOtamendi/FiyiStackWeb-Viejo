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

//Last modification on: 21/02/2023 17:37:17

namespace FiyiStackWeb.Areas.BasicCore.Services
{
    /// <summary>
    /// Stack:             4<br/>
    /// Name:              C# Service. <br/>
    /// Function:          Allow you to separate data contract stored in C# model from business with your clients. <br/>
    /// Also, allow dependency injection inside controllers/web apis<br/>
    /// Last modification: 21/02/2023 17:37:17
    /// </summary>
    public partial class ParameterService : IParameter
    {
        private readonly IHttpContextAccessor _IHttpContextAccessor;

        public ParameterService(IHttpContextAccessor IHttpContextAccessor)
        {
            _IHttpContextAccessor = IHttpContextAccessor;
        }

        #region Queries
        public ParameterModel Select1ByParameterIdToModel(int ParameterId)
        {
            return new ParameterModel().Select1ByParameterIdToModel(ParameterId);
        }

        public List<ParameterModel> SelectAllToList()
        {
            return new ParameterModel().SelectAllToList();
        }

        public parameterSelectAllPaged SelectAllPagedToModel(parameterSelectAllPaged parameterSelectAllPaged)
        {
            return new ParameterModel().SelectAllPagedToModel(parameterSelectAllPaged);
        } 
        #endregion

        #region Non-Queries
        public int Insert(ParameterModel ParameterModel)
        {
            return new ParameterModel().Insert(ParameterModel);
        }

        public int UpdateByParameterId(ParameterModel ParameterModel)
        {
            return new ParameterModel().UpdateByParameterId(ParameterModel);
        }

        public int DeleteByParameterId(int ParameterId)
        {
            return new ParameterModel().DeleteByParameterId(ParameterId);
        }

        public void DeleteManyOrAll(Ajax Ajax, string DeleteType)
        {
            if (DeleteType == "All")
            {
                ParameterModel ParameterModel = new ParameterModel();
                ParameterModel.DeleteAll();
            }
            else
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                for (int i = 0; i < RowsChecked.Length; i++)
                {
                    ParameterModel ParameterModel = new ParameterModel().Select1ByParameterIdToModel(Convert.ToInt32(RowsChecked[i]));
                    ParameterModel.DeleteByParameterId(ParameterModel.ParameterId);
                }
            }
        }

        public int CopyByParameterId(int ParameterId)
        {
            ParameterModel ParameterModel = new ParameterModel().Select1ByParameterIdToModel(ParameterId);
            int NewEnteredId = new ParameterModel().Insert(ParameterModel);

            return NewEnteredId;
        }

        public int[] CopyManyOrAll(Ajax Ajax, string CopyType)
        {
            if (CopyType == "All")
            {
                List<ParameterModel> lstParameterModel = new List<ParameterModel> { };
                lstParameterModel = new ParameterModel().SelectAllToList();

                int[] NewEnteredIds = new int[lstParameterModel.Count];

                for (int i = 0; i < lstParameterModel.Count; i++)
                {
                    NewEnteredIds[i] = lstParameterModel[i].Insert();
                }

                return NewEnteredIds;
            }
            else
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');
                int[] NewEnteredIds = new int[RowsChecked.Length];

                for (int i = 0; i < RowsChecked.Length; i++)
                {
                    ParameterModel ParameterModel = new ParameterModel().Select1ByParameterIdToModel(Convert.ToInt32(RowsChecked[i]));
                    NewEnteredIds[i] = ParameterModel.Insert();
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
            List<ParameterModel> lstParameterModel = new List<ParameterModel> { };

            if (ExportationType == "All")
            {
                lstParameterModel = new ParameterModel().SelectAllToList();

            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {
                    ParameterModel ParameterModel = new ParameterModel().Select1ByParameterIdToModel(Convert.ToInt32(RowChecked));
                    lstParameterModel.Add(ParameterModel);
                }
            }

            foreach (ParameterModel row in lstParameterModel)
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
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #4c4c4c; font-size: 36px; line-height: 45px; font-weight: 300; letter-spacing: -1px;"">Registers of Parameter</span>
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
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">ParameterId&nbsp;&nbsp;&nbsp;</span>
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
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">Value&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">IsPrivate&nbsp;&nbsp;&nbsp;</span>
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
").SaveAs($@"wwwroot/PDFFiles/BasicCore/Parameter/Parameter_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.pdf");

            return Now;
        }

        public DateTime ExportAsExcel(Ajax Ajax, string ExportationType)
        {
            DateTime Now = DateTime.Now;

            using var Book = new XLWorkbook();

            if (ExportationType == "All")
            {
                DataTable dtParameter = new DataTable();
                dtParameter.TableName = "Parameter";

                //We define another DataTable dtParameterCopy to avoid issue related to DateTime conversion
                DataTable dtParameterCopy = new DataTable();
                dtParameterCopy.TableName = "Parameter";

                #region Define columns for dtParameterCopy
                DataColumn dtColumnParameterIdFordtParameterCopy = new DataColumn();
                    dtColumnParameterIdFordtParameterCopy.DataType = typeof(string);
                    dtColumnParameterIdFordtParameterCopy.ColumnName = "ParameterId";
                    dtParameterCopy.Columns.Add(dtColumnParameterIdFordtParameterCopy);

                    DataColumn dtColumnActiveFordtParameterCopy = new DataColumn();
                    dtColumnActiveFordtParameterCopy.DataType = typeof(string);
                    dtColumnActiveFordtParameterCopy.ColumnName = "Active";
                    dtParameterCopy.Columns.Add(dtColumnActiveFordtParameterCopy);

                    DataColumn dtColumnDateTimeCreationFordtParameterCopy = new DataColumn();
                    dtColumnDateTimeCreationFordtParameterCopy.DataType = typeof(string);
                    dtColumnDateTimeCreationFordtParameterCopy.ColumnName = "DateTimeCreation";
                    dtParameterCopy.Columns.Add(dtColumnDateTimeCreationFordtParameterCopy);

                    DataColumn dtColumnDateTimeLastModificationFordtParameterCopy = new DataColumn();
                    dtColumnDateTimeLastModificationFordtParameterCopy.DataType = typeof(string);
                    dtColumnDateTimeLastModificationFordtParameterCopy.ColumnName = "DateTimeLastModification";
                    dtParameterCopy.Columns.Add(dtColumnDateTimeLastModificationFordtParameterCopy);

                    DataColumn dtColumnUserCreationIdFordtParameterCopy = new DataColumn();
                    dtColumnUserCreationIdFordtParameterCopy.DataType = typeof(string);
                    dtColumnUserCreationIdFordtParameterCopy.ColumnName = "UserCreationId";
                    dtParameterCopy.Columns.Add(dtColumnUserCreationIdFordtParameterCopy);

                    DataColumn dtColumnUserLastModificationIdFordtParameterCopy = new DataColumn();
                    dtColumnUserLastModificationIdFordtParameterCopy.DataType = typeof(string);
                    dtColumnUserLastModificationIdFordtParameterCopy.ColumnName = "UserLastModificationId";
                    dtParameterCopy.Columns.Add(dtColumnUserLastModificationIdFordtParameterCopy);

                    DataColumn dtColumnNameFordtParameterCopy = new DataColumn();
                    dtColumnNameFordtParameterCopy.DataType = typeof(string);
                    dtColumnNameFordtParameterCopy.ColumnName = "Name";
                    dtParameterCopy.Columns.Add(dtColumnNameFordtParameterCopy);

                    DataColumn dtColumnValueFordtParameterCopy = new DataColumn();
                    dtColumnValueFordtParameterCopy.DataType = typeof(string);
                    dtColumnValueFordtParameterCopy.ColumnName = "Value";
                    dtParameterCopy.Columns.Add(dtColumnValueFordtParameterCopy);

                    DataColumn dtColumnIsPrivateFordtParameterCopy = new DataColumn();
                    dtColumnIsPrivateFordtParameterCopy.DataType = typeof(string);
                    dtColumnIsPrivateFordtParameterCopy.ColumnName = "IsPrivate";
                    dtParameterCopy.Columns.Add(dtColumnIsPrivateFordtParameterCopy);

                    
                #endregion

                dtParameter = new ParameterModel().SelectAllToDataTable();

                foreach (DataRow DataRow in dtParameter.Rows)
                {
                    dtParameterCopy.Rows.Add(DataRow.ItemArray);
                }

                var Sheet = Book.Worksheets.Add(dtParameterCopy);

                Sheet.ColumnsUsed().AdjustToContents();

                Book.SaveAs($@"wwwroot/ExcelFiles/Parametering/Parameter/Parameter_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.xlsx");
            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                DataSet dsParameter = new DataSet();

                foreach (string RowChecked in RowsChecked)
                {
                    //We define another DataTable dtParameterCopy to avoid issue related to DateTime conversion
                    DataTable dtParameterCopy = new DataTable();
                    dtParameterCopy.TableName = "Parameter";

                    #region Define columns for dtParameterCopy
                    DataColumn dtColumnParameterIdFordtParameterCopy = new DataColumn();
                    dtColumnParameterIdFordtParameterCopy.DataType = typeof(string);
                    dtColumnParameterIdFordtParameterCopy.ColumnName = "ParameterId";
                    dtParameterCopy.Columns.Add(dtColumnParameterIdFordtParameterCopy);

                    DataColumn dtColumnActiveFordtParameterCopy = new DataColumn();
                    dtColumnActiveFordtParameterCopy.DataType = typeof(string);
                    dtColumnActiveFordtParameterCopy.ColumnName = "Active";
                    dtParameterCopy.Columns.Add(dtColumnActiveFordtParameterCopy);

                    DataColumn dtColumnDateTimeCreationFordtParameterCopy = new DataColumn();
                    dtColumnDateTimeCreationFordtParameterCopy.DataType = typeof(string);
                    dtColumnDateTimeCreationFordtParameterCopy.ColumnName = "DateTimeCreation";
                    dtParameterCopy.Columns.Add(dtColumnDateTimeCreationFordtParameterCopy);

                    DataColumn dtColumnDateTimeLastModificationFordtParameterCopy = new DataColumn();
                    dtColumnDateTimeLastModificationFordtParameterCopy.DataType = typeof(string);
                    dtColumnDateTimeLastModificationFordtParameterCopy.ColumnName = "DateTimeLastModification";
                    dtParameterCopy.Columns.Add(dtColumnDateTimeLastModificationFordtParameterCopy);

                    DataColumn dtColumnUserCreationIdFordtParameterCopy = new DataColumn();
                    dtColumnUserCreationIdFordtParameterCopy.DataType = typeof(string);
                    dtColumnUserCreationIdFordtParameterCopy.ColumnName = "UserCreationId";
                    dtParameterCopy.Columns.Add(dtColumnUserCreationIdFordtParameterCopy);

                    DataColumn dtColumnUserLastModificationIdFordtParameterCopy = new DataColumn();
                    dtColumnUserLastModificationIdFordtParameterCopy.DataType = typeof(string);
                    dtColumnUserLastModificationIdFordtParameterCopy.ColumnName = "UserLastModificationId";
                    dtParameterCopy.Columns.Add(dtColumnUserLastModificationIdFordtParameterCopy);

                    DataColumn dtColumnNameFordtParameterCopy = new DataColumn();
                    dtColumnNameFordtParameterCopy.DataType = typeof(string);
                    dtColumnNameFordtParameterCopy.ColumnName = "Name";
                    dtParameterCopy.Columns.Add(dtColumnNameFordtParameterCopy);

                    DataColumn dtColumnValueFordtParameterCopy = new DataColumn();
                    dtColumnValueFordtParameterCopy.DataType = typeof(string);
                    dtColumnValueFordtParameterCopy.ColumnName = "Value";
                    dtParameterCopy.Columns.Add(dtColumnValueFordtParameterCopy);

                    DataColumn dtColumnIsPrivateFordtParameterCopy = new DataColumn();
                    dtColumnIsPrivateFordtParameterCopy.DataType = typeof(string);
                    dtColumnIsPrivateFordtParameterCopy.ColumnName = "IsPrivate";
                    dtParameterCopy.Columns.Add(dtColumnIsPrivateFordtParameterCopy);

                    
                    #endregion

                    dsParameter.Tables.Add(dtParameterCopy);

                    for (int i = 0; i < dsParameter.Tables.Count; i++)
                    {
                        dtParameterCopy = new ParameterModel().Select1ByParameterIdToDataTable(Convert.ToInt32(RowChecked));

                        foreach (DataRow DataRow in dtParameterCopy.Rows)
                        {
                            dsParameter.Tables[0].Rows.Add(DataRow.ItemArray);
                        }
                    }
                    
                }

                for (int i = 0; i < dsParameter.Tables.Count; i++)
                {
                    var Sheet = Book.Worksheets.Add(dsParameter.Tables[i]);
                    Sheet.ColumnsUsed().AdjustToContents();
                }

                Book.SaveAs($@"wwwroot/ExcelFiles/Parametering/Parameter/Parameter_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.xlsx");
            }

            return Now;
        }

        public DateTime ExportAsCSV(Ajax Ajax, string ExportationType)
        {
            DateTime Now = DateTime.Now;
            List<ParameterModel> lstParameterModel = new List<ParameterModel> { };

            if (ExportationType == "All")
            {
                lstParameterModel = new ParameterModel().SelectAllToList();

            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {
                    ParameterModel ParameterModel = new ParameterModel().Select1ByParameterIdToModel(Convert.ToInt32(RowChecked));
                    lstParameterModel.Add(ParameterModel);
                }
            }

            using (var Writer = new StreamWriter($@"wwwroot/CSVFiles/Parametering/Parameter/Parameter_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.csv"))
            using (var CsvWriter = new CsvWriter(Writer, CultureInfo.InvariantCulture))
            {
                CsvWriter.WriteRecords(lstParameterModel);
            }

            return Now;
        }
        #endregion
    }
}