import { Pipe } from "@angular/core";

@Pipe({
    name: 'jaNei',
    standalone: true,
    pure: true
})
export class JaNeiPipe {
    transform(value?: boolean): string {
        console.log(value);
        return value ? 'Ja' : 'Nei';
    }
}
