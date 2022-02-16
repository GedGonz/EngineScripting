import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FilecodeService {

  constructor(private http: HttpClient) { }


  readCode1(){
    return this.http.get('app/file/codeexample1.txt', {responseType: 'text'});
  }
  readCode2(){
    return this.http.get('app/file/codeexample2.txt', {responseType: 'text'});
  }
}
