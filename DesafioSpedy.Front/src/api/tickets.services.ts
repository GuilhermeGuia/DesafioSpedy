import type { Ticket } from "../types/ticket";
import { http } from "./http";

export type TicketFilters = {
  page: number;
  pageSize: number;
  status?: string;
  priority?: string;
  responsibleId?: string;
  search?: string;
};

export async function getTickets(filters: TicketFilters) {
  const response = await http.get("/tickets", { params: filters });
  return response.data;
}

export async function getTicketById(id: string) {
  const response = await http.get(`/tickets/${id}`);
  return response.data;
}

export async function createTicket(data: Partial<Ticket>) {
  return (await http.post("/tickets", data)).data;
}

export async function updateTicket(id: string, data: Partial<Ticket>) {
  return (await http.put(`/tickets/${id}`, data)).data;
}

export async function deleteTicket(id: string) {
  return (await http.delete(`/tickets/${id}`)).data;
}

export async function updateStatus(id: string) {
  return (await http.patch(`/tickets/${id}/status`)).data;
}
