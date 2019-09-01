create database db_usuarios;

use db_usuarios;

create table usuarios(
	idUsuario int auto_increment,
	nome varchar(80) not null,
	senha varchar(80) not null,
	email varchar(150) not null unique,
	primary key(idUsuario)
)charset=utf8;