import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeCloudtagpanelComponent } from './home-cloudtagpanel.component';

describe('HomeCloudtagpanelComponent', () => {
  let component: HomeCloudtagpanelComponent;
  let fixture: ComponentFixture<HomeCloudtagpanelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HomeCloudtagpanelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeCloudtagpanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
