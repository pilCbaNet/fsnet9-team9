import { TestBed } from '@angular/core/testing';

import { DepositoService } from './deposito.service';

describe('DepositoService', () => {
  let service: DepositoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DepositoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
