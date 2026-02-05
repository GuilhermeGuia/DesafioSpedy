import { CircleX } from "lucide-react";

interface Props {
  message: string;
}

export function ErrorBox({ message }: Props) {
  if (!message) return null;

  return (
    <div className="bg-red-50 p-4 flex items-center gap-4 rounded-md mb-5 text-lg">
      <CircleX />
      <span>{message}</span>
    </div>
  );
}
