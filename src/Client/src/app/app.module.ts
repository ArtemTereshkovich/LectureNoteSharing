import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ModuleWithProviders } from '@angular/core';

import { AppComponent } from './app.component';
import { HeaderComponent } from './shared/layout/header/header.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeModule } from './home/home.module';
import { RouterModule } from '@angular/router';
import { JWTService } from './shared/services/jwt.service';
import { SharedModule } from './shared/shared.module';
import { LectureNotesServiceMock } from './shared/mocks/lecturenotesservice.mock';
import { LectureNoteTagServiceMock } from './shared/mocks/lecturenotetagservice.mock';
import { LectureNoteRatingServiceMock } from './shared/mocks/lecturenoteratingservice.mock';
import { FormsModule } from '@angular/forms';
import { CreateComponent } from './create/create.component';
import { CreateModule } from './create/create.module';

const rootRouting: ModuleWithProviders = RouterModule.forRoot([], { useHash: true });

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent
  ],
  imports: [
    rootRouting,
    BrowserAnimationsModule,
    FormsModule,
    BrowserModule,
    HomeModule,
    CreateModule
  ],
  providers: [
      JWTService,
      LectureNotesServiceMock,
      LectureNoteTagServiceMock,
      LectureNoteRatingServiceMock
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
