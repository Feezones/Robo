import { Component } from '@angular/core';
import { RoboHeadComponent } from './robo-head/robo-head.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RoboHeadComponent],
  template: '<app-robo-head></app-robo-head>',
})
export class AppComponent {}
