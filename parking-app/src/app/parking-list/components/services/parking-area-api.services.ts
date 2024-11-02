import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ParkingAreaApiService {
  private baseUrl = 'http://localhost:5000/api/parking-area';

  constructor(private http: HttpClient) {}

  getParkingAreas(cityName: string, parkingAreaType?: number, parkAndRide?: boolean, freeSpots?: boolean, chargingSpots?: boolean, disabledSpots?: boolean): Observable<any> {
    let params = new HttpParams();
    if (parkingAreaType && parkingAreaType > 0) params = params.set('parkingAreaType', parkingAreaType);
    if (parkAndRide) params = params.set('parkAndRide', parkAndRide.toString());
    if (freeSpots) params = params.set('freeSpots', freeSpots.toString());
    if (chargingSpots) params = params.set('chargingSpots', chargingSpots.toString());
    if (disabledSpots) params = params.set('disabledSpots', disabledSpots.toString());
    
    return this.http.get(`${this.baseUrl}/city/${cityName}`, { params });
  }
}