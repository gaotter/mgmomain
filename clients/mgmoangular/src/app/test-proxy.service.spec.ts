import { TestBed } from '@angular/core/testing';

import { TestProxyService } from './test-proxy.service';

describe('TestProxyService', () => {
  let service: TestProxyService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TestProxyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
