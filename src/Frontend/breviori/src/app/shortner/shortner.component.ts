import { Clipboard } from '@angular/cdk/clipboard';
import { Location, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { urlResponse } from '../url-response';
import { UrlServiceService } from '../url-service.service';
@Component({
    selector: 'app-shortner',
    standalone: true,
    imports: [NgIf],
    templateUrl: './shortner.component.html',
    styleUrl: './shortner.component.css',
})
export class ShortnerComponent implements OnInit {
    response: urlResponse | undefined;
    constructor(
        private router: ActivatedRoute,
        private urlService: UrlServiceService,
        private clipboard: Clipboard,
        private location: Location
    ) {}

    ngOnInit(): void {
        this.getUrl();
    }

    getUrl(): void {
        const url = this.router.snapshot.paramMap.get('url');

        this.urlService.shortenUrl(url!).subscribe((u) => (this.response = u));
    }

    copyShortenedUrl(shortUrl: string) {
        this.clipboard.copy(shortUrl);
    }

    goBack(): void {
        this.location.back();
    }
}
