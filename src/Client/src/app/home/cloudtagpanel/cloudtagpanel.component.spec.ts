import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CloudtagpanelComponent } from './cloudtagpanel.component';

describe('CloudtagpanelComponent', () => {
  let component: CloudtagpanelComponent;
  let fixture: ComponentFixture<CloudtagpanelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CloudtagpanelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CloudtagpanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
