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

//Last modification on: 24/03/2023 17:29:07

namespace FiyiStackWeb.Areas.FiyiStack.Services
{
    /// <summary>
    /// Stack:             4<br/>
    /// Name:              C# Service. <br/>
    /// Function:          Allow you to separate data contract stored in C# model from business with your clients. <br/>
    /// Also, allow dependency injection inside controllers/web apis<br/>
    /// Last modification: 24/03/2023 17:29:07
    /// </summary>
    public partial class BlogService : IBlog
    {
        private readonly IHttpContextAccessor _IHttpContextAccessor;

        public BlogService(IHttpContextAccessor IHttpContextAccessor)
        {
            _IHttpContextAccessor = IHttpContextAccessor;
        }

        #region Queries
        public BlogModel Select1ByBlogIdToModel(int BlogId)
        {
            return new BlogModel().Select1ByBlogIdToModel(BlogId);
        }

        public List<BlogModel> SelectAllToList()
        {
            return new BlogModel().SelectAllToList();
        }

        public blogSelectAllPaged SelectAllPagedToModel(blogSelectAllPaged blogSelectAllPaged)
        {
            return new BlogModel().SelectAllPagedToModel(blogSelectAllPaged);
        } 
        #endregion

        #region Non-Queries
        public int Insert(BlogModel BlogModel)
        {
            return new BlogModel().Insert(BlogModel);
        }

        public int UpdateByBlogId(BlogModel BlogModel)
        {
            return new BlogModel().UpdateByBlogId(BlogModel);
        }

        public int DeleteByBlogId(int BlogId)
        {
            return new BlogModel().DeleteByBlogId(BlogId);
        }

        public void DeleteManyOrAll(Ajax Ajax, string DeleteType)
        {
            if (DeleteType == "All")
            {
                BlogModel BlogModel = new BlogModel();
                BlogModel.DeleteAll();
            }
            else
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                for (int i = 0; i < RowsChecked.Length; i++)
                {
                    BlogModel BlogModel = new BlogModel().Select1ByBlogIdToModel(Convert.ToInt32(RowsChecked[i]));
                    BlogModel.DeleteByBlogId(BlogModel.BlogId);
                }
            }
        }

        public int CopyByBlogId(int BlogId)
        {
            BlogModel BlogModel = new BlogModel().Select1ByBlogIdToModel(BlogId);
            int NewEnteredId = new BlogModel().Insert(BlogModel);

            return NewEnteredId;
        }

        public int[] CopyManyOrAll(Ajax Ajax, string CopyType)
        {
            if (CopyType == "All")
            {
                List<BlogModel> lstBlogModel = new List<BlogModel> { };
                lstBlogModel = new BlogModel().SelectAllToList();

                int[] NewEnteredIds = new int[lstBlogModel.Count];

                for (int i = 0; i < lstBlogModel.Count; i++)
                {
                    NewEnteredIds[i] = lstBlogModel[i].Insert();
                }

                return NewEnteredIds;
            }
            else
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');
                int[] NewEnteredIds = new int[RowsChecked.Length];

                for (int i = 0; i < RowsChecked.Length; i++)
                {
                    BlogModel BlogModel = new BlogModel().Select1ByBlogIdToModel(Convert.ToInt32(RowsChecked[i]));
                    NewEnteredIds[i] = BlogModel.Insert();
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
            List<BlogModel> lstBlogModel = new List<BlogModel> { };

            if (ExportationType == "All")
            {
                lstBlogModel = new BlogModel().SelectAllToList();

            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {
                    BlogModel BlogModel = new BlogModel().Select1ByBlogIdToModel(Convert.ToInt32(RowChecked));
                    lstBlogModel.Add(BlogModel);
                }
            }

            foreach (BlogModel row in lstBlogModel)
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
            <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #4c4c4c; font-size: 36px; line-height: 45px; font-weight: 300; letter-spacing: -1px;"">Registers of Blog</span>
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
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">BlogId&nbsp;&nbsp;&nbsp;</span>
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
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">Body&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">BackgroundImage&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">NumberOfLikes&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""height: 10px; line-height: 10px; font-size: 8px;"">&nbsp;</div>
        </th><th align=""left"" valign=""top"" style=""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"">
            <font face=""'Source Sans Pro', sans-serif"" color=""#000000"" style=""font-size: 20px; line-height: 28px; font-weight: 600;"">
                <span style=""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"">NumberOfComments&nbsp;&nbsp;&nbsp;</span>
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
").SaveAs($@"wwwroot/PDFFiles/FiyiStack/Blog/Blog_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.pdf");

            return Now;
        }

        public DateTime ExportAsExcel(Ajax Ajax, string ExportationType)
        {
            DateTime Now = DateTime.Now;

            using var Book = new XLWorkbook();

            if (ExportationType == "All")
            {
                DataTable dtBlog = new DataTable();
                dtBlog.TableName = "Blog";

                //We define another DataTable dtBlogCopy to avoid issue related to DateTime conversion
                DataTable dtBlogCopy = new DataTable();
                dtBlogCopy.TableName = "Blog";

                #region Define columns for dtBlogCopy
                DataColumn dtColumnBlogIdFordtBlogCopy = new DataColumn();
                    dtColumnBlogIdFordtBlogCopy.DataType = typeof(string);
                    dtColumnBlogIdFordtBlogCopy.ColumnName = "BlogId";
                    dtBlogCopy.Columns.Add(dtColumnBlogIdFordtBlogCopy);

                    DataColumn dtColumnActiveFordtBlogCopy = new DataColumn();
                    dtColumnActiveFordtBlogCopy.DataType = typeof(string);
                    dtColumnActiveFordtBlogCopy.ColumnName = "Active";
                    dtBlogCopy.Columns.Add(dtColumnActiveFordtBlogCopy);

                    DataColumn dtColumnDateTimeCreationFordtBlogCopy = new DataColumn();
                    dtColumnDateTimeCreationFordtBlogCopy.DataType = typeof(string);
                    dtColumnDateTimeCreationFordtBlogCopy.ColumnName = "DateTimeCreation";
                    dtBlogCopy.Columns.Add(dtColumnDateTimeCreationFordtBlogCopy);

                    DataColumn dtColumnDateTimeLastModificationFordtBlogCopy = new DataColumn();
                    dtColumnDateTimeLastModificationFordtBlogCopy.DataType = typeof(string);
                    dtColumnDateTimeLastModificationFordtBlogCopy.ColumnName = "DateTimeLastModification";
                    dtBlogCopy.Columns.Add(dtColumnDateTimeLastModificationFordtBlogCopy);

                    DataColumn dtColumnUserCreationIdFordtBlogCopy = new DataColumn();
                    dtColumnUserCreationIdFordtBlogCopy.DataType = typeof(string);
                    dtColumnUserCreationIdFordtBlogCopy.ColumnName = "UserCreationId";
                    dtBlogCopy.Columns.Add(dtColumnUserCreationIdFordtBlogCopy);

                    DataColumn dtColumnUserLastModificationIdFordtBlogCopy = new DataColumn();
                    dtColumnUserLastModificationIdFordtBlogCopy.DataType = typeof(string);
                    dtColumnUserLastModificationIdFordtBlogCopy.ColumnName = "UserLastModificationId";
                    dtBlogCopy.Columns.Add(dtColumnUserLastModificationIdFordtBlogCopy);

                    DataColumn dtColumnTitleFordtBlogCopy = new DataColumn();
                    dtColumnTitleFordtBlogCopy.DataType = typeof(string);
                    dtColumnTitleFordtBlogCopy.ColumnName = "Title";
                    dtBlogCopy.Columns.Add(dtColumnTitleFordtBlogCopy);

                    DataColumn dtColumnBodyFordtBlogCopy = new DataColumn();
                    dtColumnBodyFordtBlogCopy.DataType = typeof(string);
                    dtColumnBodyFordtBlogCopy.ColumnName = "Body";
                    dtBlogCopy.Columns.Add(dtColumnBodyFordtBlogCopy);

                    DataColumn dtColumnBackgroundImageFordtBlogCopy = new DataColumn();
                    dtColumnBackgroundImageFordtBlogCopy.DataType = typeof(string);
                    dtColumnBackgroundImageFordtBlogCopy.ColumnName = "BackgroundImage";
                    dtBlogCopy.Columns.Add(dtColumnBackgroundImageFordtBlogCopy);

                    DataColumn dtColumnNumberOfLikesFordtBlogCopy = new DataColumn();
                    dtColumnNumberOfLikesFordtBlogCopy.DataType = typeof(string);
                    dtColumnNumberOfLikesFordtBlogCopy.ColumnName = "NumberOfLikes";
                    dtBlogCopy.Columns.Add(dtColumnNumberOfLikesFordtBlogCopy);

                    DataColumn dtColumnNumberOfCommentsFordtBlogCopy = new DataColumn();
                    dtColumnNumberOfCommentsFordtBlogCopy.DataType = typeof(string);
                    dtColumnNumberOfCommentsFordtBlogCopy.ColumnName = "NumberOfComments";
                    dtBlogCopy.Columns.Add(dtColumnNumberOfCommentsFordtBlogCopy);

                    
                #endregion

                dtBlog = new BlogModel().SelectAllToDataTable();

                foreach (DataRow DataRow in dtBlog.Rows)
                {
                    dtBlogCopy.Rows.Add(DataRow.ItemArray);
                }

                var Sheet = Book.Worksheets.Add(dtBlogCopy);

                Sheet.ColumnsUsed().AdjustToContents();

                Book.SaveAs($@"wwwroot/ExcelFiles/Bloging/Blog/Blog_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.xlsx");
            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                DataSet dsBlog = new DataSet();

                foreach (string RowChecked in RowsChecked)
                {
                    //We define another DataTable dtBlogCopy to avoid issue related to DateTime conversion
                    DataTable dtBlogCopy = new DataTable();
                    dtBlogCopy.TableName = "Blog";

                    #region Define columns for dtBlogCopy
                    DataColumn dtColumnBlogIdFordtBlogCopy = new DataColumn();
                    dtColumnBlogIdFordtBlogCopy.DataType = typeof(string);
                    dtColumnBlogIdFordtBlogCopy.ColumnName = "BlogId";
                    dtBlogCopy.Columns.Add(dtColumnBlogIdFordtBlogCopy);

                    DataColumn dtColumnActiveFordtBlogCopy = new DataColumn();
                    dtColumnActiveFordtBlogCopy.DataType = typeof(string);
                    dtColumnActiveFordtBlogCopy.ColumnName = "Active";
                    dtBlogCopy.Columns.Add(dtColumnActiveFordtBlogCopy);

                    DataColumn dtColumnDateTimeCreationFordtBlogCopy = new DataColumn();
                    dtColumnDateTimeCreationFordtBlogCopy.DataType = typeof(string);
                    dtColumnDateTimeCreationFordtBlogCopy.ColumnName = "DateTimeCreation";
                    dtBlogCopy.Columns.Add(dtColumnDateTimeCreationFordtBlogCopy);

                    DataColumn dtColumnDateTimeLastModificationFordtBlogCopy = new DataColumn();
                    dtColumnDateTimeLastModificationFordtBlogCopy.DataType = typeof(string);
                    dtColumnDateTimeLastModificationFordtBlogCopy.ColumnName = "DateTimeLastModification";
                    dtBlogCopy.Columns.Add(dtColumnDateTimeLastModificationFordtBlogCopy);

                    DataColumn dtColumnUserCreationIdFordtBlogCopy = new DataColumn();
                    dtColumnUserCreationIdFordtBlogCopy.DataType = typeof(string);
                    dtColumnUserCreationIdFordtBlogCopy.ColumnName = "UserCreationId";
                    dtBlogCopy.Columns.Add(dtColumnUserCreationIdFordtBlogCopy);

                    DataColumn dtColumnUserLastModificationIdFordtBlogCopy = new DataColumn();
                    dtColumnUserLastModificationIdFordtBlogCopy.DataType = typeof(string);
                    dtColumnUserLastModificationIdFordtBlogCopy.ColumnName = "UserLastModificationId";
                    dtBlogCopy.Columns.Add(dtColumnUserLastModificationIdFordtBlogCopy);

                    DataColumn dtColumnTitleFordtBlogCopy = new DataColumn();
                    dtColumnTitleFordtBlogCopy.DataType = typeof(string);
                    dtColumnTitleFordtBlogCopy.ColumnName = "Title";
                    dtBlogCopy.Columns.Add(dtColumnTitleFordtBlogCopy);

                    DataColumn dtColumnBodyFordtBlogCopy = new DataColumn();
                    dtColumnBodyFordtBlogCopy.DataType = typeof(string);
                    dtColumnBodyFordtBlogCopy.ColumnName = "Body";
                    dtBlogCopy.Columns.Add(dtColumnBodyFordtBlogCopy);

                    DataColumn dtColumnBackgroundImageFordtBlogCopy = new DataColumn();
                    dtColumnBackgroundImageFordtBlogCopy.DataType = typeof(string);
                    dtColumnBackgroundImageFordtBlogCopy.ColumnName = "BackgroundImage";
                    dtBlogCopy.Columns.Add(dtColumnBackgroundImageFordtBlogCopy);

                    DataColumn dtColumnNumberOfLikesFordtBlogCopy = new DataColumn();
                    dtColumnNumberOfLikesFordtBlogCopy.DataType = typeof(string);
                    dtColumnNumberOfLikesFordtBlogCopy.ColumnName = "NumberOfLikes";
                    dtBlogCopy.Columns.Add(dtColumnNumberOfLikesFordtBlogCopy);

                    DataColumn dtColumnNumberOfCommentsFordtBlogCopy = new DataColumn();
                    dtColumnNumberOfCommentsFordtBlogCopy.DataType = typeof(string);
                    dtColumnNumberOfCommentsFordtBlogCopy.ColumnName = "NumberOfComments";
                    dtBlogCopy.Columns.Add(dtColumnNumberOfCommentsFordtBlogCopy);

                    
                    #endregion

                    dsBlog.Tables.Add(dtBlogCopy);

                    for (int i = 0; i < dsBlog.Tables.Count; i++)
                    {
                        dtBlogCopy = new BlogModel().Select1ByBlogIdToDataTable(Convert.ToInt32(RowChecked));

                        foreach (DataRow DataRow in dtBlogCopy.Rows)
                        {
                            dsBlog.Tables[0].Rows.Add(DataRow.ItemArray);
                        }
                    }
                    
                }

                for (int i = 0; i < dsBlog.Tables.Count; i++)
                {
                    var Sheet = Book.Worksheets.Add(dsBlog.Tables[i]);
                    Sheet.ColumnsUsed().AdjustToContents();
                }

                Book.SaveAs($@"wwwroot/ExcelFiles/Bloging/Blog/Blog_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.xlsx");
            }

            return Now;
        }

        public DateTime ExportAsCSV(Ajax Ajax, string ExportationType)
        {
            DateTime Now = DateTime.Now;
            List<BlogModel> lstBlogModel = new List<BlogModel> { };

            if (ExportationType == "All")
            {
                lstBlogModel = new BlogModel().SelectAllToList();

            }
            else if (ExportationType == "JustChecked")
            {
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {
                    BlogModel BlogModel = new BlogModel().Select1ByBlogIdToModel(Convert.ToInt32(RowChecked));
                    lstBlogModel.Add(BlogModel);
                }
            }

            using (var Writer = new StreamWriter($@"wwwroot/CSVFiles/Bloging/Blog/Blog_{Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.csv"))
            using (var CsvWriter = new CsvWriter(Writer, CultureInfo.InvariantCulture))
            {
                CsvWriter.WriteRecords(lstBlogModel);
            }

            return Now;
        }
        #endregion
    }
}