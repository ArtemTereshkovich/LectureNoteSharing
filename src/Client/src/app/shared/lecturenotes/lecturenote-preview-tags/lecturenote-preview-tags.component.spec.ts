import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LecturenotePreviewTagsComponent } from './lecturenote-preview-tags.component';

describe('LecturenotePreviewTagsComponent', () => {
  let component: LecturenotePreviewTagsComponent;
  let fixture: ComponentFixture<LecturenotePreviewTagsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
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
