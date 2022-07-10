import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ExamplesServicesModule } from './../examples-services.module';
import { environment } from './../../../../environments/environment';

@Injectable({
  providedIn: ExamplesServicesModule,
})
export class RxjsExampleDataService {
  constructor(private httpClient: HttpClient) {}

  getPing(data: any): Observable<any> {
    return this.httpClient.get(environment.apiUrl + '/ping', {
      params: { data: data },
    });
  }
}
