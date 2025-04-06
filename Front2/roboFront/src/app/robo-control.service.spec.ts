import { TestBed } from '@angular/core/testing';

import { RoboControlService } from './robo-control.service';

describe('RoboControlService', () => {
  let service: RoboControlService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RoboControlService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
