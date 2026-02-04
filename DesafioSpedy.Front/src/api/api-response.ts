export interface ApiResponse<T> {
  result: T;
  success: boolean;
  errors: string[] | null;
}
