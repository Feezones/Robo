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

  // Braço esquerdo (parte inferior)
  private armLeft2Subject = new BehaviorSubject<string>('relaxed');
  armLeft2$ = this.armLeft2Subject.asObservable();

  // Braço direito (parte inferior)
  private armRight2Subject = new BehaviorSubject<string>('relaxed');
  armRight2$ = this.armRight2Subject.asObservable();

  // Rotação da mão esquerda
  private handLeftRotationSubject = new BehaviorSubject<string>('deg-0');
  handLeftRotation$ = this.handLeftRotationSubject.asObservable();

  // Rotação da mão direita
  private handRightRotationSubject = new BehaviorSubject<string>('deg-0');
  handRightRotation$ = this.handRightRotationSubject.asObservable();

  // Métodos da cabeça
  setHorizontal(pos: string) {
    this.horizontalSubject.next(pos);
  }

  setVertical(pos: string) {
    this.verticalSubject.next(pos);
  }

  // Contração dos braços
  setArmLeft2(level: string) {
    this.armLeft2Subject.next(level);
  }

  setArmRight2(level: string) {
    this.armRight2Subject.next(level);
  }

  // Rotação das mãos
  setHandLeftRotation(rotation: string) {
    this.handLeftRotationSubject.next(rotation);
  }

  setHandRightRotation(rotation: string) {
    this.handRightRotationSubject.next(rotation);
  }
}
