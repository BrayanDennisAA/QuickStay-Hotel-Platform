import { HotelSearchResult } from '../../domain/entities/HotelSearchResult';
import { SearchHotelsResponseDto } from '../../application/dto/SearchHotelsDto';

export class SearchMapper {
  static toDomain(dto: SearchHotelsResponseDto): HotelSearchResult {
    return HotelSearchResult.create({
      hotelId: dto.hotelId,
      name: dto.name,
      city: dto.city,
      country: dto.country,
      isAvailable: dto.isAvailable,
    });
  }

  static toDomainList(dtos: SearchHotelsResponseDto[]): HotelSearchResult[] {
    return dtos.map((dto) => this.toDomain(dto));
  }

  static toPrimitives(items: HotelSearchResult[]) {
    return items.map((x) => x.toPrimitives());
  }
}
