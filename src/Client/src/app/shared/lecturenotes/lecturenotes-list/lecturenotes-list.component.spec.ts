import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { LecturenotesListComponent } from './lecturenotes-list.component';
import { PaginationModule } from 'ngx-bootstrap';
import { LecturenotePreviewComponent } from '../lecturenote-preview/lecturenote-preview.component';
import { FormsModule } from '@angular/forms';
import { Component, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { LectureNotesListOptions } from './lecutrenotes-list.config';
import { LectureNotesServiceMock } from '../../mocks/lecturenotesservice.mock';

@Component({
  selector: 'app-test-cmp-lecturenotelist',
  template: '<app-lecturenotes-list [defaultConfig]="mockDefaultConfig"></app-lecturenotes-list>'
})
class TestLecturenotesListComponentWrapperComponent {
  mockDefaultConfig: LectureNotesListOptions = {
    filter: null,
    countPerPage: 5,
    currentPage: 1
  };
}

describe('LecturenotesListComponent', () => {
  let component: LecturenotesListComponent;
  let fixture: ComponentFixture<TestLecturenotesListComponentWrapperComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        PaginationModule.forRoot(),
        FormsModule
      ],
      declarations: [
        TestLecturenotesListComponentWrapperComponent,
        LecturenotesListComponent,
        LecturenotePreviewComponent
      ],
      providers: [
        LectureNotesServiceMock
      ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestLecturenotesListComponentWrapperComponent);
    component = fixture.debugElement.children[0].componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

