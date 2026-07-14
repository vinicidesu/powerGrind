# Projeto: powerGrind

## Visão

O repositório contém uma Web API para o produto PowerGrind. A implementação atual cobre autenticação e administração de usuários; a existência de um SaaS voltado a academias de luta aparece no contexto histórico do projeto, mas os domínios de academias, atletas e competições não estão implementados nesta codebase.

## Stack

| Área | Implementação observada |
|---|---|
| Runtime/API | .NET 10 e ASP.NET Core controllers |
| Persistência | Entity Framework Core 10 + Npgsql/PostgreSQL |
| Autenticação | JWT Bearer assinado com chave simétrica |
| Senhas | BCrypt |
| Documentação HTTP | Swagger em Development |
| E-mail | Resend registrado no host; uso no serviço de convites |
| Ambiente local | Docker Compose com PostgreSQL 16 |

## Organização

- `Modules/Authentication`: endpoint de login, serviço de autenticação e geração de token.
- `Modules/Users`: entidade, DTOs, serviço, repositório e serviço de convites.
- `Shared`: `AppDbContext`, seed de administrador e extensões de DI.
- `Migrations`: schema EF Core para `Users` e `Invites`.

## Convenções observadas

Controllers dependem de interfaces de serviço; o serviço de usuários depende de repositório; o repositório usa o `AppDbContext`. As dependências são registradas em extensões de `IServiceCollection`. Operações de persistência são assíncronas e controllers usam `ILogger<T>`.

## Visão ampliada de produto

O contexto fornecido pelo produto define o PowerGrind como SaaS para academias de luta. A academia deverá registrar alunos e convidá-los por e-mail; treinadores deverão programar treinos por modalidade, registrar descrições e observações sobre alunos; alunos deverão acompanhar treinos, peso, altura e anotações de evolução. Check-ins, relatórios/gráficos e possíveis integrações Wellhub/TotalPass ou recursos de IA são planejados, não implementados. Consulte `context/product_vision.md`.
