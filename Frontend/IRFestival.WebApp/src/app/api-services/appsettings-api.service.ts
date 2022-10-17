import { Injectable } from '@angular/core';
import { Schedule } from '../api/models/schedule.model';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AppSettings } from '../api/models/appsettings.model';

@Injectable({
  providedIn: 'root'
})
export class AppSettingsApiService {
  private baseUrl = environment.apiBaseUrl + 'settings';

  constructor(private httpClient: HttpClient) { }

  getSettings(): Observable<AppSettings> {
    const headers = new HttpHeaders().set('Ocp-Apim-Subscription-Key', '6e020f306dd94a5c953fbf441a18fdcc');
    return this.httpClient.get<AppSettings>(this.baseUrl, {'headers' : headers});
  }
}
