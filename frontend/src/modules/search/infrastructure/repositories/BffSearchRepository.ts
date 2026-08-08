import { httpClient } from '@/shared/http/http.client';
import { HotelSearchResult } from '../../domain/entities/HotelSearchResult';
import { SearchRepository } from '../../domain/interfaces/SearchRepository';
import { SearchCriteria } from '../../domain/value-objects/SearchCriteria';
import { SEARCH_BFF_ENDPOINT } from '../../application/constants/SearchConstants';
import { SearchHotelsResponseDto } from '../../application/dto/SearchHotelsDto';
import { SearchMapper } from '../mappers/SearchMapper';

export class BffSearchRepository implements SearchRepository {
  async searchHotels(criteria: SearchCriteria): Promise<HotelSearchResult[]> {
    const response = await httpClient<SearchHotelsResponseDto[]>(
      SEARCH_BFF_ENDPOINT,
      {
        method: 'POST',
        body: criteria,
      },
    );

    return SearchMapper.toDomainList(response);
  }
}
