import { FailureModel } from "../TsModels/Failure_TsModel";

export class failureSelectAllPaged {
    QueryString?: string;
    ActualPageNumber?: number;
    RowsPerPage?: number;
    SorterColumn?: string;
    SortToggler?: boolean;
    TotalRows?: number;
    TotalPages?: number;
    lstFailureModel?: FailureModel[] | undefined;
}