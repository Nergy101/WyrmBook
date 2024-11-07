import { Component, effect, inject, OnInit } from '@angular/core';
import { DragonsRxjsService } from '../../../data/signal-services/dragons.rxjs.service';
import { DragonsSignalService } from '../../../data/signal-services/dragons.signal.service';
import { AsyncPipe, CommonModule } from '@angular/common';
import { MaterialModule } from '../../modules/material/material.module';

@Component({
  selector: 'app-dragons-list',
  standalone: true,
  imports: [CommonModule, MaterialModule, AsyncPipe],
  templateUrl: './dragons-list.component.html',
  styleUrl: './dragons-list.component.scss',
})
export class DragonsListComponent implements OnInit {
  dragonsRxjsService = inject(DragonsRxjsService);
  dragonsSignalService = inject(DragonsSignalService);

  allDragons$ = this.dragonsRxjsService.all;
  allDragons = this.dragonsSignalService.all;

  constructor() {
    effect(() => {
      console.log(this.allDragons());
    });
  }

  async ngOnInit(): Promise<void> {
    this.allDragons$.subscribe((dragons) => {
      console.log(dragons);
    });
  }

  async getDragon(name: string) {
    const dragon = await this.dragonsSignalService.find(name);
    console.log(dragon);

    const dragon2 = await this.dragonsRxjsService.find(name);
    console.log(dragon2);
  }

  deleteDragon(name: string) {
    this.dragonsSignalService.delete(name);
    this.dragonsRxjsService.delete(name);
  }
}
