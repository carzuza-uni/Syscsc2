import { TestBed } from '@angular/core/testing';

import { UsoSueloService } from './uso-suelo.service';

describe('UsoSueloService', () => {
  let service: UsoSueloService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UsoSueloService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
