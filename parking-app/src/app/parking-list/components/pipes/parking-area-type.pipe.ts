import { Pipe } from "@angular/core";

@Pipe({
    name: 'parkingAreaType',
    standalone: true,
    pure: true
})
export class ParkingAreaTypePipe {
    transform(value: number): string {
        switch (value) {
            case 0:
                return 'Ikke spesifisert';
            case 1:
                return 'Parkeringshus';
            case 2:
                return 'Langs kjørebane';
            case 3:
                return 'Avgrenset område';
            default:
                return 'Ukjent';
        }
    }
}
