import * as Rx from "rxjs";
import { ajax } from "rxjs/ajax";
import { Ajax } from "../../../Library/Ajax";
import { userSelectAllPaged } from "../DTOs/userSelectAllPaged";

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

//11 fields | Last modification on: 21/12/2022 11:12:12 | Stack: 9

export class UserModel {

    //Fields
    UserId?: number;
	FantasyName?: string | string[] | number | undefined;
	Email?: string | string[] | number | undefined;
	Password?: string | string[] | number | undefined;
	RoleId?: number;
	Active?: boolean;
	UserCreationId?: number;
	UserLastModificationId?: number;
	DateTimeCreation?: string | string[] | number | undefined;
	DateTimeLastModification?: string | string[] | number | undefined;
    RegistrationToken?: string | string[] | number | undefined;
    UserCreationIdFantasyName?: string | string[] | number | undefined;
    UserLastModificationIdFantasyName?: string | string[] | number | undefined;
    RoleIdName?: string | string[] | number | undefined;

    //Queries
    static Select1ByUserId(UserId: number) {
        let URL = "/api/CMSCore/User/1/Select1ByUserIdToJSON/" + UserId;
        return Rx.from(ajax(URL));
    }

    static SelectAll() {
        let URL = "/api/CMSCore/User/1/SelectAllToJSON"
        return Rx.from(ajax(URL));
    }
    
    static SelectAllPaged(userSelectAllPaged: userSelectAllPaged) {
        let URL = "/api/CMSCore/User/1/SelectAllPagedToJSON";
        let Body = {
            QueryString: userSelectAllPaged.QueryString,
            ActualPageNumber: userSelectAllPaged.ActualPageNumber,
            RowsPerPage: userSelectAllPaged.RowsPerPage,
            SorterColumn: userSelectAllPaged.SorterColumn,
            SortToggler: userSelectAllPaged.SortToggler,
            RowCount: userSelectAllPaged.TotalRows,
            TotalPages: userSelectAllPaged.TotalPages,
            lstUserModel: userSelectAllPaged.lstUserModel
        };
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }

    //Non-Queries
    static DeleteByUserId(UserId: number | string | string[] | undefined) {
        let URL = "/api/CMSCore/User/1/DeleteByUserId/" + UserId;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.delete(URL, Header));
    }

    static DeleteManyOrAll(DeleteType: string, Body: Ajax) {
        let URL = "/api/CMSCore/User/1/DeleteManyOrAll/" + DeleteType;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }
    
    static CopyByUserId(UserId: string | number | string[] | undefined) {
        let URL = "/api/CMSCore/User/1/CopyByUserId/" + UserId;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        let Body: any = {};
        return Rx.from(ajax.post(URL, Body, Header));
    }

    static CopyManyOrAll(CopyType: string, Body: Ajax) {
        let URL = "/api/Usering/User/1/CopyManyOrAll/" + CopyType;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }
}