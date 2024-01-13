using ClosedXML.Excel;
using CsvHelper;
using IronPdf;
using Microsoft.AspNetCore.Http;
using FiyiStackWeb.Areas.CMSCore.Models;
using FiyiStackWeb.Areas.CMSCore.DTOs;
using FiyiStackWeb.Areas.CMSCore.Interfaces;
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

//Last modification on: 21/02/2023 17:56:41

namespace FiyiStackWeb.Areas.CMSCore.Services
{
    /// <summary>
    /// Stack:             4<br/>
    /// Name:              C# Service. <br/>
    /// Function:          Allow you to separate data contract stored in C# model from business with your clients. <br/>
    /// Also, allow dependency injection inside controllers/web apis<br/>
    /// Last modification: 21/02/2023 17:56:41
    /// </summary>
    public partial class MenuService : IMenu
    {
        private readonly IHttpContextAccessor _IHttpContextAccessor;

        public MenuService(IHttpContextAccessor IHttpContextAccessor)
        {
            _IHttpContextAccessor = IHttpContextAccessor;
        }

        #region Queries
        public MenuModel Select1ByMenuIdToModel(int MenuId)
        {
            return new MenuModel().Select1ByMenuIdToModel(MenuId);
        }

        public List<MenuModel> SelectAllToList()
        {
            return new MenuModel().SelectAllToList();
        }

        public menuSelectAllPaged SelectAllPagedToModel(menuSelectAllPaged menuSelectAllPaged)
        {
            return new MenuModel().SelectAllPagedToModel(menuSelectAllPaged);
        } 
        #endregion

        #region Non-Queries
        public int Insert(MenuModel MenuModel)
        {
            return new MenuModel().Insert(MenuModel);
        }

        public int UpdateByMenuId(MenuModel MenuModel)
        {
            return new MenuModel().UpdateByMenuId(MenuModel);
        }

        public int DeleteByMenuId(int MenuId)
        {
            return new MenuModel().DeleteByMenuId(MenuId);
        }

        public void DeleteManyOrAll(Ajax Ajax, string DeleteType)
        {
            if (DeleteType == "All")
            {
                MenuModel MenuModel = new MenuModel();
                MenuModel.DeleteAll();
            }
            else
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                for (int i = 0; i < RowsChecked.Length; i++)
                {
                    MenuModel MenuModel = new MenuModel().Select1ByMenuIdToModel(Convert.ToInt32(RowsChecked[i]));
                    MenuModel.DeleteByMenuId(MenuModel.MenuId);
                }
            }
        }

        public int CopyByMenuId(int MenuId)
        {
            MenuModel MenuModel = new MenuModel().Select1ByMenuIdToModel(MenuId);
            int NewEnteredId = new MenuModel().Insert(MenuModel);

            return NewEnteredId;
        }

        public int[] CopyManyOrAll(Ajax Ajax, string CopyType)
        {
            if (CopyType == "All")
            {
                List<MenuModel> lstMenuModel = new List<MenuModel> { };
                lstMenuModel = new MenuModel().SelectAllToList();

                int[] NewEnteredIds = new int[lstMenuModel.Count];

                for (int i = 0; i < lstMenuModel.Count; i++)
                {
                    NewEnteredIds[i] = lstMenuModel[i].Insert();
                }

                return NewEnteredIds;
            }
            else
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');
                int[] NewEnteredIds = new int[RowsChecked.Length];

                for (int i = 0; i < RowsChecked.Length; i++)
                {
                    MenuModel MenuModel = new MenuModel().Select1ByMenuIdToModel(Convert.ToInt32(RowsChecked[i]));
                    NewEnteredIds[i] = MenuModel.Insert();
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
            List<MenuModel> lstMenuModel = new List<MenuModel> { };

            if (ExportationType == "All")
            {
                lstMenuModel = new MenuModel().SelectAllToList();

            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {
                    MenuModel MenuModel = new MenuModel().Select1ByMenuIdToModel(Convert.ToInt32(RowChecked));
                    lstMenuModel.Add(MenuModel);
                }
            }

            foreach (MenuModel row in lstMenuModel)
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
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #4c4c4c; font-size: 36px; line-height: 45px; font-weight: 300; letter-spacing: -1px;"">Registers of Menu</span>
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
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">MenuId&nbsp;&nbsp;&nbsp;</span>
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
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">MenuFatherId&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">Order&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">URLPath&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">IconURLPath&nbsp;&nbsp;&nbsp;</span>
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
").SaveAs($@"wwwroot/PDFFiles/CMSCore/Menu/Menu_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.pdf");

            return Now;
        }

        public DateTime ExportAsExcel(Ajax Ajax, string ExportationType)
        {
            DateTime Now = DateTime.Now;

            using var Book = new XLWorkbook();

            if (ExportationType == "All")
            {
                DataTable dtMenu = new DataTable();
                dtMenu.TableName = "Menu";

                //We define another DataTable dtMenuCopy to avoid issue related to DateTime conversion
                DataTable dtMenuCopy = new DataTable();
                dtMenuCopy.TableName = "Menu";

                #region Define columns for dtMenuCopy
                DataColumn dtColumnMenuIdFordtMenuCopy = new DataColumn();
                    dtColumnMenuIdFordtMenuCopy.DataType = typeof(string);
                    dtColumnMenuIdFordtMenuCopy.ColumnName = "MenuId";
                    dtMenuCopy.Columns.Add(dtColumnMenuIdFordtMenuCopy);

                    DataColumn dtColumnActiveFordtMenuCopy = new DataColumn();
                    dtColumnActiveFordtMenuCopy.DataType = typeof(string);
                    dtColumnActiveFordtMenuCopy.ColumnName = "Active";
                    dtMenuCopy.Columns.Add(dtColumnActiveFordtMenuCopy);

                    DataColumn dtColumnDateTimeCreationFordtMenuCopy = new DataColumn();
                    dtColumnDateTimeCreationFordtMenuCopy.DataType = typeof(string);
                    dtColumnDateTimeCreationFordtMenuCopy.ColumnName = "DateTimeCreation";
                    dtMenuCopy.Columns.Add(dtColumnDateTimeCreationFordtMenuCopy);

                    DataColumn dtColumnDateTimeLastModificationFordtMenuCopy = new DataColumn();
                    dtColumnDateTimeLastModificationFordtMenuCopy.DataType = typeof(string);
                    dtColumnDateTimeLastModificationFordtMenuCopy.ColumnName = "DateTimeLastModification";
                    dtMenuCopy.Columns.Add(dtColumnDateTimeLastModificationFordtMenuCopy);

                    DataColumn dtColumnUserCreationIdFordtMenuCopy = new DataColumn();
                    dtColumnUserCreationIdFordtMenuCopy.DataType = typeof(string);
                    dtColumnUserCreationIdFordtMenuCopy.ColumnName = "UserCreationId";
                    dtMenuCopy.Columns.Add(dtColumnUserCreationIdFordtMenuCopy);

                    DataColumn dtColumnUserLastModificationIdFordtMenuCopy = new DataColumn();
                    dtColumnUserLastModificationIdFordtMenuCopy.DataType = typeof(string);
                    dtColumnUserLastModificationIdFordtMenuCopy.ColumnName = "UserLastModificationId";
                    dtMenuCopy.Columns.Add(dtColumnUserLastModificationIdFordtMenuCopy);

                    DataColumn dtColumnNameFordtMenuCopy = new DataColumn();
                    dtColumnNameFordtMenuCopy.DataType = typeof(string);
                    dtColumnNameFordtMenuCopy.ColumnName = "Name";
                    dtMenuCopy.Columns.Add(dtColumnNameFordtMenuCopy);

                    DataColumn dtColumnMenuFatherIdFordtMenuCopy = new DataColumn();
                    dtColumnMenuFatherIdFordtMenuCopy.DataType = typeof(string);
                    dtColumnMenuFatherIdFordtMenuCopy.ColumnName = "MenuFatherId";
                    dtMenuCopy.Columns.Add(dtColumnMenuFatherIdFordtMenuCopy);

                    DataColumn dtColumnOrderFordtMenuCopy = new DataColumn();
                    dtColumnOrderFordtMenuCopy.DataType = typeof(string);
                    dtColumnOrderFordtMenuCopy.ColumnName = "Order";
                    dtMenuCopy.Columns.Add(dtColumnOrderFordtMenuCopy);

                    DataColumn dtColumnURLPathFordtMenuCopy = new DataColumn();
                    dtColumnURLPathFordtMenuCopy.DataType = typeof(string);
                    dtColumnURLPathFordtMenuCopy.ColumnName = "URLPath";
                    dtMenuCopy.Columns.Add(dtColumnURLPathFordtMenuCopy);

                    DataColumn dtColumnIconURLPathFordtMenuCopy = new DataColumn();
                    dtColumnIconURLPathFordtMenuCopy.DataType = typeof(string);
                    dtColumnIconURLPathFordtMenuCopy.ColumnName = "IconURLPath";
                    dtMenuCopy.Columns.Add(dtColumnIconURLPathFordtMenuCopy);

                    
                #endregion

                dtMenu = new MenuModel().SelectAllToDataTable();

                foreach (DataRow DataRow in dtMenu.Rows)
                {
                    dtMenuCopy.Rows.Add(DataRow.ItemArray);
                }

                var Sheet = Book.Worksheets.Add(dtMenuCopy);

                Sheet.ColumnsUsed().AdjustToContents();

                Book.SaveAs($@"wwwroot/ExcelFiles/Menuing/Menu/Menu_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.xlsx");
            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                DataSet dsMenu = new DataSet();

                foreach (string RowChecked in RowsChecked)
                {
                    //We define another DataTable dtMenuCopy to avoid issue related to DateTime conversion
                    DataTable dtMenuCopy = new DataTable();
                    dtMenuCopy.TableName = "Menu";

                    #region Define columns for dtMenuCopy
                    DataColumn dtColumnMenuIdFordtMenuCopy = new DataColumn();
                    dtColumnMenuIdFordtMenuCopy.DataType = typeof(string);
                    dtColumnMenuIdFordtMenuCopy.ColumnName = "MenuId";
                    dtMenuCopy.Columns.Add(dtColumnMenuIdFordtMenuCopy);

                    DataColumn dtColumnActiveFordtMenuCopy = new DataColumn();
                    dtColumnActiveFordtMenuCopy.DataType = typeof(string);
                    dtColumnActiveFordtMenuCopy.ColumnName = "Active";
                    dtMenuCopy.Columns.Add(dtColumnActiveFordtMenuCopy);

                    DataColumn dtColumnDateTimeCreationFordtMenuCopy = new DataColumn();
                    dtColumnDateTimeCreationFordtMenuCopy.DataType = typeof(string);
                    dtColumnDateTimeCreationFordtMenuCopy.ColumnName = "DateTimeCreation";
                    dtMenuCopy.Columns.Add(dtColumnDateTimeCreationFordtMenuCopy);

                    DataColumn dtColumnDateTimeLastModificationFordtMenuCopy = new DataColumn();
                    dtColumnDateTimeLastModificationFordtMenuCopy.DataType = typeof(string);
                    dtColumnDateTimeLastModificationFordtMenuCopy.ColumnName = "DateTimeLastModification";
                    dtMenuCopy.Columns.Add(dtColumnDateTimeLastModificationFordtMenuCopy);

                    DataColumn dtColumnUserCreationIdFordtMenuCopy = new DataColumn();
                    dtColumnUserCreationIdFordtMenuCopy.DataType = typeof(string);
                    dtColumnUserCreationIdFordtMenuCopy.ColumnName = "UserCreationId";
                    dtMenuCopy.Columns.Add(dtColumnUserCreationIdFordtMenuCopy);

                    DataColumn dtColumnUserLastModificationIdFordtMenuCopy = new DataColumn();
                    dtColumnUserLastModificationIdFordtMenuCopy.DataType = typeof(string);
                    dtColumnUserLastModificationIdFordtMenuCopy.ColumnName = "UserLastModificationId";
                    dtMenuCopy.Columns.Add(dtColumnUserLastModificationIdFordtMenuCopy);

                    DataColumn dtColumnNameFordtMenuCopy = new DataColumn();
                    dtColumnNameFordtMenuCopy.DataType = typeof(string);
                    dtColumnNameFordtMenuCopy.ColumnName = "Name";
                    dtMenuCopy.Columns.Add(dtColumnNameFordtMenuCopy);

                    DataColumn dtColumnMenuFatherIdFordtMenuCopy = new DataColumn();
                    dtColumnMenuFatherIdFordtMenuCopy.DataType = typeof(string);
                    dtColumnMenuFatherIdFordtMenuCopy.ColumnName = "MenuFatherId";
                    dtMenuCopy.Columns.Add(dtColumnMenuFatherIdFordtMenuCopy);

                    DataColumn dtColumnOrderFordtMenuCopy = new DataColumn();
                    dtColumnOrderFordtMenuCopy.DataType = typeof(string);
                    dtColumnOrderFordtMenuCopy.ColumnName = "Order";
                    dtMenuCopy.Columns.Add(dtColumnOrderFordtMenuCopy);

                    DataColumn dtColumnURLPathFordtMenuCopy = new DataColumn();
                    dtColumnURLPathFordtMenuCopy.DataType = typeof(string);
                    dtColumnURLPathFordtMenuCopy.ColumnName = "URLPath";
                    dtMenuCopy.Columns.Add(dtColumnURLPathFordtMenuCopy);

                    DataColumn dtColumnIconURLPathFordtMenuCopy = new DataColumn();
                    dtColumnIconURLPathFordtMenuCopy.DataType = typeof(string);
                    dtColumnIconURLPathFordtMenuCopy.ColumnName = "IconURLPath";
                    dtMenuCopy.Columns.Add(dtColumnIconURLPathFordtMenuCopy);

                    
                    #endregion

                    dsMenu.Tables.Add(dtMenuCopy);

                    for (int i = 0; i < dsMenu.Tables.Count; i++)
                    {
                        dtMenuCopy = new MenuModel().Select1ByMenuIdToDataTable(Convert.ToInt32(RowChecked));

                        foreach (DataRow DataRow in dtMenuCopy.Rows)
                        {
                            dsMenu.Tables[0].Rows.Add(DataRow.ItemArray);
                        }
                    }
                    
                }

                for (int i = 0; i < dsMenu.Tables.Count; i++)
                {
                    var Sheet = Book.Worksheets.Add(dsMenu.Tables[i]);
                    Sheet.ColumnsUsed().AdjustToContents();
                }

                Book.SaveAs($@"wwwroot/ExcelFiles/Menuing/Menu/Menu_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.xlsx");
            }

            return Now;
        }

        public DateTime ExportAsCSV(Ajax Ajax, string ExportationType)
        {
            DateTime Now = DateTime.Now;
            List<MenuModel> lstMenuModel = new List<MenuModel> { };

            if (ExportationType == "All")
            {
                lstMenuModel = new MenuModel().SelectAllToList();

            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {
                    MenuModel MenuModel = new MenuModel().Select1ByMenuIdToModel(Convert.ToInt32(RowChecked));
                    lstMenuModel.Add(MenuModel);
                }
            }

            using (var Writer = new StreamWriter($@"wwwroot/CSVFiles/Menuing/Menu/Menu_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.csv"))
            using (var CsvWriter = new CsvWriter(Writer, CultureInfo.InvariantCulture))
            {
                CsvWriter.WriteRecords(lstMenuModel);
            }

            return Now;
        }
        #endregion
    }
}