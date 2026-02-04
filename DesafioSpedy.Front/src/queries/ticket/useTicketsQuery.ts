import { useQuery } from "@tanstack/react-query";
import { getTickets, type TicketFilters } from "../../api/tickets.services";

export function useTicketsQuery(filters: TicketFilters) {
  return useQuery({
    queryKey: ["tickets", filters],
    queryFn: () => getTickets(filters)
  });
}
