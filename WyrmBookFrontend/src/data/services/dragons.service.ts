import { inject, Injectable } from '@angular/core';
import { GenericApiService } from './generic-api.service';
import { ValueResultResponseModel } from '../models/api-result';
import { Dragon } from '../models/dragon.model';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DragonsApiService {
  genericApiService = inject(GenericApiService);

  getDragons(): Observable<ValueResultResponseModel<Dragon[]>> {
    return this.genericApiService.get<Dragon[]>('dragons');
  }

  getDragon(name: string) {
    return this.genericApiService.get<Dragon>(`dragons/${name}`);
  }

  addDragon(dragon: any) {
    return this.genericApiService.post<Dragon>('dragons', dragon);
  }

  updateDragon(dragon: any) {
    return this.genericApiService.put<Dragon>(`dragons/${dragon.name}`, dragon);
  }

  deleteDragon(name: string) {
    return this.genericApiService.delete(`dragons/${name}`);
  }
}
