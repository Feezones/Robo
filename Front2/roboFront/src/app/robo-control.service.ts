import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class RoboControlService {

  constructor(private http: HttpClient) {}

  private horizontalSubject = new BehaviorSubject<string>('center');
  private verticalSubject = new BehaviorSubject<string>('neutral');
  horizontal$ = this.horizontalSubject.asObservable(); // remover todas as linhas com ...asobservable(), valor inutilizado
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
    const allowedRotations = [
      'left-max',
      'left-mid',
      'center',
      'right-mid',
      'right-max'
    ];
  
    const keys = [
      'R90_',
      'R45_',
      'R0',
      'R45',
      'R90'
      
    ];
  
    const currentRotation = this.horizontalSubject.getValue();
  
    // Proibe rotação livre se a vertical não for "down"
    if (this.verticalSubject.getValue() === 'down') {
      return;
    }
  
    const currentIndex = allowedRotations.indexOf(currentRotation);
    const nextIndex = allowedRotations.indexOf(pos);
  
    // Valida: só pode mudar para o item ao lado (1 passo)
    const isSequential = Math.abs(currentIndex - nextIndex) === 1;
  
    if (isSequential) {  
      const payload: any = {};
      keys.forEach((key, i) => {
        payload[key] = i === nextIndex;
      });
  
      this.http.put('http://localhost:5228/api/Head/HeadRotation', payload).subscribe({
        next: () => {
          console.log('Payload enviado (HeadRotation):', payload);
          this.horizontalSubject.next(pos);
        },
        error: (err) => console.error('Erro no envio (HeadRotation):', err)
      });

      
    } else {
      return;
    }
  }
  
  

  setVertical(pos: string) {
    const allowedTilts = ['up', 'neutral', 'down'];
    const keys = ['LUp', 'LRest', 'LDown'];
    const current = this.verticalSubject.getValue();
  
    const currentIndex = allowedTilts.indexOf(current);
    const nextIndex = allowedTilts.indexOf(pos);
  
    // Só permite transições entre neutral <-> up ou neutral <-> down
    const isAllowed =
      (current === 'neutral' && (pos === 'down' || pos === 'up')) ||
      (pos === 'neutral' && (current === 'down' || current === 'up'));
  
    if (!isAllowed) return;

  
    const payload: any = {};
    keys.forEach((key, i) => {
      payload[key] = i === nextIndex;
    });
  
    this.http.put('http://localhost:5228/api/Head/HeadTilt', payload).subscribe({
      next: () => {
        console.log('Payload enviado (HeadTilt):', payload);
        this.verticalSubject.next(pos);
      },
      error: (err) => console.error('Erro no envio (HeadTilt):', err)
    });
  }
  
  

  // Contração dos braços
  setArmLeft2(level: string) {
    const allowedStates = ['relaxed', 'slight', 'medium', 'strong'];
    const current = this.armLeft2Subject.getValue();
  
    if (this.isSequentialChangeArm(current, level, allowedStates)) {
  
      const index = allowedStates.indexOf(level);
      const payload = {
        LARest: index === 0,
        LAContracted1: index === 1,
        LAContracted2: index === 2,
        LAContracted3: index === 3,
      };
  
      this.http.put('http://localhost:5228/api/Arm/LeftArm', payload).subscribe({
        next: () => {console.log('LeftArm enviado:', payload);
        this.armLeft2Subject.next(level)},
        error: (err) => console.error('Erro ao enviar LeftArm:', err),
      });
    } else {
      return;
    }
  }
  
  
  

  setArmRight2(level: string) {
    const allowedStates = ['relaxed', 'slight', 'medium', 'strong'];
    const current = this.armRight2Subject.getValue();

  if (this.isSequentialChangeArm(current, level, allowedStates)) {

    const index = allowedStates.indexOf(level);
    const payload = {
      RARest: index === 0,
      RAContracted1: index === 1,
      RAContracted2: index === 2,
      RAContracted3: index === 3,
    };

    this.http.put('http://localhost:5228/api/Arm/RightArm', payload).subscribe({
      next: () => {console.log('RightArm enviado:', payload)
        this.armRight2Subject.next(level);
      },
      error: (err) => console.error('Erro ao enviar RightArm:', err),
    });
  } else {
    return;
  }
  }

  // Rotação das mãos
  setHandLeftRotation(rotation: string) {
    const allowedRotations = [
      'deg--90',  // RP90
      'deg--45',  // RP45
      'deg-0',    // RP0
      'deg-45',   // RP45_
      'deg-90',   // RP90_
      'deg-135',  // RP135
      'deg-180'   // RP180
    ];
  
    const keys = [
      'RP45_',
      'RP90_',
      'RP0',
      'RP90',
      'RP45',
      'RP135',
      'RP180'
    ];
  
    const current = this.handLeftRotationSubject.getValue();
  
    if (this.armLeft2Subject.getValue() !== 'strong') return;
  
    if (this.isSequentialChangeHand(current, rotation, allowedRotations)) {
  
      const index = allowedRotations.indexOf(rotation);
      const payload: any = {};
  
      keys.forEach((key, i) => {
        payload[key] = i === index;
      });
  
      this.http.put('http://localhost:5228/api/Hand/LeftPulse', payload).subscribe({
        next: () => {
          console.log('Payload enviado (LeftPulse):', payload);
          this.handLeftRotationSubject.next(rotation);
        },
        error: (err) => console.error('Erro no envio (LeftPulse):', err)
      });
    }
  }
  
  setHandRightRotation(rotation: string) {
    const allowedRotations = [
      'deg--90',  // RP90
      'deg--45',  // RP45
      'deg-0',    // RP0
      'deg-45',   // RP45_
      'deg-90',   // RP90_
      'deg-135',  // RP135
      'deg-180'   // RP180
    ];
  
    const keys = [
      'RP45_',
      'RP90_',
      'RP0',
      'RP90',
      'RP45',
      'RP135',
      'RP180'
    ];
  
    const current = this.handRightRotationSubject.getValue();
  
    if (this.armRight2Subject.getValue() !== 'strong') return;
  
    if (this.isSequentialChangeHand(current, rotation, allowedRotations)) {

  
      const index = allowedRotations.indexOf(rotation);
      const payload: any = {};
  
      keys.forEach((key, i) => {
        payload[key] = i === index;
      });
  
      this.http.put('http://localhost:5228/api/Hand/RightPulse', payload).subscribe({
        next: () => {
          console.log('Payload enviado:', payload);
          this.handRightRotationSubject.next(rotation);
        },
        error: (err) => console.error('Erro no envio:', err)
      });
    }
  }

  private isSequentialChangeHand(current: string, next: string, allowedList: string[]): boolean {
    const currentIndex = allowedList.indexOf(current);
    const nextIndex = allowedList.indexOf(next);
  
    if (currentIndex === -1 || nextIndex === -1) return false;
  
    return Math.abs(currentIndex - nextIndex) === 1;
  }

  private isSequentialChangeArm(current: string, next: string, allowedStates: string[]): boolean {
    const currentIndex = allowedStates.indexOf(current);
    const nextIndex = allowedStates.indexOf(next);
  
    return Math.abs(currentIndex - nextIndex) === 1;
  }
  

  
}
