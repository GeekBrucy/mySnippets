import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { MatButtonModule } from "@angular/material/button";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatListModule } from "@angular/material/list";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

import { MsalGuard, MsalGuardConfiguration, MsalInterceptor, MsalInterceptorConfiguration, MsalModule, MsalRedirectComponent } from "@azure/msal-angular";
import { InteractionType, PublicClientApplication } from "@azure/msal-browser";
import { HomeComponent } from './home/home.component';
import { ProfileComponent } from './profile/profile.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

const isIE =
  window.navigator.userAgent.indexOf("MSIE ") > -1 ||
  window.navigator.userAgent.indexOf("Trident/") > -1;

const guardConfig = {
  interactionType: InteractionType.Redirect,
  authRequest: {
    scopes: ["user.read"]
  }
} as MsalGuardConfiguration
const interceptionConfig = {
  interactionType: InteractionType.Redirect,
  protectedResourceMap: new Map([
    ["https://graph.microsoft.com/v1.0/me", ["user.read"]],
  ])
} as MsalInterceptorConfiguration
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ProfileComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    MatButtonModule,
    MatToolbarModule,
    MatListModule,
    MsalModule.forRoot(
      new PublicClientApplication({
        auth: {
          clientId: "286a7f72-864c-4ccd-90e8-25a491921f64", // Application (client) ID from the app registration
          authority:
            "https://login.microsoftonline.com/693389cf-46e7-42e4-b0f4-3fe953db633a", // The Azure cloud instance and the app's sign-in audience (tenant ID, common, organizations, or consumers)
          redirectUri: "http://localhost:4200", // This is your redirect URI
        },
        cache: {
          cacheLocation: "localStorage",
          storeAuthStateInCookie: isIE, // Set to true for Internet Explorer 11
        },
      }),
      guardConfig,
      interceptionConfig
    ),
  ],
  providers: [
    provideAnimationsAsync(),
    {
      provide: HTTP_INTERCEPTORS,
      useClass: MsalInterceptor,
      multi: true
    },
    MsalGuard
  ],
  // bootstrap: [AppComponent]
  bootstrap: [AppComponent, MsalRedirectComponent]
})
export class AppModule { }
