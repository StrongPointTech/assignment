import { Component } from '@angular/core';
import { TargetObject } from '../models/targetObject.model';
import { KineticEnergyCalculatorService } from '../services/kinetic-energy-calculator.service';
import messages from './whatWouldHappen.json';

@Component({
  selector: 'app-kinetic-energy-calculator',
  templateUrl: './kinetic-energy-calculator.component.html',
  styleUrls: ['./kinetic-energy-calculator.component.css']
})
export class KineticEnergyCalculatorComponent {
  targetObject: TargetObject = {
    id: '',
    mass: 0,
    velocity: 0,
    energy: 0
  };

  messageList: {energy: number, message: string}[] = messages;
  selectedMessage: string = '';

  constructor(private kineticEnergyCalculatorService: KineticEnergyCalculatorService) { }

  ngOnInit(): void {
  }

  calculateEnergy() {
    this.kineticEnergyCalculatorService.getEnergy(this.targetObject).subscribe({
      next: (targetObject) => {
        this.targetObject = targetObject;
        this.selectedMessage = this.assignMessage();
      },
      error: (response) => {
        console.error(response);
      }
    });
  }

  assignMessage(): string {
    if (this.targetObject.energy < 0) {
      return "Objects can not have negative mass, so nothing really"
    }

    for (let i = 0; i < this.messageList.length - 1; i++) {
      if (this.targetObject.energy >= this.messageList[i].energy && this.targetObject.energy < this.messageList[i + 1].energy) {
        return this.messageList[i].message;
      }
    }

    return this.messageList[this.messageList.length - 1].message
  }
}
