create database biblioteca; 
use biblioteca;
create table livros (idLivro int primary key auto_increment, titulo varchar(200), autor varchar(200),
editora varchar (200), anoPublicacao date, isbn char(13), genero varchar(100), edicao varchar(60), idioma varchar(60));

desc livros; 