import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry, tap } from 'rxjs/operators';
import { ParkingSpace } from '../models/ParkingSpace';

@Injectable({
  providedIn: 'root'
})
export class ParkingSpaceService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  public addVehicle(parkingLotId: number) {
    return this.http.post<ParkingSpace>(this.baseUrl + 'api/ParkingSpace/AddVehicle/' + parkingLotId, {});
  }

  public removeVehicle(parkingLotId: number) {
    return this.http.post<ParkingSpace>(this.baseUrl + 'api/ParkingSpace/RemoveVehicle/' + parkingLotId, {});
  }

}
