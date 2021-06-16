import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { ScrollUpComponent } from './scroll-up.component';

@NgModule({
    declarations: [ScrollUpComponent],
    imports: [
        MatButtonModule,
        MatIconModule,
        CommonModule
    ],
    exports: [ScrollUpComponent]
})
export class OppScrollUpModule { }
