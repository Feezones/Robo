import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoboControlService } from '../robo-control.service';

@Component({
  selector: 'app-robo-arm-left',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './robo-arm-left.component.html',
  styleUrls: ['./robo-arm-left.component.css'],
})
export class RoboArmLeftComponent {
  contractionState: string = 'relaxed';

  constructor(private controlService: RoboControlService) {
    this.controlService.armLeft2$.subscribe(state => this.contractionState = state);
  }
}
