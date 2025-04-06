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
    const allowedRotations = ['left-max', 'left-mid', 'center', 'right-mid', 'right-max'];
    const currentRotation = this.horizontalSubject.getValue();
  
    // proibe rotação livre se a vertical não for "down"
    if (this.verticalSubject.getValue() === 'down') {
      return;
    }
  
    const currentIndex = allowedRotations.indexOf(currentRotation);
    const nextIndex = allowedRotations.indexOf(pos);

    // Valida: só pode mudar para o item ao lado (1 passo)
    const isSequential = Math.abs(currentIndex - nextIndex) === 1;
  
    if (isSequential) {
      this.horizontalSubject.next(pos);
    } else {
      return; // Não faz nada se não for um movimento sequencial
    }
  }
  

  setVertical(pos: string) {
    const positionHead = this.verticalSubject.getValue();
    if((positionHead === 'neutral' && (pos === 'down' || pos === 'up')) 
      || pos === 'neutral' && (positionHead === 'down' || positionHead === 'up')){
      this.verticalSubject.next(pos);
      return;
    }
    return;
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
    const allowedRotations = ['deg--90', 'deg--45', 'deg-0', 'deg-45', 'deg-90', 'deg-135', 'deg-180'];
    const current = this.handLeftRotationSubject.getValue();
  
    if (this.armLeft2Subject.getValue() !== 'strong') return;
  
    if (this.isSequentialChange(current, rotation, allowedRotations)) {
      this.handLeftRotationSubject.next(rotation);
    } else {
      return; // Não faz nada se não for um movimento sequencial
    }
  }
  
  

  setHandRightRotation(rotation: string) {
    const allowedRotations = ['deg--90', 'deg--45', 'deg-0', 'deg-45', 'deg-90', 'deg-135', 'deg-180'];
    const current = this.handRightRotationSubject.getValue();
  
    if (this.armRight2Subject.getValue() !== 'strong') return;
  
    if (this.isSequentialChange(current, rotation, allowedRotations)) {
      this.handRightRotationSubject.next(rotation);
    } else {
      return; // Não faz nada se não for um movimento sequencial
    }
  }
  

  private isSequentialChange(current: string, next: string, allowedList: string[]): boolean {
    const currentIndex = allowedList.indexOf(current);
    const nextIndex = allowedList.indexOf(next);
  
    if (currentIndex === -1 || nextIndex === -1) return false;
  
    return Math.abs(currentIndex - nextIndex) === 1;
  }
  
}
