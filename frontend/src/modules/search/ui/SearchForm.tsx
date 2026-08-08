'use client';

import { useActionState } from 'react';
import { searchHotelsAction } from './actions/searchActions';
import { SearchResults } from './SearchResults';
import { initialSearchState } from '../types/SearchTypes';

export const SearchForm = () => {
  const [state, formAction, pending] = useActionState(
    searchHotelsAction,
    initialSearchState,
  );

  return (
    <div className="mx-auto max-w-xl">
      <form action={formAction} className="grid grid-cols-1 gap-x-8 gap-y-6">
        <div>
          <label htmlFor="city" className="block text-sm/6 font-semibold ">
            City
          </label>
          <div className="mt-2.5">
            <input
              id="city"
              name="city"
              defaultValue="Bogota"
              placeholder="City"
              className="w-full block rounded-md px-3.5 py-2 text-base text-white outline-1 -outline-offset-1 outline-white/10 placeholder:text-gray-500  focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-500"
            />
          </div>
        </div>
        <div>
          <label htmlFor="checkIn" className="block text-sm/6 font-semibold">
            Check-in
          </label>
          <div className="mt-2.5">
            <input
              id="checkIn"
              name="checkIn"
              type="date"
              defaultValue="2026-08-10"
              className="w-full block rounded-md px-3.5 py-2 text-base text-white outline-1 -outline-offset-1 outline-white/10 placeholder:text-gray-500  focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-500"
            />
          </div>
        </div>

        <div>
          <label htmlFor="checkOut" className="block text-sm/6 font-semibold">
            Check-out
          </label>

          <input
            id="checkOut"
            name="checkOut"
            type="date"
            defaultValue="2026-08-12"
            className="w-full block rounded-md px-3.5 py-2 text-base text-white outline-1 -outline-offset-1 outline-white/10 placeholder:text-gray-500  focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-500"
          />
        </div>

        <button
          disabled={pending}
          className="block w-full rounded-md bg-indigo-500 px-3.5 py-2.5 text-center text-sm font-semibold text-white shadow-xs hover:bg-indigo-400 focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-500"
        >
          {pending ? 'Searching...' : 'Search'}
        </button>
      </form>

      {!state.ok && <p className="text-red-600">{state.error}</p>}
      {state.ok && state.data.length > 0 && (
        <p className="mt-2 text-green-600">
          Found {state.data.length} results
        </p>
      )}
      <hr className="my-4" />
      <h2 className="text-lg font-semibold">Results</h2>
      <SearchResults items={state.data} />
    </div>
  );
};
