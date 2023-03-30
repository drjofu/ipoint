import { HashLocationStrategy, LocationStrategy } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CountryListComponent } from './country-list/country-list.component';
import { SignalrComponent } from './signalr/signalr.component';
import { WorldComponent } from './world/world.component';

const routes: Routes = [
  { path: 'world', component: WorldComponent },
  { path: 'countries/:continentId', component: CountryListComponent },
  { path: 'signalr', component: SignalrComponent },
  { path: '', pathMatch: 'full', redirectTo: 'world' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [{ provide: LocationStrategy, useClass: HashLocationStrategy }],
})
export class AppRoutingModule {}
