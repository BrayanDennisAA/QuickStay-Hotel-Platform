export type SearchActionState = {
  ok: boolean;
  error?: string;
  data: Array<{
    hotelId: string;
    name: string;
    city: string;
    country: string;
    isAvailable: boolean;
  }>;
};

export const initialSearchState: SearchActionState = {
  ok: true,
  data: [],
};
