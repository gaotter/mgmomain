import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ComponentsArticleModule } from './components-article.module';
import { ServicesModule } from './services-article.module';

@NgModule({
  declarations: [],
  imports: [CommonModule, ComponentsArticleModule, ServicesModule],
  exports: [ComponentsArticleModule],
})
export class MainArticleModule {}
