import { TestBed } from '@angular/core/testing';

import { KineticEnergyCalculatorService } from './kinetic-energy-calculator.service';

describe('KineticEnergyCalculatorService', () => {
  let service: KineticEnergyCalculatorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(KineticEnergyCalculatorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
