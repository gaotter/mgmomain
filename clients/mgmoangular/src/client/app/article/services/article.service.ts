import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { tap } from 'rxjs/operators';
import { ConnectionsService } from '../../services/connections.service';
import { ServicesModule as ServicesModule } from '../modules/main-article/services-article.module';
import { IArticle } from '../models/article.model';

@Injectable({
  providedIn: ServicesModule
})
export class ArticleService {

  public $data:Observable<IArticle[]>;
  constructor(private connectionsService:ConnectionsService) {
    this.$data = connectionsService.get<{}, IArticle[]>("/articles", {});
  }
}
