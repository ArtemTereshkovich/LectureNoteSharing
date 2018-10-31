import { Component, OnInit, ViewChild } from '@angular/core';
import { CloudtagpanelComponent } from './cloudtagpanel/cloudtagpanel.component';
import { SearchpanelComponent } from './searchpanel/searchpanel.component';
import { LectureNotesListConfig } from '../shared/lecturenotes/lecturenotes-list/lecutrenotes-list.config';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  @ViewChild(CloudtagpanelComponent)
  public cloudTagPanelComponent: CloudtagpanelComponent;
  @ViewChild(SearchpanelComponent)
  public searchPanelComponent: SearchpanelComponent;

  lectureNoteListConfig: LectureNotesListConfig;

  constructor() { }

  ngOnInit() {
    this.lectureNoteListConfig = {
      filter: null,
      countPerPage: 5,
      currentPage: 1
    };
  }

}
