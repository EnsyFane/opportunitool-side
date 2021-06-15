import { NgModule } from '@angular/core';
import { ToolbarComponent } from './toolbar.component';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
    declarations: [ToolbarComponent],
    imports: [
        FormsModule,
        MatButtonModule,
        MatIconModule,
        MatInputModule,
        MatToolbarModule,
        ReactiveFormsModule
    ],
    exports: [ToolbarComponent]
})
export class OppToolbarModule { }
