// // src/auth/opaque-token.guard.ts
// import { ExecutionContext, Injectable, UnauthorizedException } from '@nestjs/common';
// import { AuthGuard } from '@nestjs/passport';
// import { AuthService } from './auth.service';

// @Injectable()
// export class OpaqueTokenGuard extends AuthGuard('bearer') {
//   constructor(private authService: AuthService) {
//     super();
//   }

//   async canActivate(context: ExecutionContext): Promise<boolean> {
//     const request = context.switchToHttp().getRequest();
//     const token = request.headers.authorization?.split(' ')[1];

//     if (!token) {
//       throw new UnauthorizedException('No token provided');
//     }

//     const tokenDetails = await this.authService.getUser(token);
// console.log(tokenDetails);

//     if (!tokenDetails.test) {
//       throw new UnauthorizedException('Guard: Invalid token');
//     }

//     // Attach token details to the request
//     request.user = tokenDetails;
//     return true;
//   }
// }