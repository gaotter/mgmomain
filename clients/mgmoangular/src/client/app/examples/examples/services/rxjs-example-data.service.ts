import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ExamplesServicesModule} from './../examples-services.module';

@Injectable({
  providedIn: ExamplesServicesModule
})
export class RxjsExampleDataService {

  constructor(private httpClient:HttpClient) { }

  getPing(data:any):Observable<any> {
     return this.httpClient.get('/api/ping',{ params:{data:data} });
  }
}
