import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {ApplicationComponent} from "./pages/application/application.component";
import {WorshopsComponent} from "./pages/worshops/worshops.component";
import {ParticipantsComponent} from "./pages/participants/participants.component";

const routes: Routes = [
  {
    path: '',
    redirectTo: 'applications',
    pathMatch: 'full'
  },
  {
    path: 'applications',
    component: ApplicationComponent
  },
  {
    path: 'workshops',
    component: WorshopsComponent
  },
  {
    path: 'participants',
    component: ParticipantsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
