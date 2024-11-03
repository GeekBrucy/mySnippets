import { NestFactory } from '@nestjs/core';
import { AppModule } from './app.module';
// import { IoAdapter } from '@nestjs/platform-socket.io';

async function bootstrap() {
  const app = await NestFactory.create(AppModule);
  app.enableCors({
    origin: 'http://127.0.0.1:5500',
    methods: ['GET', 'POST'],
  });
  // app.useWebSocketAdapter(new IoAdapter(app));
  await app.listen(3000);
}
bootstrap();
