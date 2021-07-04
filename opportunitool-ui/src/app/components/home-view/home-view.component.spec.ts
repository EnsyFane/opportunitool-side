import { TestbedHarnessEnvironment } from '@angular/cdk/testing/testbed';
import { HttpClient } from '@angular/common/http';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatCardModule } from '@angular/material/card';
import { MatOptionModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { FakeHttpClient } from 'src/app/testing/fakes/fake-http-client';
import { HomeViewPageObject } from '../../testing/page-objects/home-view.pageobject';

import { HomeViewComponent } from './home-view.component';

describe('HomeViewComponent', () => {
    let component: HomeViewComponent;
    let fixture: ComponentFixture<HomeViewComponent>;
    const fakeHttpClient: FakeHttpClient = new FakeHttpClient();
    let page: HomeViewPageObject;

    async function refreshComponent(): Promise<void> {
        fixture.detectChanges();
        await fixture.whenStable();
    }

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [
                HomeViewComponent
            ],
            imports: [
                MatSnackBarModule,
                MatSelectModule,
                MatCardModule,
                MatFormFieldModule,
                MatInputModule,
                MatButtonToggleModule,
                MatOptionModule,
                NoopAnimationsModule
            ],
            providers: [
                { provide: HttpClient, useValue: fakeHttpClient }
            ],
            schemas: [NO_ERRORS_SCHEMA]
        }).compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(HomeViewComponent);
        component = fixture.componentInstance;
        const loader = TestbedHarnessEnvironment.loader(fixture);
        page = new HomeViewPageObject(fixture.nativeElement, loader);
    });

    afterEach(() => {
        fakeHttpClient.resetDefaultValues();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });

    it('should display the correct locations in location drop-down', async () => {
        const locations = ['location1', 'location2', 'location3'];
        fakeHttpClient.setLocationsResponse(locations);
        await refreshComponent();

        page.clickLocationDropDown();
        await refreshComponent();

        const options = await page.getLocationDropDownContents();
        expect(options.length).toEqual(locations.length);

    });
});
