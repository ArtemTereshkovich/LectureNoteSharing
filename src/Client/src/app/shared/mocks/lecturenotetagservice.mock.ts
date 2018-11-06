import { Injectable } from '@angular/core';
import { Tag } from '../models/tag.models';
import { Observable, of } from 'rxjs';

@Injectable()
export class LectureNoteTagServiceMock {

  constructor() { }

  getTags(tagIds: Array<string>): Observable<Array<Tag>> {
    const tags: Array<Tag> = [
      {
        id: 'tag1',
        text: 'Simple Tag 1',
        countOfUse: 3
      },
      {
        id: 'tag2',
        text: 'Simple Tag 2',
        countOfUse: 2
      },
      {
        id: 'tag3',
        text: 'Simple Tag 3',
        countOfUse: 1
      }
    ];
    return of(tags);
  }
}
