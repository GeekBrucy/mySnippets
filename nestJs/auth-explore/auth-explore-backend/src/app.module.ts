import { Module } from '@nestjs/common';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { AuthModule } from './auth/auth.module';
import { ConfigModule, ConfigService } from '@nestjs/config';
import { AuthService } from './auth/auth/auth.service';

@Module({
  imports: [
    // ConfigModule.forRoot({ isGlobal: true }),
    AuthModule
  ],
  controllers: [AppController],
  providers: [AppService, AuthService, ConfigService],
})
export class AppModule {}
