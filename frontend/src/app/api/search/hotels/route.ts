import { SearchHotelsRequestDto } from '@/modules/search/application/dto/SearchHotelsDto';
import { SearchHotelsUseCase } from '@/modules/search/application/uses-cases/SearchHotelsUseCase';
import { SearchMapper } from '@/modules/search/infrastructure/mappers/SearchMapper';
import { BackendSearchRepository } from '@/modules/search/infrastructure/repositories/BackendSearchRepository';
import { NextRequest, NextResponse } from 'next/server';

export async function POST(request: NextRequest) {
  try {
    const body = (await request.json()) as SearchHotelsRequestDto;
    const useCase = new SearchHotelsUseCase(new BackendSearchRepository());
    const result = await useCase.execute(body);

    return NextResponse.json(SearchMapper.toPrimitives(result), {
      status: 200,
    });
  } catch (error) {
    const message =
      error instanceof Error ? error.message : 'Invalid request data';
    return NextResponse.json(message, { status: 400 });
  }
}
