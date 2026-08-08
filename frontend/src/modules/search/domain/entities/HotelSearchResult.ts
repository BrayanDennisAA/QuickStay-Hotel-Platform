import { HotelSearchResultValidationError } from '../errors/SearchDomainErrors';

type Props = {
  hotelId: string;
  name: string;
  city: string;
  country: string;
  isAvailable: boolean;
};

export class HotelSearchResult {
  private constructor(private readonly props: Props) {}

  static create(props: Props): HotelSearchResult {
    if (!props.hotelId)
      throw new HotelSearchResultValidationError('hotelId is required');
    if (!props.name?.trim())
      throw new HotelSearchResultValidationError('name is required');
    if (!props.city?.trim())
      throw new HotelSearchResultValidationError('city is required');
    if (!props.country?.trim())
      throw new HotelSearchResultValidationError('country is required');

    return new HotelSearchResult({
      hotelId: props.hotelId,
      name: props.name.trim(),
      city: props.city.trim(),
      country: props.country.trim(),
      isAvailable: props.isAvailable,
    });
  }

  get hotelId() {
    return this.props.hotelId;
  }
  get name() {
    return this.props.name;
  }
  get city() {
    return this.props.city;
  }
  get country() {
    return this.props.country;
  }
  get isAvailable() {
    return this.props.isAvailable;
  }

  isInCity(city: string): boolean {
    return this.city.toLowerCase() === city.trim().toLowerCase();
  }

  availabilityRank(): number {
    return this.isAvailable ? 1 : 0;
  }

  static sortByAvailabilityThenName(
    items: HotelSearchResult[],
  ): HotelSearchResult[] {
    return [...items].sort((a, b) => {
      const byAvailability = b.availabilityRank() - a.availabilityRank();
      if (byAvailability !== 0) return byAvailability;
      return a.name.localeCompare(b.name);
    });
  }

  toPrimitives() {
    return {
      hotelId: this.hotelId,
      name: this.name,
      city: this.city,
      country: this.country,
      isAvailable: this.isAvailable,
    };
  }
}
