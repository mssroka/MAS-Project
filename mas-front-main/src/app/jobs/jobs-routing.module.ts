import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { JobsViewComponent } from './views/jobs-view/jobs-view.component';
import { JobDetailsComponent } from './views/job-details/job-details.component';
import { JobCreationComponent } from './views/job-creation/job-creation.component';

const routes: Routes = [
  {
    path: '',
    component: JobsViewComponent,
  },
  {
    path: ':id',
    component: JobDetailsComponent,
  },
  {
    path: 'new/:id',
    component: JobCreationComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class JobsRoutingModule { }
