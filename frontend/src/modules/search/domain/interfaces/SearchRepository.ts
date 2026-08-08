import { HotelSearchResult } from "../entities/HotelSearchResult";
import { SearchCriteria } from "../value-objects/SearchCriteria";

export interface SearchRepository {
  searchHotels(criteria: SearchCriteria): Promise<HotelSearchResult[]>;
}
