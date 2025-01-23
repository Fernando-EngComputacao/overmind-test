## 💻 Sobre o projeto

OvermindTeste é um projeto no qual se acessa uma api via client, recebe seus dados (devices), os filtra, gera CSV dos produtos Apple, inclusos os camposde "Nome" e "Preço".

---

## ⚙️ Funcionalidades

- [x] GET dos Produtos Apple (nome, preço) com registro em local escolhido;
- [x] GET dos Produtos Apple (nome, preço) com registro no bin/degub;
- [x] GET de todos os Produtos da API (todos os campos);
- [x] Criação CSV dos Produto Apple (nome, preço).

---

## :1st_place_medal: Envolvimento do projeto
- [x] Implementação de GET;
- [x] Registro de CSV;
  - Local do arquivo no projeto: pasta raíz do projeto > Core > File > apple_list.csv
- [x] Documentação da API em Swagger com anotação;
- [x] Atuação de filtragem de consultas com LINQ;


--- 

## :hammer: NuGet Dependências
- [x] Swashbuckle.AspNetCore 6.4

  
---

## :bookmark: Recursos Adicionais
### - 2 GETs
- Primeiro: Busca todos os produtos e filtra pela marca Apple (string: Nome, decimal: Preco), optei por considerar os produtos com valor 0.

- Segundo: Busca todos os dispositivos, com todas suas informações.

### - Local Registro CSV
 - No ```appsettings.json``` há uma variável de nome ```SalveCSV:LocalArmazenamento```, é neste local que você informará o local do armazenamento do CSV.  
 - Decisão focada na melhoria e performance para cenário do sistema em produção.

### - Organização:
 - Optei por separar a parte que acessa a API (client) do serviço do controllador (service) para melhor gestão, escabilidade e performance.



---

## :star: Orientações Adicionais
#### - Altere o caminho para registrar o CSV onde desejar
###### - Vá ao appsettings.json da pasta raíz do seu projeto e insira o caminho para registro de seu csv.

    "SalveCSV": {
        "LocalArmazenamento": "C:\\local\\desejado\\",
        "NomeArquivo": "nome_arquivo_desejado.csv"
    }
}

###### - Exemplo preenchido:

    "SalveCSV": {
        "LocalArmazenamento": "C:\\user\\fernando\\Downloads",
        "NomeArquivo": "lista_produtos_apple.csv"
    }
}

####  :sunglasses: Autor: Fernando Furtado (2025)
- [LinkedIn](https://linkedin.com/in/furtadof/)
- [GitHub](https://github.com/Fernando-EngComputacao)