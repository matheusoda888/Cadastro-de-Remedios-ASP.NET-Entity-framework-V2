
create database AtosEntity9

create login AtosEntity9 with password='Atos_Entity_9';
create user AtosEntity9 from login AtosEntity9;



exec sp_addrolemember 'DB_DATAREADER', 'AtosEntity9';
exec sp_addrolemember 'DB_DATAWRITER', 'AtosEntity9';


create table Remedios(
	id integer primary key identity,
	nome varchar(30) not null,
	
)

create table Pacientes(
	id integer primary key identity,
	nome varchar(30) not null,
)

create table Horarios(
	id integer primary key identity,
	nomeRemedio varchar(30) not null,
	nomePaciente varchar(30) not null,
	tempo integer not null,
	horario time not null,
	foreign key (nomeRemedio) references Remedios(nome),
	foreign key (nomePaciente) references Pacientes(nome)
)

