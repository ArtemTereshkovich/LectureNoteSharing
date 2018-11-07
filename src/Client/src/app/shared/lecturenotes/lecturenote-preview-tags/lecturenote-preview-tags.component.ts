import { Component, OnInit, Input } from '@angular/core';
import { LectureNoteTagServiceMock } from '../../mocks/lecturenotetagservice.mock';
import { Tag } from '../../models/tag.models';

@Component({
  selector: 'app-lecturenote-preview-tags',
  templateUrl: './lecturenote-preview-tags.component.html',
  styleUrls: ['./lecturenote-preview-tags.component.css']
})
export class LecturenotePreviewTagsComponent implements OnInit {

  @Input()
  private tagsId: Array<string>;
  public loading: Boolean;
  public tags: Array<Tag>;

  constructor(private lectureNoteTagService: LectureNoteTagServiceMock) {
    this.loading = true;
    this.tags = [];
  }

  ngOnInit() {
    this.loadLectureNoteTag();
  }

  private loadLectureNoteTag() {
    this.loading = true;

    this.lectureNoteTagService.getTags(this.tagsId)
    .subscribe(data => {
      this.loading = false;
      this.tags = data.sort((a: Tag, b: Tag) => a.countOfUse > b.countOfUse ? 1 : 0);
    });
  }

  public tagClick(id: string): void {
    console.log(id);
  }

}
