import * as Rx from "rxjs";
import { ajax } from "rxjs/ajax";
import { Ajax } from "../../../Library/Ajax";
import { menuSelectAllPaged } from "../DTOs/menuSelectAllPaged";


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

//11 fields | Sub-models: 0 models  | Last modification on: 15/02/2023 18:14:40 | Stack: 9

export class MenuModel {

    //Fields
    MenuId?: number;
	Active?: boolean;
	DateTimeCreation?: string | string[] | number | undefined;
	DateTimeLastModification?: string | string[] | number | undefined;
	UserCreationId?: number;
	UserLastModificationId?: number;
	Name?: string | string[] | number | undefined;
	MenuFatherId?: number;
	Order?: number;
	URLPath?: string | string[] | number | undefined;
	IconURLPath?: string | string[] | number | undefined;
    UserCreationIdFantasyName?: string | string[] | number | undefined;
    UserLastModificationIdFantasyName?: string | string[] | number | undefined;

    //Queries
    static Select1ByMenuId(MenuId: number) {
        let URL = "/api/CMSCore/Menu/1/Select1ByMenuIdToJSON/" + MenuId;
        return Rx.from(ajax(URL));
    }

    static SelectAll() {
        let URL = "/api/CMSCore/Menu/1/SelectAllToJSON"
        return Rx.from(ajax(URL));
    }
    
    static SelectAllPaged(menuSelectAllPaged: menuSelectAllPaged) {
        let URL = "/api/CMSCore/Menu/1/SelectAllPagedToJSON";
        let Body = {
            QueryString: menuSelectAllPaged.QueryString,
            ActualPageNumber: menuSelectAllPaged.ActualPageNumber,
            RowsPerPage: menuSelectAllPaged.RowsPerPage,
            SorterColumn: menuSelectAllPaged.SorterColumn,
            SortToggler: menuSelectAllPaged.SortToggler,
            RowCount: menuSelectAllPaged.TotalRows,
            TotalPages: menuSelectAllPaged.TotalPages,
            lstMenuModel: menuSelectAllPaged.lstMenuModel
        };
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }

    //Non-Queries
    static DeleteByMenuId(MenuId: number | string | string[] | undefined) {
        let URL = "/api/CMSCore/Menu/1/DeleteByMenuId/" + MenuId;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.delete(URL, Header));
    }

    static DeleteManyOrAll(DeleteType: string, Body: Ajax) {
        let URL = "/api/CMSCore/Menu/1/DeleteManyOrAll/" + DeleteType;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }
    
    static CopyByMenuId(MenuId: string | number | string[] | undefined) {
        let URL = "/api/CMSCore/Menu/1/CopyByMenuId/" + MenuId;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        let Body: any = {};
        return Rx.from(ajax.post(URL, Body, Header));
    }

    static CopyManyOrAll(CopyType: string, Body: Ajax) {
        let URL = "/api/Menuing/Menu/1/CopyManyOrAll/" + CopyType;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }
}