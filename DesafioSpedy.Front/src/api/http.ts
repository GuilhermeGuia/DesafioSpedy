import axios, { AxiosError, type InternalAxiosRequestConfig } from "axios";
import { storage } from "../utils/storage";

export const http = axios.create({
  baseURL: import.meta.env.VITE_API_URL ?? "https://localhost:5001/api",
  headers: {
    'Content-Type': 'application/json'
  }
});

http.interceptors.request.use(
  (config: InternalAxiosRequestConfig) => {
    const token = storage.getToken();
    
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    
    return config;
  },
  (error: AxiosError) => {
    return Promise.reject(error);
  } 
);

http.interceptors.response.use(
  response => response,
  error => {
    if (error.response?.data?.errors?.length) {
      return Promise.reject(
        new Error(error.response.data.errors[0])
      );
    }

    if (!error.response) {
      return Promise.reject(
        new Error("Servidor indisponível")
      );
    }

    return Promise.reject(
      new Error("Erro inesperado")
    );
  }
);