
# Desafio-Teste-Ilia

Esse projeto foi desenvolvido como parte do processo seletivo na Ilia.


## Tecnologias Utilizadas
.Net
SQL Server

## Objetivo

O objetivo dessa API é preparar e desenvolver o backend e as rotas da API que tem
como objetivo, bater pontos, alocar esforço em diferentes projetos, e gerar relatórios
de acompanhamento de horários e de projetos.

## Rotas

#### POST - /v1/batidas
Responsável por fazer o registro dos horários a cada dia.

Example Body:
```
{
  "dataHora": "2023-02-17T06:52:08.779Z"
}
```

Example Response: 201
```
{
  "id": 4,
  "dia": "2023-02-16T00:00:00Z",
  "horarios": [
    {
      "dataHora": "2023-02-16T12:10:02.586Z"
    }
  ]
}
```

Example Response: 403
```
{
  "mensagem": "Tempo de Almoço deve ser de no mínimo 1 hora."
}
```
---

#### POST - /v1/alocacoes
Responsável por delegar as horas de trabalho para um determinado projeto.

Example Body:
```
{
  "dia": "2023-02-17T12:05:59.830Z",
  "tempo": "PT5H30M0S",
  "nomeProjeto": "ACME Group"
}
```
Example Response: 201
```
{
  "dia": "2023-01-16T12:13:20.888Z",
  "tempo": "PT5S",
  "nomeProjeto": "Pessoal"
}
```

Example Response: 400
```
{
  "mensagem": "Você deve finalizar primeiro todos os registros do dia desejado."
}
```
---
#### GET - /v1/folha-de-ponto/{anoMes}
Responsável por gerar relatório do colaborador ativo.
anoMes deve estar no padrão aaaa-MM

Example Request:
```
/v1/folha-de-ponto/2023-01
```

Example Response: 200
```
{
  "id": 0,
  "mes": "2023-01",
  "horasTrabalhadas": "08:00:00",
  "horasExcedentes": "00:00:00",
  "horasDevidas": "6.08:00:00",
  "registros": [
    {
      "id": 1,
      "dia": "2023-01-16T00:00:00",
      "horarios": [
        {
          "dataHora": "2023-01-16T09:00:00"
        },
        {
          "dataHora": "2023-01-16T12:00:00"
        },
        {
          "dataHora": "2023-01-16T13:00:00"
        },
        {
          "dataHora": "2023-01-16T18:00:00"
        }
      ]
    }
  ],
  "alocacoes": [
    {
      "dia": "2023-01-16T00:00:00",
      "tempo": "04:25:10",
      "nomeProjeto": "ACME Group"
    },
    {
      "dia": "2023-01-16T00:00:00",
      "tempo": "00:00:05",
      "nomeProjeto": "Pessoal"
    }
  ]
}
```

Example Response: 400
```
{
  "mensagem": "Não existem registros para essa data"
}
```

## Como Executar na sua máquina

Antes de iniciar é de **extrema** importância que você tenha os requisitos mínimos:
- Visual Studio ou Rider
- Microsoft SQL Server;
- Git
- Postman

## Passo a Passo

- Crie uma pasta e abra sua linha de comando
- Execute o comando
```
git clone https://github.com/1Baldasso/Desafio-Teste-Ilia
```
- Após o fim da etapa de clonagem, abra o arquivo _Desafio-Teste-Ilia.sln_
- Verifique o nome da ConnectionString no arquivo _/Database/APIContext/_
- Se for utilizar outro Servidor que não o Local Padrão do Windows, mude os seguintes campos de acordo com sua preferência
![image](https://user-images.githubusercontent.com/82400557/219655733-0f088385-0dcb-41d8-9082-045b98111064.png)

- Em seguida, no gerenciador de soluções, clique com o Botão direito na solução e clique em "Restaurar Pacotes Nuget" ou _Restore Nuget Packages_
- Após o processo estar concluído abra o terminal integrado e digite o comando:
```
dotnet ef database update --project Desafio-Teste-Ilia
```
- Após o fim processo, defina o projeto Desafio-Teste-Ilia como projeto de inicialização se já não estiver
- Clique em iniciar.
- O ambiente local de desenvolvimento estará disponível durante o período que estiver rodando no Visual Studio.
- Uma janela com alguns dados da API será aberta, sinta-se a vontade para explorar por ela ou pelo Postman.
