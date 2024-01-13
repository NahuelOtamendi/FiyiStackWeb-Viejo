import * as Rx from "rxjs";
import { ajax } from "rxjs/ajax";
import { Ajax } from "../../../Library/Ajax";
import { sendusdbdiagramSelectAllPaged } from "../DTOs/sendusdbdiagramSelectAllPaged";


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

//9 fields | Sub-models: 0 models  | Last modification on: 23/07/2023 22:31:09 | Stack: 9

export class SendUsDBDiagramModel {

    //Fields
    SendUsDBDiagramId?: number;
	Active?: boolean;
	DateTimeCreation?: string | string[] | number | undefined;
	DateTimeLastModification?: string | string[] | number | undefined;
	UserCreationId?: number;
	UserLastModificationId?: number;
	Title?: string | string[] | number | undefined;
	Description?: string | string[] | number | undefined;
	FileUploaded?: string | string[] | number | undefined;
    

    //Queries
    static Select1BySendUsDBDiagramId(SendUsDBDiagramId: number) {
        let URL = "/api/FiyiStack/SendUsDBDiagram/1/Select1BySendUsDBDiagramIdToJSON/" + SendUsDBDiagramId;
        return Rx.from(ajax(URL));
    }

    static SelectAll() {
        let URL = "/api/FiyiStack/SendUsDBDiagram/1/SelectAllToJSON"
        return Rx.from(ajax(URL));
    }
    
    static SelectAllPaged(sendusdbdiagramSelectAllPaged: sendusdbdiagramSelectAllPaged) {
        let URL = "/api/FiyiStack/SendUsDBDiagram/1/SelectAllPagedToJSON";
        let Body = {
            QueryString: sendusdbdiagramSelectAllPaged.QueryString,
            ActualPageNumber: sendusdbdiagramSelectAllPaged.ActualPageNumber,
            RowsPerPage: sendusdbdiagramSelectAllPaged.RowsPerPage,
            SorterColumn: sendusdbdiagramSelectAllPaged.SorterColumn,
            SortToggler: sendusdbdiagramSelectAllPaged.SortToggler,
            RowCount: sendusdbdiagramSelectAllPaged.TotalRows,
            TotalPages: sendusdbdiagramSelectAllPaged.TotalPages,
            lstSendUsDBDiagramModel: sendusdbdiagramSelectAllPaged.lstSendUsDBDiagramModel
        };
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }

    //Non-Queries
    static DeleteBySendUsDBDiagramId(SendUsDBDiagramId: number | string | string[] | undefined) {
        let URL = "/api/FiyiStack/SendUsDBDiagram/1/DeleteBySendUsDBDiagramId/" + SendUsDBDiagramId;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.delete(URL, Header));
    }

    static DeleteManyOrAll(DeleteType: string, Body: Ajax) {
        let URL = "/api/FiyiStack/SendUsDBDiagram/1/DeleteManyOrAll/" + DeleteType;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }
    
    static CopyBySendUsDBDiagramId(SendUsDBDiagramId: string | number | string[] | undefined) {
        let URL = "/api/FiyiStack/SendUsDBDiagram/1/CopyBySendUsDBDiagramId/" + SendUsDBDiagramId;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        let Body: any = {};
        return Rx.from(ajax.post(URL, Body, Header));
    }

    static CopyManyOrAll(CopyType: string, Body: Ajax) {
        let URL = "/api/SendUsDBDiagraming/SendUsDBDiagram/1/CopyManyOrAll/" + CopyType;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }
}