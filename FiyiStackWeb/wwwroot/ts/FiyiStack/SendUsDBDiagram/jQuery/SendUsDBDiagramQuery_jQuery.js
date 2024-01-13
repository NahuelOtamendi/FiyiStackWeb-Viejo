"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
//Import libraries to use
var SendUsDBDiagram_TsModel_1 = require("../../SendUsDBDiagram/TsModels/SendUsDBDiagram_TsModel");
var $ = require("jquery");
var Rx = require("rxjs");
var ajax_1 = require("rxjs/ajax");
require("bootstrap-notify");
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
//Stack: 10
//Last modification on: 23/07/2023 22:31:09
//Set default values
var LastTopDistance = 0;
var QueryString = "";
var ActualPageNumber = 1;
var RowsPerPage = 50;
var SorterColumn = "";
var SortToggler = false;
var TotalPages = 0;
var TotalRows = 0;
var ViewToggler = "List";
var ScrollDownNSearchFlag = false;
var SendUsDBDiagramQuery = /** @class */ (function () {
    function SendUsDBDiagramQuery() {
    }
    SendUsDBDiagramQuery.SelectAllPagedToHTML = function (request_sendusdbdiagramSelectAllPaged) {
        //Used for list view
        $(window).off("scroll");
        //Load some part of table
        var TableContent = "<thead class=\"thead-light\">\n    <tr>\n        <th scope=\"col\">\n            <div>\n                <input id=\"sendusdbdiagram-table-check-all\" type=\"checkbox\">\n            </div>\n        </th>\n        <th scope=\"col\">\n            <button value=\"SendUsDBDiagramId\" class=\"btn btn-outline-secondary btn-sm\" type=\"button\">\n                SendUsDBDiagramId\n            </button>\n        </th>\n        <th scope=\"col\">\n            <button value=\"Active\" class=\"btn btn-outline-secondary btn-sm\" type=\"button\">\n                Active\n            </button>\n        </th>\n        <th scope=\"col\">\n            <button value=\"DateTimeCreation\" class=\"btn btn-outline-secondary btn-sm\" type=\"button\">\n                DateTimeCreation\n            </button>\n        </th>\n        <th scope=\"col\">\n            <button value=\"DateTimeLastModification\" class=\"btn btn-outline-secondary btn-sm\" type=\"button\">\n                DateTimeLastModification\n            </button>\n        </th>\n        <th scope=\"col\">\n            <button value=\"UserCreationId\" class=\"btn btn-outline-secondary btn-sm\" type=\"button\">\n                UserCreationId\n            </button>\n        </th>\n        <th scope=\"col\">\n            <button value=\"UserLastModificationId\" class=\"btn btn-outline-secondary btn-sm\" type=\"button\">\n                UserLastModificationId\n            </button>\n        </th>\n        <th scope=\"col\">\n            <button value=\"Title\" class=\"btn btn-outline-secondary btn-sm\" type=\"button\">\n                Title\n            </button>\n        </th>\n        <th scope=\"col\">\n            <button value=\"Description\" class=\"btn btn-outline-secondary btn-sm\" type=\"button\">\n                Description\n            </button>\n        </th>\n        <th scope=\"col\">\n            <button value=\"FileUploaded\" class=\"btn btn-outline-secondary btn-sm\" type=\"button\">\n                FileUploaded\n            </button>\n        </th>\n        \n        <th scope=\"col\"></th>\n    </tr>\n</thead>\n<tbody>";
        var ListContent = "";
        SendUsDBDiagram_TsModel_1.SendUsDBDiagramModel.SelectAllPaged(request_sendusdbdiagramSelectAllPaged).subscribe({
            next: function (newrow) {
                var _a, _b, _c, _d, _e, _f, _g, _h, _j;
                //Only works when there is data available
                if (newrow.status != 204) {
                    var response_sendusdbdiagramQuery = newrow.response;
                    //Set to default values if they are null
                    QueryString = (_a = response_sendusdbdiagramQuery.QueryString) !== null && _a !== void 0 ? _a : "";
                    ActualPageNumber = (_b = response_sendusdbdiagramQuery.ActualPageNumber) !== null && _b !== void 0 ? _b : 0;
                    RowsPerPage = (_c = response_sendusdbdiagramQuery.RowsPerPage) !== null && _c !== void 0 ? _c : 0;
                    SorterColumn = (_d = response_sendusdbdiagramQuery.SorterColumn) !== null && _d !== void 0 ? _d : "";
                    SortToggler = (_e = response_sendusdbdiagramQuery.SortToggler) !== null && _e !== void 0 ? _e : false;
                    TotalRows = (_f = response_sendusdbdiagramQuery.TotalRows) !== null && _f !== void 0 ? _f : 0;
                    TotalPages = (_g = response_sendusdbdiagramQuery.TotalPages) !== null && _g !== void 0 ? _g : 0;
                    //Query string
                    $("#fiyistack-sendusdbdiagram-query-string").attr("placeholder", "Search... (" + TotalRows + " records)");
                    //Total pages of pagination
                    $("#fiyistack-sendusdbdiagram-total-pages-lg, #fiyistack-sendusdbdiagram-total-pages").html(TotalPages.toString());
                    //Actual page number of pagination
                    $("#fiyistack-sendusdbdiagram-actual-page-number-lg, #fiyistack-sendusdbdiagram-actual-page-number").html(ActualPageNumber.toString());
                    //If we are at the final of book disable next and last buttons in pagination
                    if (ActualPageNumber === TotalPages) {
                        $("#fiyistack-sendusdbdiagram-lnk-next-page-lg, #fiyistack-sendusdbdiagram-lnk-next-page").attr("disabled", "disabled");
                        $("#fiyistack-sendusdbdiagram-lnk-last-page-lg, #fiyistack-sendusdbdiagram-lnk-last-page").attr("disabled", "disabled");
                        $("#fiyistack-sendusdbdiagram-search-more-button-in-list").html("");
                    }
                    else {
                        $("#fiyistack-sendusdbdiagram-lnk-next-page-lg, #fiyistack-sendusdbdiagram-lnk-next-page").removeAttr("disabled");
                        $("#fiyistack-sendusdbdiagram-lnk-last-page-lg, #fiyistack-sendusdbdiagram-lnk-last-page").removeAttr("disabled");
                        //Scroll arrow for list view
                        $("#fiyistack-sendusdbdiagram-search-more-button-in-list").html("<i class='fas fa-2x fa-chevron-down'></i>");
                    }
                    //If we are at the begining of the book disable previous and first buttons in pagination
                    if (ActualPageNumber === 1) {
                        $("#fiyistack-sendusdbdiagram-lnk-previous-page-lg, #fiyistack-sendusdbdiagram-lnk-previous-page").attr("disabled", "disabled");
                        $("#fiyistack-sendusdbdiagram-lnk-first-page-lg, #fiyistack-sendusdbdiagram-lnk-first-page").attr("disabled", "disabled");
                    }
                    else {
                        $("#fiyistack-sendusdbdiagram-lnk-previous-page-lg, #fiyistack-sendusdbdiagram-lnk-previous-page").removeAttr("disabled");
                        $("#fiyistack-sendusdbdiagram-lnk-first-page-lg, #fiyistack-sendusdbdiagram-lnk-first-page").removeAttr("disabled");
                    }
                    //If book is empty set to default pagination values
                    if (((_h = response_sendusdbdiagramQuery === null || response_sendusdbdiagramQuery === void 0 ? void 0 : response_sendusdbdiagramQuery.lstSendUsDBDiagramModel) === null || _h === void 0 ? void 0 : _h.length) === 0) {
                        $("#fiyistack-sendusdbdiagram-lnk-previous-page-lg, #fiyistack-sendusdbdiagram-lnk-previous-page").attr("disabled", "disabled");
                        $("#fiyistack-sendusdbdiagram-lnk-first-page-lg, #fiyistack-sendusdbdiagram-lnk-first-page").attr("disabled", "disabled");
                        $("#fiyistack-sendusdbdiagram-lnk-next-page-lg, #fiyistack-sendusdbdiagram-lnk-next-page").attr("disabled", "disabled");
                        $("#fiyistack-sendusdbdiagram-lnk-last-page-lg, #fiyistack-sendusdbdiagram-lnk-last-page").attr("disabled", "disabled");
                        $("#fiyistack-sendusdbdiagram-total-pages-lg, #fiyistack-sendusdbdiagram-total-pages").html("1");
                        $("#fiyistack-sendusdbdiagram-actual-page-number-lg, #fiyistack-sendusdbdiagram-actual-page-number").html("1");
                    }
                    //Read data book
                    (_j = response_sendusdbdiagramQuery === null || response_sendusdbdiagramQuery === void 0 ? void 0 : response_sendusdbdiagramQuery.lstSendUsDBDiagramModel) === null || _j === void 0 ? void 0 : _j.forEach(function (row) {
                        TableContent += "<tr>\n    <!-- Checkbox -->\n    <td>\n        <div>\n            <input class=\"sendusdbdiagram-table-checkbox-for-row\" value=\"" + row.SendUsDBDiagramId + "\" type=\"checkbox\">\n        </div>\n    </td>\n    <!-- Data -->\n    <td class=\"text-left text-light\">\n        <i class=\"fas fa-key\"></i> " + row.SendUsDBDiagramId + "\n    </td>\n    <td class=\"text-left\">\n        <strong>\n            <i class=\"fas fa-toggle-on\"></i> " + (row.Active == true ? "Active <i class='text-success fas fa-circle'></i>" : "Not active <i class='text-danger fas fa-circle'></i>") + "\n        </strong>\n    </td>\n    <td class=\"text-left\">\n        <strong>\n            <i class=\"fas fa-calendar\"></i> " + row.DateTimeCreation + "\n        </strong>\n    </td>\n    <td class=\"text-left\">\n        <strong>\n            <i class=\"fas fa-calendar\"></i> " + row.DateTimeLastModification + "\n        </strong>\n    </td>\n    <td class=\"text-left\">\n        <strong>\n            <i class=\"fas fa-key\"></i> " + row.UserCreationId + "\n        </strong>\n    </td>\n    <td class=\"text-left\">\n        <strong>\n            <i class=\"fas fa-key\"></i> " + row.UserLastModificationId + "\n        </strong>\n    </td>\n    <td class=\"text-left\">\n        <strong><i class=\"fas fa-font\">\n            </i> " + row.Title + "\n        </strong>\n    </td>\n    <td class=\"text-left\">\n        <i class=\"fas fa-font\"></i> " + row.Description + "\n    </td>\n    <td class=\"text-left\">\n        <a href=\"" + row.FileUploaded + "\">\n            <strong>\n                <i class=\"fas fa-file\"></i> " + row.FileUploaded + "\n            </strong>\n        </a>\n    </td>\n    \n    <!-- Actions -->\n    <td class=\"text-right\">\n        <a class=\"btn btn-icon-only text-primary\" href=\"/FiyiStack/SendUsDBDiagramNonQueryPage?SendUsDBDiagramId=" + row.SendUsDBDiagramId + "\" role=\"button\" data-toggle=\"tooltip\" data-original-title=\"Edit\">\n            <i class=\"fas fa-edit\"></i>\n        </a>\n        <div class=\"dropdown\">\n            <button class=\"btn btn-icon-only text-danger\" role=\"button\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">\n                <i class=\"fas fa-trash\"></i>\n            </button>\n            <div class=\"dropdown-menu dropdown-menu-right dropdown-menu-arrow\">\n                <button class=\"dropdown-item text-danger fiyistack-sendusdbdiagram-table-delete-button\" value=\"" + row.SendUsDBDiagramId + "\" type=\"button\">\n                    <i class=\"fas fa-exclamation-triangle\"></i> Yes, delete\n                </button>\n            </div>\n        </div>\n        <div class=\"dropdown\">\n            <button class=\"btn btn-sm btn-icon-only text-primary\" href=\"#\" type=\"button\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">\n                <i class=\"fas fa-ellipsis-v\"></i>\n            </button>\n            <div class=\"dropdown-menu dropdown-menu-right dropdown-menu-arrow\">\n                <button type=\"button\" class=\"dropdown-item fiyistack-sendusdbdiagram-table-copy-button\" value=\"" + row.SendUsDBDiagramId + "\">\n                    <i class=\"fas fa-copy text-primary\"></i>&nbsp;Copy\n                </button>\n            </div>\n        </div>\n    </td>\n</tr>";
                        ListContent += "<div class=\"row mx-2\">\n    <div class=\"col-sm\">\n        <div class=\"card bg-gradient-primary mb-2\">\n            <div class=\"card-body\">\n                <div class=\"row\">\n                    <div class=\"col text-truncate\">\n                        <span class=\"text-white text-light mb-4\">\n                           SendUsDBDiagramId <i class=\"fas fa-key\"></i> " + row.SendUsDBDiagramId + "\n                        </span>\n                        <br/>\n                        <span class=\"text-white mb-4\">\n                           Active <i class=\"fas fa-toggle-on\"></i> " + (row.Active == true ? "Active <i class='text-success fas fa-circle'></i>" : "Not active <i class='text-danger fas fa-circle'></i>") + "\n                        </span>\n                        <br/>\n                        <span class=\"text-white mb-4\">\n                           DateTimeCreation <i class=\"fas fa-calendar\"></i> " + row.DateTimeCreation + "\n                        </span>\n                        <br/>\n                        <span class=\"text-white mb-4\">\n                           DateTimeLastModification <i class=\"fas fa-calendar\"></i> " + row.DateTimeLastModification + "\n                        </span>\n                        <br/>\n                        <span class=\"text-white mb-4\">\n                           UserCreationId <i class=\"fas fa-key\"></i> " + row.UserCreationId + "\n                        </span>\n                        <br/>\n                        <span class=\"text-white mb-4\">\n                           UserLastModificationId <i class=\"fas fa-key\"></i> " + row.UserLastModificationId + "\n                        </span>\n                        <br/>\n                        <span class=\"text-white mb-4\">\n                           Title <i class=\"fas fa-font\"></i> " + row.Title + "\n                        </span>\n                        <br/>\n                        <span class=\"text-white mb-4\">\n                           Description <i class=\"fas fa-font\"></i> " + row.Description + "\n                        </span>\n                        <br/>\n                        <span class=\"text-white mb-4\">\n                           FileUploaded <i class=\"fas fa-file\"></i> " + row.FileUploaded + "\n                        </span>\n                        <br/>\n                        \n                    </div>\n                    <div class=\"col-auto\">\n                    </div>\n                </div>\n                <!-- Actions -->\n                <div class=\"row\">\n                    <div class=\"col\">\n                        <div class=\"justify-content-end text-right mt-2\">\n                            <div class=\"mb-2\">\n                                <a class=\"fiyistack-sendusdbdiagram-checkbox-list list-row-unchecked icon icon-shape bg-white icon-sm rounded-circle shadow\" href=\"javascript:void(0)\" role=\"button\" data-toggle=\"tooltip\" data-original-title=\"Check\">\n                                    <i class=\"fas fa-circle text-white\"></i>\n                                </a>\n                                <input type=\"hidden\" value=\"" + row.SendUsDBDiagramId + "\"/>\n                            </div>\n                            <a class=\"icon icon-shape bg-white icon-sm rounded-circle shadow\" href=\"/FiyiStack/SendUsDBDiagramNonQueryPage?SendUsDBDiagramId=" + row.SendUsDBDiagramId + "\" role=\"button\" data-toggle=\"tooltip\" data-original-title=\"edit\">\n                                <i class=\"fas fa-edit text-primary\"></i>\n                            </a>\n                            <div class=\"dropup\">\n                                <a class=\"icon icon-shape bg-white icon-sm text-primary rounded-circle shadow\" href=\"javascript:void(0)\" role=\"button\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">\n                                    <i class=\"fas fa-ellipsis-v\"></i>\n                                </a>\n                                <div class=\"dropdown-menu dropdown-menu-right dropdown-menu-arrow\">\n                                    <button value=\"" + row.SendUsDBDiagramId + "\" class=\"dropdown-item text-primary fiyistack-sendusdbdiagram-list-copy-button\" type=\"button\">\n                                        <i class=\"fas fa-copy\"></i>&nbsp;Copy\n                                    </button>\n                                    <button value=\"" + row.SendUsDBDiagramId + "\" class=\"dropdown-item text-danger fiyistack-sendusdbdiagram-list-delete-button\" type=\"button\">\n                                        <i class=\"fas fa-trash\"></i>&nbsp;Delete\n                                    </button>\n                                </div>\n                            </div>\n                        </div>\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n</div>";
                    });
                    //If view table is activated, clear table view, if not, clear list view
                    if (ViewToggler === "Table") {
                        $("#fiyistack-sendusdbdiagram-body-and-head-table").html("");
                        $("#fiyistack-sendusdbdiagram-body-and-head-table").html(TableContent);
                    }
                    else {
                        //Used for list view
                        if (ScrollDownNSearchFlag) {
                            $("#fiyistack-sendusdbdiagram-body-list").append(ListContent);
                            ScrollDownNSearchFlag = false;
                        }
                        else {
                            //Clear list view
                            $("#fiyistack-sendusdbdiagram-body-list").html("");
                            $("#fiyistack-sendusdbdiagram-body-list").html(ListContent);
                        }
                    }
                }
                else {
                    //ERROR
                    // @ts-ignore
                    $.notify({ icon: "fas fa-exclamation-triangle", message: "No registers found" }, { type: "warning", placement: { from: "bottom", align: "center" } });
                }
            },
            complete: function () {
                //Execute ScrollDownNSearch function when the user scroll the page
                $(window).on("scroll", ScrollDownNSearch);
                //Add final content to TableContent
                TableContent += "</tbody>\n                                </table>";
                //Check button inside list view
                $(".fiyistack-sendusdbdiagram-checkbox-list").on("click", function (e) {
                    //Toggler
                    if ($(this).hasClass("list-row-checked")) {
                        $(this).html("<a class=\"icon icon-shape bg-white icon-sm rounded-circle shadow\" href=\"javascript:void(0)\" role=\"button\" data-toggle=\"tooltip\" data-original-title=\"check\">\n                                                            <i class=\"fas fa-circle text-white\"></i>\n                                                        </a>");
                        $(this).removeClass("list-row-checked").addClass("list-row-unchecked");
                    }
                    else {
                        $(this).html("<a class=\"icon icon-shape bg-white icon-sm text-primary rounded-circle shadow\" href=\"javascript:void(0)\" role=\"button\" data-toggle=\"tooltip\" data-original-title=\"check\">\n                                                            <i class=\"fas fa-check\"></i>\n                                                        </a>");
                        $(this).removeClass("list-row-unchecked").addClass("list-row-checked");
                    }
                });
                //Check all button inside table
                $("#sendusdbdiagram-table-check-all").on("click", function (e) {
                    //Toggler
                    if ($("tr td div input.sendusdbdiagram-table-checkbox-for-row").is(":checked")) {
                        $("tr td div input.sendusdbdiagram-table-checkbox-for-row").removeAttr("checked");
                    }
                    else {
                        $("tr td div input.sendusdbdiagram-table-checkbox-for-row").attr("checked", "checked");
                    }
                });
                //Buttons inside head of table
                $("tr th button").one("click", function (e) {
                    //Toggler
                    if (SorterColumn == $(this).attr("value")) {
                        SorterColumn = "";
                        SortToggler = true;
                    }
                    else {
                        SorterColumn = $(this).attr("value");
                        SortToggler = false;
                    }
                    ValidateAndSearch();
                });
                //Delete button in table and list
                $("div.dropdown-menu button.fiyistack-sendusdbdiagram-table-delete-button, div.dropdown-menu button.fiyistack-sendusdbdiagram-list-delete-button").on("click", function (e) {
                    var SendUsDBDiagramId = $(this).val();
                    SendUsDBDiagram_TsModel_1.SendUsDBDiagramModel.DeleteBySendUsDBDiagramId(SendUsDBDiagramId).subscribe({
                        next: function (newrow) {
                        },
                        complete: function () {
                            //SUCCESS
                            // @ts-ignore
                            $.notify({ icon: "fas fa-check", message: "Row deleted successfully" }, { type: "success", placement: { from: "bottom", align: "center" } });
                            ValidateAndSearch();
                        },
                        error: function (err) {
                            //ERROR
                            // @ts-ignore
                            $.notify({ icon: "fas fa-exclamation-triangle", message: "There was an error while trying to delete data" }, { type: "danger", placement: { from: "bottom", align: "center" } });
                            console.log(err);
                        }
                    });
                });
                //Copy button in table and list
                $("div.dropdown-menu button.fiyistack-sendusdbdiagram-table-copy-button, div.dropdown-menu button.fiyistack-sendusdbdiagram-list-copy-button").on("click", function (e) {
                    var SendUsDBDiagramId = $(this).val();
                    SendUsDBDiagram_TsModel_1.SendUsDBDiagramModel.CopyBySendUsDBDiagramId(SendUsDBDiagramId).subscribe({
                        next: function (newrow) {
                        },
                        complete: function () {
                            //SUCCESS
                            // @ts-ignore
                            $.notify({ icon: "fas fa-check", message: "Row copied successfully" }, { type: "success", placement: { from: "bottom", align: "center" } });
                            ValidateAndSearch();
                        },
                        error: function (err) {
                            //ERROR
                            // @ts-ignore
                            $.notify({ icon: "fas fa-exclamation-triangle", message: "There was an error while trying to copy data" }, { type: "danger", placement: { from: "bottom", align: "center" } });
                            console.log(err);
                        }
                    });
                });
            },
            error: function (err) {
                //ERROR
                // @ts-ignore
                $.notify({ icon: "fas fa-exclamation-triangle", message: "There was an error while trying to get data" }, { type: "danger", placement: { from: "bottom", align: "center" } });
                console.log(err);
            }
        });
    };
    return SendUsDBDiagramQuery;
}());
function ValidateAndSearch() {
    var _sendusdbdiagramSelectAllPaged = {
        QueryString: QueryString,
        ActualPageNumber: ActualPageNumber,
        RowsPerPage: RowsPerPage,
        SorterColumn: SorterColumn,
        SortToggler: SortToggler,
        TotalRows: TotalRows,
        TotalPages: TotalPages
    };
    SendUsDBDiagramQuery.SelectAllPagedToHTML(_sendusdbdiagramSelectAllPaged);
}
//LOAD EVENT
if ($("#fiyistack-sendusdbdiagram-title-page").html().includes("Query sendusdbdiagram")) {
    //Set to default values
    QueryString = "";
    ActualPageNumber = 1;
    RowsPerPage = 50;
    SorterColumn = "SendUsDBDiagramId";
    SortToggler = false;
    TotalRows = 0;
    TotalPages = 0;
    ViewToggler = "List";
    //Disable first and previous links in pagination
    $("#fiyistack-sendusdbdiagram-lnk-first-page-lg, #fiyistack-sendusdbdiagram-lnk-first-page").attr("disabled", "disabled");
    $("#fiyistack-sendusdbdiagram-lnk-previous-page-lg, #fiyistack-sendusdbdiagram-lnk-previous-page").attr("disabled", "disabled");
    //Hide messages
    $("#fiyistack-sendusdbdiagram-export-message").html("");
    ValidateAndSearch();
}
//CLICK, SCROLL AND KEYBOARD EVENTS
//Search button
$($("#fiyistack-sendusdbdiagram-search-button")).on("click", function () {
    ValidateAndSearch();
});
//Query string
$("#fiyistack-sendusdbdiagram-query-string").on("change keyup input", function (e) {
    var _a, _b;
    //If undefined, set QueryString to "" value
    QueryString = (_b = ((_a = $(this).val()) === null || _a === void 0 ? void 0 : _a.toString())) !== null && _b !== void 0 ? _b : "";
    ValidateAndSearch();
});
//First page link in pagination
$("#fiyistack-sendusdbdiagram-lnk-first-page-lg, #fiyistack-sendusdbdiagram-lnk-first-page").on("click", function (e) {
    ActualPageNumber = 1;
    ValidateAndSearch();
});
//Previous page link in pagination
$("#fiyistack-sendusdbdiagram-lnk-previous-page-lg, #fiyistack-sendusdbdiagram-lnk-previous-page").on("click", function (e) {
    ActualPageNumber -= 1;
    ValidateAndSearch();
});
//Next page link in pagination
$("#fiyistack-sendusdbdiagram-lnk-next-page-lg, #fiyistack-sendusdbdiagram-lnk-next-page").on("click", function (e) {
    ActualPageNumber += 1;
    ValidateAndSearch();
});
//Last page link in pagination
$("#fiyistack-sendusdbdiagram-lnk-last-page-lg, #fiyistack-sendusdbdiagram-lnk-last-page").on("click", function (e) {
    ActualPageNumber = TotalPages;
    ValidateAndSearch();
});
//Table view button
$("#fiyistack-sendusdbdiagram-table-view-button").on("click", function (e) {
    $("#fiyistack-sendusdbdiagram-view-toggler").val("Table");
    ViewToggler = "Table";
    //Reset some values to default
    ActualPageNumber = 1;
    //Clear table view
    $("#fiyistack-sendusdbdiagram-body-and-head-table").html("");
    ValidateAndSearch();
});
//List view button
$("#fiyistack-sendusdbdiagram-list-view-button").on("click", function (e) {
    $("#fiyistack-sendusdbdiagram-view-toggler").val("List");
    ViewToggler = "List";
    //Reset some values to default
    ActualPageNumber = 1;
    //Clear list view
    $("#fiyistack-sendusdbdiagram-body-list").html("");
    ValidateAndSearch();
});
//Used to list view
function ScrollDownNSearch() {
    var _a, _b, _c, _d, _e, _f, _g, _h;
    var WindowsTopDistance = (_a = $(window).scrollTop()) !== null && _a !== void 0 ? _a : 0;
    var WindowsBottomDistance = ((_b = $(window).scrollTop()) !== null && _b !== void 0 ? _b : 0) + ((_c = $(window).innerHeight()) !== null && _c !== void 0 ? _c : 0);
    var CardsFooterTopPosition = (_e = (_d = $("#fiyistack-sendusdbdiagram-search-more-button-in-list").offset()) === null || _d === void 0 ? void 0 : _d.top) !== null && _e !== void 0 ? _e : 0;
    var CardsFooterBottomPosition = ((_g = (_f = $("#fiyistack-sendusdbdiagram-search-more-button-in-list").offset()) === null || _f === void 0 ? void 0 : _f.top) !== null && _g !== void 0 ? _g : 0) + ((_h = $("#fiyistack-sendusdbdiagram-search-more-button-in-list").outerHeight()) !== null && _h !== void 0 ? _h : 0);
    if (WindowsTopDistance > LastTopDistance) {
        //Scroll down
        if ((WindowsBottomDistance > CardsFooterTopPosition) && (WindowsTopDistance < CardsFooterBottomPosition)) {
            //Search More button visible
            if (ActualPageNumber !== TotalPages) {
                ScrollDownNSearchFlag = true;
                ActualPageNumber += 1;
                ValidateAndSearch();
            }
        }
        else { /*Card footer not visible*/ }
    }
    else { /*Scroll up*/ }
    LastTopDistance = WindowsTopDistance;
}
//Used to list view
$(window).on("scroll", ScrollDownNSearch);
//Export as PDF button
$("#fiyistack-sendusdbdiagram-export-as-pdf").on("click", function (e) {
    //There are two exportation types, All and JustChecked
    var ExportationType = "";
    var DateTimeNow;
    var Body = {};
    //Define a header for HTTP protocol with Accept (receiver data type) and Content-Type (sender data type)
    var Header = {
        'Accept': 'application/json',
        'Content-Type': 'application/json; charset=utf-8'
    };
    if ($("#fiyistack-sendusdbdiagram-export-rows-all-checkbox").is(":checked")) {
        ExportationType = "All";
    }
    else {
        ExportationType = "JustChecked";
        var CheckedRows_1 = new Array();
        if (ViewToggler == "Table") {
            $("tr td div input.sendusdbdiagram-table-checkbox-for-row:checked").each(function () {
                CheckedRows_1.push($(this).val());
            });
            Body = {
                AjaxForString: CheckedRows_1.toString()
            };
        }
        else {
            $("div .list-row-checked").each(function () {
                //With .next() we access to input type hidden
                CheckedRows_1.push($(this).next().val());
            });
            Body = {
                AjaxForString: CheckedRows_1.toString()
            };
        }
    }
    Rx.from(ajax_1.ajax.post("/api/FiyiStack/SendUsDBDiagram/1/ExportAsPDF/" + ExportationType, Body, Header)).subscribe({
        next: function (newrow) {
            $("#fiyistack-sendusdbdiagram-export-message").html("<strong>Exporting as PDF</strong>");
            DateTimeNow = newrow.response;
        },
        complete: function () {
            //SUCCESS
            // @ts-ignore
            $.notify({ icon: "fas fa-check", message: "Conversion completed" }, { type: "success", placement: { from: "bottom", align: "center" } });
            //Show download button for PDF file
            $("#fiyistack-sendusdbdiagram-export-message").html("<a class=\"btn btn-icon btn-success\" href=\"/PDFFiles/FiyiStack/SendUsDBDiagram/SendUsDBDiagram_" + DateTimeNow.AjaxForString + ".pdf\" type=\"button\" download>\n                                            <span class=\"btn-inner--icon\"><i class=\"fas fa-file-pdf\"></i></span>\n                                            <span class=\"btn-inner--text\">Download</span>\n                                        </a>");
        },
        error: function (err) {
            //ERROR
            // @ts-ignore
            $.notify({ icon: "fas fa-exclamation-triangle", message: "There was an error while trying to convert" }, { type: "danger", placement: { from: "bottom", align: "center" } });
            console.log(err);
        }
    });
});
//Export as Excel button
$("#fiyistack-sendusdbdiagram-export-as-excel").on("click", function (e) {
    //There are two exportation types, All and JustChecked
    var ExportationType = "";
    var DateTimeNow;
    var Body = {};
    //Define a header for HTTP protocol with Accept (receiver data type) and Content-Type (sender data type)
    var Header = {
        'Accept': 'application/json',
        'Content-Type': 'application/json; charset=utf-8'
    };
    if ($("#fiyistack-sendusdbdiagram-export-rows-all-checkbox").is(":checked")) {
        ExportationType = "All";
    }
    else {
        ExportationType = "JustChecked";
        var CheckedRows_2 = new Array();
        if (ViewToggler == "Table") {
            $("tr td div input.sendusdbdiagram-table-checkbox-for-row:checked").each(function () {
                CheckedRows_2.push($(this).val());
            });
            Body = {
                AjaxForString: CheckedRows_2.toString()
            };
        }
        else {
            $("div .list-row-checked").each(function () {
                //With .next() we access to input type hidden
                CheckedRows_2.push($(this).next().val());
            });
            Body = {
                AjaxForString: CheckedRows_2.toString()
            };
        }
    }
    Rx.from(ajax_1.ajax.post("/api/FiyiStack/SendUsDBDiagram/1/ExportAsExcel/" + ExportationType, Body, Header)).subscribe({
        next: function (newrow) {
            $("#fiyistack-sendusdbdiagram-export-message").html("<strong>Exporting as Excel</strong>");
            DateTimeNow = newrow.response;
        },
        complete: function () {
            //SUCCESS
            // @ts-ignore
            $.notify({ icon: "fas fa-check", message: "Conversion completed" }, { type: "success", placement: { from: "bottom", align: "center" } });
            //Show download button for Excel file
            $("#fiyistack-sendusdbdiagram-export-message").html("<a class=\"btn btn-icon btn-success\" href=\"/ExcelFiles/FiyiStack/SendUsDBDiagram/SendUsDBDiagram_" + DateTimeNow.AjaxForString + ".xlsx\" type=\"button\" download>\n                                            <span class=\"btn-inner--icon\"><i class=\"fas fa-file-excel\"></i></span>\n                                            <span class=\"btn-inner--text\">Download</span>\n                                        </a>");
        },
        error: function (err) {
            //ERROR
            // @ts-ignore
            $.notify({ icon: "fas fa-exclamation-triangle", message: "There was an error while trying to convert" }, { type: "danger", placement: { from: "bottom", align: "center" } });
            console.log(err);
        }
    });
});
//Export as CSV button
$("#fiyistack-sendusdbdiagram-export-as-csv").on("click", function (e) {
    //There are two exportation types, All and JustChecked
    var ExportationType = "";
    var DateTimeNow;
    var Body = {};
    //Define a header for HTTP protocol with Accept (receiver data type) and Content-Type (sender data type)
    var Header = {
        'Accept': 'application/json',
        'Content-Type': 'application/json; charset=utf-8'
    };
    if ($("#fiyistack-sendusdbdiagram-export-rows-all-checkbox").is(":checked")) {
        ExportationType = "All";
    }
    else {
        ExportationType = "JustChecked";
        var CheckedRows_3 = new Array();
        if (ViewToggler == "Table") {
            $("tr td div input.sendusdbdiagram-table-checkbox-for-row:checked").each(function () {
                CheckedRows_3.push($(this).val());
            });
            Body = {
                AjaxForString: CheckedRows_3.toString()
            };
        }
        else {
            $("div .list-row-checked").each(function () {
                //With .next() we access to input type hidden
                CheckedRows_3.push($(this).next().val());
            });
            Body = {
                AjaxForString: CheckedRows_3.toString()
            };
        }
    }
    Rx.from(ajax_1.ajax.post("/api/FiyiStack/SendUsDBDiagram/1/ExportAsCSV/" + ExportationType, Body, Header)).subscribe({
        next: function (newrow) {
            $("#fiyistack-sendusdbdiagram-export-message").html("<strong>Exporting as CSV</strong>");
            DateTimeNow = newrow.response;
        },
        complete: function () {
            //SUCCESS
            // @ts-ignore
            $.notify({ icon: "fas fa-check", message: "Conversion completed" }, { type: "success", placement: { from: "bottom", align: "center" } });
            //Show download button for CSV file
            $("#fiyistack-sendusdbdiagram-export-message").html("<a class=\"btn btn-icon btn-success\" href=\"/CSVFiles/FiyiStack/SendUsDBDiagram/SendUsDBDiagram_" + DateTimeNow.AjaxForString + ".csv\" type=\"button\" download>\n                                            <span class=\"btn-inner--icon\"><i class=\"fas fa-file-csv\"></i></span>\n                                            <span class=\"btn-inner--text\">Download</span>\n                                        </a>");
        },
        error: function (err) {
            //ERROR
            // @ts-ignore
            $.notify({ icon: "fas fa-exclamation-triangle", message: "There was an error while trying to convert" }, { type: "danger", placement: { from: "bottom", align: "center" } });
            console.log(err);
        }
    });
});
//Export close button in modal
$("#fiyistack-sendusdbdiagram-export-close-button").on("click", function (e) {
    $("#fiyistack-sendusdbdiagram-export-message").html("");
});
//Massive action Copy
$("#fiyistack-sendusdbdiagram-massive-action-copy").on("click", function (e) {
    //There are two deletion types, All and JustChecked
    var CopyType = "";
    var Body = {};
    if ($("#fiyistack-sendusdbdiagram-copy-rows-all-checkbox").is(":checked")) {
        CopyType = "All";
    }
    else {
        CopyType = "JustChecked";
        var CheckedRows_4 = new Array();
        if (ViewToggler == "Table") {
            $("tr td div input.sendusdbdiagram-table-checkbox-for-row:checked").each(function () {
                CheckedRows_4.push($(this).val());
            });
        }
        else {
            $("div .list-row-checked").each(function () {
                //With .next() we access to input type hidden
                CheckedRows_4.push($(this).next().val());
            });
        }
        Body = {
            AjaxForString: CheckedRows_4.toString()
        };
    }
    SendUsDBDiagram_TsModel_1.SendUsDBDiagramModel.CopyManyOrAll(CopyType, Body).subscribe({
        next: function (newrow) {
        },
        complete: function () {
            //SUCCESS
            // @ts-ignore
            $.notify({ icon: "fas fa-check", message: "Completed copy" }, { type: "success", placement: { from: "bottom", align: "center" } });
            ValidateAndSearch();
        },
        error: function (err) {
            //ERROR
            // @ts-ignore
            $.notify({ icon: "fas fa-exclamation-triangle", message: "There was an error while trying to copy" }, { type: "danger", placement: { from: "bottom", align: "center" } });
            console.log(err);
        }
    });
});
//Massive action Delete
$("#fiyistack-sendusdbdiagram-massive-action-delete").on("click", function (e) {
    //There are two deletion types, All and JustChecked
    var DeleteType = "";
    var Body = {};
    if ($("#fiyistack-sendusdbdiagram-copy-rows-all-checkbox").is(":checked")) {
        DeleteType = "All";
    }
    else {
        DeleteType = "JustChecked";
        var CheckedRows_5 = new Array();
        if (ViewToggler == "Table") {
            $("tr td div input.sendusdbdiagram-table-checkbox-for-row:checked").each(function () {
                CheckedRows_5.push($(this).val());
            });
        }
        else {
            $("div .list-row-checked").each(function () {
                //With .next() we access to input type hidden
                CheckedRows_5.push($(this).next().val());
            });
        }
        Body = {
            AjaxForString: CheckedRows_5.toString()
        };
    }
    SendUsDBDiagram_TsModel_1.SendUsDBDiagramModel.DeleteManyOrAll(DeleteType, Body).subscribe({
        next: function (newrow) {
        },
        complete: function () {
            //SUCCESS
            // @ts-ignore
            $.notify({ icon: "fas fa-check", message: "Completed deletion" }, { type: "success", placement: { from: "bottom", align: "center" } });
            ValidateAndSearch();
        },
        error: function (err) {
            //ERROR
            // @ts-ignore
            $.notify({ icon: "fas fa-exclamation-triangle", message: "There was an error while trying to delete" }, { type: "danger", placement: { from: "bottom", align: "center" } });
            console.log(err);
        }
    });
});
//# sourceMappingURL=SendUsDBDiagramQuery_jQuery.js.map