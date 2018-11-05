import { Injectable } from '@angular/core';
import { LectureNotePreview, LectureNoteView, LectureNoteEdit } from '../models/lecturenotes.models';
import { LectureNotesQuery } from '../models/lecturenotesservice.model';
import { Observable, of } from 'rxjs';


@Injectable()
export class LectureNotesServiceMock {
    constructor() { }

    saveLectureNote(lectureNote: LectureNoteEdit): Observable<string> {
        return of('noteX');
    }

    deleteLectureNote(id: string) {
    }

    getLectureNoteView(id: string): Observable<LectureNoteView> {
        return of({
            id: 'note1',
            description: 'Some example of description',
            dateOfCreate: new Date(),
            tagsId: ['tag1', 'tag2', 'tag3'],
            authorId: 'author1',
            title: 'SOME MAGIC BEYTIFUL KONSPECt',
            text: 'Text of Lecture Note'
        });
    }

    getLectureNotesPreview(query: LectureNotesQuery):
    Observable<
        {
            lectureNotes: Array<LectureNotePreview>
            ; count: number;
        }> {
        const notes: Array<LectureNotePreview> = [
            {
                id: 'note1',
                description: 'Some example of description',
                dateOfCreate: new Date(),
                tagsId: ['tag1', 'tag2', 'tag3'],
                authorId: 'author1',
                title: 'SOME MAGIC BEYTIFUL KONSPECt'
            },
            {
                id: 'note2',
                description: 'Some example of description',
                dateOfCreate: new Date(),
                tagsId: ['tag1', 'tag2', 'tag3'],
                authorId: 'author1',
                title: 'SOME MAGIC BEYTIFUL KONSPECt'
            }
            ];
        return of(
            {
                lectureNotes: notes,
                count: 20
            }
        );
    }
}

