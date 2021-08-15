import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ComponentsArticleModule } from './components-article.module';
import { ServicesModule } from './services-article.module';
import { RouteArticleModule } from './route-article.module';

@NgModule({
  declarations: [],
  imports: [CommonModule, ComponentsArticleModule, ServicesModule, RouteArticleModule],
  exports: [ComponentsArticleModule, RouteArticleModule],
})
export class MainArticleModule {}
