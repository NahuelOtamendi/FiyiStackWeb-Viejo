import { CommentForBlogModel } from "../TsModels/CommentForBlog_TsModel";

export class commentforblogSelectAllPaged {
    QueryString?: string;
    ActualPageNumber?: number;
    RowsPerPage?: number;
    SorterColumn?: string;
    SortToggler?: boolean;
    TotalRows?: number;
    TotalPages?: number;
    lstCommentForBlogModel?: CommentForBlogModel[] | undefined;
}