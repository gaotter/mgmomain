import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CombineDataComponent } from './combine-data.component';

describe('CombineDataComponent', () => {
  let component: CombineDataComponent;
  let fixture: ComponentFixture<CombineDataComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CombineDataComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CombineDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
