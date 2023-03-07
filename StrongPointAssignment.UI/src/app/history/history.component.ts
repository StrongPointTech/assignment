import { Component } from '@angular/core';
import { TargetObject } from '../models/targetObject.model';
import { KineticEnergyCalculatorService } from '../services/kinetic-energy-calculator.service';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent {
  objectList: TargetObject[] = []

  constructor(private kineticEnergyCalculatorService: KineticEnergyCalculatorService) { }

  ngOnInit(): void {
    this.kineticEnergyCalculatorService.getHistory().subscribe({
      next: (response) => {
        this.objectList = response;
      },
      error: (response) => {
        console.error(response);
      }
    });
  }
}
