import { ModuleWithProviders, NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CreateComponent } from './create.component';
import { SharedModule } from '../shared/shared.module';
import { MarkdownModule } from 'ngx-markdown';
import { FormsModule } from '@angular/forms';
import {  ModalModule } from 'ngx-bootstrap';

const createRouting: ModuleWithProviders = RouterModule.forChild([
   {
        path: 'create',
        pathMatch: 'full',
        component: CreateComponent
   }
]);

@NgModule({
    imports: [
        ModalModule.forRoot(),
        FormsModule,
        MarkdownModule.forChild(),
        SharedModule,
        createRouting
    ],
    declarations: [
        CreateComponent
    ]
})
export class CreateModule {}
