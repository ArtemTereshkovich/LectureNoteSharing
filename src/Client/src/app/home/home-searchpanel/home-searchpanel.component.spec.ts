import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeSearchpanelComponent } from './home-searchpanel.component';

describe('HomeSearchpanelComponent', () => {
  let component: HomeSearchpanelComponent;
  let fixture: ComponentFixture<HomeSearchpanelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HomeSearchpanelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeSearchpanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
