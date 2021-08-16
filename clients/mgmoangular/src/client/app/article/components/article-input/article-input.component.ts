import { Component, OnInit } from '@angular/core';
import { ConnectionsService } from 'src/client/app/services/connections.service';
import { IArticle } from '../../models/article.model';
import { ArticleService } from '../../services/article.service';

@Component({
  selector: 'mgmo-article-input',
  templateUrl: './article-input.component.html',
  styleUrls: ['./article-input.component.scss']
})
export class ArticleInputComponent implements OnInit {

  constructor(private articleService:ArticleService) { }

  ngOnInit(): void {
  }

  testPostArticle() : void {
    var test:IArticle = {
      id:"test",
      title:"Test",
      category:"Testing",
      publishDate: new Date()

    }

    this.articleService.postArticle(test);

  }

}
