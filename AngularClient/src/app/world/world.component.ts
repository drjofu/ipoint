import { Component, OnInit } from '@angular/core';
import { Continent, Country } from '../models';
import { WorldService } from '../world.service';

@Component({
  selector: 'app-world',
  templateUrl: './world.component.html',
  styleUrls: ['./world.component.css'],
})
export class WorldComponent implements OnInit {
  constructor(private worldService: WorldService) {}

  continents: Continent[] = [];
  countries: Country[] = [];

  async ngOnInit() {
    // this.httpClient
    //   .get('http://localhost:22000/world')
    //   .subscribe((r) => (this.continents = r));

    this.continents = await this.worldService.getContinents();
  }

  async showCountries(continentId:string){
    this.countries = await this.worldService.getCountriesOnContinent(continentId);
  }
}
