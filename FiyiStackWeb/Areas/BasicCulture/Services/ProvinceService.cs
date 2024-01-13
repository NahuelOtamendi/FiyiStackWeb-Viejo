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

//Last modification on: 21/02/2023 17:51:29

namespace FiyiStackWeb.Areas.BasicCulture.Services
{
    /// <summary>
    /// Stack:             4<br/>
    /// Name:              C# Service. <br/>
    /// Function:          Allow you to separate data contract stored in C# model from business with your clients. <br/>
    /// Also, allow dependency injection inside controllers/web apis<br/>
    /// Last modification: 21/02/2023 17:51:29
    /// </summary>
    public partial class ProvinceService : IProvince
    {
        private readonly IHttpContextAccessor _IHttpContextAccessor;

        public ProvinceService(IHttpContextAccessor IHttpContextAccessor)
        {
            _IHttpContextAccessor = IHttpContextAccessor;
        }

        #region Queries
        public ProvinceModel Select1ByProvinceIdToModel(int ProvinceId)
        {
            return new ProvinceModel().Select1ByProvinceIdToModel(ProvinceId);
        }

        public List<ProvinceModel> SelectAllToList()
        {
            return new ProvinceModel().SelectAllToList();
        }

        public provinceSelectAllPaged SelectAllPagedToModel(provinceSelectAllPaged provinceSelectAllPaged)
        {
            return new ProvinceModel().SelectAllPagedToModel(provinceSelectAllPaged);
        } 
        #endregion

        #region Non-Queries
        public int Insert(ProvinceModel ProvinceModel)
        {
            return new ProvinceModel().Insert(ProvinceModel);
        }

        public int UpdateByProvinceId(ProvinceModel ProvinceModel)
        {
            return new ProvinceModel().UpdateByProvinceId(ProvinceModel);
        }

        public int DeleteByProvinceId(int ProvinceId)
        {
            return new ProvinceModel().DeleteByProvinceId(ProvinceId);
        }

        public void DeleteManyOrAll(Ajax Ajax, string DeleteType)
        {
            if (DeleteType == "All")
            {
                ProvinceModel ProvinceModel = new ProvinceModel();
                ProvinceModel.DeleteAll();
            }
            else
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                for (int i = 0; i < RowsChecked.Length; i++)
                {
                    ProvinceModel ProvinceModel = new ProvinceModel().Select1ByProvinceIdToModel(Convert.ToInt32(RowsChecked[i]));
                    ProvinceModel.DeleteByProvinceId(ProvinceModel.ProvinceId);
                }
            }
        }

        public int CopyByProvinceId(int ProvinceId)
        {
            ProvinceModel ProvinceModel = new ProvinceModel().Select1ByProvinceIdToModel(ProvinceId);
            int NewEnteredId = new ProvinceModel().Insert(ProvinceModel);

            return NewEnteredId;
        }

        public int[] CopyManyOrAll(Ajax Ajax, string CopyType)
        {
            if (CopyType == "All")
            {
                List<ProvinceModel> lstProvinceModel = new List<ProvinceModel> { };
                lstProvinceModel = new ProvinceModel().SelectAllToList();

                int[] NewEnteredIds = new int[lstProvinceModel.Count];

                for (int i = 0; i < lstProvinceModel.Count; i++)
                {
                    NewEnteredIds[i] = lstProvinceModel[i].Insert();
                }

                return NewEnteredIds;
            }
            else
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');
                int[] NewEnteredIds = new int[RowsChecked.Length];

                for (int i = 0; i < RowsChecked.Length; i++)
                {
                    ProvinceModel ProvinceModel = new ProvinceModel().Select1ByProvinceIdToModel(Convert.ToInt32(RowsChecked[i]));
                    NewEnteredIds[i] = ProvinceModel.Insert();
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
            List<ProvinceModel> lstProvinceModel = new List<ProvinceModel> { };

            if (ExportationType == "All")
            {
                lstProvinceModel = new ProvinceModel().SelectAllToList();

            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {
                    ProvinceModel ProvinceModel = new ProvinceModel().Select1ByProvinceIdToModel(Convert.ToInt32(RowChecked));
                    lstProvinceModel.Add(ProvinceModel);
                }
            }

            foreach (ProvinceModel row in lstProvinceModel)
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
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #4c4c4c; font-size: 36px; line-height: 45px; font-weight: 300; letter-spacing: -1px;"">Registers of Province</span>
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
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">ProvinceId&nbsp;&nbsp;&nbsp;</span>
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
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">GeographicalCoordinates&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">Code&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">CountryId&nbsp;&nbsp;&nbsp;</span>
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
").SaveAs($@"wwwroot/PDFFiles/BasicCulture/Province/Province_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.pdf");

            return Now;
        }

        public DateTime ExportAsExcel(Ajax Ajax, string ExportationType)
        {
            DateTime Now = DateTime.Now;

            using var Book = new XLWorkbook();

            if (ExportationType == "All")
            {
                DataTable dtProvince = new DataTable();
                dtProvince.TableName = "Province";

                //We define another DataTable dtProvinceCopy to avoid issue related to DateTime conversion
                DataTable dtProvinceCopy = new DataTable();
                dtProvinceCopy.TableName = "Province";

                #region Define columns for dtProvinceCopy
                DataColumn dtColumnProvinceIdFordtProvinceCopy = new DataColumn();
                    dtColumnProvinceIdFordtProvinceCopy.DataType = typeof(string);
                    dtColumnProvinceIdFordtProvinceCopy.ColumnName = "ProvinceId";
                    dtProvinceCopy.Columns.Add(dtColumnProvinceIdFordtProvinceCopy);

                    DataColumn dtColumnActiveFordtProvinceCopy = new DataColumn();
                    dtColumnActiveFordtProvinceCopy.DataType = typeof(string);
                    dtColumnActiveFordtProvinceCopy.ColumnName = "Active";
                    dtProvinceCopy.Columns.Add(dtColumnActiveFordtProvinceCopy);

                    DataColumn dtColumnDateTimeCreationFordtProvinceCopy = new DataColumn();
                    dtColumnDateTimeCreationFordtProvinceCopy.DataType = typeof(string);
                    dtColumnDateTimeCreationFordtProvinceCopy.ColumnName = "DateTimeCreation";
                    dtProvinceCopy.Columns.Add(dtColumnDateTimeCreationFordtProvinceCopy);

                    DataColumn dtColumnDateTimeLastModificationFordtProvinceCopy = new DataColumn();
                    dtColumnDateTimeLastModificationFordtProvinceCopy.DataType = typeof(string);
                    dtColumnDateTimeLastModificationFordtProvinceCopy.ColumnName = "DateTimeLastModification";
                    dtProvinceCopy.Columns.Add(dtColumnDateTimeLastModificationFordtProvinceCopy);

                    DataColumn dtColumnUserCreationIdFordtProvinceCopy = new DataColumn();
                    dtColumnUserCreationIdFordtProvinceCopy.DataType = typeof(string);
                    dtColumnUserCreationIdFordtProvinceCopy.ColumnName = "UserCreationId";
                    dtProvinceCopy.Columns.Add(dtColumnUserCreationIdFordtProvinceCopy);

                    DataColumn dtColumnUserLastModificationIdFordtProvinceCopy = new DataColumn();
                    dtColumnUserLastModificationIdFordtProvinceCopy.DataType = typeof(string);
                    dtColumnUserLastModificationIdFordtProvinceCopy.ColumnName = "UserLastModificationId";
                    dtProvinceCopy.Columns.Add(dtColumnUserLastModificationIdFordtProvinceCopy);

                    DataColumn dtColumnNameFordtProvinceCopy = new DataColumn();
                    dtColumnNameFordtProvinceCopy.DataType = typeof(string);
                    dtColumnNameFordtProvinceCopy.ColumnName = "Name";
                    dtProvinceCopy.Columns.Add(dtColumnNameFordtProvinceCopy);

                    DataColumn dtColumnGeographicalCoordinatesFordtProvinceCopy = new DataColumn();
                    dtColumnGeographicalCoordinatesFordtProvinceCopy.DataType = typeof(string);
                    dtColumnGeographicalCoordinatesFordtProvinceCopy.ColumnName = "GeographicalCoordinates";
                    dtProvinceCopy.Columns.Add(dtColumnGeographicalCoordinatesFordtProvinceCopy);

                    DataColumn dtColumnCodeFordtProvinceCopy = new DataColumn();
                    dtColumnCodeFordtProvinceCopy.DataType = typeof(string);
                    dtColumnCodeFordtProvinceCopy.ColumnName = "Code";
                    dtProvinceCopy.Columns.Add(dtColumnCodeFordtProvinceCopy);

                    DataColumn dtColumnCountryIdFordtProvinceCopy = new DataColumn();
                    dtColumnCountryIdFordtProvinceCopy.DataType = typeof(string);
                    dtColumnCountryIdFordtProvinceCopy.ColumnName = "CountryId";
                    dtProvinceCopy.Columns.Add(dtColumnCountryIdFordtProvinceCopy);

                    
                #endregion

                dtProvince = new ProvinceModel().SelectAllToDataTable();

                foreach (DataRow DataRow in dtProvince.Rows)
                {
                    dtProvinceCopy.Rows.Add(DataRow.ItemArray);
                }

                var Sheet = Book.Worksheets.Add(dtProvinceCopy);

                Sheet.ColumnsUsed().AdjustToContents();

                Book.SaveAs($@"wwwroot/ExcelFiles/Provinceing/Province/Province_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.xlsx");
            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                DataSet dsProvince = new DataSet();

                foreach (string RowChecked in RowsChecked)
                {
                    //We define another DataTable dtProvinceCopy to avoid issue related to DateTime conversion
                    DataTable dtProvinceCopy = new DataTable();
                    dtProvinceCopy.TableName = "Province";

                    #region Define columns for dtProvinceCopy
                    DataColumn dtColumnProvinceIdFordtProvinceCopy = new DataColumn();
                    dtColumnProvinceIdFordtProvinceCopy.DataType = typeof(string);
                    dtColumnProvinceIdFordtProvinceCopy.ColumnName = "ProvinceId";
                    dtProvinceCopy.Columns.Add(dtColumnProvinceIdFordtProvinceCopy);

                    DataColumn dtColumnActiveFordtProvinceCopy = new DataColumn();
                    dtColumnActiveFordtProvinceCopy.DataType = typeof(string);
                    dtColumnActiveFordtProvinceCopy.ColumnName = "Active";
                    dtProvinceCopy.Columns.Add(dtColumnActiveFordtProvinceCopy);

                    DataColumn dtColumnDateTimeCreationFordtProvinceCopy = new DataColumn();
                    dtColumnDateTimeCreationFordtProvinceCopy.DataType = typeof(string);
                    dtColumnDateTimeCreationFordtProvinceCopy.ColumnName = "DateTimeCreation";
                    dtProvinceCopy.Columns.Add(dtColumnDateTimeCreationFordtProvinceCopy);

                    DataColumn dtColumnDateTimeLastModificationFordtProvinceCopy = new DataColumn();
                    dtColumnDateTimeLastModificationFordtProvinceCopy.DataType = typeof(string);
                    dtColumnDateTimeLastModificationFordtProvinceCopy.ColumnName = "DateTimeLastModification";
                    dtProvinceCopy.Columns.Add(dtColumnDateTimeLastModificationFordtProvinceCopy);

                    DataColumn dtColumnUserCreationIdFordtProvinceCopy = new DataColumn();
                    dtColumnUserCreationIdFordtProvinceCopy.DataType = typeof(string);
                    dtColumnUserCreationIdFordtProvinceCopy.ColumnName = "UserCreationId";
                    dtProvinceCopy.Columns.Add(dtColumnUserCreationIdFordtProvinceCopy);

                    DataColumn dtColumnUserLastModificationIdFordtProvinceCopy = new DataColumn();
                    dtColumnUserLastModificationIdFordtProvinceCopy.DataType = typeof(string);
                    dtColumnUserLastModificationIdFordtProvinceCopy.ColumnName = "UserLastModificationId";
                    dtProvinceCopy.Columns.Add(dtColumnUserLastModificationIdFordtProvinceCopy);

                    DataColumn dtColumnNameFordtProvinceCopy = new DataColumn();
                    dtColumnNameFordtProvinceCopy.DataType = typeof(string);
                    dtColumnNameFordtProvinceCopy.ColumnName = "Name";
                    dtProvinceCopy.Columns.Add(dtColumnNameFordtProvinceCopy);

                    DataColumn dtColumnGeographicalCoordinatesFordtProvinceCopy = new DataColumn();
                    dtColumnGeographicalCoordinatesFordtProvinceCopy.DataType = typeof(string);
                    dtColumnGeographicalCoordinatesFordtProvinceCopy.ColumnName = "GeographicalCoordinates";
                    dtProvinceCopy.Columns.Add(dtColumnGeographicalCoordinatesFordtProvinceCopy);

                    DataColumn dtColumnCodeFordtProvinceCopy = new DataColumn();
                    dtColumnCodeFordtProvinceCopy.DataType = typeof(string);
                    dtColumnCodeFordtProvinceCopy.ColumnName = "Code";
                    dtProvinceCopy.Columns.Add(dtColumnCodeFordtProvinceCopy);

                    DataColumn dtColumnCountryIdFordtProvinceCopy = new DataColumn();
                    dtColumnCountryIdFordtProvinceCopy.DataType = typeof(string);
                    dtColumnCountryIdFordtProvinceCopy.ColumnName = "CountryId";
                    dtProvinceCopy.Columns.Add(dtColumnCountryIdFordtProvinceCopy);

                    
                    #endregion

                    dsProvince.Tables.Add(dtProvinceCopy);

                    for (int i = 0; i < dsProvince.Tables.Count; i++)
                    {
                        dtProvinceCopy = new ProvinceModel().Select1ByProvinceIdToDataTable(Convert.ToInt32(RowChecked));

                        foreach (DataRow DataRow in dtProvinceCopy.Rows)
                        {
                            dsProvince.Tables[0].Rows.Add(DataRow.ItemArray);
                        }
                    }
                    
                }

                for (int i = 0; i < dsProvince.Tables.Count; i++)
                {
                    var Sheet = Book.Worksheets.Add(dsProvince.Tables[i]);
                    Sheet.ColumnsUsed().AdjustToContents();
                }

                Book.SaveAs($@"wwwroot/ExcelFiles/Provinceing/Province/Province_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.xlsx");
            }

            return Now;
        }

        public DateTime ExportAsCSV(Ajax Ajax, string ExportationType)
        {
            DateTime Now = DateTime.Now;
            List<ProvinceModel> lstProvinceModel = new List<ProvinceModel> { };

            if (ExportationType == "All")
            {
                lstProvinceModel = new ProvinceModel().SelectAllToList();

            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {
                    ProvinceModel ProvinceModel = new ProvinceModel().Select1ByProvinceIdToModel(Convert.ToInt32(RowChecked));
                    lstProvinceModel.Add(ProvinceModel);
                }
            }

            using (var Writer = new StreamWriter($@"wwwroot/CSVFiles/Provinceing/Province/Province_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.csv"))
            using (var CsvWriter = new CsvWriter(Writer, CultureInfo.InvariantCulture))
            {
                CsvWriter.WriteRecords(lstProvinceModel);
            }

            return Now;
        }
        #endregion
    }
}