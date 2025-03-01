create database biblioteca; 
use biblioteca;

create table estado (idEstado int primary key auto_increment, UF char(2)); 

create table cidade (idCidade int primary key auto_increment, nome varchar(100), codigoIBGE varchar(7),
fk_idEstado int not null, foreign key (fk_idEstado) references estado (idEstado)); 

create table enderecos (idEndereco int primary key auto_increment, cep varchar(8), logradouro varchar(100), 
numero varchar(30), bairro varchar(100), complemento varchar(100), fk_idCidade int not null
, foreign key (fk_idCidade) references cidade (idCidade)); 

create table biblioteca (idBiblioteca int primary key auto_increment, razaoSocial varchar(100), nomeFantasia varchar(100),
telefone varchar(20), email varchar(60), fk_idEndereco int not null,
foreign key (fk_idEndereco) references enderecos (idEndereco)); 

create table livros (idLivro int primary key auto_increment, titulo varchar(200), autor varchar(200),
editora varchar (200), anoPublicacao date, isbn char(13), genero varchar(100), edicao varchar(60), idioma varchar(60),
fk_idBiblioteca int not null, foreign key (fk_idBiblioteca) references biblioteca (idBiblioteca));


create table emprestimo (idEmprestimo int primary key auto_increment, dataEmprestimo date, dataDevolucao date,
horaEmprestimo time, horaDevolucao time, fk_idFuncionario int not null, foreign key (fk_idFuncionario)
references funcionario (idFuncionario)); 

create table cliente (idCliente int primary key auto_increment, nome varchar(200), cpf char(11) unique, 
dataNascimento date, telefone varchar(20), email varchar(60), fk_idEndereco int not null, 
foreign key (fk_idEndereco) references enderecos (idEndereco)); 

create table emprestar (idEmprestar int primary key auto_increment, fk_idCliente int not null,
fk_idEmprestimo int not null, foreign key (fk_idCliente) references cliente (idCliente), 
foreign key (fk_idEmprestimo) references emprestimo (idEmprestimo)); 

create table funcionario (idFuncionario int primary key auto_increment, nome varchar(200), cpf char(11) unique,
dataNascimento date, telefone varchar(20), fk_idBiblioteca int not null, fk_idEndereco int not null, 
foreign key (fk_idBiblioteca) references biblioteca (idBiblioteca), foreign key (fk_idEndereco) 
references enderecos (idEndereco)); 

insert into estado (uf) values ('RO');
insert into cidade (nome, codigoIBGE, fk_idEstado) values ('Ji-Paraná', '1100122', 1);  
insert into biblioteca (razaoSocial, nomeFantasia, telefone, email, fk_idEndereco) values 
('BibliotecaIfro', 'BibliotecaIFROEDU.RO', '69992213121', 'bibliotecaIFRO@ifro.edu.br', 1); 
insert into enderecos (cep, logradouro, numero, bairro, complemento, fk_idCidade) values
('76900017' ,'Logradouro público', '112', 'bairro do ifro', 'perto da unir',1); 