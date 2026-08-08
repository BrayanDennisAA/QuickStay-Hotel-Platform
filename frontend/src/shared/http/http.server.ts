import { ApiError } from './http.types';

type RequestOptions = {
  method?: 'GET' | 'POST' | 'PUT' | 'DELETE';
  headers?: Record<string, string>;
  body?: unknown;
  cache?: RequestCache;
};

async function parseJsonSafe<T>(response: Response): Promise<T | null> {
  const contentType = response.headers.get('content-type') ?? '';
  if (contentType.includes('application/json')) {
    return await response.json();
  }
  return null;
}

export async function httpServer<T>(
  url: string,
  options: RequestOptions = {},
): Promise<T> {
  const response = await fetch(url, {
    method: options.method ?? 'GET',
    headers: {
      'Content-Type': 'application/json',
      ...(options.headers ?? {}),
    },
    body: options.body ? JSON.stringify(options.body) : undefined,
    cache: options.cache ?? 'no-cache',
  });

  if (!response.ok) {
    const text = await response.text();
    throw new ApiError({
      message: text || response.statusText,
      statusCode: response.status,
    });
  }

  const data = await parseJsonSafe<T>(response);

  if (data === null) {
    throw new ApiError({
      message: 'Response is not valid JSON',
      statusCode: 500,
    });
  }

  return data;
}
