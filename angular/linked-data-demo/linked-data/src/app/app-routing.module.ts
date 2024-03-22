import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LinkedDataObjComponent } from './linked-data-obj/linked-data-obj.component';
import { LinkedDataComponent } from './linked-data/linked-data.component';

const routes: Routes = [
  { path: 'simple-linked-data', component: LinkedDataComponent },
  { path: 'object-linked-data', component: LinkedDataObjComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
