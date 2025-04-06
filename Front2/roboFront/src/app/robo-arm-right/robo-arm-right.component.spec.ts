import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoboArmRightComponent } from './robo-arm-right.component';

describe('RoboArmRightComponent', () => {
  let component: RoboArmRightComponent;
  let fixture: ComponentFixture<RoboArmRightComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [RoboArmRightComponent]
    });
    fixture = TestBed.createComponent(RoboArmRightComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
