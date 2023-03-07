import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KineticEnergyCalculatorComponent } from './kinetic-energy-calculator.component';

describe('KineticEnergyCalculatorComponent', () => {
  let component: KineticEnergyCalculatorComponent;
  let fixture: ComponentFixture<KineticEnergyCalculatorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KineticEnergyCalculatorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(KineticEnergyCalculatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
