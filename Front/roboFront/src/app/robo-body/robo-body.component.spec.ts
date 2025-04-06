import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoboBodyComponent } from './robo-body.component';

describe('RoboBodyComponent', () => {
  let component: RoboBodyComponent;
  let fixture: ComponentFixture<RoboBodyComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [RoboBodyComponent]
    });
    fixture = TestBed.createComponent(RoboBodyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
