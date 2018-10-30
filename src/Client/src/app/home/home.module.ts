import { ModuleWithProviders, NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home.component';
import { CloudtagpanelComponent } from './cloudtagpanel/cloudtagpanel.component';
import { SearchpanelComponent } from './searchpanel/searchpanel.component';
import { SharedModule } from '../shared/shared.module';
import { LecturenotesListComponent } from './lecturenotes-list/lecturenotes-list.component';

const homeRouting: ModuleWithProviders = RouterModule.forChild([
   {
        path: '',
        pathMatch: 'full',
        component: HomeComponent
   }
]);

@NgModule({
    imports: [
        homeRouting,
        SharedModule
    ],
    declarations: [
        HomeComponent,
        CloudtagpanelComponent,
        SearchpanelComponent,
        LecturenotesListComponent
    ]
})
export class HomeModule {}
