import { inject, Injectable } from '@angular/core';
import { DragonsApiService } from '../services/dragons.service';
import {
  BehaviorSubject,
  lastValueFrom,
  map,
  Observable,
  Subject,
  switchMap,
  tap,
} from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DragonsRxjsService {
  apiService = inject(DragonsApiService);

  _all: BehaviorSubject<any[]> = new BehaviorSubject<any[]>([]);

  all: Observable<any[]> = this._all.asObservable();
  count: Observable<number> = this.all.pipe(map((x) => x.length));

  constructor() {
    this.getAll();
  }

  async find(name: string): Promise<any | undefined> {
    return this._all.value.find((x: any) => x.name === name);
  }

  async add(dragon: any): Promise<void> {
    const newDragon = await lastValueFrom(this.apiService.addDragon(dragon));
    const currentAll = this._all.value;

    this._all.next([currentAll, newDragon]);
  }

  async update(dragon: any): Promise<void> {
    const updatedDragon = await lastValueFrom(
      this.apiService.updateDragon(dragon)
    );
    const currentAll = this._all.value;

    this._all.next(
      currentAll.map((x) => (x.name === dragon.name ? updatedDragon : x))
    );
  }

  async delete(name: string): Promise<void> {
    await lastValueFrom(this.apiService.deleteDragon(name));
    const currentAll = this._all.value;

    this._all.next(currentAll.filter((x) => x.name !== name));
  }

  private async getAll(): Promise<void> {
    const apiResult = await lastValueFrom(this.apiService.getDragons());

    if (apiResult.isSuccess) {
      this._all.next(apiResult.value ?? []);
    }
  }
}
