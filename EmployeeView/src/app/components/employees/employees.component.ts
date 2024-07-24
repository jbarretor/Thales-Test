import { Component, OnInit } from '@angular/core';
import { EmployeeService as EmployeeService } from '../../services/employee.service';
import { Employee } from '../../Models/Employee';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrl: './employees.component.css'
})
export class EmployeesComponent implements OnInit {
  employees: Employee[] = [];
  employee: Employee | undefined;
  idSearch: number | null = null;

  constructor(private employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.loadClientes();
  }

  loadClientes(): void {
    this.employeeService.getEmployees().subscribe(data => {
      this.employees = data;
    });
  }

  searchById(): void {
    if (this.idSearch !== null) {
      this.employeeService.getEmployeeById(this.idSearch).subscribe(data => {
        this.employee = data;
        this.employees = [data]; 
      });
    } else {
      this.loadClientes();
    }
  }
}
