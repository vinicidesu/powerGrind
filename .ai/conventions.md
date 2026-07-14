# Convenções observadas

- Projetos e namespaces usam `powerGrind` em minúsculas.
- Módulos agrupam controllers, DTOs, entidades, interfaces, serviços e repositórios.
- Serviços são registrados como `Scoped` por extensões de DI.
- Persistência utiliza EF Core assíncrono.
- Controllers registram exceções e retornam códigos HTTP diretamente; não existe middleware global de exceção.
