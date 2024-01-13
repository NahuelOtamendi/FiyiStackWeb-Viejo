"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.MenuModel = void 0;
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
//11 fields | Sub-models: 0 models  | Last modification on: 15/02/2023 18:14:40 | Stack: 9
var MenuModel = /** @class */ (function () {
    function MenuModel() {
    }
    //Queries
    MenuModel.Select1ByMenuId = function (MenuId) {
        var URL = "/api/CMSCore/Menu/1/Select1ByMenuIdToJSON/" + MenuId;
        return Rx.from((0, ajax_1.ajax)(URL));
    };
    MenuModel.SelectAll = function () {
        var URL = "/api/CMSCore/Menu/1/SelectAllToJSON";
        return Rx.from((0, ajax_1.ajax)(URL));
    };
    MenuModel.SelectAllPaged = function (menuSelectAllPaged) {
        var URL = "/api/CMSCore/Menu/1/SelectAllPagedToJSON";
        var Body = {
            QueryString: menuSelectAllPaged.QueryString,
            ActualPageNumber: menuSelectAllPaged.ActualPageNumber,
            RowsPerPage: menuSelectAllPaged.RowsPerPage,
            SorterColumn: menuSelectAllPaged.SorterColumn,
            SortToggler: menuSelectAllPaged.SortToggler,
            RowCount: menuSelectAllPaged.TotalRows,
            TotalPages: menuSelectAllPaged.TotalPages,
            lstMenuModel: menuSelectAllPaged.lstMenuModel
        };
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    //Non-Queries
    MenuModel.DeleteByMenuId = function (MenuId) {
        var URL = "/api/CMSCore/Menu/1/DeleteByMenuId/" + MenuId;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.delete(URL, Header));
    };
    MenuModel.DeleteManyOrAll = function (DeleteType, Body) {
        var URL = "/api/CMSCore/Menu/1/DeleteManyOrAll/" + DeleteType;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    MenuModel.CopyByMenuId = function (MenuId) {
        var URL = "/api/CMSCore/Menu/1/CopyByMenuId/" + MenuId;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        var Body = {};
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    MenuModel.CopyManyOrAll = function (CopyType, Body) {
        var URL = "/api/Menuing/Menu/1/CopyManyOrAll/" + CopyType;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    return MenuModel;
}());
exports.MenuModel = MenuModel;
//# sourceMappingURL=Menu_TsModel.js.map