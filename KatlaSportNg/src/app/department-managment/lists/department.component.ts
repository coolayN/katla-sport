import { Component, OnInit } from '@angular/core';
import { Department } from '../models/department';
import { DepartmentService } from '../services/department.service';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentListComponent implements OnInit {

  departments: Department[];

  constructor(private departmentService: DepartmentService) { }

  ngOnInit() {
    this.getDepartments();
  }

  getDepartments() {
    this.departmentService.getDepartments().subscribe(d => this.departments = d);
  }

  onDelete(departmentId: number) {
    var department = this.departments.find(d => d.id == departmentId);
    this.departmentService.setDepartmentStatus(departmentId, true).subscribe(c => department.isDeleted = true);
  }

  onRestore(departmentId: number) {
    var hive = this.departments.find(d => d.id == departmentId);
    this.departmentService.setDepartmentStatus(departmentId, false).subscribe(c => hive.isDeleted = false);
  }
}
