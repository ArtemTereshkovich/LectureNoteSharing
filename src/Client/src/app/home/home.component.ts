import { Component, OnInit, ViewChild } from '@angular/core';
import { HomeCloudtagpanelComponent } from './home-cloudtagpanel/home-cloudtagpanel.component';
import { HomeSearchpanelComponent } from './home-searchpanel/home-searchpanel.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  @ViewChild(HomeCloudtagpanelComponent)
  public cloudTagPanelComponent: HomeCloudtagpanelComponent;
  @ViewChild(HomeSearchpanelComponent)
  public searchPanelComponent: HomeSearchpanelComponent;

  constructor() { }

  ngOnInit() {
  }

}
