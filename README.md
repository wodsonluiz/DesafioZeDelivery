# Desafio de Backend [Zé Delivery]
![Projeto](https://user-images.githubusercontent.com/13908258/117749873-ddfff400-b1e8-11eb-9dca-dd9f4e6cfaf0.png)

Microserviço responsavel pelo cadastro e consulta de novos parceiros. 
Dentro do tempo habil o projeto foi desenvolvido para ser o mais desacoplado possivel em "plugins" sendo escrito de maneira que respeitasse o maximo dos limites arquiteturais (Eu escrevi um [artigo](https://wodsonluiz.medium.com/limites-da-arquitetura-b5a088c8c50c) onde aprofundo um pouco mais esse conceito).
O Projeto tem muito potêncial de melhoria e de facil manutenção visando sempre o reaproveitamento de código. Os testes foram escritos de maneira para exemplificar a facilidade de aumentar a cobertura de testes, vale lembrar que o projeto foi escrito em .netcore assim possibilitando rodar em qualquer ambiente por linha de comando ou IDE (VS Code ou Visual Studio). O mesmo foi feito com muito carinho e dedicação, feedbacks de qualquer natureza são bem vindos =)

## Pré requisitos

- Instalar [Docker](https://www.docker.com/get-started)
- Instalar [Docker-compose](https://docs.docker.com/compose/install/)
- Instalar [.netcore 3.1.*](https://dotnet.microsoft.com/download/dotnet/3.1) 

#### Verificar instalação
```
$ docker --version
Docker version 20.10.5, build 55c4c88
```

```
$ docker-compose --version
docker-compose version 1.29.0, build 07737305
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

#### Mongo-express
Para acessar a dashboard de configuração do mongo-express, bastar direcionar no browser para o endpoint _http://localhost:8081/_, nesse ambiente podemos ver documentos e coleções do mongodb

## Executar aplicativo :smiley:

#### build
```
$ cd src/DesafioZeDelivery.Api
$ dotnet build 

output
Build succeeded.
    0 Warning(s)
    0 Error(s)
```

#### executar
```
$ cd src/DesafioZeDelivery.Api
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
- No browser, você pode verificar a saude da aplicação e conexão com o banco de dados apontando para _http://localhost:5000/monitor_, se estiver tudo devidamente configurado você vai visualizar essa tela: 
![Screenshot_2](https://user-images.githubusercontent.com/13908258/118570513-b3ff8200-b752-11eb-8ead-6bd3b11c7006.png)

#### Operações
- _Caso opte por realizar os testes usando o curl, você pode encontrar as informaçoes de instalação nesse [link](https://www.tecmint.com/install-curl-in-linux/)_
- _O teste pode ser realizado por qualquer client que realiza requisições rest http (postman, jmeter, restClient)_

## Realizar testes com o Swagger
- Para ter acesso ao swagger da aplicação basta apontar para _http://localhost:5000/swagger_
- Adicionei ao projeto um [arquivo json](https://github.com/wodsonluiz/DesafioZeDelivery/blob/master/Parceiro.postman_collection.json) para importe do workspace pronto para uso no postaman
- ![Screenshot_1](https://user-images.githubusercontent.com/13908258/117914869-85009080-b2ba-11eb-97c0-e4ab4d09459a.png)


## Testes automatizados
```
$ cd test/DesafioZeDelivery.Test
$ dotnet test

output
A total of 1 test files matched the specified pattern.

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:     4, Skipped:     0, Total:     4, Duration: 873 ms - DesafioZeDelivery.Test.dll
```


