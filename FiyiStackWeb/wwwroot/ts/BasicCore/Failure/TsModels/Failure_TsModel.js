"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FailureModel = void 0;
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
//12 fields | Last modification on: 21/12/2022 9:25:46 | Stack: 9
var FailureModel = /** @class */ (function () {
    function FailureModel() {
    }
    //Queries
    FailureModel.Select1ByFailureId = function (FailureId) {
        var URL = "/api/BasicCore/Failure/1/Select1ByFailureIdToJSON/" + FailureId;
        return Rx.from((0, ajax_1.ajax)(URL));
    };
    FailureModel.SelectAll = function () {
        var URL = "/api/BasicCore/Failure/1/SelectAllToJSON";
        return Rx.from((0, ajax_1.ajax)(URL));
    };
    FailureModel.SelectAllPaged = function (failureSelectAllPaged) {
        var URL = "/api/BasicCore/Failure/1/SelectAllPagedToJSON";
        var Body = {
            QueryString: failureSelectAllPaged.QueryString,
            ActualPageNumber: failureSelectAllPaged.ActualPageNumber,
            RowsPerPage: failureSelectAllPaged.RowsPerPage,
            SorterColumn: failureSelectAllPaged.SorterColumn,
            SortToggler: failureSelectAllPaged.SortToggler,
            RowCount: failureSelectAllPaged.TotalRows,
            TotalPages: failureSelectAllPaged.TotalPages,
            lstFailureModel: failureSelectAllPaged.lstFailureModel
        };
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    //Non-Queries
    FailureModel.DeleteByFailureId = function (FailureId) {
        var URL = "/api/BasicCore/Failure/1/DeleteByFailureId/" + FailureId;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.delete(URL, Header));
    };
    FailureModel.DeleteManyOrAll = function (DeleteType, Body) {
        var URL = "/api/BasicCore/Failure/1/DeleteManyOrAll/" + DeleteType;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    FailureModel.CopyByFailureId = function (FailureId) {
        var URL = "/api/BasicCore/Failure/1/CopyByFailureId/" + FailureId;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        var Body = {};
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    FailureModel.CopyManyOrAll = function (CopyType, Body) {
        var URL = "/api/Failureing/Failure/1/CopyManyOrAll/" + CopyType;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    return FailureModel;
}());
exports.FailureModel = FailureModel;
//# sourceMappingURL=Failure_TsModel.js.map