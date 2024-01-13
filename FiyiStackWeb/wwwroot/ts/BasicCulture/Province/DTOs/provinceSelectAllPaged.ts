import { ProvinceModel } from "../TsModels/Province_TsModel";

export class provinceSelectAllPaged {
    QueryString?: string;
    ActualPageNumber?: number;
    RowsPerPage?: number;
    SorterColumn?: string;
    SortToggler?: boolean;
    TotalRows?: number;
    TotalPages?: number;
    lstProvinceModel?: ProvinceModel[] | undefined;
}