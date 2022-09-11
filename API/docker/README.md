# Docker:
	- Instale o docker na máquina
  
  #### Comandos: 
   Execução:
     - docker-compose build
     - docker-compose up
    
    Util:
    	docker-compose build && docker-compose up

    Comandos:
      - docker network inspect bridge [Informações sobre a rede dos containers]
      	**Ver se o container do mysql está para 172.17.0.1, caso não, trocar dentro do docker-compose.yml**
      
      - docker container ls (Lista os containers).

  #### Execução no VisualStudio

    Para executar no VisualStudio com o Docker, você vai precisar pegar todos os arquivos dentro da pasta /docker
    para a raiz do projeto da api. 
      Depois, é só atualizar o projeto que já vai aparecer para dar run com docker-compose.

	* Se acontecer de dar erro de build no add migration, limpa todo o projeto e compila as solucoes separadamente
