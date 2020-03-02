use InLock_Games_Manha_Tarde
--DML--------------------
insert into Estudios (NomeEstudio)
values ('Blizzard'),('Rockstar studios'),('Square Enix') ;

insert into jogos (NomeJogo, Descricao, DataLancamento, valor, IdEstudio)
values (' Diablo 3' ,
' é um jogo que contém bastante ação e é viciante, 
seja você um novato ou um fã',' 15/05/2012',
'R$ 99,00',1),
(' Red Dead Redemption II' ,
' jogo eletrônico de ação-aventura western',' 26/10/2018',
'R$ 120,00',1);

insert into TipoUsuario(TituloTipoUsuario)
values ('ADMINISTADOR '),('CLIENTE');


INSERT into Usuario(Email,Senha,IdTipoUsuario)
values ('admin@admin.com','admin',1),('cliente@cliente.com','cliente',2)


select * from Estudios 
select * from Jogos 
select * from Usuario 
select * from TipoUsuario 



