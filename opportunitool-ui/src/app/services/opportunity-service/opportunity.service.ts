import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class OpportunityService {
    private baseServiceUrl = '';

    constructor(
        @Inject('BASE_API_URL') baseApiUrl: string,
        private http: HttpClient
    ) {
        this.baseServiceUrl = baseApiUrl + '/opportunities';
    }

    getAllLocations(): Observable<any> {
        return this.http.get(`${this.baseServiceUrl}/locations`)
            .pipe(
                catchError((error: any) => {
                    console.log(error);
                    return [];
                })
            );
    }
}
