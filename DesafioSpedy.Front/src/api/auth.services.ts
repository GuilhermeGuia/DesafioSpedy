import type { ApiResponse } from "./api-response";
import { http } from "./http";

interface LoginResult {
  token: string;
}

export async function authenticated(data: { email: string; password: string }) {
  const response = await http.post<ApiResponse<LoginResult>>(
    "/auth/login",
    data
  );
  
  return response.data;
}
