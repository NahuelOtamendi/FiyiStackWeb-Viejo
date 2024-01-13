import { ParameterModel } from "../TsModels/Parameter_TsModel";

export class parameterSelectAllPaged {
    QueryString?: string;
    ActualPageNumber?: number;
    RowsPerPage?: number;
    SorterColumn?: string;
    SortToggler?: boolean;
    TotalRows?: number;
    TotalPages?: number;
    lstParameterModel?: ParameterModel[] | undefined;
}