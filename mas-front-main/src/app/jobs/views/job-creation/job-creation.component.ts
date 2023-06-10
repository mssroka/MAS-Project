import { Component, OnInit } from '@angular/core';
import { NonNullableFormBuilder, Validators } from '@angular/forms';
import { BaseComponent } from '../../../shared/components/base.component';
import { startWith, throwError } from 'rxjs';
import { ElementModel } from '../../../shared/models/element.model';
import { ServicemanModel } from '../../../shared/models/serviceman.model';
import { JobsService } from '../../../shared/services/jobs.service';
import { ActivatedRoute, Router } from '@angular/router';
import {
  JobCreationModel,
  OverviewCreation,
  PaintingCreation,
  ReplacementCreation
} from '../../../shared/models/job-creation.model';
import { PartModel } from '../../../shared/models/part.model';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-job-creation',
  templateUrl: './job-creation.component.html',
  styleUrls: ['./job-creation.component.scss']
})
export class JobCreationComponent extends BaseComponent implements OnInit {
  readonly formGroup = this.fb.group({
    startDate: this.fb.control<Date | null>(null, Validators.required),
    endDate: this.fb.control<Date | null>(null, Validators.required),
    note: this.fb.control<string | null>(null),
    cost: this.fb.control<number | null>(null, Validators.required),
    serviceManId: this.fb.control<number | null>(null, Validators.required),
  });

  readonly replacementForm = this.fb.group({
    isReplacement: this.fb.control<Boolean>(false),
    parts: this.fb.control<PartModel[]>([]),
    serviceDate: this.fb.control<Date | null>(null),
    difficultyLevel: this.fb.control<number>(1),
  });

  readonly paintingForm = this.fb.group({
    isPainting: this.fb.control<Boolean>(false),
    elements: this.fb.control<ElementModel[]>([]),
    color: this.fb.control<string>(''),
    serviceDate: this.fb.control<Date | null>(null),
    difficultyLevel: this.fb.control<number>(1),
  });

  readonly overviewForm = this.fb.group({
    isOverview: this.fb.control<Boolean>(false),
    serviceDate: this.fb.control<Date | null>(null),
    difficultyLevel: this.fb.control<number>(1),
  });

  parts: PartModel[] = [];
  elements : ElementModel[] = [];
  serviceMans :ServicemanModel[] = [];

  carId?: number;

  get isReplacement() {
    return this.replacementForm.controls.isReplacement;
  }

  get isPainting() {
    return this.paintingForm.controls.isPainting;
  }

  get isOverview() {
    return this.overviewForm.controls.isOverview;
  }

  get paintingSum() {
    return this.paintingForm.controls.elements.value.map(ele => ele.cost).reduce((partial, sum) => partial + sum, 0);
  }

  get replacementSum() {
    return this.replacementForm.controls.parts.value.map(ele => ele.cost).reduce((partial, sum) => partial + sum, 0);
  }

  get canSave() {
    return this.formGroup.invalid || ![this.isOverview.value, this.isPainting.value, this.isReplacement.value].some(value => value)
  }

  get sum() {
    return this.replacementSum + this.paintingSum + Number(this.formGroup.controls.cost.value!);
  }

  constructor(
    private fb: NonNullableFormBuilder,
    private jobService: JobsService,
    private route: ActivatedRoute,
    private router: Router,
  ) {
    super();
  }

  ngOnInit() {
    this.observe(this.jobService.getParts())
      .subscribe(value => this.parts = value);

    this.observe(this.jobService.getElements())
      .subscribe(value => this.elements = value);

    this.observe(this.jobService.getServiceMans(1))
      .subscribe(value => this.serviceMans = value);

    this.observe(this.route.params)
      .subscribe(value => {
        this.carId = value['id'];
      });

    this.observe(this.isReplacement.valueChanges)
      .pipe(startWith(false))
      .subscribe(value => {
        if (value) {
          this.replacementForm.controls.parts.enable({ emitEvent: false });
          this.replacementForm.controls.difficultyLevel.enable({ emitEvent: false });
          this.replacementForm.controls.serviceDate.enable({ emitEvent: false });

          this.replacementForm.controls.parts.addValidators(Validators.required);
          this.replacementForm.controls.difficultyLevel.addValidators([Validators.required, Validators.min(1), Validators.max(5)]);
          this.replacementForm.controls.serviceDate.addValidators(Validators.required);
        } else {
          this.replacementForm.controls.parts.disable({ emitEvent: false });
          this.replacementForm.controls.difficultyLevel.disable({ emitEvent: false });
          this.replacementForm.controls.serviceDate.disable({ emitEvent: false });

          this.replacementForm.controls.parts.removeValidators(Validators.required);
          this.replacementForm.controls.difficultyLevel.removeValidators([Validators.required, Validators.min(1), Validators.max(5)]);
          this.replacementForm.controls.serviceDate.removeValidators(Validators.required);
        }
      });

    this.observe(this.isPainting.valueChanges)
      .pipe(startWith(false))
      .subscribe(value => {
        if (value) {
          this.paintingForm.controls.elements.enable({ emitEvent: false });
          this.paintingForm.controls.color.enable({ emitEvent: false });
          this.paintingForm.controls.serviceDate.enable({ emitEvent: false });
          this.paintingForm.controls.difficultyLevel.enable({ emitEvent: false });

          this.paintingForm.controls.elements.addValidators(Validators.required);
          this.paintingForm.controls.color.addValidators(Validators.required);
          this.paintingForm.controls.serviceDate.addValidators(Validators.required);
          this.paintingForm.controls.difficultyLevel.addValidators([Validators.required, Validators.min(1), Validators.max(5)]);
        } else {
          this.paintingForm.controls.elements.disable({ emitEvent: false });
          this.paintingForm.controls.color.disable({ emitEvent: false });
          this.paintingForm.controls.serviceDate.disable({ emitEvent: false });
          this.paintingForm.controls.difficultyLevel.disable({ emitEvent: false });

          this.paintingForm.controls.elements.removeValidators(Validators.required);
          this.paintingForm.controls.color.removeValidators(Validators.required);
          this.paintingForm.controls.serviceDate.removeValidators(Validators.required);
          this.paintingForm.controls.difficultyLevel.removeValidators([Validators.required, Validators.min(1), Validators.max(5)]);
        }
      });

    this.observe(this.isOverview.valueChanges)
      .pipe(startWith(false))
      .subscribe(value => {
        if (value) {
          this.overviewForm.controls.serviceDate.enable({ emitEvent: false });
          this.overviewForm.controls.difficultyLevel.enable({ emitEvent: false });

          this.overviewForm.controls.serviceDate.addValidators(Validators.required);
          this.overviewForm.controls.difficultyLevel.addValidators(Validators.required);
        } else {
          this.overviewForm.controls.serviceDate.disable({ emitEvent: false });
          this.overviewForm.controls.difficultyLevel.disable({ emitEvent: false });

          this.overviewForm.controls.serviceDate.removeValidators(Validators.required);
          this.overviewForm.controls.difficultyLevel.removeValidators(Validators.required);
        }
      });

    this.observe(this.replacementForm.controls.difficultyLevel.valueChanges)
      .subscribe(value => {
        if (value === this.getMaxDifficultyLevel() && value <= 5) {
          this.observe(this.jobService.getServiceMans(value))
            .subscribe(value => { this.serviceMans = value });
        }
      });

    this.observe(this.overviewForm.controls.difficultyLevel.valueChanges)
      .subscribe(value => {
        if (value === this.getMaxDifficultyLevel() && value <= 5) {
          this.observe(this.jobService.getServiceMans(value))
            .subscribe(value => { this.serviceMans = value });
        }
      });

    this.observe(this.paintingForm.controls.difficultyLevel.valueChanges)
      .subscribe(value => {
        if (value === this.getMaxDifficultyLevel() && value <= 5) {
          this.observe(this.jobService.getServiceMans(value))
            .subscribe(value => { this.serviceMans = value });
        }
      });
  }

  save() {
    let overview: OverviewCreation | undefined = {
      difficultyLevel: +this.overviewForm.controls.difficultyLevel.value!,
      serviceDate: this.overviewForm.controls.serviceDate.value!,
    };

    let replacement: ReplacementCreation | undefined = {
      difficultyLevel: +this.replacementForm.controls.difficultyLevel.value!,
      serviceDate: this.replacementForm.controls.serviceDate.value!,
      partsIds: this.replacementForm.controls.parts.value.map(ele => ele.idPart),
    };

    let painting: PaintingCreation | undefined = {
      difficultyLevel: +this.paintingForm.controls.difficultyLevel.value!,
      serviceDate: this.paintingForm.controls.serviceDate.value!,
      colour: this.paintingForm.controls.color.value,
      elementsIds: this.paintingForm.controls.elements.value.map(ele => ele.idElement),
    }

    if (!this.isOverview.value) {
      overview = undefined;
    }

    if (!this.isReplacement.value) {
      replacement = undefined;
    }

    if (!this.isPainting.value) {
      painting = undefined;
    }

    const model: JobCreationModel = {
      idCar: +this.carId!,
      dateStart: this.formGroup.controls.startDate.value!,
      dateEnd: this.formGroup.controls.endDate.value!,
      idServiceMan: this.formGroup.controls.serviceManId.value!,
      finalCost: this.sum,
      note: this.formGroup.controls.note.value,
      overviewJobCreation: overview,
      replacementJobCreation: replacement,
      paintingJobCreation: painting,
    }

    this.jobService.createJob(model)
      .subscribe(
        (result) => { this.router.navigate(['jobs']); },
      );
  }

  cancel() {
    this.router.navigate(['jobs']);
  }

  private getMaxDifficultyLevel() {
    const overview = +this.overviewForm.controls.difficultyLevel.value;
    const replacement = +this.replacementForm.controls.difficultyLevel.value;
    const painting = +this.paintingForm.controls.difficultyLevel.value;

    return Math.max(...[overview, replacement, painting]);
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 200 || error.status === 204) {
      return ;
    }

    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    // Return an observable with a user-facing error message.
    return throwError(() => new Error('Something bad happened; please try again later.'));
  }
}
