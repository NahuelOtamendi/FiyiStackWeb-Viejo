"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ProvinceModel = void 0;
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
//10 fields | Last modification on: 21/12/2022 10:37:34 | Stack: 9
var ProvinceModel = /** @class */ (function () {
    function ProvinceModel() {
    }
    //Queries
    ProvinceModel.Select1ByProvinceId = function (ProvinceId) {
        var URL = "/api/BasicCulture/Province/1/Select1ByProvinceIdToJSON/" + ProvinceId;
        return Rx.from((0, ajax_1.ajax)(URL));
    };
    ProvinceModel.SelectAll = function () {
        var URL = "/api/BasicCulture/Province/1/SelectAllToJSON";
        return Rx.from((0, ajax_1.ajax)(URL));
    };
    ProvinceModel.SelectAllPaged = function (provinceSelectAllPaged) {
        var URL = "/api/BasicCulture/Province/1/SelectAllPagedToJSON";
        var Body = {
            QueryString: provinceSelectAllPaged.QueryString,
            ActualPageNumber: provinceSelectAllPaged.ActualPageNumber,
            RowsPerPage: provinceSelectAllPaged.RowsPerPage,
            SorterColumn: provinceSelectAllPaged.SorterColumn,
            SortToggler: provinceSelectAllPaged.SortToggler,
            RowCount: provinceSelectAllPaged.TotalRows,
            TotalPages: provinceSelectAllPaged.TotalPages,
            lstProvinceModel: provinceSelectAllPaged.lstProvinceModel
        };
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    //Non-Queries
    ProvinceModel.DeleteByProvinceId = function (ProvinceId) {
        var URL = "/api/BasicCulture/Province/1/DeleteByProvinceId/" + ProvinceId;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.delete(URL, Header));
    };
    ProvinceModel.DeleteManyOrAll = function (DeleteType, Body) {
        var URL = "/api/BasicCulture/Province/1/DeleteManyOrAll/" + DeleteType;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    ProvinceModel.CopyByProvinceId = function (ProvinceId) {
        var URL = "/api/BasicCulture/Province/1/CopyByProvinceId/" + ProvinceId;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        var Body = {};
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    ProvinceModel.CopyManyOrAll = function (CopyType, Body) {
        var URL = "/api/Provinceing/Province/1/CopyManyOrAll/" + CopyType;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    return ProvinceModel;
}());
exports.ProvinceModel = ProvinceModel;
//# sourceMappingURL=Province_TsModel.js.map