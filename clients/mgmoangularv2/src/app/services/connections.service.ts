import { Injectable } from '@angular/core';
import { ConnectionModule } from '../modules/connection/connection.module';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: ConnectionModule,
})
export class ConnectionsService {
  constructor(private http: HttpClient) {}

  get<I, T>(uri: string, params: I): Observable<T> {
    return this.http.get('/api/articles', params) as Observable<T>;
  }
}
