import { Component, Input } from '@angular/core';
import { ParkingListResponse } from '../models/parking-list-response.model';
import { CommonModule } from '@angular/common';
import { ParkingAreaTypePipe } from '../pipes/parking-area-type.pipe';
import { JaNeiPipe } from '../pipes/ja-nei.pipe';

@Component({
  selector: 'parking-list',
  standalone: true,
  imports: [CommonModule, ParkingAreaTypePipe, JaNeiPipe],
  templateUrl: './parking-list.component.html',
  styleUrl: './parking-list.component.scss'
})
export class ParkingListComponent {
  @Input()
  parkingList: ParkingListResponse[] | null;
  
  expandedParking: ParkingListResponse | null = null;

  updateExpandedParking(parkingArea: ParkingListResponse) {
    this.expandedParking = this.expandedParking == parkingArea ? null : parkingArea;
  }
}
