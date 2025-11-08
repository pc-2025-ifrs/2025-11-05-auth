### 

Requisição -> Controller -> Model
                    -> Persistência
         <--------

### PERSISTÊNCIA

Qual é o contrário de persistente? TRANSIENTE (transitório)

Gravar em mídia persistente (HD, SSD, Flash Drive, mídia óptica, ...).

Organizar o que é salvo:

- Em arquivos (ex.: CSV)
- SGBDR (Sistema Gerenciador de Bases de Dados Relacionais)
(RDBMS)-> (R)elacional -> Existem Relações -> Tabelas -> Relacionamento (Relationship)

Bancos Relacionais (Structured Query Language)

Tipo Servidor

- PostgreSQL
- MySQL
- Oracle
- IBM DB2
- Microsoft SQL Server

Estratégia: rede oportunista

Tipo Embutido (embedded)
- Sqlite
- HSQLDB
- Derby
- SQL Server Compact

O/R M (Object/Relational Mapping)
- Facilita a conversão de objeto -> tabela e vice-e-versa
- Existe penalidade de performance