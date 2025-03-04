import { ConnectedSocket, MessageBody, SubscribeMessage, WebSocketGateway, WebSocketServer } from '@nestjs/websockets';
import { Server, Socket } from 'socket.io';

@WebSocketGateway({cors: true})
export class WebsocketGateway {
  @WebSocketServer()
  server: Server;

  handleConnection(@ConnectedSocket() client: Socket) {
    console.log(`Client connected: ${client.id}`);
    this.server.emit('message', `New client connected: ${client.id}`);
  }

  handleDisconnect(@ConnectedSocket() client: Socket) {
    console.log(`Client disconnected: ${client.id}`);
    this.server.emit('message', `Client disconnected: ${client.id}`);
  }

  @SubscribeMessage('message')
  handleMessage(@MessageBody() data: string, @ConnectedSocket() client: Socket): void {
    console.log(`Received message from ${client.id}: `, data);
    this.server.emit('message', `Client ${client.id} says: ${data}`);
  }
}
