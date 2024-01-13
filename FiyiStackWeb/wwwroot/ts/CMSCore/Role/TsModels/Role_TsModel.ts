import * as Rx from "rxjs";
import { ajax } from "rxjs/ajax";
import { Ajax } from "../../../Library/Ajax";
import { roleSelectAllPaged } from "../DTOs/roleSelectAllPaged";

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

//7 fields | Last modification on: 21/12/2022 11:08:27 | Stack: 9

export class RoleModel {

    //Fields
    RoleId?: number;
	Name?: string | string[] | number | undefined;
	Active?: boolean;
	UserCreationId?: number;
	UserLastModificationId?: number;
	DateTimeCreation?: string | string[] | number | undefined;
    DateTimeLastModification?: string | string[] | number | undefined;
    UserCreationIdFantasyName?: string | string[] | number | undefined;
    UserLastModificationIdFantasyName?: string | string[] | number | undefined;

    //Queries
    static Select1ByRoleId(RoleId: number) {
        let URL = "/api/CMSCore/Role/1/Select1ByRoleIdToJSON/" + RoleId;
        return Rx.from(ajax(URL));
    }

    static SelectAll() {
        let URL = "/api/CMSCore/Role/1/SelectAllToJSON"
        return Rx.from(ajax(URL));
    }
    
    static SelectAllPaged(roleSelectAllPaged: roleSelectAllPaged) {
        let URL = "/api/CMSCore/Role/1/SelectAllPagedToJSON";
        let Body = {
            QueryString: roleSelectAllPaged.QueryString,
            ActualPageNumber: roleSelectAllPaged.ActualPageNumber,
            RowsPerPage: roleSelectAllPaged.RowsPerPage,
            SorterColumn: roleSelectAllPaged.SorterColumn,
            SortToggler: roleSelectAllPaged.SortToggler,
            RowCount: roleSelectAllPaged.TotalRows,
            TotalPages: roleSelectAllPaged.TotalPages,
            lstRoleModel: roleSelectAllPaged.lstRoleModel
        };
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }

    //Non-Queries
    static DeleteByRoleId(RoleId: number | string | string[] | undefined) {
        let URL = "/api/CMSCore/Role/1/DeleteByRoleId/" + RoleId;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.delete(URL, Header));
    }

    static DeleteManyOrAll(DeleteType: string, Body: Ajax) {
        let URL = "/api/CMSCore/Role/1/DeleteManyOrAll/" + DeleteType;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }
    
    static CopyByRoleId(RoleId: string | number | string[] | undefined) {
        let URL = "/api/CMSCore/Role/1/CopyByRoleId/" + RoleId;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        let Body: any = {};
        return Rx.from(ajax.post(URL, Body, Header));
    }

    static CopyManyOrAll(CopyType: string, Body: Ajax) {
        let URL = "/api/Roleing/Role/1/CopyManyOrAll/" + CopyType;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }
}