import { NgModule } from '@angular/core';
import { ToolbarComponent } from './toolbar.component';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatToolbarModule } from '@angular/material/toolbar';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { CommonModule } from '@angular/common';

@NgModule({
    declarations: [ToolbarComponent],
    imports: [
        AppRoutingModule,
        CommonModule,
        FormsModule,
        MatButtonModule,
        MatIconModule,
        MatInputModule,
        MatMenuModule,
        MatToolbarModule,
        ReactiveFormsModule
    ],
    exports: [ToolbarComponent]
})
export class OppToolbarModule { }
