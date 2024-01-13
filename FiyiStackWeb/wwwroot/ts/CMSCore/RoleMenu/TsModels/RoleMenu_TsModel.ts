import * as Rx from "rxjs";
import { ajax } from "rxjs/ajax";
import { Ajax } from "../../../Library/Ajax";
import { rolemenuSelectAllPaged } from "../DTOs/rolemenuSelectAllPaged";

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

//8 fields | Last modification on: 21/12/2022 11:04:02 | Stack: 9

export class RoleMenuModel {

    //Fields
    RoleMenuId?: number;
	RoleId?: number;
	MenuId?: number;
	Active?: boolean;
	UserCreationId?: number;
	UserLastModificationId?: number;
	DateTimeCreation?: string | string[] | number | undefined;
	DateTimeLastModification?: string | string[] | number | undefined;

    //Queries
    static Select1ByRoleMenuId(RoleMenuId: number) {
        let URL = "/api/CMSCore/RoleMenu/1/Select1ByRoleMenuIdToJSON/" + RoleMenuId;
        return Rx.from(ajax(URL));
    }

    static SelectAll() {
        let URL = "/api/CMSCore/RoleMenu/1/SelectAllToJSON"
        return Rx.from(ajax(URL));
    }
    
    static SelectAllPaged(rolemenuSelectAllPaged: rolemenuSelectAllPaged) {
        let URL = "/api/CMSCore/RoleMenu/1/SelectAllPagedToJSON";
        let Body = {
            QueryString: rolemenuSelectAllPaged.QueryString,
            ActualPageNumber: rolemenuSelectAllPaged.ActualPageNumber,
            RowsPerPage: rolemenuSelectAllPaged.RowsPerPage,
            SorterColumn: rolemenuSelectAllPaged.SorterColumn,
            SortToggler: rolemenuSelectAllPaged.SortToggler,
            RowCount: rolemenuSelectAllPaged.TotalRows,
            TotalPages: rolemenuSelectAllPaged.TotalPages,
            lstRoleMenuModel: rolemenuSelectAllPaged.lstRoleMenuModel
        };
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }

    //Non-Queries
    static DeleteByRoleMenuId(RoleMenuId: number | string | string[] | undefined) {
        let URL = "/api/CMSCore/RoleMenu/1/DeleteByRoleMenuId/" + RoleMenuId;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.delete(URL, Header));
    }

    static DeleteManyOrAll(DeleteType: string, Body: Ajax) {
        let URL = "/api/CMSCore/RoleMenu/1/DeleteManyOrAll/" + DeleteType;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }
    
    static CopyByRoleMenuId(RoleMenuId: string | number | string[] | undefined) {
        let URL = "/api/CMSCore/RoleMenu/1/CopyByRoleMenuId/" + RoleMenuId;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        let Body: any = {};
        return Rx.from(ajax.post(URL, Body, Header));
    }

    static CopyManyOrAll(CopyType: string, Body: Ajax) {
        let URL = "/api/RoleMenuing/RoleMenu/1/CopyManyOrAll/" + CopyType;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }
}

