import { TestBed } from '@angular/core/testing';

import { EmpAddService } from './emp-add.service';

describe('EmpAddService', () => {
  let service: EmpAddService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EmpAddService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
