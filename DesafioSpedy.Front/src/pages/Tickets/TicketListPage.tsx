import { useState } from "react";
import { useTicketsQuery } from "../../queries/ticket/useTicketsQuery";

export function TicketListPage() {
  const [filters, setFilters] = useState({
    page: 1,
    pageSize: 10
  });

  const { data, isLoading, isError } = useTicketsQuery(filters);

  if (isLoading) return <p>Carregando...</p>;
  if (isError) return <p>Erro ao carregar tickets</p>;
  if (!data.items.length) return <p>Nenhum ticket encontrado</p>;

  return (
    <>
        <h1>TICKETS</h1>
    </>
  );
}
