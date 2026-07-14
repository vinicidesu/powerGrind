# Registro de decisões

| Situação | Decisão vigente | Evidência |
|---|---|---|
| Persistência local | PostgreSQL em Docker Compose | `docker-compose.yml` |
| Autenticação | Bearer JWT com chave simétrica | `Program.cs`, `TokenService.cs` |
| Entrega de e-mail | Resend configurado para convites | `Program.cs`, `InviteService.cs` |
| Canal SMS | Não decidido/implementado | pacote Twilio sem uso encontrado |
