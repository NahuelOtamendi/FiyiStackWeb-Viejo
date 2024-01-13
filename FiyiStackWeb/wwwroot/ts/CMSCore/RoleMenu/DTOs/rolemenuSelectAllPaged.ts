import { RoleMenuModel } from "../TsModels/RoleMenu_TsModel";

export class rolemenuSelectAllPaged {
    QueryString?: string;
    ActualPageNumber?: number;
    RowsPerPage?: number;
    SorterColumn?: string;
    SortToggler?: boolean;
    TotalRows?: number;
    TotalPages?: number;
    lstRoleMenuModel?: RoleMenuModel[] | undefined;
}