import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { JobModel } from '../models/job.model';
import { API_URL } from '../constants/url.constants';
import { SingleJobModel } from '../models/single-job.model';
import { ElementModel } from '../models/element.model';
import { ServicemanModel } from '../models/serviceman.model';
import { JobCreationModel } from '../models/job-creation.model';
import { PartModel } from '../models/part.model';

@Injectable({
  providedIn: 'root'
})
export class JobsService {

  constructor(private http: HttpClient) { }

  getJobs() {
    return this.http.get<JobModel[]>(`${API_URL}/jobs`);
  }

  getSingleJob(idJob: number) {
    return this.http.get<SingleJobModel>(`${API_URL}/jobs/${idJob}`);
  }

  getElements() {
    return this.http.get<ElementModel[]>(`${API_URL}/elements`);
  }

  getParts() {
    return this.http.get<PartModel[]>(`${API_URL}/parts`);
  }

  getServiceMans(skill: number) {
    return this.http.get<ServicemanModel[]>(`${API_URL}/servicemen/${skill}`);
  }

  createJob(params: JobCreationModel) {
    return this.http.post<{ isSuccess: boolean }>(`${API_URL}/jobs`, params);
  }
}
