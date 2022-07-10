import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { filter, switchMap } from 'rxjs/operators';
import { RxjsExampleDataService } from '../services/rxjs-example-data.service';

@Component({
  selector: 'app-rxjs-example',
  templateUrl: './rxjs-example.component.html',
  styleUrls: ['./rxjs-example.component.scss'],
  changeDetection:ChangeDetectionStrategy.OnPush
})
export class RxjsExampleComponent {
  pingDataAction$ = new Subject<any>();

  pingData$ = this.pingDataAction$.pipe(
    switchMap((data) => this.dataservice.getPing(data))
  );

  eventMessage:string;

  constructor(private dataservice: RxjsExampleDataService) {}

  getSomeData() {
    this.pingDataAction$.next('hello world');
  }

  handelComponentEvent($event:{message:string}) {
    this.eventMessage = $event.message;
  }
}
