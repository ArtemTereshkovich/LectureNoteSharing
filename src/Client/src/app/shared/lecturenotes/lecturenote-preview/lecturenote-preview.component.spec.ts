import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LecturenotePreviewComponent } from './lecturenote-preview.component';
import { LectureNotePreview } from '../../models/lecturenotes.models';
import { Component, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { LecturenotePreviewRatingComponent } from '../lecturenote-preview-rating/lecturenote-preview-rating.component';
import { LecturenotePreviewTagsComponent } from '../lecturenote-preview-tags/lecturenote-preview-tags.component';
import { LectureNoteTagServiceMock } from '../../mocks/lecturenotetagservice.mock';
import { LectureNoteRatingServiceMock } from '../../mocks/lecturenoteratingservice.mock';

@Component({
  selector: 'app-test-cmp-lecturenotepreview',
  template: '<app-lecturenote-preview [lectureNote]="mockLectureNote"></app-lecturenote-preview>'
})
class TestLecturenotePreviewComponentWrapperComponent {
  mockLectureNote: LectureNotePreview = {
    id: 'note1',
    description: 'Some example of description',
    dateOfCreate: new Date(),
    tagsId: ['tag1', 'tag2', 'tag3'],
    authorId: 'author1',
    title: 'SOME MAGIC BEYTIFUL KONSPECt'
  };
}

describe('LecturenotePreviewComponent', () => {
  let component: LecturenotePreviewComponent;
  let fixture: ComponentFixture<TestLecturenotePreviewComponentWrapperComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      providers: [
        LectureNoteRatingServiceMock,
        LectureNoteTagServiceMock
      ],
      declarations: [
        LecturenotePreviewComponent,
        TestLecturenotePreviewComponentWrapperComponent,
        LecturenotePreviewRatingComponent,
        LecturenotePreviewTagsComponent
       ],
       schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestLecturenotePreviewComponentWrapperComponent);
    component = fixture.debugElement.children[0].componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
