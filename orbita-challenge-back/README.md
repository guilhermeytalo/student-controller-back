
# 🪐 Projeto Orbita(Outdated)

Bem-vindo ao projeto Orbita! Este sistema foi desenvolvido para facilitar o gerenciamento de alunos por meio de uma interface web eficiente e moderna.

## 📚 **Descrição do Projeto**

O objetivo do projeto é permitir que usuários administrativos de instituições possam gerenciar o cadastro de alunos, incluindo a criação, edição, visualização e exclusão de registros.

### Principais Funcionalidades:
- Cadastro de novos alunos.
- Edição de informações de alunos existentes.
- Exclusão de registros de alunos.
- Busca na lista de alunos.
- Listagem detalhada de alunos cadastrados.

## 🛠️ **Tecnologias Utilizadas**

**Frontend**:
- **Framework**: Vue 3
- **Bibliotecas**:
    - Vuetify (UI Component Library)
    - Axios (HTTP Client)
    - Vuelidate (Validação de Formulários)

**Backend**:
- **Linguagem**: .NET (C#)
- **Banco de Dados**: PostgreSQL
- **Contêinerização**: Docker

## 🏗️ **Arquitetura do Projeto**

### **Backend**
- Estruturado seguindo o padrão **MVC**:
    - **Controllers**: Responsáveis por processar as requisições.
    - **Models**: Representação dos dados e regras de negócio.
    - **Services**: Contêm a lógica de negócios.
    - **Data**: Conexão e configuração do banco de dados.

### **Frontend**
- Modularizado para melhor organização e manutenção do código:
    - **Layouts**: Estruturas de página.
    - **Pages**: Componentes principais de telas.
    - **Stores**: Gerenciamento de estado (com Pinia ou Vuex).
    - **Plugins**: Configurações e integrações.
    - **Utils**: Funções reutilizáveis e auxiliares.

## 🚀 **Como Configurar o Ambiente**

### Pré-requisitos:
- **Node.js** instalado.
- **Docker** configurado.

### Instruções de Instalação:
2. Instale as dependências do **frontend**:
   ```bash
   cd orbita-challenge-front
   npm install
   ```

3. Configure o **backend**:
   ```bash
   cd orbita-challenge-back/orbita-challenge-back
   docker compose build
   ```

4. Criação da Tabela no **Banco de Dados**

   Com o docker executando(`docker compose up`) na mesma pasta do backend, é necessário configurar o banco de dados PostgreSQL e criar a tabela `students`. Siga as instruções abaixo:

   #### Passo 1: Acesse o banco de dados no container Docker
    ```bash
        docker exec -it db psql -U postgres
    ```

   Após isso, você verá uma tela semelhante a esta:
    ```
        psql (12.21 (Debian 12.21-1.pgdg120+1))
        Type "help" for help.
        postgres=#
    ```

   #### Passo 2: Verifique se a tabela já existe
   No terminal do PostgreSQL, execute o seguinte comando:
    ```
        \dt
    ```

   Caso a tabela `students` não exista, você precisará criá-la.

   #### Passo 3: Crie a tabela manualmente
   No terminal do PostgreSQL, copie e cole o comando abaixo para criar a tabela:
    ```sql
            CREATE TABLE students (
            id SERIAL PRIMARY KEY,
            academic_register VARCHAR(10) UNIQUE NOT NULL,
            name VARCHAR(255) NOT NULL,
            email VARCHAR(255) NOT NULL,
            cpf VARCHAR(14) NOT NULL UNIQUE
        );
    ```
   #### Passo 4: Verifique novamente se a tabela foi criada
   Para confirmar, execute o comando abaixo:
    ```
        \dt
    ```
   Agora, você deverá ver uma saída semelhante a esta:

    ```
                List of relations
        Schema |   Name   | Type  |  Owner   
        --------+----------+-------+----------
        public | students | table | postgres
        (1 row)
    ```
   Pronto! O banco de dados está configurado e pronto para uso pelo backend.

## ▶️ **Como Executar o Projeto**

### Frontend:
1. Na pasta `orbita-challenge-front`, inicie o servidor:
   ```node
    npm run dev
   ```

### Backend:
1. Na pasta `orbita-challenge-back/orbita-challenge-back`, rode o backend:
   ```bash
   dotnet run
   ```

2. Suba os contêineres do Docker:
   ```bash
   docker compose up
   ```
3. Através do swagger tente executar a rota `/test`ela é um endpoint dummy para validar se de tudo certo, e se conseguiu executar o backend

   em caso de sucesso  você verá a seguinte mensagem de retorno

    ```
        Hello World!
    ```

   para o banco de dados pode utilizar a rota `/students` em caso de sucesso
    ```
       []
    ```

## 📝 **Melhorias Futuras**
- **Testes Unitários**:
    - Cobrir casos de sucesso e erro no backend e frontend.
- **Deploy**:
    - Publicar os projetos em uma plataforma como AWS, Azure ou Vercel para acessibilidade global.
- **Frontend**
    - Possíveis casos não esperado de falha ou sucesso.


## 📂 **Decisões de Arquitetura**

### Documentação da Solução
1. **Motivação para o uso do padrão MVC no backend**:
    - Separação de responsabilidades facilitando a manutenção e extensibilidade do código.
2. **Uso do Vuetify no frontend**:
    - Permitindo construir interfaces responsivas com rapidez.

### Ferramentas Utilizadas:
- Docker para isolar ambiente.
- Json-Server para simulação de APIs (em ambientes de teste).
- Git Flow para organização do fluxo de trabalho.

