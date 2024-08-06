import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { catchError, EMPTY, Observable, of, tap } from 'rxjs';
import {
  ValueResultResponseModel,
  VoidResultResponseModel,
} from '../models/api-result';
// import Environment from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class GenericApiService {
  readonly httpClient = inject(HttpClient);
  // readonly environment = inject(Environment);

  private readonly baseUrl: string;

  constructor() {
    this.baseUrl = 'http://localhost:5112/api/'; // this.environment.apiUrl;

    this.httpClient.options;
  }

  private handleError(error: HttpErrorResponse): Observable<any> {
    if (!error.error.isSuccess) {
      console.warn('Server response not OK', error.error?.errors);
    }
    return of(EMPTY);
  }

  get<T>(url: string): Observable<ValueResultResponseModel<T>> {
    return (
      this.httpClient.get(this.baseUrl + url) as Observable<
        ValueResultResponseModel<T>
      >
    ).pipe(catchError(this.handleError));
  }

  post<T>(url: string, body: T) {
    return (
      this.httpClient.post(this.baseUrl + url, body) as Observable<
        ValueResultResponseModel<T>
      >
    ).pipe(catchError(this.handleError));
  }

  put<T>(url: string, body: T) {
    return (
      this.httpClient.put(this.baseUrl + url, body) as Observable<
        ValueResultResponseModel<T>
      >
    ).pipe(catchError(this.handleError));
  }

  delete(url: string) {
    return (
      this.httpClient.delete(
        this.baseUrl + url
      ) as Observable<VoidResultResponseModel>
    ).pipe(catchError(this.handleError));
  }
}
