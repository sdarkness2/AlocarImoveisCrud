CREATE DATABASE ALOCACAO;

CREATE TABLE IF NOT EXISTS IMOVEIS(
	id int Not Null auto_increment,
	tipo varchar(20) Not Null,
    rua varchar(20) Not Null,
    numero int Not Null,
    bairro varchar(30) Not Null,
    cidade varchar(30) Not Null,
    estado varchar(30) Not Null,
    disponivel tinyint Not Null,
    preco decimal Not Null,
    datainicial Datetime not null,
    datafinal datetime,
    primary key (id)
);



