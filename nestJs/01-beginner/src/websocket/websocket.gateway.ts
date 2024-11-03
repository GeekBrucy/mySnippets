import {
  ConnectedSocket,
  MessageBody,
  SubscribeMessage,
  WebSocketGateway,
  WebSocketServer,
} from '@nestjs/websockets';
import { Server, Socket } from 'socket.io';

@WebSocketGateway({
  cors: {
    origin: 'http://127.0.0.1:5500',
    methods: ['GET', 'POST'],
    credentials: true,
  },
})
export class WebsocketGateway {
  @WebSocketServer()
  server: Server;

  @SubscribeMessage('message')
  handleMessage(
    @MessageBody() message: string,
    @ConnectedSocket() client: Socket,
  ): string {
    console.log(`ConnectedSocket: ${client}`);
    console.log(`Received message: ${message}`);
    // You can broadcast or respond to the specific client
    this.server.emit('message', `Hello, client! Your message was: ${message}`);
    return `Message received: ${message}`;
  }

  @SubscribeMessage('joinRoom')
  handleJoinRoom(
    @MessageBody() room: string,
    @ConnectedSocket() client: Socket,
  ): void {
    client.join(room);
    client.emit('joinedRoom', `You have joined room: ${room}`);
    client.emit('showRoom', `Rooms: ${client}`);
  }

  @SubscribeMessage('sendToRoom')
  handleSendToRoom(
    @MessageBody() data: { room: string; message: string },
    @ConnectedSocket() client: Socket,
  ): void {
    console.log(`ConnectedSocket: ${client}`);
    this.server.to(data.room).emit('message', data.message);
  }
}
