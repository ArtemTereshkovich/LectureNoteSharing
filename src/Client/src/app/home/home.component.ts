import { Component, OnInit, ViewChild } from '@angular/core';
import { CloudtagpanelComponent } from './cloudtagpanel/cloudtagpanel.component';
import { SearchpanelComponent } from './searchpanel/searchpanel.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  @ViewChild(CloudtagpanelComponent)
  public cloudTagPanelComponent: CloudtagpanelComponent;
  @ViewChild(SearchpanelComponent)
  public searchPanelComponent: SearchpanelComponent;

  constructor() { }

  ngOnInit() {
  }

}
