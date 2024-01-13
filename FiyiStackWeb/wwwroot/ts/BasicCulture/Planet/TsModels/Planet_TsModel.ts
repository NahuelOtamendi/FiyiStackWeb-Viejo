import * as Rx from "rxjs";
import { ajax } from "rxjs/ajax";
import { Ajax } from "../../../Library/Ajax";
import { planetSelectAllPaged } from "../DTOs/planetSelectAllPaged";

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

//8 fields | Last modification on: 21/12/2022 10:33:37 | Stack: 9

export class PlanetModel {

    //Fields
    PlanetId?: number;
	Name?: string | string[] | number | undefined;
	Code?: string | string[] | number | undefined;
	Active?: boolean;
	UserCreationId?: number;
	UserLastModificationId?: number;
	DateTimeCreation?: string | string[] | number | undefined;
    DateTimeLastModification?: string | string[] | number | undefined;
    UserCreationIdFantasyName?: string | string[] | number | undefined;
    UserLastModificationIdFantasyName?: string | string[] | number | undefined;

    //Queries
    static Select1ByPlanetId(PlanetId: number) {
        let URL = "/api/BasicCulture/Planet/1/Select1ByPlanetIdToJSON/" + PlanetId;
        return Rx.from(ajax(URL));
    }

    static SelectAll() {
        let URL = "/api/BasicCulture/Planet/1/SelectAllToJSON"
        return Rx.from(ajax(URL));
    }
    
    static SelectAllPaged(planetSelectAllPaged: planetSelectAllPaged) {
        let URL = "/api/BasicCulture/Planet/1/SelectAllPagedToJSON";
        let Body = {
            QueryString: planetSelectAllPaged.QueryString,
            ActualPageNumber: planetSelectAllPaged.ActualPageNumber,
            RowsPerPage: planetSelectAllPaged.RowsPerPage,
            SorterColumn: planetSelectAllPaged.SorterColumn,
            SortToggler: planetSelectAllPaged.SortToggler,
            RowCount: planetSelectAllPaged.TotalRows,
            TotalPages: planetSelectAllPaged.TotalPages,
            lstPlanetModel: planetSelectAllPaged.lstPlanetModel
        };
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }

    //Non-Queries
    static DeleteByPlanetId(PlanetId: number | string | string[] | undefined) {
        let URL = "/api/BasicCulture/Planet/1/DeleteByPlanetId/" + PlanetId;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.delete(URL, Header));
    }

    static DeleteManyOrAll(DeleteType: string, Body: Ajax) {
        let URL = "/api/BasicCulture/Planet/1/DeleteManyOrAll/" + DeleteType;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }
    
    static CopyByPlanetId(PlanetId: string | number | string[] | undefined) {
        let URL = "/api/BasicCulture/Planet/1/CopyByPlanetId/" + PlanetId;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        let Body: any = {};
        return Rx.from(ajax.post(URL, Body, Header));
    }

    static CopyManyOrAll(CopyType: string, Body: Ajax) {
        let URL = "/api/Planeting/Planet/1/CopyManyOrAll/" + CopyType;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }
}