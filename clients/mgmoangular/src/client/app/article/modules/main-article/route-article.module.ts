import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ArticleMainComponent } from '../../components/article-main/article-main.component';
import { ArticleInputComponent } from '../../components/article-input/article-input.component';

const routes: Routes = [
  {
    path:'',
    component:ArticleMainComponent,
    children:[
      {
        path:'new',
        component:ArticleInputComponent
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
