export type ApiErrorShape = {
  message: string;
  statusCode: number;
};

export class ApiError extends Error {
  statusCode: number;

  constructor({ message, statusCode }: ApiErrorShape) {
    super(message);
    this.name = 'ApiError';
    this.statusCode = statusCode;
  }
}
