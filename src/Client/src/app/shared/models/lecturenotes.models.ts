import { UserView } from './user.models';
import { LectureNoteTagView } from './tag.models';

export class LectureNoteDTO {
    id: String;
    title: String;
    description: String;
    autorid: String;
    text: String;
    dateOfCreate: Date;
    tagsId: Array<String>;
}

export class LectureNote {
    id: String;
    title: String;
    description: String;
    autor: UserView;
    text: String;
    dateOfCreate: Date;
    tags: Array<LectureNoteTagView>;
}

export class LectureNoteView {
    id: string;
    title: string;
    description: string;
    text: string;
    dateOfCreation: Date;
    autorUsername: String;
    tags: Array<LectureNoteTagView>;
}
