import { Component, inject, OnInit } from '@angular/core';
import { DragonsRxjsService } from '../../../data/signal-services/dragons.rxjs.service';
import { DragonsSignalService } from '../../../data/signal-services/dragons.signal.service';
import { AsyncPipe, CommonModule } from '@angular/common';

@Component({
  selector: 'app-dragons-list',
  standalone: true,
  imports: [CommonModule, AsyncPipe],
  templateUrl: './dragons-list.component.html',
  styleUrl: './dragons-list.component.scss',
})
export class DragonsListComponent implements OnInit {
  dragonsRxjsService = inject(DragonsRxjsService);
  dragonsSignalService = inject(DragonsSignalService);

  allDragons$ = this.dragonsRxjsService.all;
  allDragons = this.dragonsSignalService.all;

  async ngOnInit(): Promise<void> {}
}
