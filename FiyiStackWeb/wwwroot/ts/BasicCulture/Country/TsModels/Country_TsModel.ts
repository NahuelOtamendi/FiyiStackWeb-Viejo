import * as Rx from "rxjs";
import { ajax } from "rxjs/ajax";
import { Ajax } from "../../../Library/Ajax";
import { countrySelectAllPaged } from "../DTOs/countrySelectAllPaged";

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

//10 fields | Last modification on: 21/12/2022 10:30:11 | Stack: 9

export class CountryModel {

    //Fields
    CountryId?: number;
	Name?: string | string[] | number | undefined;
	GeographicalCoordinates?: string | string[] | number | undefined;
	Code?: string | string[] | number | undefined;
	PlanetId?: number;
	Active?: boolean;
	UserCreationId?: number;
	UserLastModificationId?: number;
	DateTimeCreation?: string | string[] | number | undefined;
    DateTimeLastModification?: string | string[] | number | undefined;
    UserCreationIdFantasyName?: string | string[] | number | undefined;
    UserLastModificationIdFantasyName?: string | string[] | number | undefined;
    PlanetIdName?: string | string[] | number | undefined;

    //Queries
    static Select1ByCountryId(CountryId: number) {
        let URL = "/api/BasicCulture/Country/1/Select1ByCountryIdToJSON/" + CountryId;
        return Rx.from(ajax(URL));
    }

    static SelectAll() {
        let URL = "/api/BasicCulture/Country/1/SelectAllToJSON"
        return Rx.from(ajax(URL));
    }
    
    static SelectAllPaged(countrySelectAllPaged: countrySelectAllPaged) {
        let URL = "/api/BasicCulture/Country/1/SelectAllPagedToJSON";
        let Body = {
            QueryString: countrySelectAllPaged.QueryString,
            ActualPageNumber: countrySelectAllPaged.ActualPageNumber,
            RowsPerPage: countrySelectAllPaged.RowsPerPage,
            SorterColumn: countrySelectAllPaged.SorterColumn,
            SortToggler: countrySelectAllPaged.SortToggler,
            RowCount: countrySelectAllPaged.TotalRows,
            TotalPages: countrySelectAllPaged.TotalPages,
            lstCountryModel: countrySelectAllPaged.lstCountryModel
        };
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }

    //Non-Queries
    static DeleteByCountryId(CountryId: number | string | string[] | undefined) {
        let URL = "/api/BasicCulture/Country/1/DeleteByCountryId/" + CountryId;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.delete(URL, Header));
    }

    static DeleteManyOrAll(DeleteType: string, Body: Ajax) {
        let URL = "/api/BasicCulture/Country/1/DeleteManyOrAll/" + DeleteType;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }
    
    static CopyByCountryId(CountryId: string | number | string[] | undefined) {
        let URL = "/api/BasicCulture/Country/1/CopyByCountryId/" + CountryId;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        let Body: any = {};
        return Rx.from(ajax.post(URL, Body, Header));
    }

    static CopyManyOrAll(CopyType: string, Body: Ajax) {
        let URL = "/api/Countrying/Country/1/CopyManyOrAll/" + CopyType;
        let Header: any = {
            "Accept": "application/json",
            "Content-Type": "application/json; charset=utf-8"
        };
        return Rx.from(ajax.post(URL, Body, Header));
    }
}