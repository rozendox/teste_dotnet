# Teste Dotnet - API de Orcamentos

API desenvolvida em ASP.NET Core (.NET 9) com Entity Framework Core 

## Requisitos

- .NET SDK 9.0 ou superior
- SQL Server LocalDB instalado

## Configuracao e Execucao

1. Restaurar pacotes: 

   ```bash
   dotnet restore
   ```

2. Executar as migracoes para criar o banco de dados local (OficinaDb):
   ```bash
   dotnet ef database update
   ```

3. Iniciar a aplicacao:
   ```bash
   dotnet run
   ```

A API estara disponivel em `http://localhost:5256`.

## Testes

Para testar o endpoint de criacao de orcamentos (POST `/api/orcamentos`), envie a requisicao utilizando o arquivo `teste_dotnet.http` no VS Code ou execute o comando abaixo no PowerShell:

```powershell
Invoke-RestMethod -Uri "http://localhost:5256/api/orcamentos" -Method Post -ContentType "application/json" -Body '{"clienteId": 1, "veiculoId": 2, "itens": [{"descricao": "Troca de Oleo", "quantidade": 1, "valorUnitario": 150.00}, {"descricao": "Filtro de Oleo", "quantidade": 1, "valorUnitario": 45.50}]}'
```

## Visualizacao de Dados no Banco

Para visualizar os dados diretamente no banco de dados local (OficinaDb) utilizando o terminal PowerShell:

Visualizar orcamentos criados:
```powershell
sqlcmd -S "(localdb)\MSSQLLocalDB" -d OficinaDb -Q "SELECT * FROM Orcamentos"
```

Visualizar os itens dos orcamentos:
```powershell
sqlcmd -S "(localdb)\MSSQLLocalDB" -d OficinaDb -Q "SELECT * FROM OrcamentoItens"
```

Alternativamente, utilize ferramentas de banco de dados (Azure Data Studio, SSMS ou a extensao MSSQL no VS Code) com as seguintes credenciais:
- Servidor: `(localdb)\MSSQLLocalDB`
- Banco de dados: `OficinaDb`
- Autenticacao: `Windows Authentication` / `Integrated`

