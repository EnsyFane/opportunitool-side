import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatButtonToggleGroup } from '@angular/material/button-toggle';

@Component({
    selector: 'opp-home-view',
    templateUrl: './home-view.component.html',
    styleUrls: ['./home-view.component.scss']
})
export class HomeViewComponent {
    searchOptions: string[] = [$localize`Competitions`, $localize`Conferences`, $localize`Camps`, $localize`Programs`, $localize`Trainings`, $localize`Others`];

    @ViewChild('searchButtons') searchButtons: MatButtonToggleGroup;
}
