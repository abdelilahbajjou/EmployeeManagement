import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators,ReactiveFormsModule } from '@angular/forms';
import { Router ,RouterLink} from '@angular/router';
import { EmployeeService } from '../employee.service';
import { Employee } from '../../model/employee';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-add-employee',
  standalone:true,
  templateUrl: './employee-add.component.html',
  styleUrls: ['./employee-add.component.css'],
  imports:[ReactiveFormsModule,CommonModule,RouterLink]
})
export class EmployeeAddComponent {
  employeeForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private employeeService: EmployeeService,
    private router: Router
  ) {
    this.employeeForm = this.fb.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: ['', [Validators.required, Validators.pattern(/^[0-9]{10}$/)]],
      position: ['', [Validators.required]],
      department: ['', [Validators.required]]
    });
  }

  get f() {
    return this.employeeForm.controls;
  }

  addEmployee(): void {
    if (this.employeeForm.valid) {
      const employee: Employee = this.employeeForm.value;
      this.employeeService.addEmployee(employee).subscribe({
        next: (newEmployee) => {
          console.log('Employee added successfully:', newEmployee);
          this.router.navigate(['/employees']);
        },
        error: (error) => {
          console.error('Error adding employee:', error);
        }
      });
    } else {
      console.error('Form is invalid');
    }
  }
}
