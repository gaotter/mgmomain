import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MgmoResponsiveTableComponent } from './mgmo-responsive-table.component';

describe('MgmoResponsiveTableComponent', () => {
  let component: MgmoResponsiveTableComponent;
  let fixture: ComponentFixture<MgmoResponsiveTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MgmoResponsiveTableComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MgmoResponsiveTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
