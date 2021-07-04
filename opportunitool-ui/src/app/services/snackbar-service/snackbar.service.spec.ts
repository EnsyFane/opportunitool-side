import { HttpClient } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { FakeHttpClient } from 'src/app/testing/fakes/fake-http-client';

import { SnackbarService } from './snackbar.service';

describe('SnackbarService', () => {
    let service: SnackbarService;
    const fakeHttpClient: FakeHttpClient = new FakeHttpClient();

    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [
                { provide: HttpClient, useValue: fakeHttpClient }
            ],
            imports: [
                MatSnackBarModule
            ]
        });
        service = TestBed.inject(SnackbarService);
    });

    it('should be created', () => {
        expect(service).toBeTruthy();
    });
});
