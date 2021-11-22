import { Component, OnInit , Inject} from '@angular/core';
import { ParkingLot } from '../models/ParkingLot';
import { ParkingLotService } from '../services/parking-lot.service';
import { ParkingSpaceService } from '../services/parking-space.service';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { find, filter, map, switchMap, switchMapTo } from 'rxjs/operators';

@Component({
  selector: 'app-parking-lots',
  templateUrl: './parking-lots.component.html',
  styleUrls: ['./parking-lots.component.css'],
})
export class ParkingLotsComponent implements OnInit {

  //public parkingLots: Array<ParkingLot> = [];
  public parkingLots: Array<ParkingLot> = []

  public parkingLotsObservable: Observable<Array<ParkingLot>> = of([])

  public refreshParkingLots = new BehaviorSubject<boolean>(true);

  constructor(private parkingLotService: ParkingLotService, private parkingSpaceService: ParkingSpaceService ) {
  }

  ngOnInit() {

    //this.getParkingLots();
    this.parkingLotsObservable = this.refreshParkingLots.pipe(switchMap(_  => this.parkingLotService.getParkingLots()))
  }

  public getParkingLots() {

    this.parkingLotService.getParkingLots()
      .subscribe(result => {
        this.parkingLotsObservable = of(result);
        console.log(this.parkingLotsObservable)
      }, error => console.error(error));

    

  }

  public addVehicle(parkingLot) {
    this.parkingSpaceService.addVehicle(parkingLot.parkingLotId).subscribe(result => {

      if (result.parkingSpaceId === 0) {
        alert('Garage is full.')
      }
      else {

        //let pkLot = this.parkingLotsObservable.pipe(filter (x => x.parkingLotId == parkingLot.parkingLotId ))
        //pkLot.availableSpaces = pkLot.availableSpaces - 1;

        this.refreshParkingLots.next(true);

      }
    }, error => console.error(error));
  }

  public removeVehicle(parkingLot) {
    this.parkingSpaceService.removeVehicle(parkingLot.parkingLotId).subscribe(result => {
      if (result.parkingSpaceId === 0) { alert('Garage is empty.') }
      else {

        //let pkLot = this.parkingLots.find(x => x.parkingLotId == parkingLot.parkingLotId);
        //pkLot.availableSpaces = pkLot.availableSpaces + 1;

        this.refreshParkingLots.next(true);
      }
    }, error => console.error(error));
  }


}
