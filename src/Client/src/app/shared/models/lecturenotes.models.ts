export class LectureNoteView {
    id: string;
    title: string;
    description: string;
    authorId: string;
    text: string;
    dateOfCreate: Date;
    tagsId: Array<string>;
}

export class LectureNotePreview {
    id: string;
    title: string;
    description: string;
    authorId: string;
    dateOfCreate: Date;
    tagsId: Array<string>;
}

export class LectureNoteEdit {
    id: string;
    title: string;
    description: string;
    text: string;
    tagsId: Array<string>;
}
