import {
  Component,
  EventEmitter,
  OnDestroy,
  OnInit,
  Output,
} from '@angular/core';
import { Subscription } from 'rxjs';
import { tap } from 'rxjs/operators';

@Component({
  selector: 'app-event-emitter',
  templateUrl: './event-emitter.component.html',
  styleUrls: ['./event-emitter.component.scss'],
})
export class EventEmitterComponent implements OnInit, OnDestroy {
  @Output() eventEmitted = new EventEmitter<{ message: string }>();

  eventSub: Subscription;

  ngOnInit(): void {
    this.eventSub = this.eventEmitted
      .pipe(
        tap((event) =>
          console.log(
            `button was clicked at ${new Date().getTime()} width message ${
              event.message
            }`
          )
        )
      )
      .subscribe();
  }

  ngOnDestroy(): void {
    if (this?.eventSub.closed === false) {
      this.eventSub.unsubscribe();
    }
  }

  emitEvent() {
    this.eventEmitted.next({
      message: 'ha en fin dag',
    });
  }
}
