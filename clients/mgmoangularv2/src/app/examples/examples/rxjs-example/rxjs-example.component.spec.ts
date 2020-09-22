import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RxjsExampleComponent } from './rxjs-example.component';

describe('RxjsExampleComponent', () => {
  let component: RxjsExampleComponent;
  let fixture: ComponentFixture<RxjsExampleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RxjsExampleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RxjsExampleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
