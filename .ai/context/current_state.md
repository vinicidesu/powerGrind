# Estado atual

## Implementado

- Login por e-mail e senha, com verificação BCrypt e JWT de 60 minutos.
- Endpoints administrativos autenticados para listar, consultar, criar e atualizar usuários; as ações do `UserController` exigem o papel `Admin`.
- PostgreSQL via EF Core, migrations para usuários e convites, e Docker Compose para banco local.
- Seed de administrador configurável por `Seed:AdminEmail` e `Seed:AdminPassword`.
- Geração e envio de convite por e-mail via Resend no `InviteService`.

## Parcial ou pendente

- `InviteService` não é registrado em `AddUserServices` e não há controller/endpoints de convite; portanto, o fluxo de convite não está exposto pela API.
- `CompleteInviteAsync` retorna sucesso sem validar token, expiração, senha ou criar/atualizar usuário.
- O pacote Twilio está referenciado, mas não há uso encontrado; envio por telefone permanece não implementado.
- `UserResponse` está vazio; o CRUD trabalha diretamente com a entidade `User`, que contém `PasswordHash`.
- Não foram encontrados testes, CI/CD, health checks, tratamento global de exceções nem telemetria.

## Riscos técnicos

- `appsettings.json` contém credenciais locais e credenciais padrão de administrador; não é configuração segura para produção.
- JWT exige `Jwt:SecretKey`, mas a chave não está no `appsettings.json` versionado; a execução depende de configuração externa/User Secrets.
- O seed cria o administrador quando não encontra qualquer usuário com papel `Admin`; não valida configuração vazia.

## Próximos passos sugeridos

1. Tornar o fluxo de convite completo e acessível por API.
2. Criar DTOs de resposta e validação de entradas para não expor a entidade de persistência.
3. Criar testes de autenticação, autorização e convites.
4. Externalizar segredos e adicionar automação de build/teste.

## Visão de produto incorporada

Além do fluxo de convites, o produto planeja cadastro de academias, gestão de alunos/instrutores, agenda de treinos por modalidade, acompanhamento de evolução, observações de treinador, check-ins e relatórios. Essas capacidades ainda não existem nesta codebase e foram adicionadas ao contexto como planejamento; consulte `context/product_vision.md`.
