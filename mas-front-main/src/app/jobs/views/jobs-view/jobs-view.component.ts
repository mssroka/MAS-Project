import { AfterViewInit, Component, OnInit } from '@angular/core';
import {  Observable } from 'rxjs';
import { BaseComponent } from '../../../shared/components/base.component';
import { JobsService } from '../../../shared/services/jobs.service';
import { JobModel } from '../../../shared/models/job.model';
import { Router } from '@angular/router';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-jobs-view',
  templateUrl: './jobs-view.component.html',
  styleUrls: ['./jobs-view.component.scss']
})
export class JobsViewComponent extends BaseComponent implements OnInit {
  jobs$ = new Observable<JobModel[]>();
  columns = ['start', 'end', 'cost', 'status', 'car', 'employee'];

  constructor(
    private jobService: JobsService,
    private router: Router,
  ) {
    super();
  }

  ngOnInit() {
    this.jobs$ = this.jobService.getJobs();
  }

  navigateToDetails(idJob: number) {
    this.router.navigate([`jobs/${idJob}`]);
  }
}
