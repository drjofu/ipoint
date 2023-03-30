import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { Continent, Country } from './models';

@Injectable({
  providedIn: 'root'
})
export class WorldService {

  baseUrl='http://localhost:5255/';
  constructor(private httpClient:HttpClient) { }

  getContinents(){
    return lastValueFrom(this.httpClient.get<Continent[]>(this.baseUrl + 'world'));
  }

  getCountriesOnContinent(continentId:string){
    return lastValueFrom(this.httpClient.get<Country[]>(this.baseUrl + 'world/countries?continentid=' + continentId));
  }
}
