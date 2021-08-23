import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
//import { ComponentsArticleModule } from './components-article.module';
import { ServicesModule } from './services-article.module';
import { RouteArticleModule } from './route-article.module';
import { ArticleMainComponent } from '../../components/article-main/article-main.component';
import { ArticleInputComponent } from '../../components/article-input/article-input.component';
import { ArticleListComponent } from '../../components/article-list/article-list.component';

@NgModule({
  declarations: [ArticleMainComponent, ArticleInputComponent, ArticleListComponent],
  imports: [CommonModule, ServicesModule, RouteArticleModule],
  exports: [RouteArticleModule, ArticleInputComponent, ArticleMainComponent],
})
export class MainArticleModule {}
