import * as Rx from "rxjs";
import { ajax } from "rxjs/ajax";
import { Ajax } from "../../../Library/Ajax";
import { visitorcounterSelectAllPaged } from "../DTOs/visitorcounterSelectAllPaged";

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

//7 fields | Sub-models: 0 models  | Last modification on: 22/02/2023 7:45:50 | Stack: 9

export class VisitorCounterModel {

    //Fields
    VisitorCounterId?: number;
	Active?: boolean;
	DateTimeCreation?: string | string[] | number | undefined;
	DateTimeLastModification?: string | string[] | number | undefined;
	UserCreationId?: number;
	UserLastModificationId?: number;
	DateTime?: string | string[] | number | undefined;
    

    //Queries
    static Select1ByVisitorCounterId(VisitorCounterId: number) {
        let URL = "/api/BasicCore/VisitorCounter/1/Select1ByVisitorCounterIdToJSON/" + VisitorCounterId;
        return Rx.from(ajax(URL));
    }

    static SelectAll() {
        let URL = "/api/BasicCore/VisitorCounter/1/SelectAllToJSON"
        return Rx.from(ajax(URL));
    }
    
    static SelectAllPaged(visitorcounterSelectAllPaged: visitorcounterSelectAllPaged) {
        let URL = "/api/BasicCore/VisitorCounter/1/SelectAllPagedToJSON";
        let Body = {
            QueryString: visitorcounterSelectAllPaged.QueryString,
            ActualPageNumber: visitorcounterSelectAllPaged.ActualPageNumber,
            RowsPerPage: visitorcounterSelectAllPaged.RowsPerPage,
            SorterColumn: visitorcounterSelectAllPaged.SorterColumn,
            SortToggler: visitorcounterSelectAllPaged.SortToggler,
            RowCount: visitorcounterSelectAllPaged.TotalRows,
            TotalPages: visitorcounterSelectAllPaged.TotalPages,
            lstVisitorCounterModel: visitorcounterSelectAllPaged.lstVisitorCounterModel
        };
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }

    //Non-Queries
    static DeleteByVisitorCounterId(VisitorCounterId: number | string | string[] | undefined) {
        let URL = "/api/BasicCore/VisitorCounter/1/DeleteByVisitorCounterId/" + VisitorCounterId;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.delete(URL, Header));
    }

    static DeleteManyOrAll(DeleteType: string, Body: Ajax) {
        let URL = "/api/BasicCore/VisitorCounter/1/DeleteManyOrAll/" + DeleteType;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }
    
    static CopyByVisitorCounterId(VisitorCounterId: string | number | string[] | undefined) {
        let URL = "/api/BasicCore/VisitorCounter/1/CopyByVisitorCounterId/" + VisitorCounterId;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        let Body: any = {};
        return Rx.from(ajax.post(URL, Body, Header));
    }

    static CopyManyOrAll(CopyType: string, Body: Ajax) {
        let URL = "/api/VisitorCountering/VisitorCounter/1/CopyManyOrAll/" + CopyType;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }
}