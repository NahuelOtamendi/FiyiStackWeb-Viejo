"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.CityModel = void 0;
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
//10 fields | Last modification on: 21/12/2022 9:41:41 | Stack: 9
var CityModel = /** @class */ (function () {
    function CityModel() {
    }
    //Queries
    CityModel.Select1ByCityId = function (CityId) {
        var URL = "/api/BasicCulture/City/1/Select1ByCityIdToJSON/" + CityId;
        return Rx.from((0, ajax_1.ajax)(URL));
    };
    CityModel.SelectAll = function () {
        var URL = "/api/BasicCulture/City/1/SelectAllToJSON";
        return Rx.from((0, ajax_1.ajax)(URL));
    };
    CityModel.SelectAllPaged = function (citySelectAllPaged) {
        var URL = "/api/BasicCulture/City/1/SelectAllPagedToJSON";
        var Body = {
            QueryString: citySelectAllPaged.QueryString,
            ActualPageNumber: citySelectAllPaged.ActualPageNumber,
            RowsPerPage: citySelectAllPaged.RowsPerPage,
            SorterColumn: citySelectAllPaged.SorterColumn,
            SortToggler: citySelectAllPaged.SortToggler,
            RowCount: citySelectAllPaged.TotalRows,
            TotalPages: citySelectAllPaged.TotalPages,
            lstCityModel: citySelectAllPaged.lstCityModel
        };
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    //Non-Queries
    CityModel.DeleteByCityId = function (CityId) {
        var URL = "/api/BasicCulture/City/1/DeleteByCityId/" + CityId;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.delete(URL, Header));
    };
    CityModel.DeleteManyOrAll = function (DeleteType, Body) {
        var URL = "/api/BasicCulture/City/1/DeleteManyOrAll/" + DeleteType;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    CityModel.CopyByCityId = function (CityId) {
        var URL = "/api/BasicCulture/City/1/CopyByCityId/" + CityId;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        var Body = {};
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    CityModel.CopyManyOrAll = function (CopyType, Body) {
        var URL = "/api/Citying/City/1/CopyManyOrAll/" + CopyType;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    return CityModel;
}());
exports.CityModel = CityModel;
//# sourceMappingURL=City_TsModel.js.map