import * as Rx from "rxjs";
import { ajax } from "rxjs/ajax";
import { Ajax } from "../../../Library/Ajax";
import { provinceSelectAllPaged } from "../DTOs/provinceSelectAllPaged";

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

//10 fields | Last modification on: 21/12/2022 10:37:34 | Stack: 9

export class ProvinceModel {

    //Fields
    ProvinceId?: number;
	Name?: string | string[] | number | undefined;
	GeographicalCoordinates?: string | string[] | number | undefined;
	Code?: string | string[] | number | undefined;
	CountryId?: number;
	Active?: boolean;
	UserCreationId?: number;
	UserLastModificationId?: number;
	DateTimeCreation?: string | string[] | number | undefined;
    DateTimeLastModification?: string | string[] | number | undefined;
    UserCreationIdFantasyName?: string | string[] | number | undefined;
    UserLastModificationIdFantasyName?: string | string[] | number | undefined;
    CountryIdName?: string | string[] | number | undefined;

    //Queries
    static Select1ByProvinceId(ProvinceId: number) {
        let URL = "/api/BasicCulture/Province/1/Select1ByProvinceIdToJSON/" + ProvinceId;
        return Rx.from(ajax(URL));
    }

    static SelectAll() {
        let URL = "/api/BasicCulture/Province/1/SelectAllToJSON"
        return Rx.from(ajax(URL));
    }
    
    static SelectAllPaged(provinceSelectAllPaged: provinceSelectAllPaged) {
        let URL = "/api/BasicCulture/Province/1/SelectAllPagedToJSON";
        let Body = {
            QueryString: provinceSelectAllPaged.QueryString,
            ActualPageNumber: provinceSelectAllPaged.ActualPageNumber,
            RowsPerPage: provinceSelectAllPaged.RowsPerPage,
            SorterColumn: provinceSelectAllPaged.SorterColumn,
            SortToggler: provinceSelectAllPaged.SortToggler,
            RowCount: provinceSelectAllPaged.TotalRows,
            TotalPages: provinceSelectAllPaged.TotalPages,
            lstProvinceModel: provinceSelectAllPaged.lstProvinceModel
        };
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }

    //Non-Queries
    static DeleteByProvinceId(ProvinceId: number | string | string[] | undefined) {
        let URL = "/api/BasicCulture/Province/1/DeleteByProvinceId/" + ProvinceId;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.delete(URL, Header));
    }

    static DeleteManyOrAll(DeleteType: string, Body: Ajax) {
        let URL = "/api/BasicCulture/Province/1/DeleteManyOrAll/" + DeleteType;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }
    
    static CopyByProvinceId(ProvinceId: string | number | string[] | undefined) {
        let URL = "/api/BasicCulture/Province/1/CopyByProvinceId/" + ProvinceId;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        let Body: any = {};
        return Rx.from(ajax.post(URL, Body, Header));
    }

    static CopyManyOrAll(CopyType: string, Body: Ajax) {
        let URL = "/api/Provinceing/Province/1/CopyManyOrAll/" + CopyType;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }
}