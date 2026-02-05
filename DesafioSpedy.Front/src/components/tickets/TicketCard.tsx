import { getStatusLabel, getStatusColor, getPriorityLabel, getPriorityColor, formatDate } from '../../utils/ticketHelpers';
import { useNavigate } from 'react-router-dom';
import { Badge } from '../ui/Badge';
import type { Ticket } from '../../types/ticket';

interface TicketCardProps {
  ticket: Ticket;
}

export function TicketCard({ ticket }: TicketCardProps) {
  const navigate = useNavigate();

  return (
    <div 
      onClick={() => navigate(`/tickets/${ticket.id}`)}
      className="bg-white rounded-lg shadow hover:shadow-md transition-shadow cursor-pointer border border-gray-200 p-4"
    >
      <div className="flex items-start justify-between mb-3">
        <h3 className="text-lg font-semibold text-gray-900 flex-1 mr-3">
          {ticket.title}
        </h3>
        <Badge variant={getPriorityColor(ticket.priority)}>
          {getPriorityLabel(ticket.priority)}
        </Badge>
      </div>

      <p className="text-gray-600 text-sm mb-4 line-clamp-2">
        {ticket.description}
      </p>

      <div className="flex items-center justify-between text-sm">
        <div className="flex items-center gap-3">
          <Badge variant={getStatusColor(ticket.status)}>
            {getStatusLabel(ticket.status)}
          </Badge>
          
          {ticket.responsableName && (
            <span className="text-gray-500">
              👤 {ticket.responsableName}
            </span>
          )}
        </div>

        <span className="text-gray-400 text-xs">
          {formatDate(ticket.createdAt)}
        </span>
      </div>
    </div>
  );
}