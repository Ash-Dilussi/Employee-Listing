import { TestBed } from '@angular/core/testing';

import { EmpUpdateService } from './emp-update.service';

describe('EmpUpdateService', () => {
  let service: EmpUpdateService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EmpUpdateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
