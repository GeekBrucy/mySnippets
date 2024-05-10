import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import keycode from 'keycode';
import * as signalR from '@microsoft/signalr';

@Component({
  selector: 'app-websocket-myhub',
  standalone: true,
  imports: [FormsModule, ],
  templateUrl: './websocket-myhub.component.html',
  styleUrl: './websocket-myhub.component.scss'
})
export class WebsocketMyhubComponent implements OnInit {
  msg: string = "";
  messages: string[] = [];
  // skipNegotiation and open websocket to the server directly
  // this is to avoid issues in distributed servers
  connectionOptions = {skipNegotiation: true, transport: signalR.HttpTransportType.WebSockets}
  connection: signalR.HubConnection = new signalR.HubConnectionBuilder()
    .withUrl('http://localhost:5071/myHub', this.connectionOptions)
    .withAutomaticReconnect()
    .build();

  async ngOnInit(): Promise<void> {
    await this.connection.start();
    this.connection.on(
      "PublicMsgReceived", // the string in SendAsync in MyHub class
      msg => {
      this.messages.push(msg)
    });
  }

  async onKeyUp(event: KeyboardEvent) {
    if (keycode.isEventKey(event, 'enter') === false) {
      return;
    }
    await this.connection.invoke("SendPublicMsg", this.msg); // the function name in the MyHub class
    this.msg = "";
  }
}
