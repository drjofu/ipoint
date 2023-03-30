import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'AngularClient';
  private _zahl: number = 123;
  public get zahl(): number {
    return this._zahl;
  }
  public set zahl(value: number) {
    this._zahl = value;
  }
  farbe='red';

  buttonclass='';

  buttonClicked(e: any) {
    console.log('button clicked...');
    this.title = 'was anderes...';
    this.farbe='green';
    this.buttonclass='btn-spezial';
  }
}
