# ADR 0002 — Resend para entrega de convites por e-mail

## Contexto

O host registra Resend usando `Resend:ApiKey`; `InviteService` cria um convite persistido e chama `EmailSendAsync` quando recebe e-mail.

## Decisão

Usar Resend como adaptador de entrega de convites por e-mail nesta fase.

## Consequências

O serviço requer uma chave externa e a entrega ainda não é alcançável pela API porque o serviço não está registrado/exposto. Telefone/SMS permanece apenas uma possibilidade: Twilio está referenciado, sem implementação ativa.

## Trade-offs

O fluxo inicia simples, mas precisa de tratamento de falha, reenvio, auditoria e definição de canal antes de ser considerado pronto para produção.
