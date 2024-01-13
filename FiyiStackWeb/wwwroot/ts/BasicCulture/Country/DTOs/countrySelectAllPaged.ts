import { CountryModel } from "../TsModels/Country_TsModel";

export class countrySelectAllPaged {
    QueryString?: string;
    ActualPageNumber?: number;
    RowsPerPage?: number;
    SorterColumn?: string;
    SortToggler?: boolean;
    TotalRows?: number;
    TotalPages?: number;
    lstCountryModel?: CountryModel[] | undefined;
}