import * as Rx from "rxjs";
import { ajax } from "rxjs/ajax";
import { Ajax } from "../../../Library/Ajax";
import { sexSelectAllPaged } from "../DTOs/sexSelectAllPaged";

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

//7 fields | Last modification on: 21/12/2022 10:42:03 | Stack: 9

export class SexModel {

    //Fields
    SexId?: number;
	Name?: string | string[] | number | undefined;
	Active?: boolean;
	UserCreationId?: number;
	UserLastModificationId?: number;
	DateTimeCreation?: string | string[] | number | undefined;
    DateTimeLastModification?: string | string[] | number | undefined;
    UserCreationIdFantasyName?: string | string[] | number | undefined;
    UserLastModificationIdFantasyName?: string | string[] | number | undefined;

    //Queries
    static Select1BySexId(SexId: number) {
        let URL = "/api/BasicCulture/Sex/1/Select1BySexIdToJSON/" + SexId;
        return Rx.from(ajax(URL));
    }

    static SelectAll() {
        let URL = "/api/BasicCulture/Sex/1/SelectAllToJSON"
        return Rx.from(ajax(URL));
    }
    
    static SelectAllPaged(sexSelectAllPaged: sexSelectAllPaged) {
        let URL = "/api/BasicCulture/Sex/1/SelectAllPagedToJSON";
        let Body = {
            QueryString: sexSelectAllPaged.QueryString,
            ActualPageNumber: sexSelectAllPaged.ActualPageNumber,
            RowsPerPage: sexSelectAllPaged.RowsPerPage,
            SorterColumn: sexSelectAllPaged.SorterColumn,
            SortToggler: sexSelectAllPaged.SortToggler,
            RowCount: sexSelectAllPaged.TotalRows,
            TotalPages: sexSelectAllPaged.TotalPages,
            lstSexModel: sexSelectAllPaged.lstSexModel
        };
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }

    //Non-Queries
    static DeleteBySexId(SexId: number | string | string[] | undefined) {
        let URL = "/api/BasicCulture/Sex/1/DeleteBySexId/" + SexId;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.delete(URL, Header));
    }

    static DeleteManyOrAll(DeleteType: string, Body: Ajax) {
        let URL = "/api/BasicCulture/Sex/1/DeleteManyOrAll/" + DeleteType;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }
    
    static CopyBySexId(SexId: string | number | string[] | undefined) {
        let URL = "/api/BasicCulture/Sex/1/CopyBySexId/" + SexId;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        let Body: any = {};
        return Rx.from(ajax.post(URL, Body, Header));
    }

    static CopyManyOrAll(CopyType: string, Body: Ajax) {
        let URL = "/api/Sexing/Sex/1/CopyManyOrAll/" + CopyType;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }
}