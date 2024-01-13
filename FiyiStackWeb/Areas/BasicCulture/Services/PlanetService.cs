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

//Last modification on: 21/02/2023 17:48:26

namespace FiyiStackWeb.Areas.BasicCulture.Services
{
    /// <summary>
    /// Stack:             4<br/>
    /// Name:              C# Service. <br/>
    /// Function:          Allow you to separate data contract stored in C# model from business with your clients. <br/>
    /// Also, allow dependency injection inside controllers/web apis<br/>
    /// Last modification: 21/02/2023 17:48:26
    /// </summary>
    public partial class PlanetService : IPlanet
    {
        private readonly IHttpContextAccessor _IHttpContextAccessor;

        public PlanetService(IHttpContextAccessor IHttpContextAccessor)
        {
            _IHttpContextAccessor = IHttpContextAccessor;
        }

        #region Queries
        public PlanetModel Select1ByPlanetIdToModel(int PlanetId)
        {
            return new PlanetModel().Select1ByPlanetIdToModel(PlanetId);
        }

        public List<PlanetModel> SelectAllToList()
        {
            return new PlanetModel().SelectAllToList();
        }

        public planetSelectAllPaged SelectAllPagedToModel(planetSelectAllPaged planetSelectAllPaged)
        {
            return new PlanetModel().SelectAllPagedToModel(planetSelectAllPaged);
        } 
        #endregion

        #region Non-Queries
        public int Insert(PlanetModel PlanetModel)
        {
            return new PlanetModel().Insert(PlanetModel);
        }

        public int UpdateByPlanetId(PlanetModel PlanetModel)
        {
            return new PlanetModel().UpdateByPlanetId(PlanetModel);
        }

        public int DeleteByPlanetId(int PlanetId)
        {
            return new PlanetModel().DeleteByPlanetId(PlanetId);
        }

        public void DeleteManyOrAll(Ajax Ajax, string DeleteType)
        {
            if (DeleteType == "All")
            {
                PlanetModel PlanetModel = new PlanetModel();
                PlanetModel.DeleteAll();
            }
            else
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                for (int i = 0; i < RowsChecked.Length; i++)
                {
                    PlanetModel PlanetModel = new PlanetModel().Select1ByPlanetIdToModel(Convert.ToInt32(RowsChecked[i]));
                    PlanetModel.DeleteByPlanetId(PlanetModel.PlanetId);
                }
            }
        }

        public int CopyByPlanetId(int PlanetId)
        {
            PlanetModel PlanetModel = new PlanetModel().Select1ByPlanetIdToModel(PlanetId);
            int NewEnteredId = new PlanetModel().Insert(PlanetModel);

            return NewEnteredId;
        }

        public int[] CopyManyOrAll(Ajax Ajax, string CopyType)
        {
            if (CopyType == "All")
            {
                List<PlanetModel> lstPlanetModel = new List<PlanetModel> { };
                lstPlanetModel = new PlanetModel().SelectAllToList();

                int[] NewEnteredIds = new int[lstPlanetModel.Count];

                for (int i = 0; i < lstPlanetModel.Count; i++)
                {
                    NewEnteredIds[i] = lstPlanetModel[i].Insert();
                }

                return NewEnteredIds;
            }
            else
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');
                int[] NewEnteredIds = new int[RowsChecked.Length];

                for (int i = 0; i < RowsChecked.Length; i++)
                {
                    PlanetModel PlanetModel = new PlanetModel().Select1ByPlanetIdToModel(Convert.ToInt32(RowsChecked[i]));
                    NewEnteredIds[i] = PlanetModel.Insert();
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
            List<PlanetModel> lstPlanetModel = new List<PlanetModel> { };

            if (ExportationType == "All")
            {
                lstPlanetModel = new PlanetModel().SelectAllToList();

            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {
                    PlanetModel PlanetModel = new PlanetModel().Select1ByPlanetIdToModel(Convert.ToInt32(RowChecked));
                    lstPlanetModel.Add(PlanetModel);
                }
            }

            foreach (PlanetModel row in lstPlanetModel)
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
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #4c4c4c; font-size: 36px; line-height: 45px; font-weight: 300; letter-spacing: -1px;"">Registers of Planet</span>
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
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">PlanetId&nbsp;&nbsp;&nbsp;</span>
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
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">Code&nbsp;&nbsp;&nbsp;</span>
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
").SaveAs($@"wwwroot/PDFFiles/BasicCulture/Planet/Planet_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.pdf");

            return Now;
        }

        public DateTime ExportAsExcel(Ajax Ajax, string ExportationType)
        {
            DateTime Now = DateTime.Now;

            using var Book = new XLWorkbook();

            if (ExportationType == "All")
            {
                DataTable dtPlanet = new DataTable();
                dtPlanet.TableName = "Planet";

                //We define another DataTable dtPlanetCopy to avoid issue related to DateTime conversion
                DataTable dtPlanetCopy = new DataTable();
                dtPlanetCopy.TableName = "Planet";

                #region Define columns for dtPlanetCopy
                DataColumn dtColumnPlanetIdFordtPlanetCopy = new DataColumn();
                    dtColumnPlanetIdFordtPlanetCopy.DataType = typeof(string);
                    dtColumnPlanetIdFordtPlanetCopy.ColumnName = "PlanetId";
                    dtPlanetCopy.Columns.Add(dtColumnPlanetIdFordtPlanetCopy);

                    DataColumn dtColumnActiveFordtPlanetCopy = new DataColumn();
                    dtColumnActiveFordtPlanetCopy.DataType = typeof(string);
                    dtColumnActiveFordtPlanetCopy.ColumnName = "Active";
                    dtPlanetCopy.Columns.Add(dtColumnActiveFordtPlanetCopy);

                    DataColumn dtColumnDateTimeCreationFordtPlanetCopy = new DataColumn();
                    dtColumnDateTimeCreationFordtPlanetCopy.DataType = typeof(string);
                    dtColumnDateTimeCreationFordtPlanetCopy.ColumnName = "DateTimeCreation";
                    dtPlanetCopy.Columns.Add(dtColumnDateTimeCreationFordtPlanetCopy);

                    DataColumn dtColumnDateTimeLastModificationFordtPlanetCopy = new DataColumn();
                    dtColumnDateTimeLastModificationFordtPlanetCopy.DataType = typeof(string);
                    dtColumnDateTimeLastModificationFordtPlanetCopy.ColumnName = "DateTimeLastModification";
                    dtPlanetCopy.Columns.Add(dtColumnDateTimeLastModificationFordtPlanetCopy);

                    DataColumn dtColumnUserCreationIdFordtPlanetCopy = new DataColumn();
                    dtColumnUserCreationIdFordtPlanetCopy.DataType = typeof(string);
                    dtColumnUserCreationIdFordtPlanetCopy.ColumnName = "UserCreationId";
                    dtPlanetCopy.Columns.Add(dtColumnUserCreationIdFordtPlanetCopy);

                    DataColumn dtColumnUserLastModificationIdFordtPlanetCopy = new DataColumn();
                    dtColumnUserLastModificationIdFordtPlanetCopy.DataType = typeof(string);
                    dtColumnUserLastModificationIdFordtPlanetCopy.ColumnName = "UserLastModificationId";
                    dtPlanetCopy.Columns.Add(dtColumnUserLastModificationIdFordtPlanetCopy);

                    DataColumn dtColumnNameFordtPlanetCopy = new DataColumn();
                    dtColumnNameFordtPlanetCopy.DataType = typeof(string);
                    dtColumnNameFordtPlanetCopy.ColumnName = "Name";
                    dtPlanetCopy.Columns.Add(dtColumnNameFordtPlanetCopy);

                    DataColumn dtColumnCodeFordtPlanetCopy = new DataColumn();
                    dtColumnCodeFordtPlanetCopy.DataType = typeof(string);
                    dtColumnCodeFordtPlanetCopy.ColumnName = "Code";
                    dtPlanetCopy.Columns.Add(dtColumnCodeFordtPlanetCopy);

                    
                #endregion

                dtPlanet = new PlanetModel().SelectAllToDataTable();

                foreach (DataRow DataRow in dtPlanet.Rows)
                {
                    dtPlanetCopy.Rows.Add(DataRow.ItemArray);
                }

                var Sheet = Book.Worksheets.Add(dtPlanetCopy);

                Sheet.ColumnsUsed().AdjustToContents();

                Book.SaveAs($@"wwwroot/ExcelFiles/Planeting/Planet/Planet_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.xlsx");
            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                DataSet dsPlanet = new DataSet();

                foreach (string RowChecked in RowsChecked)
                {
                    //We define another DataTable dtPlanetCopy to avoid issue related to DateTime conversion
                    DataTable dtPlanetCopy = new DataTable();
                    dtPlanetCopy.TableName = "Planet";

                    #region Define columns for dtPlanetCopy
                    DataColumn dtColumnPlanetIdFordtPlanetCopy = new DataColumn();
                    dtColumnPlanetIdFordtPlanetCopy.DataType = typeof(string);
                    dtColumnPlanetIdFordtPlanetCopy.ColumnName = "PlanetId";
                    dtPlanetCopy.Columns.Add(dtColumnPlanetIdFordtPlanetCopy);

                    DataColumn dtColumnActiveFordtPlanetCopy = new DataColumn();
                    dtColumnActiveFordtPlanetCopy.DataType = typeof(string);
                    dtColumnActiveFordtPlanetCopy.ColumnName = "Active";
                    dtPlanetCopy.Columns.Add(dtColumnActiveFordtPlanetCopy);

                    DataColumn dtColumnDateTimeCreationFordtPlanetCopy = new DataColumn();
                    dtColumnDateTimeCreationFordtPlanetCopy.DataType = typeof(string);
                    dtColumnDateTimeCreationFordtPlanetCopy.ColumnName = "DateTimeCreation";
                    dtPlanetCopy.Columns.Add(dtColumnDateTimeCreationFordtPlanetCopy);

                    DataColumn dtColumnDateTimeLastModificationFordtPlanetCopy = new DataColumn();
                    dtColumnDateTimeLastModificationFordtPlanetCopy.DataType = typeof(string);
                    dtColumnDateTimeLastModificationFordtPlanetCopy.ColumnName = "DateTimeLastModification";
                    dtPlanetCopy.Columns.Add(dtColumnDateTimeLastModificationFordtPlanetCopy);

                    DataColumn dtColumnUserCreationIdFordtPlanetCopy = new DataColumn();
                    dtColumnUserCreationIdFordtPlanetCopy.DataType = typeof(string);
                    dtColumnUserCreationIdFordtPlanetCopy.ColumnName = "UserCreationId";
                    dtPlanetCopy.Columns.Add(dtColumnUserCreationIdFordtPlanetCopy);

                    DataColumn dtColumnUserLastModificationIdFordtPlanetCopy = new DataColumn();
                    dtColumnUserLastModificationIdFordtPlanetCopy.DataType = typeof(string);
                    dtColumnUserLastModificationIdFordtPlanetCopy.ColumnName = "UserLastModificationId";
                    dtPlanetCopy.Columns.Add(dtColumnUserLastModificationIdFordtPlanetCopy);

                    DataColumn dtColumnNameFordtPlanetCopy = new DataColumn();
                    dtColumnNameFordtPlanetCopy.DataType = typeof(string);
                    dtColumnNameFordtPlanetCopy.ColumnName = "Name";
                    dtPlanetCopy.Columns.Add(dtColumnNameFordtPlanetCopy);

                    DataColumn dtColumnCodeFordtPlanetCopy = new DataColumn();
                    dtColumnCodeFordtPlanetCopy.DataType = typeof(string);
                    dtColumnCodeFordtPlanetCopy.ColumnName = "Code";
                    dtPlanetCopy.Columns.Add(dtColumnCodeFordtPlanetCopy);

                    
                    #endregion

                    dsPlanet.Tables.Add(dtPlanetCopy);

                    for (int i = 0; i < dsPlanet.Tables.Count; i++)
                    {
                        dtPlanetCopy = new PlanetModel().Select1ByPlanetIdToDataTable(Convert.ToInt32(RowChecked));

                        foreach (DataRow DataRow in dtPlanetCopy.Rows)
                        {
                            dsPlanet.Tables[0].Rows.Add(DataRow.ItemArray);
                        }
                    }
                    
                }

                for (int i = 0; i < dsPlanet.Tables.Count; i++)
                {
                    var Sheet = Book.Worksheets.Add(dsPlanet.Tables[i]);
                    Sheet.ColumnsUsed().AdjustToContents();
                }

                Book.SaveAs($@"wwwroot/ExcelFiles/Planeting/Planet/Planet_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.xlsx");
            }

            return Now;
        }

        public DateTime ExportAsCSV(Ajax Ajax, string ExportationType)
        {
            DateTime Now = DateTime.Now;
            List<PlanetModel> lstPlanetModel = new List<PlanetModel> { };

            if (ExportationType == "All")
            {
                lstPlanetModel = new PlanetModel().SelectAllToList();

            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {
                    PlanetModel PlanetModel = new PlanetModel().Select1ByPlanetIdToModel(Convert.ToInt32(RowChecked));
                    lstPlanetModel.Add(PlanetModel);
                }
            }

            using (var Writer = new StreamWriter($@"wwwroot/CSVFiles/Planeting/Planet/Planet_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.csv"))
            using (var CsvWriter = new CsvWriter(Writer, CultureInfo.InvariantCulture))
            {
                CsvWriter.WriteRecords(lstPlanetModel);
            }

            return Now;
        }
        #endregion
    }
}