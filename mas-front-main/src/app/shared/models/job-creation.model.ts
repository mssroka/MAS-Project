export interface JobCreationModel {
  idCar: number;
  dateStart: Date;
  dateEnd: Date;
  note: string | null;
  idServiceMan: number;
  finalCost: number;
  overviewJobCreation?: OverviewCreation;
  paintingJobCreation?: PaintingCreation;
  replacementJobCreation?: ReplacementCreation;
}

export interface OverviewCreation {
  difficultyLevel: number;
  serviceDate: Date;
}

export interface PaintingCreation {
  difficultyLevel: number;
  serviceDate: Date;
  colour: string;
  elementsIds: number[];
}

export interface ReplacementCreation {
  difficultyLevel: number;
  serviceDate: Date;
  partsIds: number[];
}
