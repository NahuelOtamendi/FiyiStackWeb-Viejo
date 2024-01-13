//Import libraries to use
import { SendUsDBDiagramModel } from "../../SendUsDBDiagram/TsModels/SendUsDBDiagram_TsModel";
import { sendusdbdiagramSelectAllPaged } from "../DTOs/sendusdbdiagramSelectAllPaged";
import * as $ from "jquery";
import * as Rx from "rxjs";
import { ajax } from "rxjs/ajax";
import { Ajax } from "../../../Library/Ajax";
import "bootstrap-notify";

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
let LastTopDistance: number = 0;
let QueryString: string = "";
let ActualPageNumber: number = 1;
let RowsPerPage: number = 50;
let SorterColumn: string | undefined = "";
let SortToggler: boolean = false;
let TotalPages: number = 0;
let TotalRows: number = 0;
let ViewToggler: string = "List";
let ScrollDownNSearchFlag: boolean = false;

class SendUsDBDiagramQuery {
    static SelectAllPagedToHTML(request_sendusdbdiagramSelectAllPaged: sendusdbdiagramSelectAllPaged) {
        //Used for list view
        $(window).off("scroll");

        //Load some part of table
        var TableContent: string = `<thead class="thead-light">
    <tr>
        <th scope="col">
            <div>
                <input id="sendusdbdiagram-table-check-all" type="checkbox">
            </div>
        </th>
        <th scope="col">
            <button value="SendUsDBDiagramId" class="btn btn-outline-secondary btn-sm" type="button">
                SendUsDBDiagramId
            </button>
        </th>
        <th scope="col">
            <button value="Active" class="btn btn-outline-secondary btn-sm" type="button">
                Active
            </button>
        </th>
        <th scope="col">
            <button value="DateTimeCreation" class="btn btn-outline-secondary btn-sm" type="button">
                DateTimeCreation
            </button>
        </th>
        <th scope="col">
            <button value="DateTimeLastModification" class="btn btn-outline-secondary btn-sm" type="button">
                DateTimeLastModification
            </button>
        </th>
        <th scope="col">
            <button value="UserCreationId" class="btn btn-outline-secondary btn-sm" type="button">
                UserCreationId
            </button>
        </th>
        <th scope="col">
            <button value="UserLastModificationId" class="btn btn-outline-secondary btn-sm" type="button">
                UserLastModificationId
            </button>
        </th>
        <th scope="col">
            <button value="Title" class="btn btn-outline-secondary btn-sm" type="button">
                Title
            </button>
        </th>
        <th scope="col">
            <button value="Description" class="btn btn-outline-secondary btn-sm" type="button">
                Description
            </button>
        </th>
        <th scope="col">
            <button value="FileUploaded" class="btn btn-outline-secondary btn-sm" type="button">
                FileUploaded
            </button>
        </th>
        
        <th scope="col"></th>
    </tr>
</thead>
<tbody>`;

        var ListContent: string = ``;

        SendUsDBDiagramModel.SelectAllPaged(request_sendusdbdiagramSelectAllPaged).subscribe(
            {
                next: newrow => {
                    //Only works when there is data available
                    if (newrow.status != 204) {

                        const response_sendusdbdiagramQuery = newrow.response as sendusdbdiagramSelectAllPaged;

                        //Set to default values if they are null
                        QueryString = response_sendusdbdiagramQuery.QueryString ?? "";
                        ActualPageNumber = response_sendusdbdiagramQuery.ActualPageNumber ?? 0;
                        RowsPerPage = response_sendusdbdiagramQuery.RowsPerPage ?? 0;
                        SorterColumn = response_sendusdbdiagramQuery.SorterColumn ?? "";
                        SortToggler = response_sendusdbdiagramQuery.SortToggler ?? false;
                        TotalRows = response_sendusdbdiagramQuery.TotalRows ?? 0;
                        TotalPages = response_sendusdbdiagramQuery.TotalPages ?? 0;

                        //Query string
                        $("#fiyistack-sendusdbdiagram-query-string").attr("placeholder", `Search... (${TotalRows} records)`);
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
                        if (response_sendusdbdiagramQuery?.lstSendUsDBDiagramModel?.length === 0) {
                            $("#fiyistack-sendusdbdiagram-lnk-previous-page-lg, #fiyistack-sendusdbdiagram-lnk-previous-page").attr("disabled", "disabled");
                            $("#fiyistack-sendusdbdiagram-lnk-first-page-lg, #fiyistack-sendusdbdiagram-lnk-first-page").attr("disabled", "disabled");
                            $("#fiyistack-sendusdbdiagram-lnk-next-page-lg, #fiyistack-sendusdbdiagram-lnk-next-page").attr("disabled", "disabled");
                            $("#fiyistack-sendusdbdiagram-lnk-last-page-lg, #fiyistack-sendusdbdiagram-lnk-last-page").attr("disabled", "disabled");
                            $("#fiyistack-sendusdbdiagram-total-pages-lg, #fiyistack-sendusdbdiagram-total-pages").html("1");
                            $("#fiyistack-sendusdbdiagram-actual-page-number-lg, #fiyistack-sendusdbdiagram-actual-page-number").html("1");
                        }
                        //Read data book
                        response_sendusdbdiagramQuery?.lstSendUsDBDiagramModel?.forEach(row => {

                            TableContent += `<tr>
    <!-- Checkbox -->
    <td>
        <div>
            <input class="sendusdbdiagram-table-checkbox-for-row" value="${row.SendUsDBDiagramId}" type="checkbox">
        </div>
    </td>
    <!-- Data -->
    <td class="text-left text-light">
        <i class="fas fa-key"></i> ${row.SendUsDBDiagramId}
    </td>
    <td class="text-left">
        <strong>
            <i class="fas fa-toggle-on"></i> ${row.Active == true ? "Active <i class='text-success fas fa-circle'></i>" : "Not active <i class='text-danger fas fa-circle'></i>"}
        </strong>
    </td>
    <td class="text-left">
        <strong>
            <i class="fas fa-calendar"></i> ${row.DateTimeCreation}
        </strong>
    </td>
    <td class="text-left">
        <strong>
            <i class="fas fa-calendar"></i> ${row.DateTimeLastModification}
        </strong>
    </td>
    <td class="text-left">
        <strong>
            <i class="fas fa-key"></i> ${row.UserCreationId}
        </strong>
    </td>
    <td class="text-left">
        <strong>
            <i class="fas fa-key"></i> ${row.UserLastModificationId}
        </strong>
    </td>
    <td class="text-left">
        <strong><i class="fas fa-font">
            </i> ${row.Title}
        </strong>
    </td>
    <td class="text-left">
        <i class="fas fa-font"></i> ${row.Description}
    </td>
    <td class="text-left">
        <a href="${row.FileUploaded}">
            <strong>
                <i class="fas fa-file"></i> ${row.FileUploaded}
            </strong>
        </a>
    </td>
    
    <!-- Actions -->
    <td class="text-right">
        <a class="btn btn-icon-only text-primary" href="/FiyiStack/SendUsDBDiagramNonQueryPage?SendUsDBDiagramId=${row.SendUsDBDiagramId}" role="button" data-toggle="tooltip" data-original-title="Edit">
            <i class="fas fa-edit"></i>
        </a>
        <div class="dropdown">
            <button class="btn btn-icon-only text-danger" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                <i class="fas fa-trash"></i>
            </button>
            <div class="dropdown-menu dropdown-menu-right dropdown-menu-arrow">
                <button class="dropdown-item text-danger fiyistack-sendusdbdiagram-table-delete-button" value="${row.SendUsDBDiagramId}" type="button">
                    <i class="fas fa-exclamation-triangle"></i> Yes, delete
                </button>
            </div>
        </div>
        <div class="dropdown">
            <button class="btn btn-sm btn-icon-only text-primary" href="#" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                <i class="fas fa-ellipsis-v"></i>
            </button>
            <div class="dropdown-menu dropdown-menu-right dropdown-menu-arrow">
                <button type="button" class="dropdown-item fiyistack-sendusdbdiagram-table-copy-button" value="${row.SendUsDBDiagramId}">
                    <i class="fas fa-copy text-primary"></i>&nbsp;Copy
                </button>
            </div>
        </div>
    </td>
</tr>`;

                            ListContent += `<div class="row mx-2">
    <div class="col-sm">
        <div class="card bg-gradient-primary mb-2">
            <div class="card-body">
                <div class="row">
                    <div class="col text-truncate">
                        <span class="text-white text-light mb-4">
                           SendUsDBDiagramId <i class="fas fa-key"></i> ${row.SendUsDBDiagramId}
                        </span>
                        <br/>
                        <span class="text-white mb-4">
                           Active <i class="fas fa-toggle-on"></i> ${row.Active == true ? "Active <i class='text-success fas fa-circle'></i>" : "Not active <i class='text-danger fas fa-circle'></i>"}
                        </span>
                        <br/>
                        <span class="text-white mb-4">
                           DateTimeCreation <i class="fas fa-calendar"></i> ${row.DateTimeCreation}
                        </span>
                        <br/>
                        <span class="text-white mb-4">
                           DateTimeLastModification <i class="fas fa-calendar"></i> ${row.DateTimeLastModification}
                        </span>
                        <br/>
                        <span class="text-white mb-4">
                           UserCreationId <i class="fas fa-key"></i> ${row.UserCreationId}
                        </span>
                        <br/>
                        <span class="text-white mb-4">
                           UserLastModificationId <i class="fas fa-key"></i> ${row.UserLastModificationId}
                        </span>
                        <br/>
                        <span class="text-white mb-4">
                           Title <i class="fas fa-font"></i> ${row.Title}
                        </span>
                        <br/>
                        <span class="text-white mb-4">
                           Description <i class="fas fa-font"></i> ${row.Description}
                        </span>
                        <br/>
                        <span class="text-white mb-4">
                           FileUploaded <i class="fas fa-file"></i> ${row.FileUploaded}
                        </span>
                        <br/>
                        
                    </div>
                    <div class="col-auto">
                    </div>
                </div>
                <!-- Actions -->
                <div class="row">
                    <div class="col">
                        <div class="justify-content-end text-right mt-2">
                            <div class="mb-2">
                                <a class="fiyistack-sendusdbdiagram-checkbox-list list-row-unchecked icon icon-shape bg-white icon-sm rounded-circle shadow" href="javascript:void(0)" role="button" data-toggle="tooltip" data-original-title="Check">
                                    <i class="fas fa-circle text-white"></i>
                                </a>
                                <input type="hidden" value="${row.SendUsDBDiagramId}"/>
                            </div>
                            <a class="icon icon-shape bg-white icon-sm rounded-circle shadow" href="/FiyiStack/SendUsDBDiagramNonQueryPage?SendUsDBDiagramId=${row.SendUsDBDiagramId}" role="button" data-toggle="tooltip" data-original-title="edit">
                                <i class="fas fa-edit text-primary"></i>
                            </a>
                            <div class="dropup">
                                <a class="icon icon-shape bg-white icon-sm text-primary rounded-circle shadow" href="javascript:void(0)" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    <i class="fas fa-ellipsis-v"></i>
                                </a>
                                <div class="dropdown-menu dropdown-menu-right dropdown-menu-arrow">
                                    <button value="${row.SendUsDBDiagramId}" class="dropdown-item text-primary fiyistack-sendusdbdiagram-list-copy-button" type="button">
                                        <i class="fas fa-copy"></i>&nbsp;Copy
                                    </button>
                                    <button value="${row.SendUsDBDiagramId}" class="dropdown-item text-danger fiyistack-sendusdbdiagram-list-delete-button" type="button">
                                        <i class="fas fa-trash"></i>&nbsp;Delete
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>`;
                        })

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
                complete: () => {
                    //Execute ScrollDownNSearch function when the user scroll the page
                    $(window).on("scroll", ScrollDownNSearch);

                    //Add final content to TableContent
                    TableContent += `</tbody>
                                </table>`;

                    //Check button inside list view
                    $(".fiyistack-sendusdbdiagram-checkbox-list").on("click", function (e) {
                        //Toggler
                        if ($(this).hasClass("list-row-checked")) {
                            $(this).html(`<a class="icon icon-shape bg-white icon-sm rounded-circle shadow" href="javascript:void(0)" role="button" data-toggle="tooltip" data-original-title="check">
                                                            <i class="fas fa-circle text-white"></i>
                                                        </a>`);
                            $(this).removeClass("list-row-checked").addClass("list-row-unchecked");
                        }
                        else {
                            $(this).html(`<a class="icon icon-shape bg-white icon-sm text-primary rounded-circle shadow" href="javascript:void(0)" role="button" data-toggle="tooltip" data-original-title="check">
                                                            <i class="fas fa-check"></i>
                                                        </a>`);
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
                        let SendUsDBDiagramId = $(this).val();
                        SendUsDBDiagramModel.DeleteBySendUsDBDiagramId(SendUsDBDiagramId).subscribe({
                            next: newrow => {
                            },
                            complete: () => {
                                //SUCCESS
                                // @ts-ignore
                                $.notify({ icon: "fas fa-check", message: "Row deleted successfully" }, { type: "success", placement: { from: "bottom", align: "center" } });

                                ValidateAndSearch();
                            },
                            error: err => {
                                //ERROR
                                // @ts-ignore
                                $.notify({ icon: "fas fa-exclamation-triangle", message: "There was an error while trying to delete data" }, { type: "danger", placement: { from: "bottom", align: "center" } });
                                console.log(err);
                            }
                        });
                    });

                    //Copy button in table and list
                    $("div.dropdown-menu button.fiyistack-sendusdbdiagram-table-copy-button, div.dropdown-menu button.fiyistack-sendusdbdiagram-list-copy-button").on("click", function (e) {
                        let SendUsDBDiagramId = $(this).val();
                        SendUsDBDiagramModel.CopyBySendUsDBDiagramId(SendUsDBDiagramId).subscribe({
                            next: newrow => {
                            },
                            complete: () => {
                                //SUCCESS
                                // @ts-ignore
                                $.notify({ icon: "fas fa-check", message: "Row copied successfully" }, { type: "success", placement: { from: "bottom", align: "center" } });

                                ValidateAndSearch();
                            },
                            error: err => {
                                //ERROR
                                // @ts-ignore
                                $.notify({ icon: "fas fa-exclamation-triangle", message: "There was an error while trying to copy data" }, { type: "danger", placement: { from: "bottom", align: "center" } });
                                console.log(err);
                            }
                        });
                    });
                },
                error: err => {
                    //ERROR
                    // @ts-ignore
                    $.notify({ icon: "fas fa-exclamation-triangle", message: "There was an error while trying to get data" }, { type: "danger", placement: { from: "bottom", align: "center" } });
                    console.log(err);
                }
            });
    }
}

function ValidateAndSearch() {

    var _sendusdbdiagramSelectAllPaged: sendusdbdiagramSelectAllPaged = {
        QueryString,
        ActualPageNumber,
        RowsPerPage,
        SorterColumn,
        SortToggler,
        TotalRows,
        TotalPages
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
    //If undefined, set QueryString to "" value
    QueryString = ($(this).val()?.toString()) ?? "" ;
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
    let WindowsTopDistance: number = $(window).scrollTop() ?? 0;
    let WindowsBottomDistance: number = ($(window).scrollTop() ?? 0) + ($(window).innerHeight() ?? 0);
    let CardsFooterTopPosition: number = $("#fiyistack-sendusdbdiagram-search-more-button-in-list").offset()?.top ?? 0;
    let CardsFooterBottomPosition: number = ($("#fiyistack-sendusdbdiagram-search-more-button-in-list").offset()?.top ?? 0) + ($("#fiyistack-sendusdbdiagram-search-more-button-in-list").outerHeight() ?? 0);

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
    let ExportationType: string = "";
    let DateTimeNow: Ajax;
    let Body: Ajax = {};
    //Define a header for HTTP protocol with Accept (receiver data type) and Content-Type (sender data type)
    let Header: any = {
        'Accept': 'application/json',
        'Content-Type': 'application/json; charset=utf-8'
    };

    if ($("#fiyistack-sendusdbdiagram-export-rows-all-checkbox").is(":checked")) {
        ExportationType = "All";
    }
    else{
        ExportationType = "JustChecked";
        let CheckedRows = new Array();

        if (ViewToggler == "Table") {
            $("tr td div input.sendusdbdiagram-table-checkbox-for-row:checked").each(function () {
                CheckedRows.push($(this).val());
            });

            Body = {
                AjaxForString: CheckedRows.toString()
            };
        }
        else {
            $("div .list-row-checked").each(function () {
                //With .next() we access to input type hidden
                CheckedRows.push($(this).next().val());
            });

            Body = {
                AjaxForString: CheckedRows.toString()
            };
        }
    }

    Rx.from(ajax.post("/api/FiyiStack/SendUsDBDiagram/1/ExportAsPDF/" + ExportationType, Body, Header)).subscribe({
        next: newrow => {
            $("#fiyistack-sendusdbdiagram-export-message").html("<strong>Exporting as PDF</strong>");
            DateTimeNow = newrow.response as Ajax;
        },
        complete: () => {
            //SUCCESS
            // @ts-ignore
            $.notify({ icon: "fas fa-check", message: "Conversion completed" }, { type: "success", placement: { from: "bottom", align: "center" } });

            //Show download button for PDF file
            $("#fiyistack-sendusdbdiagram-export-message").html(`<a class="btn btn-icon btn-success" href="/PDFFiles/FiyiStack/SendUsDBDiagram/SendUsDBDiagram_${DateTimeNow.AjaxForString}.pdf" type="button" download>
                                            <span class="btn-inner--icon"><i class="fas fa-file-pdf"></i></span>
                                            <span class="btn-inner--text">Download</span>
                                        </a>`);

        },
        error: err => {
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
    let ExportationType: string = "";
    let DateTimeNow: Ajax;
    let Body: Ajax = {};
    //Define a header for HTTP protocol with Accept (receiver data type) and Content-Type (sender data type)
    let Header: any = {
        'Accept': 'application/json',
        'Content-Type': 'application/json; charset=utf-8'
    };

    if ($("#fiyistack-sendusdbdiagram-export-rows-all-checkbox").is(":checked")) {
        ExportationType = "All";
    }
    else {
        ExportationType = "JustChecked";
        let CheckedRows = new Array();

        if (ViewToggler == "Table") {
            $("tr td div input.sendusdbdiagram-table-checkbox-for-row:checked").each(function () {
                CheckedRows.push($(this).val());
            });

            Body = {
                AjaxForString: CheckedRows.toString()
            };
        }
        else {
            $("div .list-row-checked").each(function () {
                //With .next() we access to input type hidden
                CheckedRows.push($(this).next().val());
            });

            Body = {
                AjaxForString: CheckedRows.toString()
            };
        }
    }

    Rx.from(ajax.post("/api/FiyiStack/SendUsDBDiagram/1/ExportAsExcel/" + ExportationType, Body, Header)).subscribe({
        next: newrow => {
            $("#fiyistack-sendusdbdiagram-export-message").html("<strong>Exporting as Excel</strong>");
            DateTimeNow = newrow.response as Ajax;
        },
        complete: () => {
            //SUCCESS
            // @ts-ignore
            $.notify({ icon: "fas fa-check", message: "Conversion completed" }, { type: "success", placement: { from: "bottom", align: "center" } });

            //Show download button for Excel file
            $("#fiyistack-sendusdbdiagram-export-message").html(`<a class="btn btn-icon btn-success" href="/ExcelFiles/FiyiStack/SendUsDBDiagram/SendUsDBDiagram_${DateTimeNow.AjaxForString}.xlsx" type="button" download>
                                            <span class="btn-inner--icon"><i class="fas fa-file-excel"></i></span>
                                            <span class="btn-inner--text">Download</span>
                                        </a>`);
        },
        error: err => {
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
    let ExportationType: string = "";
    let DateTimeNow: Ajax;
    let Body: Ajax = {};
    //Define a header for HTTP protocol with Accept (receiver data type) and Content-Type (sender data type)
    let Header: any = {
        'Accept': 'application/json',
        'Content-Type': 'application/json; charset=utf-8'
    };

    if ($("#fiyistack-sendusdbdiagram-export-rows-all-checkbox").is(":checked")) {
        ExportationType = "All";
    }
    else {
        ExportationType = "JustChecked";
        let CheckedRows = new Array();

        if (ViewToggler == "Table") {
            $("tr td div input.sendusdbdiagram-table-checkbox-for-row:checked").each(function () {
                CheckedRows.push($(this).val());
            });

            Body = {
                AjaxForString: CheckedRows.toString()
            };
        }
        else {
            $("div .list-row-checked").each(function () {
                //With .next() we access to input type hidden
                CheckedRows.push($(this).next().val());
            });

            Body = {
                AjaxForString: CheckedRows.toString()
            };
        }
    }

    Rx.from(ajax.post("/api/FiyiStack/SendUsDBDiagram/1/ExportAsCSV/" + ExportationType, Body, Header)).subscribe({
        next: newrow => {
            $("#fiyistack-sendusdbdiagram-export-message").html("<strong>Exporting as CSV</strong>");
            DateTimeNow = newrow.response as Ajax;
        },
        complete: () => {
            //SUCCESS
            // @ts-ignore
            $.notify({ icon: "fas fa-check", message: "Conversion completed" }, { type: "success", placement: { from: "bottom", align: "center" } });

            //Show download button for CSV file
            $("#fiyistack-sendusdbdiagram-export-message").html(`<a class="btn btn-icon btn-success" href="/CSVFiles/FiyiStack/SendUsDBDiagram/SendUsDBDiagram_${DateTimeNow.AjaxForString}.csv" type="button" download>
                                            <span class="btn-inner--icon"><i class="fas fa-file-csv"></i></span>
                                            <span class="btn-inner--text">Download</span>
                                        </a>`);
        },
        error: err => {
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
    let CopyType: string = "";
    let Body: Ajax = {};

    if ($("#fiyistack-sendusdbdiagram-copy-rows-all-checkbox").is(":checked")) {
        CopyType = "All";
    }
    else {
        CopyType = "JustChecked";
        let CheckedRows = new Array();

        if (ViewToggler == "Table") {
            $("tr td div input.sendusdbdiagram-table-checkbox-for-row:checked").each(function () {
                CheckedRows.push($(this).val());
            });
        }
        else {
            $("div .list-row-checked").each(function () {
                //With .next() we access to input type hidden
                CheckedRows.push($(this).next().val());
            });
        }
        Body = {
            AjaxForString: CheckedRows.toString()
        };
    }

    SendUsDBDiagramModel.CopyManyOrAll(CopyType, Body).subscribe({
        next: newrow => {
        },
        complete: () => {
            //SUCCESS
            // @ts-ignore
            $.notify({ icon: "fas fa-check", message: "Completed copy" }, { type: "success", placement: { from: "bottom", align: "center" } });

            ValidateAndSearch();
        },
        error: err => {
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
    let DeleteType: string = "";
    let Body: Ajax = {};

    if ($("#fiyistack-sendusdbdiagram-copy-rows-all-checkbox").is(":checked")) {
        DeleteType = "All";
    }
    else {
        DeleteType = "JustChecked";
        let CheckedRows = new Array();

        if (ViewToggler == "Table") {
            $("tr td div input.sendusdbdiagram-table-checkbox-for-row:checked").each(function () {
                CheckedRows.push($(this).val());
            });
        }
        else {
            $("div .list-row-checked").each(function () {
                //With .next() we access to input type hidden
                CheckedRows.push($(this).next().val());
            });
        }
        Body = {
            AjaxForString: CheckedRows.toString()
        };
    }

    SendUsDBDiagramModel.DeleteManyOrAll(DeleteType, Body).subscribe({
        next: newrow => {
        },
        complete: () => {
            //SUCCESS
            // @ts-ignore
            $.notify({ icon: "fas fa-check", message: "Completed deletion" }, { type: "success", placement: { from: "bottom", align: "center" } });

            ValidateAndSearch();
        },
        error: err => {
            //ERROR
            // @ts-ignore
            $.notify({ icon: "fas fa-exclamation-triangle", message: "There was an error while trying to delete" }, { type: "danger", placement: { from: "bottom", align: "center" } });
            console.log(err);
        }
    });
});