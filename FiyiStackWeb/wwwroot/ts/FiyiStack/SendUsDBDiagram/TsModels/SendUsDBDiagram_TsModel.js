"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.SendUsDBDiagramModel = void 0;
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
//9 fields | Sub-models: 0 models  | Last modification on: 23/07/2023 22:31:09 | Stack: 9
var SendUsDBDiagramModel = /** @class */ (function () {
    function SendUsDBDiagramModel() {
    }
    //Queries
    SendUsDBDiagramModel.Select1BySendUsDBDiagramId = function (SendUsDBDiagramId) {
        var URL = "/api/FiyiStack/SendUsDBDiagram/1/Select1BySendUsDBDiagramIdToJSON/" + SendUsDBDiagramId;
        return Rx.from((0, ajax_1.ajax)(URL));
    };
    SendUsDBDiagramModel.SelectAll = function () {
        var URL = "/api/FiyiStack/SendUsDBDiagram/1/SelectAllToJSON";
        return Rx.from((0, ajax_1.ajax)(URL));
    };
    SendUsDBDiagramModel.SelectAllPaged = function (sendusdbdiagramSelectAllPaged) {
        var URL = "/api/FiyiStack/SendUsDBDiagram/1/SelectAllPagedToJSON";
        var Body = {
            QueryString: sendusdbdiagramSelectAllPaged.QueryString,
            ActualPageNumber: sendusdbdiagramSelectAllPaged.ActualPageNumber,
            RowsPerPage: sendusdbdiagramSelectAllPaged.RowsPerPage,
            SorterColumn: sendusdbdiagramSelectAllPaged.SorterColumn,
            SortToggler: sendusdbdiagramSelectAllPaged.SortToggler,
            RowCount: sendusdbdiagramSelectAllPaged.TotalRows,
            TotalPages: sendusdbdiagramSelectAllPaged.TotalPages,
            lstSendUsDBDiagramModel: sendusdbdiagramSelectAllPaged.lstSendUsDBDiagramModel
        };
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    //Non-Queries
    SendUsDBDiagramModel.DeleteBySendUsDBDiagramId = function (SendUsDBDiagramId) {
        var URL = "/api/FiyiStack/SendUsDBDiagram/1/DeleteBySendUsDBDiagramId/" + SendUsDBDiagramId;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.delete(URL, Header));
    };
    SendUsDBDiagramModel.DeleteManyOrAll = function (DeleteType, Body) {
        var URL = "/api/FiyiStack/SendUsDBDiagram/1/DeleteManyOrAll/" + DeleteType;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    SendUsDBDiagramModel.CopyBySendUsDBDiagramId = function (SendUsDBDiagramId) {
        var URL = "/api/FiyiStack/SendUsDBDiagram/1/CopyBySendUsDBDiagramId/" + SendUsDBDiagramId;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        var Body = {};
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    SendUsDBDiagramModel.CopyManyOrAll = function (CopyType, Body) {
        var URL = "/api/SendUsDBDiagraming/SendUsDBDiagram/1/CopyManyOrAll/" + CopyType;
        var Header = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax_1.ajax.post(URL, Body, Header));
    };
    return SendUsDBDiagramModel;
}());
exports.SendUsDBDiagramModel = SendUsDBDiagramModel;
//# sourceMappingURL=SendUsDBDiagram_TsModel.js.map