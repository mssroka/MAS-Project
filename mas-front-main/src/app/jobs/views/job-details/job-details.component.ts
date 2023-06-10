import { Component, OnInit } from '@angular/core';
import { JobsService } from '../../../shared/services/jobs.service';
import { ActivatedRoute } from '@angular/router';
import { BaseComponent } from '../../../shared/components/base.component';
import { Observable } from 'rxjs';
import { SingleJobModel } from '../../../shared/models/single-job.model';

@Component({
  selector: 'app-job-details',
  templateUrl: './job-details.component.html',
  styleUrls: ['./job-details.component.scss']
})
export class JobDetailsComponent extends BaseComponent implements OnInit {
  job$ = new Observable<SingleJobModel>();

  constructor(
    private jobService: JobsService,
    private route: ActivatedRoute,
  ) {
    super();
  }

  ngOnInit() {
    this.observe(this.route.params)
      .subscribe(value => {
        const id = value['id'];

        this.job$ = this.jobService.getSingleJob(id);
      });
  }
}
