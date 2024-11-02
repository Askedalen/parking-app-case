import { Routes } from '@angular/router';

export const routes: Routes = [
    { 
        path: 'parking-list', loadComponent: () => import('./parking-list/components/parking-list-page/parking-list-page.component').then(m => m.ParkingListPageComponent)
    },
    {
        path: 'info', loadComponent: () => import('./info/components/info-page/info-page.component').then(m => m.InfoPageComponent)
    },
    { path: '', redirectTo: 'parking-list', pathMatch: 'full' },
    { path: '**', redirectTo: 'parking-list' }
];
