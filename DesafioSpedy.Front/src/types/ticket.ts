export type TicketPriority = "Low" | "Medium" | "High";
export type TicketStatus =
  | "Open"
  | "InProgress"
  | "Waiting"
  | "Done";

export type Ticket = {
  id: string;
  title: string;
  description: string;
  priority: TicketPriority;
  status: TicketStatus;
  responsibleUserId?: string;
  createdAt: string;
};
