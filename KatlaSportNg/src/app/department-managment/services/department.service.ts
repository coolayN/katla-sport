import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { Department } from '../models/department';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {
  private url = environment.apiUrl + 'api/departments/';

  constructor(private http: HttpClient) { }

  getDepartments(): Observable<Array<Department>> {
    return this.http.get<Array<Department>>(this.url);
  }

  getDepartment(departmentId: number): Observable<Department> {
    return this.http.get<Department>(`${this.url}${departmentId}`);
  }

  addDepartment(department: Department): Observable<Department> {
    return this.http.post<Department>(`${this.url}`, department);
  }

  updateDepartment(department: Department): Observable<Object> {
    return this.http.put<Department>(`${this.url}${department.id}`, department);
  }

  deleteDepartment(departmentId: number): Observable<Object> {
    return this.http.delete<Department>(`${this.url}${departmentId}`);
  }

  setDepartmentStatus(departmentId: number, deletedStatus: boolean): Observable<Object> {
    return this.http.put<Department>(`${this.url}${departmentId}/status/${deletedStatus}`, null);
  }
}
