"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
//Import libraries to use
var Blog_TsModel_1 = require("../TsModels/Blog_TsModel");
var $ = require("jquery");
var timeago_js_1 = require("timeago.js");
require("bootstrap-notify");
var BlogQuery = /** @class */ (function () {
    function BlogQuery() {
    }
    BlogQuery.Select1ByBlogIdToHTML = function (BlogId) {
        //Used for list view
        $(window).off("scroll");
        var Content = "";
        Blog_TsModel_1.BlogModel.Select1ByBlogIdAndIdiom(BlogId).subscribe({
            next: function (newrow) {
                var _a;
                //Only works when there is data available
                if (newrow.status != 204) {
                    var response_blogQuery = newrow.response;
                    Content += "<section class=\"section section-blog-info\">\n    <div class=\"container\">\n      <div class=\"row\">\n        <div class=\"col-md-8 mx-auto\">\n          <div class=\"card\">\n            <div class=\"card-header\">\n              <h5 class=\"h3 mb-0\">" + response_blogQuery.Title + "</h5>\n            </div>\n            <div class=\"card-header d-flex align-items-center\">\n              <div class=\"d-flex align-items-center\">\n                <a href=\"javascript:;\">\n                  <img src=\"/img/FiyiStack/Me.jpg\" class=\"avatar\">\n                </a>\n                <div class=\"mx-3\">\n                  <a href=\"javascript:;\" class=\"text-dark font-weight-600 text-sm\">Matias Novillo</a>\n                  <small class=\"d-block text-muted\">" + (0, timeago_js_1.format)(Date.parse(response_blogQuery.DateTimeLastModification)) + "</small>\n                </div>\n              </div>\n            </div>\n            <div class=\"card-body\">\n              <p class=\"mb-4\">\n                " + response_blogQuery.Body + "\n              </p>\n              <img alt=\"Image placeholder\" src=\"" + response_blogQuery.BackgroundImage + "\" class=\"img-fluid rounded mb-4\">\n              <div class=\"row align-items-center mb-5\">\n                  <div class=\"col-sm-6\">\n                    <div class=\"icon-actions\">\n                      <a href=\"javascript:;\" class=\"btn-post-like\">\n                        <i class=\"fas fa-2x fa-thumbs-up\"></i>\n                        <span class=\"text-muted\">" + response_blogQuery.NumberOfLikes + "</span>\n                      </a>\n                      <input type=\"hidden\" value=\"" + response_blogQuery.BlogId + "\"></input>\n                      <a href=\"javascript:;\">\n                        <i class=\"fas fa-2x fa-comment\"></i>\n                        <span class=\"text-muted\">" + response_blogQuery.NumberOfComments + "</span>\n                      </a>\n                    </div>\n                  </div>\n                  <div class=\"col-sm-6 d-none d-sm-block\">\n                    &nbsp;\n                  </div>\n                </div>\n              <!-- Comments -->\n              <div class=\"mb-1\">\n                " + ((_a = response_blogQuery.lstCommentForBlogModel) === null || _a === void 0 ? void 0 : _a.map(function (row2) {
                        return "<div class=\"media media-comment mb--2\">\n                  <img alt=\"Image placeholder\" class=\"media-comment-avatar rounded-circle\" src=\"/img/CMSCore/User.png\">\n                  <div class=\"media-body\">\n                    <div class=\"media-comment-text\">\n                      <h6 class=\"h5 mt-0\">" + row2.FantasyName + "</h6>\n                      <p class=\"text-sm lh-160\">" + row2.Comment + "</p>\n                      <div class=\"icon-actions\">\n                          <p class=\"text-muted\">" + (0, timeago_js_1.format)(Date.parse(row2.DateTimeCreation)) + "</p>\n                      </div>\n                    </div>\n                  </div>\n                </div>";
                    }).join("")) + "\n                <div class=\"media align-items-center mt-2\">\n                  <div class=\"media-body\">\n                    <form>\n                        <div class=\"row\">\n                            <div class=\"col text-right\">\n                                <textarea class=\"form-control mt-4\"\n                                    placeholder=\"Write your comment\"\n                                    rows=\"3\"\n                                    resize=\"none\"\n                                    maxlength=\"8000\">\n                                </textarea>\n                                <button class=\"btn btn-sm mt-2 mr-0 btn-primary btn-post-comment\" type=\"button\">Post comment</button>\n                                <input type=\"hidden\" value=\"" + response_blogQuery.BlogId + "\"></input>\n                            </div>\n                        </div>\n                    </form>\n                  </div>\n                </div>\n              </div>\n            </div>\n          </div>\n        </div>\n      </div>\n    </div>\n  </section>";
                    $("#fiyistack-blog-body-list").html(Content);
                }
                else {
                    //Show error message
                }
            },
            complete: function () {
                //Post comment button
                $(".btn-post-comment").on("click", function (e) {
                    var _a, _b;
                    if ($(this).prev().val() == "") {
                        // @ts-ignore
                        $.notify({ icon: "fas fa-info", message: "Write a comment" }, { type: "info", placement: { from: "bottom", align: "center" } });
                        return;
                    }
                    var formData = new FormData();
                    var BlogId = (_a = $(this).next().val()) === null || _a === void 0 ? void 0 : _a.toString();
                    if (BlogId === undefined) {
                        return;
                    }
                    formData.append("BlogId", BlogId);
                    var Comment = (_b = $(this).prev().val()) === null || _b === void 0 ? void 0 : _b.toString();
                    if (Comment === undefined) {
                        Comment = "";
                    }
                    formData.append("Comment", Comment);
                    //Setup request
                    var xmlHttpRequest = new XMLHttpRequest();
                    xmlHttpRequest.onload = function () {
                        if (xmlHttpRequest.status >= 400) {
                            // @ts-ignore
                            $.notify({ icon: "fas fa-check", message: "Comment posted successfully. Reload the page to see it" }, { type: "success", placement: { from: "bottom", align: "center" } });
                        }
                        else {
                            if (xmlHttpRequest.response == "You have to login first") {
                                // @ts-ignore
                                $.notify({ icon: "fas fa-info", message: "You have to login first" }, { type: "info", placement: { from: "bottom", align: "center" } });
                            }
                            else {
                                // @ts-ignore
                                $.notify({ icon: "fas fa-check", message: "Comment posted successfully" }, { type: "success", placement: { from: "bottom", align: "center" } });
                                ValidateAndSearch();
                            }
                        }
                    };
                    //Open connection
                    xmlHttpRequest.open("POST", "/api/FiyiStack/CommentForBlog/1/PostComment", true);
                    //Send request
                    xmlHttpRequest.send(formData);
                });
                //Post like
                $(".btn-post-like").on("click", function (e) {
                    var _a;
                    var formData = new FormData();
                    var BlogId = (_a = $(this).next().val()) === null || _a === void 0 ? void 0 : _a.toString();
                    if (BlogId === undefined) {
                        return;
                    }
                    formData.append("BlogId", BlogId);
                    //Setup request
                    var xmlHttpRequest = new XMLHttpRequest();
                    xmlHttpRequest.onload = function () {
                        if (xmlHttpRequest.status >= 400) {
                            // @ts-ignore
                            $.notify({ icon: "fas fa-exclamation-triangle", message: "An error has occurred, try again" }, { type: "danger", placement: { from: "bottom", align: "center" } });
                        }
                        else {
                            // @ts-ignore
                            $.notify({ icon: "fas fa-check", message: "Like posted successfully" }, { type: "success", placement: { from: "bottom", align: "center" } });
                            ValidateAndSearch();
                        }
                    };
                    //Open connection
                    xmlHttpRequest.open("POST", "/api/FiyiStack/CommentForBlog/1/PostLike", true);
                    //Send request
                    xmlHttpRequest.send(formData);
                });
            },
            error: function (err) {
            }
        });
    };
    return BlogQuery;
}());
function ValidateAndSearch() {
    // @ts-ignore
    var PostId = $("#post-id").val();
    BlogQuery.Select1ByBlogIdToHTML(PostId);
}
//LOAD EVENT
$(document).ready(function () {
    ValidateAndSearch();
});
//# sourceMappingURL=BlogPostCustom_jQuery.js.map