import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LinkedDataComponent } from './linked-data/linked-data.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { MaterialModule } from './material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { LinkedDataObjComponent } from './linked-data-obj/linked-data-obj.component';

@NgModule({
  declarations: [
    AppComponent,
    LinkedDataComponent,
    LinkedDataObjComponent
  ],
  imports: [
    BrowserModule,
    MaterialModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
