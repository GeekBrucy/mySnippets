import { Controller, Get, Req, UnauthorizedException, UseGuards } from '@nestjs/common';
import { AppService } from './app.service';
import { AuthGuard } from '@nestjs/passport';
import { AuthService } from './auth/auth/auth.service';

@Controller()
export class AppController {
  constructor(
    private readonly appService: AppService,
    private readonly authService: AuthService
  ) {}

  @Get("protected")
  @UseGuards(AuthGuard('bearer'))
  async getHello(@Req() req): Promise<string> {
    const token = req.headers.authorization?.split(' ')[1];
    if (!token) {
      throw new UnauthorizedException('No token provided');
    }
    const tokenDetails = await this.authService.validateToken(token);

    if (!tokenDetails.active) {
      throw new UnauthorizedException('Invalid token');
    }
    return this.appService.getHello();
  }

  @Get('ja_user')
  @UseGuards(AuthGuard('bearer'))
  async getJAUser(@Req() req) {
    console.log(JSON.stringify(req.user));
    
    const token = req.headers.authorization?.split(' ')[1];
    return await this.authService.getUser(token);
  }
}
