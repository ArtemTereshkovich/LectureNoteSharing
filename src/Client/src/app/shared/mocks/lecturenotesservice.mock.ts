import { Injectable } from '@angular/core';
import { LectureNoteDTO } from '../models/lecturenotes.models';
import { LectureNotesQuery } from './lecturenotesservice.model';
import { Observable, of } from 'rxjs';


@Injectable()
export class LectureNotesServiceMock {
    constructor() {}

    getLectureNotes(query: LectureNotesQuery): Observable<Array<LectureNoteDTO>> {
        const notes: LectureNoteDTO[] = [
            {
                id: '123',
                description: '123',
                dateOfCreate: new Date(),
                tagsId: [ '123', '321'],
                autorid: '123',
                text: '123',
                title: '123321',

            }];
        return of(notes);
    }
}
