import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoboControlService } from '../robo-control.service';

@Component({
  selector: 'app-robo-arm-right',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './robo-arm-right.component.html',
  styleUrls: ['./robo-arm-right.component.css'],
})
export class RoboArmRightComponent {
  contractionLevel: string = 'relaxed';

  constructor(private controlService: RoboControlService) {
    this.controlService.armRight2$.subscribe(level => {
      this.contractionLevel = level;
    });
  }
}
