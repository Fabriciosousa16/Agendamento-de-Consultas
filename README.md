# Agendamento-de-Consultas
Sistema para Agendamento de Consultas

O sistema Possui 5 entidades

User, Doctor, Patiente, Query e QueryPatient, todas com os metodos GET,POST,PUT e DELETE.

Usuários precisam está autenticados para realizar ações no sistema, como parte de teste, o metodo POST de Users pode ser usado sem precisar de autenticação.

Na parte do cadastro (User)

{
  "name": "String",
  "cpf": "string",
  "idProfile": 1,
  "email": "email@teste.com",
  "password": "string"
}

Name é obrigatório
Cpf tem que esta no formado "###.###.###-##"
idprofile recebe 1 ou 2, 1 se for Medico  2 se for Paciente, e só pode receber numeros
Email tem que ter o "@"
Password tem que conter no minimo 8 caracterer, contendo letras, numeros e catactere especias.

Os outros métodos precisam está autenticados no sistema.

Autenticação funciona da sequinte maneira.

Método Post Login

{
  "email": "user@example.com",
  "password": "string"
}

Ao realizar o login, tem que pegar o valor do aceestoken que foi gerado usando jwt

"acessToken": "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDA3LzA1L3htbGRzaWctbW9yZSNzaGEyNTYtcnNhLU1HRjEiLCJ0eXAiOiJKV1QifQ.eyJ1bmlxdWVfbmFtZSI6WyJ1c2VyQGV4YW1wbGUuY29tIiwidXNlckBleGFtcGxlLmNvbSJdLCJqdGkiOiIzNTgxNDlmMi1hNTUzLTQxNGItYmEyNy1mZTA1ZGUwMjljZjAiLCJJZFByb2ZpbGUiOjEsIm5iZiI6MTcwMjQyNjU2OCwiZXhwIjoxNzAyNDMzNzY4LCJpYXQiOjE3MDI0MjY1NjgsImlzcyI6Iklzc3VlciIsImF1ZCI6IkF1ZGllbmNlIn0.q4utOALURLKAC8mNb6Yyzbvwy0HZ74DOklCWEPr_ncEMvsmOXkz0S-SRqUqDna-mQpe6MpCiE-W2_CjYPouNspz-kDI_WmFoff4T7oq3KpHP2zz9jhfGUnyJMZntV95GVTSW6gBVAQC0GUNgmoS6lp8OXN4iTp7w3l_vaZFWGE8X_9EMi8ORlAoYTADiNWZ_5zcakFdlU4No8HtvqbKh6POvGfm_0K9myd7c1N6W99trWM1SFCxMcdGTbfCUe2B0ik4cfEviXwG-XhVbjQbgVMCnz6UR14R4HXipVA6p7AmboPwzI2aIYR7eFc8cy2xnzzdpJx4QJYsJvxBlZYyy-g",

Peque o valor entre as abas, depois vai no botão de Autenticação.

Lá coloque a chave Bearer + Acess Token. Exemplo.
Bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDA3LzA1L3htbGRzaWctbW9yZSNzaGEyNTYtcnNhLU1HRjEiLCJ0eXAiOiJKV1QifQ.eyJ1bmlxdWVfbmFtZSI6WyJ1c2VyQGV4YW1wbGUuY29tIiwidXNlckBleGFtcGxlLmNvbSJdLCJqdGkiOiIzNTgxNDlmMi1hNTUzLTQxNGItYmEyNy1mZTA1ZGUwMjljZjAiLCJJZFByb2ZpbGUiOjEsIm5iZiI6MTcwMjQyNjU2OCwiZXhwIjoxNzAyNDMzNzY4LCJpYXQiOjE3MDI0MjY1NjgsImlzcyI6Iklzc3VlciIsImF1ZCI6IkF1ZGllbmNlIn0.q4utOALURLKAC8mNb6Yyzbvwy0HZ74DOklCWEPr_ncEMvsmOXkz0S-SRqUqDna-mQpe6MpCiE-W2_CjYPouNspz-kDI_WmFoff4T7oq3KpHP2zz9jhfGUnyJMZntV95GVTSW6gBVAQC0GUNgmoS6lp8OXN4iTp7w3l_vaZFWGE8X_9EMi8ORlAoYTADiNWZ_5zcakFdlU4No8HtvqbKh6POvGfm_0K9myd7c1N6W99trWM1SFCxMcdGTbfCUe2B0ik4cfEviXwG-XhVbjQbgVMCnz6UR14R4HXipVA6p7AmboPwzI2aIYR7eFc8cy2xnzzdpJx4QJYsJvxBlZYyy-g.

OBS - Sempre faça logout no sistema antes de trocar de usuário, pois a validade do token está programada para 2 horas.

Sobre Autenticação.

Apenas Patientes tem acessos a Patient e QueryPatient
Apenas Medicos tem acessos a Doctors e Query.

em Doctors.

{
  "specialty": "string",
  "idUser": 0
}

Vai pedir a especialidade do médico e o iduser, id user pq a tabela tem referencia a Users.

Patient

{
  "medicalPlan": "string",
  "idUser": 0
}

Vai pedir o Plano Medico, e o id_user.

QueryPatient

Vai ser onde o paciente vai agendar a consultas.

{
  "startTime": "2023-12-13T01:29:30.207Z",
  "endTime": "2023-12-13T01:29:30.207Z",
  "idStatus": 0,
  "idDoctor": 0,
  "idPatient": 0
}

Pedir o horario inicial e horario final da consulta, bem como o idStatus que pode ser 1 - Agendado, 2- Concluida, 3 - Cancelada.
IdDoctor, vai pegar o Id do medico e o IdPatient vai pegar o ID_Patient.


Query

Onde a consulta é realizada

{
  "reason": "string",
  "medicalRecord": "string",
  "idDoctor": 0,
  "idPatient": 0
}

Reason é a razão da consulta, ou seja o motivo pelo qual a consulta está sendo realizada.
medicalRecord - è o diagnostico da consulta.
IdDoctor - o ID do medico que realizou a consulta
IdPatient - o ID do Paciente que realizou a consulta.

----------------------------------------------------------------------------------------------------------------------------------------------

Tecnologias Utilizads

C#
ASP.NET
Postman
Mysql
Sistema Desenvolvido utilizando principios de Arquitetura DDD.

------------------------------------------------------------------------------------------------------------------------------------------------
Passos para rodar o sistema.

Tenha instalado o banco de dados mysql. 

Acesse a class ConfigureRepository, altere as informações abaixo de acordo com suas necessidades.

 serviceCollection.AddDbContext<MyContext>(
               options => options.UseMySql("Server=localhost;Port=3306;Database=dbagendamento;Uid=root;Pwd=root")
           );

Server - Servidor
Port - Porta
Darabase - Nome do Banco
Uid - Nome de Usuário
Pwd = Senha

As informações mencionadas acima, devem ser alteradas tambem na clss ContextFactory

var connectionString = "Server=localhost;Port=3306;Database=dbAgendamento;Uid=root;Pwd=";

Dentro da pasta Api.Data, conforme o caminho abaixo, rode o seguinte comando.

C:\Agendamento-de-Consultas\src\Api.Data>


dotnet ef migrations add EntityMigration   (Usado para criar as entidades)

dotnet ef database update  (Comando usado para atualizar a base de dados)


Para rodar o sistema, entre na pasta Api.Application, conforme caminho abaixo e rode o comando dotnet run

C:\Agendamento-de-Consultas\src\Api.Application>

Após rodar o comando verifique as informações

info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000

Acessar o link disponivel, no nosso caso, o http://localhost:5000.

------------------------------------------------------------------------------------------------------------------------------------------------
Trabahos futuros

impleementei no banco uma tabela para consultar historicos do pacientes, mas nçao chequei a imprementar a mesma.














