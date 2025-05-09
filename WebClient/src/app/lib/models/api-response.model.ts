interface ApiResultModel {
  isValid: boolean;
  errors: string[];
}

export interface ApiResult<T> extends ApiResultModel {
  model: T;
}
