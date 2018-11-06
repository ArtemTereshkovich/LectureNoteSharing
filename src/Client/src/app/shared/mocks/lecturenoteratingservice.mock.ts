import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { RatingPreview } from '../models/rating.models';

@Injectable()
export class LectureNoteRatingServiceMock {

  constructor() { }

  public getRatingByLectureNoteId(lectureNoteId: string): Observable<RatingPreview> {
    const rating: RatingPreview = {
      id: 'rating1',
      lectureNoteId: lectureNoteId,
      rating: 140,
      isFavorite: false
    };
    return of(rating);
  }
}
