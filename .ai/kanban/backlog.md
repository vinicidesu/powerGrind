# Backlog

- [ ] Como administrador, quero enviar convites para que novos integrantes possam entrar na plataforma.
  - Aceite: endpoint protegido cria convite, valida destinatário/papel, entrega pelo canal configurado e não expõe token indevidamente.
- [ ] Como convidado, quero concluir o cadastro com convite válido para obter acesso.
  - Aceite: token é localizado, não expirado e não utilizado; senha é armazenada com hash e convite recebe data de aceite.
- [ ] Como administrador, quero respostas de usuários sem informações sensíveis para integrar clientes de forma segura.
  - Aceite: DTOs de resposta não retornam `PasswordHash`; entradas possuem validação e erros previsíveis.
- [ ] Como equipe, quero testes e pipeline para detectar regressões antes de publicar.
  - Aceite: build e testes executam automaticamente e falham em regressões conhecidas.

- [ ] Como academia, quero cadastrar minha organização para administrar pessoas e operações no PowerGrind.
  - Aceite: regras de cadastro, propriedade e acesso administrativo são definidas antes da implementação.
- [ ] Como treinador, quero programar treinos por modalidade para orientar os alunos.
  - Aceite: treino possui agenda, modalidade, descrição e regras claras de visualização pelo aluno.
- [ ] Como aluno, quero registrar peso, altura e anotações para acompanhar minha evolução.
  - Aceite: registros possuem data, acesso restrito e suporte aos períodos de acompanhamento definidos pelo produto.
- [ ] Como academia ou instrutor, quero visualizar e filtrar check-ins para acompanhar presença.
  - Aceite: fluxo manual é definido antes de avaliar integrações Wellhub/TotalPass.
