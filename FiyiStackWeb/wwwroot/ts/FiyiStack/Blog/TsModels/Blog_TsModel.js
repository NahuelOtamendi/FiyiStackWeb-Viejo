"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.BlogModel = void 0;
var Rx = require("rxjs");
var ajax_1 = require("rxjs/ajax");
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
//12 fields | Sub-models: 1 models  | Last modification on: 23/07/2023 11:33:01 | Stack: 9
var BlogModel = /** @class */ (function () {
    function BlogModel() {
    }
    //Queries
    BlogModel.Select1ByBlogIdAndIdiom = function (BlogId) {
        var URL = "/api/FiyiStack/Blog/1/Select1ByBlogIdToJSON/" + BlogId;
        return Rx.from((0, ajax_1.ajax)(URL));
    };
    BlogModel.SelectAll = function () {
        var URL = "/api/FiyiStack/Blog/1/SelectAllToJSON";
        return Rx.from((0, ajax_1.ajax)(URL));
    };
    BlogModel.SelectAllPaged = function (blogSelectAllPaged) {
        var URL = "/api/FiyiStack/Blog/1/SelectAllPagedToJSON";
        var Body = {
            QueryString: blogSelectAllPaged.QueryString,
            ActualPageNumber: blogSelectAllPaged.ActualPageNumber,
            RowsPerPage: blogSelectAllPaged.RowsPerPage,
            SorterColumn: blogSelectAllPaged.SorterColumn,
            SortToggler: blogSelectAllPaged.SortToggler,
            RowCount: blogSelectAllPaged.TotalRows,
            TotalPages: blogSelectAllPaged.TotalPages,
            lstBlogModel: blogSelectAllPaged.lstBlogModel
        };
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    //Non-Queries
    BlogModel.DeleteByBlogId = function (BlogId) {
        var URL = "/api/FiyiStack/Blog/1/DeleteByBlogId/" + BlogId;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.delete(URL, Header));
    };
    BlogModel.DeleteManyOrAll = function (DeleteType, Body) {
        var URL = "/api/FiyiStack/Blog/1/DeleteManyOrAll/" + DeleteType;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    BlogModel.CopyByBlogId = function (BlogId) {
        var URL = "/api/FiyiStack/Blog/1/CopyByBlogId/" + BlogId;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        var Body = {};
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    BlogModel.CopyManyOrAll = function (CopyType, Body) {
        var URL = "/api/Bloging/Blog/1/CopyManyOrAll/" + CopyType;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    return BlogModel;
}());
exports.BlogModel = BlogModel;
//# sourceMappingURL=Blog_TsModel.js.map