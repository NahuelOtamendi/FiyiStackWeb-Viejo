import * as Rx from "rxjs";
import { ajax } from "rxjs/ajax";
import { Ajax } from "../../../Library/Ajax";
import { blogSelectAllPaged } from "../DTOs/blogSelectAllPaged";
import { CommentForBlogModel } from "../../CommentForBlog/TsModels/CommentForBlog_TsModel";

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

//12 fields | Sub-models: 1 models  | Last modification on: 23/07/2023 11:33:01 | Stack: 9

export class BlogModel {

    //Fields
    BlogId?: number;
	Active?: boolean;
    DateTimeCreation: string;
    DateTimeLastModification: string;
	UserCreationId?: number;
	UserLastModificationId?: number;
	Title?: string | string[] | number | undefined;
	Body?: string | string[] | number | undefined;
	BackgroundImage?: string | string[] | number | undefined;
	NumberOfLikes?: number;
	NumberOfComments?: number;
    lstCommentForBlogModel?: CommentForBlogModel[] | undefined;
    UserCreationIdFantasyName?: string | string[] | number | undefined;
    UserLastModificationIdFantasyName?: string | string[] | number | undefined;

    //Queries
    static Select1ByBlogIdAndIdiom(BlogId: number) {
        let URL = "/api/FiyiStack/Blog/1/Select1ByBlogIdToJSON/" + BlogId;
        return Rx.from(ajax(URL));
    }

    static SelectAll() {
        let URL = "/api/FiyiStack/Blog/1/SelectAllToJSON"
        return Rx.from(ajax(URL));
    }
    
    static SelectAllPaged(blogSelectAllPaged: blogSelectAllPaged) {
        let URL = "/api/FiyiStack/Blog/1/SelectAllPagedToJSON";
        let Body = {
            QueryString: blogSelectAllPaged.QueryString,
            ActualPageNumber: blogSelectAllPaged.ActualPageNumber,
            RowsPerPage: blogSelectAllPaged.RowsPerPage,
            SorterColumn: blogSelectAllPaged.SorterColumn,
            SortToggler: blogSelectAllPaged.SortToggler,
            RowCount: blogSelectAllPaged.TotalRows,
            TotalPages: blogSelectAllPaged.TotalPages,
            lstBlogModel: blogSelectAllPaged.lstBlogModel
        };
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }

    //Non-Queries
    static DeleteByBlogId(BlogId: number | string | string[] | undefined) {
        let URL = "/api/FiyiStack/Blog/1/DeleteByBlogId/" + BlogId;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.delete(URL, Header));
    }

    static DeleteManyOrAll(DeleteType: string, Body: Ajax) {
        let URL = "/api/FiyiStack/Blog/1/DeleteManyOrAll/" + DeleteType;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }
    
    static CopyByBlogId(BlogId: string | number | string[] | undefined) {
        let URL = "/api/FiyiStack/Blog/1/CopyByBlogId/" + BlogId;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        let Body: any = {};
        return Rx.from(ajax.post(URL, Body, Header));
    }

    static CopyManyOrAll(CopyType: string, Body: Ajax) {
        let URL = "/api/Bloging/Blog/1/CopyManyOrAll/" + CopyType;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }
}