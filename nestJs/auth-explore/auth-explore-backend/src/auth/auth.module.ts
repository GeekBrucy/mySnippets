import { Module } from '@nestjs/common';
import { AuthService } from './auth/auth.service';
import { AuthController } from './auth/auth.controller';
import { PassportModule } from '@nestjs/passport';
import { JwtModule } from '@nestjs/jwt';
import { ConfigModule, ConfigService } from '@nestjs/config';
import { JwtStrategy } from './auth/jwt.strategy';
import { BearerStrategy } from './auth/bearer.strategy';

@Module({
  imports: [
    PassportModule.register({ defaultStrategy: 'jwt' }),
    // JwtModule.registerAsync({
    //   imports: [ConfigModule],
    //   useFactory: async (configService: ConfigService) => ({
    //     secret: configService.get<string>('JWT_SECRET'),
    //     signOptions: { expiresIn: '1h'}
    //   }),
    //   inject: [ConfigService]
    // })
    ConfigModule.forRoot(),
  ],
  controllers: [AuthController],
  providers: [AuthService, BearerStrategy],
  // providers: [AuthService, JwtStrategy],
  exports: [PassportModule]
})
export class AuthModule {}
