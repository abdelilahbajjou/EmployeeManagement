import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators , FormsModule,
  ReactiveFormsModule} from '@angular/forms';
import { ActivatedRoute, Router,RouterModule } from '@angular/router';
import { EmployeeService } from '../employee.service';
import { Employee } from '../../model/employee';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-employee-edit',
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.css'],
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule
  ]
})
export class EmployeeEditComponent implements OnInit {
  employeeForm: FormGroup;
  employeeId: string;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private employeeService: EmployeeService
  ) {
    this.employeeForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: ['', [Validators.required, Validators.pattern('^[0-9]*$')]],
      position: ['', Validators.required],
      department: ['', Validators.required]
    });

    this.employeeId = this.route.snapshot.paramMap.get('id')!;
  }

  ngOnInit(): void {
    this.employeeService.getEmployee(this.employeeId).subscribe(employee => {
      this.employeeForm.patchValue(employee);
    });
  }

  editEmployee(): void {
    if (this.employeeForm.valid) {
      const updatedEmployee: Employee = {
        id: this.employeeId,
        ...this.employeeForm.value
      };

      this.employeeService.updateEmployee(this.employeeId, updatedEmployee).subscribe({
        next: () => this.router.navigate(['/employees']),
        error: err => console.error('Error updating employee:', err)
      });
    }
  }
}

