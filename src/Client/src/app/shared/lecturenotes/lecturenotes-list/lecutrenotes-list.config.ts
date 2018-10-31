export class LectureNotesListConfig {
    countPerPage: number;
    currentPage: number;
    filter: LectureNotesListFilter;
}

export class LectureNotesListFilter {
    defaultTag: String;
}
