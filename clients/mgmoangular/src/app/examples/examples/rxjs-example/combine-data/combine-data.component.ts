import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { combineLatest, Subject } from 'rxjs';
import { filter, map, switchMap, tap } from 'rxjs/operators';
import { RxjsExampleDataService } from '../../services/rxjs-example-data.service';

@Component({
  selector: 'app-combine-data',
  templateUrl: './combine-data.component.html',
  styleUrls: ['./combine-data.component.scss'],
  changeDetection:ChangeDetectionStrategy.OnPush
})
export class CombineDataComponent {
  nameAction$ = new Subject<string>();
  ageAction$ = new Subject<string>();

  compindedElementsResponse$ = combineLatest([
    this.nameAction$.pipe(filter(v => !!v)),
    this.ageAction$.pipe(filter(v => !!v)),
  ]).pipe(
    map(([name, age]) => `you'r name is ${name} 😂 and you'r age is ${age} 👴`),
    switchMap((userInfo) => this.dataservice.getPing(userInfo)),
    map(response => `${response.message}, ticks ${response.tick}`)
  );

  constructor(private dataservice: RxjsExampleDataService) {}

  onInputNameInputBlur(name) {
    console.log(`name entered ${name}`)
    this.nameAction$.next(name);
  }

  onAgeInputBlure(age) {
    console.log(`age entred ${age}`)
    this.ageAction$.next(age);
  }
}
