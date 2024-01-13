import { RoleModel } from "../TsModels/Role_TsModel";

export class roleSelectAllPaged {
    QueryString?: string;
    ActualPageNumber?: number;
    RowsPerPage?: number;
    SorterColumn?: string;
    SortToggler?: boolean;
    TotalRows?: number;
    TotalPages?: number;
    lstRoleModel?: RoleModel[] | undefined;
}