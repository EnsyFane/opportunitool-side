import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class OpportunityService {
    constructor(
        private http: HttpClient
    ) { }

    getAllLocations(): Observable<any> {
        return this.http.get(`opportunitool/opportunities/locations`)
            .pipe(
                catchError((error: any) => {
                    console.log(error);
                    return [];
                })
            );
    }
}
