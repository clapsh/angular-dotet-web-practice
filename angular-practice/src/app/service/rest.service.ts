import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/internal/operators';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map } from 'rxjs/operators';
import { ApiResponse } from '../model/ApiResponse';
import { environment } from 'src/environments/environment';

const endpoint = environment.apiBaseUrl;

@Injectable({
  providedIn: 'root'
})
export class RestService {
  // url
  private formUrl = endpoint+'/v1/addItems';


  constructor(private http: HttpClient) { }

  
  addUser(userId:string, userName:string): Promise<any>{
    const formData = new FormData();
    formData.append('userId', userId); // form data에서는 value로 number를 보낼 수 없음
    formData.append('userName', userName);
    return this.http.post<ApiResponse>(this.formUrl,formData)
    .toPromise()
    .then(resp => {
      return resp;
    })
    .catch(resp=> {
      alert('오류 발생\n'+ resp.error);
      return Promise.reject(resp);
    });
    
  }

 
}
