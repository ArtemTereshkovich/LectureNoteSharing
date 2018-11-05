import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-lecturenote-preview-tags',
  templateUrl: './lecturenote-preview-tags.component.html',
  styleUrls: ['./lecturenote-preview-tags.component.css']
})
export class LecturenotePreviewTagsComponent implements OnInit {

  @Input()
  private tagsId: Array<string>;
  private loading: Boolean;

  constructor() {
    this.loading = true;
  }

  ngOnInit() {
  }

}
