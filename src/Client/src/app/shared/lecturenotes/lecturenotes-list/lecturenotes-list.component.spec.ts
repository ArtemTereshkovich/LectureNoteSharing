import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { LecturenotesListComponent } from './lecturenotes-list.component';
import { PaginationModule } from 'ngx-bootstrap';
import { LecturenotePreviewComponent } from '../lecturenote-preview/lecturenote-preview.component';
import { FormsModule } from '@angular/forms';
import { Component, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { LectureNotesListConfig } from './lecutrenotes-list.config';

@Component({
  selector  : 'app-test-cmp',
  template  : '<app-lecturenotes-list [defaultConfig]="mockDefaultConfig"></app-lecturenotes-list>'
 })
 class TestWrapperComponent {
     mockDefaultConfig = new LectureNotesListConfig(); // mock your input
 }

describe('LecturenotesListComponent', () => {
  let component: LecturenotesListComponent;
  let fixture: ComponentFixture<TestWrapperComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        PaginationModule.forRoot(),
        FormsModule
       ],
      declarations: [
        TestWrapperComponent,
        LecturenotesListComponent,
        LecturenotePreviewComponent
     ],
     schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestWrapperComponent);
    component = fixture.debugElement.children[0].componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

