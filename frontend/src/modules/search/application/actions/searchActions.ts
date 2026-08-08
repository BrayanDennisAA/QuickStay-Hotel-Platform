'use server';

import { SearchMapper } from '../../infrastructure/mappers/SearchMapper';
import { BffSearchRepository } from '../../infrastructure/repositories/BffSearchRepository';
import { SearchActionState } from '../../types/SearchTypes';
import { SearchHotelsUseCase } from '../uses-cases/SearchHotelsUseCase';

export async function searchHotelsAction(
  _prevState: SearchActionState,
  formData: FormData,
): Promise<SearchActionState> {
  try {
    const city = String(formData.get('city') ?? '');
    const checkIn = String(formData.get('checkIn') ?? '');
    const checkOut = String(formData.get('checkOut') ?? '');

    const useCase = new SearchHotelsUseCase(new BffSearchRepository());
    const result = await useCase.execute({ city, checkIn, checkOut });

    return {
      ok: true,
      data: SearchMapper.toPrimitives(result),
    };
  } catch (error) {
    return {
      ok: false,
      error: (error as Error).message,
      data: [],
    };
  }
}
