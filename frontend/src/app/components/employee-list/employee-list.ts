import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';              // ← needed for ngModel
import { RouterModule } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatTableDataSource, MatCellDef, MatHeaderCellDef } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatCardModule } from '@angular/material/card';

import { EmployeeService } from '../../services/employee';
import { Employee } from '../../models/employee';

@Component({
  selector: 'app-employee-list',
  standalone: true,
  templateUrl: './employee-list.html',  // make sure filename matches
  imports: [
    CommonModule,
    FormsModule,          // ← super important for [(ngModel)]
    RouterModule,
    MatCardModule,
    // Material modules
    MatTableModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
  ]
})
export class EmployeeListComponent implements OnInit {
  dataSource = new MatTableDataSource<Employee>();
  displayedColumns = ['id','firstName','lastName','email','position','actions'];
  filterValue = '';

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private svc: EmployeeService) {}

  ngOnInit() {
    this.load();
  }

  load() {
    this.svc.getAll().subscribe(data => {
      this.dataSource.data = data;
      this.dataSource.paginator = this.paginator;
      this.applyFilter();
    });
  }

  applyFilter() {
    this.dataSource.filter = this.filterValue.trim().toLowerCase();
  }

  delete(id: number) {
    if (confirm('Delete this employee?')) {
      this.svc.delete(id).subscribe(() => this.load());
    }
  }
}
