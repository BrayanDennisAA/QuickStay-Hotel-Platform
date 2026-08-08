export type SearchHotelsRequestDto = {
  city: string;
  checkIn: string;
  checkOut: string;
};

export type SearchHotelsResponseDto = {
  hotelId: string;
  name: string;
  city: string;
  country: string;
  isAvailable: boolean;
};
