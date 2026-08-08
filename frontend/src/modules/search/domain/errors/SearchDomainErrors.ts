export class SearchCriteriaValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'SearchCriteriaValidationError';
  }
}

export class HotelSearchResultValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'HotelSearchResultValidationError';
  }
}
