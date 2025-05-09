import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class ShapeService {
  private apiUrl = `${environment.API_URL}/shapez`; // API URL

  constructor(private http: HttpClient) {}

  get(prompt: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/generate`, { prompt });
  }
}
