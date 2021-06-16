import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatMenuTrigger } from '@angular/material/menu';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
    selector: 'opp-toolbar',
    templateUrl: './toolbar.component.html',
    styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent implements OnDestroy {
    searchFormGroup = new FormGroup({
        search: new FormControl('')
    });

    @ViewChild(MatMenuTrigger) menuTrigger: MatMenuTrigger;
    isMenuOpen = false;

    private subsctiption: Subscription = new Subscription();

    constructor(
        private router: Router
    ) { }

    ngOnDestroy(): void {
        this.subsctiption.unsubscribe();
    }

    openMenu(event: Event): void {
        event.preventDefault();
        event.stopPropagation();
        this.menuTrigger.openMenu();
    }

    navigateHome(): void {
        this.router.navigateByUrl('/home');
    }
}
