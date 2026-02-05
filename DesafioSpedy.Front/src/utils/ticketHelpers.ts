import { TicketStatus, TicketPriority } from '../types/ticket';

export const getStatusLabel = (status: TicketStatus): string => {
  const labels = {
    [TicketStatus.Open]: 'Aberto',
    [TicketStatus.InProgress]: 'Em Progresso',
    [TicketStatus.Finished]: 'Finalizado',
  };

  return labels[status] || 'Desconhecido';
};

export const getStatusColor = (status: TicketStatus): string => {
  const colors = {
    [TicketStatus.Open]: 'bg-blue-100 text-blue-800',
    [TicketStatus.InProgress]: 'bg-yellow-100 text-yellow-800',
    [TicketStatus.Finished]: 'bg-green-100 text-green-800',
  };
  return colors[status] || 'bg-gray-100 text-gray-800';
};

export const getPriorityLabel = (priority: TicketPriority): string => {
  const labels = {
    [TicketPriority.Low]: 'Baixa',
    [TicketPriority.Medium]: 'Média',
    [TicketPriority.High]: 'Alta',
  };
  return labels[priority] || 'Desconhecida';
};

export const getPriorityColor = (priority: TicketPriority): string => {
  const colors = {
    [TicketPriority.Low]: 'bg-gray-100 text-gray-800',
    [TicketPriority.Medium]: 'bg-blue-100 text-blue-800',
    [TicketPriority.High]: 'bg-orange-100 text-orange-800',
  };
  return colors[priority] || 'bg-gray-100 text-gray-800';
};

export const formatDate = (dateString: string): string => {
  const date = new Date(dateString);
  return new Intl.DateTimeFormat('pt-BR', {
    day: '2-digit',
    month: '2-digit',
    year: 'numeric',
    hour: '2-digit',
    minute: '2-digit'
  }).format(date);
};