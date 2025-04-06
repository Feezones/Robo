import { Component } from '@angular/core';
import { RoboControlService } from '../robo-control.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-robo-controls',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './robo-controls.component.html',
  styleUrls: ['./robo-controls.component.css'],
})
export class RoboControlsComponent {
  constructor(private controlService: RoboControlService) {}

  setHorizontal(pos: string) {
    this.controlService.setHorizontal(pos);
  }

  setVertical(pos: string) {
    this.controlService.setVertical(pos);
  }
}
