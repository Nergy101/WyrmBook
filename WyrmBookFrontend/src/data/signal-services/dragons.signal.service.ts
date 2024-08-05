import {
  computed,
  inject,
  Injectable,
  signal,
  WritableSignal,
} from '@angular/core';
import { DragonsApiService } from '../services/dragons.service';
import { lastValueFrom, Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DragonsSignalService {
  apiService = inject(DragonsApiService);

  all: WritableSignal<any[]> = signal([]);
  count = computed(() => this.all.length);

  constructor() {
    this.getAll();
  }

  async find(name: string): Promise<any | undefined> {
    return lastValueFrom(this.all().find((x: any) => x.name === name));
  }

  async add(dragon: any): Promise<void> {
    const newDragon = await lastValueFrom(this.apiService.addDragon(dragon));
    this.all.update((current) => [...current, newDragon]);
  }

  async update(dragon: any): Promise<void> {
    const updatedDragon = await lastValueFrom(
      this.apiService.updateDragon(dragon)
    );
    this.all.update((current) =>
      current.map((x) => (x.name === dragon.name ? updatedDragon : x))
    );
  }

  async delete(name: string): Promise<void> {
    await lastValueFrom(this.apiService.deleteDragon(name));
    this.all.update((current) => current.filter((x) => x.name !== name));
  }

  private async getAll(): Promise<void> {
    this.all.set((await lastValueFrom(this.apiService.getDragons())) as []);
  }
}
