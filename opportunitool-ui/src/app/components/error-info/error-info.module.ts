import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { MatButtonModule } from "@angular/material/button";
import { MatExpansionModule } from "@angular/material/expansion";
import { MatIconModule } from "@angular/material/icon";
import { MatSnackBarModule } from "@angular/material/snack-bar";
import { ErrorInfoComponent } from "./error-info.component";

@NgModule({
    declarations: [ErrorInfoComponent],
    imports: [
        MatIconModule,
        CommonModule,
        MatExpansionModule,
        MatSnackBarModule,
        MatButtonModule
    ],
    exports: [ErrorInfoComponent]
})
export class OppErrorInfoModule { }
