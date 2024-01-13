import { MenuModel } from "../TsModels/Menu_TsModel";

export class menuSelectAllPaged {
    QueryString?: string;
    ActualPageNumber?: number;
    RowsPerPage?: number;
    SorterColumn?: string;
    SortToggler?: boolean;
    TotalRows?: number;
    TotalPages?: number;
    lstMenuModel?: MenuModel[] | undefined;
}