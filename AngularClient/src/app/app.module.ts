import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { WorldComponent } from './world/world.component';
import { HttpClientModule } from '@angular/common/http';
import { CountryListComponent } from './country-list/country-list.component';
import { SignalrComponent } from './signalr/signalr.component';

@NgModule({
  declarations: [AppComponent, WorldComponent, CountryListComponent, SignalrComponent],
  imports: [BrowserModule, AppRoutingModule, FormsModule, HttpClientModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
