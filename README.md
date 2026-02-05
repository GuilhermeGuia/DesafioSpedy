# Projeto – Sistema de Tickets

Este projeto foi desenvolvido como parte de um **teste técnico**, com foco em **organização, arquitetura limpa, boas práticas em .NET e domínio bem definido**, priorizando a consistência do back-end e regras de negócio.

---

## Arquitetura e Organização

O projeto foi estruturado em **camadas bem definidas**, seguindo princípios de separação de responsabilidades:

- **Api** → Exposição dos endpoints, autenticação e configuração da aplicação  
- **Application** → Casos de uso, DTOs, validações de entrada e orquestração  
- **Domain** → Regras de negócio, entidades, validações de domínio e State Pattern  
- **Infrastructure** → Acesso a dados, EF Core, migrations, seed e integrações  
- **Exceptions** → Exceções customizadas e tratamento centralizado  
- **Front** → Camada de front-end (parcialmente implementada)

Essa separação facilita manutenção, testes e evolução do sistema.

---

## Controle de Status – State Pattern

O avanço de status dos tickets foi implementado utilizando o **State Pattern diretamente no domínio**, garantindo que:

- Apenas transições válidas sejam permitidas  
- As regras de negócio fiquem centralizadas no domínio  
- O sistema evite condicionais espalhadas (`if/else`)

Essa abordagem torna o fluxo de status mais seguro, extensível e alinhado a boas práticas de DDD.

---

## Validações

### 🔹 Validações de Entrada
- Implementadas com **FluentValidation**
- Aplicadas nos DTOs da camada **Application**
- Seguem boas práticas do ecossistema .NET

### 🔹 Validações de Domínio
- Regras críticas implementadas diretamente no **Domain**
- Exceções personalizadas para garantir integridade do negócio

## Autenticação
### Usuário padrão para acesso:
- **Email:** `admin@admin.com`  
- **Senha:** `123456`
---
O projeto conta com **Docker Compose** para facilitar a execução local:

- API .NET
- Banco de dados

### Executar o backend do projeto:
```bash
docker-compose up -d
```
### Executar o Front-end

1. Acesse o diretório do front-end:
```bash
cd DesafioSpedy.Front

npm install

npm run ddev
```
