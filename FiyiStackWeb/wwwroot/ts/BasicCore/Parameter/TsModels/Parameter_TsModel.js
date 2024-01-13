"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ParameterModel = void 0;
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
//9 fields | Last modification on: 21/12/2022 9:32:45 | Stack: 9
var ParameterModel = /** @class */ (function () {
    function ParameterModel() {
    }
    //Queries
    ParameterModel.Select1ByParameterId = function (ParameterId) {
        var URL = "/api/BasicCore/Parameter/1/Select1ByParameterIdToJSON/" + ParameterId;
        return Rx.from((0, ajax_1.ajax)(URL));
    };
    ParameterModel.SelectAll = function () {
        var URL = "/api/BasicCore/Parameter/1/SelectAllToJSON";
        return Rx.from((0, ajax_1.ajax)(URL));
    };
    ParameterModel.SelectAllPaged = function (parameterSelectAllPaged) {
        var URL = "/api/BasicCore/Parameter/1/SelectAllPagedToJSON";
        var Body = {
            QueryString: parameterSelectAllPaged.QueryString,
            ActualPageNumber: parameterSelectAllPaged.ActualPageNumber,
            RowsPerPage: parameterSelectAllPaged.RowsPerPage,
            SorterColumn: parameterSelectAllPaged.SorterColumn,
            SortToggler: parameterSelectAllPaged.SortToggler,
            RowCount: parameterSelectAllPaged.TotalRows,
            TotalPages: parameterSelectAllPaged.TotalPages,
            lstParameterModel: parameterSelectAllPaged.lstParameterModel
        };
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    //Non-Queries
    ParameterModel.DeleteByParameterId = function (ParameterId) {
        var URL = "/api/BasicCore/Parameter/1/DeleteByParameterId/" + ParameterId;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.delete(URL, Header));
    };
    ParameterModel.DeleteManyOrAll = function (DeleteType, Body) {
        var URL = "/api/BasicCore/Parameter/1/DeleteManyOrAll/" + DeleteType;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    ParameterModel.CopyByParameterId = function (ParameterId) {
        var URL = "/api/BasicCore/Parameter/1/CopyByParameterId/" + ParameterId;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        var Body = {};
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    ParameterModel.CopyManyOrAll = function (CopyType, Body) {
        var URL = "/api/Parametering/Parameter/1/CopyManyOrAll/" + CopyType;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    return ParameterModel;
}());
exports.ParameterModel = ParameterModel;
//# sourceMappingURL=Parameter_TsModel.js.map