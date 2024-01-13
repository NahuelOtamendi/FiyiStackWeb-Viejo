//Import libraries to use
import { RoleMenuModel } from "../../RoleMenu/TsModels/RoleMenu_TsModel";
import { rolemenuSelectAllPaged } from "../DTOs/rolemenuSelectAllPaged";
import * as $ from "jquery";
import * as Rx from "rxjs";
import { ajax } from "rxjs/ajax";
import { Ajax } from "../../../Library/Ajax";

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

//Stack: 10

//Last modification on: 21/12/2022 11:04:02

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

class RoleMenuQuery {
    static SelectAllPagedToHTML(request_rolemenuSelectAllPaged: rolemenuSelectAllPaged) {
        //Used for list view
        $(window).off("scroll");

        //Load some part of table
        var TableContent: string = `<thead class="thead-light">
    <tr>
        <th scope="col">
            <div>
                <input id="rolemenu-table-check-all" type="checkbox">
            </div>
        </th>
        <th scope="col">
            <button value="RoleMenuId" class="btn btn-outline-secondary btn-sm" type="button">
                RoleMenuId
            </button>
        </th>
        <th scope="col">
            <button value="RoleId" class="btn btn-outline-secondary btn-sm" type="button">
                RoleId
            </button>
        </th>
        <th scope="col">
            <button value="MenuId" class="btn btn-outline-secondary btn-sm" type="button">
                MenuId
            </button>
        </th>
        <th scope="col">
            <button value="Active" class="btn btn-outline-secondary btn-sm" type="button">
                Active
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
            <button value="DateTimeCreation" class="btn btn-outline-secondary btn-sm" type="button">
                DateTimeCreation
            </button>
        </th>
        <th scope="col">
            <button value="DateTimeLastModification" class="btn btn-outline-secondary btn-sm" type="button">
                DateTimeLastModification
            </button>
        </th>
        
        <th scope="col"></th>
    </tr>
</thead>
<tbody>`;

        var ListContent: string = ``;

        RoleMenuModel.SelectAllPaged(request_rolemenuSelectAllPaged).subscribe(
            {
                next: newrow => {
                    //Only works when there is data available
                    if (newrow.status != 204) {

                        const response_rolemenuQuery = newrow.response as rolemenuSelectAllPaged;

                        //Set to default values if they are null
                        QueryString = response_rolemenuQuery.QueryString ?? "";
                        ActualPageNumber = response_rolemenuQuery.ActualPageNumber ?? 0;
                        RowsPerPage = response_rolemenuQuery.RowsPerPage ?? 0;
                        SorterColumn = response_rolemenuQuery.SorterColumn ?? "";
                        SortToggler = response_rolemenuQuery.SortToggler ?? false;
                        TotalRows = response_rolemenuQuery.TotalRows ?? 0;
                        TotalPages = response_rolemenuQuery.TotalPages ?? 0;

                        //Query string
                        $("#cmscore-rolemenu-query-string").attr("placeholder", `Search... (${TotalRows} records)`);
                        //Total pages of pagination
                        $("#cmscore-rolemenu-total-pages-lg, #cmscore-rolemenu-total-pages").html(TotalPages.toString());
                        //Actual page number of pagination
                        $("#cmscore-rolemenu-actual-page-number-lg, #cmscore-rolemenu-actual-page-number").html(ActualPageNumber.toString());
                        //If we are at the final of book disable next and last buttons in pagination
                        if (ActualPageNumber === TotalPages) {
                            $("#cmscore-rolemenu-lnk-next-page-lg, #cmscore-rolemenu-lnk-next-page").attr("disabled", "disabled");
                            $("#cmscore-rolemenu-lnk-last-page-lg, #cmscore-rolemenu-lnk-last-page").attr("disabled", "disabled");
                            $("#cmscore-rolemenu-search-more-button-in-list").html("");
                        }
                        else {
                            $("#cmscore-rolemenu-lnk-next-page-lg, #cmscore-rolemenu-lnk-next-page").removeAttr("disabled");
                            $("#cmscore-rolemenu-lnk-last-page-lg, #cmscore-rolemenu-lnk-last-page").removeAttr("disabled");
                            //Scroll arrow for list view
                            $("#cmscore-rolemenu-search-more-button-in-list").html("<i class='fas fa-2x fa-chevron-down'></i>");
                        }
                        //If we are at the begining of the book disable previous and first buttons in pagination
                        if (ActualPageNumber === 1) {
                            $("#cmscore-rolemenu-lnk-previous-page-lg, #cmscore-rolemenu-lnk-previous-page").attr("disabled", "disabled");
                            $("#cmscore-rolemenu-lnk-first-page-lg, #cmscore-rolemenu-lnk-first-page").attr("disabled", "disabled");
                        }
                        else {
                            $("#cmscore-rolemenu-lnk-previous-page-lg, #cmscore-rolemenu-lnk-previous-page").removeAttr("disabled");
                            $("#cmscore-rolemenu-lnk-first-page-lg, #cmscore-rolemenu-lnk-first-page").removeAttr("disabled");
                        }
                        //If book is empty set to default pagination values
                        if (response_rolemenuQuery?.lstRoleMenuModel?.length === 0) {
                            $("#cmscore-rolemenu-lnk-previous-page-lg, #cmscore-rolemenu-lnk-previous-page").attr("disabled", "disabled");
                            $("#cmscore-rolemenu-lnk-first-page-lg, #cmscore-rolemenu-lnk-first-page").attr("disabled", "disabled");
                            $("#cmscore-rolemenu-lnk-next-page-lg, #cmscore-rolemenu-lnk-next-page").attr("disabled", "disabled");
                            $("#cmscore-rolemenu-lnk-last-page-lg, #cmscore-rolemenu-lnk-last-page").attr("disabled", "disabled");
                            $("#cmscore-rolemenu-total-pages-lg, #cmscore-rolemenu-total-pages").html("1");
                            $("#cmscore-rolemenu-actual-page-number-lg, #cmscore-rolemenu-actual-page-number").html("1");
                        }
                        //Read data book
                        response_rolemenuQuery?.lstRoleMenuModel?.forEach(row => {

                            TableContent += `<tr>
    <!-- Checkbox -->
    <td>
        <div>
            <input class="rolemenu-table-checkbox-for-row" value="${row.RoleMenuId}" type="checkbox">
        </div>
    </td>
    <!-- Data -->
    <td class="text-left text-light">
        <i class="fas fa-key"></i> ${row.RoleMenuId}
    </td>
    <td class="text-left">
        <strong>
            <i class="fas fa-key"></i> ${row.RoleId}
        </strong>
    </td>
    <td class="text-left">
        <strong>
            <i class="fas fa-key"></i> ${row.MenuId}
        </strong>
    </td>
    <td class="text-left">
        <strong>
            <i class="fas fa-toggle-on"></i> ${row.Active == true ? "Active <i class='text-success fas fa-circle'></i>" : "Not active <i class='text-danger fas fa-circle'></i>"}
        </strong>
    </td>
    <td class="text-left">
        <strong><i class="fas fa-divide">
            </i> ${row.UserCreationId}
        </strong>
    </td>
    <td class="text-left">
        <strong><i class="fas fa-divide">
            </i> ${row.UserLastModificationId}
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
    
    <!-- Actions -->
    <td class="text-right">
        <a class="btn btn-icon-only text-primary" href="/CMSCore/PageRoleMenuNonQuery?RoleMenuId=${row.RoleMenuId}" role="button" data-toggle="tooltip" data-original-title="Edit">
            <i class="fas fa-edit"></i>
        </a>
        <div class="dropdown">
            <button class="btn btn-icon-only text-danger" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                <i class="fas fa-trash"></i>
            </button>
            <div class="dropdown-menu dropdown-menu-right dropdown-menu-arrow">
                <button class="dropdown-item text-danger cmscore-rolemenu-table-delete-button" value="${row.RoleMenuId}" type="button">
                    <i class="fas fa-exclamation-triangle"></i> Yes, delete
                </button>
            </div>
        </div>
        <div class="dropdown">
            <button class="btn btn-sm btn-icon-only text-primary" href="#" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                <i class="fas fa-ellipsis-v"></i>
            </button>
            <div class="dropdown-menu dropdown-menu-right dropdown-menu-arrow">
                <button type="button" class="dropdown-item cmscore-rolemenu-table-copy-button" value="${row.RoleMenuId}">
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
                           RoleMenuId <i class="fas fa-key"></i> ${row.RoleMenuId}
                        </span>
                        <br/>
                        <span class="text-white mb-4">
                           RoleId <i class="fas fa-key"></i> ${row.RoleId}
                        </span>
                        <br/>
                        <span class="text-white mb-4">
                           MenuId <i class="fas fa-key"></i> ${row.MenuId}
                        </span>
                        <br/>
                        <span class="text-white mb-4">
                           Active <i class="fas fa-toggle-on"></i> ${row.Active == true ? "Active <i class='text-success fas fa-circle'></i>" : "Not active <i class='text-danger fas fa-circle'></i>"}
                        </span>
                        <br/>
                        <span class="text-white mb-4">
                            UserCreationId <i class="fas fa-divide"></i> ${row.UserCreationId}
                        </span>
                        <br/>
                        <span class="text-white mb-4">
                            UserLastModificationId <i class="fas fa-divide"></i> ${row.UserLastModificationId}
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
                        
                    </div>
                    <div class="col-auto">
                    </div>
                </div>
                <!-- Actions -->
                <div class="row">
                    <div class="col">
                        <div class="justify-content-end text-right mt-2">
                            <div class="cmscore-rolemenu-checkbox-list list-row-unchecked mb-2">
                                <a class="icon icon-shape bg-white icon-sm rounded-circle shadow" href="javascript:void(0)" role="button" data-toggle="tooltip" data-original-title="check">
                                    <i class="fas fa-circle text-white"></i>
                                </a>
                            </div>
                            <input type="hidden" value="${row.RoleMenuId}"/>
                            <a class="icon icon-shape bg-white icon-sm rounded-circle shadow" href="/CMSCore/PageRoleMenuNonQuery?RoleMenuId=${row.RoleMenuId}" role="button" data-toggle="tooltip" data-original-title="edit">
                                <i class="fas fa-edit text-primary"></i>
                            </a>
                            <div class="dropup">
                                <a class="icon icon-shape bg-white icon-sm text-primary rounded-circle shadow" href="javascript:void(0)" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    <i class="fas fa-ellipsis-v"></i>
                                </a>
                                <div class="dropdown-menu dropdown-menu-right dropdown-menu-arrow">
                                    <button value="${row.RoleMenuId}" class="dropdown-item text-primary cmscore-rolemenu-list-copy-button" type="button">
                                        <i class="fas fa-copy"></i>&nbsp;Copy
                                    </button>
                                    <button value="${row.RoleMenuId}" class="dropdown-item text-danger cmscore-rolemenu-list-delete-button" type="button">
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
                            $("#cmscore-rolemenu-body-and-head-table").html("");
                            $("#cmscore-rolemenu-body-and-head-table").html(TableContent);
                        }
                        else {
                            //Used for list view
                            if (ScrollDownNSearchFlag) {
                                $("#cmscore-rolemenu-body-list").append(ListContent);
                                ScrollDownNSearchFlag = false;
                            }
                            else {
                                //Clear list view
                                $("#cmscore-rolemenu-body-list").html("");
                                $("#cmscore-rolemenu-body-list").html(ListContent);
                            }
                            }
                    }
                    else {
                        //Show error message
                        $("#cmscore-rolemenu-error-message-title").html("No registers found");
                        $("#cmscore-rolemenu-error-message-text").html("The server did not found any register. HTTP code 204");
                        $("#cmscore-rolemenu-button-error-message-in-card").show();
                    }
                },
                complete: () => {
                    //Execute ScrollDownNSearch function when the user scroll the page
                    $(window).on("scroll", ScrollDownNSearch);

                    //Add final content to TableContent
                    TableContent += `</tbody>
                                </table>`;

                    //Check button inside list view
                    $(".cmscore-rolemenu-checkbox-list").on("click", function (e) {
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
                    $("#rolemenu-table-check-all").on("click", function (e) { 
                        //Toggler
                        if ($("tr td div input.rolemenu-table-checkbox-for-row").is(":checked")) {
                            $("tr td div input.rolemenu-table-checkbox-for-row").removeAttr("checked");
                        }
                        else {
                            $("tr td div input.rolemenu-table-checkbox-for-row").attr("checked", "checked");
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

                    //Hide error message
                    $("#cmscore-rolemenu-error-message-title").html("");
                    $("#cmscore-rolemenu-error-message-text").html("");
                    $("#cmscore-rolemenu-button-error-message-in-card").hide();

                    //Delete button in table and list
                    $("div.dropdown-menu button.cmscore-rolemenu-table-delete-button, div.dropdown-menu button.cmscore-rolemenu-list-delete-button").on("click", function (e) {
                        let RoleMenuId = $(this).val();
                        RoleMenuModel.DeleteByRoleMenuId(RoleMenuId).subscribe({
                            next: newrow => {
                            },
                            complete: () => {
                                ValidateAndSearch();

                                //Show OK message
                                $("#cmscore-rolemenu-button-error-message-in-card").hide();
                                $("#cmscore-rolemenu-button-ok-message-in-card").html(`<strong>
                                                                    <i class="fas fa-check"></i>
                                                                </strong> Row deleted successfully`);
                                $("#cmscore-rolemenu-button-ok-message-in-card").show();
                            },
                            error: err => {
                                //Related to error message
                                $("#cmscore-rolemenu-error-message-title").html("RoleMenuModel.DeleteByRoleMenuId(RoleMenuId).subscribe(...)");
                                $("#cmscore-rolemenu-error-message-text").html(err);
                                $("#cmscore-rolemenu-button-error-message-in-card").show();
                            }
                        });
                    });

                    //Copy button in table and list
                    $("div.dropdown-menu button.cmscore-rolemenu-table-copy-button, div.dropdown-menu button.cmscore-rolemenu-list-copy-button").on("click", function (e) {
                        let RoleMenuId = $(this).val();
                        RoleMenuModel.CopyByRoleMenuId(RoleMenuId).subscribe({
                            next: newrow => {
                            },
                            complete: () => {
                                ValidateAndSearch();

                                //Show OK message
                                $("#cmscore-rolemenu-button-error-message-in-card").hide();
                                $("#cmscore-rolemenu-button-ok-message-in-card").html(`<strong>
                                                                    <i class="fas fa-check"></i>
                                                                </strong> Row copied successfully`);
                                $("#cmscore-rolemenu-button-ok-message-in-card").show();
                            },
                            error: err => {
                                //Show error message
                                $("#cmscore-rolemenu-error-message-title").html("RoleMenuModel.CopyByRoleMenuId(RoleMenuId).subscribe(...)");
                                $("#cmscore-rolemenu-error-message-text").html(err);
                                $("#cmscore-rolemenu-button-error-message-in-card").show();
                            }
                        });
                    });
                },
                error: err => {
                    //Show error message
                    $("#cmscore-rolemenu-error-message-title").html("RoleMenuModel.SelectAllPaged(request_rolemenumodelQ).subscribe(...)");
                    $("#cmscore-rolemenu-error-message-text").html(err);
                    $("#cmscore-rolemenu-button-error-message-in-card").show();
                }
            });
    }
}

function ValidateAndSearch() {

    //Hide error and OK message button
    $("#cmscore-rolemenu-button-error-message-in-card").hide();
    $("#cmscore-rolemenu-button-ok-message-in-card").hide();

    var _rolemenuSelectAllPaged: rolemenuSelectAllPaged = {
        QueryString,
        ActualPageNumber,
        RowsPerPage,
        SorterColumn,
        SortToggler,
        TotalRows,
        TotalPages
    };

    RoleMenuQuery.SelectAllPagedToHTML(_rolemenuSelectAllPaged);
}

//LOAD EVENT
if ($("#cmscore-rolemenu-title-page").html().includes("Query rolemenu")) {
    //Set to default values
    QueryString = "";
    ActualPageNumber = 1;
    RowsPerPage = 50;
    SorterColumn = "RoleMenuId";
    SortToggler = false;
    TotalRows = 0;
    TotalPages = 0;
    ViewToggler = "List";
    //Disable first and previous links in pagination
    $("#cmscore-rolemenu-lnk-first-page-lg, #cmscore-rolemenu-lnk-first-page").attr("disabled", "disabled");
    $("#cmscore-rolemenu-lnk-previous-page-lg, #cmscore-rolemenu-lnk-previous-page").attr("disabled", "disabled");
    //Hide messages
    $("#cmscore-rolemenu-export-message").html("");
    $("#cmscore-rolemenu-button-error-message-in-card").hide();
    $("#cmscore-rolemenu-button-ok-message-in-card").hide();

    ValidateAndSearch();
}
//CLICK, SCROLL AND KEYBOARD EVENTS
//Search button
$($("#cmscore-rolemenu-search-button")).on("click", function () {
    ValidateAndSearch();
});

//Query string
$("#cmscore-rolemenu-query-string").on("change keyup input", function (e) {
    //If undefined, set QueryString to "" value
    QueryString = ($(this).val()?.toString()) ?? "" ;
    ValidateAndSearch();
});

//First page link in pagination
$("#cmscore-rolemenu-lnk-first-page-lg, #cmscore-rolemenu-lnk-first-page").on("click", function (e) {
    ActualPageNumber = 1;
    ValidateAndSearch();
});

//Previous page link in pagination
$("#cmscore-rolemenu-lnk-previous-page-lg, #cmscore-rolemenu-lnk-previous-page").on("click", function (e) {
    ActualPageNumber -= 1;
    ValidateAndSearch();
});

//Next page link in pagination
$("#cmscore-rolemenu-lnk-next-page-lg, #cmscore-rolemenu-lnk-next-page").on("click", function (e) {
    ActualPageNumber += 1;
    ValidateAndSearch();
});

//Last page link in pagination
$("#cmscore-rolemenu-lnk-last-page-lg, #cmscore-rolemenu-lnk-last-page").on("click", function (e) {
    ActualPageNumber = TotalPages;
    ValidateAndSearch();
});

//Table view button
$("#cmscore-rolemenu-table-view-button").on("click", function (e) {
    $("#cmscore-rolemenu-view-toggler").val("Table");
    ViewToggler = "Table";
    //Reset some values to default
    ActualPageNumber = 1;
    //Clear table view
    $("#cmscore-rolemenu-body-and-head-table").html("");
    ValidateAndSearch();
});

//List view button
$("#cmscore-rolemenu-list-view-button").on("click", function (e) {
    $("#cmscore-rolemenu-view-toggler").val("List");
    ViewToggler = "List";
    //Reset some values to default
    ActualPageNumber = 1;
    //Clear list view
    $("#cmscore-rolemenu-body-list").html("");
    ValidateAndSearch();
});

//Used to list view
function ScrollDownNSearch() {
    let WindowsTopDistance: number = $(window).scrollTop() ?? 0;
    let WindowsBottomDistance: number = ($(window).scrollTop() ?? 0) + ($(window).innerHeight() ?? 0);
    let CardsFooterTopPosition: number = $("#cmscore-rolemenu-search-more-button-in-list").offset()?.top ?? 0;
    let CardsFooterBottomPosition: number = ($("#cmscore-rolemenu-search-more-button-in-list").offset()?.top ?? 0) + ($("#cmscore-rolemenu-search-more-button-in-list").outerHeight() ?? 0);

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
$("#cmscore-rolemenu-export-as-pdf").on("click", function (e) {
    //There are two exportation types, All and JustChecked
    let ExportationType: string = "";
    let DateTimeNow: Ajax;
    let Body: Ajax = {};
    //Define a header for HTTP protocol with Accept (receiver data type) and Content-Type (sender data type)
    let Header: any = {
        'Accept': 'application/json',
        'Content-Type': 'application/json; charset=utf-8'
    };

    if ($("#cmscore-rolemenu-export-rows-all-checkbox").is(":checked")) {
        ExportationType = "All";
    }
    else{
        ExportationType = "JustChecked";
        let CheckedRows = new Array();

        if (ViewToggler == "Table") {
            $("tr td div input.rolemenu-table-checkbox-for-row:checked").each(function () {
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

    Rx.from(ajax.post("/api/CMSCore/RoleMenu/1/ExportAsPDF/" + ExportationType, Body, Header)).subscribe({
        next: newrow => {
            $("#cmscore-rolemenu-export-message").html("<strong>Exporting as PDF</strong>");
            DateTimeNow = newrow.response as Ajax;
        },
        complete: () => {
            //Show download button for PDF file
            $("#cmscore-rolemenu-export-message").html(`<a class="btn btn-icon btn-success" href="/PDFFiles/CMSCore/RoleMenu/RoleMenu_${DateTimeNow.AjaxForString}.pdf" type="button" download>
                                            <span class="btn-inner--icon"><i class="fas fa-file-pdf"></i></span>
                                            <span class="btn-inner--text">Download</span>
                                        </a>`);

            //Show OK message
            $("#cmscore-rolemenu-button-ok-message-in-card").html(`<strong>
                                                                    <i class="fas fa-check"></i>
                                                                </strong> Conversion completed`);
            $("#cmscore-rolemenu-button-ok-message-in-card").show();
        },
        error: err => {
            //Show error message
            $("#cmscore-rolemenu-error-message-title").html("Rx.from(ajax.post('/api/CMSCore/RoleMenu/1/ExportAsPDF/' + ExportationType, Body, Header)).subscribe(...)");
            $("#cmscore-rolemenu-error-message-text").html(err);
            $("#cmscore-rolemenu-button-error-message-in-card").show();
        }
    });
});

//Export as Excel button
$("#cmscore-rolemenu-export-as-excel").on("click", function (e) {
    //There are two exportation types, All and JustChecked
    let ExportationType: string = "";
    let DateTimeNow: Ajax;
    let Body: Ajax = {};
    //Define a header for HTTP protocol with Accept (receiver data type) and Content-Type (sender data type)
    let Header: any = {
        'Accept': 'application/json',
        'Content-Type': 'application/json; charset=utf-8'
    };

    if ($("#cmscore-rolemenu-export-rows-all-checkbox").is(":checked")) {
        ExportationType = "All";
    }
    else {
        ExportationType = "JustChecked";
        let CheckedRows = new Array();

        if (ViewToggler == "Table") {
            $("tr td div input.rolemenu-table-checkbox-for-row:checked").each(function () {
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

    Rx.from(ajax.post("/api/CMSCore/RoleMenu/1/ExportAsExcel/" + ExportationType, Body, Header)).subscribe({
        next: newrow => {
            $("#cmscore-rolemenu-export-message").html("<strong>Exporting as Excel</strong>");
            DateTimeNow = newrow.response as Ajax;
        },
        complete: () => {
            //Show download button for Excel file
            $("#cmscore-rolemenu-export-message").html(`<a class="btn btn-icon btn-success" href="/ExcelFiles/CMSCore/RoleMenu/RoleMenu_${DateTimeNow.AjaxForString}.xlsx" type="button" download>
                                            <span class="btn-inner--icon"><i class="fas fa-file-excel"></i></span>
                                            <span class="btn-inner--text">Download</span>
                                        </a>`);

            //Show OK message
            $("#cmscore-rolemenu-button-ok-message-in-card").html(`<strong>
                                                                    <i class="fas fa-check"></i>
                                                                </strong> Conversion completed`);
            $("#cmscore-rolemenu-button-ok-message-in-card").show();
        },
        error: err => {
            //Show error message
            $("#cmscore-rolemenu-error-message-title").html("Rx.from(ajax.post('/api/CMSCore/RoleMenu/1/ExportAsExcel/' + ExportationType, Body, Header)).subscribe(...)");
            $("#cmscore-rolemenu-error-message-text").html(err);
            $("#cmscore-rolemenu-button-error-message-in-card").show();
        }
    });
});

//Export as CSV button
$("#cmscore-rolemenu-export-as-csv").on("click", function (e) {
    //There are two exportation types, All and JustChecked
    let ExportationType: string = "";
    let DateTimeNow: Ajax;
    let Body: Ajax = {};
    //Define a header for HTTP protocol with Accept (receiver data type) and Content-Type (sender data type)
    let Header: any = {
        'Accept': 'application/json',
        'Content-Type': 'application/json; charset=utf-8'
    };

    if ($("#cmscore-rolemenu-export-rows-all-checkbox").is(":checked")) {
        ExportationType = "All";
    }
    else {
        ExportationType = "JustChecked";
        let CheckedRows = new Array();

        if (ViewToggler == "Table") {
            $("tr td div input.rolemenu-table-checkbox-for-row:checked").each(function () {
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

    Rx.from(ajax.post("/api/CMSCore/RoleMenu/1/ExportAsCSV/" + ExportationType, Body, Header)).subscribe({
        next: newrow => {
            $("#cmscore-rolemenu-export-message").html("<strong>Exporting as CSV</strong>");
            DateTimeNow = newrow.response as Ajax;
        },
        complete: () => {
            //Show download button for CSV file
            $("#cmscore-rolemenu-export-message").html(`<a class="btn btn-icon btn-success" href="/CSVFiles/CMSCore/RoleMenu/RoleMenu_${DateTimeNow.AjaxForString}.csv" type="button" download>
                                            <span class="btn-inner--icon"><i class="fas fa-file-csv"></i></span>
                                            <span class="btn-inner--text">Download</span>
                                        </a>`);

            //Show OK message
            $("#cmscore-rolemenu-button-ok-message-in-card").html(`<strong>
                                                                    <i class="fas fa-check"></i>
                                                                </strong> Conversion completed`);
            $("#cmscore-rolemenu-button-ok-message-in-card").show();
        },
        error: err => {
            //Show error message
            $("#cmscore-rolemenu-error-message-title").html("Rx.from(ajax.post('/api/CMSCore/RoleMenu/1/ExportAsCSV/' + ExportationType, Body, Header)).subscribe(...)");
            $("#cmscore-rolemenu-error-message-text").html(err);
            $("#cmscore-rolemenu-button-error-message-in-card").show();
        }
    });
});

//Export close button in modal
$("#cmscore-rolemenu-export-close-button").on("click", function (e) {
    $("#cmscore-rolemenu-export-message").html("");
});

//Massive action Copy
$("#cmscore-rolemenu-massive-action-copy").on("click", function (e) {
    //There are two deletion types, All and JustChecked
    let CopyType: string = "";
    let Body: Ajax = {};

    if ($("#cmscore-rolemenu-copy-rows-all-checkbox").is(":checked")) {
        CopyType = "All";
    }
    else {
        CopyType = "JustChecked";
        let CheckedRows = new Array();

        if (ViewToggler == "Table") {
            $("tr td div input.rolemenu-table-checkbox-for-row:checked").each(function () {
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

    RoleMenuModel.CopyManyOrAll(CopyType, Body).subscribe({
        next: newrow => {
        },
        complete: () => {
            ValidateAndSearch();

            //Show OK message
            $("#cmscore-rolemenu-button-ok-message-in-card").html(`<strong>
                                                                    <i class="fas fa-check"></i>
                                                                </strong> Rows copied successfully`);
            $("#cmscore-rolemenu-button-ok-message-in-card").show();
        },
        error: err => {
            //Show error message
            $("#cmscore-rolemenu-error-message-title").html("RoleMenuModel.Copy(CopyType).subscribe(...)");
            $("#cmscore-rolemenu-error-message-text").html(err);
            $("#cmscore-rolemenu-button-error-message-in-card").show();
        }
    });
});

//Massive action Delete
$("#cmscore-rolemenu-massive-action-delete").on("click", function (e) {
    //There are two deletion types, All and JustChecked
    let DeleteType: string = "";
    let Body: Ajax = {};

    if ($("#cmscore-rolemenu-copy-rows-all-checkbox").is(":checked")) {
        DeleteType = "All";
    }
    else {
        DeleteType = "JustChecked";
        let CheckedRows = new Array();

        if (ViewToggler == "Table") {
            $("tr td div input.rolemenu-table-checkbox-for-row:checked").each(function () {
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

    RoleMenuModel.DeleteManyOrAll(DeleteType, Body).subscribe({
        next: newrow => {
        },
        complete: () => {
            ValidateAndSearch();

            //Show OK message
            $("#cmscore-rolemenu-button-ok-message-in-card").html(`<strong>
                                                                    <i class="fas fa-check"></i>
                                                                </strong> Rows deleted successfully`);
            $("#cmscore-rolemenu-button-ok-message-in-card").show();
        },
        error: err => {
            //Show error message
            $("#cmscore-rolemenu-error-message-title").html("RoleMenuModel.Copy(CopyType).subscribe(...)");
            $("#cmscore-rolemenu-error-message-text").html(err);
            $("#cmscore-rolemenu-button-error-message-in-card").show();
        }
    });
});