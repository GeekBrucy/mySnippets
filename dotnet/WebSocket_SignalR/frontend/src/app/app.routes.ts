import { Routes } from '@angular/router';
import { WebsocketMyhubComponent } from './websocket-myhub/websocket-myhub.component';
import { WebsocketWithAuthComponent } from './websocket-with-auth/websocket-with-auth.component';

export const routes: Routes = [
  {path: "", component: WebsocketMyhubComponent },
  {path: "websocket-auth", component: WebsocketWithAuthComponent}
];
