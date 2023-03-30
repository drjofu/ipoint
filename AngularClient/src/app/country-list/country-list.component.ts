import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Country } from '../models';
import { WorldService } from '../world.service';

@Component({
  selector: 'app-country-list',
  templateUrl: './country-list.component.html',
  styleUrls: ['./country-list.component.css'],
})
export class CountryListComponent implements OnInit {
  countries: Country[] = [];
  constructor(
    private activatedRoute: ActivatedRoute,
    private worldService: WorldService
  ) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(async(p: any) =>
      this.countries = await this.worldService.getCountriesOnContinent( p.continentId)
    );
  }
}
