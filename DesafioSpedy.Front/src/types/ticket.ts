
export const TicketStatus = {
  Open: 1,
  InProgress: 2,
  Finished: 3,
} as const;

export type TicketStatus = typeof TicketStatus[keyof typeof TicketStatus];

export const TicketPriority = {
  Low: 1,
  Medium: 2,
  High: 3,
} as const;

export type TicketPriority = typeof TicketPriority[keyof typeof TicketPriority];

export interface Ticket {
  id: string;
  title: string;
  description: string;
  status: TicketStatus;
  priority: TicketPriority;
  createdAt: string;
  updatedAt?: string;
  finishedAt?: string;
  responsableUserId: string;
  responsableName?: string;
  creatorUserId: string;
  creatorName?: string;
}

export interface CreateTicketDto {
  title: string;
  description: string;
  priority: TicketPriority;
  responsibleUserId?: string;
}

export interface TicketFilters {
  page: number;
  pageSize: number;
  status?: string;
  priority?: string;
  responsableUserId?: string;
  search?: string;
}

export interface PagedResult<T> {
  items: T[];
  total: number;
}

export interface User {
  id: string;
  name: string;
  email: string;
}