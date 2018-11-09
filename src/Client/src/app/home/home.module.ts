import { ModuleWithProviders, NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home.component';
import { CloudtagpanelComponent } from './cloudtagpanel/cloudtagpanel.component';
import { SearchpanelComponent } from './searchpanel/searchpanel.component';
import { SharedModule } from '../shared/shared.module';

const homeRouting: ModuleWithProviders = RouterModule.forChild([
   {
        path: '',
        pathMatch: 'full',
        component: HomeComponent
   }
]);

@NgModule({
    imports: [
        SharedModule,
        homeRouting
    ],
    declarations: [
        HomeComponent,
        CloudtagpanelComponent,
        SearchpanelComponent
    ]
})
export class HomeModule {}
