import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry, tap } from 'rxjs/operators';
import { ParkingLot } from '../models/ParkingLot';

@Injectable({
  providedIn: 'root'
})
export class ParkingLotService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getParkingLots(): Observable<ParkingLot[]>  {
    return this.http.get<ParkingLot[]>(this.baseUrl + 'api/ParkingLot/GetParkingLots/');
  }

  getParkingLotById(parkingLotId: number) {
    return this.http.get<ParkingLot>(this.baseUrl + 'api/ParkingLot/GetParkingLotById/' + parkingLotId);
  }

}
