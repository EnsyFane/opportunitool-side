import { HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';

export class FakeHttpClient {
    private calls: any[];
    private locations: any[];

    constructor() {
        this.resetDefaultValues();
    }

    resetDefaultValues(): void {
        this.calls = [];
        this.locations = this.getDefaultLocationsResponse();
    }

    setLocationsResponse(locations: any[]): void {
        this.locations = locations;
    }

    get(url: string): Observable<any> {
        this.calls.push({ url, body: null });

        if (this.matches(/opportunitool\/opportunities\/locations$/i, url)) {
            return of(this.locations);
        }

        return of(this.getNotFoundResponse());
    }

    post(url: string, requestBody: any): Observable<any> {
        this.calls.push({ url, body: requestBody });

        return of(this.getNotFoundResponse());
    }

    private matches(regex: RegExp, url: string): false | RegExpMatchArray {
        const match = url.match(regex);
        if (!match) {
            return false;
        }

        return match;
    }

    private getNotFoundResponse(): HttpErrorResponse {
        return new HttpErrorResponse({
            status: 404
        });
    }

    private getDefaultLocationsResponse(): any[] {
        return [];
    }
}
