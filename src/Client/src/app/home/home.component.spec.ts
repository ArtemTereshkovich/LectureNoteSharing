import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HomeComponent } from './home.component';
import { CloudtagpanelComponent } from './cloudtagpanel/cloudtagpanel.component';
import { SearchpanelComponent } from './searchpanel/searchpanel.component';
import { SharedModule } from '../shared/shared.module';
import { LectureNotesServiceMock } from '../shared/mocks/lecturenotesservice.mock';
import { LectureNotePreview } from '../shared/models/lecturenotes.models';

describe('HomeComponent', () => {
  let component: HomeComponent;
  let fixture: ComponentFixture<HomeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        SharedModule
      ],
      declarations: [
        HomeComponent,
        CloudtagpanelComponent,
        SearchpanelComponent,
      ],
      providers: [
        LectureNotesServiceMock
      ],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
