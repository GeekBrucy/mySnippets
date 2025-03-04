import { Injectable, UnauthorizedException } from "@nestjs/common";
import { PassportStrategy } from "@nestjs/passport";
import { Strategy } from 'passport-http-bearer';
import { AuthService } from "./auth.service";

@Injectable()
export class BearerStrategy extends PassportStrategy(Strategy) {
  constructor(private authService: AuthService) {
    super();
  }

  async validate(token: string): Promise<any> {
    const tokenDetails = await this.authService.getUser(token);
    if (!tokenDetails.userId) {
      throw new UnauthorizedException('Strategy: Invalid token');
    }

    return tokenDetails; // Attach token details to the request
  }
}