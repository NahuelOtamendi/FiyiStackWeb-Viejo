"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.VisitorCounterModel = void 0;
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
//7 fields | Sub-models: 0 models  | Last modification on: 22/02/2023 7:45:50 | Stack: 9
var VisitorCounterModel = /** @class */ (function () {
    function VisitorCounterModel() {
    }
    //Queries
    VisitorCounterModel.Select1ByVisitorCounterId = function (VisitorCounterId) {
        var URL = "/api/BasicCore/VisitorCounter/1/Select1ByVisitorCounterIdToJSON/" + VisitorCounterId;
        return Rx.from((0, ajax_1.ajax)(URL));
    };
    VisitorCounterModel.SelectAll = function () {
        var URL = "/api/BasicCore/VisitorCounter/1/SelectAllToJSON";
        return Rx.from((0, ajax_1.ajax)(URL));
    };
    VisitorCounterModel.SelectAllPaged = function (visitorcounterSelectAllPaged) {
        var URL = "/api/BasicCore/VisitorCounter/1/SelectAllPagedToJSON";
        var Body = {
            QueryString: visitorcounterSelectAllPaged.QueryString,
            ActualPageNumber: visitorcounterSelectAllPaged.ActualPageNumber,
            RowsPerPage: visitorcounterSelectAllPaged.RowsPerPage,
            SorterColumn: visitorcounterSelectAllPaged.SorterColumn,
            SortToggler: visitorcounterSelectAllPaged.SortToggler,
            RowCount: visitorcounterSelectAllPaged.TotalRows,
            TotalPages: visitorcounterSelectAllPaged.TotalPages,
            lstVisitorCounterModel: visitorcounterSelectAllPaged.lstVisitorCounterModel
        };
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    //Non-Queries
    VisitorCounterModel.DeleteByVisitorCounterId = function (VisitorCounterId) {
        var URL = "/api/BasicCore/VisitorCounter/1/DeleteByVisitorCounterId/" + VisitorCounterId;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.delete(URL, Header));
    };
    VisitorCounterModel.DeleteManyOrAll = function (DeleteType, Body) {
        var URL = "/api/BasicCore/VisitorCounter/1/DeleteManyOrAll/" + DeleteType;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    VisitorCounterModel.CopyByVisitorCounterId = function (VisitorCounterId) {
        var URL = "/api/BasicCore/VisitorCounter/1/CopyByVisitorCounterId/" + VisitorCounterId;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        var Body = {};
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    VisitorCounterModel.CopyManyOrAll = function (CopyType, Body) {
        var URL = "/api/VisitorCountering/VisitorCounter/1/CopyManyOrAll/" + CopyType;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    return VisitorCounterModel;
}());
exports.VisitorCounterModel = VisitorCounterModel;
//# sourceMappingURL=VisitorCounter_TsModel.js.map