import { HttpClient } from '@angular/common/http';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { FakeHttpClient } from 'src/app/testing/fakes/fake-http-client';

import { HomeViewComponent } from './home-view.component';

describe('HomeViewComponent', () => {
    let component: HomeViewComponent;
    let fixture: ComponentFixture<HomeViewComponent>;
    const fakeHttpClient: FakeHttpClient = new FakeHttpClient();

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [
                HomeViewComponent
            ],
            imports: [
                MatSnackBarModule
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
        fixture.detectChanges();
    });

    afterEach(() => {
        fakeHttpClient.resetDefaultValues();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
