import { Component, OnInit, Input } from '@angular/core';
import { LectureNotePreview } from '../../models/lecturenotes.models';

@Component({
  selector: 'app-lecturenote-preview',
  templateUrl: './lecturenote-preview.component.html',
  styleUrls: ['./lecturenote-preview.component.css']
})
export class LecturenotePreviewComponent implements OnInit {

  @Input()
  public lectureNote: LectureNotePreview;

  constructor() { }

  ngOnInit() {
  }

  public readButtonClick(id: string): void {
    console.log(id);
  }
}
