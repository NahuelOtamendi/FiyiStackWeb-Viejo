import * as Rx from "rxjs";
import { ajax } from "rxjs/ajax";
import { Ajax } from "../../../Library/Ajax";
import { citySelectAllPaged } from "../DTOs/citySelectAllPaged";

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

//10 fields | Last modification on: 21/12/2022 9:41:41 | Stack: 9

export class CityModel {

    //Fields
    CityId?: number;
	Name?: string | string[] | number | undefined;
	GeographicalCoordinates?: string | string[] | number | undefined;
	Code?: string | string[] | number | undefined;
	ProvinceId?: number;
	Active?: boolean;
	UserCreationId?: number;
	UserLastModificationId?: number;
	DateTimeCreation?: string | string[] | number | undefined;
    DateTimeLastModification?: string | string[] | number | undefined;
    UserCreationIdFantasyName?: string | string[] | number | undefined;
    UserLastModificationIdFantasyName?: string | string[] | number | undefined;
    ProvinceIdName?: string | string[] | number | undefined;

    //Queries
    static Select1ByCityId(CityId: number) {
        let URL = "/api/BasicCulture/City/1/Select1ByCityIdToJSON/" + CityId;
        return Rx.from(ajax(URL));
    }

    static SelectAll() {
        let URL = "/api/BasicCulture/City/1/SelectAllToJSON"
        return Rx.from(ajax(URL));
    }
    
    static SelectAllPaged(citySelectAllPaged: citySelectAllPaged) {
        let URL = "/api/BasicCulture/City/1/SelectAllPagedToJSON";
        let Body = {
            QueryString: citySelectAllPaged.QueryString,
            ActualPageNumber: citySelectAllPaged.ActualPageNumber,
            RowsPerPage: citySelectAllPaged.RowsPerPage,
            SorterColumn: citySelectAllPaged.SorterColumn,
            SortToggler: citySelectAllPaged.SortToggler,
            RowCount: citySelectAllPaged.TotalRows,
            TotalPages: citySelectAllPaged.TotalPages,
            lstCityModel: citySelectAllPaged.lstCityModel
        };
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }

    //Non-Queries
    static DeleteByCityId(CityId: number | string | string[] | undefined) {
        let URL = "/api/BasicCulture/City/1/DeleteByCityId/" + CityId;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.delete(URL, Header));
    }

    static DeleteManyOrAll(DeleteType: string, Body: Ajax) {
        let URL = "/api/BasicCulture/City/1/DeleteManyOrAll/" + DeleteType;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }
    
    static CopyByCityId(CityId: string | number | string[] | undefined) {
        let URL = "/api/BasicCulture/City/1/CopyByCityId/" + CityId;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        let Body: any = {};
        return Rx.from(ajax.post(URL, Body, Header));
    }

    static CopyManyOrAll(CopyType: string, Body: Ajax) {
        let URL = "/api/Citying/City/1/CopyManyOrAll/" + CopyType;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }
}