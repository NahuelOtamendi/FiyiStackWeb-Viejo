//Import libraries to use
import { BlogModel } from "../../Blog/TsModels/Blog_TsModel";
import { blogSelectAllPaged } from "../DTOs/blogSelectAllPaged";
import * as $ from "jquery";
import { format } from "timeago.js";
var numeral = require('numeral');

//Set default values
let LastTopDistance: number = 0;
let QueryString: string = "";
let ActualPageNumber: number = 1;
let RowsPerPage: number = 2000;
let SorterColumn: string | undefined = "";
let SortToggler: boolean = false;
let TotalPages: number = 0;
let TotalRows: number = 0;
let ViewToggler: string = "List";
let ScrollDownNSearchFlag: boolean = false;

class BlogQuery {
    static SelectAllPagedToHTML(request_blogSelectAllPaged: blogSelectAllPaged) {
        //Used for list view
        $(window).off("scroll");

        var ListContent: string = ``;

        BlogModel.SelectAllPaged(request_blogSelectAllPaged).subscribe(
            {
                next: newrow => {
                    //Only works when there is data available
                    if (newrow.status != 204) {

                        const response_blogQuery = newrow.response as blogSelectAllPaged;

                        //Set to default values if they are null
                        QueryString = response_blogQuery.QueryString ?? "";
                        ActualPageNumber = response_blogQuery.ActualPageNumber ?? 0;
                        RowsPerPage = response_blogQuery.RowsPerPage ?? 0;
                        SorterColumn = response_blogQuery.SorterColumn ?? "";
                        SortToggler = response_blogQuery.SortToggler ?? false;
                        TotalRows = response_blogQuery.TotalRows ?? 0;
                        TotalPages = response_blogQuery.TotalPages ?? 0;

                        //Query string
                        $("#fiyistack-blog-query-string").attr("placeholder", `Search... (${TotalRows} posts)`);
                        //If we are at the final of book disable next and last buttons in pagination
                        if (ActualPageNumber === TotalPages) {
                            $("#fiyistack-blog-search-more-button-in-list").html("");
                        }
                        else {
                            //Scroll arrow for list view
                            $("#fiyistack-blog-search-more-button-in-list").html("<i class='fas fa-2x fa-chevron-down'></i>");
                        }
                        
                        response_blogQuery?.lstBlogModel?.forEach(row => {


                            //Read data book
                            ListContent += `
<div class="card card-blog card-plain blog-horizontal mb-5">
    <div class="row">
        <div class="col-lg-4">
            <div class="card-image">
                <a href="/BlogPost/${row.BlogId}">
                    <img class="img rounded" src="${row.BackgroundImage}" />
                </a>
            </div>
        </div>
        <div class="col-lg-8">
            <div class="card-body">
                <h3 class="card-title">
                    <a class="text-default" href="/BlogPost/${row.BlogId}">${row.Title}</a>
                </h3>
                <p class="card-description">
                    ${row.Body?.toString().substring(0, 160)} <a class="text-default" href="/BlogPost/${row.BlogId}"> Read More </a>
                </p>
                <div class="row">
                    <div class="col-2">
                        <img src="/img/FiyiStack/Me.jpg" alt="MatiasNovillo" class="avatar img-raised">
                    </div>
                    <div class="col-10">
                        <div class="author">
                            <div class="text">
                                <span class="name">
                                    Matias Novillo - Full Stack Web Developer
                                </span>
                                <div class="meta">
                                    ${format(Date.parse(row.DateTimeLastModification))} -
                                    ${numeral(row.NumberOfLikes).format('0,0.')} likes -
                                    ${numeral(row.NumberOfComments).format('0,0.')} comments
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
                            //Table view is not activated
                        }
                        else {
                            //Used for list view
                            if (ScrollDownNSearchFlag) {
                                $("#fiyistack-blog-body-list").append(ListContent);
                                ScrollDownNSearchFlag = false;
                            }
                            else {
                                //Clear list view
                                $("#fiyistack-blog-body-list").html("");
                                $("#fiyistack-blog-body-list").html(ListContent);
                            }
                            }
                    }
                    else {
                        //Show error message
                    }
                },
                complete: () => {
                    //Execute ScrollDownNSearch function when the user scroll the page
                    $(window).on("scroll", ScrollDownNSearch);

                    //Post comment button
                    $(".btn-post-comment").on("click", function (e) {

                        //Button -> Input -> Break -> Message
                        let Message = $(this).next().next().next();

                        if ($(this).prev().val() == "") {
                            Message.html(`<strong><i class='fas fa-exclamation-triangle'></i> 
                                                    Write a comment
                                            </strong>`);
                            return;
                        }

                        let formData = new FormData();

                        let BlogId = $(this).next().val()?.toString();
                        if (BlogId === undefined) {
                            BlogId = "";
                        }
                        formData.append("BlogId", BlogId);

                        let Comment = $(this).prev().val()?.toString();
                        if (Comment === undefined) {
                            Comment = "";
                        }
                        formData.append("Comment", Comment);


                        //Setup request
                        var xmlHttpRequest = new XMLHttpRequest();
                        xmlHttpRequest.onload = function () {
                            if (xmlHttpRequest.status >= 400) {
                                Message.html(`<strong><i class='fas fa-exclamation-triangle'></i> 
                                                    An error has occurred, try again
                                            </strong>`);
                            }
                            else {
                                if (xmlHttpRequest.response == "You have to login first") {
                                    Message.html(`<strong><i class='fas fa-exclamation-triangle'></i> 
                                                    You have to login first
                                            </strong>`);
                                }
                                else {
                                    ValidateAndSearch();
                                }
                                
                            }
                        };
                        //Open connection
                        xmlHttpRequest.open("POST", "/api/FiyiStack/CommentForBlog/1/PostComment", true);
                        //Send request
                        xmlHttpRequest.send(formData);
                    });

                },
                error: err => {
                }
            });
    }
}

function ValidateAndSearch() {


    var _blogSelectAllPaged: blogSelectAllPaged = {
        QueryString,
        ActualPageNumber,
        RowsPerPage,
        SorterColumn,
        SortToggler,
        TotalRows,
        TotalPages
    };

    BlogQuery.SelectAllPagedToHTML(_blogSelectAllPaged);
}

if ($("#fiyistack-blog-title-page").html().includes("El blog de FiyiStack")) {
    //Set to default values
    QueryString = "";
    ActualPageNumber = 1;
    RowsPerPage = 50;
    SorterColumn = "DateTimeCreation";
    SortToggler = true;
    TotalRows = 0;
    TotalPages = 0;
    ViewToggler = "List";

    ValidateAndSearch();
}

//CLICK, SCROLL AND KEYBOARD EVENTS
//Search button
$($("#fiyistack-blog-search-button")).on("click", function () {
    ValidateAndSearch();
});

//Query string
$("#fiyistack-blog-query-string").on("change keyup input", function (e) {
    //If undefined, set QueryString to "" value
    QueryString = ($(this).val()?.toString()) ?? "" ;
    ValidateAndSearch();
});

//Used to list view
function ScrollDownNSearch() {
    let WindowsTopDistance: number = $(window).scrollTop() ?? 0;
    let WindowsBottomDistance: number = ($(window).scrollTop() ?? 0) + ($(window).innerHeight() ?? 0);
    let CardsFooterTopPosition: number = $("#fiyistack-blog-search-more-button-in-list").offset()?.top ?? 0;
    let CardsFooterBottomPosition: number = ($("#fiyistack-blog-search-more-button-in-list").offset()?.top ?? 0) + ($("#fiyistack-blog-search-more-button-in-list").outerHeight() ?? 0);

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