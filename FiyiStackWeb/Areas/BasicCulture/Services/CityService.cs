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

//Last modification on: 21/02/2023 17:42:15

namespace FiyiStackWeb.Areas.BasicCulture.Services
{
    /// <summary>
    /// Stack:             4<br/>
    /// Name:              C# Service. <br/>
    /// Function:          Allow you to separate data contract stored in C# model from business with your clients. <br/>
    /// Also, allow dependency injection inside controllers/web apis<br/>
    /// Last modification: 21/02/2023 17:42:15
    /// </summary>
    public partial class CityService : ICity
    {
        private readonly IHttpContextAccessor _IHttpContextAccessor;

        public CityService(IHttpContextAccessor IHttpContextAccessor)
        {
            _IHttpContextAccessor = IHttpContextAccessor;
        }

        #region Queries
        public CityModel Select1ByCityIdToModel(int CityId)
        {
            return new CityModel().Select1ByCityIdToModel(CityId);
        }

        public List<CityModel> SelectAllToList()
        {
            return new CityModel().SelectAllToList();
        }

        public citySelectAllPaged SelectAllPagedToModel(citySelectAllPaged citySelectAllPaged)
        {
            return new CityModel().SelectAllPagedToModel(citySelectAllPaged);
        } 
        #endregion

        #region Non-Queries
        public int Insert(CityModel CityModel)
        {
            return new CityModel().Insert(CityModel);
        }

        public int UpdateByCityId(CityModel CityModel)
        {
            return new CityModel().UpdateByCityId(CityModel);
        }

        public int DeleteByCityId(int CityId)
        {
            return new CityModel().DeleteByCityId(CityId);
        }

        public void DeleteManyOrAll(Ajax Ajax, string DeleteType)
        {
            if (DeleteType == "All")
            {
                CityModel CityModel = new CityModel();
                CityModel.DeleteAll();
            }
            else
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                for (int i = 0; i < RowsChecked.Length; i++)
                {
                    CityModel CityModel = new CityModel().Select1ByCityIdToModel(Convert.ToInt32(RowsChecked[i]));
                    CityModel.DeleteByCityId(CityModel.CityId);
                }
            }
        }

        public int CopyByCityId(int CityId)
        {
            CityModel CityModel = new CityModel().Select1ByCityIdToModel(CityId);
            int NewEnteredId = new CityModel().Insert(CityModel);

            return NewEnteredId;
        }

        public int[] CopyManyOrAll(Ajax Ajax, string CopyType)
        {
            if (CopyType == "All")
            {
                List<CityModel> lstCityModel = new List<CityModel> { };
                lstCityModel = new CityModel().SelectAllToList();

                int[] NewEnteredIds = new int[lstCityModel.Count];

                for (int i = 0; i < lstCityModel.Count; i++)
                {
                    NewEnteredIds[i] = lstCityModel[i].Insert();
                }

                return NewEnteredIds;
            }
            else
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');
                int[] NewEnteredIds = new int[RowsChecked.Length];

                for (int i = 0; i < RowsChecked.Length; i++)
                {
                    CityModel CityModel = new CityModel().Select1ByCityIdToModel(Convert.ToInt32(RowsChecked[i]));
                    NewEnteredIds[i] = CityModel.Insert();
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
            List<CityModel> lstCityModel = new List<CityModel> { };

            if (ExportationType == "All")
            {
                lstCityModel = new CityModel().SelectAllToList();

            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {
                    CityModel CityModel = new CityModel().Select1ByCityIdToModel(Convert.ToInt32(RowChecked));
                    lstCityModel.Add(CityModel);
                }
            }

            foreach (CityModel row in lstCityModel)
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
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #4c4c4c; font-size: 36px; line-height: 45px; font-weight: 300; letter-spacing: -1px;"">Registers of City</span>
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
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">CityId&nbsp;&nbsp;&nbsp;</span>
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
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">ProvinceId&nbsp;&nbsp;&nbsp;</span>
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
").SaveAs($@"wwwroot/PDFFiles/BasicCulture/City/City_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.pdf");

            return Now;
        }

        public DateTime ExportAsExcel(Ajax Ajax, string ExportationType)
        {
            DateTime Now = DateTime.Now;

            using var Book = new XLWorkbook();

            if (ExportationType == "All")
            {
                DataTable dtCity = new DataTable();
                dtCity.TableName = "City";

                //We define another DataTable dtCityCopy to avoid issue related to DateTime conversion
                DataTable dtCityCopy = new DataTable();
                dtCityCopy.TableName = "City";

                #region Define columns for dtCityCopy
                DataColumn dtColumnCityIdFordtCityCopy = new DataColumn();
                    dtColumnCityIdFordtCityCopy.DataType = typeof(string);
                    dtColumnCityIdFordtCityCopy.ColumnName = "CityId";
                    dtCityCopy.Columns.Add(dtColumnCityIdFordtCityCopy);

                    DataColumn dtColumnActiveFordtCityCopy = new DataColumn();
                    dtColumnActiveFordtCityCopy.DataType = typeof(string);
                    dtColumnActiveFordtCityCopy.ColumnName = "Active";
                    dtCityCopy.Columns.Add(dtColumnActiveFordtCityCopy);

                    DataColumn dtColumnDateTimeCreationFordtCityCopy = new DataColumn();
                    dtColumnDateTimeCreationFordtCityCopy.DataType = typeof(string);
                    dtColumnDateTimeCreationFordtCityCopy.ColumnName = "DateTimeCreation";
                    dtCityCopy.Columns.Add(dtColumnDateTimeCreationFordtCityCopy);

                    DataColumn dtColumnDateTimeLastModificationFordtCityCopy = new DataColumn();
                    dtColumnDateTimeLastModificationFordtCityCopy.DataType = typeof(string);
                    dtColumnDateTimeLastModificationFordtCityCopy.ColumnName = "DateTimeLastModification";
                    dtCityCopy.Columns.Add(dtColumnDateTimeLastModificationFordtCityCopy);

                    DataColumn dtColumnUserCreationIdFordtCityCopy = new DataColumn();
                    dtColumnUserCreationIdFordtCityCopy.DataType = typeof(string);
                    dtColumnUserCreationIdFordtCityCopy.ColumnName = "UserCreationId";
                    dtCityCopy.Columns.Add(dtColumnUserCreationIdFordtCityCopy);

                    DataColumn dtColumnUserLastModificationIdFordtCityCopy = new DataColumn();
                    dtColumnUserLastModificationIdFordtCityCopy.DataType = typeof(string);
                    dtColumnUserLastModificationIdFordtCityCopy.ColumnName = "UserLastModificationId";
                    dtCityCopy.Columns.Add(dtColumnUserLastModificationIdFordtCityCopy);

                    DataColumn dtColumnNameFordtCityCopy = new DataColumn();
                    dtColumnNameFordtCityCopy.DataType = typeof(string);
                    dtColumnNameFordtCityCopy.ColumnName = "Name";
                    dtCityCopy.Columns.Add(dtColumnNameFordtCityCopy);

                    DataColumn dtColumnGeographicalCoordinatesFordtCityCopy = new DataColumn();
                    dtColumnGeographicalCoordinatesFordtCityCopy.DataType = typeof(string);
                    dtColumnGeographicalCoordinatesFordtCityCopy.ColumnName = "GeographicalCoordinates";
                    dtCityCopy.Columns.Add(dtColumnGeographicalCoordinatesFordtCityCopy);

                    DataColumn dtColumnCodeFordtCityCopy = new DataColumn();
                    dtColumnCodeFordtCityCopy.DataType = typeof(string);
                    dtColumnCodeFordtCityCopy.ColumnName = "Code";
                    dtCityCopy.Columns.Add(dtColumnCodeFordtCityCopy);

                    DataColumn dtColumnProvinceIdFordtCityCopy = new DataColumn();
                    dtColumnProvinceIdFordtCityCopy.DataType = typeof(string);
                    dtColumnProvinceIdFordtCityCopy.ColumnName = "ProvinceId";
                    dtCityCopy.Columns.Add(dtColumnProvinceIdFordtCityCopy);

                    
                #endregion

                dtCity = new CityModel().SelectAllToDataTable();

                foreach (DataRow DataRow in dtCity.Rows)
                {
                    dtCityCopy.Rows.Add(DataRow.ItemArray);
                }

                var Sheet = Book.Worksheets.Add(dtCityCopy);

                Sheet.ColumnsUsed().AdjustToContents();

                Book.SaveAs($@"wwwroot/ExcelFiles/Citying/City/City_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.xlsx");
            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                DataSet dsCity = new DataSet();

                foreach (string RowChecked in RowsChecked)
                {
                    //We define another DataTable dtCityCopy to avoid issue related to DateTime conversion
                    DataTable dtCityCopy = new DataTable();
                    dtCityCopy.TableName = "City";

                    #region Define columns for dtCityCopy
                    DataColumn dtColumnCityIdFordtCityCopy = new DataColumn();
                    dtColumnCityIdFordtCityCopy.DataType = typeof(string);
                    dtColumnCityIdFordtCityCopy.ColumnName = "CityId";
                    dtCityCopy.Columns.Add(dtColumnCityIdFordtCityCopy);

                    DataColumn dtColumnActiveFordtCityCopy = new DataColumn();
                    dtColumnActiveFordtCityCopy.DataType = typeof(string);
                    dtColumnActiveFordtCityCopy.ColumnName = "Active";
                    dtCityCopy.Columns.Add(dtColumnActiveFordtCityCopy);

                    DataColumn dtColumnDateTimeCreationFordtCityCopy = new DataColumn();
                    dtColumnDateTimeCreationFordtCityCopy.DataType = typeof(string);
                    dtColumnDateTimeCreationFordtCityCopy.ColumnName = "DateTimeCreation";
                    dtCityCopy.Columns.Add(dtColumnDateTimeCreationFordtCityCopy);

                    DataColumn dtColumnDateTimeLastModificationFordtCityCopy = new DataColumn();
                    dtColumnDateTimeLastModificationFordtCityCopy.DataType = typeof(string);
                    dtColumnDateTimeLastModificationFordtCityCopy.ColumnName = "DateTimeLastModification";
                    dtCityCopy.Columns.Add(dtColumnDateTimeLastModificationFordtCityCopy);

                    DataColumn dtColumnUserCreationIdFordtCityCopy = new DataColumn();
                    dtColumnUserCreationIdFordtCityCopy.DataType = typeof(string);
                    dtColumnUserCreationIdFordtCityCopy.ColumnName = "UserCreationId";
                    dtCityCopy.Columns.Add(dtColumnUserCreationIdFordtCityCopy);

                    DataColumn dtColumnUserLastModificationIdFordtCityCopy = new DataColumn();
                    dtColumnUserLastModificationIdFordtCityCopy.DataType = typeof(string);
                    dtColumnUserLastModificationIdFordtCityCopy.ColumnName = "UserLastModificationId";
                    dtCityCopy.Columns.Add(dtColumnUserLastModificationIdFordtCityCopy);

                    DataColumn dtColumnNameFordtCityCopy = new DataColumn();
                    dtColumnNameFordtCityCopy.DataType = typeof(string);
                    dtColumnNameFordtCityCopy.ColumnName = "Name";
                    dtCityCopy.Columns.Add(dtColumnNameFordtCityCopy);

                    DataColumn dtColumnGeographicalCoordinatesFordtCityCopy = new DataColumn();
                    dtColumnGeographicalCoordinatesFordtCityCopy.DataType = typeof(string);
                    dtColumnGeographicalCoordinatesFordtCityCopy.ColumnName = "GeographicalCoordinates";
                    dtCityCopy.Columns.Add(dtColumnGeographicalCoordinatesFordtCityCopy);

                    DataColumn dtColumnCodeFordtCityCopy = new DataColumn();
                    dtColumnCodeFordtCityCopy.DataType = typeof(string);
                    dtColumnCodeFordtCityCopy.ColumnName = "Code";
                    dtCityCopy.Columns.Add(dtColumnCodeFordtCityCopy);

                    DataColumn dtColumnProvinceIdFordtCityCopy = new DataColumn();
                    dtColumnProvinceIdFordtCityCopy.DataType = typeof(string);
                    dtColumnProvinceIdFordtCityCopy.ColumnName = "ProvinceId";
                    dtCityCopy.Columns.Add(dtColumnProvinceIdFordtCityCopy);

                    
                    #endregion

                    dsCity.Tables.Add(dtCityCopy);

                    for (int i = 0; i < dsCity.Tables.Count; i++)
                    {
                        dtCityCopy = new CityModel().Select1ByCityIdToDataTable(Convert.ToInt32(RowChecked));

                        foreach (DataRow DataRow in dtCityCopy.Rows)
                        {
                            dsCity.Tables[0].Rows.Add(DataRow.ItemArray);
                        }
                    }
                    
                }

                for (int i = 0; i < dsCity.Tables.Count; i++)
                {
                    var Sheet = Book.Worksheets.Add(dsCity.Tables[i]);
                    Sheet.ColumnsUsed().AdjustToContents();
                }

                Book.SaveAs($@"wwwroot/ExcelFiles/Citying/City/City_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.xlsx");
            }

            return Now;
        }

        public DateTime ExportAsCSV(Ajax Ajax, string ExportationType)
        {
            DateTime Now = DateTime.Now;
            List<CityModel> lstCityModel = new List<CityModel> { };

            if (ExportationType == "All")
            {
                lstCityModel = new CityModel().SelectAllToList();

            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {
                    CityModel CityModel = new CityModel().Select1ByCityIdToModel(Convert.ToInt32(RowChecked));
                    lstCityModel.Add(CityModel);
                }
            }

            using (var Writer = new StreamWriter($@"wwwroot/CSVFiles/Citying/City/City_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.csv"))
            using (var CsvWriter = new CsvWriter(Writer, CultureInfo.InvariantCulture))
            {
                CsvWriter.WriteRecords(lstCityModel);
            }

            return Now;
        }
        #endregion
    }
}