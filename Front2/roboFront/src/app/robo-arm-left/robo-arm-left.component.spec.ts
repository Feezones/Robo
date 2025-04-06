import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoboArmLeftComponent } from './robo-arm-left.component';

describe('RoboArmLeftComponent', () => {
  let component: RoboArmLeftComponent;
  let fixture: ComponentFixture<RoboArmLeftComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [RoboArmLeftComponent]
    });
    fixture = TestBed.createComponent(RoboArmLeftComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
