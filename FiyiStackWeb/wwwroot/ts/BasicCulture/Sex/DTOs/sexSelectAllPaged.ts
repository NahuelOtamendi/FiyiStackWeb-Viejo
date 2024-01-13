import { SexModel } from "../TsModels/Sex_TsModel";

export class sexSelectAllPaged {
    QueryString?: string;
    ActualPageNumber?: number;
    RowsPerPage?: number;
    SorterColumn?: string;
    SortToggler?: boolean;
    TotalRows?: number;
    TotalPages?: number;
    lstSexModel?: SexModel[] | undefined;
}