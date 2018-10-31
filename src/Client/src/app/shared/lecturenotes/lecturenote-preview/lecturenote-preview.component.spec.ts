import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LecturenotePreviewComponent } from './lecturenote-preview.component';

describe('LecturenotePreviewComponent', () => {
  let component: LecturenotePreviewComponent;
  let fixture: ComponentFixture<LecturenotePreviewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LecturenotePreviewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LecturenotePreviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
