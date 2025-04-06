import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoboControlService } from '../robo-control.service';

@Component({
  selector: 'app-robo-head',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './robo-head.component.html',
  styleUrls: ['./robo-head.component.css']
})
export class RoboHeadComponent {
  horizontalPosition: string = 'center';
  verticalPosition: string = 'neutral';

  constructor(private controlService: RoboControlService) {
    this.controlService.horizontal$.subscribe(pos => this.horizontalPosition = pos);
    this.controlService.vertical$.subscribe(pos => this.verticalPosition = pos);
  }

  setHorizontal(position: string) {
    this.horizontalPosition = position;
  }
  
  setVertical(position: string) {
    this.verticalPosition = position;
  }

  get transformStyle(): string {
    let rotate = 'rotate(0deg)';
    let tilt = 'rotateX(0deg)';

    switch (this.horizontalPosition) {
      case 'left-max': rotate = 'rotate(-90deg)'; break;
      case 'left-mid': rotate = 'rotate(-45deg)'; break;
      case 'right-mid': rotate = 'rotate(45deg)'; break;
      case 'right-max': rotate = 'rotate(90deg)'; break;
    }

    switch (this.verticalPosition) {
      case 'up': tilt = 'rotateX(-30deg)'; break;
      case 'down': tilt = 'rotateX(30deg)'; break;
    }

    return `${rotate} ${tilt}`;
  }
}
