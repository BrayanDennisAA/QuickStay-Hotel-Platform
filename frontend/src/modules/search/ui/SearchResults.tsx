import { SearchHotelsResponseDto } from '../application/dto/SearchHotelsDto';

type Props = { items: SearchHotelsResponseDto[] };

export const SearchResults = ({ items }: Props) => {
  if (!items || items.length === 0) {
    return <div className='mt-2'>No results found</div>;
  }
  return (
    <div className="grid gap-3">
      {items.map((h) => (
        <div key={h.hotelId} className="border rounded-xl p-4">
          <h3 className="font-semibold">{h.name}</h3>
          <p>
            {h.city}, {h.country}
          </p>
          <p className={h.isAvailable ? 'text-green-600' : 'text-red-600'}>
            {h.isAvailable ? 'Available' : 'Not available'}
          </p>
        </div>
      ))}
    </div>
  );
};
