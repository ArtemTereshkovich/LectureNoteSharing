import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LecturenotePreviewRatingComponent } from './lecturenote-preview-rating.component';
import { LectureNoteRatingServiceMock } from '../../mocks/lecturenoteratingservice.mock';

describe('LecturenotePreviewRatingComponent', () => {
  let component: LecturenotePreviewRatingComponent;
  let fixture: ComponentFixture<LecturenotePreviewRatingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      providers: [LectureNoteRatingServiceMock],
      declarations: [ LecturenotePreviewRatingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LecturenotePreviewRatingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
