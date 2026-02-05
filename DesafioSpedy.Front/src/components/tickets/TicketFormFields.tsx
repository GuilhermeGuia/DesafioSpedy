import { TicketPriority } from '../../types/ticket';

interface TicketFormFieldsProps {
  formData: {
    title: string;
    description: string;
    priority: TicketPriority;
    responsibleUserId?: string;
  };
  errors: Record<string, string>;
//   users: User[];
  onChange: (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement | HTMLSelectElement>) => void;
  disabled?: boolean;
  readOnly?: boolean;
  titleRef?: React.RefObject<HTMLInputElement>;
}

export function TicketFormFields({
  formData,
  errors,
//   users,
  onChange,
  disabled = false,
  readOnly = false,
  titleRef
}: TicketFormFieldsProps) {
  const isDisabled = disabled || readOnly;

  return (
    <div className="space-y-4">
      {/* Título */}
      <div>
        <label htmlFor="title" className="block text-sm font-medium text-gray-700 mb-1">
          Título <span className="text-red-500">*</span>
        </label>
        <input
          ref={titleRef}
          id="title"
          name="title"
          type="text"
          value={formData.title}
          onChange={onChange}
          disabled={isDisabled}
          readOnly={readOnly}
          className={`w-full px-3 py-2 border rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 ${
            readOnly ? 'bg-gray-50 cursor-not-allowed text-gray-600' : 'bg-white'
          } ${
            errors.title ? 'border-red-500' : 'border-gray-300'
          }`}
          placeholder="Ex: Erro no login do sistema"
        />
        {errors.title && (
          <p className="mt-1 text-sm text-red-600">{errors.title}</p>
        )}
      </div>

      {/* Descrição */}
      <div>
        <label htmlFor="description" className="block text-sm font-medium text-gray-700 mb-1">
          Descrição <span className="text-red-500">*</span>
        </label>
        <textarea
          id="description"
          name="description"
          rows={4}
          value={formData.description}
          onChange={onChange}
          disabled={isDisabled}
          readOnly={readOnly}
          className={`w-full px-3 py-2 border rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 ${
            readOnly ? 'bg-gray-50 cursor-not-allowed text-gray-600' : 'bg-white'
          } ${
            errors.description ? 'border-red-500' : 'border-gray-300'
          }`}
          placeholder="Descreva o problema em detalhes..."
        />
        {errors.description && (
          <p className="mt-1 text-sm text-red-600">{errors.description}</p>
        )}
      </div>

      {/* Grid: Prioridade + Responsável */}
      <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
        {/* Prioridade */}
        <div>
          <label htmlFor="priority" className="block text-sm font-medium text-gray-700 mb-1">
            Prioridade <span className="text-red-500">*</span>
          </label>
          <select
            id="priority"
            name="priority"
            value={formData.priority}
            onChange={onChange}
            disabled={isDisabled}
            className={`w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 ${
              readOnly ? 'bg-gray-50 cursor-not-allowed text-gray-600' : 'bg-white'
            }`}
          >
            <option value={TicketPriority.Low}>Baixa</option>
            <option value={TicketPriority.Medium}>Média</option>
            <option value={TicketPriority.High}>Alta</option>
          </select>
        </div>

        {/* Responsável */}
        <div>
          <label htmlFor="responsibleUserId" className="block text-sm font-medium text-gray-700 mb-1">
            Responsável (opcional)
          </label>
          <select
            id="responsibleUserId"
            name="responsibleUserId"
            value={formData.responsibleUserId || ''}
            onChange={onChange}
            disabled={isDisabled}
            className={`w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 ${
              readOnly ? 'bg-gray-50 cursor-not-allowed text-gray-600' : 'bg-white'
            }`}
          >
            <option value="">Nenhum</option>
            {/* {users.map(user => (
              <option key={user.id} value={user.id}>
                {user.name}
              </option>
            ))} */}
          </select>
        </div>
      </div>
    </div>
  );
}