import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { SnackbarService } from '../snackbar-service/snackbar.service';

@Injectable({
    providedIn: 'root'
})
export class OpportunityService {
    constructor(
        private http: HttpClient,
        private snackbarService: SnackbarService
    ) { }

    getAllLocations(): Observable<string[]> {
        return this.http.get(`opportunitool/opportunities/locations`)
            .pipe(
                catchError((error: any) => {
                    return this.handleHttpError(`The request to get all locations failed with error code ${error.status}.`, [])
                })
            );
    }

    private handleHttpError(error: string, toReturn: any): Observable<any> {
        this.snackbarService.displayErrorSnackbar(error);
        return of(toReturn);
    }
}
