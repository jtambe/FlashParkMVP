import { Component, OnInit , Inject} from '@angular/core';
import { ParkingLot } from '../models/ParkingLot';
import { HttpClient } from '@angular/common/http';
import { ParkingLotService } from '../services/parking-lot.service';
import { ParkingSpaceService } from '../services/parking-space.service';
import { BehaviorSubject } from 'rxjs';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-parking-lots',
  templateUrl: './parking-lots.component.html',
  styleUrls: ['./parking-lots.component.css'],
})
export class ParkingLotsComponent implements OnInit {

  public parkingLots: Array<ParkingLot> = [];

  public refreshParkingLots = new BehaviorSubject<boolean>(true);

  constructor(private parkingLotService: ParkingLotService, private parkingSpaceService: ParkingSpaceService ) {
  }

  ngOnInit() {

    this.getParkingLots();
  }

  public getParkingLots() {

    this.parkingLotService.getParkingLots()
      .subscribe(result => {
        this.parkingLots = result;
      }, error => console.error(error));


  }

  public addVehicle(parkingLot) {
    this.parkingSpaceService.addVehicle(parkingLot.parkingLotId).subscribe(result => {

      if (result.parkingSpaceId === 0) {
        alert('Garage is full.')
      }
      else {
        let pkLot = this.parkingLots.find(x => x.parkingLotId == parkingLot.parkingLotId);
        pkLot.availableSpaces = pkLot.availableSpaces - 1;

      }
    }, error => console.error(error));
  }

  public removeVehicle(parkingLot) {
    this.parkingSpaceService.removeVehicle(parkingLot.parkingLotId).subscribe(result => {
      if (result.parkingSpaceId === 0) { alert('Garage is empty.') }
      else {
        let pkLot = this.parkingLots.find(x => x.parkingLotId == parkingLot.parkingLotId);
        pkLot.availableSpaces = pkLot.availableSpaces + 1;
      }
    }, error => console.error(error));
  }


}
