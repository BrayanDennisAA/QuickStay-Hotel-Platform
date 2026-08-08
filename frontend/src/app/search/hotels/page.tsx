import { SearchForm } from '@/modules/search/ui/SearchForm';

export default function SearchHotels() {
  return (
    <div className="flex flex-1 w-full flex-col items-center py-32 px-16">
      <div className="flex flex-col items-center gap-6 text-center sm:items-start sm:text-left pb-6">
        <h1 className="max-w-xs text-3xl font-semibold leading-10 tracking-tight text-black dark:text-zinc-50">
          Search Hotels
        </h1>
      </div>
      <SearchForm />
    </div>
  );
}
