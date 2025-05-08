import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { urlResponse } from './url-response';

@Injectable({
    providedIn: 'root',
})
export class UrlServiceService {
    private http = inject(HttpClient);

    private serverUrl = 'http://localhost:5056';
    private httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    };

    redirectUrl(key: string): Observable<any> {
        return this.http.get(`${this.serverUrl}/${key}`);
    }
    shortenUrl(url: string): Observable<urlResponse> {
        return this.http
            .post<urlResponse>(
                `${this.serverUrl}`,
                { url: url },
                this.httpOptions
            )
            .pipe(
                tap((u) =>
                    console.log(`short: ${u.shortUrl}, long: ${u.longUrl}`)
                )
            );
    }
}
