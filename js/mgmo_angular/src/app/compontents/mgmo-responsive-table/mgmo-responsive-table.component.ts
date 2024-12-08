import { Component, HostBinding, OnDestroy, OnInit,  ChangeDetectorRef  } from '@angular/core';
import { NgClass } from '@angular/common';
import { ViewportRuler } from '@angular/cdk/scrolling';
import { Subscription } from 'rxjs';

@Component({
  selector: 'mgmo-responsive-table',
  imports: [NgClass],
  templateUrl: './mgmo-responsive-table.component.html',
  styleUrl: './mgmo-responsive-table.component.css'
})
export class MgmoResponsiveTableComponent implements OnInit, OnDestroy {
  @HostBinding('style.--grid-repeat') gridNumber = 10;
  @HostBinding('style.--background-color') tableBackcolor = 'red';

  public fakeClass = false;
  public headres:string[] = [];

  private viewPortChanger: Subscription;
  constructor(private viewPortRuler: ViewportRuler, private cdr: ChangeDetectorRef) {

    this.viewPortChanger = this.viewPortRuler.change(200).subscribe(() => {
      this.onResize();
    });
  }
  ngOnInit(): void {
    this.onResize();

    const propertyNames = Object.keys(this.customers[0]);
    this.headres = propertyNames;
    console.log(propertyNames);
  }
  public customers = tableData;

  private onResize() {

    console.log(this.viewPortRuler.getViewportSize().width);
    if(this.viewPortRuler.getViewportSize().width < 1200) {
      this.gridNumber = 5;
      this.tableBackcolor = 'blue';
      this.cdr.markForCheck();
    } else {
      this.gridNumber = 10;
      this.tableBackcolor = 'red';
      this.cdr.markForCheck();
    }

  }

  ngOnDestroy(): void {
    this.viewPortChanger.unsubscribe();
  }

}







// test data for the table
export const tableData = [
  {
    "name": "Tiger Nixon",
    "position": "System Architect",
    "office": "Edinburgh",
    "age": "61",
    "startDate": "2011/04/25",
    "salary": "$320,800",
    "email": "tiger.nixon@datatables.net",
    "phone": "123-456-7890",
    "department": "Engineering",
    "status": "Active"
  },
  {
    "name": "Garrett Winters",
    "position": "Accountant",
    "office": "Tokyo",
    "age": "63",
    "startDate": "2011/07/25",
    "salary": "$170,750",
    "email": "garrett.winters@datatables.net",
    "phone": "098-765-4321",
    "department": "Finance",
    "status": "Active"
  },
  {
    "name": "Ashton Cox",
    "position": "Junior Technical Author",
    "office": "San Francisco",
    "age": "66",
    "startDate": "2009/01/12",
    "salary": "$86,000",
    "email": "ashton.cox@datatables.net",
    "phone": "456-789-0123",
    "department": "Documentation",
    "status": "Inactive"
  }
]
