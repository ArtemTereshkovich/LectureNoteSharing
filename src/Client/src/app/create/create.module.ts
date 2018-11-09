import { ModuleWithProviders, NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { CreateComponent } from './create.component';
import { AngularMarkdownEditorModule } from 'angular-markdown-editor';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

const createRouting: ModuleWithProviders = RouterModule.forChild([
   {
        path: 'create',
        component: CreateComponent
   }
]);

@NgModule({
    imports: [
        createRouting,
        SharedModule,
    ],
    declarations: [
        CreateComponent
    ]
})
export class CreateModule {}
