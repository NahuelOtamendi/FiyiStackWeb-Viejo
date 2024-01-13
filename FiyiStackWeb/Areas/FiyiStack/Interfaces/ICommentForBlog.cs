using FiyiStackWeb.Areas.FiyiStack.DTOs;
using FiyiStackWeb.Areas.FiyiStack.Models;
using FiyiStackWeb.Library;
using System;
using System.Collections.Generic;

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

//Last modification on: 22/02/2023 7:10:30

namespace FiyiStackWeb.Areas.FiyiStack.Interfaces
{
    /// <summary>
    /// Stack:             5<br/>
    /// Name:              C# Interface. <br/>
    /// Function:          This interface allow you to standardize the C# service associated. 
    ///                    In other words, define the functions that has to implement the C# service. <br/>
    /// Note:              Raise exception in case of missing any function declared here but not in the service. <br/>
    /// Last modification: 22/02/2023 7:10:30
    /// </summary>
    public partial interface ICommentForBlog
    {
        #region Queries
        /// <summary>
        /// Note: Raise exception when the query find duplicated IDs
        /// </summary>
        /// <param name="CommentForBlogId"></param>
        /// <returns></returns>
        CommentForBlogModel Select1ByCommentForBlogIdToModel(int CommentForBlogId);

        List<CommentForBlogModel> SelectAllToList();

        commentforblogSelectAllPaged SelectAllPagedToModel(commentforblogSelectAllPaged commentforblogSelectAllPaged);
        #endregion

        #region Non-Queries
        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull insertion in database
        /// </summary>
        /// <param name="CommentForBlog"></param>
        /// <returns>NewEnteredId: The ID of the last registry inserted in CommentForBlog table</returns>
        int Insert(CommentForBlogModel CommentForBlog);

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull update in database
        /// </summary>
        /// <param name="CommentForBlog"></param>
        /// <returns>The number of rows updated in CommentForBlog table</returns>
        int UpdateByCommentForBlogId(CommentForBlogModel CommentForBlog);

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull deletion in database
        /// </summary>
        /// <param name="CommentForBlogId"></param>
        /// <returns>The number of rows deleted in CommentForBlog table</returns>
        int DeleteByCommentForBlogId(int CommentForBlogId);

        void DeleteManyOrAll(Ajax Ajax, string DeleteType);

        int CopyByCommentForBlogId(int CommentForBlogId);

        int[] CopyManyOrAll(Ajax Ajax, string CopyType);

        string PostComment(int UserId, int BlogId, string Comment);

        void PostLike(int BlogId);
        #endregion

        #region Other actions
        DateTime ExportAsPDF(Ajax Ajax, string ExportationType);

        DateTime ExportAsExcel(Ajax Ajax, string ExportationType);

        DateTime ExportAsCSV(Ajax Ajax, string ExportationType);
        #endregion
    }
}