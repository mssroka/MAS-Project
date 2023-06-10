import { Component, OnInit } from '@angular/core';
import { CarsService } from '../../../shared/services/cars.service';
import { BaseComponent } from '../../../shared/components/base.component';
import { Observable } from 'rxjs';
import { CarModel } from '../../../shared/models/car.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cars-view',
  templateUrl: './cars-view.component.html',
  styleUrls: ['./cars-view.component.scss']
})
export class CarsViewComponent extends BaseComponent implements OnInit {
  cars$ = new Observable<CarModel[]>();
  columns = ['plates', 'brand', 'model', 'owner', 'add'];

  constructor(
    private carService: CarsService,
    private router: Router
  ) {
    super();
  }

  ngOnInit() {
    this.cars$ = this.carService.getCars();
  }

  navigateToCreation(id: number) {
    this.router.navigate(['jobs/new', id]);
  }
}
