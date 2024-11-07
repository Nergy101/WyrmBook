import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { DragonsListComponent } from './components/dragons-list/dragons-list.component';
import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import { SideMenuComponent } from './components/side-menu/side-menu.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    DragonsListComponent,
    LandingPageComponent,
    SideMenuComponent,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  title = 'WyrmBookFrontend';
}
