import { ShapeType } from '../enum/shape-type.enum';

export interface ShapeResponse {
  type: ShapeType;
  data: ShapeData;
}

export interface ShapeData {
  [key: string]: any;
}
