import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { TargetObject } from '../models/targetObject.model';

@Injectable({
  providedIn: 'root'
})
export class KineticEnergyCalculatorService {

  constructor(private http: HttpClient) { }

  getHistory(): Observable<TargetObject[]> {
    return this.http.get<TargetObject[]>(environment.baseApiUrl + "KineticEnergy");
  }

  getEnergy(targetObject: TargetObject): Observable<TargetObject> {
    return this.http.post<TargetObject>(environment.baseApiUrl + "KineticEnergy", targetObject);
  }
}
