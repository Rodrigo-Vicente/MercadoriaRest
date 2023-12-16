Arquitetura do Sistema:

Tecnologias Utilizadas:

Backend: ASP.NET Core (C#)
Frontend: React.js
Banco de Dados: SQL
Funcionalidades:

Backend (ASP.NET Core):
Gerenciamento de Mercadorias:

Criação, leitura, atualização e exclusão (CRUD) das mercadorias.
Campos a serem salvos: nome, número de registro, fabricante, tipo e descrição.
Gerenciamento de Entrada e Saída de Mercadorias:

Criação de entradas e saídas de mercadorias.
Campos a serem salvos: quantidade, data e hora, local e referência à mercadoria.
Validação de Dados no Servidor:

Aplicar validações adicionais nos dados recebidos do cliente.
Frontend (React.js):
Interface para Gerenciamento de Mercadorias:

Formulário para adicionar/editar mercadorias.
Validação de dados no cliente antes do envio para o servidor.
Interface para Entrada e Saída de Mercadorias:

Formulário para registrar entradas e saídas.
Dropdowns para seleção de mercadorias já cadastradas.
Visualização em Gráfico:

Página para visualização de entradas e saídas por mês, em formato gráfico.
Exportar Relatório Mensal em PDF:

Função para gerar e exportar relatórios mensais com todas as entradas e saídas.
Banco de Dados (SQL):
Tabelas:
Tabela de Mercadorias: nome, número de registro, fabricante, tipo, descrição.
Tabela de Entrada: quantidade, data e hora, local, referência à mercadoria.
Tabela de Saída: quantidade, data e hora, local, referência à mercadoria.
