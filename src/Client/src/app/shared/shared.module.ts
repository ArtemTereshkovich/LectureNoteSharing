import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { LecturenotesListComponent } from './lecturenotes/lecturenotes-list/lecturenotes-list.component';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { FormsModule } from '@angular/forms';
import { LecturenotePreviewComponent } from './lecturenotes/lecturenote-preview/lecturenote-preview.component';
import { LecturenotePreviewRatingComponent } from './lecturenotes/lecturenote-preview-rating/lecturenote-preview-rating.component';
import { LecturenotePreviewTagsComponent } from './lecturenotes/lecturenote-preview-tags/lecturenote-preview-tags.component';

@NgModule({
    imports: [
        CommonModule,
        HttpClientModule,
        RouterModule,
        PaginationModule.forRoot(),
        FormsModule
    ],
    declarations: [
        LecturenotePreviewRatingComponent,
        LecturenotePreviewTagsComponent,
        LecturenotesListComponent,
        LecturenotePreviewComponent
    ],
    exports: [
        LecturenotesListComponent,
        LecturenotePreviewComponent
    ]
})
export class SharedModule {}
