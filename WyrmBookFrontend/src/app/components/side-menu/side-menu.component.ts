import { Component } from '@angular/core';
import { MaterialModule } from '../../modules/material/material.module';

@Component({
  selector: 'app-side-menu',
  standalone: true,
  imports: [MaterialModule],
  templateUrl: './side-menu.component.html',
  styleUrl: './side-menu.component.scss',
})
export class SideMenuComponent {}
