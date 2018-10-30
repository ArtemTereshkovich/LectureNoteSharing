import { Injectable } from '@angular/core';
import { LectureNoteDTO } from '../models/lecturenotes.models';

@Injectable()
export class LectureNotesServiceMock {
    constructor() {}

    getLectureNotes(): Array<LectureNoteDTO> {
        return [];
    }
}
