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

//Last modification on: 21/02/2023 17:45:06

namespace FiyiStackWeb.Areas.BasicCulture.Services
{
    /// <summary>
    /// Stack:             4<br/>
    /// Name:              C# Service. <br/>
    /// Function:          Allow you to separate data contract stored in C# model from business with your clients. <br/>
    /// Also, allow dependency injection inside controllers/web apis<br/>
    /// Last modification: 21/02/2023 17:45:06
    /// </summary>
    public partial class CountryService : ICountry
    {
        private readonly IHttpContextAccessor _IHttpContextAccessor;

        public CountryService(IHttpContextAccessor IHttpContextAccessor)
        {
            _IHttpContextAccessor = IHttpContextAccessor;
        }

        #region Queries
        public CountryModel Select1ByCountryIdToModel(int CountryId)
        {
            return new CountryModel().Select1ByCountryIdToModel(CountryId);
        }

        public List<CountryModel> SelectAllToList()
        {
            return new CountryModel().SelectAllToList();
        }

        public countrySelectAllPaged SelectAllPagedToModel(countrySelectAllPaged countrySelectAllPaged)
        {
            return new CountryModel().SelectAllPagedToModel(countrySelectAllPaged);
        } 
        #endregion

        #region Non-Queries
        public int Insert(CountryModel CountryModel)
        {
            return new CountryModel().Insert(CountryModel);
        }

        public int UpdateByCountryId(CountryModel CountryModel)
        {
            return new CountryModel().UpdateByCountryId(CountryModel);
        }

        public int DeleteByCountryId(int CountryId)
        {
            return new CountryModel().DeleteByCountryId(CountryId);
        }

        public void DeleteManyOrAll(Ajax Ajax, string DeleteType)
        {
            if (DeleteType == "All")
            {
                CountryModel CountryModel = new CountryModel();
                CountryModel.DeleteAll();
            }
            else
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                for (int i = 0; i < RowsChecked.Length; i++)
                {
                    CountryModel CountryModel = new CountryModel().Select1ByCountryIdToModel(Convert.ToInt32(RowsChecked[i]));
                    CountryModel.DeleteByCountryId(CountryModel.CountryId);
                }
            }
        }

        public int CopyByCountryId(int CountryId)
        {
            CountryModel CountryModel = new CountryModel().Select1ByCountryIdToModel(CountryId);
            int NewEnteredId = new CountryModel().Insert(CountryModel);

            return NewEnteredId;
        }

        public int[] CopyManyOrAll(Ajax Ajax, string CopyType)
        {
            if (CopyType == "All")
            {
                List<CountryModel> lstCountryModel = new List<CountryModel> { };
                lstCountryModel = new CountryModel().SelectAllToList();

                int[] NewEnteredIds = new int[lstCountryModel.Count];

                for (int i = 0; i < lstCountryModel.Count; i++)
                {
                    NewEnteredIds[i] = lstCountryModel[i].Insert();
                }

                return NewEnteredIds;
            }
            else
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');
                int[] NewEnteredIds = new int[RowsChecked.Length];

                for (int i = 0; i < RowsChecked.Length; i++)
                {
                    CountryModel CountryModel = new CountryModel().Select1ByCountryIdToModel(Convert.ToInt32(RowsChecked[i]));
                    NewEnteredIds[i] = CountryModel.Insert();
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
            List<CountryModel> lstCountryModel = new List<CountryModel> { };

            if (ExportationType == "All")
            {
                lstCountryModel = new CountryModel().SelectAllToList();

            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {
                    CountryModel CountryModel = new CountryModel().Select1ByCountryIdToModel(Convert.ToInt32(RowChecked));
                    lstCountryModel.Add(CountryModel);
                }
            }

            foreach (CountryModel row in lstCountryModel)
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
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #4c4c4c; font-size: 36px; line-height: 45px; font-weight: 300; letter-spacing: -1px;"">Registers of Country</span>
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
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">CountryId&nbsp;&nbsp;&nbsp;</span>
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
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">PlanetId&nbsp;&nbsp;&nbsp;</span>
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
").SaveAs($@"wwwroot/PDFFiles/BasicCulture/Country/Country_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.pdf");

            return Now;
        }

        public DateTime ExportAsExcel(Ajax Ajax, string ExportationType)
        {
            DateTime Now = DateTime.Now;

            using var Book = new XLWorkbook();

            if (ExportationType == "All")
            {
                DataTable dtCountry = new DataTable();
                dtCountry.TableName = "Country";

                //We define another DataTable dtCountryCopy to avoid issue related to DateTime conversion
                DataTable dtCountryCopy = new DataTable();
                dtCountryCopy.TableName = "Country";

                #region Define columns for dtCountryCopy
                DataColumn dtColumnCountryIdFordtCountryCopy = new DataColumn();
                    dtColumnCountryIdFordtCountryCopy.DataType = typeof(string);
                    dtColumnCountryIdFordtCountryCopy.ColumnName = "CountryId";
                    dtCountryCopy.Columns.Add(dtColumnCountryIdFordtCountryCopy);

                    DataColumn dtColumnActiveFordtCountryCopy = new DataColumn();
                    dtColumnActiveFordtCountryCopy.DataType = typeof(string);
                    dtColumnActiveFordtCountryCopy.ColumnName = "Active";
                    dtCountryCopy.Columns.Add(dtColumnActiveFordtCountryCopy);

                    DataColumn dtColumnDateTimeCreationFordtCountryCopy = new DataColumn();
                    dtColumnDateTimeCreationFordtCountryCopy.DataType = typeof(string);
                    dtColumnDateTimeCreationFordtCountryCopy.ColumnName = "DateTimeCreation";
                    dtCountryCopy.Columns.Add(dtColumnDateTimeCreationFordtCountryCopy);

                    DataColumn dtColumnDateTimeLastModificationFordtCountryCopy = new DataColumn();
                    dtColumnDateTimeLastModificationFordtCountryCopy.DataType = typeof(string);
                    dtColumnDateTimeLastModificationFordtCountryCopy.ColumnName = "DateTimeLastModification";
                    dtCountryCopy.Columns.Add(dtColumnDateTimeLastModificationFordtCountryCopy);

                    DataColumn dtColumnUserCreationIdFordtCountryCopy = new DataColumn();
                    dtColumnUserCreationIdFordtCountryCopy.DataType = typeof(string);
                    dtColumnUserCreationIdFordtCountryCopy.ColumnName = "UserCreationId";
                    dtCountryCopy.Columns.Add(dtColumnUserCreationIdFordtCountryCopy);

                    DataColumn dtColumnUserLastModificationIdFordtCountryCopy = new DataColumn();
                    dtColumnUserLastModificationIdFordtCountryCopy.DataType = typeof(string);
                    dtColumnUserLastModificationIdFordtCountryCopy.ColumnName = "UserLastModificationId";
                    dtCountryCopy.Columns.Add(dtColumnUserLastModificationIdFordtCountryCopy);

                    DataColumn dtColumnNameFordtCountryCopy = new DataColumn();
                    dtColumnNameFordtCountryCopy.DataType = typeof(string);
                    dtColumnNameFordtCountryCopy.ColumnName = "Name";
                    dtCountryCopy.Columns.Add(dtColumnNameFordtCountryCopy);

                    DataColumn dtColumnGeographicalCoordinatesFordtCountryCopy = new DataColumn();
                    dtColumnGeographicalCoordinatesFordtCountryCopy.DataType = typeof(string);
                    dtColumnGeographicalCoordinatesFordtCountryCopy.ColumnName = "GeographicalCoordinates";
                    dtCountryCopy.Columns.Add(dtColumnGeographicalCoordinatesFordtCountryCopy);

                    DataColumn dtColumnCodeFordtCountryCopy = new DataColumn();
                    dtColumnCodeFordtCountryCopy.DataType = typeof(string);
                    dtColumnCodeFordtCountryCopy.ColumnName = "Code";
                    dtCountryCopy.Columns.Add(dtColumnCodeFordtCountryCopy);

                    DataColumn dtColumnPlanetIdFordtCountryCopy = new DataColumn();
                    dtColumnPlanetIdFordtCountryCopy.DataType = typeof(string);
                    dtColumnPlanetIdFordtCountryCopy.ColumnName = "PlanetId";
                    dtCountryCopy.Columns.Add(dtColumnPlanetIdFordtCountryCopy);

                    
                #endregion

                dtCountry = new CountryModel().SelectAllToDataTable();

                foreach (DataRow DataRow in dtCountry.Rows)
                {
                    dtCountryCopy.Rows.Add(DataRow.ItemArray);
                }

                var Sheet = Book.Worksheets.Add(dtCountryCopy);

                Sheet.ColumnsUsed().AdjustToContents();

                Book.SaveAs($@"wwwroot/ExcelFiles/Countrying/Country/Country_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.xlsx");
            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                DataSet dsCountry = new DataSet();

                foreach (string RowChecked in RowsChecked)
                {
                    //We define another DataTable dtCountryCopy to avoid issue related to DateTime conversion
                    DataTable dtCountryCopy = new DataTable();
                    dtCountryCopy.TableName = "Country";

                    #region Define columns for dtCountryCopy
                    DataColumn dtColumnCountryIdFordtCountryCopy = new DataColumn();
                    dtColumnCountryIdFordtCountryCopy.DataType = typeof(string);
                    dtColumnCountryIdFordtCountryCopy.ColumnName = "CountryId";
                    dtCountryCopy.Columns.Add(dtColumnCountryIdFordtCountryCopy);

                    DataColumn dtColumnActiveFordtCountryCopy = new DataColumn();
                    dtColumnActiveFordtCountryCopy.DataType = typeof(string);
                    dtColumnActiveFordtCountryCopy.ColumnName = "Active";
                    dtCountryCopy.Columns.Add(dtColumnActiveFordtCountryCopy);

                    DataColumn dtColumnDateTimeCreationFordtCountryCopy = new DataColumn();
                    dtColumnDateTimeCreationFordtCountryCopy.DataType = typeof(string);
                    dtColumnDateTimeCreationFordtCountryCopy.ColumnName = "DateTimeCreation";
                    dtCountryCopy.Columns.Add(dtColumnDateTimeCreationFordtCountryCopy);

                    DataColumn dtColumnDateTimeLastModificationFordtCountryCopy = new DataColumn();
                    dtColumnDateTimeLastModificationFordtCountryCopy.DataType = typeof(string);
                    dtColumnDateTimeLastModificationFordtCountryCopy.ColumnName = "DateTimeLastModification";
                    dtCountryCopy.Columns.Add(dtColumnDateTimeLastModificationFordtCountryCopy);

                    DataColumn dtColumnUserCreationIdFordtCountryCopy = new DataColumn();
                    dtColumnUserCreationIdFordtCountryCopy.DataType = typeof(string);
                    dtColumnUserCreationIdFordtCountryCopy.ColumnName = "UserCreationId";
                    dtCountryCopy.Columns.Add(dtColumnUserCreationIdFordtCountryCopy);

                    DataColumn dtColumnUserLastModificationIdFordtCountryCopy = new DataColumn();
                    dtColumnUserLastModificationIdFordtCountryCopy.DataType = typeof(string);
                    dtColumnUserLastModificationIdFordtCountryCopy.ColumnName = "UserLastModificationId";
                    dtCountryCopy.Columns.Add(dtColumnUserLastModificationIdFordtCountryCopy);

                    DataColumn dtColumnNameFordtCountryCopy = new DataColumn();
                    dtColumnNameFordtCountryCopy.DataType = typeof(string);
                    dtColumnNameFordtCountryCopy.ColumnName = "Name";
                    dtCountryCopy.Columns.Add(dtColumnNameFordtCountryCopy);

                    DataColumn dtColumnGeographicalCoordinatesFordtCountryCopy = new DataColumn();
                    dtColumnGeographicalCoordinatesFordtCountryCopy.DataType = typeof(string);
                    dtColumnGeographicalCoordinatesFordtCountryCopy.ColumnName = "GeographicalCoordinates";
                    dtCountryCopy.Columns.Add(dtColumnGeographicalCoordinatesFordtCountryCopy);

                    DataColumn dtColumnCodeFordtCountryCopy = new DataColumn();
                    dtColumnCodeFordtCountryCopy.DataType = typeof(string);
                    dtColumnCodeFordtCountryCopy.ColumnName = "Code";
                    dtCountryCopy.Columns.Add(dtColumnCodeFordtCountryCopy);

                    DataColumn dtColumnPlanetIdFordtCountryCopy = new DataColumn();
                    dtColumnPlanetIdFordtCountryCopy.DataType = typeof(string);
                    dtColumnPlanetIdFordtCountryCopy.ColumnName = "PlanetId";
                    dtCountryCopy.Columns.Add(dtColumnPlanetIdFordtCountryCopy);

                    
                    #endregion

                    dsCountry.Tables.Add(dtCountryCopy);

                    for (int i = 0; i < dsCountry.Tables.Count; i++)
                    {
                        dtCountryCopy = new CountryModel().Select1ByCountryIdToDataTable(Convert.ToInt32(RowChecked));

                        foreach (DataRow DataRow in dtCountryCopy.Rows)
                        {
                            dsCountry.Tables[0].Rows.Add(DataRow.ItemArray);
                        }
                    }
                    
                }

                for (int i = 0; i < dsCountry.Tables.Count; i++)
                {
                    var Sheet = Book.Worksheets.Add(dsCountry.Tables[i]);
                    Sheet.ColumnsUsed().AdjustToContents();
                }

                Book.SaveAs($@"wwwroot/ExcelFiles/Countrying/Country/Country_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.xlsx");
            }

            return Now;
        }

        public DateTime ExportAsCSV(Ajax Ajax, string ExportationType)
        {
            DateTime Now = DateTime.Now;
            List<CountryModel> lstCountryModel = new List<CountryModel> { };

            if (ExportationType == "All")
            {
                lstCountryModel = new CountryModel().SelectAllToList();

            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {
                    CountryModel CountryModel = new CountryModel().Select1ByCountryIdToModel(Convert.ToInt32(RowChecked));
                    lstCountryModel.Add(CountryModel);
                }
            }

            using (var Writer = new StreamWriter($@"wwwroot/CSVFiles/Countrying/Country/Country_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.csv"))
            using (var CsvWriter = new CsvWriter(Writer, CultureInfo.InvariantCulture))
            {
                CsvWriter.WriteRecords(lstCountryModel);
            }

            return Now;
        }
        #endregion
    }
}