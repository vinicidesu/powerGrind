# Sprint 1 proposta — Convites utilizáveis e seguros

## Objetivo

Transformar a infraestrutura parcial de convites em um fluxo acessível, validado e seguro.

## Itens

- Registrar `IInviteService`/`InviteService` e expor operações administrativas necessárias.
- Implementar aceite de convite, expiração e criação/atualização de usuário.
- Definir contratos HTTP e validação.
- Cobrir fluxo por testes e documentar configuração Resend.

## Riscos e dependências

- Regras de quem pode convidar e quais papéis existem ainda não estão explicitadas.
- É necessário decidir se telefone/SMS fará parte do primeiro fluxo.
- Chaves e remetente autorizados no Resend são dependências externas.
