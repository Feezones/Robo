import { Component } from '@angular/core';
import { CommonModule } from '@angular/common'; // Importando CommonModule

@Component({
  selector: 'app-robo-head',
  standalone: true,
  templateUrl: './robo-head.component.html',
  styleUrls: ['./robo-head.component.css'],
  imports: [CommonModule] // Adicionando CommonModule para habilitar o ngClass
})
export class RoboHeadComponent {
  horizontalPosition: string = 'center';
  verticalPosition: string = 'neutral';

  setHorizontalPosition(newPosition: string) {
    this.horizontalPosition = newPosition;
  }

  setVerticalPosition(newPosition: string) {
    this.verticalPosition = newPosition;
  }
}
