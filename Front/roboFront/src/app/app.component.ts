import { Component } from '@angular/core';
import { RoboHeadComponent } from './robo-head/robo-head.component';
import { RoboBodyComponent } from './robo-body/robo-body.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RoboHeadComponent,RoboBodyComponent],
  template: '<app-robo-head></app-robo-head>, <app-robo-body></app-robo-body>',
})
export class AppComponent {}
