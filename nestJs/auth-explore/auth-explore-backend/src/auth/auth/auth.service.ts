import { Injectable, Logger } from '@nestjs/common';
import { ConfigService } from '@nestjs/config';
import axios from 'axios';

@Injectable()
export class AuthService {
  private readonly logger = new Logger(AuthService.name);
  constructor(private configService: ConfigService) {}

  public async getUser(token: string): Promise<any> {
    const response = await axios.get(`https://api.jobadder.com/v2/users/current`, {
      headers: {
        "Authorization": `Bearer ${token}`,
      },
    })

    return response?.data ?? null;
  }

  async validateToken(token: string) {
    const clientId = this.configService.get<string>('JOBADDER_CLIENT_ID');
    const clientSecret = this.configService.get<string>('JOBADDER_CLIENT_SECRET');
    const introspectionUrl = 'https://id.jobadder.com/connect/introspect'; // JobAdder's introspection endpoint

    const auth = Buffer.from(`${clientId}:${clientSecret}`, "utf8").toString("base64");
    const params = new URLSearchParams({
      // client_id: clientId ?? '',
      // client_secret: clientSecret ?? '',
      token: token ?? '',
    });

    try {
      const response = await axios.post(introspectionUrl, params.toString(), {
        headers: {
          'Content-Type': 'application/x-www-form-urlencoded',
          'Authorization': `Basic ${auth}`
        }
      });

      this.logger.debug('Token introspection successful:', response.data);
      return response.data; // Returns token details (e.g., active, sub, exp)
    } catch (error) {
      this.logger.error('Token introspection failed:', error.response?.data || error.message);
      throw new Error('Failed to validate token');
    }
  }

  async exchangeCodeForToken(code: string) {
    const clientId = this.configService.get<string>('JOBADDER_CLIENT_ID');
    const clientSecret = this.configService.get<string>('JOBADDER_CLIENT_SECRET');
    const redirectUri = this.configService.get<string>('JOBADDER_REDIRECT_URI');
    console.log(Buffer.from(`${clientId}:${clientSecret}`).toString('base64'));
    const tokenUrl = 'https://id.jobadder.com/connect/token';
    const params = new URLSearchParams({
      client_id: clientId ?? '',
      client_secret: clientSecret ?? '',
      code: code ?? '',
      grant_type: 'authorization_code',
      redirect_uri: redirectUri ?? '',
    });

    this.logger.debug(`Sending request to ${tokenUrl} with params: ${params.toString()}`);

    try {
      const response = await axios.post(tokenUrl, params, {
        headers: {
          'Content-Type': 'application/x-www-form-urlencoded',
        },
      });
      this.logger.debug('Token exchange successful:', response.data);
      return response.data;
    } catch (error) {
      this.logger.error('Token exchange failed:', error.response?.data || error.message);
      throw new Error('Failed to exchange code for tokens');
    }
  }

  async refreshTokens(refreshToken: string) {
    const clientId = this.configService.get<string>('JOBADDER_CLIENT_ID');
    const clientSecret = this.configService.get<string>('JOBADDER_CLIENT_SECRET');
  
    const tokenUrl = 'https://id.jobadder.com/connect/token';
  
    const params = new URLSearchParams({
      client_id: clientId ?? '',
      client_secret: clientSecret ?? '',
      refresh_token: refreshToken ?? '',
      grant_type: 'refresh_token',
    });
  
    try {
      const response = await axios.post(tokenUrl, params, {
        headers: {
          'Content-Type': 'application/x-www-form-urlencoded',
        },
      });
  
      return response.data; // Returns new access_token and refresh_token
    } catch (error) {
      throw new Error('Failed to refresh tokens');
    }
  }
}
