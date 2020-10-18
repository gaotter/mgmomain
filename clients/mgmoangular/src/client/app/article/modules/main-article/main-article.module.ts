import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ComponentsArticleModule } from './components-article.module';

@NgModule({
  declarations: [],
  imports: [CommonModule, ComponentsArticleModule],
  exports: [ComponentsArticleModule],
})
export class MainArticleModule {}
