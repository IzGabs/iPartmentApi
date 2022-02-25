# iPartmentAPI em .NET Core + EntityFramework + Docker + MYSQL

 - .NET Core 5.0
 - EntityFramework Core
 - Docker 
 - Docker-compose 3.4
 - Mysql 


## Docker:
	- Instale o docker na máquina
  ### Comandos: 
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

  ### Execução no VisualStudio

    Para executar no VisualStudio com o Docker, você vai precisar pegar todos os arquivos dentro da pasta /docker
    para a raiz do projeto. 
      Depois, é só atualizar o projeto que já vai aparecer para dar run com docker-compose.


## URL's

 *Após o container ser iniciado

http://localhost:5001/api/  <---- Documentacao

http://localhost:5001/api/Produto <---------- /api/{Nome_Controller} trás os endpoints
