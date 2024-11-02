import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { Observable } from 'rxjs';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatOptionModule } from '@angular/material/core';
import { ParkingListResponse } from '../models/parking-list-response.model';
import { ParkingAreaApiService } from '../services/parking-area-api.services';
import { ParkingListComponent } from '../parking-list/parking-list.component';
import { HttpClientModule } from '@angular/common/http';

type SearchForm = FormGroup<{
  city: FormControl<string | null>;
  type: FormControl<number | null>;
}>;

@Component({
  selector: 'parking-list-page',
  standalone: true,
  imports: [
    ParkingListComponent,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    CommonModule,
    MatCheckboxModule,
    MatOptionModule,
  ],
  templateUrl: './parking-list-page.component.html',
  styleUrl: './parking-list-page.component.scss'
})
export class ParkingListPageComponent {
  formGroup: SearchForm;
  freeParking: boolean = false;
  charging: boolean = false;
  handicap: boolean = false;
  parkAndRide: boolean = false;

  parkings$: Observable<ParkingListResponse[]>;

  constructor(private formBuilder: FormBuilder, private parkingAreaApiService: ParkingAreaApiService) {
    this.formGroup = this.formBuilder.group({ city: ['Sandefjord', Validators.required], type: [0] });
  }

  search() {
    this.parkings$ = this.parkingAreaApiService.getParkingAreas(
      this.formGroup.value.city!,
      this.formGroup.value.type!,
      this.parkAndRide,
      this.freeParking,
      this.charging,
      this.handicap
    );
  }

  updateFreeParking(checked: boolean) {
    this.freeParking = checked;
  }

  updateCharging(checked: boolean) {
    this.charging = checked;
  }

  updateHandicap(checked: boolean) {
    this.handicap = checked;
  }

  updateParkAndRide(checked: boolean) {
    this.parkAndRide = checked;
  }
}
