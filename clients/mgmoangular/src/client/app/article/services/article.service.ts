import { Injectable } from '@angular/core';
import { MainArticleModule } from "../modules/main-article/main-article.module";

@Injectable({
  providedIn: MainArticleModule
})
export class ArticleService {

  constructor() { }
}
