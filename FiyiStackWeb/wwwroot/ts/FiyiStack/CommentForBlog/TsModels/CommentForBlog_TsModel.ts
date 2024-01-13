import * as Rx from "rxjs";
import { ajax } from "rxjs/ajax";
import { Ajax } from "../../../Library/Ajax";
import { commentforblogSelectAllPaged } from "../DTOs/commentforblogSelectAllPaged";

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

//8 fields | Last modification on: 21/12/2022 12:08:11 | Stack: 9

export class CommentForBlogModel {

    //Fields
    CommentForBlogId?: number;
	Active?: boolean;
	DateTimeCreation: string;
	DateTimeLastModification?: string | string[] | number | undefined;
	UserCreationId?: number;
	UserLastModificationId?: number;
	Comment?: string | string[] | number | undefined;
    BlogId?: number;
    FantasyName?: string | string[] | number | undefined;
    UserCreationIdFantasyName?: string | string[] | number | undefined;
    UserLastModificationIdFantasyName?: string | string[] | number | undefined;
    BlogIdTitle?: string | string[] | number | undefined;

    //Queries
    static Select1ByCommentForBlogId(CommentForBlogId: number) {
        let URL = "/api/FiyiStack/CommentForBlog/1/Select1ByCommentForBlogIdToJSON/" + CommentForBlogId;
        return Rx.from(ajax(URL));
    }

    static SelectAll() {
        let URL = "/api/FiyiStack/CommentForBlog/1/SelectAllToJSON"
        return Rx.from(ajax(URL));
    }
    
    static SelectAllPaged(commentforblogSelectAllPaged: commentforblogSelectAllPaged) {
        let URL = "/api/FiyiStack/CommentForBlog/1/SelectAllPagedToJSON";
        let Body = {
            QueryString: commentforblogSelectAllPaged.QueryString,
            ActualPageNumber: commentforblogSelectAllPaged.ActualPageNumber,
            RowsPerPage: commentforblogSelectAllPaged.RowsPerPage,
            SorterColumn: commentforblogSelectAllPaged.SorterColumn,
            SortToggler: commentforblogSelectAllPaged.SortToggler,
            RowCount: commentforblogSelectAllPaged.TotalRows,
            TotalPages: commentforblogSelectAllPaged.TotalPages,
            lstCommentForBlogModel: commentforblogSelectAllPaged.lstCommentForBlogModel
        };
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }

    //Non-Queries
    static DeleteByCommentForBlogId(CommentForBlogId: number | string | string[] | undefined) {
        let URL = "/api/FiyiStack/CommentForBlog/1/DeleteByCommentForBlogId/" + CommentForBlogId;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.delete(URL, Header));
    }

    static DeleteManyOrAll(DeleteType: string, Body: Ajax) {
        let URL = "/api/FiyiStack/CommentForBlog/1/DeleteManyOrAll/" + DeleteType;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }
    
    static CopyByCommentForBlogId(CommentForBlogId: string | number | string[] | undefined) {
        let URL = "/api/FiyiStack/CommentForBlog/1/CopyByCommentForBlogId/" + CommentForBlogId;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        let Body: any = {};
        return Rx.from(ajax.post(URL, Body, Header));
    }

    static CopyManyOrAll(CopyType: string, Body: Ajax) {
        let URL = "/api/CommentForBloging/CommentForBlog/1/CopyManyOrAll/" + CopyType;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }
}