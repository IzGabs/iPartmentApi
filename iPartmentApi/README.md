# Estudos em .NET Core + EntityFramework + Docker + MYSQL

 - .NET Core 5.0
 - EntityFramework Core
 - Docker 
 - Docker-compose 3.4
 - Mysql 


## Requisitos:
	- Ter o docker instalado na máquina

## Comandos: 
  Execução:
    - docker-compose build
    - docker-compose up
    
    util:
	docker-compose build && docker-compose up

  Uteis:
- docker network inspect bridge 
  - Informações sobre a rede dos containers
  -	**Ver se o container do mysql está para 172.17.0.1, caso não, trocar dentro do docker-compose.yml**
   
 - docker container ls (Lista os containers)


## URL's

 *Após o container ser iniciado

http://localhost:5001/api/  <---- Documentacao

http://localhost:5001/api/Produto <---------- /api/{Nome_Controller} trás os endpoints
