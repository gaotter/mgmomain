import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ArticleMainComponent } from '../../components/article-main/article-main.component';
import { RouteArticleModule } from './route-article.module';

@NgModule({
  declarations: [ArticleMainComponent],
  imports: [
    CommonModule,
    RouteArticleModule
  ],
  exports: [
    ArticleMainComponent
  ]
})
export class ComponentsArticleModule { }
