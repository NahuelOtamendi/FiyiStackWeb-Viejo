import { VisitorCounterModel } from "../TsModels/VisitorCounter_TsModel";

export class visitorcounterSelectAllPaged {
    QueryString?: string;
    ActualPageNumber?: number;
    RowsPerPage?: number;
    SorterColumn?: string;
    SortToggler?: boolean;
    TotalRows?: number;
    TotalPages?: number;
    lstVisitorCounterModel?: VisitorCounterModel[] | undefined;
}