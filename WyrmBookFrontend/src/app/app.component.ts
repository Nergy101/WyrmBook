import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { DragonsListComponent } from './components/dragons-list/dragons-list.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, DragonsListComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  title = 'WyrmBookFrontend';
}
