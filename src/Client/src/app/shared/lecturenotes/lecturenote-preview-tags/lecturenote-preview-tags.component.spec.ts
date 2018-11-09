import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LecturenotePreviewTagsComponent } from './lecturenote-preview-tags.component';
import { LectureNoteTagServiceMock } from '../../mocks/lecturenotetagservice.mock';

describe('LecturenotePreviewTagsComponent', () => {
  let component: LecturenotePreviewTagsComponent;
  let fixture: ComponentFixture<LecturenotePreviewTagsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      providers: [LectureNoteTagServiceMock],
      declarations: [ LecturenotePreviewTagsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LecturenotePreviewTagsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
