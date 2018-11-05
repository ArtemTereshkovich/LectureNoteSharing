export class LectureNotesQuery {
    ratingSort: Boolean;
    offset: number;
    limit: number;
    filter: LectureNoteQueryFilter;
}

export class LectureNoteQueryFilter {
    tags: Array<String>;
}
