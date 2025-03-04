import { Injectable } from '@nestjs/common';
import { ConfigService } from '@nestjs/config';
import { PassportStrategy } from '@nestjs/passport';
import { createRemoteJWKSet, jwtVerify } from 'jose';
import { ExtractJwt, Strategy } from 'passport-jwt';

const jwksUrl = 'https://id.jobadder.com/.well-known/jwks';
const jwks = createRemoteJWKSet(new URL(jwksUrl));

@Injectable()
export class JwtStrategy extends PassportStrategy(Strategy) {
  constructor() {
    super({
      jwtFromRequest: ExtractJwt.fromAuthHeaderAsBearerToken(),
      ignoreExpiration: false,
      secretOrKey: async (request, rawJwtToken, done) => {
        try {
          const { payload } = await jwtVerify(rawJwtToken, jwks);
          console.log(payload);
          console.log(rawJwtToken);
          
          done(null, payload);
        } catch (err) {
          done(err, null);
        }
      },
    });
  }

  async validate(payload: any) {
    return { userId: payload.sub, username: payload.username };
  }
}
