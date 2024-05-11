import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from '../login/login.component';
import * as signalR from '@microsoft/signalr';
import keycode from 'keycode';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-websocket-with-auth',
  standalone: true,
  imports: [LoginComponent, FormsModule, CommonModule],
  templateUrl: './websocket-with-auth.component.html',
  styleUrl: './websocket-with-auth.component.scss'
})
export class WebsocketWithAuthComponent {
  baseUrl = "http://localhost:5225";
  token: string = "";
  msg: string = "";
  messages: string[] = [];
  connectionTransport: signalR.HttpTransportType = signalR.HttpTransportType.WebSockets;
  connectionOptions: signalR.IHttpConnectionOptions = {
    skipNegotiation: true,
    transport: this.connectionTransport
  }
  connection: signalR.HubConnection | null = null;
  async setToken(token: string) {
    if (!token) {
      return;
    }
    this.token = token;

    this.connectionOptions.accessTokenFactory = () => this.token;

    this.connection = new signalR.HubConnectionBuilder()
    .withUrl(`${this.baseUrl}/myHub`, this.connectionOptions)
    .withAutomaticReconnect()
    .build();

    await this.connection.start();
    this.connection.on('PublicMsgReceived', msg => {
      this.messages.push(msg);
    })
  }

  async onKeyUp(event: KeyboardEvent) {
    if (!this.connection) {
      return;
    }
    if (keycode.isEventKey(event, 'enter') === false) {
      return;
    }
    await this.connection.invoke("SendPublicMsg", this.msg); // the function name in the MyHub class
    this.msg = "";
  }
}
