import * as Rx from "rxjs";
import { ajax } from "rxjs/ajax";
import { Ajax } from "../../../Library/Ajax";
import { parameterSelectAllPaged } from "../DTOs/parameterSelectAllPaged";

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

//9 fields | Last modification on: 21/12/2022 9:32:45 | Stack: 9

export class ParameterModel {

    //Fields
    ParameterId?: number;
	Name?: string | string[] | number | undefined;
	Value?: string | string[] | number | undefined;
	IsPrivate?: boolean;
	Active?: boolean;
	UserCreationId?: number;
	UserLastModificationId?: number;
	DateTimeCreation?: string | string[] | number | undefined;
	DateTimeLastModification?: string | string[] | number | undefined;
    UserCreationIdFantasyName?: string | string[] | number | undefined;
    UserLastModificationIdFantasyName?: string | string[] | number | undefined;

    //Queries
    static Select1ByParameterId(ParameterId: number) {
        let URL = "/api/BasicCore/Parameter/1/Select1ByParameterIdToJSON/" + ParameterId;
        return Rx.from(ajax(URL));
    }

    static SelectAll() {
        let URL = "/api/BasicCore/Parameter/1/SelectAllToJSON"
        return Rx.from(ajax(URL));
    }
    
    static SelectAllPaged(parameterSelectAllPaged: parameterSelectAllPaged) {
        let URL = "/api/BasicCore/Parameter/1/SelectAllPagedToJSON";
        let Body = {
            QueryString: parameterSelectAllPaged.QueryString,
            ActualPageNumber: parameterSelectAllPaged.ActualPageNumber,
            RowsPerPage: parameterSelectAllPaged.RowsPerPage,
            SorterColumn: parameterSelectAllPaged.SorterColumn,
            SortToggler: parameterSelectAllPaged.SortToggler,
            RowCount: parameterSelectAllPaged.TotalRows,
            TotalPages: parameterSelectAllPaged.TotalPages,
            lstParameterModel: parameterSelectAllPaged.lstParameterModel
        };
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }

    //Non-Queries
    static DeleteByParameterId(ParameterId: number | string | string[] | undefined) {
        let URL = "/api/BasicCore/Parameter/1/DeleteByParameterId/" + ParameterId;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.delete(URL, Header));
    }

    static DeleteManyOrAll(DeleteType: string, Body: Ajax) {
        let URL = "/api/BasicCore/Parameter/1/DeleteManyOrAll/" + DeleteType;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }
    
    static CopyByParameterId(ParameterId: string | number | string[] | undefined) {
        let URL = "/api/BasicCore/Parameter/1/CopyByParameterId/" + ParameterId;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        let Body: any = {};
        return Rx.from(ajax.post(URL, Body, Header));
    }

    static CopyManyOrAll(CopyType: string, Body: Ajax) {
        let URL = "/api/Parametering/Parameter/1/CopyManyOrAll/" + CopyType;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }
}