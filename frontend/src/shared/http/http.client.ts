import { ApiError } from './http.types';

type ClientRequestOptions = Omit<RequestInit, 'body'> & {
  body?: unknown;
};

export async function httpClient<T>(
  input: RequestInfo | URL,
  options: ClientRequestOptions = {},
): Promise<T> {
  const baseUrl = process.env.NEXT_PUBLIC_API_BASE_URL ?? '';
  const response = await fetch(`${baseUrl}${input}`, {
    ...options,
    headers: {
      'Content-Type': 'application/json',
      ...(options.headers ?? {}),
    },
    body: options.body ? JSON.stringify(options.body) : undefined,
    cache: options.cache ?? 'no-store',
  });

  if (!response.ok) {
    const text = await response.text();
    throw new ApiError({
      message: text || response.statusText,
      statusCode: response.status,
    });
  }

  return (await response.json()) as T;
}
