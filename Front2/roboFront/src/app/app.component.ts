import { Component } from '@angular/core';
import { RoboHeadComponent } from './robo-head/robo-head.component';
import { RoboBodyComponent } from './robo-body/robo-body.component';
import { RoboArmLeftComponent } from './robo-arm-left/robo-arm-left.component';
import { RoboArmRightComponent } from './robo-arm-right/robo-arm-right.component';
import { RoboHandLeftComponent } from './robo-hand-left/robo-hand-left.component';
import { RoboHandRightComponent } from './robo-hand-right/robo-hand-right.component';
import { RoboControlsComponent } from './robo-controls/robo-controls.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RoboHeadComponent,
    RoboBodyComponent,
    RoboArmLeftComponent,
    RoboArmRightComponent,
    RoboHandLeftComponent,
    RoboHandRightComponent,
    RoboControlsComponent
  ],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {}
