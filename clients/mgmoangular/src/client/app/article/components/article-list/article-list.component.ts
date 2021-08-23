import { Component, OnInit } from '@angular/core';
import { ArticleService } from '../../services/article.service';

@Component({
  templateUrl: './article-list.component.html',
  styleUrls: ['./article-list.component.scss']
})
export class ArticleListComponent implements OnInit {

  constructor(public articleService:ArticleService) { }

  ngOnInit(): void {
  }

}
