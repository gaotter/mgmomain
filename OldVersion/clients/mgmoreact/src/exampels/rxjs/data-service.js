import { Subject } from "rxjs";
import { map, switchMap, shareReplay } from "rxjs/operators";
import { ajax } from "rxjs/ajax";

export class PingService {
  _ferchDataSubject = new Subject("test");

  pingData$ = this._ferchDataSubject.pipe(
    switchMap((data) => ajax(`/api/ping?data=${data}`)),
    map(data => `${data.response.message} tick ${data.response.tick}`),
    shareReplay(1)
  );

  fetchPing(data) {
    this._ferchDataSubject.next(data);
  }
}

export const StaticPingService = new PingService();
