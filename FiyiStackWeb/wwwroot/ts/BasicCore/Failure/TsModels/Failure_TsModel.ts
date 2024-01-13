import * as Rx from "rxjs";
import { ajax } from "rxjs/ajax";
import { Ajax } from "../../../Library/Ajax";
import { failureSelectAllPaged } from "../DTOs/failureSelectAllPaged";

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

//12 fields | Last modification on: 21/12/2022 9:25:46 | Stack: 9

export class FailureModel {

    //Fields
    FailureId?: number;
	HTTPCode?: number;
	EmergencyLevel?: number;
	Message?: string | string[] | number | undefined;
	StackTrace?: string | string[] | number | undefined;
	Source?: string | string[] | number | undefined;
	Comment?: string | string[] | number | undefined;
	Active?: boolean;
	UserCreationId?: number;
	UserLastModificationId?: number;
	DateTimeCreation?: string | string[] | number | undefined;
	DateTimeLastModification?: string | string[] | number | undefined;
    UserCreationIdFantasyName?: string | string[] | number | undefined;
    UserLastModificationIdFantasyName?: string | string[] | number | undefined;

    //Queries
    static Select1ByFailureId(FailureId: number) {
        let URL = "/api/BasicCore/Failure/1/Select1ByFailureIdToJSON/" + FailureId;
        return Rx.from(ajax(URL));
    }

    static SelectAll() {
        let URL = "/api/BasicCore/Failure/1/SelectAllToJSON"
        return Rx.from(ajax(URL));
    }
    
    static SelectAllPaged(failureSelectAllPaged: failureSelectAllPaged) {
        let URL = "/api/BasicCore/Failure/1/SelectAllPagedToJSON";
        let Body = {
            QueryString: failureSelectAllPaged.QueryString,
            ActualPageNumber: failureSelectAllPaged.ActualPageNumber,
            RowsPerPage: failureSelectAllPaged.RowsPerPage,
            SorterColumn: failureSelectAllPaged.SorterColumn,
            SortToggler: failureSelectAllPaged.SortToggler,
            RowCount: failureSelectAllPaged.TotalRows,
            TotalPages: failureSelectAllPaged.TotalPages,
            lstFailureModel: failureSelectAllPaged.lstFailureModel
        };
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }

    //Non-Queries
    static DeleteByFailureId(FailureId: number | string | string[] | undefined) {
        let URL = "/api/BasicCore/Failure/1/DeleteByFailureId/" + FailureId;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.delete(URL, Header));
    }

    static DeleteManyOrAll(DeleteType: string, Body: Ajax) {
        let URL = "/api/BasicCore/Failure/1/DeleteManyOrAll/" + DeleteType;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }
    
    static CopyByFailureId(FailureId: string | number | string[] | undefined) {
        let URL = "/api/BasicCore/Failure/1/CopyByFailureId/" + FailureId;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        let Body: any = {};
        return Rx.from(ajax.post(URL, Body, Header));
    }

    static CopyManyOrAll(CopyType: string, Body: Ajax) {
        let URL = "/api/Failureing/Failure/1/CopyManyOrAll/" + CopyType;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }
}