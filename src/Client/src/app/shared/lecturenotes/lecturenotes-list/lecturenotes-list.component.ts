import { Component, OnInit, Input } from '@angular/core';
import { LectureNotesListOptions } from './lecutrenotes-list.config';
import { LectureNotesServiceMock } from '../../mocks/lecturenotesservice.mock';
import { LectureNotePreview } from '../../models/lecturenotes.models';
import { LectureNotesQuery } from '../../models/lecturenotesservice.model';

@Component({
  selector: 'app-lecturenotes-list',
  templateUrl: './lecturenotes-list.component.html',
  styleUrls: ['./lecturenotes-list.component.css']
})
export class LecturenotesListComponent implements OnInit {

  @Input()
  set defaultConfig(defaultConfig: LectureNotesListOptions) {
    this.lectureNoteQuery = {
      ratingSort: true,
      offset: 0,
      limit: defaultConfig.countPerPage,
      filter: {
          tags: [ defaultConfig.filter === null ? null :  this.defaultConfig.filter.defaultTag  ]
      }
    };
    this.currentPage = defaultConfig.currentPage;
  }

  public lectureNoteQuery: LectureNotesQuery;
  public totalItems: number;
  public loading: Boolean;
  public currentPage: number;
  public lectureNotes: Array<LectureNotePreview>;

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

  loadLectureNotes(): void  {
    this.lectureNoteQuery.offset = this.currentPage * this.lectureNoteQuery.limit;
    this.loading = true;

    this.lectureNoteService.getLectureNotesPreview(this.lectureNoteQuery).subscribe(data => {
      this.totalItems = data.count;
      this.lectureNotes = data.lectureNotes;
      this.loading = false;
    });
  }

  pageChanged(event: any): void {
    this.currentPage = event.page;
    this.loadLectureNotes();
  }
}
