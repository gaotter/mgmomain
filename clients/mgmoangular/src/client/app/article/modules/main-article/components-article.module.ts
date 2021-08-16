import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ArticleMainComponent } from '../../components/article-main/article-main.component';
import { ArticleInputComponent} from '../../components/article-input/article-input.component';

@NgModule({
  declarations: [ArticleMainComponent, ArticleInputComponent],
  imports: [
    CommonModule
  ],
  exports: [
    ArticleMainComponent
  ]
})
export class ComponentsArticleModule { }
