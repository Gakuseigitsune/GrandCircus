import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'; 

import { AppComponent } from './app.component';
import { ReddtPostListComponent } from './reddt-post-list/reddt-post-list.component';
import { ReddtPostComponent } from './reddt-post/reddt-post.component';


@NgModule({
  declarations: [
    AppComponent,
    ReddtPostListComponent,
    ReddtPostComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
