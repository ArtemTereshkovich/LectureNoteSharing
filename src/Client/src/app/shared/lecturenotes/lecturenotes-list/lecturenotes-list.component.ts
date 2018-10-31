import { Component, OnInit, Input } from '@angular/core';
import { LectureNotesListConfig } from './lecutrenotes-list.config';

@Component({
  selector: 'app-lecturenotes-list',
  templateUrl: './lecturenotes-list.component.html',
  styleUrls: ['./lecturenotes-list.component.css']
})
export class LecturenotesListComponent implements OnInit {

  @Input()
  private defaultConfig: LectureNotesListConfig;
  private totalItems = 0;
  private load: Boolean;

  constructor() { }

  ngOnInit() {
    this.load = true;
  }

}
