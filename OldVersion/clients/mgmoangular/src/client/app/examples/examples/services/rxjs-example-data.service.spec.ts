import { TestBed } from '@angular/core/testing';

import { RxjsExampleDataService } from './rxjs-example-data.service';

describe('RxjsExampleDataService', () => {
  let service: RxjsExampleDataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RxjsExampleDataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
