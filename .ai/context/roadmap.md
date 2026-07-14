# Roadmap inicial

## Curto prazo

- Finalizar convites: registro no DI, endpoints administrativos, validação de destinatário/papel, expiração e aceite seguro.
- Definir DTOs e validação para usuários e autenticação.
- Documentar configuração de desenvolvimento e mover segredos para mecanismos apropriados.

## Médio prazo

- Cobrir login, autorização administrativa e convites com testes automatizados.
- Padronizar respostas de erro e logs estruturados.
- Adicionar pipeline de build/teste e instruções de operação local.

## Longo prazo

- Evoluir permissões de papéis para um modelo compatível com requisitos reais do produto.
- Integrar notificações por e-mail/SMS após definição de regras de produto e canais.
- Integrar o contexto de eventos de luta quando o contrato entre a API e `PowerGrind.FightEvents` for definido.

## Evolução de produto planejada

- Modelar academia, aluno, instrutor e vínculo a modalidades antes de iniciar treinos ou check-ins.
- Implementar agenda de treinos, evolução e observações após definição de autorização e privacidade.
- Avaliar check-ins, Wellhub/TotalPass, relatórios e IA apenas com contratos e dados de origem definidos.
