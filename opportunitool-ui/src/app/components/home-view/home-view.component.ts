import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatButtonToggleGroup } from '@angular/material/button-toggle';
import { Subscription } from 'rxjs';
import { tap } from 'rxjs/operators';
import { OpportunityService } from 'src/app/services/opportunity-service/opportunity.service';

@Component({
    selector: 'opp-home-view',
    templateUrl: './home-view.component.html',
    styleUrls: ['./home-view.component.scss']
})
export class HomeViewComponent implements OnInit, OnDestroy {
    searchOptions: string[] = [$localize`Competitions`, $localize`Conferences`, $localize`Camps`, $localize`Programs`, $localize`Trainings`, $localize`Others`];
    domains: string[] = [];
    locations: string[] = [];

    @ViewChild('searchButtons') private searchButtons: MatButtonToggleGroup;
    private subscriptions: Subscription = new Subscription();

    constructor(
        private opportunityService: OpportunityService
    ) { }

    ngOnInit(): void {
        const subscription = this.opportunityService.getAllLocations()
            .pipe(
                tap((locations) => {
                    this.locations = locations;
                })
            ).subscribe();
        this.subscriptions.add(subscription);
    }

    ngOnDestroy(): void {
        this.subscriptions.unsubscribe();
    }
}
