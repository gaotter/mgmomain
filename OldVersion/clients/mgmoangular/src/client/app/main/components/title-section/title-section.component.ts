import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-title-section',
  templateUrl: './title-section.component.html',
  styleUrls: ['./title-section.component.scss']
})
export class TitleSectionComponent implements OnInit {

  title$ = new BehaviorSubject<string>("Welcome to mgmo's main page");
  content$ = new BehaviorSubject<string>("This is a play and a page i use to post som aticles and services that I create.  My online hub of things I test out. So I can go back and look at it.")

  constructor() { }

  ngOnInit(): void {
  }

}
