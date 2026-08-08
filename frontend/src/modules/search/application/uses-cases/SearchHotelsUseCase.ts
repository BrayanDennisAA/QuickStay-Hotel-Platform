import { HotelSearchResult } from '../../domain/entities/HotelSearchResult';
import { SearchRepository } from '../../domain/interfaces/SearchRepository';
import { SearchCriteria } from '../../domain/value-objects/SearchCriteria';

export class SearchHotelsUseCase {
  constructor(private readonly repository: SearchRepository) {}

  async execute(input: { city: string; checkIn: string; checkOut: string }) {
    const criteria = SearchCriteria.create(input);
    const results = await this.repository.searchHotels(criteria);
    
    const sorted = HotelSearchResult.sortByAvailabilityThenName(results);

    return sorted;
  }
}
