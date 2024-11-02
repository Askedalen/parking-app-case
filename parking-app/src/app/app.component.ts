import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MatToolbarModule } from '@angular/material/toolbar'; 
import { MatSidenavModule } from '@angular/material/sidenav'; 
import { MatListModule } from '@angular/material/list'; // Import MatListModule

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, MatToolbarModule, MatSidenavModule, MatListModule], // Add MatListModule to imports
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'parking-app';
}
