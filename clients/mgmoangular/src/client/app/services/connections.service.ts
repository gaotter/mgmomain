import { Injectable } from '@angular/core';
import { ConnectionModule } from '../modules/connection/connection.module';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from './../../environments/environment';

@Injectable({
  providedIn: "root",
})
export class ConnectionsService {
  constructor(private http: HttpClient) {}

  get<I, T>(uri: string, params: I): Observable<T> {
    return this.http.get(
      environment.apiUrl + uri,
      params
    ) as Observable<T>;
  }
}
