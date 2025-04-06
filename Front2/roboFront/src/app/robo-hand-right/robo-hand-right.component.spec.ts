import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoboHandRightComponent } from './robo-hand-right.component';

describe('RoboHandRightComponent', () => {
  let component: RoboHandRightComponent;
  let fixture: ComponentFixture<RoboHandRightComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [RoboHandRightComponent]
    });
    fixture = TestBed.createComponent(RoboHandRightComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
