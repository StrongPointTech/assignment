import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HistoryComponent } from './history/history.component';
import { KineticEnergyCalculatorComponent } from './kinetic-energy-calculator/kinetic-energy-calculator.component';

const routes: Routes = [
  {
    path: '',
    component: KineticEnergyCalculatorComponent
  },
  {
    path: 'kineticEnergyCalculator',
    component: KineticEnergyCalculatorComponent
  },
  {
    path: 'history',
    component: HistoryComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
