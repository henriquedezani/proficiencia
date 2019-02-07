CREATE DATABASE proficiencia;

USE proficiencia;

CREATE TABLE usuario
(
	id INT IDENTITY PRIMARY KEY,
	name VARCHAR(250) NOT NULL,
	email VARCHAR(250) NOT NULL,
	senha VARCHAR(250) NOT NULL
);


CREATE TABLE tarefa
(
	id INT IDENTITY PRIMARY KEY,
	id_usuario INT NOT NULL,
	descricao VARCHAR(250) NOT NULL,
	conclusao VARCHAR(250) NOT NULL,
	CONSTRAINT fk_tarefa_usuario_id 
	FOREIGN KEY(id_usuario) REFERENCES usuario(id)
);