import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TestProxyService {

articles = this.getArticles();

  constructor(private http: HttpClient) { }

  getArticles():Observable<any> {
    return this.http.get("/api/articles");
  }
}
