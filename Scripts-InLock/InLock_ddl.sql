create database InLock_Games_Manha_Tarde
--DDL---------------
use InLock_Games_Manha_Tarde

create table Estudios (
IdEstudio int primary key identity,
NomeEstudio varchar (200) not null 
)

create table Jogos (
IdJogo int primary key identity,
NomeJogo varchar (200) not null ,
Descricao varchar (200) not null ,
DataLancamento datetime  not null ,
Valor varchar (200) not null ,
IdEstudio int FOREIGN KEY references  Estudios(IdEstudio)
)

create table TipoUsuario (
IdTipoUsuario int primary key identity,
TituloTipoUsuario varchar (200) not null 
)

create table Usuario (
 IdUsuario int primary key identity,
 Email varchar (200) not null ,
 Senha varchar (200) not null ,
 IdTipoUsuario int FOREIGN KEY references  TipoUsuario(idTipoUsuario)
)

drop table Usuario