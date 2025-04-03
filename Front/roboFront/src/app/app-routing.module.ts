import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RoboHeadComponent } from './robo-head/robo-head.component';

const routes: Routes = [
  { path: 'robo-head', component: RoboHeadComponent } // Usando o componente standalone na rota
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }