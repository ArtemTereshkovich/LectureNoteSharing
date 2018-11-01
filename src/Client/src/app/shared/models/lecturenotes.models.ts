import { UserView } from './user.models';
import { LectureNoteTagView } from './tag.models';

export class LectureNoteDTO {
    id: string;
    title: string;
    description: string;
    autorid: string;
    text: string;
    dateOfCreate: Date;
    tagsId: Array<string>;
}

export class LectureNote {
    id: string;
    title: string;
    description: string;
    autor: UserView;
    text: string;
    dateOfCreate: Date;
    tags: Array<LectureNoteTagView>;
}

export class LectureNoteView {
    id: string;
    title: string;
    description: string;
    text: string;
    dateOfCreation: Date;
    autorUsername: string;
    tags: Array<LectureNoteTagView>;
}

export class LectureNoteEdit {
    id: string;
    title: string;
    description: string;
    text: string;
}
