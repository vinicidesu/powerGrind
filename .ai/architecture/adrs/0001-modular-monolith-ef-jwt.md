# ADR 0001 — Monólito modular com EF Core, PostgreSQL e JWT

## Contexto

O repositório contém uma única ASP.NET Core Web API, módulos de autenticação e usuários, `AppDbContext`, migrations EF Core e Docker Compose para PostgreSQL.

## Decisão

Organizar funcionalidades em módulos internos e usar EF Core/Npgsql para persistência. Autenticar requisições protegidas com Bearer JWT; gerar tokens a partir de claims de identificador, e-mail e papel.

## Consequências

O desenvolvimento e a operação local permanecem simples. A separação entre módulos depende de convenções internas e o modelo atual de autorização é baseado em strings de papel.

## Trade-offs

Não há isolamento de processo entre domínios nem mecanismo de eventos. Isso reduz custo inicial, mas futuras integrações — como eventos de luta — exigirão contrato e estratégia explícitos.
