# iPartmentAPI em .NET Core + EntityFramework + Docker + MYSQL

	*** Após o container ser iniciado

	http://localhost:5001/api/  <---- Documentacao

	http://localhost:5001/api/Produto <---------- /api/{Nome_Controller} trás os endpoints
	
#### Configuração 
- Comece sempre fazendo a instalação do docker e de tudo que for preciso para executar o projeto.
- Pegue os arquivos dentro da pasta /docker e jogue para /api.
- Realizar um **add-migration** first quando for rodar pela primeira vez.
- Executar o projeto uma primeira vez para ver se está tudo funcionando.

# Padrão de desenvolvimento

### Padrões

- Ter certeza que adicionou uma migration.
- Escrever testes quando possível e se quiser testar camadas funcionando.
- O projeto deve ser estruturado utilizando DDD, assim mantemos ele escalável e limpo.

		- Utilizar o basico do DDD de Controller->Service->Repository.
		- Dentro da Domain não deve haver implementação concreta de Services e Repositórios, apenas interfaces e Entidades.

- Tente manter um código limpo e desacoplado.

P.S. O módulo de usuário foi feito utilizando uma métodologia antiga, use como padrão o modo como foi feito o CREATE do RealState.


	



