import axios from "axios";

export const http = axios.create({
  baseURL: "https://localhost:52831/api",
});

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