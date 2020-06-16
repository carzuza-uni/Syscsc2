import { TestBed } from '@angular/core/testing';

import { ManejoCultivoService } from './manejo-cultivo.service';

describe('ManejoCultivoService', () => {
  let service: ManejoCultivoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ManejoCultivoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
