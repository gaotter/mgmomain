import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { ExamplesModule} from './examples/examples/examples.module';
import { MainArticleModule} from './article/modules/main-article/main-article.module';
import { TitleSectionComponent } from './main/components/title-section/title-section.component';

@NgModule({
  declarations: [
    AppComponent,
    TitleSectionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ExamplesModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
