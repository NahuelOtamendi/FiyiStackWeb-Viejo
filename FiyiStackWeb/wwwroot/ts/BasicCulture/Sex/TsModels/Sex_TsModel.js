"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.SexModel = void 0;
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
//7 fields | Last modification on: 21/12/2022 10:42:03 | Stack: 9
var SexModel = /** @class */ (function () {
    function SexModel() {
    }
    //Queries
    SexModel.Select1BySexId = function (SexId) {
        var URL = "/api/BasicCulture/Sex/1/Select1BySexIdToJSON/" + SexId;
        return Rx.from((0, ajax_1.ajax)(URL));
    };
    SexModel.SelectAll = function () {
        var URL = "/api/BasicCulture/Sex/1/SelectAllToJSON";
        return Rx.from((0, ajax_1.ajax)(URL));
    };
    SexModel.SelectAllPaged = function (sexSelectAllPaged) {
        var URL = "/api/BasicCulture/Sex/1/SelectAllPagedToJSON";
        var Body = {
            QueryString: sexSelectAllPaged.QueryString,
            ActualPageNumber: sexSelectAllPaged.ActualPageNumber,
            RowsPerPage: sexSelectAllPaged.RowsPerPage,
            SorterColumn: sexSelectAllPaged.SorterColumn,
            SortToggler: sexSelectAllPaged.SortToggler,
            RowCount: sexSelectAllPaged.TotalRows,
            TotalPages: sexSelectAllPaged.TotalPages,
            lstSexModel: sexSelectAllPaged.lstSexModel
        };
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    //Non-Queries
    SexModel.DeleteBySexId = function (SexId) {
        var URL = "/api/BasicCulture/Sex/1/DeleteBySexId/" + SexId;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.delete(URL, Header));
    };
    SexModel.DeleteManyOrAll = function (DeleteType, Body) {
        var URL = "/api/BasicCulture/Sex/1/DeleteManyOrAll/" + DeleteType;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    SexModel.CopyBySexId = function (SexId) {
        var URL = "/api/BasicCulture/Sex/1/CopyBySexId/" + SexId;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        var Body = {};
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    SexModel.CopyManyOrAll = function (CopyType, Body) {
        var URL = "/api/Sexing/Sex/1/CopyManyOrAll/" + CopyType;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    return SexModel;
}());
exports.SexModel = SexModel;
//# sourceMappingURL=Sex_TsModel.js.map