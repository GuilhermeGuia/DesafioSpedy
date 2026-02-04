import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { useState } from "react";
import { Eye, EyeClosed } from "lucide-react";
import { useNavigate } from "react-router-dom";
import { useLogin } from "../../queries/useLogin";
import { useAuth } from "../../auth/useAuth";
import { loginSchema, type LoginFormData } from "../../schemas/login.schema";
import { ErrorBox } from "../../components/ErrorBox";
import { FormInput } from "../../components/FormInput";

export function Login() {
  const [passwordVisible, setPasswordVisible] = useState(false);
  const loginMutation = useLogin();
  const { login } = useAuth();
  const navigate = useNavigate();

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<LoginFormData>({
    resolver: zodResolver(loginSchema),
  });

  function onSubmit(data: LoginFormData) {
    loginMutation.mutate(data, {
      onSuccess: (response) => {
        login(response.result.token);
        navigate("/tickets", { replace: true });
      }
    });
  }

  return (
    <div className="grid min-h-screen">
      <div className="flex items-center justify-center">
        <div className="min-w-[450px]">
          <ErrorBox message={loginMutation.error?.message as string} />

          <div className="text-blue-500 font-bold text-4xl mb-5">
            <h1>SpedyTicket</h1>
          </div>

          <form onSubmit={handleSubmit(onSubmit)}>
            <FormInput
              label="Email"
              type="email"
              register={register("email")}
              error={errors.email}
            />

            <div className="mb-5">
              <label className="block font-bold text-lg mb-2">Senha</label>

              <div className="relative">
                <input
                  type={passwordVisible ? "text" : "password"}
                  {...register("password")}
                  className="w-full p-3 rounded-md border text-base"
                />
                <button
                  type="button"
                  onClick={() => setPasswordVisible(!passwordVisible)}
                  className="absolute right-3 top-3 text-gray-500"
                >
                  {passwordVisible ? <EyeClosed className="text-gray-500"/> : <Eye className="text-gray-500"/>}
                </button>
              </div>

              {errors.password && (
                <p className="text-red-500 mt-1">
                  {errors.password.message}
                </p>
              )}
            </div>

            <button
              type="submit"
              disabled={loginMutation.isPending}
              className="w-full bg-blue-500 text-white font-bold text-lg py-3 rounded-md mt-5 disabled:opacity-60 cursor-pointer"
            >
              {loginMutation.isPending ? "Entrando..." : "Acessar"}
            </button>
          </form>
        </div>
      </div>
    </div>
  );
}
