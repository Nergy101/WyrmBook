import { inject, Injectable } from '@angular/core';
import { GenericApiService } from './generic-api.service';

@Injectable({
  providedIn: 'root',
})
export class DragonsApiService {
  genericApiService = inject(GenericApiService);

  constructor() {}

  getDragons() {
    return this.genericApiService.get('dragons');
  }

  getDragon(name: string) {
    return this.genericApiService.get(`dragons/${name}`);
  }

  addDragon(dragon: any) {
    return this.genericApiService.post('dragons', dragon);
  }

  updateDragon(dragon: any) {
    return this.genericApiService.put(`dragons/${dragon.name}`, dragon);
  }

  deleteDragon(name: string) {
    return this.genericApiService.delete(`dragons/${name}`);
  }
}
