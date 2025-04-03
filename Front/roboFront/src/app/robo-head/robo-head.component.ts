import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-robo-head',
  standalone: true,
  templateUrl: './robo-head.component.html',
  styleUrls: ['./robo-head.component.css'],
  imports: [CommonModule],
})
export class RoboHeadComponent {
  horizontalPosition: string = 'center';
  verticalPosition: string = 'neutral';

  constructor(private http: HttpClient) {} // Injeção pelo construtor

  setHorizontalPosition(newPosition: string) {
    this.horizontalPosition = newPosition;
    this.sendPositionToBackend();
  }

  setVerticalPosition(newPosition: string) {
    this.verticalPosition = newPosition;
    this.sendPositionToBackend();
  }

  private sendPositionToBackend() {
    const data = {
      isLeftMax: this.horizontalPosition === 'left-max',
      isLeftMid: this.horizontalPosition === 'left-mid',
      isCenter: this.horizontalPosition === 'center',
      isRightMid: this.horizontalPosition === 'right-mid',
      isRightMax: this.horizontalPosition === 'right-max',
      isUp: this.verticalPosition === 'up',
      isNeutral: this.verticalPosition === 'neutral',
      isDown: this.verticalPosition === 'down',
    };
    console.log('Dados a serem enviados:', data); // Log dos dados a serem enviados

    this.http.post('https://seu-endpoint.com/posicao-robo', data).subscribe({
      next: response => console.log('Posição enviada:', response),
      error: error => console.error('Erro ao enviar posição:', error),
    });
  }
}
