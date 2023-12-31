import { Injectable } from '@angular/core';
import { AddCategoryRequest } from '../../models/add-category-request.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private httpclient:HttpClient) { }


  addCategory(model:AddCategoryRequest): Observable<void>{
    return this.httpclient.post<void>(`http://localhost:5209/createCategory`,model);
  }

}
