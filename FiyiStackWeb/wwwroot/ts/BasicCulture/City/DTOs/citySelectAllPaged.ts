import { CityModel } from "../TsModels/City_TsModel";

export class citySelectAllPaged {
    QueryString?: string;
    ActualPageNumber?: number;
    RowsPerPage?: number;
    SorterColumn?: string;
    SortToggler?: boolean;
    TotalRows?: number;
    TotalPages?: number;
    lstCityModel?: CityModel[] | undefined;
}