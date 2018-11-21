import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html'
})

export class EmployeesComponent {
  private _http: HttpClient;
  private _baseUrl: string;

  public employees: Employee[];
  public employeeId: number;
  public error: string;
  public loading = false;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._http = http;
    this._baseUrl = baseUrl;
  }

  public getEmployees() {

    this.loading = true;
    this.error = "";
    this.employees = null;

    if (this.employeeId > 0) {
      this._http.get<Employee>(this._baseUrl + 'api/v1/Employee/' + this.employeeId).subscribe(result => {
        this.employees = new Array<Employee>();
        this.employees.push(result);
        this.loading = false;
      }, error => {
        console.error(error);
        this.error = error.statusText;
        this.loading = false;
      });
    }
    else {
      this._http.get<Employee[]>(this._baseUrl + 'api/v1/Employee').subscribe(result => {
        this.employees = result;
        this.loading = false;
      }, error => {
        console.error(error);
        this.error = error.statusText;
        this.loading = false;
      });
    }
  }
}

interface Employee {
  id: number;
  name: string;
  contractTypeDescription: string;
  role: string;
  salary: number;
  annualSalary: number;
}
