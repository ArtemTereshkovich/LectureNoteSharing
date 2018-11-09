import { ModuleWithProviders, NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CreateComponent } from './create.component';
import { SharedModule } from '../shared/shared.module';

const createRouting: ModuleWithProviders = RouterModule.forChild([
   {
        path: 'create',
        pathMatch: 'full',
        component: CreateComponent
   }
]);

@NgModule({
    imports: [
        SharedModule,
        createRouting
    ],
    declarations: [
        CreateComponent
    ]
})
export class CreateModule {}
