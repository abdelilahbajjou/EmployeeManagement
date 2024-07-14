import { Component, OnInit } from '@angular/core';
import { ActivatedRoute,Router,RouterLink,RouterModule } from '@angular/router';
import { EmployeeService } from '../employee.service';
import { Employee } from '../../model/employee';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-employee-details',
  standalone: true,
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.css'],
  imports:[RouterModule,RouterLink,CommonModule,FormsModule]
})
export class EmployeeDetailComponent implements OnInit {
  employee: Employee | undefined;

  constructor(
    private route: ActivatedRoute,
    private employeeService: EmployeeService
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id')!;
    this.employeeService.getEmployee(id).subscribe((employee: Employee) => {
      this.employee = employee;
    });
  }
}
