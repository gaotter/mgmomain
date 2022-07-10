import { Component, OnInit } from '@angular/core';
import {TestProxyService} from './test-proxy.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'mgmoangular';


  constructor(public testP:TestProxyService) {

  }
  ngOnInit(): void {

  }


}
