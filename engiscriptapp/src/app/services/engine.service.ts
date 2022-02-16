import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from "src/environments/environment";
@Injectable({
  providedIn: 'root'
})
export class EngineService {

  constructor(private http: HttpClient) { }

  getResultFromEngineStript(script: string, type: number) {

    const urlApi = type==1 ? `${environment.urlEngine}Engine/ExcuteScriptFunction`: `${environment.urlEngine}Engine/ExcuteScript`;
    
    const headers = new HttpHeaders()
        .append('Content-Type', 'application/json; charset=UTF-8');
    return this.http.post<any>(urlApi, JSON.stringify(script),{headers});
  }
}
