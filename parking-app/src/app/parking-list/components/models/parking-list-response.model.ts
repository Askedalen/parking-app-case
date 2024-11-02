export interface ParkingListResponse {
  id: string;
  name: string;
  totalSpots: number;
  address?: string;
  city: string;
  paidSpots?: number;
  freeSpots?: number;
  chargingSpots?: number;
  chargingSpotsNote?: string;
  disabledSpots?: number;
  disabledSpotsEvaluation?: string;
  parkAndRide: boolean;
  hasToilet?: boolean;
  hasHandicapToilet?: boolean;
  hasBabyChangingTable?: boolean;
  hasShower?: boolean;
  hasAccommodation?: boolean;
  hasBicycleParking?: boolean;
  hasMotorcycleParking?: boolean;
  provider: string;
  parkingAreaType: number;
}
