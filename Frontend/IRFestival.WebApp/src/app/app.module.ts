import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './layout/header/header.component';
import { FooterComponent } from './layout/footer/footer.component';
import { LayoutModule } from './layout/layout.module';
import { HttpClientModule } from '@angular/common/http';
import { MsalModule, MsalRedirectComponent } from '@azure/msal-angular';
import { PublicClientApplication } from '@azure/msal-browser';
import { environment } from 'src/environments/environment';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,

    HttpClientModule,

    LayoutModule,

    MsalModule.forRoot( new PublicClientApplication({
      auth: {
        clientId: '35a51507-e09d-4d62-bda4-4a6e0bee1dd4',
        authority: 'https://login.microsoftonline.com/245dbd46-9d47-4e7c-b0ee-f7a7850fb86d',
        redirectUri: environment.redirectUrl
      },
      cache: {
        cacheLocation: 'localStorage'
      }
    }), null, null)
  ],
  providers: [],
  bootstrap: [AppComponent, MsalRedirectComponent]
})
export class AppModule { }
