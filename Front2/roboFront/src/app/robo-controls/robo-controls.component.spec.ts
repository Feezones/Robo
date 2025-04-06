import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoboControlsComponent } from './robo-controls.component';

describe('RoboControlsComponent', () => {
  let component: RoboControlsComponent;
  let fixture: ComponentFixture<RoboControlsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [RoboControlsComponent]
    });
    fixture = TestBed.createComponent(RoboControlsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
