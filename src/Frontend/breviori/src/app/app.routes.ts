import { Routes } from '@angular/router';
import { ShortnerComponent } from './shortner/shortner.component';

export const routes: Routes = [
    { path: 'shortner/:url', component: ShortnerComponent },
];
