import { SearchCriteriaValidationError } from '../errors/SearchDomainErrors';

export class SearchCriteria {
  private constructor(
    public readonly city: string,
    public readonly checkIn: string,
    public readonly checkOut: string,
  ) {}

  static create(input: {
    city: string;
    checkIn: string;
    checkOut: string;
  }): SearchCriteria {
    const city = input.city.trim();

    if (!city) throw new SearchCriteriaValidationError('City is required');
    if (!input.checkIn)
      throw new SearchCriteriaValidationError('Check-in is required');
    if (!input.checkOut)
      throw new SearchCriteriaValidationError('Check-out is required');
    if (input.checkOut <= input.checkIn) {
      throw new SearchCriteriaValidationError(
        'Check-out must be greater than check-in',
      );
    }

    return new SearchCriteria(city, input.checkIn, input.checkOut);
  }
}
