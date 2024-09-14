# Sistema-de-API-.NET

## Integrantes

- André Rohregger Machado - RM98110
- Daniele Vargas de Lima -RM99400
- Daniel Alves de Souza -RM552310
- Marcela S Moreira -RM552051
- Nathalia Braga do Nascimento - RM552221

## Projeto

O projeto foi desenvolvido com ASP.Net Web API, baseado em um contexto no qual o usuário consegue cadastrar diferentes tipos de climas e plantaçoes. O tema escolhido é devido ao Challenge, no qual estamos desenvolvendo um sistema de previsao e consulta de safras, com foco em obter lucros por meio do agronegócio.

### Arquiterura escolhida

A arquitetura utilizada no projeto é a de microsserviços. O motivo de escolher essa arquitetura é devido a manutenção mais simples, ou seja, cada serviço é pequeno e isolado, é mais fácil de gerenciar, testar e depurar. Atualizações ou mudanças podem ser feitas em um serviço sem impactar os outros. Se tivesse sido utilizada a monolítica, todo o código-fonte, funcionalidades e serviços do sistema estão em uma única base de código, seria mais complexo a parte da manutenção, pois um erro pode afetar o sistema inteiro.

### Banco de dados

O banco de dados utilizado é o SQL Server, nesse banco iremos realizar os CRUDs da aplicacao.
![image](https://github.com/user-attachments/assets/8e5b771a-15dc-4320-aecd-421ead5277c5)

### CRUD

Podemos observar os métodos CRUD dentro do swagger:
![image](https://github.com/user-attachments/assets/29336585-22ce-4776-90ee-296b2ec93aad)
Na frente de cada método está a descricao, essa inclusao foi feita pois utilizamos uma documentacao com Swagger dentro do código fonte.

### Instruções para realizar o CRUD

### Clima

### Listar Climas

- URL: https://localhost:porta/swagger/api/Clima
- Método: GET
- Retorno: Lista de todos os climas

> [
  {
    "id": 1,
    "nome": "tropical",
    "descricao": "O clima tropical é caracterizado por temperaturas elevadas e chuvas recorrentes, e ocorre nas regiões intertropicais, entre os trópicos de Câncer e Capricórnio"
  }
> ]

### Buscar clima por ID

- URL: https://localhost:porta/swagger/api/Clima/{id}
- Método: GET
- Retorno: O clima correspondente ao ID informado

> [
  {
    "id": 2,
    "nome": "subtropical",
    "descricao": "é um tipo de clima que ocorre em regiões de transição entre as zonas tropicais e temperadas, caracterizado por: Temperaturas amenas, Chuvas bem distribuídas ao longo do ano, Quatro estações bem definidas, Alta amplitude térmica anual"
  }
> ]


### Adicionar Clima

- URL: https://localhost:porta/swagger/api/Clima
- Método: POST

> [
  {
    "nome": "equatorial",
    "descricao": "é um tipo de clima tropical úmido que se caracteriza por ser quente e úmido, com altas temperaturas e chuvas frequentes e intensas"
  }
> ]

### Atualizar Clima

- URL: https://localhost:porta/swagger/api/Clima/{id}
- Método: PUT

> [
  {
    "nome": "árido",
    "descricao": "O clima árido, também conhecido como clima desértico, é caracterizado por: Baixa umidade do ar, Raros registros de chuva, Excesso de evaporação em relação à precipitação, Condições climáticas mais severas que o clima semiárido."
  }
> ]

### Deletar Clima

- URL: https://localhost:porta/swagger/api/Clima/{id}
- Método: DELETE
- Parâmetro: informar ID do clima a ser deletado







