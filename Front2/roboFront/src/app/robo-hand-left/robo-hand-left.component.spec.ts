import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoboHandLeftComponent } from './robo-hand-left.component';

describe('RoboHandLeftComponent', () => {
  let component: RoboHandLeftComponent;
  let fixture: ComponentFixture<RoboHandLeftComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [RoboHandLeftComponent]
    });
    fixture = TestBed.createComponent(RoboHandLeftComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
