import { Component, OnInit, Input } from '@angular/core';
import { LectureNotesListConfig } from './lecutrenotes-list.config';
import { LectureNotesServiceMock } from '../../mocks/lecturenotesservice.mock';
import { LectureNoteView } from '../../models/lecturenotes.models';

@Component({
  selector: 'app-lecturenotes-list',
  templateUrl: './lecturenotes-list.component.html',
  styleUrls: ['./lecturenotes-list.component.css']
})
export class LecturenotesListComponent implements OnInit {
  @Input()
  private defaultConfig: LectureNotesListConfig;
  private totalItems;
  private loading: Boolean;
  private lectureNotes: Array<LectureNoteView>;

  constructor(
    private lectureNoteService: LectureNotesServiceMock
  ) {
    this.lectureNotes = [];
    this.totalItems = 0;
    this.loading = true;
   }

  ngOnInit() {
    this.loadLectureNotes();
  }

  loadLectureNotes() {
    this.loading = true;
  }
}
