"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.RoleModel = void 0;
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
//7 fields | Last modification on: 21/12/2022 11:08:27 | Stack: 9
var RoleModel = /** @class */ (function () {
    function RoleModel() {
    }
    //Queries
    RoleModel.Select1ByRoleId = function (RoleId) {
        var URL = "/api/CMSCore/Role/1/Select1ByRoleIdToJSON/" + RoleId;
        return Rx.from((0, ajax_1.ajax)(URL));
    };
    RoleModel.SelectAll = function () {
        var URL = "/api/CMSCore/Role/1/SelectAllToJSON";
        return Rx.from((0, ajax_1.ajax)(URL));
    };
    RoleModel.SelectAllPaged = function (roleSelectAllPaged) {
        var URL = "/api/CMSCore/Role/1/SelectAllPagedToJSON";
        var Body = {
            QueryString: roleSelectAllPaged.QueryString,
            ActualPageNumber: roleSelectAllPaged.ActualPageNumber,
            RowsPerPage: roleSelectAllPaged.RowsPerPage,
            SorterColumn: roleSelectAllPaged.SorterColumn,
            SortToggler: roleSelectAllPaged.SortToggler,
            RowCount: roleSelectAllPaged.TotalRows,
            TotalPages: roleSelectAllPaged.TotalPages,
            lstRoleModel: roleSelectAllPaged.lstRoleModel
        };
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    //Non-Queries
    RoleModel.DeleteByRoleId = function (RoleId) {
        var URL = "/api/CMSCore/Role/1/DeleteByRoleId/" + RoleId;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.delete(URL, Header));
    };
    RoleModel.DeleteManyOrAll = function (DeleteType, Body) {
        var URL = "/api/CMSCore/Role/1/DeleteManyOrAll/" + DeleteType;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    RoleModel.CopyByRoleId = function (RoleId) {
        var URL = "/api/CMSCore/Role/1/CopyByRoleId/" + RoleId;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        var Body = {};
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    RoleModel.CopyManyOrAll = function (CopyType, Body) {
        var URL = "/api/Roleing/Role/1/CopyManyOrAll/" + CopyType;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    return RoleModel;
}());
exports.RoleModel = RoleModel;
//# sourceMappingURL=Role_TsModel.js.map