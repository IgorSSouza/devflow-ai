# 🚀 DevFlow AI

> Plataforma inteligente de gestão de tarefas com suporte a geração de planos por IA.  
> Projeto construído como laboratório técnico para evolução em arquitetura, backend, testes, observabilidade, Docker e CI/CD.

---

## 🧠 Visão do Produto

Equipes e desenvolvedores frequentemente enfrentam desafios como:

- dificuldade para transformar objetivos em tarefas executáveis;
- planejamento inconsistente;
- perda de produtividade;
- excesso de tempo gasto organizando trabalho;
- falta de visibilidade sobre progresso e execução.

## 💡 A Solução

**DevFlow AI** é uma plataforma que combina gestão de tarefas com uma camada de inteligência para transformar objetivos em planos de execução.

O usuário descreve um objetivo e o sistema:

- gera um plano inicial de tarefas;
- organiza essas tarefas em um workspace;
- permite acompanhar e concluir atividades;
- prepara a base para futuras integrações reais com provedores de IA;
- expõe uma API estruturada, testável e pronta para evolução.

---

## 🎯 Objetivo Técnico do Projeto

Este projeto foi criado para praticar engenharia de software moderna em um cenário realista, com foco em:

- Clean Architecture;
- Domain-Driven Design;
- CQRS com MediatR;
- validação com pipeline behavior;
- testes unitários e de integração;
- persistência com PostgreSQL;
- Docker e Docker Compose;
- observabilidade básica;
- CI/CD com GitHub Actions;
- publicação de imagem Docker no GitHub Container Registry;
- preparação para deploy em cloud.

O foco não é apenas criar uma API, mas desenvolver raciocínio técnico de backend e arquitetura em nível mais avançado.

---

## 🧩 Domínios do Sistema

| Domínio | Responsabilidade |
|---|---|
| **Workspace** | Organização dos contextos de trabalho/projetos |
| **Tasks** | Criação, listagem e conclusão de tarefas |
| **AI Engine** | Geração de planos a partir de objetivos |
| **Analytics** | Futuro módulo para métricas e insights |
| **Identity** | Futuro módulo de usuários e autenticação |

---

## ⚙️ Stack Tecnológica

### Backend

- .NET 8
- ASP.NET Core Web API
- Clean Architecture
- Domain-Driven Design
- CQRS com MediatR
- FluentValidation
- EF Core
- PostgreSQL
- Serilog
- Health Checks

### Testes

- xUnit
- FluentAssertions
- Moq
- Testcontainers
- PostgreSQL containerizado para testes de integração

### Infraestrutura

- Docker
- Docker Compose
- GitHub Actions
- GitHub Container Registry

### IA

- Provider fake implementado para simular geração de planos;
- arquitetura preparada para futura integração com provedores reais como Gemini, OpenAI ou outros.

---

## 🏗️ Arquitetura

O projeto segue uma arquitetura em camadas:

```text
DevFlowAI
├── DevFlowAI.API
├── DevFlowAI.Application
├── DevFlowAI.Domain
├── DevFlowAI.Infrastructure
├── DevFlowAI.Domain.Tests
├── DevFlowAI.Application.Tests
└── DevFlowAI.Infrastructure.Tests