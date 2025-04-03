import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoboHeadComponent } from './robo-head.component';

describe('RoboHeadComponent', () => {
  let component: RoboHeadComponent;
  let fixture: ComponentFixture<RoboHeadComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [RoboHeadComponent]
    });
    fixture = TestBed.createComponent(RoboHeadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
