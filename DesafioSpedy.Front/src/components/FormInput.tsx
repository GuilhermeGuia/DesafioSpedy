import type { FieldError } from "react-hook-form";

interface Props {
  label: string;
  type?: string;
  error?: FieldError;
  register: any;
}

export function FormInput({ label, type = "text", error, register }: Props) {
  return (
    <div className="mb-5">
      <label className="block font-bold text-lg mb-2">{label}</label>
      <input
        type={type}
        {...register}
        className="w-full p-3 rounded-md border text-base"
      />
      {error && <p className="text-red-500 mt-1">{error.message}</p>}
    </div>
  );
}