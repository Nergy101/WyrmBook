import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import Environment from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class GenericApiService {
  readonly httpClient = inject(HttpClient);
  readonly environment = inject(Environment);

  private readonly baseUrl: string;

  constructor() {
    this.baseUrl = this.environment.apiUrl;
  }

  get(url: string) {
    return this.httpClient.get(this.baseUrl + url);
  }

  post(url: string, body: any) {
    return this.httpClient.post(this.baseUrl + url, body);
  }

  put(url: string, body: any) {
    return this.httpClient.put(this.baseUrl + url, body);
  }

  delete(url: string) {
    return this.httpClient.delete(this.baseUrl + url);
  }
}
