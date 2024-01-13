import { PlanetModel } from "../TsModels/Planet_TsModel";

export class planetSelectAllPaged {
    QueryString?: string;
    ActualPageNumber?: number;
    RowsPerPage?: number;
    SorterColumn?: string;
    SortToggler?: boolean;
    TotalRows?: number;
    TotalPages?: number;
    lstPlanetModel?: PlanetModel[] | undefined;
}