import { HttpClient } from '@angular/common/http';
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
    return this.genericApiService.get(
      `http://localhost:3000/api/dragons/${name}`
    );
  }

  addDragon(dragon: any) {
    return this.genericApiService.post(
      'http://localhost:3000/api/dragons',
      dragon
    );
  }

  updateDragon(dragon: any) {
    return this.genericApiService.put(
      `http://localhost:3000/api/dragons/${dragon.name}`,
      dragon
    );
  }

  deleteDragon(name: string) {
    return this.genericApiService.delete(
      `http://localhost:3000/api/dragons/${name}`
    );
  }
}
