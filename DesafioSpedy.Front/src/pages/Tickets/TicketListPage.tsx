import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useTicketsQuery } from "../../queries/ticket/useTicketsQuery";
import { TicketFilters } from "../../components/tickets/TicketFilters";
import { TicketCard } from "../../components/tickets/TicketCard";
import { TicketPagination } from "../../components/tickets/TicketPagination";
import type { Ticket } from "../../types/ticket";
import { TriangleAlert } from "lucide-react";
import { CreateTicketModal } from "../../components/tickets/CreateTicketModal";

export function TicketListPage() {
  const [isCreateModalOpen, setIsCreateModalOpen] = useState(false);

  const [filters, setFilters] = useState({
    Page: 1,
    PageSize: 10,
    Search: '',
    Status: '',
    Priority: '',
    ResponsableUserId: ''
  });

  const { data, isLoading, isError } = useTicketsQuery(filters);

  const handleFilterChange = (key: string, value: string) => {
    setFilters(prev => ({
      ...prev,
      [key]: value,
      page: 1
    }));
  };

  const handleClearFilters = () => {
    setFilters({
      Page: 1,
      PageSize: 10,
      Search: '',
      Status: '',
      Priority: '',
      ResponsableUserId: ''
    });
  };

  const handlePageChange = (page: number) => {
    setFilters(prev => ({ ...prev, page }));
  };

  const handleOpenCreateModal = () => {
    setIsCreateModalOpen(true);
  };

  const handleTicketCreated = () => {
    console.log('Ticket criado! Recarregar lista...');
  };

  if (isLoading) {
    return (
      <div className="min-h-screen bg-gray-50 flex items-center justify-center">
        <div className="text-center">
          <div className="rounded-full h-12 w-12 border-b-2 border-blue-600 mx-auto mb-4"></div>
          <p className="text-gray-600">Carregando tickets...</p>
        </div>
      </div>
    );
  }

  if (isError) {
    return (
      <div className="min-h-screen bg-gray-50 flex items-center justify-center">
        <div className="bg-white rounded-lg shadow-md p-8 max-w-md text-center">
          <div className="text-red-500 text-5xl mb-4">
            <TriangleAlert />
          </div>
          <h2 className="text-2xl font-bold text-gray-900 mb-2">Erro ao carregar tickets</h2>
        </div>
      </div>
    );
  }

  return (
    <div className="min-h-screen bg-gray-50">
      <div className="bg-white shadow">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-6">
          <div className="flex items-center justify-between">
            <h1 className="text-3xl font-bold text-gray-900">Tickets</h1>
            <button
              onClick={handleOpenCreateModal}
              className="bg-blue-600 text-white px-4 py-2 rounded-md hover:bg-blue-700 transition-colors flex items-center gap-2"
            >
              <span className="text-xl">+</span>
              Novo Ticket
            </button>
          </div>
        </div>
      </div>

      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-8">
        <TicketFilters
          filters={filters}
          onFilterChange={handleFilterChange}
          onClearFilters={handleClearFilters}
        />

        {!data?.result.items?.length ? (
          <div className="bg-white rounded-lg shadow p-12 text-center">
            <div className="text-gray-400 text-6xl mb-4">📋</div>
            <h3 className="text-xl font-semibold text-gray-900 mb-2">
              Nenhum ticket encontrado
            </h3>
            <p className="text-gray-600 mb-6">
              {filters.Search || filters.Status || filters.Priority
                ? 'Tente ajustar os filtros para encontrar tickets.'
                : 'Comece criando seu primeiro ticket.'}
            </p>
            {(filters.Search || filters.Status || filters.Priority) && (
              <button
                onClick={handleClearFilters}
                className="text-blue-600 hover:text-blue-800 font-medium"
              >
                Limpar filtros
              </button>
            )}
          </div>
        ) : (
          <>
            <div className="grid gap-4 mb-6">
              {data.result.items.map((ticket: Ticket) => (
                <TicketCard key={ticket.id} ticket={ticket} />
              ))}
            </div>

            <TicketPagination
              currentPage={filters.Page}
              pageSize={filters.PageSize}
              total={data.result.total}
              onPageChange={handlePageChange}
            />
          </>
        )}


        <CreateTicketModal
          isOpen={isCreateModalOpen}
          onClose={() => setIsCreateModalOpen(false)}
          onSuccess={handleTicketCreated}
        />

      </div>
    </div>
  );
}