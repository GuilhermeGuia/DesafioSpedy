import type { CreateTicketDto, PagedResult, Ticket } from "../types/ticket";
import type { ApiResponse } from "./api-response";
import { http } from "./http";

export type TicketFilters = {
  Page: number;
  PageSize: number;
  Status?: string;
  Priority?: string;
  ResponsibleId?: string;
  Search?: string;
};

export async function getTickets(filters: TicketFilters) {
  const response = await http.get<ApiResponse<PagedResult<Ticket>>>("/ticket", { params: filters});

  console.log(response.data.result);

  return response.data;
}

export async function getTicketById(id: string) {
  const response = await http.get(`/ticket/${id}`);
  return response.data;
}

export async function createTicket(data: CreateTicketDto) {
  return (await http.post("/ticket", data)).data;
}

export async function updateTicket(id: string, data: Partial<Ticket>) {
  return (await http.put(`/ticket/${id}`, data)).data;
}

export async function deleteTicket(id: string) {
  return (await http.delete(`/ticket/${id}`)).data;
}

export async function updateStatus(id: string) {
  return (await http.patch(`/ticket/${id}/status`)).data;
}
