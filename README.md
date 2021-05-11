# Desafio de Backend [Zé Delivery]
![Projeto](https://user-images.githubusercontent.com/13908258/117749873-ddfff400-b1e8-11eb-9dca-dd9f4e6cfaf0.png)

Microserviço responsavel pelo cadastro e consulta de novos parceiros. 
Dentro do tempo habil o projeto foi desenvolvido para ser o mais desacoplado possivel em "plugins" sendo escrito de maneira que respeitasse o maximo dos limites arquiteturais (Eu escrevi um [artigo](https://wodsonluiz.medium.com/limites-da-arquitetura-b5a088c8c50c) onde aprofundo um pouco mais esse conceito).
O Projeto tem muito potêncial de melhoria e de facil manutenção visando sempre o reaproveitamento de código. Os testes foram escritos de maneira para exemplificar a facilidade de aumentar a cobertura de testes de maneira fácil, vale lembrar que o projeto foi escrito em .netcore assim possibilitando reproduzir o teste em qualquer ambiente. O mesmo foi feito com muito carinho e dedicação, feedbacks de qualquer natureza são bem vindos =)

## Pré requisitos

- Instalar [Docker](https://www.docker.com/get-started)
- Instalar [.netcore 3.1.*](https://dotnet.microsoft.com/download/dotnet/3.1) 

#### Verificar instalação
```
$ docker --version
Docker version 20.10.5, build 55c4c88
```

```
$ dotnet --version
3.1.408
```

## Subir instância do mongoDb e mongo-express no container docker
```
$ cd DesafioZeDelivery/
$ docker-compose up -d
$ docker container ps

output 
CONTAINER ID   IMAGE           COMMAND                  CREATED          STATUS         PORTS                      NAMES
3b9796c8ef3c   mongo-express   "tini -- /docker-ent…"   10 seconds ago   Up 8 seconds   0.0.0.0:8081->8081/tcp     desafiozedelivery_mongo-express_1
93062c9263a7   mongo           "docker-entrypoint.s…"   10 seconds ago   Up 8 seconds   0.0.0.0:27017->27017/tcp   desafiozedelivery_mongo_1
```

## Executar aplicativo

#### build
```
$ cd DesafioZeDelivery/src/DesafioZeDelivery.Api
$ dotnet build 

output
Build succeeded.
    0 Warning(s)
    0 Error(s)
```

#### executar
```
$ cd DesafioZeDelivery/src/DesafioZeDelivery.Api
$ dotnet run 

output
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /mnt/d/fonts/DesafioZeDelivery/src/DesafioZeDelivery.Api
```

![giphy (1)](https://user-images.githubusercontent.com/13908258/117663558-2aaae700-b177-11eb-830e-42366df6ae5e.gif)

#### Health check
- No browser, você pode verificar a saude da aplicação e conexão com o banco de dados apontando para _http://localhost:5000/healthcheck_, se estiver tudo devidamente configurado você vai visualizar essa tela: 
- ![Screenshot_3](https://user-images.githubusercontent.com/13908258/117742127-688d2700-b1da-11eb-8b3a-a82b4316d5a8.png)

#### Swagger
- Para ter acesso ao swagger da aplicação basta apontar para _http://localhost:5000/swagger_

### Operações
- _Caso seja necessário instalar o curl, você pode encontrar as informaçoes nesse [link](https://www.tecmint.com/install-curl-in-linux/)_
- _O teste pode ser realizado por qualquer client que realiza requisições rest http (postman, jmeter, restClient)_



#### Incluir novo parceiro 
```
curl --location --request POST 'http://localhost:5000/Parceiro' \
--header 'Content-Type: application/json' \
--data-raw '{
  "id": "wodson", 
  "tradingName": "Adega da Cerveja - Pinheiros",
  "ownerName": "Zé da Silva",
  "document": "1432132123891/0001",
  "coverageArea": { 
    "type": "MultiPolygon", 
    "coordinates": [
      [[[30, 20], [45, 40], [10, 40], [30, 20]]], 
      [[[15, 5], [40, 10], [10, 20], [5, 10], [15, 5]]]
    ]
  },
  "address": { 
    "type": "Point",
    "coordinates": [-46.57421, -21.785741]
  }
}'
```

#### Listar todos os parceiros
```
curl --location --request GET 'http://localhost:5000/Parceiro'
```

#### Filtra por Id
```
curl --location --request GET 'http://localhost:5000/Parceiro/wodson'
```

#### Filtra por localização
```
curl --location --request GET 'http://localhost:5000/Parceiro/GetAddress?lon=-46.57421&lat=-21.785741'
```

## Testes
```
$ cd test/DesafioZeDelivery.Test
$ dotnet test

output
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:     5, Skipped:     0, Total:     5, Duration: 1 s - DesafioZeDelivery.Test.dll 
```


