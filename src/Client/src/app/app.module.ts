import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './shared/layout/header/header.component';
import { HomeSearchpanelComponent } from './home/home-searchpanel/home-searchpanel.component';
import { HomeCloudtagpanelComponent } from './home/home-cloudtagpanel/home-cloudtagpanel.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    HomeSearchpanelComponent,
    HomeCloudtagpanelComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
