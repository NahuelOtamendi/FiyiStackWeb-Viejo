"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.CommentForBlogModel = void 0;
var Rx = require("rxjs");
var ajax_1 = require("rxjs/ajax");
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
//8 fields | Last modification on: 21/12/2022 12:08:11 | Stack: 9
var CommentForBlogModel = /** @class */ (function () {
    function CommentForBlogModel() {
    }
    //Queries
    CommentForBlogModel.Select1ByCommentForBlogId = function (CommentForBlogId) {
        var URL = "/api/FiyiStack/CommentForBlog/1/Select1ByCommentForBlogIdToJSON/" + CommentForBlogId;
        return Rx.from((0, ajax_1.ajax)(URL));
    };
    CommentForBlogModel.SelectAll = function () {
        var URL = "/api/FiyiStack/CommentForBlog/1/SelectAllToJSON";
        return Rx.from((0, ajax_1.ajax)(URL));
    };
    CommentForBlogModel.SelectAllPaged = function (commentforblogSelectAllPaged) {
        var URL = "/api/FiyiStack/CommentForBlog/1/SelectAllPagedToJSON";
        var Body = {
            QueryString: commentforblogSelectAllPaged.QueryString,
            ActualPageNumber: commentforblogSelectAllPaged.ActualPageNumber,
            RowsPerPage: commentforblogSelectAllPaged.RowsPerPage,
            SorterColumn: commentforblogSelectAllPaged.SorterColumn,
            SortToggler: commentforblogSelectAllPaged.SortToggler,
            RowCount: commentforblogSelectAllPaged.TotalRows,
            TotalPages: commentforblogSelectAllPaged.TotalPages,
            lstCommentForBlogModel: commentforblogSelectAllPaged.lstCommentForBlogModel
        };
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    //Non-Queries
    CommentForBlogModel.DeleteByCommentForBlogId = function (CommentForBlogId) {
        var URL = "/api/FiyiStack/CommentForBlog/1/DeleteByCommentForBlogId/" + CommentForBlogId;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.delete(URL, Header));
    };
    CommentForBlogModel.DeleteManyOrAll = function (DeleteType, Body) {
        var URL = "/api/FiyiStack/CommentForBlog/1/DeleteManyOrAll/" + DeleteType;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    CommentForBlogModel.CopyByCommentForBlogId = function (CommentForBlogId) {
        var URL = "/api/FiyiStack/CommentForBlog/1/CopyByCommentForBlogId/" + CommentForBlogId;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        var Body = {};
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    CommentForBlogModel.CopyManyOrAll = function (CopyType, Body) {
        var URL = "/api/CommentForBloging/CommentForBlog/1/CopyManyOrAll/" + CopyType;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    return CommentForBlogModel;
}());
exports.CommentForBlogModel = CommentForBlogModel;
//# sourceMappingURL=CommentForBlog_TsModel.js.map