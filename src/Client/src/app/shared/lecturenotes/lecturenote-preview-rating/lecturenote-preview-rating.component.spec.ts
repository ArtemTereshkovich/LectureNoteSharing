import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LecturenotePreviewRatingComponent } from './lecturenote-preview-rating.component';

describe('LecturenotePreviewRatingComponent', () => {
  let component: LecturenotePreviewRatingComponent;
  let fixture: ComponentFixture<LecturenotePreviewRatingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
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
