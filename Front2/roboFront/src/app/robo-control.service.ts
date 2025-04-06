import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class RoboControlService {
  private horizontalSubject = new BehaviorSubject<string>('center');
  private verticalSubject = new BehaviorSubject<string>('neutral');

  horizontal$ = this.horizontalSubject.asObservable();
  vertical$ = this.verticalSubject.asObservable();

  setHorizontal(position: string) {
    this.horizontalSubject.next(position);
  }

  setVertical(position: string) {
    this.verticalSubject.next(position);
  }
}
