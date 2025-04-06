import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoboControlService } from '../robo-control.service';

@Component({
  selector: 'app-robo-hand-right',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './robo-hand-right.component.html',
  styleUrls: ['./robo-hand-right.component.css'],
})

export class RoboHandRightComponent {
  contractionLevel: string = 'relaxed';
  rotationClass = 'deg-0';

  constructor(private controlService: RoboControlService) {
    this.controlService.armRight2$.subscribe(level => this.contractionLevel = level);
    this.controlService.handRightRotation$.subscribe(rotation => {
      this.rotationClass = rotation;
    });
  }
}
