import { Body, Controller, Post } from '@nestjs/common';
import { AuthService } from './auth.service';

@Controller('auth')
export class AuthController {
  constructor(private readonly authService: AuthService) {}

  @Post('callback')
  async handleCallback(@Body('code') code: string) {
    const tokens = await this.authService.exchangeCodeForToken(code);

    return { tokens };
  }

  @Post('refresh')
  async refreshToken(@Body('refresh_token') refreshToken: string) {
    const tokens = await this.authService.refreshTokens(refreshToken);
    return { tokens };
  }
}
