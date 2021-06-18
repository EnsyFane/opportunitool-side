import { Component, Input } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
    selector: 'opp-toolbar',
    templateUrl: './toolbar.component.html',
    styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent {
    /**
     * Whether or not the user is logged in.
     */
    @Input() isLoggedIn = false;

    searchFormGroup = new FormGroup({
        search: new FormControl('')
    });

    constructor(
        private router: Router
    ) { }

    navigateHome(): void {
        this.router.navigateByUrl('/home');
    }
}
