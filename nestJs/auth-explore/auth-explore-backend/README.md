1. Exchanges an **authorization code** for **tokens** (access token, ID token, refresh token).
2. Validates the **access token** issued by JobAdder.
3. Protects routes using a **JWT guard**.

Once the backend is ready, we’ll move to the **React frontend** to complete the POC.

---

## **Step 1: Set Up a New NestJS Project**

### **1. Install NestJS CLI**
If you haven’t already, install the NestJS CLI globally:
```bash
npm install -g @nestjs/cli
```

### **2. Create a New NestJS Project**
Run the following command to create a new NestJS project:
```bash
nest new jobadder-auth-backend
```
Choose your preferred package manager (e.g., `npm` or `yarn`).

### **3. Navigate to the Project**
```bash
cd jobadder-auth-backend
```

---

## **Step 2: Install Required Dependencies**

Install the necessary packages for handling HTTP requests, JWT validation, and environment variables:
```bash
npm install @nestjs/passport passport passport-jwt axios @nestjs/config
```

---

## **Step 3: Set Up Environment Variables**

Create a `.env` file in the root of your project and add the following variables:
```env
# JobAdder OAuth2 credentials
JOBADDER_CLIENT_ID=your-client-id
JOBADDER_CLIENT_SECRET=your-client-secret
JOBADDER_REDIRECT_URI=http://localhost:3000/callback

# JWT validation (optional for direct JobAdder auth)
JWT_SECRET=your-jwt-secret
```

---

## **Step 4: Create the Auth Module**

### **1. Generate the Auth Module**
Run the following command to generate the `AuthModule`:
```bash
nest generate module auth
```

### **2. Generate the Auth Service**
Run the following command to generate the `AuthService`:
```bash
nest generate service auth
```

### **3. Generate the Auth Controller**
Run the following command to generate the `AuthController`:
```bash
nest generate controller auth
```

---

## **Step 5: Implement the Auth Service**

Update the `auth.service.ts` file to handle the OAuth2 flow:

```typescript
// src/auth/auth.service.ts
import { Injectable } from '@nestjs/common';
import { ConfigService } from '@nestjs/config';
import axios from 'axios';

@Injectable()
export class AuthService {
  constructor(private configService: ConfigService) {}

  async exchangeCodeForTokens(code: string) {
    const clientId = this.configService.get<string>('JOBADDER_CLIENT_ID');
    const clientSecret = this.configService.get<string>('JOBADDER_CLIENT_SECRET');
    const redirectUri = this.configService.get<string>('JOBADDER_REDIRECT_URI');

    const tokenUrl = 'https://id.jobadder.com/connect/token';

    const response = await axios.post(
      tokenUrl,
      new URLSearchParams({
        client_id: clientId,
        client_secret: clientSecret,
        code: code,
        redirect_uri: redirectUri,
        grant_type: 'authorization_code',
      }),
      {
        headers: {
          'Content-Type': 'application/x-www-form-urlencoded',
        },
      },
    );

    return response.data; // Returns access_token, id_token, refresh_token, etc.
  }
}
```

---

## **Step 6: Implement the Auth Controller**

Update the `auth.controller.ts` file to handle the callback and token exchange:

```typescript
// src/auth/auth.controller.ts
import { Controller, Post, Body } from '@nestjs/common';
import { AuthService } from './auth.service';

@Controller('auth')
export class AuthController {
  constructor(private readonly authService: AuthService) {}

  @Post('callback')
  async handleCallback(@Body('code') code: string) {
    const tokens = await this.authService.exchangeCodeForTokens(code);
    return { tokens };
  }
}
```

---

## **Step 7: Set Up the App Module**

Update the `app.module.ts` file to include the `AuthModule` and configure the `ConfigModule`:

```typescript
// src/app.module.ts
import { Module } from '@nestjs/common';
import { ConfigModule } from '@nestjs/config';
import { AuthModule } from './auth/auth.module';

@Module({
  imports: [
    ConfigModule.forRoot({ isGlobal: true }), // Load environment variables
    AuthModule,
  ],
})
export class AppModule {}
```

---

## **Step 8: Test the Backend**

### **1. Start the NestJS Server**
Run the following command to start the server:
```bash
npm run start
```

### **2. Test the `/auth/callback` Endpoint**
Use a tool like **Postman** or **cURL** to test the endpoint:
```bash
curl -X POST http://localhost:3000/auth/callback \
  -H "Content-Type: application/json" \
  -d '{"code": "your-authorization-code"}'
```

If successful, the backend will return the tokens:
```json
{
  "tokens": {
    "access_token": "your-access-token",
    "id_token": "your-id-token",
    "refresh_token": "your-refresh-token"
  }
}
```