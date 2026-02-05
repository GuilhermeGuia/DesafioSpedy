import { useState, useEffect, useRef } from 'react';
import { TicketPriority, type CreateTicketDto, type User } from '../../types/ticket';
import { createTicket } from '../../api/tickets.services';

interface CreateTicketModalProps {
  isOpen: boolean;
  onClose: () => void;
  onSuccess: () => void;
  users?: User[];
}

export function CreateTicketModal({ isOpen, onClose, onSuccess, users }: CreateTicketModalProps) {
  const [formData, setFormData] = useState<CreateTicketDto>({
    title: '',
    description: '',
    priority: TicketPriority.Medium,
    responsibleUserId: undefined
  });

  const [errors, setErrors] = useState<Record<string, string>>({});
  const [isSubmitting, setIsSubmitting] = useState(false);
  const titleInputRef = useRef<HTMLInputElement>(null);

  useEffect(() => {
    if (isOpen) {
      setTimeout(() => titleInputRef.current?.focus(), 100);
    }
  }, [isOpen]);

  const validate = (): boolean => {
    const newErrors: Record<string, string> = {};

    if (!formData.title.trim()) {
      newErrors.title = 'Título é obrigatório';
    } else if (formData.title.length < 3) {
      newErrors.title = 'Título deve ter no mínimo 3 caracteres';
    }

    if (!formData.description.trim()) {
      newErrors.description = 'Descrição é obrigatória';
    } else if (formData.description.length < 10) {
      newErrors.description = 'Descrição deve ter no mínimo 10 caracteres';
    }

    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!validate()) return;

    setIsSubmitting(true);

    try {
      await createTicket(formData);
      onSuccess();
      onClose();
    } catch (error: any) {
      setErrors({ submit: error.message || 'Erro ao criar ticket' });
    } finally {
      setIsSubmitting(false);
    }
  };

  if (!isOpen) return null;

  return (
    <>
      <div className="fixed inset-0 bg-black bg-opacity-50 z-40" onClick={onClose} />
      
      <div className="fixed inset-0 z-50 flex items-center justify-center p-4">
        <div className="bg-white rounded-lg shadow-xl max-w-2xl w-full max-h-[90vh] overflow-y-auto">
          <div className="flex items-center justify-between p-6 border-b">
            <h2 className="text-xl font-semibold text-gray-900">Novo Ticket</h2>
            <button onClick={onClose} className="text-gray-400 hover:text-gray-600">
              <svg className="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M6 18L18 6M6 6l12 12" />
              </svg>
            </button>
          </div>

          <form onSubmit={handleSubmit} className="p-6">
            {/* <TicketFormFields
              formData={formData}
              errors={errors}
            //   users={users}
              onChange={handleChange}
              disabled={isSubmitting}
            /> */}

            {errors.submit && (
              <div className="mt-4 bg-red-50 border border-red-200 rounded-md p-3">
                <p className="text-sm text-red-600">{errors.submit}</p>
              </div>
            )}

            <div className="flex justify-end gap-3 pt-4 mt-6 border-t">
              <button
                type="button"
                onClick={onClose}
                disabled={isSubmitting}
                className="px-4 py-2 text-sm font-medium text-gray-700 bg-white border border-gray-300 rounded-md hover:bg-gray-50"
              >
                Cancelar
              </button>
              <button
                type="submit"
                disabled={isSubmitting}
                className="px-4 py-2 text-sm font-medium text-white bg-blue-600 rounded-md hover:bg-blue-700"
              >
                {isSubmitting ? 'Criando...' : 'Criar Ticket'}
              </button>
            </div>
          </form>
        </div>
      </div>
    </>
  );
}