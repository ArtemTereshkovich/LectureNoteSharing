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
        text: 'anime',
        countOfUse: 3
      },
      {
        id: 'tag2',
        text: 'hentai',
        countOfUse: 2
      },
      {
        id: 'tag3',
        text: 'aoi',
        countOfUse: 1
      }
    ];
    return of(tags);
  }
}
