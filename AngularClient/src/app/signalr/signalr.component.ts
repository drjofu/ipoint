import { Component, OnDestroy, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';

@Component({
  selector: 'app-signalr',
  templateUrl: './signalr.component.html',
  styleUrls: ['./signalr.component.css'],
})
export class SignalrComponent implements OnInit, OnDestroy {
  user: string = 'ich';
  message: string = 'Hallo';
  messages: string[] = [];
  hubconnection?: HubConnection;

  constructor() {}
  ngOnDestroy(): void {
    this.hubconnection?.stop();
  }

  ngOnInit() {
    this.hubconnection = new HubConnectionBuilder()
      .withUrl('http://localhost:5108/chat')
      .build();

    this.hubconnection.on('showMessage', (user,message)=>
        this.messages.push(`${user}: ${message}`)
    );
    this.hubconnection.start();
  }

  postMessage() {
    this.hubconnection?.send('postMessage', this.user, this.message);
  }
}
