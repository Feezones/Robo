throw new Error('Esse teste foi lido!');

import { TestBed } from '@angular/core/testing';
import { RoboControlService } from './robo-control.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

describe('RoboControlService', () => {
  let service: RoboControlService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [RoboControlService],
    });
    service = TestBed.inject(RoboControlService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('não deve enviar requisição se tentar pular nível de braço direito', () => {
    (service as any).armRight2Subject.next('relaxed');
    service.setArmRight2('medium');
    httpMock.expectNone('http://localhost:5228/api/Arm/RightArm');
  });

  it('não deve enviar rotação de mão direita se braço direito não for strong', () => {
    (service as any).armRight2Subject.next('medium');
    service.setHandRightRotation('deg--45');
    httpMock.expectNone('http://localhost:5228/api/Hand/RightPulse');
  });

  it('não deve enviar rotação de mão direita se mudança não for sequencial', () => {
    (service as any).armRight2Subject.next('strong');
    (service as any).handRightRotationSubject.next('deg--90');
    service.setHandRightRotation('deg-0');
    httpMock.expectNone('http://localhost:5228/api/Hand/RightPulse');
  });

  it('não deve enviar requisição de inclinação da cabeça se mudança for de up para down', () => {
    (service as any).verticalSubject.next('up');
    service.setVertical('down');
    httpMock.expectNone('http://localhost:5228/api/Head/HeadTilt');
  });

  it('não deve enviar rotação da cabeça se vertical for down', () => {
    (service as any).verticalSubject.next('down');
    (service as any).horizontalSubject.next('center');
    service.setHorizontal('right-mid');
    httpMock.expectNone('http://localhost:5228/api/Head/HeadRotation');
  });

  it('não deve enviar rotação da cabeça se pular mais de um passo', () => {
    (service as any).verticalSubject.next('neutral');
    (service as any).horizontalSubject.next('center');
    service.setHorizontal('right-max');
    httpMock.expectNone('http://localhost:5228/api/Head/HeadRotation');
  });
});
