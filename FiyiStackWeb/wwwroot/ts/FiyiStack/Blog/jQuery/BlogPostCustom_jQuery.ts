//Import libraries to use
import { BlogModel } from "../TsModels/Blog_TsModel";
import * as $ from "jquery";
import { format } from "timeago.js";
import "bootstrap-notify";

class BlogQuery {
    static Select1ByBlogIdToHTML(BlogId: number) {
        //Used for list view
        $(window).off("scroll");

        var Content: string = ``;

        BlogModel.Select1ByBlogIdAndIdiom(BlogId).subscribe(
            {
                next: newrow => {
                    //Only works when there is data available
                    if (newrow.status != 204) {

                        const response_blogQuery = newrow.response as BlogModel;

                        Content += `<section class="section section-blog-info">
    <div class="container">
      <div class="row">
        <div class="col-md-8 mx-auto">
          <div class="card">
            <div class="card-header">
              <h5 class="h3 mb-0">${response_blogQuery.Title}</h5>
            </div>
            <div class="card-header d-flex align-items-center">
              <div class="d-flex align-items-center">
                <a href="javascript:;">
                  <img src="/img/FiyiStack/Me.jpg" class="avatar">
                </a>
                <div class="mx-3">
                  <a href="javascript:;" class="text-dark font-weight-600 text-sm">Matias Novillo</a>
                  <small class="d-block text-muted">${format(Date.parse(response_blogQuery.DateTimeLastModification))}</small>
                </div>
              </div>
            </div>
            <div class="card-body">
              <p class="mb-4">
                ${response_blogQuery.Body}
              </p>
              <img alt="Image placeholder" src="${response_blogQuery.BackgroundImage}" class="img-fluid rounded mb-4">
              <div class="row align-items-center mb-5">
                  <div class="col-sm-6">
                    <div class="icon-actions">
                      <a href="javascript:;" class="btn-post-like">
                        <i class="fas fa-2x fa-thumbs-up"></i>
                        <span class="text-muted">${response_blogQuery.NumberOfLikes}</span>
                      </a>
                      <input type="hidden" value="${response_blogQuery.BlogId}"></input>
                      <a href="javascript:;">
                        <i class="fas fa-2x fa-comment"></i>
                        <span class="text-muted">${response_blogQuery.NumberOfComments}</span>
                      </a>
                    </div>
                  </div>
                  <div class="col-sm-6 d-none d-sm-block">
                    &nbsp;
                  </div>
                </div>
              <!-- Comments -->
              <div class="mb-1">
                ${response_blogQuery.lstCommentForBlogModel?.map(row2 => {

                            return `<div class="media media-comment mb--2">
                  <img alt="Image placeholder" class="media-comment-avatar rounded-circle" src="/img/CMSCore/User.png">
                  <div class="media-body">
                    <div class="media-comment-text">
                      <h6 class="h5 mt-0">${row2.FantasyName}</h6>
                      <p class="text-sm lh-160">${row2.Comment}</p>
                      <div class="icon-actions">
                          <p class="text-muted">${format(Date.parse(row2.DateTimeCreation))}</p>
                      </div>
                    </div>
                  </div>
                </div>` }).join("")}
                <div class="media align-items-center mt-2">
                  <div class="media-body">
                    <form>
                        <div class="row">
                            <div class="col text-right">
                                <textarea class="form-control mt-4"
                                    placeholder="Write your comment"
                                    rows="3"
                                    resize="none"
                                    maxlength="8000">
                                </textarea>
                                <button class="btn btn-sm mt-2 mr-0 btn-primary btn-post-comment" type="button">Post comment</button>
                                <input type="hidden" value="${response_blogQuery.BlogId}"></input>
                            </div>
                        </div>
                    </form>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>`;

                        $("#fiyistack-blog-body-list").html(Content);
                    }
                    else {
                        //Show error message
                    }
                },
                complete: () => {

                    //Post comment button
                    $(".btn-post-comment").on("click", function (e) {

                        if ($(this).prev().val() == "") {
                            // @ts-ignore
                            $.notify({ icon: "fas fa-info", message: "Write a comment" }, { type: "info", placement: { from: "bottom", align: "center" } });
                            return;
                        }

                        let formData = new FormData();

                        let BlogId = $(this).next().val()?.toString();
                        if (BlogId === undefined) {
                            return;
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

                        let formData = new FormData();

                        let BlogId = $(this).next().val()?.toString();
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
                error: err => {
                }
            });
    }
}

function ValidateAndSearch() {

    // @ts-ignore
    let PostId: number = $("#post-id").val();

    BlogQuery.Select1ByBlogIdToHTML(PostId);
}

//LOAD EVENT
$(document).ready(function () {
    ValidateAndSearch();
});