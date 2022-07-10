import { Injectable } from '@angular/core';
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

  post<I, T>(uri:string, params: I):Observable<T>  {
    return this.http.post(environment.apiUrl + uri, params) as Observable<T>;
  }

  put<I, T>(uri:string, params: I):Observable<T>  {
    return this.http.put(environment.apiUrl + uri, params) as Observable<T>;
  }

  delete<I, T>(uri:string, params: I):Observable<T>  {
    return this.http.delete(environment.apiUrl + uri, params) as Observable<T>;
  }
}
