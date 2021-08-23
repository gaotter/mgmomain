import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ArticleMainComponent } from '../../components/article-main/article-main.component';
import { ArticleInputComponent } from '../../components/article-input/article-input.component';
import { ArticleListComponent } from '../../components/article-list/article-list.component';

const routes: Routes = [
  {
    path:'',
    component:ArticleMainComponent,
    children:[
      {
        path:'new',
        component:ArticleInputComponent
      },
      {
        path:'list',
        component:ArticleListComponent
      },
      {
        path:'',
        redirectTo:'list',
        pathMatch:'full'
      }
    ]
  }

];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)],
    exports:[RouterModule]

})
export class RouteArticleModule { }
