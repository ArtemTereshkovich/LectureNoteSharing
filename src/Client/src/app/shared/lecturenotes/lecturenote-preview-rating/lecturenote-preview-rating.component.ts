import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-lecturenote-preview-rating',
  templateUrl: './lecturenote-preview-rating.component.html',
  styleUrls: ['./lecturenote-preview-rating.component.css']
})
export class LecturenotePreviewRatingComponent implements OnInit {

  @Input()
  private lectureNoteId: string;
  private loading: Boolean;

  constructor() {
    this.loading = true;
   }

  ngOnInit() {
  }

}
