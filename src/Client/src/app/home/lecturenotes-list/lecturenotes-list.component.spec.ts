import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LecturenotesListComponent } from './lecturenotes-list.component';

describe('LecturenotesListComponent', () => {
  let component: LecturenotesListComponent;
  let fixture: ComponentFixture<LecturenotesListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LecturenotesListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LecturenotesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
