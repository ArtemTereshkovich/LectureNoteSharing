import { Component, OnInit, Input } from '@angular/core';
import { LectureNoteRatingServiceMock } from '../../mocks/lecturenoteratingservice.mock';
import { RatingPreview } from '../../models/rating.models';

@Component({
  selector: 'app-lecturenote-preview-rating',
  templateUrl: './lecturenote-preview-rating.component.html',
  styleUrls: ['./lecturenote-preview-rating.component.css']
})
export class LecturenotePreviewRatingComponent implements OnInit {

  @Input()
  private lectureNoteId: string;
  public rating: RatingPreview;
  public loading: Boolean;

  constructor(private lectureNoteRatingService: LectureNoteRatingServiceMock) {
    this.loading = true;
    this.rating = null;
   }

  ngOnInit() {
    this.loadLectureNoteRating();
  }

  private loadLectureNoteRating(): void {
    this.loading = true;
    this.lectureNoteRatingService.getRatingByLectureNoteId(this.lectureNoteId).subscribe(rating => {
      this.rating = rating;
      this.loading = false;
    });
  }
}
