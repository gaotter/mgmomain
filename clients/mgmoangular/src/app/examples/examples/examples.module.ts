import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExamplesComponent } from './examples.component';
import { RxjsExampleComponent } from './rxjs-example/rxjs-example.component';
import {ExamplesServicesModule} from './examples-services.module';
import { EventEmitterComponent } from './rxjs-example/event-emitter/event-emitter.component';
import { CombineDataComponent } from './rxjs-example/combine-data/combine-data.component';

@NgModule({
  declarations: [ExamplesComponent, RxjsExampleComponent, EventEmitterComponent, CombineDataComponent],
  imports: [CommonModule, ExamplesServicesModule],
  exports: [ExamplesComponent],
})
export class ExamplesModule {}
