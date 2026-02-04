import { useMutation } from "@tanstack/react-query";
import { authenticated } from "../api/auth.services";

export function useLogin() {
  return useMutation({
    mutationFn: authenticated,
  });
}
