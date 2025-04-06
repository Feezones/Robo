import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoboControlService } from '../robo-control.service';

@Component({
  selector: 'app-robo-hand-left',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './robo-hand-left.component.html',
  styleUrls: ['./robo-hand-left.component.css'],
})

export class RoboHandLeftComponent {
  contractionLevel: string = 'relaxed';
  rotationClass = 'hand-0';

  constructor(private controlService: RoboControlService) {
    this.controlService.armLeft2$.subscribe(level => this.contractionLevel = level);
    this.controlService.handLeftRotation$.subscribe(rotation => {
      this.rotationClass = rotation;
    });
  }
}
