import { TestBed } from '@angular/core/testing';

import { CollegeMgmtService } from './college-mgmt.service';

describe('CollegeMgmtService', () => {
  let service: CollegeMgmtService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CollegeMgmtService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
