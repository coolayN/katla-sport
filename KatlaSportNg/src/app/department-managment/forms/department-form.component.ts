import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DepartmentService } from '../services/department.service';
import { Department } from '../models/department';

@Component({
  selector: 'app-department-form',
  templateUrl: './department-form.component.html',
  styleUrls: ['./department-form.component.css']
})

export class DepartmentFormComponent implements OnInit {
  department = new Department(0, 0,"", "", "", false, "", null);
  existed = false;
  departments: Department[];

  constructor(private route: ActivatedRoute, private router: Router, private departmentService: DepartmentService) { }
  ngOnInit() {
    this.departmentService.getDepartments().subscribe(d =>{ this.departments = d});
    this.route.params.subscribe(p => {

      if (p['id'] === undefined)
        return;
        this.existed = true;
      this.departmentService.getDepartment(p['id']).subscribe(d => this.department = d);
      let ind = this.departments.indexOf(this.department);
      this.departments.splice(ind,1);
    });
  }
  navigateToDepartments() {
    this.router.navigate(['/departments']);
  }
  onCancel() {
    this.navigateToDepartments();
  }
  onSubmit() {
    if (this.existed) {
      this.departmentService.updateDepartment(this.department).subscribe(p => this.navigateToDepartments());
    }
    else {
      this.departmentService.addDepartment(this.department).subscribe(p => this.navigateToDepartments());
    }
  }
  onDelete() {
    this.departmentService.setDepartmentStatus(this.department.id, true).subscribe(c => this.department.isDeleted = true);
  }
  onUndelete() {
    this.departmentService.setDepartmentStatus(this.department.id, false).subscribe(c => this.department.isDeleted = false);
  }
  onPurge() {
    this.departmentService.deleteDepartment(this.department.id).subscribe(p => this.navigateToDepartments());
  }
}
