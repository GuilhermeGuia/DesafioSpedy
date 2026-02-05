import { useEffect, useState } from 'react';
import { TicketStatus, TicketPriority } from '../../types/ticket';
import { useDebounce } from '../../hooks/useDebounce';

interface TicketFiltersProps {
  filters: {
    Search: string;
    Status: string;
    Priority: string;
  };
  onFilterChange: (key: string, value: string) => void;
  onClearFilters: () => void;
}

export function TicketFilters({ filters, onFilterChange, onClearFilters }: TicketFiltersProps) {
  const [searchInput, setSearchInput] = useState(filters.Search);
  
  const debouncedSearch = useDebounce(searchInput, 500);

  useEffect(() => {
    if (debouncedSearch !== filters.Search) {
      onFilterChange('Search', debouncedSearch);
    }
  }, [debouncedSearch]);

  useEffect(() => {
    if (filters.Search === '' && searchInput !== '') {
      setSearchInput('');
    }
  }, [filters.Search]);

  const hasActiveFilters = filters.Search || filters.Status || filters.Priority;

  return (
    <div className="bg-white rounded-lg shadow p-4 mb-6">
      <div className="grid grid-cols-1 md:grid-cols-4 gap-4">
        <div className="md:col-span-2">
          <label htmlFor="Search" className="block text-sm font-medium text-gray-700 mb-1">
            Buscar
          </label>
          <input
            id="Search"
            type="text"
            placeholder="Buscar por título ou descrição..."
            value={searchInput}
            onChange={(e) => setSearchInput(e.target.value)}
            className="w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500"
          />
        </div>

        <div>
          <label htmlFor="Status" className="block text-sm font-medium text-gray-700 mb-1">
            Status
          </label>
          <select
            id="Status"
            value={filters.Status}
            onChange={(e) => onFilterChange('Status', e.target.value)}
            className="w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500"
          >
            <option value="">Todos</option>
            <option value={TicketStatus.Open}>Aberto</option>
            <option value={TicketStatus.InProgress}>Em Progresso</option>
            <option value={TicketStatus.Finished}>Finalizado</option>
          </select>
        </div>

        <div>
          <label htmlFor="Priority" className="block text-sm font-medium text-gray-700 mb-1">
            Prioridade
          </label>
          <select
            id="Priority"
            value={filters.Priority}
            onChange={(e) => onFilterChange('Priority', e.target.value)}
            className="w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500"
          >
            <option value="">Todas</option>
            <option value={TicketPriority.Low}>Baixa</option>
            <option value={TicketPriority.Medium}>Média</option>
            <option value={TicketPriority.High}>Alta</option>
          </select>
        </div>
      </div>

      {hasActiveFilters && (
        <div className="mt-3 flex justify-end">
          <button
            onClick={onClearFilters}
            className="text-sm text-blue-600 hover:text-blue-800 font-medium"
          >
            Limpar filtros
          </button>
        </div>
      )}
    </div>
  );
}