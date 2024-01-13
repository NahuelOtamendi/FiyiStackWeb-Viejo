import { UserModel } from "../TsModels/User_TsModel";

export class userSelectAllPaged {
    QueryString?: string;
    ActualPageNumber?: number;
    RowsPerPage?: number;
    SorterColumn?: string;
    SortToggler?: boolean;
    TotalRows?: number;
    TotalPages?: number;
    lstUserModel?: UserModel[] | undefined;
}