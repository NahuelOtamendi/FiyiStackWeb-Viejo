using ClosedXML.Excel;
using CsvHelper;
using IronPdf;
using Microsoft.AspNetCore.Http;
using FiyiStackWeb.Areas.CMSCore.Models;
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
 * Copyright © 2022
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 */

//Last modification on: 20/12/2022 20:28:32

namespace FiyiStackWeb.Areas.CMSCore.Services
{
    /// <summary>
    /// Stack:             4<br/>
    /// Name:              C# Service. <br/>
    /// Function:          Allow you to separate data contract stored in C# model from business with your clients. <br/>
    /// Also, allow dependency injection inside controllers/web apis<br/>
    /// Last modification: 20/12/2022 20:28:32
    /// </summary>
    public partial class RoleMenuService : IRoleMenu
    {
        private readonly IHttpContextAccessor _IHttpContextAccessor;

        public RoleMenuService(IHttpContextAccessor IHttpContextAccessor)
        {
            _IHttpContextAccessor = IHttpContextAccessor;
        }

        #region Queries
        public RoleMenuModel Select1ByRoleMenuIdToModel(int RoleMenuId)
        {
            return new RoleMenuModel().Select1ByRoleMenuIdToModel(RoleMenuId);
        }

        public List<RoleMenuModel> SelectAllToList()
        {
            return new RoleMenuModel().SelectAllToList();
        }

        public rolemenuModelQuery SelectAllPagedToModel(rolemenuModelQuery rolemenuModelQuery)
        {
            return new RoleMenuModel().SelectAllPagedToModel(rolemenuModelQuery);
        }

        public List<roleMenuForChechboxes> SelectAllByRoleIdToRoleMenuForChechboxes(int RoleId)
        {
            return new RoleMenuModel().SelectAllByRoleIdToRoleMenuForChechboxes(RoleId);
        }
        #endregion

        #region Non-Queries
        public int Insert(RoleMenuModel RoleMenuModel)
        {
            return new RoleMenuModel().Insert(RoleMenuModel);
        }

        public int UpdateByRoleMenuId(RoleMenuModel RoleMenuModel)
        {
            return new RoleMenuModel().UpdateByRoleMenuId(RoleMenuModel);
        }

        public int DeleteByRoleMenuId(int RoleMenuId)
        {
            return new RoleMenuModel().DeleteByRoleMenuId(RoleMenuId);
        }

        public void DeleteManyOrAll(Ajax Ajax, string DeleteType)
        {
            if (DeleteType == "All")
            {
                RoleMenuModel RoleMenuModel = new RoleMenuModel();
                RoleMenuModel.DeleteAll();
            }
            else
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                for (int i = 0; i < RowsChecked.Length; i++)
                {
                    RoleMenuModel RoleMenuModel = new RoleMenuModel().Select1ByRoleMenuIdToModel(Convert.ToInt32(RowsChecked[i]));
                    RoleMenuModel.DeleteByRoleMenuId(RoleMenuModel.RoleMenuId);
                }
            }
        }

        public int CopyByRoleMenuId(int RoleMenuId)
        {
            RoleMenuModel RoleMenuModel = new RoleMenuModel().Select1ByRoleMenuIdToModel(RoleMenuId);
            int NewEnteredId = new RoleMenuModel().Insert(RoleMenuModel);

            return NewEnteredId;
        }

        public int[] CopyManyOrAll(Ajax Ajax, string CopyType)
        {
            if (CopyType == "All")
            {
                List<RoleMenuModel> lstRoleMenuModel = new List<RoleMenuModel> { };
                lstRoleMenuModel = new RoleMenuModel().SelectAllToList();

                int[] NewEnteredIds = new int[lstRoleMenuModel.Count];

                for (int i = 0; i < lstRoleMenuModel.Count; i++)
                {
                    NewEnteredIds[i] = lstRoleMenuModel[i].Insert();
                }

                return NewEnteredIds;
            }
            else
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');
                int[] NewEnteredIds = new int[RowsChecked.Length];

                for (int i = 0; i < RowsChecked.Length; i++)
                {
                    RoleMenuModel RoleMenuModel = new RoleMenuModel().Select1ByRoleMenuIdToModel(Convert.ToInt32(RowsChecked[i]));
                    NewEnteredIds[i] = RoleMenuModel.Insert();
                }

                return NewEnteredIds;
            }
        }

        public void UpdateByRoleIdByMenuId(int RoleId, int MenuId, bool Selected)
        {
            RoleMenuModel RoleMenuModel = new RoleMenuModel();
            RoleMenuModel.UpdateByRoleIdByMenuId(RoleId, MenuId, Selected);
        }
        #endregion

        #region Other services
        public DateTime ExportAsPDF(Ajax Ajax, string ExportationType)
        {
            var Renderer = new HtmlToPdf();
            DateTime Now = DateTime.Now;
            string RowsAsHTML = "";
            List<RoleMenuModel> lstRoleMenuModel = new List<RoleMenuModel> { };

            if (ExportationType == "All")
            {
                lstRoleMenuModel = new RoleMenuModel().SelectAllToList();

            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {
                    RoleMenuModel RoleMenuModel = new RoleMenuModel().Select1ByRoleMenuIdToModel(Convert.ToInt32(RowChecked));
                    lstRoleMenuModel.Add(RoleMenuModel);
                }
            }

            foreach (RoleMenuModel row in lstRoleMenuModel)
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
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #4c4c4c; font-size: 36px; line-height: 45px; font-weight: 300; letter-spacing: -1px;"">Registers of RoleMenu</span>
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
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">RoleMenuId&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">RoleId&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
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
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">DateTimeCreation&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">DateTimeLastModification&nbsp;&nbsp;&nbsp;</span>
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
").SaveAs($@"wwwroot/PDFFiles/CMSCore/RoleMenu/RoleMenu_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.pdf");

            return Now;
        }

        public DateTime ExportAsExcel(Ajax Ajax, string ExportationType)
        {
            DateTime Now = DateTime.Now;

            using var Book = new XLWorkbook();

            if (ExportationType == "All")
            {
                DataTable dtRoleMenu = new DataTable();
                dtRoleMenu.TableName = "RoleMenu";

                //We define another DataTable dtRoleMenuCopy to avoid issue related to DateTime conversion
                DataTable dtRoleMenuCopy = new DataTable();
                dtRoleMenuCopy.TableName = "RoleMenu";

                #region Define columns for dtRoleMenuCopy
                DataColumn dtColumnRoleMenuIdFordtRoleMenuCopy = new DataColumn();
                    dtColumnRoleMenuIdFordtRoleMenuCopy.DataType = typeof(string);
                    dtColumnRoleMenuIdFordtRoleMenuCopy.ColumnName = "RoleMenuId";
                    dtRoleMenuCopy.Columns.Add(dtColumnRoleMenuIdFordtRoleMenuCopy);

                    DataColumn dtColumnRoleIdFordtRoleMenuCopy = new DataColumn();
                    dtColumnRoleIdFordtRoleMenuCopy.DataType = typeof(string);
                    dtColumnRoleIdFordtRoleMenuCopy.ColumnName = "RoleId";
                    dtRoleMenuCopy.Columns.Add(dtColumnRoleIdFordtRoleMenuCopy);

                    DataColumn dtColumnMenuIdFordtRoleMenuCopy = new DataColumn();
                    dtColumnMenuIdFordtRoleMenuCopy.DataType = typeof(string);
                    dtColumnMenuIdFordtRoleMenuCopy.ColumnName = "MenuId";
                    dtRoleMenuCopy.Columns.Add(dtColumnMenuIdFordtRoleMenuCopy);

                    DataColumn dtColumnActiveFordtRoleMenuCopy = new DataColumn();
                    dtColumnActiveFordtRoleMenuCopy.DataType = typeof(string);
                    dtColumnActiveFordtRoleMenuCopy.ColumnName = "Active";
                    dtRoleMenuCopy.Columns.Add(dtColumnActiveFordtRoleMenuCopy);

                    DataColumn dtColumnUserCreationIdFordtRoleMenuCopy = new DataColumn();
                    dtColumnUserCreationIdFordtRoleMenuCopy.DataType = typeof(string);
                    dtColumnUserCreationIdFordtRoleMenuCopy.ColumnName = "UserCreationId";
                    dtRoleMenuCopy.Columns.Add(dtColumnUserCreationIdFordtRoleMenuCopy);

                    DataColumn dtColumnUserLastModificationIdFordtRoleMenuCopy = new DataColumn();
                    dtColumnUserLastModificationIdFordtRoleMenuCopy.DataType = typeof(string);
                    dtColumnUserLastModificationIdFordtRoleMenuCopy.ColumnName = "UserLastModificationId";
                    dtRoleMenuCopy.Columns.Add(dtColumnUserLastModificationIdFordtRoleMenuCopy);

                    DataColumn dtColumnDateTimeCreationFordtRoleMenuCopy = new DataColumn();
                    dtColumnDateTimeCreationFordtRoleMenuCopy.DataType = typeof(string);
                    dtColumnDateTimeCreationFordtRoleMenuCopy.ColumnName = "DateTimeCreation";
                    dtRoleMenuCopy.Columns.Add(dtColumnDateTimeCreationFordtRoleMenuCopy);

                    DataColumn dtColumnDateTimeLastModificationFordtRoleMenuCopy = new DataColumn();
                    dtColumnDateTimeLastModificationFordtRoleMenuCopy.DataType = typeof(string);
                    dtColumnDateTimeLastModificationFordtRoleMenuCopy.ColumnName = "DateTimeLastModification";
                    dtRoleMenuCopy.Columns.Add(dtColumnDateTimeLastModificationFordtRoleMenuCopy);

                    
                #endregion

                dtRoleMenu = new RoleMenuModel().SelectAllToDataTable();

                foreach (DataRow DataRow in dtRoleMenu.Rows)
                {
                    dtRoleMenuCopy.Rows.Add(DataRow.ItemArray);
                }

                var Sheet = Book.Worksheets.Add(dtRoleMenuCopy);

                Sheet.ColumnsUsed().AdjustToContents();

                Book.SaveAs($@"wwwroot/ExcelFiles/RoleMenuing/RoleMenu/RoleMenu_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.xlsx");
            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                DataSet dsRoleMenu = new DataSet();

                foreach (string RowChecked in RowsChecked)
                {
                    //We define another DataTable dtRoleMenuCopy to avoid issue related to DateTime conversion
                    DataTable dtRoleMenuCopy = new DataTable();
                    dtRoleMenuCopy.TableName = "RoleMenu";

                    #region Define columns for dtRoleMenuCopy
                    DataColumn dtColumnRoleMenuIdFordtRoleMenuCopy = new DataColumn();
                    dtColumnRoleMenuIdFordtRoleMenuCopy.DataType = typeof(string);
                    dtColumnRoleMenuIdFordtRoleMenuCopy.ColumnName = "RoleMenuId";
                    dtRoleMenuCopy.Columns.Add(dtColumnRoleMenuIdFordtRoleMenuCopy);

                    DataColumn dtColumnRoleIdFordtRoleMenuCopy = new DataColumn();
                    dtColumnRoleIdFordtRoleMenuCopy.DataType = typeof(string);
                    dtColumnRoleIdFordtRoleMenuCopy.ColumnName = "RoleId";
                    dtRoleMenuCopy.Columns.Add(dtColumnRoleIdFordtRoleMenuCopy);

                    DataColumn dtColumnMenuIdFordtRoleMenuCopy = new DataColumn();
                    dtColumnMenuIdFordtRoleMenuCopy.DataType = typeof(string);
                    dtColumnMenuIdFordtRoleMenuCopy.ColumnName = "MenuId";
                    dtRoleMenuCopy.Columns.Add(dtColumnMenuIdFordtRoleMenuCopy);

                    DataColumn dtColumnActiveFordtRoleMenuCopy = new DataColumn();
                    dtColumnActiveFordtRoleMenuCopy.DataType = typeof(string);
                    dtColumnActiveFordtRoleMenuCopy.ColumnName = "Active";
                    dtRoleMenuCopy.Columns.Add(dtColumnActiveFordtRoleMenuCopy);

                    DataColumn dtColumnUserCreationIdFordtRoleMenuCopy = new DataColumn();
                    dtColumnUserCreationIdFordtRoleMenuCopy.DataType = typeof(string);
                    dtColumnUserCreationIdFordtRoleMenuCopy.ColumnName = "UserCreationId";
                    dtRoleMenuCopy.Columns.Add(dtColumnUserCreationIdFordtRoleMenuCopy);

                    DataColumn dtColumnUserLastModificationIdFordtRoleMenuCopy = new DataColumn();
                    dtColumnUserLastModificationIdFordtRoleMenuCopy.DataType = typeof(string);
                    dtColumnUserLastModificationIdFordtRoleMenuCopy.ColumnName = "UserLastModificationId";
                    dtRoleMenuCopy.Columns.Add(dtColumnUserLastModificationIdFordtRoleMenuCopy);

                    DataColumn dtColumnDateTimeCreationFordtRoleMenuCopy = new DataColumn();
                    dtColumnDateTimeCreationFordtRoleMenuCopy.DataType = typeof(string);
                    dtColumnDateTimeCreationFordtRoleMenuCopy.ColumnName = "DateTimeCreation";
                    dtRoleMenuCopy.Columns.Add(dtColumnDateTimeCreationFordtRoleMenuCopy);

                    DataColumn dtColumnDateTimeLastModificationFordtRoleMenuCopy = new DataColumn();
                    dtColumnDateTimeLastModificationFordtRoleMenuCopy.DataType = typeof(string);
                    dtColumnDateTimeLastModificationFordtRoleMenuCopy.ColumnName = "DateTimeLastModification";
                    dtRoleMenuCopy.Columns.Add(dtColumnDateTimeLastModificationFordtRoleMenuCopy);

                    
                    #endregion

                    dsRoleMenu.Tables.Add(dtRoleMenuCopy);

                    for (int i = 0; i < dsRoleMenu.Tables.Count; i++)
                    {
                        dtRoleMenuCopy = new RoleMenuModel().Select1ByRoleMenuIdToDataTable(Convert.ToInt32(RowChecked));

                        foreach (DataRow DataRow in dtRoleMenuCopy.Rows)
                        {
                            dsRoleMenu.Tables[0].Rows.Add(DataRow.ItemArray);
                        }
                    }
                    
                }

                for (int i = 0; i < dsRoleMenu.Tables.Count; i++)
                {
                    var Sheet = Book.Worksheets.Add(dsRoleMenu.Tables[i]);
                    Sheet.ColumnsUsed().AdjustToContents();
                }

                Book.SaveAs($@"wwwroot/ExcelFiles/RoleMenuing/RoleMenu/RoleMenu_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.xlsx");
            }

            return Now;
        }

        public DateTime ExportAsCSV(Ajax Ajax, string ExportationType)
        {
            DateTime Now = DateTime.Now;
            List<RoleMenuModel> lstRoleMenuModel = new List<RoleMenuModel> { };

            if (ExportationType == "All")
            {
                lstRoleMenuModel = new RoleMenuModel().SelectAllToList();

            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {
                    RoleMenuModel RoleMenuModel = new RoleMenuModel().Select1ByRoleMenuIdToModel(Convert.ToInt32(RowChecked));
                    lstRoleMenuModel.Add(RoleMenuModel);
                }
            }

            using (var Writer = new StreamWriter($@"wwwroot/CSVFiles/RoleMenuing/RoleMenu/RoleMenu_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.csv"))
            using (var CsvWriter = new CsvWriter(Writer, CultureInfo.InvariantCulture))
            {
                CsvWriter.WriteRecords(lstRoleMenuModel);
            }

            return Now;
        }
        #endregion
    }
}