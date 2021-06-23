import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { HomeViewComponent } from './home-view.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';

@NgModule({
    declarations: [HomeViewComponent],
    imports: [
        MatButtonModule,
        MatIconModule,
        CommonModule,
        MatCardModule,
        MatButtonToggleModule,
        MatFormFieldModule,
        ReactiveFormsModule,
        MatInputModule
    ],
    exports: [HomeViewComponent]
})
export class OppHomeViewModule { }
