import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExamplesComponent } from './examples.component';
import { RxjsExampleComponent } from './rxjs-example/rxjs-example.component';
import {ExamplesServicesModule} from './examples-services.module';
import { EventEmitterComponent } from './rxjs-example/event-emitter/event-emitter.component';

@NgModule({
  declarations: [ExamplesComponent, RxjsExampleComponent, EventEmitterComponent],
  imports: [CommonModule, ExamplesServicesModule],
  exports: [ExamplesComponent],
})
export class ExamplesModule {}
