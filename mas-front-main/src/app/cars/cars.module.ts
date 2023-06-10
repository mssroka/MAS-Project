import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CarsRoutingModule } from './cars-routing.module';
import { CarsViewComponent } from './views/cars-view/cars-view.component';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatPaginatorModule } from '@angular/material/paginator';

@NgModule({
  declarations: [
    CarsViewComponent
  ],
    imports: [
        CommonModule,
        CarsRoutingModule,
        MatTableModule,
        MatButtonModule,
        MatPaginatorModule
    ]
})
export class CarsModule { }
