export interface SingleJobModel {
  idJob: number;
  startDate: Date;
  endDate: Date;
  cost: number;
  status: string;
  note?: string;
  diagnose?: string;
  plates: string;
  brand: string;
  model: string;
  firstName: string;
  lastName: string;
  overviews: Overview[];
  paintings: Painting[];
  replacements: Replacement[];
}

export interface Overview {
  serviceDate: Date;
  name: string;
  difficultyLevel: number;
  cost: number;
}

export interface Painting {
  serviceDate: Date;
  name: string;
  difficultyLevel: number;
  colour: string;
  elements: PaintingElement[];
}

export interface PaintingElement {
  name: string;
  cost: number;
}

export interface Replacement {
  serviceDate: Date;
  name: string;
  difficultyLevel: number;
  parts: ReplacementElement[];
}

export interface ReplacementElement {
  name: string;
  cost: number;
}
