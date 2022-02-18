import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FilecodeService {

  constructor(private http: HttpClient) { }


  readCode(name:string){
    return this.http.get(`app/file/${name}.txt`, {responseType: 'text'});
  }

}
