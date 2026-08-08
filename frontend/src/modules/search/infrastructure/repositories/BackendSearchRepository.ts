import { httpServer } from '@/shared/http/http.server';
import { HotelSearchResult } from '../../domain/entities/HotelSearchResult';
import { SearchRepository } from '../../domain/interfaces/SearchRepository';
import { SearchCriteria } from '../../domain/value-objects/SearchCriteria';
import { SearchHotelsResponseDto } from '../../application/dto/SearchHotelsDto';
import { SearchMapper } from '../mappers/SearchMapper';
import { getServerEnv } from '@/shared/config/env.server';

export class BackendSearchRepository implements SearchRepository {
  async searchHotels(criteria: SearchCriteria): Promise<HotelSearchResult[]> {
    const apiUrl = getServerEnv('API_BASE_URL');
    const queryParams = new URLSearchParams({
      city: criteria.city,
      checkIn: criteria.checkIn,
      checkOut: criteria.checkOut,
    });

    const response = await httpServer<SearchHotelsResponseDto[]>(
      `${apiUrl}/api/search/hotels?${queryParams.toString()}`,
      {
        method: 'GET',
      },
    );

    return SearchMapper.toDomainList(response);
  }
}
